<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtSampleRate = New System.Windows.Forms.TextBox()
        Me.Run = New System.Windows.Forms.Button()
        Me.txtStartAddr = New System.Windows.Forms.TextBox()
        Me.txtRegisterQty = New System.Windows.Forms.TextBox()
        Me.txtSlaveID = New System.Windows.Forms.TextBox()
        Me.lstRegisterValues = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPortName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PortName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtvalue = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtSampleRate
        '
        Me.txtSampleRate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtSampleRate.Location = New System.Drawing.Point(165, 93)
        Me.txtSampleRate.Name = "txtSampleRate"
        Me.txtSampleRate.Size = New System.Drawing.Size(146, 20)
        Me.txtSampleRate.TabIndex = 8
        '
        'Run
        '
        Me.Run.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Run.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Run.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Run.Location = New System.Drawing.Point(164, 254)
        Me.Run.Name = "Run"
        Me.Run.Size = New System.Drawing.Size(146, 29)
        Me.Run.TabIndex = 9
        Me.Run.Text = "All Plc Values"
        Me.Run.UseVisualStyleBackColor = False
        '
        'txtStartAddr
        '
        Me.txtStartAddr.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtStartAddr.Location = New System.Drawing.Point(165, 40)
        Me.txtStartAddr.Name = "txtStartAddr"
        Me.txtStartAddr.Size = New System.Drawing.Size(146, 20)
        Me.txtStartAddr.TabIndex = 10
        '
        'txtRegisterQty
        '
        Me.txtRegisterQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtRegisterQty.Location = New System.Drawing.Point(165, 66)
        Me.txtRegisterQty.Name = "txtRegisterQty"
        Me.txtRegisterQty.Size = New System.Drawing.Size(146, 20)
        Me.txtRegisterQty.TabIndex = 11
        '
        'txtSlaveID
        '
        Me.txtSlaveID.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtSlaveID.Location = New System.Drawing.Point(165, 120)
        Me.txtSlaveID.Name = "txtSlaveID"
        Me.txtSlaveID.Size = New System.Drawing.Size(56, 20)
        Me.txtSlaveID.TabIndex = 12
        '
        'lstRegisterValues
        '
        Me.lstRegisterValues.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lstRegisterValues.Location = New System.Drawing.Point(407, 12)
        Me.lstRegisterValues.Multiline = True
        Me.lstRegisterValues.Name = "lstRegisterValues"
        Me.lstRegisterValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lstRegisterValues.Size = New System.Drawing.Size(368, 389)
        Me.lstRegisterValues.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 254)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 29)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Single Plc Value"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtPortName
        '
        Me.txtPortName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPortName.Location = New System.Drawing.Point(165, 13)
        Me.txtPortName.Name = "txtPortName"
        Me.txtPortName.Size = New System.Drawing.Size(146, 20)
        Me.txtPortName.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "PLC Starting/Single Address "
        '
        'PortName
        '
        Me.PortName.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PortName.Location = New System.Drawing.Point(2, 16)
        Me.PortName.Name = "PortName"
        Me.PortName.Size = New System.Drawing.Size(133, 17)
        Me.PortName.TabIndex = 17
        Me.PortName.Text = "Port Number"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Registor StartAddress "
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Registor Total Quantity"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 17)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Sample Rate"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(12, 289)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 29)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "ON"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(12, 324)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(146, 29)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "OFF"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(164, 324)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(146, 29)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "WRITE"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 17)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Value Write"
        '
        'Txtvalue
        '
        Me.Txtvalue.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Txtvalue.Location = New System.Drawing.Point(165, 150)
        Me.Txtvalue.Name = "Txtvalue"
        Me.Txtvalue.Size = New System.Drawing.Size(146, 20)
        Me.Txtvalue.TabIndex = 25
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(164, 289)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(146, 29)
        Me.Button5.TabIndex = 27
        Me.Button5.Text = "READ (D-Value)"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(12, 414)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(763, 27)
        Me.LblStatus.TabIndex = 29
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Txtvalue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PortName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPortName)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstRegisterValues)
        Me.Controls.Add(Me.txtSlaveID)
        Me.Controls.Add(Me.txtRegisterQty)
        Me.Controls.Add(Me.txtStartAddr)
        Me.Controls.Add(Me.Run)
        Me.Controls.Add(Me.txtSampleRate)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSampleRate As TextBox
    Friend WithEvents Run As Button
    Friend WithEvents txtStartAddr As TextBox
    Friend WithEvents txtRegisterQty As TextBox
    Friend WithEvents txtSlaveID As TextBox
    Friend WithEvents lstRegisterValues As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtPortName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PortName As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Txtvalue As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents LblStatus As Label
End Class
