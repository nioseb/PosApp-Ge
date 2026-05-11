<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Favtorizacia
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextPass = New System.Windows.Forms.TextBox
        Me.TextID = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Sylfaen", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(363, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "გამოიყენეთ საიდენტიფიკაციო ბარათი"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextPass
        '
        Me.TextPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextPass.Location = New System.Drawing.Point(15, 86)
        Me.TextPass.MaxLength = 50
        Me.TextPass.Name = "TextPass"
        Me.TextPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPass.ShortcutsEnabled = False
        Me.TextPass.Size = New System.Drawing.Size(360, 22)
        Me.TextPass.TabIndex = 4
        '
        'TextID
        '
        Me.TextID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextID.Location = New System.Drawing.Point(15, 58)
        Me.TextID.MaxLength = 50
        Me.TextID.Name = "TextID"
        Me.TextID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextID.ShortcutsEnabled = False
        Me.TextID.Size = New System.Drawing.Size(360, 22)
        Me.TextID.TabIndex = 3
        '
        'Favtorizacia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 123)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextPass)
        Me.Controls.Add(Me.TextID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Favtorizacia"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ავტორიზაცია"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextPass As System.Windows.Forms.TextBox
    Friend WithEvents TextID As System.Windows.Forms.TextBox
End Class
