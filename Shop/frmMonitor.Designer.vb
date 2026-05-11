<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitor
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Appearance1.BackColor = System.Drawing.Color.SaddleBrown
        Appearance1.BackColor2 = System.Drawing.Color.Bisque
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox1.Appearance = Appearance1
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid
        Me.UltraGroupBox1.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(343, 285)
        Me.UltraGroupBox1.TabIndex = 0
        '
        'UltraPictureBox1
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.Appearance = Appearance2
        Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.UltraPictureBox1.Location = New System.Drawing.Point(2, 0)
        Me.UltraPictureBox1.MaintainAspectRatio = False
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.ScaleImage = Infragistics.Win.ScaleImage.Always
        Me.UltraPictureBox1.Size = New System.Drawing.Size(339, 283)
        Me.UltraPictureBox1.TabIndex = 0
        Me.UltraPictureBox1.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'frmMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 285)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMonitor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMonitor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
End Class
