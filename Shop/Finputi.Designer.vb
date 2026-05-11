<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Finputi
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
        Me.Text_Input = New System.Windows.Forms.TextBox
        Me.InpCancel = New System.Windows.Forms.Button
        Me.InpOK = New System.Windows.Forms.Button
        Me.InpTxt = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Text_Input
        '
        Me.Text_Input.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Text_Input.Location = New System.Drawing.Point(12, 80)
        Me.Text_Input.MaxLength = 50
        Me.Text_Input.Name = "Text_Input"
        Me.Text_Input.ShortcutsEnabled = False
        Me.Text_Input.Size = New System.Drawing.Size(328, 22)
        Me.Text_Input.TabIndex = 0
        '
        'InpCancel
        '
        Me.InpCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.InpCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.InpCancel.Location = New System.Drawing.Point(265, 46)
        Me.InpCancel.Name = "InpCancel"
        Me.InpCancel.Size = New System.Drawing.Size(75, 28)
        Me.InpCancel.TabIndex = 2
        Me.InpCancel.Text = "Cancel"
        Me.InpCancel.UseVisualStyleBackColor = True
        Me.InpCancel.Visible = False
        '
        'InpOK
        '
        Me.InpOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.InpOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.InpOK.Location = New System.Drawing.Point(265, 12)
        Me.InpOK.Name = "InpOK"
        Me.InpOK.Size = New System.Drawing.Size(75, 28)
        Me.InpOK.TabIndex = 1
        Me.InpOK.Text = "OK"
        Me.InpOK.UseVisualStyleBackColor = True
        Me.InpOK.Visible = False
        '
        'InpTxt
        '
        Me.InpTxt.AutoSize = True
        Me.InpTxt.Font = New System.Drawing.Font("Sylfaen", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.InpTxt.Location = New System.Drawing.Point(12, 9)
        Me.InpTxt.Name = "InpTxt"
        Me.InpTxt.Size = New System.Drawing.Size(51, 22)
        Me.InpTxt.TabIndex = 3
        Me.InpTxt.Text = "Label"
        '
        'Finputi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(352, 115)
        Me.Controls.Add(Me.Text_Input)
        Me.Controls.Add(Me.InpCancel)
        Me.Controls.Add(Me.InpOK)
        Me.Controls.Add(Me.InpTxt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Finputi"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 10, 6)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_Input As System.Windows.Forms.TextBox
    Friend WithEvents InpCancel As System.Windows.Forms.Button
    Friend WithEvents InpOK As System.Windows.Forms.Button
    Friend WithEvents InpTxt As System.Windows.Forms.Label
End Class
