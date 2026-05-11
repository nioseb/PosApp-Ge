<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingsReport
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBookingsReport))
        Me.wbHtmlHost = New System.Windows.Forms.WebBrowser()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.panelBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'wbHtmlHost
        '
        Me.wbHtmlHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbHtmlHost.Location = New System.Drawing.Point(0, 0)
        Me.wbHtmlHost.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbHtmlHost.Name = "wbHtmlHost"
        Me.wbHtmlHost.Size = New System.Drawing.Size(984, 506)
        Me.wbHtmlHost.TabIndex = 0
        '
        'panelBottom
        '
        Me.panelBottom.Controls.Add(Me.btnClose)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(0, 506)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(984, 63)
        Me.panelBottom.TabIndex = 1
        '
        'btnClose
        '
        Appearance7.Image = CType(resources.GetObject("Appearance7.Image"), Object)
        Appearance7.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnClose.Appearance = Appearance7
        Me.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.ImageSize = New System.Drawing.Size(55, 55)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(909, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.ShowFocusRect = False
        Me.btnClose.ShowOutline = False
        Me.btnClose.Size = New System.Drawing.Size(75, 63)
        Me.btnClose.TabIndex = 1
        '
        'frmBookingsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(984, 569)
        Me.Controls.Add(Me.wbHtmlHost)
        Me.Controls.Add(Me.panelBottom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBookingsReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reservations Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wbHtmlHost As WebBrowser
    Friend WithEvents panelBottom As Panel
    Friend WithEvents btnClose As Infragistics.Win.Misc.UltraButton
End Class
