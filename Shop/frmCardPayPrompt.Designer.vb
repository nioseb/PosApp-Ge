<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardPayPrompt
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
        Me.MsgYes = New System.Windows.Forms.Button
        Me.MsgClose = New System.Windows.Forms.Button
        Me.btnInstallment = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'MsgYes
        '
        Me.MsgYes.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.MsgYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MsgYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsgYes.Location = New System.Drawing.Point(53, 38)
        Me.MsgYes.Name = "MsgYes"
        Me.MsgYes.Size = New System.Drawing.Size(124, 110)
        Me.MsgYes.TabIndex = 2
        Me.MsgYes.Text = "შესრულება ტერმინალით"
        Me.MsgYes.UseVisualStyleBackColor = True
        '
        'MsgClose
        '
        Me.MsgClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.MsgClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MsgClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsgClose.Location = New System.Drawing.Point(220, 38)
        Me.MsgClose.Name = "MsgClose"
        Me.MsgClose.Size = New System.Drawing.Size(124, 110)
        Me.MsgClose.TabIndex = 3
        Me.MsgClose.Text = "შესრულება ტერმინალის გარეშე"
        Me.MsgClose.UseVisualStyleBackColor = True
        '
        'btnInstallment
        '
        Me.btnInstallment.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnInstallment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInstallment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnInstallment.Location = New System.Drawing.Point(135, 231)
        Me.btnInstallment.Name = "btnInstallment"
        Me.btnInstallment.Size = New System.Drawing.Size(124, 110)
        Me.btnInstallment.TabIndex = 6
        Me.btnInstallment.Text = "განვადება"
        Me.btnInstallment.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.Image = Global.Shop.My.Resources.Resources.double_arrow_down
        Me.Button2.Location = New System.Drawing.Point(-3, 177)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(404, 29)
        Me.Button2.TabIndex = 5
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmCardPayPrompt
        '
        Me.AcceptButton = Me.MsgYes
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 205)
        Me.Controls.Add(Me.btnInstallment)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.MsgClose)
        Me.Controls.Add(Me.MsgYes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCardPayPrompt"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "უნაღდო ოპერაცია"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MsgYes As System.Windows.Forms.Button
    Friend WithEvents MsgClose As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnInstallment As System.Windows.Forms.Button
End Class
