<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitorCheck
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("itmImage")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("itmName")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("itmQuantity")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("itmUnit")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("itmPrice")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("itmAmount")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("itmKey", 0)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("sumAmount", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "itmAmount", 5, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.Center, "itmName", 1, True)
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("itmImage")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("itmName")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("itmQuantity")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("itmUnit")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("itmPrice")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("itmAmount")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitorCheck))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'UltraGrid1
        '
        Me.UltraGrid1.DataSource = Me.UltraDataSource1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGrid1.DisplayLayout.Appearance = Appearance1
        Me.UltraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridBand1.ColHeadersVisible = False
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn1.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(0, 56)
        UltraGridColumn1.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn1.RowLayoutColumnInfo.SpanY = 4
        UltraGridColumn1.Width = 48
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance26.FontData.BoldAsString = "True"
        Appearance26.FontData.SizeInPoints = 11.0!
        Appearance26.TextVAlignAsString = "Top"
        UltraGridColumn2.CellAppearance = Appearance26
        UltraGridColumn2.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn2.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn2.Format = ""
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn2.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(244, 56)
        UltraGridColumn2.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn2.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn2.Width = 284
        UltraGridColumn3.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance27.FontData.BoldAsString = "True"
        Appearance27.FontData.SizeInPoints = 11.0!
        Appearance27.TextHAlignAsString = "Right"
        Appearance27.TextVAlignAsString = "Top"
        UltraGridColumn3.CellAppearance = Appearance27
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn3.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(48, 56)
        UltraGridColumn3.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn3.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn3.Width = 48
        UltraGridColumn4.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance28.FontData.BoldAsString = "True"
        Appearance28.FontData.SizeInPoints = 11.0!
        Appearance28.TextHAlignAsString = "Left"
        Appearance28.TextVAlignAsString = "Top"
        UltraGridColumn4.CellAppearance = Appearance28
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn4.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(28, 56)
        UltraGridColumn4.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn4.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn4.Width = 26
        UltraGridColumn5.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance29.FontData.BoldAsString = "True"
        Appearance29.FontData.SizeInPoints = 11.0!
        Appearance29.TextHAlignAsString = "Right"
        Appearance29.TextVAlignAsString = "Top"
        UltraGridColumn5.CellAppearance = Appearance29
        UltraGridColumn5.Format = "x # ##0.00"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn5.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(48, 56)
        UltraGridColumn5.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn5.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn5.Width = 76
        UltraGridColumn6.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance30.FontData.BoldAsString = "False"
        Appearance30.FontData.SizeInPoints = 14.0!
        Appearance30.TextHAlignAsString = "Right"
        Appearance30.TextVAlignAsString = "Top"
        UltraGridColumn6.CellAppearance = Appearance30
        UltraGridColumn6.Format = "= # ##0.00₾"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.RowLayoutColumnInfo.OriginX = 10
        UltraGridColumn6.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(51, 56)
        UltraGridColumn6.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn6.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn6.Width = 62
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
        UltraGridBand1.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.None
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Appearance31.FontData.BoldAsString = "False"
        Appearance31.FontData.Name = "Sylfaen"
        Appearance31.FontData.SizeInPoints = 30.0!
        Appearance31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Appearance31.TextHAlignAsString = "Center"
        SummarySettings1.Appearance = Appearance31
        SummarySettings1.DisplayFormat = "{0:0.00} ₾."
        SummarySettings1.GroupBySummaryValueAppearance = Appearance32
        SummarySettings1.Lines = 3
        SummarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
        UltraGridBand1.SummaryFooterCaption = "გადასახდელი თანხა:"
        Me.UltraGrid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.None
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(45, Byte), Integer))
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.Name = "Sylfaen"
        Appearance9.FontData.SizeInPoints = 12.0!
        Appearance9.ForeColor = System.Drawing.Color.White
        Appearance9.TextHAlignAsString = "Left"
        Me.UltraGrid1.DisplayLayout.CaptionAppearance = Appearance9
        Me.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.GroupByBox.Appearance = Appearance10
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
        Me.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance12.BackColor2 = System.Drawing.SystemColors.Control
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance12
        Me.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.UltraGrid1.DisplayLayout.Override.ActiveCellAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.UltraGrid1.DisplayLayout.Override.ActiveRowAppearance = Appearance14
        Appearance15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.UltraGrid1.DisplayLayout.Override.AddRowAppearance = Appearance15
        Appearance16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.UltraGrid1.DisplayLayout.Override.AddRowCellAppearance = Appearance16
        Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes
        Me.UltraGrid1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.UltraGrid1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.UltraGrid1.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleSummaryFooter = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleSummaryFooterCaption = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleSummaryValue = Infragistics.Win.UIElementBorderStyle.None
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = Appearance17
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Appearance18.FontData.Name = "Sylfaen"
        Appearance18.FontData.SizeInPoints = 12.0!
        Appearance18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid1.DisplayLayout.Override.CellAppearance = Appearance18
        Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid1.DisplayLayout.Override.CellPadding = 0
        Me.UltraGrid1.DisplayLayout.Override.DefaultRowHeight = 48
        Appearance19.BackColor = System.Drawing.SystemColors.Control
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = Appearance19
        Appearance20.TextHAlignAsString = "Left"
        Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance = Appearance20
        Me.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.FontData.Name = "Sylfaen"
        Appearance21.FontData.SizeInPoints = 12.0!
        Appearance21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.UltraGrid1.DisplayLayout.Override.RowAppearance = Appearance21
        Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid1.DisplayLayout.Override.RowSpacingAfter = 2
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.UltraGrid1.DisplayLayout.Override.SelectedCellAppearance = Appearance22
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = Appearance23
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.UltraGrid1.DisplayLayout.Override.SpecialRowSeparator = Infragistics.Win.UltraWinGrid.SpecialRowSeparator.None
        Me.UltraGrid1.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Sylfaen"
        Appearance24.FontData.SizeInPoints = 10.0!
        Appearance24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(17, Byte), Integer))
        Appearance24.TextHAlignAsString = "Center"
        Me.UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.UltraGrid1.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide
        Me.UltraGrid1.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None
        Me.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(600, 570)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "თქვენი შენაძენი:"
        Me.UltraGrid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UltraDataSource1
        '
        UltraDataColumn1.DataType = GetType(System.Drawing.Bitmap)
        UltraDataColumn1.ReadOnly = Infragistics.Win.DefaultableBoolean.[False]
        UltraDataColumn2.ReadOnly = Infragistics.Win.DefaultableBoolean.[False]
        UltraDataColumn3.DataType = GetType(Double)
        UltraDataColumn3.ReadOnly = Infragistics.Win.DefaultableBoolean.[False]
        UltraDataColumn4.ReadOnly = Infragistics.Win.DefaultableBoolean.[False]
        UltraDataColumn5.DataType = GetType(Double)
        UltraDataColumn5.ReadOnly = Infragistics.Win.DefaultableBoolean.[False]
        UltraDataColumn6.DataType = GetType(Double)
        UltraDataColumn6.ReadOnly = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6})
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(316, 274)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'frmMonitorCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 570)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.UltraGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMonitorCheck"
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmMonitorCheck"
        Me.TopMost = True
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
