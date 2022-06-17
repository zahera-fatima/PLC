Imports System
Imports System.Timers
Imports System.IO.Ports


Public Class Form1
    Dim sp As New SerialPort()
    Private timer As New System.Timers.Timer()
    Private ShiftTimer As New System.Timers.Timer()
    Dim RefTime As New TimeSpan(19, 0, 0)
    Dim timespan2 As New TimeSpan()
    Dim timediff As New TimeSpan()
    Dim milsec As Integer
    Dim TimerCount As Integer = 0
    Public modbusStatus As String
    Private spOpen As Boolean
    Private dataType As String
    Dim values() As Integer = Nothing



    Private Sub GetCRC(ByVal message() As Byte, ByRef CRC() As Byte)
        Dim CRCFull As UShort = &HFFFF
        Dim CRCHigh As Byte = &HFF, CRCLow As Byte = &HFF
        Dim CRCLSB As Char

        For i As Integer = 0 To ((message.Length) - 2) - 1
            CRCFull = CUShort(CRCFull Xor message(i))


            For j As Integer = 0 To 7
                CRCLSB = ChrW(CRCFull And &H1)
                CRCFull = CUShort((CInt(CRCFull) >> 1) And &H7FFF)

                If AscW(CRCLSB) = 1 Then
                    CRCFull = CUShort(CRCFull Xor &HA001)
                End If
            Next j
        Next i
        CRCHigh = CByte((CInt(CRCFull) >> 8) And &HFF)
        CRC(1) = CRCHigh
        CRCLow = CByte(CRCFull And &HFF)
        CRC(0) = CRCLow
    End Sub
    Private Sub BuildMessage(ByVal address As Byte, ByVal type As Byte, ByVal start As UShort, ByVal registers As UShort, ByRef message() As Byte)

        Dim CRC(1) As Byte
        Dim StartLwrByte As UShort
        Dim AndLwrByte As UShort = 255
        Dim Reglwrbyte As UShort
        StartLwrByte = start And AndLwrByte
        Reglwrbyte = registers And AndLwrByte
        message(0) = address
        message(1) = type
        message(2) = CByte(CInt(start) >> 8)
        message(3) = CByte(StartLwrByte)
        message(4) = CByte(CInt(registers) >> 8)
        message(5) = CByte(Reglwrbyte)

        GetCRC(message, CRC)
        message(message.Length - 2) = CRC(0)
        message(message.Length - 1) = CRC(1)
    End Sub
    Private Sub buildmessage1(ByVal address As Byte, ByVal type As Byte, ByVal start As UShort, ByVal registers As UShort, ByRef message() As Byte)

        Dim crc(1) As Byte
        Dim startlwrbyte As UShort
        Dim andlwrbyte As UShort = 255
        startlwrbyte = start And andlwrbyte
        message(0) = address
        message(1) = type
        message(2) = CByte(CInt(start) >> 8)
        message(3) = CByte(startlwrbyte)
        message(4) = CByte(registers)
        message(5) = CByte(CInt(registers) >> 8)

        GetCRC(message, crc)
        message(message.Length - 2) = crc(0)
        message(message.Length - 1) = crc(1)
    End Sub
    Private Function CheckResponse(ByVal response() As Byte) As Boolean

        Dim CRC(1) As Byte
        GetCRC(response, CRC)
        If CRC(0) = response(response.Length - 2) AndAlso CRC(1) = response(response.Length - 1) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub GetResponse(ByRef response() As Byte)


        For i As Integer = 0 To response.Length - 1
            Try
                response(i) = CByte(sp.ReadByte())
            Catch ex As Exception
                lstRegisterValues.AppendText("No response from PLC" & vbCrLf)
                Exit Sub

            End Try
        Next i
        lstRegisterValues.AppendText("Waiting For PLC response" & vbCrLf)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Run.Click
        Dim registers As UShort
        Dim address As Byte
        Dim start As UShort
        Dim IDtxt As String
        Dim IDcnt As Integer
        Dim str As String = Nothing
        IDtxt = Convert.ToString(txtSlaveID.Text)
        IDcnt = CInt(txtSlaveID.Text)
        Dim values(Convert.ToInt32(txtRegisterQty.Text) - 1) As Integer
        start = Convert.ToUInt16(txtStartAddr.Text)
        registers = Convert.ToUInt16(txtRegisterQty.Text)

        lstRegisterValues.Clear()
        If sp.IsOpen Then
            For j As Integer = 0 To IDcnt - 1
                Dim v As Integer = j + 1
                address = Convert.ToByte(v)

                sp.DiscardOutBuffer()
                sp.DiscardInBuffer()
                If start >= 0 And start < 4168 Then
                    str = "R"
                ElseIf start >= 6000 And start < 8999 Then
                    str = "D"
                End If
                Dim message(7) As Byte

                Dim response((5 + 2 * registers) - 1) As Byte

                BuildMessage(address, CByte(3), start, registers, message)

                Try
                    sp.Write(message, 0, message.Length)
                    System.Threading.Thread.Sleep(50)
                    GetResponse(response)
                    System.Threading.Thread.Sleep(50)

                Catch err As InvalidOperationException

                    lstRegisterValues.AppendText("Error in read event: No response from plc " & v & vbCrLf)

                End Try

                lstRegisterValues.AppendText("PLC " & v & vbCrLf)
                If CheckResponse(response) Then
                    System.Threading.Thread.Sleep(100)
                    For i As Integer = 0 To ((response.Length - 5) \ 2) - 1
                        values(i) = response(2 * i + 3)
                        values(i) <<= 8
                        values(i) += response(2 * i + 4)

                        lstRegisterValues.AppendText(str & (CInt(message(3))) + i & " = " & values(i) & vbCrLf)
                    Next i

                    modbusStatus = "Read successful"

                Else
                    modbusStatus = "CRC error"
                    lstRegisterValues.AppendText("In PLC" & " " & v & " CRC error occur " & vbCrLf)
                End If
            Next j
        Else
            modbusStatus = "Serial port not open"

        End If
        lblStatus.Text = modbusStatus
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not sp.IsOpen Then
            sp.PortName = "COM3"
            sp.BaudRate = 9600
            sp.DataBits = 8
            sp.Parity = Parity.None
            sp.StopBits = StopBits.One
            sp.ReadTimeout = 100


            Try
                sp.Open()
            Catch err As Exception
                modbusStatus = "Error opening " & sp.PortName & ": " & err.Message


            End Try
            modbusStatus = sp.PortName & " opened successfully"
            spOpen = True

        Else
            modbusStatus = sp.PortName & " already opened"

        End If
        dataType = "Decimal"
        If sp.IsOpen() Then
            timer.AutoReset = True
            txtPortName.Text = sp.PortName
            txtRegisterQty.Text = "7"
            txtSampleRate.Text = "5000"
            txtSlaveID.Text = ""
            txtStartAddr.Text = "0"
            If txtSampleRate.Text <> "" Then
                timer.Interval = Convert.ToDouble(txtSampleRate.Text)
            Else
                timer.Interval = 1000
            End If
            timer.Start()
        End If
        lblStatus.Text = modbusStatus
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim registers As UShort
        Dim address As Byte
        Dim start As UShort
        Dim IDtxt As String
        Dim IDcnt As Integer
        Dim str As String = Nothing
        IDtxt = Convert.ToString(txtSlaveID.Text)
        IDcnt = CInt(txtSlaveID.Text)
        Dim values(Convert.ToInt32(txtRegisterQty.Text) - 1) As Integer
        start = Convert.ToUInt16(txtStartAddr.Text)
        registers = Convert.ToUInt16(txtRegisterQty.Text)
        address = Convert.ToByte(IDtxt)
        lstRegisterValues.Clear()
        If sp.IsOpen Then

            sp.DiscardOutBuffer()
            sp.DiscardInBuffer()
            If start >= 0 And start < 4168 Then
                str = "R"
            ElseIf start >= 6000 And start < 8999 Then
                str = "D"
            End If

            Dim message(7) As Byte

            Dim response((5 + 2 * registers) - 1) As Byte

            BuildMessage(address, CByte(3), start, registers, message)

            Try
                sp.Write(message, 0, message.Length)
                System.Threading.Thread.Sleep(50)
                GetResponse(response)
                System.Threading.Thread.Sleep(50)

            Catch err As InvalidOperationException

                lstRegisterValues.AppendText("Error in read event: No response from plc ")

            End Try

            lstRegisterValues.AppendText("PLC " & IDcnt & vbCrLf)

            If CheckResponse(response) Then
                System.Threading.Thread.Sleep(50)
                For i As Integer = 0 To ((response.Length - 5) \ 2) - 1
                    values(i) = response(2 * i + 3)
                    values(i) <<= 8
                    values(i) += response(2 * i + 4)
                    lstRegisterValues.AppendText(str & (CInt(message(3))) + i & " = " & values(i) & vbCrLf)
                Next i

                modbusStatus = "Read successful"

            Else
                modbusStatus = "CRC error"
                lstRegisterValues.AppendText("In PLC" & " " & IDcnt & " CRC error occur " & vbCrLf)
            End If

        Else
            modbusStatus = "Serial port not open"

        End If
        lblStatus.Text = modbusStatus
    End Sub



    Private Sub button2_click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim datas As UShort
        Dim address As Byte
        Dim start As UShort
        Dim idtxt As String
        Dim idcnt As Integer
        idtxt = Convert.ToString(txtSlaveID.Text)
        idcnt = CInt(txtSlaveID.Text)
        Dim values(Convert.ToInt32(txtRegisterQty.Text) - 1) As Integer
        start = Convert.ToUInt16(txtStartAddr.Text)
        datas = Convert.ToUInt16("255")
        address = Convert.ToByte(idtxt)
        lstRegisterValues.Clear()
        If sp.IsOpen Then

            sp.DiscardOutBuffer()
            sp.DiscardInBuffer()

            Dim message(7) As Byte

            Dim response(8) As Byte

            buildmessage1(address, CByte(5), start, datas, message)

            Try
                sp.Write(message, 0, message.Length)
                System.Threading.Thread.Sleep(50)
                GetResponse(response)
                System.Threading.Thread.Sleep(50)

            Catch err As InvalidOperationException

                lstRegisterValues.AppendText("error in read event: no response from plc ")

            End Try

            lstRegisterValues.AppendText("plc " & idcnt & vbCrLf)

            If CheckResponse(response) Then
                System.Threading.Thread.Sleep(50)

                modbusStatus = "read successful"

            Else
                modbusStatus = "crc error"
                lstRegisterValues.AppendText("in plc" & " " & idcnt & " crc error occur " & vbCrLf)
            End If
            'next j
        Else
            modbusStatus = "serial port not open"

        End If
        lblStatus.Text = modbusStatus
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim datas As UShort
        Dim address As Byte
        Dim start As UShort
        Dim idtxt As String
        Dim idcnt As Integer
        idtxt = Convert.ToString(txtSlaveID.Text)
        idcnt = CInt(txtSlaveID.Text)
        Dim values(Convert.ToInt32(txtRegisterQty.Text) - 1) As Integer
        start = Convert.ToUInt16(txtStartAddr.Text)
        datas = Convert.ToUInt16("0")
        address = Convert.ToByte(idtxt)
        lstRegisterValues.Clear()
        If sp.IsOpen Then

            sp.DiscardOutBuffer()
            sp.DiscardInBuffer()

            Dim message(7) As Byte

            Dim response(8) As Byte

            buildmessage1(address, CByte(5), start, datas, message)

            Try
                sp.Write(message, 0, message.Length)
                System.Threading.Thread.Sleep(50)
                GetResponse(response)
                System.Threading.Thread.Sleep(50)

            Catch err As InvalidOperationException

                lstRegisterValues.AppendText("error in read event: no response from plc ")

            End Try

            lstRegisterValues.AppendText("plc " & idcnt & vbCrLf)

            If CheckResponse(response) Then
                System.Threading.Thread.Sleep(50)

                modbusStatus = "read successful"

            Else
                modbusStatus = "crc error"
                lstRegisterValues.AppendText("in plc" & " " & idcnt & " crc error occur " & vbCrLf)
            End If

        Else
            modbusStatus = "serial port not open"

        End If
        lblStatus.Text = modbusStatus
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim registers As UShort
        Dim address As Byte
        Dim start As UShort
        Dim IDtxt As String
        Dim IDcnt As Integer
        IDtxt = Convert.ToString(txtSlaveID.Text)
        IDcnt = CInt(txtSlaveID.Text)
        Dim values(Convert.ToInt32(txtRegisterQty.Text) - 1) As Integer
        start = Convert.ToUInt16(txtStartAddr.Text)
        registers = Convert.ToUInt16(Txtvalue.Text)
        address = Convert.ToByte(IDtxt)
        'lstRegisterValues.Clear()
        If sp.IsOpen Then



            sp.DiscardOutBuffer()
                sp.DiscardInBuffer()

                Dim message(7) As Byte

            Dim response(7) As Byte

            BuildMessage(address, CByte(6), start, registers, message)

                Try
                    sp.Write(message, 0, message.Length)
                    System.Threading.Thread.Sleep(50)
                    GetResponse(response)
                System.Threading.Thread.Sleep(50)

            Catch err As InvalidOperationException

                lstRegisterValues.AppendText("Error in read event: No response from plc " & vbCrLf)

            End Try

            lstRegisterValues.AppendText("PLC " & IDtxt & vbCrLf)
            If CheckResponse(response) Then
                System.Threading.Thread.Sleep(100)

                modbusStatus = "Write successful"

            Else
                    modbusStatus = "CRC error"
                lstRegisterValues.AppendText("In PLC" & " " & IDtxt & " CRC error occur " & vbCrLf)
            End If

        Else
            modbusStatus = "Serial port not open"

        End If
        lblStatus.Text = modbusStatus
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim registers As UShort
        Dim address As Byte
        Dim start As UShort
        Dim IDtxt As String
        Dim IDcnt As Integer
        Dim str As String = Nothing
        Dim iba As BitArray = New BitArray(8)
        IDtxt = Convert.ToString(txtSlaveID.Text)
        IDcnt = CInt(txtSlaveID.Text)
        Dim values(Convert.ToInt32(txtRegisterQty.Text) - 1) As Integer
        start = Convert.ToUInt16(txtStartAddr.Text)
        registers = Convert.ToUInt16(txtRegisterQty.Text)
        Dim quantity As Integer = CInt(txtRegisterQty.Text)
        address = Convert.ToByte(IDtxt)
        lstRegisterValues.Clear()
        If sp.IsOpen Then

            sp.DiscardOutBuffer()
            sp.DiscardInBuffer()

            If start >= 0 And start < 256 Then
                str = "Y"
            ElseIf start >= 1000 And start < 1256 Then
                str = "X"
            ElseIf start >= 2000 And start < 4002 Then
                str = "M"
            ElseIf start >= 6000 And start < 7000 Then
                str = "S"

            End If

            Dim message(7) As Byte

            Dim response((5 + ((registers + 7) \ 8)) - 1) As Byte


            BuildMessage(address, CByte(1), start, registers, message)

            Try
                sp.Write(message, 0, message.Length)
                System.Threading.Thread.Sleep(50)
                GetResponse(response)
                System.Threading.Thread.Sleep(50)

            Catch err As InvalidOperationException

                lstRegisterValues.AppendText("Error in read event: No response from plc " & vbCrLf)

            End Try

            lstRegisterValues.AppendText("PLC " & IDtxt & vbCrLf)
            If CheckResponse(response) Then
                System.Threading.Thread.Sleep(100)
                For i As Integer = 0 To ((quantity + 7) \ 8) - 1
                    values(i) = response(i + 3)
                    Dim a() As Byte = {values(i)}
                    iba = New BitArray(a)
                    For j As Integer = 0 To iba.Count - 1
                        If iba(j) = True Then
                            lstRegisterValues.AppendText(str & (CInt(message(3))) + j & " = " & "ON" & vbCrLf)
                        Else
                            lstRegisterValues.AppendText(str & (CInt(message(3))) + j & " = " & "OFF" & vbCrLf)
                        End If
                    Next j

                Next i

                    modbusStatus = "Write successful"

            Else
                modbusStatus = "CRC error"
                lstRegisterValues.AppendText("In PLC" & " " & IDtxt & " CRC error occur " & vbCrLf)
            End If

        Else
            modbusStatus = "Serial port not open"

        End If
        lblStatus.Text = modbusStatus
    End Sub
End Class
