<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fmain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fmain))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel_Header = New System.Windows.Forms.Panel()
        Me.btn_BookinsReport = New System.Windows.Forms.Button()
        Me.panel_OrderCtrls = New System.Windows.Forms.Panel()
        Me.btn_Line = New System.Windows.Forms.Button()
        Me.panel_SpaceOnOrderCtrls = New System.Windows.Forms.Panel()
        Me.txt_Guests = New System.Windows.Forms.TextBox()
        Me.btn_EditUser = New System.Windows.Forms.Button()
        Me.lbl_Guests = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PicLogo = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.lbl_Time = New System.Windows.Forms.Label()
        Me.lbl_Gasacemi = New System.Windows.Forms.Label()
        Me.txt_Gad_Tan = New System.Windows.Forms.TextBox()
        Me.lbl_Xurda = New System.Windows.Forms.Label()
        Me.lbl_Gad_Tan = New System.Windows.Forms.Label()
        Me.lbl_Check_N = New System.Windows.Forms.Label()
        Me.lbl_Nom = New System.Windows.Forms.Label()
        Me.lbl_SaleType = New System.Windows.Forms.Label()
        Me.lbl_Saxeli = New System.Windows.Forms.Label()
        Me.lbl_Magh = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_Tar = New System.Windows.Forms.Label()
        Me.Panel_Body = New System.Windows.Forms.Panel()
        Me.txt_kodi = New Shop.MTGCComboBox()
        Me.DGV_Sales = New System.Windows.Forms.DataGridView()
        Me.ColKodi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJgufi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDasaxeleba = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFasi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRaodenoba = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJami = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip_Footer = New System.Windows.Forms.StatusStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnPrintOrder = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnPrintBill = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnNew = New System.Windows.Forms.ToolStripDropDownButton()
        Me.lbl_Gadasaxdeli = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_Tanxa = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerDate = New System.Windows.Forms.Timer(Me.components)
        Me.MyImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel_Header.SuspendLayout()
        Me.panel_OrderCtrls.SuspendLayout()
        Me.Panel_Body.SuspendLayout()
        CType(Me.DGV_Sales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip_Footer.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_Header
        '
        Me.Panel_Header.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Header.Controls.Add(Me.btn_BookinsReport)
        Me.Panel_Header.Controls.Add(Me.panel_OrderCtrls)
        Me.Panel_Header.Controls.Add(Me.btn_EditUser)
        Me.Panel_Header.Controls.Add(Me.lbl_Guests)
        Me.Panel_Header.Controls.Add(Me.Label4)
        Me.Panel_Header.Controls.Add(Me.PicLogo)
        Me.Panel_Header.Controls.Add(Me.lbl_Status)
        Me.Panel_Header.Controls.Add(Me.lbl_Time)
        Me.Panel_Header.Controls.Add(Me.lbl_Gasacemi)
        Me.Panel_Header.Controls.Add(Me.txt_Gad_Tan)
        Me.Panel_Header.Controls.Add(Me.lbl_Xurda)
        Me.Panel_Header.Controls.Add(Me.lbl_Gad_Tan)
        Me.Panel_Header.Controls.Add(Me.lbl_Check_N)
        Me.Panel_Header.Controls.Add(Me.lbl_Nom)
        Me.Panel_Header.Controls.Add(Me.lbl_SaleType)
        Me.Panel_Header.Controls.Add(Me.lbl_Saxeli)
        Me.Panel_Header.Controls.Add(Me.lbl_Magh)
        Me.Panel_Header.Controls.Add(Me.Label3)
        Me.Panel_Header.Controls.Add(Me.Label2)
        Me.Panel_Header.Controls.Add(Me.Label1)
        Me.Panel_Header.Controls.Add(Me.lbl_Tar)
        Me.Panel_Header.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Header.Name = "Panel_Header"
        Me.Panel_Header.Size = New System.Drawing.Size(800, 140)
        Me.Panel_Header.TabIndex = 0
        '
        'btn_BookinsReport
        '
        Me.btn_BookinsReport.BackColor = System.Drawing.Color.GhostWhite
        Me.btn_BookinsReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btn_BookinsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_BookinsReport.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BookinsReport.Image = Global.Shop.My.Resources.Resources.calendar_date_schedule_event_time_24
        Me.btn_BookinsReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_BookinsReport.Location = New System.Drawing.Point(656, 107)
        Me.btn_BookinsReport.Name = "btn_BookinsReport"
        Me.btn_BookinsReport.Size = New System.Drawing.Size(102, 30)
        Me.btn_BookinsReport.TabIndex = 22
        Me.btn_BookinsReport.Text = "ჯავშნები"
        Me.btn_BookinsReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_BookinsReport.UseVisualStyleBackColor = False
        Me.btn_BookinsReport.Visible = False
        '
        'panel_OrderCtrls
        '
        Me.panel_OrderCtrls.Controls.Add(Me.btn_Line)
        Me.panel_OrderCtrls.Controls.Add(Me.panel_SpaceOnOrderCtrls)
        Me.panel_OrderCtrls.Controls.Add(Me.txt_Guests)
        Me.panel_OrderCtrls.Location = New System.Drawing.Point(656, 107)
        Me.panel_OrderCtrls.Name = "panel_OrderCtrls"
        Me.panel_OrderCtrls.Size = New System.Drawing.Size(98, 30)
        Me.panel_OrderCtrls.TabIndex = 21
        Me.panel_OrderCtrls.Visible = False
        '
        'btn_Line
        '
        Me.btn_Line.BackColor = System.Drawing.Color.GhostWhite
        Me.btn_Line.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_Line.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btn_Line.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Line.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Line.Location = New System.Drawing.Point(40, 0)
        Me.btn_Line.Name = "btn_Line"
        Me.btn_Line.Size = New System.Drawing.Size(58, 30)
        Me.btn_Line.TabIndex = 19
        Me.btn_Line.Text = "—↕—"
        Me.btn_Line.UseVisualStyleBackColor = False
        '
        'panel_SpaceOnOrderCtrls
        '
        Me.panel_SpaceOnOrderCtrls.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel_SpaceOnOrderCtrls.Location = New System.Drawing.Point(37, 0)
        Me.panel_SpaceOnOrderCtrls.Name = "panel_SpaceOnOrderCtrls"
        Me.panel_SpaceOnOrderCtrls.Size = New System.Drawing.Size(3, 30)
        Me.panel_SpaceOnOrderCtrls.TabIndex = 20
        '
        'txt_Guests
        '
        Me.txt_Guests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Guests.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt_Guests.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_Guests.Location = New System.Drawing.Point(0, 0)
        Me.txt_Guests.Multiline = True
        Me.txt_Guests.Name = "txt_Guests"
        Me.txt_Guests.Size = New System.Drawing.Size(37, 30)
        Me.txt_Guests.TabIndex = 17
        Me.txt_Guests.TabStop = False
        '
        'btn_EditUser
        '
        Me.btn_EditUser.BackColor = System.Drawing.Color.GhostWhite
        Me.btn_EditUser.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btn_EditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EditUser.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EditUser.Image = CType(resources.GetObject("btn_EditUser.Image"), System.Drawing.Image)
        Me.btn_EditUser.Location = New System.Drawing.Point(347, 69)
        Me.btn_EditUser.Name = "btn_EditUser"
        Me.btn_EditUser.Size = New System.Drawing.Size(30, 28)
        Me.btn_EditUser.TabIndex = 20
        Me.btn_EditUser.UseVisualStyleBackColor = False
        Me.btn_EditUser.Visible = False
        '
        'lbl_Guests
        '
        Me.lbl_Guests.AutoSize = True
        Me.lbl_Guests.Font = New System.Drawing.Font("Sylfaen", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Guests.Location = New System.Drawing.Point(566, 112)
        Me.lbl_Guests.Name = "lbl_Guests"
        Me.lbl_Guests.Size = New System.Drawing.Size(84, 18)
        Me.lbl_Guests.TabIndex = 18
        Me.lbl_Guests.Text = "სტუმრები:"
        Me.lbl_Guests.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(281, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 19)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "გაყიდვა"
        '
        'PicLogo
        '
        Appearance1.BorderColor = System.Drawing.Color.DarkGray
        Me.PicLogo.Appearance = Appearance1
        Me.PicLogo.BorderShadowColor = System.Drawing.Color.Empty
        Me.PicLogo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.PicLogo.Location = New System.Drawing.Point(0, 0)
        Me.PicLogo.MaintainAspectRatio = False
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(162, 140)
        Me.PicLogo.TabIndex = 15
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.Red
        Me.lbl_Status.Location = New System.Drawing.Point(763, 114)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(19, 17)
        Me.lbl_Status.TabIndex = 1
        Me.lbl_Status.Text = "▼"
        '
        'lbl_Time
        '
        Me.lbl_Time.AutoSize = True
        Me.lbl_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Time.Location = New System.Drawing.Point(280, 4)
        Me.lbl_Time.Name = "lbl_Time"
        Me.lbl_Time.Size = New System.Drawing.Size(63, 25)
        Me.lbl_Time.TabIndex = 14
        Me.lbl_Time.Text = "Time"
        '
        'lbl_Gasacemi
        '
        Me.lbl_Gasacemi.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_Gasacemi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_Gasacemi.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Gasacemi.ForeColor = System.Drawing.Color.Red
        Me.lbl_Gasacemi.Location = New System.Drawing.Point(656, 70)
        Me.lbl_Gasacemi.Name = "lbl_Gasacemi"
        Me.lbl_Gasacemi.Size = New System.Drawing.Size(124, 35)
        Me.lbl_Gasacemi.TabIndex = 4
        Me.lbl_Gasacemi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Gasacemi.Visible = False
        '
        'txt_Gad_Tan
        '
        Me.txt_Gad_Tan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Gad_Tan.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_Gad_Tan.Location = New System.Drawing.Point(656, 32)
        Me.txt_Gad_Tan.Name = "txt_Gad_Tan"
        Me.txt_Gad_Tan.Size = New System.Drawing.Size(124, 35)
        Me.txt_Gad_Tan.TabIndex = 1
        Me.txt_Gad_Tan.TabStop = False
        Me.txt_Gad_Tan.Visible = False
        '
        'lbl_Xurda
        '
        Me.lbl_Xurda.AutoSize = True
        Me.lbl_Xurda.Font = New System.Drawing.Font("Sylfaen", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Xurda.Location = New System.Drawing.Point(590, 75)
        Me.lbl_Xurda.Name = "lbl_Xurda"
        Me.lbl_Xurda.Size = New System.Drawing.Size(60, 18)
        Me.lbl_Xurda.TabIndex = 11
        Me.lbl_Xurda.Text = "ხურდა:"
        '
        'lbl_Gad_Tan
        '
        Me.lbl_Gad_Tan.AutoSize = True
        Me.lbl_Gad_Tan.Font = New System.Drawing.Font("Sylfaen", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Gad_Tan.Location = New System.Drawing.Point(509, 43)
        Me.lbl_Gad_Tan.Name = "lbl_Gad_Tan"
        Me.lbl_Gad_Tan.Size = New System.Drawing.Size(141, 18)
        Me.lbl_Gad_Tan.TabIndex = 10
        Me.lbl_Gad_Tan.Text = "გადახდილი თანხა:"
        '
        'lbl_Check_N
        '
        Me.lbl_Check_N.AutoSize = True
        Me.lbl_Check_N.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Check_N.Location = New System.Drawing.Point(656, 8)
        Me.lbl_Check_N.Name = "lbl_Check_N"
        Me.lbl_Check_N.Size = New System.Drawing.Size(21, 20)
        Me.lbl_Check_N.TabIndex = 9
        Me.lbl_Check_N.Text = "N"
        '
        'lbl_Nom
        '
        Me.lbl_Nom.AutoSize = True
        Me.lbl_Nom.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Nom.Location = New System.Drawing.Point(577, 9)
        Me.lbl_Nom.Name = "lbl_Nom"
        Me.lbl_Nom.Size = New System.Drawing.Size(73, 19)
        Me.lbl_Nom.TabIndex = 8
        Me.lbl_Nom.Text = "ნომერი:"
        '
        'lbl_SaleType
        '
        Me.lbl_SaleType.AutoSize = True
        Me.lbl_SaleType.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_SaleType.ForeColor = System.Drawing.Color.Green
        Me.lbl_SaleType.Location = New System.Drawing.Point(508, 9)
        Me.lbl_SaleType.Name = "lbl_SaleType"
        Me.lbl_SaleType.Size = New System.Drawing.Size(71, 19)
        Me.lbl_SaleType.TabIndex = 7
        Me.lbl_SaleType.Text = "გაყიდვა"
        Me.lbl_SaleType.Visible = False
        '
        'lbl_Saxeli
        '
        Me.lbl_Saxeli.AutoSize = True
        Me.lbl_Saxeli.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Saxeli.Location = New System.Drawing.Point(281, 74)
        Me.lbl_Saxeli.Name = "lbl_Saxeli"
        Me.lbl_Saxeli.Size = New System.Drawing.Size(66, 19)
        Me.lbl_Saxeli.TabIndex = 6
        Me.lbl_Saxeli.Text = "სახელი"
        '
        'lbl_Magh
        '
        Me.lbl_Magh.AutoSize = True
        Me.lbl_Magh.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Magh.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Magh.Location = New System.Drawing.Point(281, 42)
        Me.lbl_Magh.Name = "lbl_Magh"
        Me.lbl_Magh.Size = New System.Drawing.Size(72, 19)
        Me.lbl_Magh.TabIndex = 5
        Me.lbl_Magh.Text = "მაღაზია"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(180, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ოპერაცია:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(180, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "მოლარე:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(180, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "მაღაზია:"
        '
        'lbl_Tar
        '
        Me.lbl_Tar.AutoSize = True
        Me.lbl_Tar.Font = New System.Drawing.Font("Sylfaen", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Tar.Location = New System.Drawing.Point(180, 9)
        Me.lbl_Tar.Name = "lbl_Tar"
        Me.lbl_Tar.Size = New System.Drawing.Size(77, 19)
        Me.lbl_Tar.TabIndex = 1
        Me.lbl_Tar.Text = "თარიღი:"
        '
        'Panel_Body
        '
        Me.Panel_Body.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Body.AutoScroll = True
        Me.Panel_Body.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Body.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel_Body.Controls.Add(Me.txt_kodi)
        Me.Panel_Body.Controls.Add(Me.DGV_Sales)
        Me.Panel_Body.Location = New System.Drawing.Point(0, 141)
        Me.Panel_Body.Name = "Panel_Body"
        Me.Panel_Body.Size = New System.Drawing.Size(800, 383)
        Me.Panel_Body.TabIndex = 0
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
        Me.txt_kodi.DropDownHeight = 71
        Me.txt_kodi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_kodi.DropDownWidth = 1
        Me.txt_kodi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_kodi.GridLineColor = System.Drawing.Color.LightGray
        Me.txt_kodi.GridLineHorizontal = False
        Me.txt_kodi.GridLineVertical = True
        Me.txt_kodi.HighlightBorderColor = System.Drawing.Color.Blue
        Me.txt_kodi.IntegralHeight = False
        Me.txt_kodi.ItemHeight = 31
        Me.txt_kodi.Location = New System.Drawing.Point(2, 28)
        Me.txt_kodi.Name = "txt_kodi"
        Me.txt_kodi.NormalBorderColor = System.Drawing.Color.Black
        Me.txt_kodi.Size = New System.Drawing.Size(160, 36)
        Me.txt_kodi.TabIndex = 0
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
        Me.DGV_Sales.Location = New System.Drawing.Point(2, 0)
        Me.DGV_Sales.MultiSelect = False
        Me.DGV_Sales.Name = "DGV_Sales"
        Me.DGV_Sales.RowHeadersVisible = False
        Me.DGV_Sales.RowTemplate.Height = 35
        Me.DGV_Sales.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DGV_Sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGV_Sales.Size = New System.Drawing.Size(769, 30)
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
        '
        'ColRaodenoba
        '
        Me.ColRaodenoba.HeaderText = "რაოდ"
        Me.ColRaodenoba.Name = "ColRaodenoba"
        Me.ColRaodenoba.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColJami
        '
        Me.ColJami.HeaderText = "ჯამი"
        Me.ColJami.Name = "ColJami"
        Me.ColJami.ReadOnly = True
        Me.ColJami.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'StatusStrip_Footer
        '
        Me.StatusStrip_Footer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.btnPrintOrder, Me.btnPrintBill, Me.btnNew, Me.lbl_Gadasaxdeli, Me.lbl_Tanxa})
        Me.StatusStrip_Footer.Location = New System.Drawing.Point(0, 525)
        Me.StatusStrip_Footer.Name = "StatusStrip_Footer"
        Me.StatusStrip_Footer.Size = New System.Drawing.Size(800, 48)
        Me.StatusStrip_Footer.TabIndex = 1
        Me.StatusStrip_Footer.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.AutoSize = False
        Me.ToolStripDropDownButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("Sylfaen", 16.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripDropDownButton1.ForeColor = System.Drawing.Color.DimGray
        Me.ToolStripDropDownButton1.Image = Global.Shop.My.Resources.Resources.database1
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripDropDownButton1.ShowDropDownArrow = False
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(112, 46)
        Me.ToolStripDropDownButton1.Text = "მენიუ"
        '
        'btnPrintOrder
        '
        Me.btnPrintOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnPrintOrder.Font = New System.Drawing.Font("Sylfaen", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintOrder.ForeColor = System.Drawing.Color.DimGray
        Me.btnPrintOrder.Image = Global.Shop.My.Resources.Resources.printer3
        Me.btnPrintOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPrintOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrintOrder.Name = "btnPrintOrder"
        Me.btnPrintOrder.ShowDropDownArrow = False
        Me.btnPrintOrder.Size = New System.Drawing.Size(146, 46)
        Me.btnPrintOrder.Text = "შეკვეთის ბეჭდვა"
        Me.btnPrintOrder.Visible = False
        '
        'btnPrintBill
        '
        Me.btnPrintBill.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnPrintBill.Font = New System.Drawing.Font("Sylfaen", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintBill.ForeColor = System.Drawing.Color.DimGray
        Me.btnPrintBill.Image = Global.Shop.My.Resources.Resources.calculator_accept
        Me.btnPrintBill.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPrintBill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrintBill.Name = "btnPrintBill"
        Me.btnPrintBill.ShowDropDownArrow = False
        Me.btnPrintBill.Size = New System.Drawing.Size(95, 46)
        Me.btnPrintBill.Text = "ანგარიში"
        Me.btnPrintBill.Visible = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnNew.Font = New System.Drawing.Font("Sylfaen", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnNew.ForeColor = System.Drawing.Color.DimGray
        Me.btnNew.Image = Global.Shop.My.Resources.Resources.page
        Me.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.ShowDropDownArrow = False
        Me.btnNew.Size = New System.Drawing.Size(75, 46)
        Me.btnNew.Text = "ახალი"
        Me.btnNew.Visible = False
        '
        'lbl_Gadasaxdeli
        '
        Me.lbl_Gadasaxdeli.AutoSize = False
        Me.lbl_Gadasaxdeli.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbl_Gadasaxdeli.Font = New System.Drawing.Font("Sylfaen", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Gadasaxdeli.Name = "lbl_Gadasaxdeli"
        Me.lbl_Gadasaxdeli.Size = New System.Drawing.Size(632, 43)
        Me.lbl_Gadasaxdeli.Spring = True
        Me.lbl_Gadasaxdeli.Text = "გადასახდელი თანხა"
        Me.lbl_Gadasaxdeli.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Tanxa
        '
        Me.lbl_Tanxa.AutoSize = False
        Me.lbl_Tanxa.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbl_Tanxa.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Tanxa.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Tanxa.Name = "lbl_Tanxa"
        Me.lbl_Tanxa.Size = New System.Drawing.Size(41, 43)
        Me.lbl_Tanxa.Text = "0"
        Me.lbl_Tanxa.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TimerDate
        '
        '
        'MyImageList
        '
        Me.MyImageList.ImageStream = CType(resources.GetObject("MyImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.MyImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.MyImageList.Images.SetKeyName(0, "Entree logo ENG_b.bmp")
        Me.MyImageList.Images.SetKeyName(1, "KUTEBI-PRINT_printer7.bmp")
        '
        'Fmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(800, 573)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStrip_Footer)
        Me.Controls.Add(Me.Panel_Body)
        Me.Controls.Add(Me.Panel_Header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Fmain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "zr"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel_Header.ResumeLayout(False)
        Me.Panel_Header.PerformLayout()
        Me.panel_OrderCtrls.ResumeLayout(False)
        Me.panel_OrderCtrls.PerformLayout()
        Me.Panel_Body.ResumeLayout(False)
        CType(Me.DGV_Sales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip_Footer.ResumeLayout(False)
        Me.StatusStrip_Footer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel_Header As System.Windows.Forms.Panel
    Friend WithEvents Panel_Body As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip_Footer As System.Windows.Forms.StatusStrip
    Friend WithEvents lbl_Gadasaxdeli As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl_Tanxa As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGV_Sales As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Saxeli As System.Windows.Forms.Label
    Friend WithEvents lbl_Magh As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Tar As System.Windows.Forms.Label
    Friend WithEvents lbl_SaleType As System.Windows.Forms.Label
    Friend WithEvents lbl_Check_N As System.Windows.Forms.Label
    Friend WithEvents lbl_Nom As System.Windows.Forms.Label
    Friend WithEvents lbl_Gasacemi As System.Windows.Forms.Label
    Friend WithEvents txt_Gad_Tan As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Xurda As System.Windows.Forms.Label
    Friend WithEvents lbl_Gad_Tan As System.Windows.Forms.Label
    Friend WithEvents lbl_Time As System.Windows.Forms.Label
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents txt_kodi As Shop.MTGCComboBox
    Friend WithEvents TimerDate As System.Windows.Forms.Timer
    Friend WithEvents MyImageList As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ColKodi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJgufi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDasaxeleba As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFasi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRaodenoba As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJami As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PicLogo As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPrintOrder As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnPrintBill As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btn_Line As Button
    Friend WithEvents lbl_Guests As Label
    Friend WithEvents txt_Guests As TextBox
    Friend WithEvents btn_EditUser As Button
    Friend WithEvents panel_OrderCtrls As Panel
    Friend WithEvents panel_SpaceOnOrderCtrls As Panel
    Friend WithEvents btn_BookinsReport As Button
End Class
