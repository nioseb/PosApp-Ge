<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSaleSublines
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FSaleSublines))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel_Body = New System.Windows.Forms.Panel
        Me.btnRemove = New System.Windows.Forms.Button
        Me.DGV_Sales = New System.Windows.Forms.DataGridView
        Me.ColKodi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJgufi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDasaxeleba = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFasi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRaodenoba = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJami = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblDescription = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txt_kodi = New Shop.MTGCComboBox
        Me.Panel_Body.SuspendLayout()
        CType(Me.DGV_Sales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_Body
        '
        Me.Panel_Body.AutoScroll = True
        Me.Panel_Body.BackColor = System.Drawing.Color.White
        Me.Panel_Body.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Body.Controls.Add(Me.btnRemove)
        Me.Panel_Body.Controls.Add(Me.DGV_Sales)
        Me.Panel_Body.Controls.Add(Me.lblDescription)
        Me.Panel_Body.Controls.Add(Me.btnAdd)
        Me.Panel_Body.Controls.Add(Me.txt_kodi)
        Me.Panel_Body.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Body.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Body.Name = "Panel_Body"
        Me.Panel_Body.Size = New System.Drawing.Size(773, 288)
        Me.Panel_Body.TabIndex = 1
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Transparent
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(737, 252)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(36, 34)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.UseVisualStyleBackColor = False
        Me.btnRemove.Visible = False
        '
        'DGV_Sales
        '
        Me.DGV_Sales.AllowUserToAddRows = False
        Me.DGV_Sales.AllowUserToDeleteRows = False
        Me.DGV_Sales.AllowUserToResizeColumns = False
        Me.DGV_Sales.AllowUserToResizeRows = False
        Me.DGV_Sales.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGV_Sales.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Sylfaen", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Sales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Sales.ColumnHeadersHeight = 28
        Me.DGV_Sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV_Sales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColKodi, Me.ColJgufi, Me.ColDasaxeleba, Me.ColFasi, Me.ColRaodenoba, Me.ColJami})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(189, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Sylfaen", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Sales.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Sales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DGV_Sales.Location = New System.Drawing.Point(0, 0)
        Me.DGV_Sales.MultiSelect = False
        Me.DGV_Sales.Name = "DGV_Sales"
        Me.DGV_Sales.RowHeadersVisible = False
        Me.DGV_Sales.RowTemplate.Height = 35
        Me.DGV_Sales.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DGV_Sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGV_Sales.Size = New System.Drawing.Size(770, 30)
        Me.DGV_Sales.StandardTab = True
        Me.DGV_Sales.TabIndex = 2
        Me.DGV_Sales.TabStop = False
        '
        'ColKodi
        '
        Me.ColKodi.HeaderText = "კოდი"
        Me.ColKodi.Name = "ColKodi"
        Me.ColKodi.ReadOnly = True
        Me.ColKodi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColJgufi
        '
        Me.ColJgufi.HeaderText = "ჯგუფი"
        Me.ColJgufi.Name = "ColJgufi"
        Me.ColJgufi.ReadOnly = True
        Me.ColJgufi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJgufi.Visible = False
        '
        'ColDasaxeleba
        '
        Me.ColDasaxeleba.HeaderText = "დასახელება"
        Me.ColDasaxeleba.Name = "ColDasaxeleba"
        Me.ColDasaxeleba.ReadOnly = True
        Me.ColDasaxeleba.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColFasi
        '
        Me.ColFasi.HeaderText = "ფასი"
        Me.ColFasi.Name = "ColFasi"
        Me.ColFasi.ReadOnly = True
        Me.ColFasi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFasi.Visible = False
        '
        'ColRaodenoba
        '
        Me.ColRaodenoba.HeaderText = "რაოდ"
        Me.ColRaodenoba.Name = "ColRaodenoba"
        Me.ColRaodenoba.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRaodenoba.Visible = False
        '
        'ColJami
        '
        Me.ColJami.HeaderText = "ჯამი"
        Me.ColJami.Name = "ColJami"
        Me.ColJami.ReadOnly = True
        Me.ColJami.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJami.Visible = False
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Sylfaen", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(45, 260)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(694, 24)
        Me.lblDescription.TabIndex = 5
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAdd.Location = New System.Drawing.Point(0, 244)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(43, 43)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txt_kodi
        '
        Me.txt_kodi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txt_kodi.ColumnNum = 5
        Me.txt_kodi.ColumnWidth = "10;10;10;10;10"
        Me.txt_kodi.DisplayMember = "Text"
        Me.txt_kodi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txt_kodi.DropDownArrowBackColor = System.Drawing.Color.Transparent
        Me.txt_kodi.DropDownBackColor = System.Drawing.Color.Transparent
        Me.txt_kodi.DropDownForeColor = System.Drawing.Color.Black
        Me.txt_kodi.DropDownHeight = 1
        Me.txt_kodi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_kodi.DropDownWidth = 1
        Me.txt_kodi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_kodi.GridLineColor = System.Drawing.Color.LightGray
        Me.txt_kodi.GridLineHorizontal = False
        Me.txt_kodi.GridLineVertical = True
        Me.txt_kodi.HighlightBorderColor = System.Drawing.Color.Blue
        Me.txt_kodi.IntegralHeight = False
        Me.txt_kodi.ItemHeight = 31
        Me.txt_kodi.Location = New System.Drawing.Point(1, 28)
        Me.txt_kodi.Name = "txt_kodi"
        Me.txt_kodi.NormalBorderColor = System.Drawing.Color.Black
        Me.txt_kodi.Size = New System.Drawing.Size(160, 38)
        Me.txt_kodi.SourceDataString = Nothing
        Me.txt_kodi.TabIndex = 0
        '
        'FSaleSublines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 288)
        Me.Controls.Add(Me.Panel_Body)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FSaleSublines"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "მენიუს შემადგენლობა"
        Me.TopMost = True
        Me.Panel_Body.ResumeLayout(False)
        CType(Me.DGV_Sales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel_Body As System.Windows.Forms.Panel
    Friend WithEvents txt_kodi As Shop.MTGCComboBox
    Friend WithEvents DGV_Sales As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ColKodi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJgufi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDasaxeleba As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFasi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRaodenoba As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJami As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lblDescription As System.Windows.Forms.Label
End Class
