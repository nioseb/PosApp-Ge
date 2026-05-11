<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrderTablesSagaOne
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrderTablesSagaOne))
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.btnSwitchViews = New Infragistics.Win.Misc.UltraButton()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.tlpGrid = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpStreetSide = New System.Windows.Forms.TableLayoutPanel()
        Me.TABLE15 = New System.Windows.Forms.Button()
        Me.tlpCentre = New System.Windows.Forms.TableLayoutPanel()
        Me.TABLE07 = New System.Windows.Forms.Button()
        Me.TABLE08 = New System.Windows.Forms.Button()
        Me.TABLE09 = New System.Windows.Forms.Button()
        Me.TABLE10 = New System.Windows.Forms.Button()
        Me.TABLE11 = New System.Windows.Forms.Button()
        Me.TABLE12 = New System.Windows.Forms.Button()
        Me.TABLE14 = New System.Windows.Forms.Button()
        Me.tlpWallSide = New System.Windows.Forms.TableLayoutPanel()
        Me.TABLE23 = New System.Windows.Forms.Button()
        Me.TABLE24 = New System.Windows.Forms.Button()
        Me.TABLE25 = New System.Windows.Forms.Button()
        Me.TABLE20 = New System.Windows.Forms.Button()
        Me.TABLE21 = New System.Windows.Forms.Button()
        Me.TABLE22 = New System.Windows.Forms.Button()
        Me.tlpStreetCorner = New System.Windows.Forms.TableLayoutPanel()
        Me.TABLE16 = New System.Windows.Forms.Button()
        Me.TABLE17 = New System.Windows.Forms.Button()
        Me.TABLE18 = New System.Windows.Forms.Button()
        Me.TABLE19 = New System.Windows.Forms.Button()
        Me.TABLE26 = New System.Windows.Forms.Button()
        Me.TABLE27 = New System.Windows.Forms.Button()
        Me.tlpCorner = New System.Windows.Forms.TableLayoutPanel()
        Me.TABLE01 = New System.Windows.Forms.Button()
        Me.TABLE06 = New System.Windows.Forms.Button()
        Me.TABLE04 = New System.Windows.Forms.Button()
        Me.TABLE02 = New System.Windows.Forms.Button()
        Me.TABLE05 = New System.Windows.Forms.Button()
        Me.TABLE03 = New System.Windows.Forms.Button()
        Me.lblRestaurant = New System.Windows.Forms.Label()
        Me.lblBar = New System.Windows.Forms.Label()
        Me.lblGrill = New System.Windows.Forms.Label()
        Me.panelBottom.SuspendLayout()
        Me.tlpGrid.SuspendLayout()
        Me.tlpStreetSide.SuspendLayout()
        Me.tlpCentre.SuspendLayout()
        Me.tlpWallSide.SuspendLayout()
        Me.tlpStreetCorner.SuspendLayout()
        Me.tlpCorner.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelBottom
        '
        Me.panelBottom.Controls.Add(Me.btnSwitchViews)
        Me.panelBottom.Controls.Add(Me.btnClose)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(0, 709)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(1024, 59)
        Me.panelBottom.TabIndex = 8
        '
        'btnSwitchViews
        '
        Appearance7.Image = Global.Shop.My.Resources.Resources.applications1
        Appearance7.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSwitchViews.Appearance = Appearance7
        Me.btnSwitchViews.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.btnSwitchViews.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSwitchViews.ImageSize = New System.Drawing.Size(48, 48)
        Me.btnSwitchViews.ImageTransparentColor = System.Drawing.Color.White
        Me.btnSwitchViews.Location = New System.Drawing.Point(0, 0)
        Me.btnSwitchViews.Name = "btnSwitchViews"
        Me.btnSwitchViews.ShowFocusRect = False
        Me.btnSwitchViews.ShowOutline = False
        Me.btnSwitchViews.Size = New System.Drawing.Size(64, 59)
        Me.btnSwitchViews.TabIndex = 1
        '
        'btnClose
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnClose.Appearance = Appearance1
        Me.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.ImageSize = New System.Drawing.Size(48, 48)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(960, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.ShowFocusRect = False
        Me.btnClose.ShowOutline = False
        Me.btnClose.Size = New System.Drawing.Size(64, 59)
        Me.btnClose.TabIndex = 0
        '
        'tlpGrid
        '
        Me.tlpGrid.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tlpGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpGrid.ColumnCount = 4
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpGrid.Controls.Add(Me.tlpStreetSide, 1, 3)
        Me.tlpGrid.Controls.Add(Me.tlpCentre, 1, 2)
        Me.tlpGrid.Controls.Add(Me.tlpWallSide, 0, 0)
        Me.tlpGrid.Controls.Add(Me.tlpStreetCorner, 2, 3)
        Me.tlpGrid.Controls.Add(Me.tlpCorner, 1, 0)
        Me.tlpGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGrid.Location = New System.Drawing.Point(0, 0)
        Me.tlpGrid.Name = "tlpGrid"
        Me.tlpGrid.RowCount = 4
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGrid.Size = New System.Drawing.Size(1024, 709)
        Me.tlpGrid.TabIndex = 9
        '
        'tlpStreetSide
        '
        Me.tlpStreetSide.ColumnCount = 3
        Me.tlpStreetSide.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.14516!))
        Me.tlpStreetSide.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.48387!))
        Me.tlpStreetSide.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.96774!))
        Me.tlpStreetSide.Controls.Add(Me.TABLE15, 1, 1)
        Me.tlpStreetSide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpStreetSide.Location = New System.Drawing.Point(259, 535)
        Me.tlpStreetSide.Name = "tlpStreetSide"
        Me.tlpStreetSide.RowCount = 3
        Me.tlpStreetSide.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpStreetSide.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpStreetSide.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpStreetSide.Size = New System.Drawing.Size(248, 170)
        Me.tlpStreetSide.TabIndex = 1
        '
        'TABLE15
        '
        Me.TABLE15.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE15.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE15.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE15.Location = New System.Drawing.Point(110, 45)
        Me.TABLE15.Name = "TABLE15"
        Me.TABLE15.Size = New System.Drawing.Size(82, 79)
        Me.TABLE15.TabIndex = 5
        Me.TABLE15.UseVisualStyleBackColor = False
        '
        'tlpCentre
        '
        Me.tlpCentre.ColumnCount = 8
        Me.tlpGrid.SetColumnSpan(Me.tlpCentre, 3)
        Me.tlpCentre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpCentre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpCentre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpCentre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpCentre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpCentre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpCentre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpCentre.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpCentre.Controls.Add(Me.TABLE07, 7, 1)
        Me.tlpCentre.Controls.Add(Me.TABLE08, 6, 1)
        Me.tlpCentre.Controls.Add(Me.TABLE09, 5, 1)
        Me.tlpCentre.Controls.Add(Me.TABLE10, 4, 1)
        Me.tlpCentre.Controls.Add(Me.TABLE11, 2, 1)
        Me.tlpCentre.Controls.Add(Me.TABLE12, 1, 1)
        Me.tlpCentre.Controls.Add(Me.TABLE14, 0, 1)
        Me.tlpCentre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCentre.Location = New System.Drawing.Point(259, 358)
        Me.tlpCentre.Name = "tlpCentre"
        Me.tlpCentre.RowCount = 3
        Me.tlpCentre.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCentre.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCentre.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCentre.Size = New System.Drawing.Size(761, 170)
        Me.tlpCentre.TabIndex = 3
        '
        'TABLE07
        '
        Me.TABLE07.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE07.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE07.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE07.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE07.Location = New System.Drawing.Point(680, 45)
        Me.TABLE07.Margin = New System.Windows.Forms.Padding(24, 3, 3, 3)
        Me.TABLE07.Name = "TABLE07"
        Me.TABLE07.Size = New System.Drawing.Size(78, 79)
        Me.TABLE07.TabIndex = 7
        Me.TABLE07.UseVisualStyleBackColor = False
        '
        'TABLE08
        '
        Me.TABLE08.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE08.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE08.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE08.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE08.Location = New System.Drawing.Point(582, 45)
        Me.TABLE08.Margin = New System.Windows.Forms.Padding(24, 3, 3, 3)
        Me.TABLE08.Name = "TABLE08"
        Me.TABLE08.Size = New System.Drawing.Size(71, 79)
        Me.TABLE08.TabIndex = 5
        Me.TABLE08.UseVisualStyleBackColor = False
        '
        'TABLE09
        '
        Me.TABLE09.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE09.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE09.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE09.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE09.Location = New System.Drawing.Point(484, 45)
        Me.TABLE09.Margin = New System.Windows.Forms.Padding(24, 3, 3, 3)
        Me.TABLE09.Name = "TABLE09"
        Me.TABLE09.Size = New System.Drawing.Size(71, 79)
        Me.TABLE09.TabIndex = 5
        Me.TABLE09.UseVisualStyleBackColor = False
        '
        'TABLE10
        '
        Me.TABLE10.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE10.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE10.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE10.Location = New System.Drawing.Point(386, 45)
        Me.TABLE10.Margin = New System.Windows.Forms.Padding(24, 3, 3, 3)
        Me.TABLE10.Name = "TABLE10"
        Me.TABLE10.Size = New System.Drawing.Size(71, 79)
        Me.TABLE10.TabIndex = 6
        Me.TABLE10.UseVisualStyleBackColor = False
        '
        'TABLE11
        '
        Me.TABLE11.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE11.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE11.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE11.Location = New System.Drawing.Point(220, 45)
        Me.TABLE11.Margin = New System.Windows.Forms.Padding(24, 3, 3, 3)
        Me.TABLE11.Name = "TABLE11"
        Me.TABLE11.Size = New System.Drawing.Size(71, 79)
        Me.TABLE11.TabIndex = 7
        Me.TABLE11.UseVisualStyleBackColor = False
        '
        'TABLE12
        '
        Me.TABLE12.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE12.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE12.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE12.Location = New System.Drawing.Point(122, 45)
        Me.TABLE12.Margin = New System.Windows.Forms.Padding(24, 3, 3, 3)
        Me.TABLE12.Name = "TABLE12"
        Me.TABLE12.Size = New System.Drawing.Size(71, 79)
        Me.TABLE12.TabIndex = 5
        Me.TABLE12.UseVisualStyleBackColor = False
        '
        'TABLE14
        '
        Me.TABLE14.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE14.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE14.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE14.Location = New System.Drawing.Point(24, 45)
        Me.TABLE14.Margin = New System.Windows.Forms.Padding(24, 3, 3, 3)
        Me.TABLE14.Name = "TABLE14"
        Me.TABLE14.Size = New System.Drawing.Size(71, 79)
        Me.TABLE14.TabIndex = 7
        Me.TABLE14.UseVisualStyleBackColor = False
        '
        'tlpWallSide
        '
        Me.tlpWallSide.ColumnCount = 3
        Me.tlpWallSide.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpWallSide.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpWallSide.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpWallSide.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpWallSide.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpWallSide.Controls.Add(Me.TABLE23, 0, 0)
        Me.tlpWallSide.Controls.Add(Me.TABLE24, 1, 0)
        Me.tlpWallSide.Controls.Add(Me.TABLE25, 2, 0)
        Me.tlpWallSide.Controls.Add(Me.TABLE20, 0, 3)
        Me.tlpWallSide.Controls.Add(Me.TABLE21, 0, 2)
        Me.tlpWallSide.Controls.Add(Me.TABLE22, 0, 1)
        Me.tlpWallSide.Controls.Add(Me.lblBar, 1, 1)
        Me.tlpWallSide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpWallSide.Location = New System.Drawing.Point(4, 4)
        Me.tlpWallSide.Name = "tlpWallSide"
        Me.tlpWallSide.RowCount = 4
        Me.tlpGrid.SetRowSpan(Me.tlpWallSide, 3)
        Me.tlpWallSide.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpWallSide.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpWallSide.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpWallSide.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpWallSide.Size = New System.Drawing.Size(248, 524)
        Me.tlpWallSide.TabIndex = 4
        '
        'TABLE23
        '
        Me.TABLE23.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE23.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE23.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE23.Location = New System.Drawing.Point(9, 24)
        Me.TABLE23.Margin = New System.Windows.Forms.Padding(9, 24, 6, 32)
        Me.TABLE23.Name = "TABLE23"
        Me.TABLE23.Size = New System.Drawing.Size(67, 75)
        Me.TABLE23.TabIndex = 6
        Me.TABLE23.UseVisualStyleBackColor = False
        '
        'TABLE24
        '
        Me.TABLE24.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE24.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE24.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE24.Location = New System.Drawing.Point(91, 24)
        Me.TABLE24.Margin = New System.Windows.Forms.Padding(9, 24, 6, 32)
        Me.TABLE24.Name = "TABLE24"
        Me.TABLE24.Size = New System.Drawing.Size(67, 75)
        Me.TABLE24.TabIndex = 6
        Me.TABLE24.UseVisualStyleBackColor = False
        '
        'TABLE25
        '
        Me.TABLE25.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE25.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE25.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE25.Location = New System.Drawing.Point(173, 24)
        Me.TABLE25.Margin = New System.Windows.Forms.Padding(9, 24, 6, 32)
        Me.TABLE25.Name = "TABLE25"
        Me.TABLE25.Size = New System.Drawing.Size(69, 75)
        Me.TABLE25.TabIndex = 6
        Me.TABLE25.UseVisualStyleBackColor = False
        '
        'TABLE20
        '
        Me.TABLE20.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE20.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE20.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE20.Location = New System.Drawing.Point(9, 417)
        Me.TABLE20.Margin = New System.Windows.Forms.Padding(9, 24, 6, 32)
        Me.TABLE20.Name = "TABLE20"
        Me.TABLE20.Size = New System.Drawing.Size(67, 75)
        Me.TABLE20.TabIndex = 10
        Me.TABLE20.UseVisualStyleBackColor = False
        '
        'TABLE21
        '
        Me.TABLE21.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE21.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE21.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE21.Location = New System.Drawing.Point(9, 286)
        Me.TABLE21.Margin = New System.Windows.Forms.Padding(9, 24, 6, 32)
        Me.TABLE21.Name = "TABLE21"
        Me.TABLE21.Size = New System.Drawing.Size(67, 75)
        Me.TABLE21.TabIndex = 4
        Me.TABLE21.UseVisualStyleBackColor = False
        '
        'TABLE22
        '
        Me.TABLE22.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE22.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE22.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE22.Location = New System.Drawing.Point(9, 155)
        Me.TABLE22.Margin = New System.Windows.Forms.Padding(9, 24, 6, 32)
        Me.TABLE22.Name = "TABLE22"
        Me.TABLE22.Size = New System.Drawing.Size(67, 75)
        Me.TABLE22.TabIndex = 5
        Me.TABLE22.UseVisualStyleBackColor = False
        '
        'tlpStreetCorner
        '
        Me.tlpStreetCorner.ColumnCount = 7
        Me.tlpGrid.SetColumnSpan(Me.tlpStreetCorner, 2)
        Me.tlpStreetCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpStreetCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpStreetCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpStreetCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpStreetCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpStreetCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpStreetCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpStreetCorner.Controls.Add(Me.TABLE16, 6, 1)
        Me.tlpStreetCorner.Controls.Add(Me.lblGrill, 0, 0)
        Me.tlpStreetCorner.Controls.Add(Me.TABLE17, 5, 1)
        Me.tlpStreetCorner.Controls.Add(Me.TABLE18, 4, 1)
        Me.tlpStreetCorner.Controls.Add(Me.TABLE19, 3, 1)
        Me.tlpStreetCorner.Controls.Add(Me.TABLE26, 2, 1)
        Me.tlpStreetCorner.Controls.Add(Me.TABLE27, 1, 1)
        Me.tlpStreetCorner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpStreetCorner.Location = New System.Drawing.Point(514, 535)
        Me.tlpStreetCorner.Name = "tlpStreetCorner"
        Me.tlpStreetCorner.RowCount = 3
        Me.tlpStreetCorner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpStreetCorner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpStreetCorner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpStreetCorner.Size = New System.Drawing.Size(506, 170)
        Me.tlpStreetCorner.TabIndex = 2
        '
        'TABLE16
        '
        Me.TABLE16.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE16.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE16.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE16.Location = New System.Drawing.Point(437, 45)
        Me.TABLE16.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.TABLE16.Name = "TABLE16"
        Me.TABLE16.Size = New System.Drawing.Size(66, 79)
        Me.TABLE16.TabIndex = 6
        Me.TABLE16.UseVisualStyleBackColor = False
        '
        'TABLE17
        '
        Me.TABLE17.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE17.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE17.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE17.Location = New System.Drawing.Point(362, 45)
        Me.TABLE17.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.TABLE17.Name = "TABLE17"
        Me.TABLE17.Size = New System.Drawing.Size(60, 79)
        Me.TABLE17.TabIndex = 7
        Me.TABLE17.UseVisualStyleBackColor = False
        '
        'TABLE18
        '
        Me.TABLE18.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE18.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE18.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE18.Location = New System.Drawing.Point(287, 45)
        Me.TABLE18.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.TABLE18.Name = "TABLE18"
        Me.TABLE18.Size = New System.Drawing.Size(60, 79)
        Me.TABLE18.TabIndex = 8
        Me.TABLE18.UseVisualStyleBackColor = False
        '
        'TABLE19
        '
        Me.TABLE19.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE19.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE19.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE19.Location = New System.Drawing.Point(212, 45)
        Me.TABLE19.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.TABLE19.Name = "TABLE19"
        Me.TABLE19.Size = New System.Drawing.Size(60, 79)
        Me.TABLE19.TabIndex = 9
        Me.TABLE19.UseVisualStyleBackColor = False
        '
        'TABLE26
        '
        Me.TABLE26.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE26.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE26.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE26.Location = New System.Drawing.Point(137, 45)
        Me.TABLE26.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.TABLE26.Name = "TABLE26"
        Me.TABLE26.Size = New System.Drawing.Size(60, 79)
        Me.TABLE26.TabIndex = 9
        Me.TABLE26.UseVisualStyleBackColor = False
        '
        'TABLE27
        '
        Me.TABLE27.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE27.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE27.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE27.Location = New System.Drawing.Point(62, 45)
        Me.TABLE27.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.TABLE27.Name = "TABLE27"
        Me.TABLE27.Size = New System.Drawing.Size(60, 79)
        Me.TABLE27.TabIndex = 9
        Me.TABLE27.UseVisualStyleBackColor = False
        '
        'tlpCorner
        '
        Me.tlpCorner.ColumnCount = 8
        Me.tlpGrid.SetColumnSpan(Me.tlpCorner, 3)
        Me.tlpCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.Controls.Add(Me.TABLE01, 1, 2)
        Me.tlpCorner.Controls.Add(Me.TABLE06, 7, 1)
        Me.tlpCorner.Controls.Add(Me.TABLE04, 5, 1)
        Me.tlpCorner.Controls.Add(Me.TABLE02, 3, 1)
        Me.tlpCorner.Controls.Add(Me.TABLE05, 5, 3)
        Me.tlpCorner.Controls.Add(Me.TABLE03, 3, 3)
        Me.tlpCorner.Controls.Add(Me.lblRestaurant, 2, 2)
        Me.tlpCorner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCorner.Location = New System.Drawing.Point(259, 4)
        Me.tlpCorner.Name = "tlpCorner"
        Me.tlpCorner.RowCount = 5
        Me.tlpGrid.SetRowSpan(Me.tlpCorner, 2)
        Me.tlpCorner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCorner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCorner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCorner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlpCorner.Size = New System.Drawing.Size(761, 347)
        Me.tlpCorner.TabIndex = 0
        '
        'TABLE01
        '
        Me.TABLE01.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE01.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE01.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE01.Location = New System.Drawing.Point(98, 132)
        Me.TABLE01.Name = "TABLE01"
        Me.TABLE01.Size = New System.Drawing.Size(89, 80)
        Me.TABLE01.TabIndex = 3
        Me.TABLE01.UseVisualStyleBackColor = False
        '
        'TABLE06
        '
        Me.TABLE06.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE06.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE06.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE06.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE06.Location = New System.Drawing.Point(668, 46)
        Me.TABLE06.Name = "TABLE06"
        Me.TABLE06.Size = New System.Drawing.Size(90, 80)
        Me.TABLE06.TabIndex = 6
        Me.TABLE06.UseVisualStyleBackColor = False
        '
        'TABLE04
        '
        Me.TABLE04.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE04.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE04.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE04.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE04.Location = New System.Drawing.Point(478, 46)
        Me.TABLE04.Name = "TABLE04"
        Me.TABLE04.Size = New System.Drawing.Size(89, 80)
        Me.TABLE04.TabIndex = 4
        Me.TABLE04.UseVisualStyleBackColor = False
        '
        'TABLE02
        '
        Me.TABLE02.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE02.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE02.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE02.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE02.Location = New System.Drawing.Point(288, 46)
        Me.TABLE02.Name = "TABLE02"
        Me.TABLE02.Size = New System.Drawing.Size(89, 80)
        Me.TABLE02.TabIndex = 4
        Me.TABLE02.UseVisualStyleBackColor = False
        '
        'TABLE05
        '
        Me.TABLE05.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE05.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE05.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE05.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE05.Location = New System.Drawing.Point(478, 218)
        Me.TABLE05.Name = "TABLE05"
        Me.TABLE05.Size = New System.Drawing.Size(89, 80)
        Me.TABLE05.TabIndex = 5
        Me.TABLE05.UseVisualStyleBackColor = False
        '
        'TABLE03
        '
        Me.TABLE03.BackColor = System.Drawing.Color.LightGreen
        Me.TABLE03.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TABLE03.Font = New System.Drawing.Font("Segoe UI Black", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABLE03.ForeColor = System.Drawing.Color.DimGray
        Me.TABLE03.Location = New System.Drawing.Point(288, 218)
        Me.TABLE03.Name = "TABLE03"
        Me.TABLE03.Size = New System.Drawing.Size(89, 80)
        Me.TABLE03.TabIndex = 4
        Me.TABLE03.UseVisualStyleBackColor = False
        '
        'lblRestaurant
        '
        Me.tlpCorner.SetColumnSpan(Me.lblRestaurant, 5)
        Me.lblRestaurant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRestaurant.Font = New System.Drawing.Font("Calibri", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRestaurant.ForeColor = System.Drawing.Color.LightGray
        Me.lblRestaurant.Location = New System.Drawing.Point(193, 129)
        Me.lblRestaurant.Name = "lblRestaurant"
        Me.lblRestaurant.Size = New System.Drawing.Size(469, 86)
        Me.lblRestaurant.TabIndex = 7
        Me.lblRestaurant.Text = "RESTAURANT"
        Me.lblRestaurant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBar
        '
        Me.tlpWallSide.SetColumnSpan(Me.lblBar, 2)
        Me.lblBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBar.Font = New System.Drawing.Font("Calibri", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBar.ForeColor = System.Drawing.Color.LightGray
        Me.lblBar.Location = New System.Drawing.Point(85, 131)
        Me.lblBar.Name = "lblBar"
        Me.tlpWallSide.SetRowSpan(Me.lblBar, 2)
        Me.lblBar.Size = New System.Drawing.Size(160, 262)
        Me.lblBar.TabIndex = 7
        Me.lblBar.Text = "BAR"
        Me.lblBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGrill
        '
        Me.tlpStreetCorner.SetColumnSpan(Me.lblGrill, 7)
        Me.lblGrill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGrill.Font = New System.Drawing.Font("Calibri", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrill.ForeColor = System.Drawing.Color.LightGray
        Me.lblGrill.Location = New System.Drawing.Point(3, 0)
        Me.lblGrill.Name = "lblGrill"
        Me.lblGrill.Size = New System.Drawing.Size(500, 42)
        Me.lblGrill.TabIndex = 7
        Me.lblGrill.Text = "G R I L L"
        Me.lblGrill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmOrderTablesSagaOne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.tlpGrid)
        Me.Controls.Add(Me.panelBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOrderTablesSagaOne"
        Me.Text = "frmOrderTables"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelBottom.ResumeLayout(False)
        Me.tlpGrid.ResumeLayout(False)
        Me.tlpStreetSide.ResumeLayout(False)
        Me.tlpCentre.ResumeLayout(False)
        Me.tlpWallSide.ResumeLayout(False)
        Me.tlpStreetCorner.ResumeLayout(False)
        Me.tlpCorner.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelBottom As System.Windows.Forms.Panel
    Friend WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents tlpGrid As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSwitchViews As Infragistics.Win.Misc.UltraButton
    Friend WithEvents tlpCorner As TableLayoutPanel
    Friend WithEvents TABLE21 As Button
    Friend WithEvents TABLE04 As Button
    Friend WithEvents TABLE03 As Button
    Friend WithEvents TABLE02 As Button
    Friend WithEvents TABLE01 As Button
    Friend WithEvents TABLE05 As Button
    Friend WithEvents TABLE06 As Button
    Friend WithEvents TABLE07 As Button
    Friend WithEvents tlpStreetSide As TableLayoutPanel
    Friend WithEvents TABLE11 As Button
    Friend WithEvents TABLE09 As Button
    Friend WithEvents TABLE10 As Button
    Friend WithEvents tlpStreetCorner As TableLayoutPanel
    Friend WithEvents TABLE08 As Button
    Friend WithEvents tlpCentre As TableLayoutPanel
    Friend WithEvents TABLE25 As Button
    Friend WithEvents TABLE12 As Button
    Friend WithEvents TABLE14 As Button
    Friend WithEvents TABLE22 As Button
    Friend WithEvents tlpWallSide As TableLayoutPanel
    Friend WithEvents TABLE18 As Button
    Friend WithEvents TABLE15 As Button
    Friend WithEvents TABLE16 As Button
    Friend WithEvents TABLE17 As Button
    Friend WithEvents TABLE19 As Button
    Friend WithEvents TABLE20 As Button
    Friend WithEvents TABLE23 As Button
    Friend WithEvents TABLE24 As Button
    Friend WithEvents TABLE26 As Button
    Friend WithEvents TABLE27 As Button
    Friend WithEvents lblRestaurant As Label
    Friend WithEvents lblBar As Label
    Friend WithEvents lblGrill As Label
End Class
