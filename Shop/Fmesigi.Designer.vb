<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fmesigi
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
        Me.MsgStatus = New System.Windows.Forms.Label
        Me.MsgNo = New System.Windows.Forms.Button
        Me.MsgOK = New System.Windows.Forms.Button
        Me.MsgYes = New System.Windows.Forms.Button
        Me.MsgLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'MsgStatus
        '
        Me.MsgStatus.AutoSize = True
        Me.MsgStatus.Font = New System.Drawing.Font("Sylfaen", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsgStatus.ForeColor = System.Drawing.Color.Red
        Me.MsgStatus.Location = New System.Drawing.Point(23, 0)
        Me.MsgStatus.Name = "MsgStatus"
        Me.MsgStatus.Size = New System.Drawing.Size(65, 25)
        Me.MsgStatus.TabIndex = 4
        Me.MsgStatus.Text = "Status"
        '
        'MsgNo
        '
        Me.MsgNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MsgNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsgNo.Location = New System.Drawing.Point(166, 59)
        Me.MsgNo.Name = "MsgNo"
        Me.MsgNo.Size = New System.Drawing.Size(75, 47)
        Me.MsgNo.TabIndex = 3
        Me.MsgNo.Text = "არა"
        Me.MsgNo.UseVisualStyleBackColor = True
        '
        'MsgOK
        '
        Me.MsgOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MsgOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsgOK.Location = New System.Drawing.Point(111, 59)
        Me.MsgOK.Name = "MsgOK"
        Me.MsgOK.Size = New System.Drawing.Size(75, 47)
        Me.MsgOK.TabIndex = 2
        Me.MsgOK.Text = "OK"
        Me.MsgOK.UseVisualStyleBackColor = True
        '
        'MsgYes
        '
        Me.MsgYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MsgYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsgYes.Location = New System.Drawing.Point(56, 59)
        Me.MsgYes.Name = "MsgYes"
        Me.MsgYes.Size = New System.Drawing.Size(75, 47)
        Me.MsgYes.TabIndex = 1
        Me.MsgYes.Text = "დიახ"
        Me.MsgYes.UseVisualStyleBackColor = True
        '
        'MsgLabel
        '
        Me.MsgLabel.AutoSize = True
        Me.MsgLabel.Font = New System.Drawing.Font("Sylfaen", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MsgLabel.Location = New System.Drawing.Point(23, 24)
        Me.MsgLabel.Name = "MsgLabel"
        Me.MsgLabel.Size = New System.Drawing.Size(60, 25)
        Me.MsgLabel.TabIndex = 5
        Me.MsgLabel.Text = "Label"
        Me.MsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Fmesigi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(294, 114)
        Me.Controls.Add(Me.MsgStatus)
        Me.Controls.Add(Me.MsgNo)
        Me.Controls.Add(Me.MsgOK)
        Me.Controls.Add(Me.MsgYes)
        Me.Controls.Add(Me.MsgLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fmesigi"
        Me.Padding = New System.Windows.Forms.Padding(20, 0, 20, 5)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "მესიჯი"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MsgStatus As System.Windows.Forms.Label
    Friend WithEvents MsgNo As System.Windows.Forms.Button
    Friend WithEvents MsgOK As System.Windows.Forms.Button
    Friend WithEvents MsgYes As System.Windows.Forms.Button
    Friend WithEvents MsgLabel As System.Windows.Forms.Label
End Class
