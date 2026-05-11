<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FUserSelect
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FUserSelect))
        Me.GridF = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        CType(Me.GridF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridF
        '
        Me.GridF.AllowUserToAddRows = False
        Me.GridF.AllowUserToDeleteRows = False
        Me.GridF.AllowUserToResizeColumns = False
        Me.GridF.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Sylfaen", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridF.DefaultCellStyle = DataGridViewCellStyle2
        Me.GridF.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridF.Location = New System.Drawing.Point(0, 0)
        Me.GridF.MultiSelect = False
        Me.GridF.Name = "GridF"
        Me.GridF.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Sylfaen", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GridF.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.GridF.RowTemplate.Height = 40
        Me.GridF.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridF.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.GridF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridF.Size = New System.Drawing.Size(349, 33)
        Me.GridF.StandardTab = True
        Me.GridF.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "პერსონალი"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 344
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance7.Image = CType(resources.GetObject("Appearance7.Image"), Object)
        Appearance7.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnClose.Appearance = Appearance7
        Me.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(0, -7)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.ShowFocusRect = False
        Me.btnClose.ShowOutline = False
        Me.btnClose.Size = New System.Drawing.Size(349, 42)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Visible = False
        '
        'FUserSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(347, 35)
        Me.Controls.Add(Me.GridF)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FUserSelect"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FUserSelect"
        CType(Me.GridF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridF As DataGridView
    Friend WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
