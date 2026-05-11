'Imports AirConnFiscaler.OpModels.Generic
'Imports AirConnFiscaler.OpModels.ResponseDatas
'Imports AirConnFiscaler
'Imports AirConnFiscaler.OpModels.RequestParams

Public Class Fmain

    'Public LOCAL_CONN_STR As String = "Data Source=(local)\SQLEXPRESS;Initial Catalog=pos_db;Integrated Security=SSPI;Connect Timeout=2"
    Public LOCAL_CONN_STR As String = "Data Source=(local);Initial Catalog=pos_db;Integrated Security=SSPI;Connect Timeout=2"

    'Public SERVER_CONN_STR As String = "Data Source=92.241.70.102,5594;Initial Catalog=SalesBuffer;User ID=appuser;PWD=tesla555;Connect Timeout=5"
    Public SERVER_CONN_STR As String = "Data Source=10.10.5.13;Initial Catalog=SalesBuffer;User ID=appuser;PWD=tesla555;Connect Timeout=5"
    'Public SERVER_CONN_STR As String = "Data Source=92.241.70.102,1434;Initial Catalog=MistoSalesBuffer;User ID=sa;PWD=User!Client;Connect Timeout=5"
    'Public SERVER_CONN_STR As String = "Data Source=10.10.10.60;Initial Catalog=SalesBuffer;User ID=appuser;PWD=tesla555;Connect Timeout=5"
    'Public SERVER_CONN_STR As String = "Data Source=lst_db0201.veyseloglu.az,1450;Initial Catalog=SalesBuffer;User ID=appuser;PWD=tesla555;Connect Timeout=5"
    'Public SERVER_CONN_STR As String = "Data Source=188.129.207.253,8442;Initial Catalog=SalesBuffer;User ID=gspm_pos;PWD=userclient;Connect Timeout=5"
    'Public SERVER_CONN_STR As String = "Data Source=net.gurme.ge,8442;Initial Catalog=SalesBuffer;User ID=gspm_pos;PWD=userclient;Connect Timeout=5"


    Structure Person
        Dim ID As String
        Dim ID2 As String
        Dim Pass As String
        Dim Pass2 As String
        Dim Name As String
        Dim Name2 As String
        Dim Role As Short
        Dim Role2 As Short
    End Structure

    Public p_Person As New Person

    Declare Function SetSystemTime Lib "kernel32.dll" (ByRef lpSystemTime As SYSTEMTIME) As UInt32

    Structure SYSTEMTIME
        Public wYear As UInt16
        Public wMonth As UInt16
        Public wDayOfWeek As UInt16
        Public wDay As UInt16
        Public wHour As UInt16
        Public wMinute As UInt16
        Public wSecond As UInt16
        Public wMilliseconds As UInt16
    End Structure

    Dim DS1 As New DataSet
    Public daisy_FP As daisyFP.daisyFP

    Public Market_N As Integer
    Public Pos_N As Integer
    Public Market_Name, Market_Address As String

    Public b_Servertan_Aris_Kavshiri As Boolean = True
    Public b_BoxIsOpen As Boolean
    Public b_Fasdakleba_Moxda As Short
    Public dt_Servertan_Kavshirisatvis As New Date
    Public dt_Last_Z_Time As Date
    'Public vat_add As Decimal = 1.18
    'Public vat_sub As Decimal = 0.847457627118644
    Dim dt_Last_Update As Date

    Dim screen_X As Integer
    Dim screen_Y As Integer
    Public d_Tanxa As Double
    'Dim s_Tanxa As String
    Dim a_WonisStatusebi As New ArrayList
    Dim a_NulebisStatusebi As New ArrayList
    Public a_Fasdaklebebi As New ArrayList
    Dim d_Shecvlamde As Double
    Dim a_TaxGroups As New ArrayList

    Public Check_Number As Integer
    Public Fiscal_N As Short
    Public Scanner_N As Short
    Public Drawer_N As Short
    Public Drawer_Name As String
    Public Printer_N As Short
    Public Fiscal_Port As String
    Public BankTerminalId As String
    Public BankTerminalPort As String
    Public BankTerminalData As String = String.Empty
    Public Company_Name As String
    Public Company_Line As String
    Public Shared UI_Language As String
    Public Shared UITerms As Dictionary(Of String, String)
    Public Shared CheckTerms As New Dictionary(Of String, String)
    ReadOnly printerSettings As New Printing.PrinterSettings()

    'Public isTouch As Boolean
    Public fp_daisy As Short
    Public b_Daibechda(2) As Boolean
    Public b_From_Scanner As Boolean
    Dim SecondaryMonitorIndex As Integer = 1
    Public PrebillAllowed As Boolean = False
    Public OrdersAllowed As Boolean = False
    Public ResOSId As String

    Public Fiscal_Tcp As String
    Public Fiscal_RegNumber As String
    Public Fiscal_Pin As String
    Public Fiscal_Token As String
    Public Fiscal_Currency As String

    Public operator_num As Byte = 1
    Public operator_pwd As String = "000001"

    Public WithEvents PD As New Printing.PrintDocument()

    Friend WithEvents drawer_timer As System.Windows.Forms.Timer

    Public DaisyFP As DaisyFPCtrl.DaisyFP
    'Public ACFiscalbox As AirConnFiscaler.Fiscalbox
    'Public ACLogin As AirConnFiscaler.OpModels.Generic.BaseResponse(Of AirConnFiscaler.OpModels.ResponseDatas.ToLoginData)

    Public VATPercent As Decimal = 18.0
    Private ReturnFiscalDocId As String = String.Empty
    Public OrderedTable As OrderTable = Nothing

    Dim i_Wuti As Short

    Private Sub Fmain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Cursor.Hide()
        TranslateUI(Me, UITerms)

        TimerDate.Start()

        drawer_timer = New System.Windows.Forms.Timer(Me.components)

        Share_Settings()
        RunStartupScripts()
        If Market_N = 72 Then
            Run72StartupScripts()
        End If
        If b_Servertan_Aris_Kavshiri Then
            Get_Server_Date()
        End If

        If IO.File.Exists("panel_logo.jpg") Then
            PicLogo.Image = Image.FromFile("panel_logo.jpg")
        End If

        If IO.File.Exists("panel_body.jpg") Then
            Panel_Body.BackgroundImage = Image.FromFile("panel_body.jpg")
            Panel_Body.BackColor = New Bitmap(Panel_Body.BackgroundImage).GetPixel(100, 100)
            DGV_Sales.RowsDefaultCellStyle.BackColor = Panel_Body.BackColor
            txt_kodi.Height = 36
        End If

        price_List_Load()
        area_Control()

        Dim column As New DataGridViewColumn()
        column.Name = "ID"
        column.HeaderText = "ID"
        column.Visible = True
        column.CellTemplate = DGV_Sales.Columns(4).CellTemplate.Clone()
        column.Visible = False
        DGV_Sales.Columns.Add(column)

        Dim colOrderPrinted As New DataGridViewColumn()
        colOrderPrinted.Name = "OrderPrinted"
        colOrderPrinted.HeaderText = "OrderPrinted"
        colOrderPrinted.Visible = True
        colOrderPrinted.CellTemplate = DGV_Sales.Columns(4).CellTemplate.Clone()
        colOrderPrinted.ValueType = System.Type.GetType("System.Boolean")
        colOrderPrinted.Visible = False
        btn_BookinsReport.Visible = OrdersAllowed
        DGV_Sales.Columns.Add(colOrderPrinted)

        If Fiscal_N = 1 Then
            F_FP_SC_DR.Open_Fiscal()
        ElseIf Fiscal_N = 2 Or Fiscal_N = 3 Then
            M_SLP.Open_SLP()
            M_SLP.SetDate_SLP()
        End If
        If fp_daisy > 0 Then
            Try
                Dim proc() As System.Diagnostics.Process = Process.GetProcessesByName("lsDaisyPrn")
                proc(0).Kill()
            Catch ex As Exception

            End Try

            DaisyFP = New DaisyFPCtrl.DaisyFP(Fiscal_Port)
            'M_Daisy.SetStartupSettings(fp_daisy = 2)
            Try
                DaisyFP.SetOperatorName(operator_num, operator_pwd, p_Person.Name)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        'If Fiscal_N = 4 Then
        '    ACFiscalbox = New Fiscalbox(Fiscal_Tcp, 1)
        '    Dim info = ACFiscalbox.GetInfo()
        '    If info.Code <> "0" Then
        '        Mesigi(info.Message + " (" + info.Code + ")", "Fiscalbox: GetInfo")
        '        Exit Sub
        '    End If
        '    Dim last_online_time As Date? = info.Data.Last_online_time
        '    If last_online_time.HasValue Then
        '        If DateTime.Now.Subtract(last_online_time.Value).TotalMinutes > 1440 Then
        '            Mesigi("Fiscal device last online time is earlier than one day")
        '        End If
        '    End If
        '    ACLogin = ACFiscalbox.Login(Fiscal_Pin, Fiscal_RegNumber)
        '    If ACLogin.Code <> "0" Or ACLogin.Data Is Nothing Then
        '        Mesigi(ACLogin.Message + " (" + ACLogin.Code + ")", "Fiscalbox: Login")
        '        Exit Sub
        '    End If
        '    Dim ShiftStatus As BaseResponse(Of GetShiftStatusData) = ACFiscalbox.GetShiftStatus(ACLogin.Data.Access_token)
        '    If ShiftStatus.Code <> "0" Or ShiftStatus.Data Is Nothing Then
        '        Mesigi(ShiftStatus.Message + " (" + ShiftStatus.Code + ")", "Fiscalbox: ShiftStatus")
        '        Exit Sub
        '    End If
        '    If ShiftStatus.Data.Shift_open = True And ShiftStatus.Data.Shift_open_time.HasValue Then
        '        If DateTime.Now.Subtract(ShiftStatus.Data.Shift_open_time.Value).TotalMinutes > 1440 Then
        '            Check_Z()
        '        End If
        '        'Dim CloseShift = ACFiscalbox.CloseShift(ACLogin.Data.Access_token)
        '        'If CloseShift.Code <> "0" Then
        '        '    Mesigi(CloseShift.Message + " (" + CloseShift.Code + ")", "Fiscalbox: CloseShift")
        '        '    Exit Sub
        '        'End If
        '    End If
        '    If ShiftStatus.Data.Shift_open = False Then
        '        Dim ShiftOpen = ACFiscalbox.OpenShift(ACLogin.Data.Access_token)
        '        If ShiftOpen.Code <> "0" Then
        '            Mesigi(ShiftOpen.Message + " (" + ShiftOpen.Code + ")", "Fiscalbox: OpenShift")
        '            Exit Sub
        '        End If
        '    End If
        'End If

        If Scanner_N = 1 Then
            F_FP_SC_DR.Open_Scanner()
        End If
        If Drawer_N = 1 Then
            F_FP_SC_DR.Open_Drawer()
        ElseIf Drawer_N = 4 Then
            F_NCR_CLS.OpenNCRDrawer("NCR7616CashDrawer.1")
        End If
        M_SQL.Delete_Old_Sales()
        dt_Last_Z_Time = Last_Z_Time()
        Get_NewCheckN_On_Load()
        Look_Last_Sales()
        Check_Log_Size()
        If DGV_Sales.Rows.Count = 0 Then
            M_Z.Check_Z()
        End If
        dt_Last_Update = Last_Update_Time()
        i_Wuti = Random_Minute()
        Copy_Pos()
    End Sub

    Private Sub Fmain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Fiscal_N = 1 Then
            F_FP_SC_DR.Close_Fiscal()
        ElseIf Fiscal_N = 2 Or Fiscal_N = 3 Then
            M_SLP.Close_SLP()
        End If

        If fp_daisy = 1 Then
            Try
                Dim proc() As System.Diagnostics.Process = Process.GetProcessesByName("lsDaisyPrn")
                proc(0).Kill()
            Catch ex As Exception
                'MessageBox.Show("Process lsDaisyPrn has not been killed" + Environment.NewLine + ex.Message)
                'Write_In_Log("Process lsDaisyPrn has not been killed - " + ex.Message)
            End Try
        End If

        If Scanner_N = 1 Then
            F_FP_SC_DR.Close_Scanner()
        End If
        If Drawer_N = 1 Then
            F_FP_SC_DR.Close_Drawer()
        End If
        Shrink_pos_db()
        Application.Exit()
    End Sub

    Public Sub price_List_Load()
        DS1.Clear()
        Dim Conn1 As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
        Dim Comm1 As New System.Data.SqlClient.SqlCommand
        '##### price_list-ის ბუფერში გადმოტანა
        Dim SDA1 As New System.Data.SqlClient.SqlDataAdapter
        Comm1.Connection = Conn1
        Comm1.CommandText = "SELECT kodi, jgufi, dasaxeleba, gas_fasi, CASE wonis WHEN 1 THEN N'წონის' ELSE N'ცალობის' END wonis FROM dbo.price_list ORDER BY jgufi, dasaxeleba"
        SDA1.SelectCommand = Comm1
        SDA1.Fill(DS1, "price_list")

        Dim dr As DataRow = DS1.Tables("price_list").NewRow
        'dr.Item(0) = String.Empty
        'dr.Item(1) = String.Empty
        'dr.Item(2) = String.Empty
        'dr.Item(3) = String.Empty
        'dr.Item(4) = String.Empty
        DS1.Tables("price_list").Rows.InsertAt(dr, 0)
        txt_kodi.SelectedIndex = -1
        txt_kodi.Items.Clear()
        txt_kodi.ColumnNum = 5
        txt_kodi.SourceDataString = New String(4) {"kodi", "jgufi", "dasaxeleba", "gas_fasi", "wonis"}
        txt_kodi.SourceDataTable = DS1.Tables("price_list")
    End Sub

    Private Sub area_Control()
        '##### ეკრანის კონტროლი
        Const KODI_SIGRDZE As Short = 160
        Dim JGUFI_SIGRDZE As Integer
        Dim DASAXELEBA_SIGRDZE As Integer
        Const FASI_SIGRDZE As Short = 80
        Const RAODENOBA_SIGRDZE As Short = 70
        Const JAMI_SIGRDZE As Short = 80

        Dim Screens() As System.Windows.Forms.Screen = System.Windows.Forms.Screen.AllScreens
        screen_X = Screens(0).WorkingArea.Width
        screen_Y = Screens(0).WorkingArea.Height
        DGV_Sales.Left = 2
        DGV_Sales.Top = 0
        lbl_Tanxa.Width = 250
        'lbl_Gadasaxdeli.Width = screen_X - 678

        txt_Gad_Tan.Left = screen_X - txt_Gad_Tan.Width - 20
        lbl_Gasacemi.Left = txt_Gad_Tan.Left
        panel_OrderCtrls.Left = txt_Gad_Tan.Left
        lbl_Status.Left = screen_X - lbl_Status.Width - 20
        lbl_Check_N.Left = txt_Gad_Tan.Left
        lbl_Gad_Tan.Left = txt_Gad_Tan.Left - lbl_Gad_Tan.Width - 6
        lbl_Guests.Left = panel_OrderCtrls.Left - lbl_Guests.Width - 6
        btn_BookinsReport.Left = IIf(lbl_Guests.Visible = True, lbl_Guests, lbl_Status).Left - btn_BookinsReport.Width - 3
        lbl_Xurda.Left = txt_Gad_Tan.Left - lbl_Xurda.Width - 6
        lbl_Nom.Left = txt_Gad_Tan.Left - lbl_Nom.Width - 6
        'prg_Transfer.Left = lbl_Gad_Tan.Left
        'Windows.Forms.Cursor.Position = New System.Drawing.Point(screen_X, 0)
        txt_Gad_Tan.Visible = True
        lbl_Gasacemi.Visible = True

        If screen_Y < 700 Then
            txt_kodi.DropDownHeight -= 70
        End If
        JGUFI_SIGRDZE = Math.Round((screen_X - KODI_SIGRDZE - FASI_SIGRDZE - RAODENOBA_SIGRDZE - JAMI_SIGRDZE - 22) * 0.4, 0)
        DASAXELEBA_SIGRDZE = Math.Round((screen_X - KODI_SIGRDZE - FASI_SIGRDZE - RAODENOBA_SIGRDZE - JAMI_SIGRDZE - 22) * 0.6, 0)

        'DGV_Price.Width = KODI_SIGRDZE + JGUFI_SIGRDZE + DASAXELEBA_SIGRDZE + FASI_SIGRDZE + RAODENOBA_SIGRDZE + 16
        DGV_Sales.Width = KODI_SIGRDZE + JGUFI_SIGRDZE + DASAXELEBA_SIGRDZE + FASI_SIGRDZE + RAODENOBA_SIGRDZE + JAMI_SIGRDZE + 3

        'lbl_Kodi.Width = KODI_SIGRDZE
        'lbl_Jgufi.Width = JGUFI_SIGRDZE
        'lbl_Dasaxeleba.Width = DASAXELEBA_SIGRDZE
        'lbl_Fasi.Width = FASI_SIGRDZE
        'lbl_Raod.Width = RAODENOBA_SIGRDZE
        'lbl_Jami.Width = JAMI_SIGRDZE

        DGV_Sales.Columns(0).Width = KODI_SIGRDZE
        DGV_Sales.Columns(1).Width = JGUFI_SIGRDZE
        DGV_Sales.Columns(2).Width = DASAXELEBA_SIGRDZE
        DGV_Sales.Columns(3).Width = FASI_SIGRDZE
        DGV_Sales.Columns(4).Width = RAODENOBA_SIGRDZE
        DGV_Sales.Columns(5).Width = JAMI_SIGRDZE

        'DGV_Price.Columns(3).DefaultCellStyle.Format = Format("###0.00")
        DGV_Sales.Columns(3).DefaultCellStyle.Format = Format("###0.00")
        DGV_Sales.Columns(5).DefaultCellStyle.Format = Format("###0.00")
        txt_kodi.ColumnWidth = KODI_SIGRDZE & ";" & JGUFI_SIGRDZE & ";" & DASAXELEBA_SIGRDZE & ";" & FASI_SIGRDZE & ";" & RAODENOBA_SIGRDZE
        txt_kodi.Width = Convert.ToInt32(KODI_SIGRDZE) + 2
    End Sub

    Public Sub TranslateUI(ByRef control As Control, ByRef terms As Dictionary(Of String, String), Optional ByVal tgr As Boolean = False)
        Dim termKey = control.Text
        Dim termValue = termKey
        If Not terms Is Nothing Then
            If terms.ContainsKey(termKey) Then
                termValue = terms(termKey)
            End If
        End If

        If TypeOf control Is DataGridView Then
            Dim dg As DataGridView = control
            For Each col As DataGridViewColumn In dg.Columns
                termKey = col.HeaderText
                termValue = termKey

                If terms.ContainsKey(termKey) Then
                    termValue = terms(termKey)
                End If
                col.HeaderText = termValue
            Next
            If tgr = True Then
                For Each row As DataGridViewRow In dg.Rows
                    termKey = row.Cells(0).Value.ToString()
                    termValue = termKey

                    If terms.ContainsKey(termKey) Then
                        termValue = terms(termKey)
                    End If
                    row.Cells(0).Value = termValue
                Next
            End If
        ElseIf TypeOf control Is StatusStrip Then
            Dim ss As StatusStrip = control
            For Each ssi As ToolStripItem In ss.Items
                termKey = ssi.Text
                termValue = termKey

                If terms.ContainsKey(termKey) Then
                    termValue = terms(termKey)
                End If
                ssi.Text = termValue
            Next
        ElseIf TypeOf control Is Infragistics.Win.UltraWinGrid.UltraGrid Then
            Dim ug As Infragistics.Win.UltraWinGrid.UltraGrid = control
            ug.Text = termValue

            termKey = ug.DisplayLayout.Bands(0).SummaryFooterCaption
            termValue = termKey

            If terms.ContainsKey(termKey) Then
                termValue = terms(termKey)
            End If
            ug.DisplayLayout.Bands(0).SummaryFooterCaption = termValue
        ElseIf control.Name <> "lbl_SaleType" Then
            control.Text = termValue
        End If

        For Each ctrl As Control In control.Controls
            TranslateUI(ctrl, terms, tgr)
        Next
    End Sub

    Private Sub RunStartupScripts()
        Dim Conn As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Comm.Connection = Conn

        Comm.CommandType = CommandType.Text

        Conn.Open()

        Try
            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM syscolumns WHERE id = OBJECT_ID('pos_sales') AND [name] = 'customerID') ALTER TABLE dbo.pos_sales ADD customerID NVARCHAR(64)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM syscolumns WHERE id = OBJECT_ID('pos_sales') AND [name] = 'card_pay') ALTER TABLE dbo.pos_sales ADD card_pay float"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM syscolumns WHERE id = OBJECT_ID('pos_sales') AND [name] = 'fiscal_docid') ALTER TABLE dbo.pos_sales ADD fiscal_docid nvarchar(64)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM dbo.syscolumns WHERE id = OBJECT_ID(N'[dbo].[price_list]') AND [name] = N'pType') ALTER TABLE dbo.price_list ADD pType INT NOT NULL CONSTRAINT [DF_price_list_pType] DEFAULT (1)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CustomerList]') AND type in (N'U')) CREATE TABLE dbo.CustomerList (CustomerID INT NOT NULL, CustomerKEY NVARCHAR(16) NOT NULL, CustomerName NVARCHAR(64), Bonus FLOAT, StatusID INT CONSTRAINT [PK_CustomerList] PRIMARY KEY CLUSTERED ([CustomerID] ASC))"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (EXISTS (SELECT id FROM sysindexes WHERE id = Object_id(N'price_list') AND name = N'PK_price_list_1')) BEGIN ALTER TABLE dbo.price_list DROP CONSTRAINT PK_price_list_1 ALTER TABLE dbo.price_list ADD CONSTRAINT PK_price_list PRIMARY KEY CLUSTERED (kodi asc) ON [PRIMARY] END"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'pos_salelines') AND name = N'scanTime')) ALTER TABLE dbo.pos_salelines ADD scanTime DATETIME NULL CONSTRAINT [DF_pos_salelines_scanTime] DEFAULT (GETDATE())"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'pos_salelines') AND name = N'dscQuantity')) ALTER TABLE dbo.pos_salelines ADD dscQuantity FLOAT NULL CONSTRAINT [DF_pos_salelines_dscQuantity] DEFAULT (0)"
            Comm.ExecuteNonQuery()

            If Drawer_N = 4 Then
                Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND name = N'drawer_name')) ALTER TABLE dbo.settings ADD drawer_name NVARCHAR(32) NOT NULL CONSTRAINT [DF_settings_drawer_name] DEFAULT ('NCRCashDrawer.0')"
            Else
                Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND name = N'drawer_name')) ALTER TABLE dbo.settings ADD drawer_name NVARCHAR(32) NOT NULL CONSTRAINT [DF_settings_drawer_name] DEFAULT ('drawer4')"
            End If
            Comm.ExecuteNonQuery()

            If Fiscal_N = 1 Then
                Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND name = N'fiscal_port')) ALTER TABLE dbo.settings ADD fiscal_port NVARCHAR(32) NOT NULL CONSTRAINT [DF_settings_fiscal_port] DEFAULT ('COM3')"
            Else
                Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND name = N'fiscal_port')) ALTER TABLE dbo.settings ADD fiscal_port NVARCHAR(32) NOT NULL CONSTRAINT [DF_settings_fiscal_port] DEFAULT ('COM1')"
            End If
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND name = N'secondary_monitor')) ALTER TABLE dbo.settings ADD secondary_monitor INT NOT NULL CONSTRAINT [DF_settings_secondary_monitor] DEFAULT (1)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'fn_getCurrentBit') AND type IN (N'FN')) BEGIN DECLARE @s NVARCHAR(1024) SET @s = N'CREATE FUNCTION [dbo].[fn_getCurrentBit](@Value AS TINYINT, @BitN AS TINYINT) RETURNS BIT AS BEGIN DECLARE @ReturnValue AS BIT DECLARE @CompareValue AS TINYINT	SET @CompareValue = POWER(2, @BitN - 1)	SET @ReturnValue = @Value & @CompareValue RETURN @ReturnValue END' EXEC sp_executesql @s END"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM dbo.syscolumns WHERE id = OBJECT_ID(N'[dbo].[price_list]') AND [name] = N'bonusPrice') ALTER TABLE dbo.price_list ADD bonusPrice FLOAT NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'price_list') AND name = N'pNote')) ALTER TABLE dbo.price_list ADD pNote NVARCHAR(16) NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'price_list') AND name = N'wsQuantity')) ALTER TABLE dbo.price_list ADD wsQuantity FLOAT NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'price_list') AND name = N'wsPrice')) ALTER TABLE dbo.price_list ADD wsPrice FLOAT NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'price_list') AND name = N'pairKey')) ALTER TABLE dbo.price_list ADD pairKey NVARCHAR(16) NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF  EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_pos_salelines_pos_sales]') AND parent_obj = OBJECT_ID(N'[dbo].[pos_salelines]')) ALTER TABLE [dbo].[pos_salelines] DROP CONSTRAINT [FK_pos_salelines_pos_sales]"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_pos_salelines_pos_salesNew]') AND parent_obj = OBJECT_ID(N'[dbo].[pos_salelines]')) ALTER TABLE [dbo].[pos_salelines]  WITH CHECK ADD  CONSTRAINT [FK_pos_salelines_pos_salesNew] FOREIGN KEY([check_n]) REFERENCES [dbo].[pos_sales] ([check_n]) ON DELETE CASCADE ON UPDATE CASCADE"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "ALTER TABLE [dbo].[pos_salelines] ALTER COLUMN [ttime] NVARCHAR(32) NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'pos_salelines') AND name = N'id')) ALTER TABLE dbo.pos_salelines ADD id int not null identity (1,1)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF EXISTS (SELECT * FROM sysindexes WHERE id = OBJECT_ID(N'[dbo].[pos_salelines]') AND name = N'PK_pos_salelines') ALTER TABLE [dbo].[pos_salelines] DROP CONSTRAINT [PK_pos_salelines]"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysindexes WHERE id = OBJECT_ID(N'[dbo].[pos_salelines]') AND name = N'PK_pos_salelinesNew') ALTER TABLE [dbo].[pos_salelines] add constraint [PK_pos_salelinesNew] primary key clustered (id)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'pos_salelines') AND name = N'parentId')) ALTER TABLE dbo.pos_salelines ADD parentId int NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_pos_salelines_pos_salelines]') AND parent_obj = OBJECT_ID(N'[dbo].[pos_salelines]')) ALTER TABLE [dbo].[pos_salelines] ADD  CONSTRAINT [FK_pos_salelines_pos_salelines] FOREIGN KEY([parentId]) REFERENCES [dbo].[pos_salelines] ([id])"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'pos_salelines') AND name = N'order_printed')) ALTER TABLE dbo.pos_salelines ADD order_printed bit not null default(0)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'pos_salelines') AND [name] = 'order_rank')) alter table dbo.pos_salelines add order_rank int not null default(0)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'Items') AND name = N'isMenu')) ALTER TABLE dbo.Items ADD isMenu bit not NULL default(0)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'Items') AND [name] = 'itmNOTE' AND prec = 255)) ALTER TABLE dbo.Items ALTER COLUMN itmNOTE nvarchar(255)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'company_name')) ALTER TABLE dbo.settings ADD company_name nvarchar(50)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'ui_language')) ALTER TABLE dbo.settings ADD ui_language nvarchar(8)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'bank_terminal_id')) ALTER TABLE dbo.settings ADD bank_terminal_id nvarchar(64)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'bank_terminal_port')) ALTER TABLE dbo.settings ADD bank_terminal_port nvarchar(32)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[UITerms]') AND type in (N'U')) CREATE TABLE dbo.UITerms (Id INT NOT NULL, TermKey NVARCHAR(250) NOT NULL, TermValue NVARCHAR(250) CONSTRAINT [PK_UITerms] PRIMARY KEY CLUSTERED ([ID] ASC))"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'UITerms') AND [name] = 'TypeCode')) ALTER TABLE dbo.UITerms ADD TypeCode nvarchar(32)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'allow_prebill')) ALTER TABLE dbo.settings ADD allow_prebill bit not NULL default(0)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'fiscal_tcp')) ALTER TABLE dbo.settings ADD fiscal_tcp varchar(64) NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'fiscal_regnumber')) ALTER TABLE dbo.settings ADD fiscal_regnumber varchar(64) NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'fiscal_pin')) ALTER TABLE dbo.settings ADD fiscal_pin varchar(16) NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'fiscal_currency')) ALTER TABLE dbo.settings ADD fiscal_currency varchar(4) NULL"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'vat_percent')) ALTER TABLE dbo.settings ADD vat_percent float not null default(18)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'allow_orders')) ALTER TABLE dbo.settings ADD allow_orders bit not NULL default(0)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[order_tablegroups]') AND type in (N'U')) create table dbo.order_tablegroups (id int not null identity(1,1) constraint pk_order_tablegroups primary key, code nvarchar(32) not null, name nvarchar(255) not null, sort_id int, active bit not null default(1))"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[order_tables]') AND type in (N'U')) CREATE TABLE dbo.order_tables (id int not null identity(1,1) primary key clustered,code nvarchar(32) not null unique,[name] nvarchar(255) not null,[description] nvarchar(1024),sort_id int,active bit not null default(1))"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'[dbo].[order_tables]') AND [name] = 'group_id')) alter table dbo.order_tables add group_id int constraint fk_order_tables_order_tablegroups references dbo.order_tablegroups (id)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM syscolumns WHERE id = OBJECT_ID('pos_sales') AND [name] = 'table_id') alter table dbo.pos_sales add table_id int constraint fk_pos_sales_order_tables references dbo.order_tables (id)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[receipt_printers]') AND type in (N'U')) CREATE TABLE dbo.receipt_printers (id int not null identity(1,1) primary key clustered,code nvarchar(32) not null,[name] nvarchar(255) not null,[description] nvarchar(1024),net_address nvarchar(32),sort_id int,active bit not null default(1))"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[itemgroup_printers]') AND type in (N'U')) CREATE TABLE dbo.itemgroup_printers (itmg_id int not null,printer_id int not null constraint fk_itemgroup_printers_printers references dbo.receipt_printers (id),constraint pk_itemgroup_printers primary key clustered (itmg_id, printer_id))"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[table_orders]') AND type in (N'U')) CREATE TABLE dbo.table_orders (id int not null identity(1,1) primary key clustered,table_id int not null constraint fk_open_tables_order_tables references dbo.order_tables (id), check_n int not null constraint fk_open_tables_pos_sales references dbo.pos_sales (check_n), order_closed bit not null default(0), open_date datetime not null default(getdate()), close_date datetime)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "insert into itemgroup_printers (itmg_id, printer_id) select itmgID, 2 printer_id from dbo.receipt_printers p, itemgroups g left join dbo.itemgroup_printers gp on g.itmgID = gp.itmg_id and printer_id = 2 where g.itmgPID = 2966 and p.Id = 2 and gp.itmg_id is null"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'[dbo].[table_orders]') AND [name] = 'supervisor')) alter table dbo.table_orders add supervisor nvarchar(100)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'[dbo].[table_orders]') AND [name] = 'guests')) alter table dbo.table_orders add guests int"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'[dbo].[order_tablegroups]') AND [name] = 'rgbhex')) alter table dbo.order_tablegroups add rgbhex nvarchar(100)"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "IF (NOT EXISTS (SELECT id FROM syscolumns WHERE id = object_id(N'settings') AND [name] = 'resos_id')) ALTER TABLE dbo.settings ADD resos_id varchar(50) NULL"
            Comm.ExecuteNonQuery()

            'Comm.CommandText = "update settings set company_name = N'შპს ანტრე 2008' where market_name like N'ანტრე%'"
            'Comm.ExecuteNonQuery()

            'If Market_N = 30 And (Fiscal_N = 1 Or Printer_N = 1) Then
            'If fp_daisy < 2 Then
            '    Comm.CommandText = "UPDATE SETTINGS SET device1 = 2, fiscal = 0, printer = 0"
            '    Comm.ExecuteNonQuery()
            'End If
            'End If

        Catch ex As Exception
            Mesigi("Startup script execution failed!")
            Write_In_Log("Err_RunStartupScripts: " + ex.Message)
        End Try
    End Sub

    Private Sub Run72StartupScripts()
        Dim Conn As New SqlClient.SqlConnection(LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand With {
            .Connection = Conn,
            .CommandType = CommandType.Text
        }

        Conn.Open()

        Try
            Comm.CommandText = "SELECT count(id) as count_id FROM dbo.order_tables where code = 'TABLE27'"
            Dim table27id As Integer = Comm.ExecuteScalar()
            If table27id > 0 Then
                Conn.Close()
                Comm.Dispose()
                Conn.Dispose()
                Exit Sub
            End If

            Comm.CommandText = "update dbo.order_tablegroups set rgbhex = '#00b0f0' where id = 1
                                update dbo.order_tablegroups set rgbhex = '#ffa6b2' where id = 2
                                update dbo.order_tablegroups set rgbhex = '#00b0f0' where id = 3
                                update dbo.order_tablegroups set rgbhex = '#00b0f0' where id = 4
                                update dbo.order_tablegroups set rgbhex = '#ffc000' where id = 5"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "update dbo.order_tables set active = 0 where code = 'TABLE13'
                                update dbo.order_tables set [name] = '01' where code = 'TABLE16'
                                update dbo.order_tables set [name] = '02' where code = 'TABLE17'
                                update dbo.order_tables set [name] = '03' where code = 'TABLE18'
                                update dbo.order_tables set [name] = '04' where code = 'TABLE19'"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "update dbo.order_tables set group_id = 1 where code >= 'TABLE01' and code < 'TABLE07'
                                update dbo.order_tables set group_id = 4 where code >= 'TABLE07' and code < 'TABLE15'
                                update dbo.order_tables set group_id = 3 where code >= 'TABLE15' and code < 'TABLE16'
                                update dbo.order_tables set group_id = 2 where code >= 'TABLE16' and code < 'TABLE20'
                                update dbo.order_tables set group_id = 5 where code >= 'TABLE20' and code < 'TABLE26'"
            Comm.ExecuteNonQuery()

            Comm.CommandText = "if (not exists (select id from dbo.order_tables where code = 'TABLE25')) insert into dbo.order_tables (code, [name], [description], [sort_id], [active], [group_id]) values ('TABLE25', '25', N'ოცდამეხუთე', 25, 1, 5)
                                if (not exists (select id from dbo.order_tables where code = 'TABLE26')) insert into dbo.order_tables (code, [name], [description], [sort_id], [active], [group_id]) values ('TABLE26', '05', N'ოცდამეექვსე', 26, 1, 2)
                                if (not exists (select id from dbo.order_tables where code = 'TABLE27')) insert into dbo.order_tables (code, [name], [description], [sort_id], [active], [group_id]) values ('TABLE27', '06', N'ოცდამეშვიდე', 27, 1, 2)"
            Comm.ExecuteNonQuery()

        Catch ex As Exception
            Mesigi("Startup script (72) execution failed!")
            Write_In_Log("Err_Run72StartupScripts: " + ex.Message)
        End Try
    End Sub


    Private Sub Share_Settings()
        Dim Conn As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Dim Reader As SqlClient.SqlDataReader
        Comm.Connection = Conn
        Comm.CommandText = "SELECT * FROM settings"
        Try
            Conn.Open()
            Reader = Comm.ExecuteReader
            While Reader.Read
                Market_N = Reader.Item(0)
                Pos_N = Reader.Item(1)
                Market_Name = Reader.Item(2)
                Market_Address = Reader.Item(3)
                Fiscal_N = Reader.Item(4)
                Scanner_N = Reader.Item(5)
                Drawer_N = Reader.Item(6)
                Printer_N = Reader.Item(7)

                Try
                    fp_daisy = Reader.Item("device1")
                    Drawer_Name = Reader.Item("drawer_name").ToString()
                    Fiscal_Port = Reader.Item("fiscal_port").ToString()
                    SecondaryMonitorIndex = Reader.Item("secondary_monitor")
                    Company_Name = Reader.Item("company_name").ToString()
                    UI_Language = IIf(Reader.Item("ui_language").ToString() = String.Empty, "Ge", Reader.Item("ui_language").ToString())
                    If Reader.GetValue(Reader.GetOrdinal("bank_terminal_id")).Equals(DBNull.Value) Then
                        BankTerminalId = BankTerminalId
                    Else
                        BankTerminalId = Reader.Item("bank_terminal_id")
                    End If
                    If Reader.GetValue(Reader.GetOrdinal("bank_terminal_port")).Equals(DBNull.Value) Then
                        BankTerminalPort = BankTerminalPort
                    Else
                        BankTerminalPort = Reader.Item("bank_terminal_port")
                    End If
                    PrebillAllowed = Reader.Item("allow_prebill")
                    OrdersAllowed = Reader.Item("allow_orders")
                    ResOSId = Reader.Item("resos_id")
                    Fiscal_Tcp = Reader.Item("fiscal_tcp").ToString()
                    Fiscal_RegNumber = Reader.Item("fiscal_regnumber").ToString()
                    Fiscal_Pin = Reader.Item("fiscal_pin").ToString()
                    Fiscal_Currency = Reader("fiscal_currency").ToString()
                    VATPercent = Reader.Item("vat_percent")
                Catch ex As Exception
                    Dim a As String = ex.Message
                    'MessageBox.Show(ex.Message)
                    Write_In_Log("Err_Share_Settings: " & ex.Message)
                End Try

                'isTouch = Reader.Item(8)
            End While
            If Company_Name.Contains(Environment.NewLine) Then
                Dim cmpHeaders = Company_Name.Split(Environment.NewLine)
                If cmpHeaders.Length > 1 Then
                    Company_Name = cmpHeaders(0).Trim()
                    Company_Line = cmpHeaders(1).Trim()
                End If
            End If

            lbl_Magh.Text = Market_Name
            'If Drawer_N = 6 Then
            '    drawer_timer.Interval = 200
            '    drawer_timer.Enabled = False
            'End If
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Share_Settings:")
            Write_In_Log("Err_Share_Settings: " & ex.Message)
            Application.Exit()
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Get_Server_Date()
        Dim ConnS As New System.Data.SqlClient.SqlConnection(Me.SERVER_CONN_STR)
        Try
            ConnS.Open()
        Catch ex As Exception
            b_Servertan_Aris_Kavshiri = False
            dt_Servertan_Kavshirisatvis = Now
            lbl_Status.ForeColor = Color.Red
            Write_In_Log("servertan kavshiri ar aris: Get_Server_Date")
            Exit Sub
        End Try

        'Dim pinfo As New ProcessStartInfo("FontReg.exe")
        'pinfo.Arguments = "/copy"
        'pinfo.WindowStyle = ProcessWindowStyle.Hidden

        'Process.Start(pinfo)

        'System.IO.File.Copy("sylfaen.ttf", "c:\windows\fonts\sylfaen.ttf", True)
        DownloadDlls(ConnS)
        'Dim Comm1 As New SqlClient.SqlCommand("select * from dbo.take_date", ConnS)
        Dim Comm1 As New SqlClient.SqlCommand("SELECT Getdate()", ConnS)
        Dim Reader As SqlClient.SqlDataReader
        Try
            Reader = Comm1.ExecuteReader
            While Reader.Read
                Dim ST As New SYSTEMTIME
                Dim RD As Date = Reader.GetDateTime(0)
                RD = RD.AddHours(0 - DateDiff(DateInterval.Hour, My.Computer.Clock.GmtTime, Now))
                ST.wYear = RD.Year
                ST.wMonth = RD.Month
                ST.wDay = RD.Day
                ST.wHour = RD.Hour
                ST.wMinute = RD.Minute
                ST.wSecond = RD.Second
                ST.wMilliseconds = RD.Millisecond
                SetSystemTime(ST)
            End While
            Reader.Close()
            lbl_Status.ForeColor = Color.Green
            DownloadNewPosExe(ConnS)
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Get_Server_Date:")
            Write_In_Log("Err_Get_Server_Date: " & ex.Message)
        Finally
            ConnS.Close()
        End Try
    End Sub

    Private Function Last_Z_Time() As Date
        Dim ConnL As New System.Data.SqlClient.SqlConnection(Me.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand("select isnull((select top 1 sale_date from pos_sales where check_n > (select max(check_n) mc from pos_sales where sale_type = 6)),dateadd(hour, 0, getdate())) sale_date", ConnL)
        Dim Reader As SqlClient.SqlDataReader
        Try
            ConnL.Open()
            Reader = Comm.ExecuteReader
            While Reader.Read
                If Not (Reader.Item(0) Is DBNull.Value) Then
                    Return (Reader.Item(0))
                Else
                    Return (#1/1/2000#)
                End If
            End While
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Last_Z_Time:")
            Write_In_Log("Err_Last_Z_Time: " & ex.Message)
        Finally
            ConnL.Close()
        End Try
    End Function

    Private Function Last_Update_Time() As Date
        Dim ConnL As New System.Data.SqlClient.SqlConnection(Me.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand("SELECT price_update_time FROM date_times", ConnL)
        Dim Reader As SqlClient.SqlDataReader
        Try
            ConnL.Open()
            Reader = Comm.ExecuteReader
            While Reader.Read
                If Not (Reader.Item(0) Is DBNull.Value) Then
                    Return (Reader.Item(0))
                Else
                    Return (#1/1/2000#)
                End If
            End While
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Last_Update_Time:")
            Write_In_Log("Err_Last_Update_Time: " & ex.Message)
        Finally
            ConnL.Close()
        End Try
    End Function

    Private Function Random_Minute() As Short
        Randomize()
        Dim wuti As Integer = Int((59 * Rnd()) + 1)
        Return (wuti)
    End Function

    Private Sub Automatic_Update()
        Try
            Select Case Now.TimeOfDay
                Case #11:50:00 AM#.AddMinutes(i_Wuti).TimeOfDay To #5:35:00 PM#.TimeOfDay
                    Select Case dt_Last_Update.TimeOfDay
                        Case #11:50:00 AM#.TimeOfDay To #5:35:00 PM#.TimeOfDay
                        Case Else
                            If b_Servertan_Aris_Kavshiri Then
                                dt_Last_Update = Now
                                Write_In_Log("daiwyo avtomaturi ganaxleba")
                                M_SQL.Update_Price()
                            End If
                    End Select
                Case #5:50:00 PM#.AddMinutes(i_Wuti).TimeOfDay To #11:35:00 PM#.TimeOfDay
                    Select Case dt_Last_Update.TimeOfDay
                        Case #5:50:00 PM#.TimeOfDay To #11:35:00 PM#.TimeOfDay
                        Case Else
                            If b_Servertan_Aris_Kavshiri Then
                                dt_Last_Update = Now
                                Write_In_Log("daiwyo avtomaturi ganaxleba")
                                M_SQL.Update_Price()
                            End If
                    End Select
            End Select
        Catch ex As Exception
            Write_In_Log("Automatic_Update: " & ex.Message)
        End Try

        'Case #12:00:00 AM# To #5:35:00 PM#
        'Case #6:00:00 PM# To #11:35:00 PM#
    End Sub

    Private Sub Copy_Pos()
        'Try
        '    If My.Computer.FileSystem.FileExists("C:\pos\Pos.exe") Then
        '        If FileSystem.FileDateTime("\\server-" & Market_N.ToString("00") & "\C\pos\Pos.exe") > FileSystem.FileDateTime("C:\pos\Pos.exe") Then
        '            FileSystem.FileCopy("\\server-" & Market_N.ToString("00") & "\C\pos\Pos.exe", "C:\pos\Pos.exe")
        '        End If
        '    Else
        '        FileSystem.FileCopy("\\server-" & Market_N.ToString("00") & "\C\pos\Pos.exe", "C:\pos\Pos.exe")
        '    End If
        'Catch ex As Exception
        '    Write_In_Log("Err_Copy_Pos: " & ex.Message)
        'End Try
    End Sub

    Private Sub DownloadNewPosExe(ByVal Conn As SqlClient.SqlConnection)
        Dim Comm As New System.Data.SqlClient.SqlCommand()
        Comm.CommandType = Data.CommandType.Text
        Comm.Connection = Conn
        Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'Pos.exe' AND FileType = '.exe'"

        Try
            Dim ModDateServer As DateTime = Comm.ExecuteScalar()
            Dim ModDateLocal As DateTime

            If System.IO.File.Exists("C:\Pos\Pos.exe") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\Pos.exe")
            Else
                ModDateLocal = DateTime.MinValue
            End If


            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'Pos.exe' AND FileType = '.exe'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\Pos.exe", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\Pos.exe", ModDateServer)
            End If
            Conn.Close()
        Catch ex As Exception
            Write_In_Log("Err_DownloadPosExe: " & ex.Message)
        End Try
    End Sub

    Private Sub DownloadDlls(ByVal Conn As SqlClient.SqlConnection)
        Dim Comm As New System.Data.SqlClient.SqlCommand()
        Comm.CommandType = Data.CommandType.Text
        Comm.Connection = Conn
        Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'Interop.OposCashDrawer_1_10_Lib.dll' AND FileType = '.dll'"

        Try
            'Interop.OposCashDrawer_1_10_Lib.dll
            Dim ModDateServer As DateTime = Comm.ExecuteScalar()
            Dim ModDateLocal As DateTime

            If System.IO.File.Exists("C:\Pos\Interop.OposCashDrawer_1_10_Lib.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\Interop.OposCashDrawer_1_10_Lib.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If


            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'Interop.OposCashDrawer_1_10_Lib.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\Interop.OposCashDrawer_1_10_Lib.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\Interop.OposCashDrawer_1_10_Lib.dll", ModDateServer)
            End If

            'AxInterop.OposCashDrawer_1_10_Lib.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'AxInterop.OposCashDrawer_1_10_Lib.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\AxInterop.OposCashDrawer_1_10_Lib.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\AxInterop.OposCashDrawer_1_10_Lib.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If


            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'AxInterop.OposCashDrawer_1_10_Lib.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\AxInterop.OposCashDrawer_1_10_Lib.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\AxInterop.OposCashDrawer_1_10_Lib.dll", ModDateServer)
            End If

            'PosManualSync.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'PosManualSync.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\PosManualSync.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\PosManualSync.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If


            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'PosManualSync.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\PosManualSync.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\PosManualSync.dll", ModDateServer)
            End If

            'GCAnator.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'GCAnator.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\GCAnator.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\GCAnator.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'GCAnator.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\GCAnator.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\GCAnator.dll", ModDateServer)
            End If

            'panel_body.jpg
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'panel_body.jpg' AND FileType = '.jpg'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\panel_body.jpg") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\panel_body.jpg")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'panel_body.jpg' AND FileType = '.jpg'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\panel_body.jpg", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\panel_body.jpg", ModDateServer)
            End If

            'panel_logo.jpg
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'panel_logo.jpg' AND FileType = '.jpg'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\panel_logo.jpg") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\panel_logo.jpg")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'panel_logo.jpg' AND FileType = '.jpg'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\panel_logo.jpg", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\panel_logo.jpg", ModDateServer)
            End If

            'panel_monitor.jpg
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'panel_monitor.jpg' AND FileType = '.jpg'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\panel_monitor.jpg") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\panel_monitor.jpg")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'panel_monitor.jpg' AND FileType = '.jpg'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\panel_monitor.jpg", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\panel_monitor.jpg", ModDateServer)
            End If

            'panel_item.jpg
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'panel_item.jpg' AND FileType = '.jpg'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\panel_item.jpg") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\panel_item.jpg")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'panel_item.jpg' AND FileType = '.jpg'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\panel_item.jpg", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\panel_item.jpg", ModDateServer)
            End If

            'WincorDrawerCtrl.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'WincorDrawerCtrl.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\WincorDrawerCtrl.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\WincorDrawerCtrl.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'WincorDrawerCtrl.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\WincorDrawerCtrl.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\WincorDrawerCtrl.dll", ModDateServer)
            End If

            'PosiflexDrawerTest.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'PosiflexDrawerTest.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\PosiflexDrawerTest.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\PosiflexDrawerTest.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'PosiflexDrawerTest.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\PosiflexDrawerTest.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\PosiflexDrawerTest.dll", ModDateServer)
            End If

            'eptcvx.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'eptcvx.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\eptcvx.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\eptcvx.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'eptcvx.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\eptcvx.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\eptcvx.dll", ModDateServer)
            End If

            'AirConnFiscaler.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'AirConnFiscaler.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\AirConnFiscaler.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\AirConnFiscaler.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'AirConnFiscaler.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\AirConnFiscaler.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\AirConnFiscaler.dll", ModDateServer)
            End If

            'Newtonsoft.Json.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'Newtonsoft.Json.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\Newtonsoft.Json.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\Newtonsoft.Json.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'Newtonsoft.Json.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\Newtonsoft.Json.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\Newtonsoft.Json.dll", ModDateServer)
            End If

            'ZeroMQ.dll
            Comm.CommandText = "SELECT UploadDate FROM ExternFiles WITH (NOLOCK) WHERE FileName = 'ZeroMQ.dll' AND FileType = '.dll'"

            ModDateServer = Comm.ExecuteScalar()

            If System.IO.File.Exists("C:\Pos\ZeroMQ.dll") Then
                ModDateLocal = FileSystem.FileDateTime("C:\Pos\ZeroMQ.dll")
            Else
                ModDateLocal = DateTime.MinValue
            End If

            If ModDateServer > ModDateLocal Then
                Comm.CommandText = "SELECT FileData FROM dbo.ExternFiles WITH (NOLOCK) WHERE FileName = 'ZeroMQ.dll' AND FileType = '.dll'"
                Dim fData As Byte() = Comm.ExecuteScalar()
                System.IO.File.WriteAllBytes("C:\Pos\ZeroMQ.dll", fData)
                System.IO.File.SetLastWriteTime("C:\Pos\ZeroMQ.dll", ModDateServer)
            End If

            'Conn.Close()
        Catch ex As Exception
            Write_In_Log("DownloadDlls: " & ex.Message)
        End Try
    End Sub

    Private Sub Add_Row_to_Monitor(ByVal rowIndex As Integer)
        If Screen.AllScreens.Length > SecondaryMonitorIndex And SecondaryMonitorIndex > 0 Then
            Dim con As New SqlClient.SqlConnection(Me.LOCAL_CONN_STR)
            Dim com As New SqlClient.SqlCommand()
            Dim dr As SqlClient.SqlDataReader
            Dim data() As Byte
            Dim stream As New IO.MemoryStream()
            Dim img As Drawing.Image = Nothing

            com.CommandType = CommandType.StoredProcedure
            com.Connection = con
            com.CommandText = "sp_getItemInfo"
            com.Parameters.Add("@itmKEY", SqlDbType.NVarChar, 16)
            com.Parameters(0).Value = DGV_Sales.Rows(rowIndex).Cells(0).Value.ToString()

            'If (Screen.AllScreens.Length > 1) Then
            If (DGV_Sales.Rows.Count = 1) Then
                frmMonitorCheck.Close()
                frmMonitorCheck.Height = Int(Screen.AllScreens(SecondaryMonitorIndex).WorkingArea.Height * 0.95)
                frmMonitorCheck.Left = Screen.AllScreens(0).WorkingArea.Width + (Screen.AllScreens(SecondaryMonitorIndex).WorkingArea.Width - frmMonitorCheck.Width) / 2
                frmMonitorCheck.Top = (Screen.AllScreens(SecondaryMonitorIndex).WorkingArea.Height - frmMonitorCheck.Height) / 2
                'frmMonitorCheck.Left = (Screen.AllScreens(0).WorkingArea.Width - frmMonitorCheck.Width) / 2
                'frmMonitorCheck.Top = (Screen.AllScreens(0).WorkingArea.Height - frmMonitorCheck.Height) / 2

                frmMonitorCheck.Show()
                Me.Focus()
            End If

            con.Open()
            frmMonitorCheck.UltraGrid1.DisplayLayout.Bands(0).AddNew()
            dr = com.ExecuteReader()
            dr.Read()

            If Not dr("itmImage") Is DBNull.Value Then
                data = dr("itmImage")
                stream.Write(data, 0, data.Length)
                img = Drawing.Image.FromStream(stream)
                frmMonitorCheck.UltraGrid1.ActiveRow.Cells("itmImage").Value = img
            Else
                frmMonitorCheck.UltraGrid1.ActiveRow.Cells("itmImage").Value = frmMonitorCheck.PictureBox1.Image
            End If

            frmMonitorCheck.UltraGrid1.ActiveRow.Cells("itmKEY").Value = dr("itmKEY")
            frmMonitorCheck.UltraGrid1.ActiveRow.Cells("itmName").Value = dr("itmNAME")
            frmMonitorCheck.UltraGrid1.ActiveRow.Cells("itmQuantity").Value = DGV_Sales.Rows(rowIndex).Cells(4).Value
            frmMonitorCheck.UltraGrid1.ActiveRow.Cells("itmUnit").Value = dr("dmKEY")
            frmMonitorCheck.UltraGrid1.ActiveRow.Cells("itmPrice").Value = DGV_Sales.Rows(rowIndex).Cells(3).Value
            frmMonitorCheck.UltraGrid1.ActiveRow.Cells("itmAmount").Value = DGV_Sales.Rows(rowIndex).Cells(5).Value
            con.Close()
            frmMonitorCheck.UltraGrid1.Rows(rowIndex).Hidden = (Math.Abs(Val(DGV_Sales.Rows(rowIndex).Cells(4).Value)) < 0.0001)
            'End If
        End If
    End Sub

    Private Sub Update_Monitor_Row(ByVal rowIndex As Integer, ByVal colIndex As Integer)
        If Screen.AllScreens.Length > SecondaryMonitorIndex And SecondaryMonitorIndex > 0 Then
            'If CType(DGV_Sales.Rows(rowIndex).Cells(colIndex).Value, Integer) > 0 Then
            If frmMonitorCheck.UltraGrid1.Rows.Count > 0 Then
                'For i As Integer = 0 To frmMonitorCheck.UltraGrid1.Rows.Count - 1 Step 1
                '    If frmMonitorCheck.UltraGrid1.Rows(i).Cells("itmKey").Value = DGV_Sales.Rows(e.RowIndex).Cells(0).Value Then
                '        rowFound = i
                '        Exit For
                '    End If
                'Next i
                'If rowFound <> -1 Then
                frmMonitorCheck.UltraGrid1.Rows(rowIndex).Cells("itmQuantity").Value = DGV_Sales.Rows(rowIndex).Cells(colIndex).Value
                frmMonitorCheck.UltraGrid1.Rows(rowIndex).Cells("itmAmount").Value = DGV_Sales.Rows(rowIndex).Cells(5).Value
                'Else
                'Add_Row_to_Monitor(e.RowIndex)
                'End If
            End If
            'Else
            frmMonitorCheck.UltraGrid1.Rows(rowIndex).Hidden = (Math.Abs(Val(DGV_Sales.Rows(rowIndex).Cells(colIndex).Value)) < 0.0001)
            'End If
        End If
    End Sub
    Private Sub txt_kodi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_kodi.KeyDown
        If Not IsNumeric(txt_kodi.Text) Then
            txt_kodi.SelectedIndex = 0
        End If
        'Dim fThumbs As New frmThumbs
        Select Case e.KeyCode
            Case Keys.Enter
x:              If txt_kodi.Text <> String.Empty Then
                    Dim sale_type As Integer = 1
                    Dim table_id As Integer? = Nothing
                    Dim supervisor As String = Nothing
                    Dim guests As Integer? = Nothing
                    If lbl_SaleType.Text.StartsWith("შეკვეთა") Then
                        sale_type = 8
                    End If
                    If Not OrderedTable Is Nothing Then
                        table_id = OrderedTable.Id
                        supervisor = OrderedTable.Supervisor
                        guests = OrderedTable.Guests
                    End If
                    If lbl_SaleType.Text = "გაყიდვა" Or lbl_SaleType.Text.StartsWith("შეკვეთა") Then
                        Dim Conn As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
                        Dim Comm As New System.Data.SqlClient.SqlCommand
                        Dim Reader As System.Data.SqlClient.SqlDataReader
                        Dim b_DGV_Sales_Focus As Boolean
                        Dim b_Not_In_Price As Boolean = True
                        Dim d_Price As Decimal = 0
                        Dim s_tTime As String = IIf(b_Fasdakleba_Moxda = 18, "diplomat", IIf(b_Fasdakleba_Moxda = 8, "restaurant", IIf(b_Fasdakleba_Moxda = 8, "discount_10p", String.Empty)))
                        Comm.CommandText = "SELECT * FROM dbo.price_list WHERE kodi='" & txt_kodi.Text & "'"
                        Comm.Connection = Conn
                        Try
                            Conn.Open()
                            Reader = Comm.ExecuteReader
                            While Reader.Read()
                                b_Not_In_Price = False
                                Dim b_Lock_Status1 As Boolean
                                If Not Reader.IsDBNull(5) Then
                                    b_Lock_Status1 = Reader.GetBoolean(5)
                                End If
                                If (b_From_Scanner Or (Not b_Lock_Status1)) Or (Scanner_N = 0) Then
                                    Dim i_Pozicia As Integer = f_Arsebulis_Pozicia(txt_kodi.Text)
                                    If i_Pozicia = -10 Then

                                        If M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(i_Pozicia).Cells(6).Value), Val(DGV_Sales.Rows(i_Pozicia).Cells(4).Value) + 1) Then
                                            DGV_Sales.Rows(i_Pozicia).Cells(4).Value = Val(DGV_Sales.Rows(i_Pozicia).Cells(4).Value) + 1
                                            DGV_Sales.Rows(i_Pozicia).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(i_Pozicia).Cells(3).Value) * Val(DGV_Sales.Rows(i_Pozicia).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
                                            d_Tanxa += Val(DGV_Sales.Rows(i_Pozicia).Cells(3).Value)
                                            Update_Monitor_Row(i_Pozicia, 4)
                                        Else
                                            Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                            Write_In_Log("Err_Ver_Gatarda: " & Check_Number & " - " & txt_kodi.Text)
                                        End If

                                    Else
                                        Dim b_Gaixsna As Boolean = False

                                        If DGV_Sales.Rows.Count = 0 Then
                                            Try
                                                If fp_daisy > 0 Then
                                                    If DaisyFP.NonFiscalDocIsOpen Then
                                                        DaisyFP.NonFiscalDocClose()
                                                    End If
                                                    If DaisyFP.FiscalDocIsOpen Then
                                                        DaisyFP.FiscalDocCancel()
                                                    End If
                                                    'If Not DaisyFP.PrintAllowed Then
                                                    '    DaisyFP.Dispose()
                                                    '    Throw New Exception("Print of document is not allowed")
                                                    'End If
                                                End If
                                            Catch ex As Exception
                                                Mesigi(ex.Message, ex.Source)
                                                DaisyFP.Dispose()
                                                If fp_daisy = 2 Then
                                                    txt_kodi.Text = ""
                                                    Exit Sub
                                                End If
                                            End Try

                                            If M_SQL.Open_Sale(Check_Number, sale_type, table_id, supervisor, guests) Then
                                                b_Gaixsna = True
                                            End If
                                        Else
                                            b_Gaixsna = True
                                        End If

                                        Dim d_Raodenoba As Double = 0
                                        If Not Reader.Item(4) Then
                                            d_Raodenoba = 1
                                        End If
                                        If b_Gaixsna Then
                                            d_Price = Reader.Item(3)
                                            If b_Fasdakleba_Moxda > 0 Then
                                                d_Price = Math.Round(d_Price / (1 + (b_Fasdakleba_Moxda * 0.01)), 2, MidpointRounding.AwayFromZero)
                                            End If
                                            Dim id As Integer = M_SQL.Do_SaleLines(Check_Number, Reader.Item(0), d_Raodenoba, d_Price, s_tTime)
                                            shemdegi()
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value = id

                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value = Reader.Item(0)
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(1).Value = Reader.Item(1)
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(2).Value = Reader.Item(2)
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value = d_Price
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                                            If Reader.Item(4) Then
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = 0
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = 0
                                                b_DGV_Sales_Focus = True
                                            Else
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = 1
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value
                                            End If
                                            a_WonisStatusebi.Add(Reader.Item(4))
                                            a_NulebisStatusebi.Add(1)
                                            a_TaxGroups.Add(Reader.Item(6))
                                            ''############### SaleLines-ში ჩაწერა
                                            'Dim s_Kodi As String
                                            'Dim d_Fasi As Double
                                            'Dim s_Ttime As String

                                            's_Kodi = DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value.ToString
                                            'd_Raodenoba = Val(DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value)
                                            'd_Fasi = Math.Round(Val(DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value), 2)
                                            's_Ttime = String.Empty
                                            'If DGV_Sales.Rows.Count = 1 Then
                                            '    M_SQL.Open_Sale(Check_Number)
                                            'End If
                                            'M_SQL.Do_SaleLines(Check_Number, s_Kodi, d_Raodenoba, d_Fasi, s_Ttime)
                                            ''###############
                                            d_Tanxa += Math.Round(d_Price * d_Raodenoba, 2, MidpointRounding.AwayFromZero)

                                            Add_Row_to_Monitor(DGV_Sales.Rows.Count - 1)

                                            If IsMenu(Reader.Item(0)) Then
                                                Dim name As String = DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(2).Value.ToString()
                                                FSaleSublines.Text = name + " - მენიუს შემადგენლობა"
                                                FSaleSublines.lblDescription.Text = M_SQL.GetDescription(Reader.Item(0))
                                                FSaleSublines.Left = DGV_Sales.Left + 2
                                                If (DGV_Sales.Rows.Count) * DGV_Sales.RowTemplate.Height < DGV_Sales.Parent.Height - FSaleSublines.Height Then
                                                    FSaleSublines.Top = DGV_Sales.Parent.Top + (DGV_Sales.Rows.Count) * DGV_Sales.RowTemplate.Height + DGV_Sales.ColumnHeadersHeight
                                                Else
                                                    FSaleSublines.Top = DGV_Sales.Parent.Top + (DGV_Sales.Rows.Count) * DGV_Sales.RowTemplate.Height + DGV_Sales.ColumnHeadersHeight - DGV_Sales.RowTemplate.Height - FSaleSublines.Height
                                                End If
                                                FSaleSublines.pId = Convert.ToInt32(DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value)
                                                FSaleSublines.Load_Sublines()
                                                FSaleSublines.Visible = True
                                            End If

                                        Else
                                            Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                            Write_In_Log("Err_Ver_Gatarda: " & Check_Number & " - " & txt_kodi.Text)

                                        End If
                                    End If
                                    's_Tanxa = f_Damrgvaleba(d_Tanxa).ToString("#####0.00")
                                    'Label_Tanxa.Text = s_Tanxa
                                    lbl_Tanxa.Text = Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero).ToString("#####0.00")
                                    txt_kodi.SelectedIndex = 0
                                    'txt_kodi.SelectedText = String.Empty
                                    'txt_kodi.Text = String.Empty
                                End If
                            End While
                            Reader.Close()
                            '_______________try as scale code
                            If b_Not_In_Price And (Mid(txt_kodi.Text, 1, 2) = "22" Or Mid(txt_kodi.Text, 1, 2) = "29") Then
                                Dim s_Code As String = Mid(txt_kodi.Text, 1, 7)
                                Dim i_raod As Integer = Val(Mid(txt_kodi.Text, 8, 5))
                                Comm.CommandText = "SELECT * FROM dbo.price_list WHERE kodi='" & s_Code & "'"
                                Reader = Comm.ExecuteReader
                                While Reader.Read()
                                    Dim b_Lock_Status2 As Boolean
                                    If Not Reader.IsDBNull(5) Then
                                        b_Lock_Status2 = Reader.GetBoolean(5)
                                    End If
                                    If (b_From_Scanner Or (Not b_Lock_Status2)) Or (Scanner_N = 0) Then
                                        Dim i_Pozicia2 As Integer = f_Arsebulis_Pozicia(s_Code)
                                        If i_Pozicia2 = -10 Then
                                            If Reader.Item(4) Then
                                                If M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(i_Pozicia2).Cells(6).Value), Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + i_raod / 1000) Then
                                                    DGV_Sales.Rows(i_Pozicia2).Cells(4).Value = Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + i_raod / 1000
                                                    DGV_Sales.Rows(i_Pozicia2).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value) * Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
                                                    d_Tanxa += Math.Round(Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value) * i_raod / 1000, 2, MidpointRounding.AwayFromZero)
                                                Else
                                                    Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                                    Write_In_Log("Err_Ver_Gatarda: " & Check_Number & " - " & txt_kodi.Text)
                                                End If
                                            Else
                                                If i_raod > 100 Then
                                                    If M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(i_Pozicia2).Cells(6).Value), Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + 1) Then
                                                        DGV_Sales.Rows(i_Pozicia2).Cells(4).Value = Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + 1
                                                        DGV_Sales.Rows(i_Pozicia2).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value) * Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
                                                        d_Tanxa += Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value)
                                                    Else
                                                        Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                                        Write_In_Log("Err_Ver_Gatarda: " & Check_Number & " - " & txt_kodi.Text)
                                                    End If
                                                Else
                                                    If M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(i_Pozicia2).Cells(6).Value), Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + i_raod) Then
                                                        DGV_Sales.Rows(i_Pozicia2).Cells(4).Value = Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + i_raod
                                                        DGV_Sales.Rows(i_Pozicia2).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value) * Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
                                                        d_Tanxa += Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value * i_raod)
                                                    Else
                                                        Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                                        Write_In_Log("Err_Ver_Gatarda: " & Check_Number & " - " & txt_kodi.Text)
                                                    End If
                                                End If
                                            End If
                                        Else

                                            Dim b_Gaixsna As Boolean = False

                                            If DGV_Sales.Rows.Count = 0 Then
                                                Try
                                                    If fp_daisy > 0 Then
                                                        If DaisyFP.NonFiscalDocIsOpen Then
                                                            DaisyFP.NonFiscalDocClose()
                                                        End If
                                                        If DaisyFP.FiscalDocIsOpen Then
                                                            DaisyFP.FiscalDocCancel()
                                                        End If
                                                        'If Not DaisyFP.PrintAllowed Then
                                                        '    DaisyFP.Dispose()
                                                        '    Throw New Exception("Print of document is not allowed")
                                                        'End If
                                                    End If
                                                Catch ex As Exception
                                                    Mesigi(ex.Message, ex.Source)
                                                    DaisyFP.Dispose()
                                                    If fp_daisy = 2 Then
                                                        txt_kodi.Text = ""
                                                        Exit Sub
                                                    End If
                                                End Try

                                                If M_SQL.Open_Sale(Check_Number, sale_type, table_id, supervisor, guests) Then
                                                    b_Gaixsna = True
                                                End If
                                            Else
                                                b_Gaixsna = True
                                            End If

                                            Dim d_Raodenoba As Double = 0
                                            If Reader.Item(4) Then
                                                d_Raodenoba = i_raod / 1000
                                            Else
                                                If i_raod > 100 Then
                                                    d_Raodenoba = 1
                                                Else
                                                    d_Raodenoba = i_raod
                                                End If
                                            End If
                                            d_Price = Reader.Item(3)
                                            If (b_Fasdakleba_Moxda > 0) Then
                                                d_Price = Math.Round(d_Price / (1 + (b_Fasdakleba_Moxda * 0.01)), 2, MidpointRounding.AwayFromZero)
                                            End If
                                            Dim id = M_SQL.Do_SaleLines(Check_Number, Reader.Item(0), d_Raodenoba, d_Price, String.Empty)
                                            If id > 0 Then

                                                shemdegi()
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value = id
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value = Reader.Item(0)
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(1).Value = Reader.Item(1)
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(2).Value = Reader.Item(2)
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value = d_Price
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                                                If Reader.Item(4) Then
                                                    DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = i_raod / 1000
                                                    DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Math.Round(i_raod * d_Price / 1000, 2, MidpointRounding.AwayFromZero)
                                                Else
                                                    If i_raod > 100 Then
                                                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = 1
                                                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = d_Price
                                                    Else
                                                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = i_raod
                                                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Math.Round(i_raod * d_Price, 2, MidpointRounding.AwayFromZero)
                                                    End If
                                                End If
                                                a_WonisStatusebi.Add(Reader.Item(4))
                                                a_NulebisStatusebi.Add(1)
                                                a_TaxGroups.Add(Reader.Item(6))
                                                ''############### SaleLines-ში ჩაწერა
                                                'Dim s_Kodi As String
                                                'Dim d_Fasi As Double
                                                'Dim s_Ttime As String

                                                's_Kodi = DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value.ToString
                                                'd_Raodenoba = Val(DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value)
                                                'd_Fasi = Math.Round(Val(DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value), 2)
                                                's_Ttime = String.Empty
                                                'If DGV_Sales.Rows.Count = 1 Then
                                                '    M_SQL.Open_Sale(Check_Number)
                                                'End If
                                                'M_SQL.Do_SaleLines(Check_Number, s_Kodi, d_Raodenoba, d_Fasi, s_Ttime)
                                                ''###############
                                                d_Tanxa += Math.Round(Val(DGV_Sales.Rows(DGV_Sales.SelectedCells(0).RowIndex).Cells(5).Value), 2, MidpointRounding.AwayFromZero)

                                                Add_Row_to_Monitor(DGV_Sales.Rows.Count - 1)
                                            Else
                                                Write_In_Log("Err_Ver_Gatarda: " & Check_Number & " - " & txt_kodi.Text)
                                                Mesigi("ვერ გატარდა, სცადეთ თავიდან")

                                            End If
                                        End If
                                        's_Tanxa = f_Damrgvaleba(d_Tanxa).ToString("#####0.00")
                                        'Label_Tanxa.Text = s_Tanxa
                                        lbl_Tanxa.Text = Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero).ToString("#####0.00")
                                        txt_kodi.SelectedIndex = 0
                                        'txt_kodi.SelectedText = String.Empty
                                        'txt_kodi.Text = String.Empty
                                    End If
                                End While
                                Reader.Close()
                            End If
                            If sale_type = 8 And DGV_Sales.RowCount = 1 Then
                                btnPrintBill.Visible = True
                                btnPrintOrder.Visible = True
                                btnNew.Visible = True
                                lbl_Gadasaxdeli.Spring = False
                                lbl_Gadasaxdeli.Width = 286
                                lbl_Gadasaxdeli.Spring = True
                            End If
                            '____________________________
                        Catch ex As Exception
                            Mesigi(ex.Message, "Err_CodeKeyDown_Enter:")
                            Write_In_Log("Err_CodeKeyDown_Enter: " & ex.Message + Environment.NewLine + ex.StackTrace)
                        Finally
                            Conn.Close()
                        End Try
                        If b_DGV_Sales_Focus Then
                            DGV_Sales.Focus()
                            Panel_Body.AutoScrollPosition = New System.Drawing.Point(0, DGV_Sales.SelectedCells(0).RowIndex * 22)
                        End If
                    Else
                        Mesigi("ჯერ დაასრულეთ მიმდინარე გაყიდვა", "შეცდომა")
                    End If
                Else
                    txt_kodi.SelectedIndex = 0
                    'txt_kodi.SelectedText = String.Empty
                    'txt_kodi.Text = String.Empty
                End If
                b_From_Scanner = False
            Case Keys.Up
                If Not txt_kodi.DroppedDown Then
                    If DGV_Sales.Rows.Count > 0 Then
                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                        DGV_Sales.Focus()
                        Panel_Body.AutoScrollPosition = New System.Drawing.Point(0, DGV_Sales.SelectedCells(0).RowIndex * 22)
                    End If
                End If
            Case Keys.Down
                If Not txt_kodi.DroppedDown Then
                    txt_kodi.SelectedIndex -= 1
                End If
            Case Keys.Escape
                If txt_kodi.DroppedDown Then
                    txt_kodi.DroppedDown = False
                Else
                    txt_kodi.SelectedIndex = 0
                End If
                'txt_kodi.SelectedText = String.Empty
                'txt_kodi.Text = String.Empty
            Case Keys.F2
                txt_kodi.SelectionStart = txt_kodi.Text.Length
                txt_kodi.SelectionLength = 0
        End Select
        If e.Control AndAlso e.KeyCode = Keys.Tab Then
            PicLogo.Focus()
            txt_Gad_Tan.Focus()
            txt_Gad_Tan.Text = "0.00"
            txt_Gad_Tan.SelectAll()
            'End If
            's_Tanxa = f_Damrgvaleba(d_Tanxa).ToString("#####0.00")
            'Label_Tanxa.Text = s_Tanxa
            lbl_Tanxa.Text = Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero).ToString("#####0.00")
            'TBXur.Text = (f_Damrgvaleba(d_Tanxa) - 2 * f_Damrgvaleba(d_Tanxa)).ToString("#####0.00")
            lbl_Gasacemi.Text = (Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero) - 2 * Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero)).ToString("#####0.00")
        End If
    End Sub

    Private Sub shemdegi()
        DGV_Sales.Rows.Add()
        Adjust_GridHeight()
        txt_kodi.Focus()
    End Sub

    Private Function f_Arsebulis_Pozicia(ByVal kod As String) As Integer
        Dim i_Count As Integer
        Dim ret_Val As Integer = -1
        If DGV_Sales.Rows.Count > 0 Then
            For i_Count = 0 To DGV_Sales.Rows.Count - 1
                If DGV_Sales.Rows(i_Count).Cells(0).Value = kod Then
                    ret_Val = i_Count
                    Exit For
                End If
            Next
        End If
        Return (ret_Val)
    End Function

    Private Sub txt_Gad_Tan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Gad_Tan.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Dim Flst As New Flist
                frmThumbs.Visible = False
                Flst.ShowDialog()
                Flst = Nothing
            Case Keys.Enter
                If DGV_Sales.Rows.Count > 0 Then
                    If Mid(lbl_SaleType.Text, 1, 6) <> "დაბრუნ" And Mid(lbl_SaleType.Text, 1, 6) <> "უნაღდო" And Not lbl_SaleType.Text.EndsWith("უნაღდო") Then
                        If IsNumeric(txt_Gad_Tan.Text) Then
                            If Val(txt_Gad_Tan.Text) >= Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero) Then
                                If Val(txt_Gad_Tan.Text) <= 10000 Then
                                    txt_Gad_Tan.Text = Val(txt_Gad_Tan.Text).ToString("#####0.00")
                                    lbl_Gasacemi.Text = (Val(txt_Gad_Tan.Text) - Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero)).ToString("#####0.00")
                                    End_Of_Sale()
                                Else
                                    txt_Gad_Tan.SelectAll()
                                End If
                            Else
                                txt_Gad_Tan.SelectAll()
                            End If
                        Else
                            txt_Gad_Tan.Clear()
                        End If
                    Else
                        txt_Gad_Tan.Clear()
                        lbl_Gasacemi.Text = String.Empty
                        End_Of_Sale()
                    End If
                End If
            Case Keys.Left
                txt_kodi.Focus()
            Case Keys.F2
                M_SQL.Update_MasterData()
        End Select
    End Sub

    Public Sub End_Of_Prebill(Optional ByVal sale_type As Integer = 7)
        Dim i_Count As Integer
        Dim i_RowCount As Integer = DGV_Sales.Rows.Count
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim d_Sum As Double
        For i_Count = 0 To i_RowCount - 1
            d_Sum += Val(DGV_Sales.Rows(i_Count).Cells(5).Value)
        Next
        If Math.Abs(Math.Round(d_Sum, 2, MidpointRounding.AwayFromZero) - Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero)) > 0.04 Then
            Mesigi("დათვლილი თანხა არასწორია, გთხოვთ შეამოწმოთ, მიმართეთ IT განყოფილებას", "შეცდომა")
            Write_In_Log("tanxa ar daitvala sworad" & Math.Round(d_Sum, 2, MidpointRounding.AwayFromZero) & "  " & Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero))
            Threading.Thread.Sleep(3000)
        End If

        If Mesigi("ნამდვილად გსურთ დაბეჭდოთ წინასწარი ქვითარი?", , True) Then
            If sale_type = 7 Then
                lbl_SaleType.Text = "წინასწარი ქვითარი"
            End If
            TranslateUI(Panel_Header, Fmain.UITerms)
            txt_kodi.SelectedIndex = 0
            '##### Check Parameters
            Dim d_Raodenobebi(i_RowCount - 1) As Double
            Dim d_Fasebi(i_RowCount - 1) As Double
            Dim s_Dasaxelebebi(i_RowCount - 1) As String
            Dim s_Kodebi(i_RowCount - 1) As String
            Dim b_Wonis(i_RowCount - 1) As Boolean
            '##### Sale Parameters
            Dim i_GadaxdisTipi As Short = 0
            If Mid(lbl_SaleType.Text, 1, 6) = "უნაღდო" Or lbl_SaleType.Text = "დაბრუნება უნაღდო" Then
                i_GadaxdisTipi = 1
            End If

            For i_Count = 0 To i_RowCount - 1
                s_Dasaxelebebi(i_Count) = DGV_Sales.Rows(i_Count).Cells(2).Value.ToString
                s_Kodebi(i_Count) = DGV_Sales.Rows(i_Count).Cells(0).Value.ToString
                d_Raodenobebi(i_Count) = Val(DGV_Sales.Rows(i_Count).Cells(4).Value)
                d_Fasebi(i_Count) = Val(DGV_Sales.Rows(i_Count).Cells(3).Value)
                b_Wonis(i_Count) = a_WonisStatusebi(i_Count)
            Next
            Try
                If sale_type = 8 And OrderedTable IsNot Nothing Then
                    M_SQL.Close_Sale(Check_Number, sale_type, Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero), i_GadaxdisTipi, False, OrderedTable.Id, OrderedTable.Supervisor, OrderedTable.Guests)
                Else
                    M_SQL.Close_Sale(Check_Number, sale_type, Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero), i_GadaxdisTipi)
                End If

            Catch ex As Exception
                Mesigi(IIf(UITerms.ContainsKey(ex.Message), CheckTermsValue(ex.Message), ex.Message), "Err_Close_Sale")
                Exit Sub
            End Try

            If fp_daisy = 2 And Printer_N = 0 Then
                If DaisyFP.PrintAllowed Then
                    Try
                        M_Daisy.Print_Prebill_Check(s_Dasaxelebebi, d_Raodenobebi, d_Fasebi)
                    Catch ex As Exception
                        Write_In_Log("Err Daisy FP print check: " & Check_Number.ToString() & " : " & ex.Message)
                        MessageBox.Show(ex.Message, "Fiscal Printer Error - Print fiscal doc", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        DaisyFP.Dispose()
                        Try
                            DaisyFP.NonFiscalDocClose()
                        Catch ex1 As Exception
                            Write_In_Log("Err Daisy FP cancel check: " & Check_Number.ToString() & " : " & ex1.Message)
                            MessageBox.Show(ex1.Message, "Fiscal Printer Error - Cancel fiscal doc", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            DaisyFP.Dispose()
                        End Try
                        Exit Sub
                    End Try
                Else
                    Mesigi("ფისკალურ პრინტერთან კავშირი არ არის. ოპერაციის განხორციელება შეუძლებელია") ', "გაფრთხილება", True, "გაფრთხილება", True) Then
                    Write_In_Log("Err Daisy FP print check: Closing check")
                    Exit Sub
                End If
            End If
            Try
                If Printer_N = 1 Then
                    b_Daibechda(0) = False
                    b_Daibechda(1) = False
                    b_Daibechda(2) = False
                    Do While (((b_Daibechda(0) And b_Daibechda(1)) And b_Daibechda(2)) = False)
                        PD.DocumentName = "check"
                        PD.Print()
                        Me.Refresh()
                    Loop
                End If
                Me.Refresh()
            Catch ex As Exception
                Mesigi(ex.Message, "Err_End_Sale_Wincor")
                Write_In_Log("Err_End_Sale_Wincor: " & ex.Message)
            End Try
            Try
                refresh_Form()
                If (Now - dt_Servertan_Kavshirisatvis).TotalMinutes > 45 Then
                    b_Servertan_Aris_Kavshiri = True
                End If
                M_Transfer.Do_Transfer()
                M_Z.Check_Z()
                'Automatic_Update()
                If Screen.AllScreens.Length > SecondaryMonitorIndex And SecondaryMonitorIndex > 0 Then
                    frmMonitorCheck.CloseEx()
                End If
            Catch ex As Exception
                Write_In_Log("Err_End_Sale_End: " & ex.Message)
            End Try
            dt_Last_Z_Time = Last_Z_Time()
            frmThumbs.ResetView()
        Else
            txt_kodi.SelectedIndex = 0
            txt_kodi.Focus()
        End If
    End Sub

    Public Function CheckPrinter() As Boolean
        Try
            If fp_daisy > 0 Then
                If DaisyFP.PrintAllowed Then
                    CheckPrinter = True
                    Return True
                Else
                    CheckPrinter = False
                    Return False
                End If
            End If
        Catch ex As Exception
            CheckPrinter = False
            Return False
        End Try

        CheckPrinter = True
        Return True
    End Function

    Public Sub End_Of_Sale(Optional ByVal confirm As Boolean = True)
        Dim i_Count As Integer
        Dim i_RowCount As Integer = DGV_Sales.Rows.Count
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim d_Sum As Double = 0.0
        For i_Count = 0 To i_RowCount - 1
            d_Sum += Val(DGV_Sales.Rows(i_Count).Cells(5).Value)
        Next
        If Math.Abs(Math.Round(d_Sum, 2, MidpointRounding.AwayFromZero) - Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero)) > 0.04 Then
            Mesigi("დათვლილი თანხა არასწორია, გთხოვთ შეამოწმოთ, მიმართეთ IT განყოფილებას", "შეცდომა")
            Write_In_Log("tanxa ar daitvala sworad" & Math.Round(d_Sum, 2, MidpointRounding.AwayFromZero) & "  " & Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero))
            Threading.Thread.Sleep(3000)
        End If
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        'გაყიდვა
        'გაყიდვა -18%
        'გაყიდვა -8%
        'უნაღდო გაყიდვა
        'უნაღდო გაყიდვა - 18%
        'უნაღდო გაყიდვა - 8%
        'დაბრუნება
        Dim confres As Boolean = True
        If confirm = True Then
            confres = Mesigi("გსურთ დაასრულოთ მიმდინარე " & IIf(Mid(lbl_SaleType.Text, 1, 6) = "დაბრუნ", "დაბრუნება?", IIf(lbl_SaleType.Text.StartsWith("შეკვეთა"), "შეკვეთა?", "გაყიდვა?")), , True, IIf(Mid(lbl_SaleType.Text, 1, 6) = "დაბრუნ", "დაბრუნება", IIf(lbl_SaleType.Text.StartsWith("შეკვეთა"), "შეკვეთა", "გაყიდვა")))
        End If

        If confirm = False Or confres = True Then
            If lbl_SaleType.Text.StartsWith("შეკვეთა") Then
                If lbl_SaleType.Text.EndsWith("უნაღდო") Then
                    lbl_SaleType.Text = "უნაღდო გაყიდვა"
                Else
                    lbl_SaleType.Text = "გაყიდვა"
                End If
            End If
            txt_kodi.SelectedIndex = 0
            '##### Check Parameters
            Dim d_Raodenobebi(i_RowCount - 1) As Double
            Dim d_Fasebi(i_RowCount - 1) As Double
            Dim s_Dasaxelebebi(i_RowCount - 1) As String
            Dim s_Kodebi(i_RowCount - 1) As String
            Dim b_Wonis(i_RowCount - 1) As Boolean
            Dim s_TaxGroups(i_RowCount - 1) As String
            Dim d_Fasdakleba As Double = 0
            '##### Sale Parameters
            Dim i_GadaxdisTipi As Short = 0
            If Mid(lbl_SaleType.Text, 1, 6) = "უნაღდო" Or lbl_SaleType.Text = "დაბრუნება უნაღდო" Then
                i_GadaxdisTipi = 1
            End If

            For i_Count = 0 To i_RowCount - 1
                s_Dasaxelebebi(i_Count) = DGV_Sales.Rows(i_Count).Cells(2).Value.ToString
                s_Kodebi(i_Count) = DGV_Sales.Rows(i_Count).Cells(0).Value.ToString
                d_Raodenobebi(i_Count) = Val(DGV_Sales.Rows(i_Count).Cells(4).Value)
                d_Fasebi(i_Count) = Val(DGV_Sales.Rows(i_Count).Cells(3).Value)
                b_Wonis(i_Count) = a_WonisStatusebi(i_Count)
                s_TaxGroups(i_Count) = IIf(lbl_SaleType.Text <> "საჩუქარი", "A", "B")
                's_TaxGroups(i_Count) = IIf(lbl_SaleType.Text <> "საჩუქარი" And a_TaxGroups(i_Count) <> 2, IIf(a_TaxGroups(i_Count) = 1, "A", IIf(a_TaxGroups(i_Count) = 3, "C", "D")), "B")
            Next
            If Mid(lbl_SaleType.Text, 1, 6) = "დაბრუნ" Then
                Try
                    M_SQL.Close_Sale(Check_Number, 5, Math.Round(-1 * d_Tanxa, 2, MidpointRounding.AwayFromZero), i_GadaxdisTipi, False)
                Catch ex As Exception
                    Mesigi(IIf(UITerms.ContainsKey(ex.Message), CheckTermsValue(ex.Message), ex.Message), "Err_Close_Sale")
                    Exit Sub
                End Try
            Else
                Try
                    If Not OrderedTable Is Nothing Then
                        M_SQL.Close_Sale(Check_Number, 1, Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero), i_GadaxdisTipi, False, OrderedTable.Id, OrderedTable.Supervisor, OrderedTable.Guests)
                    Else
                        M_SQL.Close_Sale(Check_Number, 1, Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero), i_GadaxdisTipi, False)
                    End If
                Catch ex As Exception
                    Mesigi(IIf(UITerms.ContainsKey(ex.Message), CheckTermsValue(ex.Message), ex.Message), "Err_Close_Sale")
                    Exit Sub
                End Try
            End If
            Try
                '********** უჯრის გაღება
                i_Count = 0
                If Drawer_N = 1 Then
                    If Mid(lbl_SaleType.Text, 1, 6) <> "უნაღდო" And lbl_SaleType.Text <> "დაბრუნება უნაღდო" Then
                        b_BoxIsOpen = True
                        Do While F_FP_SC_DR.DR.DrawerOpened = False And i_Count < 20
                            F_FP_SC_DR.DR.OpenDrawer()
                            i_Count += 1
                        Loop
                    End If
                ElseIf Drawer_N = 4 Then
                    If Mid(lbl_SaleType.Text, 1, 6) <> "უნაღდო" And lbl_SaleType.Text <> "დაბრუნება უნაღდო" Then
                        Do While F_NCR_CLS.NCRCashDrawer.DrawerOpened = False And i_Count < 20
                            If (i_Count < 4) Then
                                F_NCR_CLS.NCRCashDrawer.OpenDrawer()
                            End If
                            i_Count += 1
                            Threading.Thread.Sleep(100)
                        Loop
                    End If
                ElseIf Drawer_N = 5 And Mid(lbl_SaleType.Text, 1, 6) <> "უნაღდო" And lbl_SaleType.Text <> "დაბრუნება უნაღდო" Then
                    Dim port As New System.IO.Ports.SerialPort(Drawer_Name, 115200, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
                    port.Open()
                    port.Write("1")
                    port.Close()
                    port.Dispose()
                ElseIf Drawer_N = 6 And Mid(lbl_SaleType.Text, 1, 6) <> "უნაღდო" And lbl_SaleType.Text <> "დაბრუნება უნაღდო" Then
                    System.Diagnostics.Process.Start("wincdropener.exe")
                    System.Threading.Thread.Sleep(1000)
                ElseIf (Drawer_N = 11 Or Drawer_N = 12) And Mid(lbl_SaleType.Text, 1, 6) <> "უნაღდო" And lbl_SaleType.Text <> "დაბრუნება უნაღდო" Then
                    Dim wincDrawer As New WincorDrawerCtrl.Drawer()
                    Dim n As Integer = Drawer_N - 10
                    Dim wdev As Boolean = wincDrawer.OpenDevice()
                    If wdev = False Then
                        Mesigi("ფულის უჯრასთან კავშირი არ არის")
                    Else
                        Dim wdrw As Boolean = wincDrawer.OpenDrawer(n)
                        If wdrw = False Then
                            Mesigi("უჯრის გახსნისას მოხდა შეცდომა")
                        End If
                        wincDrawer.CloseDevice()
                    End If
                ElseIf Drawer_N = 20 And Mid(lbl_SaleType.Text, 1, 6) <> "უნაღდო" And lbl_SaleType.Text <> "დაბრუნება უნაღდო" Then
                    Dim drawerF As New PosiflexDrawerTest.DrawerForm()
                    drawerF.OpenDevice(Drawer_Name)
                    drawerF.OpenDrawer()
                    drawerF.CloseDevice()
                End If
                '*********************
            Catch ex As Exception
                Mesigi(ex.Message, "Err_End_Sale_DR")
                Write_In_Log("Err_End_Sale_DR: " & ex.Message)
            End Try

            If lbl_SaleType.Text = "დაბრუნება უნაღდო" Then
                If Not String.IsNullOrEmpty(BankTerminalId) And Math.Abs(d_Tanxa) > 0.001 Then
                    If frmCardPayPrompt.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If Not CheckPrinter() Then
                            Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                            Exit Sub
                        End If

                        Dim port As String = BankTerminalPort
                        Dim terminal As New eptcvx.Terminal(BankTerminalId)
                        terminal.PortInfo.PortName = BankTerminalPort
                        Dim term_res As String = terminal.Transaction((d_Tanxa * 100).ToString("000"), eptcvx.CardTransaction.Return)
                        BankTerminalData = terminal.ReceiptData

                        If Not String.IsNullOrEmpty(term_res) And Not String.IsNullOrEmpty(BankTerminalData) Then
                            If fp_daisy = 2 Then
                                M_Daisy.Print_Terminal_Response(BankTerminalData, "----ტერმინალით დაბრუნება----")
                            ElseIf Printer_N = 1 Then
                                Dim sep As String() = {"~0xDA^^"}
                                Dim receipts As String() = terminal.ReceiptData.Split(sep, StringSplitOptions.RemoveEmptyEntries)
                                For Each terminalData In receipts
                                    BankTerminalData = terminalData
                                    PD.DocumentName = "terminal_check"
                                    PD.Print()
                                Next
                            End If
                            BankTerminalData = String.Empty
                        End If

                        If Not String.IsNullOrEmpty(term_res) Then
                            Write_In_Log("Err terminal transaction: " & Check_Number.ToString() & " : " & term_res)
                            MessageBox.Show("ტერმინალით ტრანზაქციის განხორციელება შეუძლებელია" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - Card Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        If fp_daisy = 2 Then
                            M_Daisy.Print_Terminal_Response(BankTerminalData, "-----ტერმინალით გადახდა-----")
                        ElseIf Printer_N = 1 Then
                            PD.DocumentName = "terminal_check"
                            PD.Print()
                        End If
                        BankTerminalData = String.Empty
                    Else
                        BankTerminalData = String.Empty
                    End If
                End If
            End If

            Dim fiscal_docid As String = String.Empty

            If fp_daisy = 2 Then
                If DaisyFP.PrintAllowed Then
                    If Mid(lbl_SaleType.Text, 1, 6) <> "დაბრუნ" And lbl_SaleType.Text <> "საჩუქარი" Then
                        Try
                            M_Daisy.Print_Check(s_Dasaxelebebi, d_Raodenobebi, d_Fasebi, d_Fasdakleba, s_TaxGroups)
                        Catch ex As Exception
                            Write_In_Log("Err Daisy FP print check: " & Check_Number.ToString() & " : " & ex.Message & Environment.NewLine & ex.StackTrace & IIf(i_GadaxdisTipi = 1, Environment.NewLine & "TerminalData: " & BankTerminalData, ""))
                            MessageBox.Show(ex.Message, "Fiscal Printer Error - Print fiscal doc", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Try
                                DaisyFP.FiscalDocCancel()
                            Catch ex1 As Exception
                                Write_In_Log("Err Daisy FP cancel check: " & Check_Number.ToString() & " : " & ex1.Message & Environment.NewLine & ex.StackTrace)
                                MessageBox.Show(ex1.Message, "Fiscal Printer Error - Cancel fiscal doc", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                            DaisyFP.Dispose()
                            Exit Sub
                        End Try
                    ElseIf lbl_SaleType.Text = "დაბრუნება" Then
                        Try
                            DaisyFP.ServiceOutput(-d_Tanxa, "არაფისკალური დაბრუნება", "ქვითარი " + lbl_Check_N.Text.PadLeft(20, "."))
                        Catch ex2 As Exception
                            Write_In_Log("Err Daisy FP cancel check: " & ex2.Message)
                            MessageBox.Show(ex2.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            DaisyFP.Dispose()
                            Exit Sub
                        End Try
                    End If
                Else
                    Mesigi("ფისკალურ პრინტერთან კავშირი არ არის. ოპერაციის განხორციელება შეუძლებელია") ', "გაფრთხილება", True, "გაფრთხილება", True) Then
                    Write_In_Log("Err Daisy FP print check: Closing check")
                    Exit Sub
                End If
            End If

            If Mid(lbl_SaleType.Text, 1, 6) = "დაბრუნ" Then
                Try
                    M_SQL.Update_CloseStatus(Check_Number, True, Math.Round(-1 * d_Tanxa, 2, MidpointRounding.AwayFromZero), fiscal_docid)
                Catch ex As Exception
                    Mesigi(ex.Message, "Err_Update_CloseStatus")
                    Exit Sub
                End Try
            Else
                Try
                    M_SQL.Update_CloseStatus(Check_Number, True, d_Tanxa, fiscal_docid)
                Catch ex As Exception
                    Mesigi(ex.Message, "Err_Update_CloseStatus")
                    Exit Sub
                End Try
            End If

            Try
                If fp_daisy = 1 Then
                    If Mid(lbl_SaleType.Text, 1, 6) <> "დაბრუნ" And lbl_SaleType.Text <> "საჩუქარი" Then
                        M_Daisy.Print_Check("#: " + lbl_Check_N.Text, 1, d_Tanxa, 0, "A")
                    ElseIf lbl_SaleType.Text = "დაბრუნება" Then
                        DaisyFP.ServiceOutput(-d_Tanxa, "არაფისკალური დაბრუნება", "ქვითარი " + lbl_Check_N.Text.PadLeft(20, "."))
                    End If
                End If

                If Fiscal_N = 1 Then
                    F_FP_SC_DR.Open_Check(lbl_SaleType.Text)
                    F_FP_SC_DR.Print_Check(s_Dasaxelebebi, s_Kodebi, d_Raodenobebi, d_Fasebi, b_Wonis, d_Fasdakleba)
                    F_FP_SC_DR.Close_Check(i_GadaxdisTipi, Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero), Val(txt_Gad_Tan.Text))
                ElseIf Fiscal_N = 2 Then
                    'SLP Check detal
                    If Mid(lbl_SaleType.Text, 1, 6) = "დაბრუნ" Then
                        RestoreStock_SLP("გაყიდული საქონლის დაბრუნება", 1, d_Tanxa)
                    Else
                        M_SLP.CheckItem_SLP(s_Dasaxelebebi, d_Raodenobebi, d_Fasebi)
                        M_SLP.Close_Check_SLP(i_GadaxdisTipi, Val(txt_Gad_Tan.Text))
                    End If
                ElseIf Fiscal_N = 3 Then
                    'SLP Check not detal
                    If Mid(lbl_SaleType.Text, 1, 6) = "დაბრუნ" Then
                        RestoreStock_SLP("გაყიდული საქონლის დაბრუნება", 1, d_Tanxa)
                    Else
                        Dim s_dasax(0) As String
                        Dim d_raoden(0) As Double
                        Dim d_faseb(0) As Double
                        s_dasax(0) = "შენაძენის ერთიანი თანხა"
                        d_raoden(0) = 1
                        d_faseb(0) = d_Tanxa
                        M_SLP.CheckItem_SLP(s_dasax, d_raoden, d_faseb)
                        M_SLP.Close_Check_SLP(i_GadaxdisTipi, Val(txt_Gad_Tan.Text))
                    End If
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_End_Sale_Fiscal")
                Write_In_Log("Err_End_Sale_Fiscal: " & ex.Message)
            End Try
            Try
                '%%%%%%%%%%%%%%%%%%% Wincor-ის ჩეკი
                If Fiscal_N = 2 Or Fiscal_N = 3 Then
                    Threading.Thread.Sleep(500)
                Else
                    Threading.Thread.Sleep(1500)
                End If
                If Printer_N = 1 Then
                    b_Daibechda(0) = False
                    b_Daibechda(1) = False
                    b_Daibechda(2) = False
                    Do While (((b_Daibechda(0) And b_Daibechda(1)) And b_Daibechda(2)) = False)
                        PD.DocumentName = "check"
                        PD.Print()
                        Me.Refresh()
                    Loop
                End If
                Me.Refresh()
                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            Catch ex As Exception
                Mesigi(ex.Message, "Err_End_Sale_Wincor")
                Write_In_Log("Err_End_Sale_Wincor: " & ex.Message)
            End Try

            Try
                '********** უჯრის დალოდება
                If Drawer_N = 1 Then
                    If F_FP_SC_DR.DR.DrawerOpened Then
                        Do While F_FP_SC_DR.DR.DrawerOpened
                            Threading.Thread.Sleep(300)
                        Loop
                    End If
                    b_BoxIsOpen = False
                ElseIf Drawer_N = 4 Then
                    Do While F_NCR_CLS.NCRCashDrawer.DrawerOpened
                        Threading.Thread.Sleep(300)
                    Loop
                End If
                '************************
            Catch ex As Exception
                Mesigi(ex.Message, "Err_End_Sale_DRwait")
                Write_In_Log("Err_End_Sale_RDwait: " & ex.Message)
            End Try
            Try
                ReturnFiscalDocId = String.Empty
                OrderedTable = Nothing
                refresh_Form()
                If (Now - dt_Servertan_Kavshirisatvis).TotalMinutes > 45 Then
                    b_Servertan_Aris_Kavshiri = True
                End If
                M_Transfer.Do_Transfer()
                M_Z.Check_Z()
                'Automatic_Update()
                If Screen.AllScreens.Length > SecondaryMonitorIndex And SecondaryMonitorIndex > 0 Then
                    frmMonitorCheck.CloseEx()
                End If
            Catch ex As Exception
                Write_In_Log("Err_End_Sale_End: " & ex.Message)
            End Try
            dt_Last_Z_Time = Last_Z_Time()
            frmThumbs.ResetView()

            'GCAnator.AdvancedGC.Collect()
        Else
            txt_kodi.SelectedIndex = 0
            txt_kodi.Focus()
        End If
    End Sub

    Private Sub PD_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.BeginPrint
        b_Daibechda(0) = Not (e.Cancel)
    End Sub
    Private Sub PD_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.EndPrint
        b_Daibechda(2) = Not (e.Cancel)
    End Sub

    Public Sub Init_Z_Appx(ByVal XorZ As String)
        Try
            Dim sCashSum As Double = 0
            Dim sCardSum As Double = 0
            Dim rCashSum As Double = 0
            Dim rCardSum As Double = 0
            Dim pBillSum As Double = 0

            Dim Conn1 As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
            Dim Comm1 As New System.Data.SqlClient.SqlCommand("SELECT isnull(Sum(check_amount),0), sale_type, payment_type FROM pos_sales WHERE check_n>(SELECT Max(check_n) FROM pos_sales WHERE sale_type=6) GROUP BY sale_type, payment_type ORDER BY sale_type, payment_type", Conn1)
            Dim Read1 As System.Data.SqlClient.SqlDataReader
            Conn1.Open()
            Read1 = Comm1.ExecuteReader
            While Read1.Read
                If Read1.Item(1) = 1 Then
                    If Read1.Item(2) = 0 Then
                        'გაყიდვა
                        sCashSum = Val(Read1.Item(0))
                    ElseIf Read1.Item(2) = 1 Then
                        'გაყიდვა უნაღდო
                        sCardSum = Val(Read1.Item(0))
                    End If
                ElseIf Read1.Item(1) = 5 Then
                    If Read1.Item(2) = 0 Then
                        'დაბრუნება
                        rCashSum = Val(Read1.Item(0))
                    ElseIf Read1.Item(2) = 1 Then
                        'დაბრუნება უნაღდო
                        rCardSum = Val(Read1.Item(0))
                    End If
                ElseIf Read1.Item(1) = 7 Then
                    pBillSum = Val(Read1.Item(0))
                End If
            End While
            Read1.Close()
            Conn1.Close()
            If fp_daisy <> 2 Then
                F_FP_SC_DR.Open_Fiscal()
                F_FP_SC_DR.Open_Check("Z_Appx")
                F_FP_SC_DR.Print_Z_Appx(XorZ, sCashSum, sCardSum, rCashSum, rCardSum)
            Else
                M_Daisy.Print_Z_Appx(XorZ, sCashSum, sCardSum, -1 * Math.Abs(rCashSum), -1 * Math.Abs(rCardSum), 0, 0, 0, pBillSum)
            End If
        Catch ex As Exception
            Mesigi(ex.Message, "Err_PrintPage_" + XorZ + "_Appx")
            Write_In_Log("Err_PrintPage_" + XorZ + "_Appx: " + ex.Message + Environment.NewLine + ex.StackTrace)
        End Try

    End Sub

    Public Function UITermsValue(ByVal a As String) As String
        Dim b As String = a
        If UITerms.ContainsKey(a) Then
            b = UITerms(a)
        End If
        UITermsValue = b
        Return b
    End Function

    Public Function CheckTermsValue(ByVal a As String) As String
        Dim b As String = a
        If CheckTerms.ContainsKey(a) Then
            b = CheckTerms(a)
        End If
        CheckTermsValue = b
        Return b
    End Function

    Private Sub PD_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PD.PrintPage
        Try
            Dim FontBD As New Font("Sylfaen", 15, FontStyle.Bold)
            Dim FontBP As New Font("Sylfaen", 12, FontStyle.Bold)
            Dim FontND As New Font("Sylfaen", 10)
            Dim FontNP As New Font("Sylfaen", 9)
            Dim FontMS As New Font("Sylfaen", 8, FontStyle.Bold)
            Dim FontTS As New Font("Sylfaen", 8)
            Dim FontXS As New Font(FontNP.FontFamily, 6, FontNP.Style)
            Dim FontHB As New Font("Sylfaen", 10, FontStyle.Bold)
            Dim FontTB As New Font(FontTS.FontFamily, 8, FontStyle.Bold)
            Dim FontTC As New Font("Courier New", 8)

            Dim marginL As Integer = 4
            Dim marginR As Integer = 286
            Dim vShift As Integer = 12

            Dim CompanyNameSize = e.Graphics.MeasureString(Company_Name, FontBD)
            e.Graphics.DrawString(Company_Name, FontBD, Brushes.Black, (marginR - CompanyNameSize.Width) / 2, 1)
            If Not String.IsNullOrEmpty(Company_Line) Then
                Dim companyLineWidth As Integer = e.Graphics.MeasureString(Company_Line, FontMS).Width
                e.Graphics.DrawString(Company_Line, FontMS, Brushes.Black, (marginR - companyLineWidth) / 2, CompanyNameSize.Height - 5)
            End If
            If PD.DocumentName <> "order" Then
                e.Graphics.DrawString(IIf(UITerms.ContainsKey("მისამართი:"), CheckTermsValue("მისამართი:"), "მისამართი:") + " " + Market_Address, FontND, Brushes.Black, 2, 32 + vShift)
            ElseIf OrderedTable IsNot Nothing Then
                e.Graphics.DrawString(IIf(UITerms.ContainsKey("სტუმრების რაოდენობა:"), CheckTermsValue("სტუმრების რაოდენობა:"), "სტუმრების რაოდენობა:") + " " + OrderedTable.Guests.ToString(), FontND, Brushes.Black, 2, 32 + vShift)
            End If
            e.Graphics.DrawString(IIf(UITerms.ContainsKey("ქვითარი #:"), CheckTermsValue("ქვითარი #:"), "ქვითარი #:") + " " + lbl_Check_N.Text, FontND, Brushes.Black, 2, 54 + vShift)
            e.Graphics.DrawString(IIf(UITerms.ContainsKey("თარიღი:"), CheckTermsValue("თარიღი:"), "თარიღი:") + " " + Now, FontND, Brushes.Black, 2, 76 + vShift)
            If Not lbl_SaleType.Text.StartsWith("შეკვეთა") And OrderedTable Is Nothing Then
                e.Graphics.DrawString(IIf(UITerms.ContainsKey("მოლარე:"), CheckTermsValue("მოლარე:"), "მოლარე:") + " " + p_Person.Name, FontND, Brushes.Black, 2, 98 + vShift)
            ElseIf OrderedTable IsNot Nothing And Not String.IsNullOrEmpty(OrderedTable.Supervisor) Then
                e.Graphics.DrawString(IIf(UITerms.ContainsKey("სუპერვაიზერი:"), CheckTermsValue("სუპერვაიზერი:"), "სუპერვაიზერი:") + " " + OrderedTable.Supervisor, FontND, Brushes.Black, 2, 98 + vShift)
            End If
            'e.Graphics.DrawImage(MyImageList.Images(0), 206, 1)
            Dim k As Integer = 144 + vShift
            If PD.DocumentName = "Z" Or PD.DocumentName = "X" Then
                e.Graphics.DrawString("**** " + PD.DocumentName + " " + IIf(UITerms.ContainsKey("ანგარიში"), CheckTermsValue("ანგარიში"), "ანგარიში") + " ****", FontHB, Brushes.Black, 75, 118 + vShift)
                e.Graphics.DrawLine(Pens.Black, marginL, 142 + vShift, marginR, 142 + vShift)
                e.Graphics.DrawLine(Pens.Black, marginL, 144 + vShift, marginR, 144 + vShift)
                Dim Conn1 As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
                Dim Comm1 As New System.Data.SqlClient.SqlCommand("SELECT Sum(check_amount), sale_type, payment_type, count(*) as rcts FROM pos_sales WHERE check_n>(SELECT Max(check_n) FROM pos_sales WHERE sale_type=6) GROUP BY sale_type, payment_type ORDER BY sale_type, payment_type", Conn1)
                Dim Read1 As System.Data.SqlClient.SqlDataReader
                Conn1.Open()
                Read1 = Comm1.ExecuteReader
                Dim d_Rct As Integer = 0
                Dim d_Sum As Double = 0
                While Read1.Read
                    If Read1.Item(1) = 1 Then
                        If Read1.Item(2) = 0 Then
                            'გაყიდვა
                            k += 17
                            e.Graphics.DrawString(IIf(UITerms.ContainsKey("გაყიდვა"), CheckTermsValue("გაყიდვა"), "გაყიდვა"), FontND, Brushes.Black, 2, k)
                            e.Graphics.DrawString(Val(Read1.Item(0)).ToString("#####0.00") + " " + IIf(UITerms.ContainsKey("₾"), CheckTermsValue("₾"), "₾"), FontND, Brushes.Black, 160, k)
                            d_Sum += Read1.Item(0)
                            d_Rct += Read1.Item(3)
                        ElseIf Read1.Item(2) = 1 Then
                            'გაყიდვა უნაღდო
                            k += 17
                            e.Graphics.DrawString(IIf(UITerms.ContainsKey("გაყიდვა უნაღდო"), CheckTermsValue("გაყიდვა უნაღდო"), "გაყიდვა უნაღდო"), FontND, Brushes.Black, 2, k)
                            e.Graphics.DrawString(Val(Read1.Item(0)).ToString("#####0.00") + " " & IIf(UITerms.ContainsKey("₾"), CheckTermsValue("₾"), "₾"), FontND, Brushes.Black, 160, k)
                            d_Sum += Read1.Item(0)
                            d_Rct += Read1.Item(3)
                        End If
                    ElseIf Read1.Item(1) = 5 Then
                        If Read1.Item(2) = 0 Then
                            'დაბრუნება
                            k += 17
                            e.Graphics.DrawString(IIf(UITerms.ContainsKey("დაბრუნება"), CheckTermsValue("დაბრუნება"), "დაბრუნება"), FontND, Brushes.Black, 2, k)
                            e.Graphics.DrawString(Val(Read1.Item(0)).ToString("#####0.00") + " " + IIf(UITerms.ContainsKey("₾"), CheckTermsValue("₾"), "₾"), FontND, Brushes.Black, 160, k)
                            d_Sum += -1 * Math.Abs(Read1.Item(0))
                            If (Read1.Item(3) <= d_Rct) Then
                                d_Rct -= Read1.Item(3)
                            End If
                        ElseIf Read1.Item(2) = 1 Then
                            'დაბრუნება უნაღდო
                            k += 17
                            e.Graphics.DrawString(IIf(UITerms.ContainsKey("დაბრუნება უნაღდო"), CheckTermsValue("დაბრუნება უნაღდო"), "დაბრუნება უნაღდო"), FontND, Brushes.Black, 2, k)
                            e.Graphics.DrawString(Val(Read1.Item(0)).ToString("#####0.00") + " " + IIf(UITerms.ContainsKey("₾"), CheckTermsValue("₾"), "₾"), FontND, Brushes.Black, 160, k)
                            d_Sum += -1 * Math.Abs(Read1.Item(0))
                            If (Read1.Item(3) <= d_Rct) Then
                                d_Rct -= Read1.Item(3)
                            End If
                        End If
                    End If
                End While
                Read1.Close()
                Conn1.Close()
                e.Graphics.DrawString(IIf(UITerms.ContainsKey("ჯამი"), CheckTermsValue("ჯამი"), "ჯამი"), FontHB, Brushes.Black, 2, k + 19)
                e.Graphics.DrawString(d_Sum.ToString("#####0.00") + " " + IIf(UITerms.ContainsKey("₾"), CheckTermsValue("₾"), "₾"), FontHB, Brushes.Black, 160, k + 19)
                k += 19
                e.Graphics.DrawString(IIf(UITerms.ContainsKey("ჩეკები"), CheckTermsValue("ჩეკები"), "ჩეკები"), FontHB, Brushes.Black, 2, k + 19)
                e.Graphics.DrawString(d_Rct.ToString("#####0"), FontHB, Brushes.Black, 160, k + 19)
            ElseIf PD.DocumentName = "terminal_check" Then
                Dim source = BankTerminalData
                If Not String.IsNullOrEmpty(source) Then
                    Dim sep As String() = {"@#$%"}
                    Dim src As String = source.Replace(Environment.NewLine, Environment.NewLine + sep(0))
                    Dim lines As String() = src.Split(sep, StringSplitOptions.RemoveEmptyEntries)
                    k += vShift
                    e.Graphics.DrawString("----------TBC Bank----------", FontTC, Brushes.Black, 2, k)
                    If lines.Length > 3 Then
                        Dim u As Integer = lines.Length - 2
                        Dim si As String = String.Empty
                        For j As Integer = lines.Length - 2 To 0 Step -1
                            si += lines(j).Trim()
                            If Not String.IsNullOrEmpty(si) Then
                                u = j
                                Exit For
                            End If
                        Next j

                        For i As Integer = 1 To u
                            Dim stri As String = lines(i)
                            If stri.StartsWith("ბარათის მფლობელი:") Then
                                stri = stri.Replace("ბარათის მფლობელი:", "").Trim()
                                k += vShift
                                e.Graphics.DrawString("ბარათის მფლობელი:", FontTC, Brushes.Black, 2, k)
                            Else
                                Dim length As Integer = 28
                                Dim spacePos As Integer
                                spacePos = stri.IndexOf("   ")
                                If stri.StartsWith("ჯამი") And stri.Contains("") Then
                                    stri = stri.Replace("", "₾")
                                End If
                                If (spacePos > 1) Then
                                    Dim before = stri.Substring(0, spacePos).Trim()
                                    Dim after = stri.Replace(before, "").Trim()
                                    If Not String.IsNullOrEmpty(after) Then
                                        stri = before + after.PadLeft(length - before.Length, " ")
                                    Else
                                        stri = before
                                    End If
                                Else
                                    Dim sourceTrm = stri.Trim()
                                    If sourceTrm.Length > length Then
                                        sourceTrm = stri.Substring(0, length).Trim()
                                    End If
                                    Dim spaces As Integer = length - sourceTrm.Length
                                    Dim padLeft As Integer = spaces / 2 + sourceTrm.Length

                                    stri = sourceTrm.PadLeft(padLeft)
                                End If
                            End If
                            If stri.Trim() = "~0xDA^^" Then
                                k += vShift
                                e.Graphics.DrawString("----------TBC Bank----------", FontTC, Brushes.Black, 2, k)
                                k += vShift
                                e.Graphics.DrawString("", FontTC, Brushes.Black, 2, k)
                            Else
                                k += vShift
                                e.Graphics.DrawString(stri, FontTC, Brushes.Black, 2, k)
                            End If
                        Next i
                        k += vShift
                        e.Graphics.DrawString("", FontTC, Brushes.Black, 2, k)
                    End If
                End If
            Else
                If DGV_Sales.Rows.Count > 0 Then
                    Dim stypetext As String = String.Empty
                    Dim local_vat_sub As Decimal = 1 'vat_sub
                    If b_Fasdakleba_Moxda = 18 Then
                        local_vat_sub = 1
                    End If
                    If lbl_SaleType.Text.StartsWith("შეკვეთა") And PD.DocumentName <> "order" Then
                        stypetext = "**** " + CheckTermsValue("წინასწარი ქვითარი") + " ****"
                    ElseIf PD.DocumentName = "order" Or OrderedTable IsNot Nothing Then
                        stypetext = "**** " + CheckTermsValue(lbl_SaleType.Text.Replace("გაყიდვა", "გადახდა")) + " ****"
                    Else
                        stypetext = "**** " + CheckTermsValue(lbl_SaleType.Text) + " ****"
                    End If
                    Dim stypesize = e.Graphics.MeasureString(stypetext, FontHB)
                    e.Graphics.DrawString(stypetext, FontHB, Brushes.Black, (marginR - stypesize.Width) / 2, 132 + vShift)

                    e.Graphics.DrawLine(Pens.Black, marginL, 156 + vShift, marginR, 156 + vShift)
                    e.Graphics.DrawLine(Pens.Black, marginL, 158 + vShift, marginR, 158 + vShift)
                    If PD.DocumentName = "order" Then
                        e.Graphics.DrawString(IIf(UITerms.ContainsKey("დასახელება                                 რაოდენობა"), CheckTermsValue("დასახელება                             რაოდენობა"), "დასახელება                             რაოდენობა"), FontHB, Brushes.Black, 2, 158 + vShift)
                    Else
                        e.Graphics.DrawString(IIf(UITerms.ContainsKey("დასახელება       რაოდ       ფასი       თანხა"), CheckTermsValue("დასახელება       რაოდ       ფასი       თანხა"), "დასახელება       რაოდ       ფასი       თანხა"), FontHB, Brushes.Black, 2, 158 + vShift)
                    End If
                    e.Graphics.DrawLine(Pens.Black, marginL, 180 + vShift, marginR, 180 + vShift)
                    Dim j As Integer = 164 + vShift
                    Using conn As New SqlClient.SqlConnection(LOCAL_CONN_STR)
                        Using comm As New SqlClient.SqlCommand
                            comm.Connection = conn
                            comm.CommandType = CommandType.Text
                            comm.CommandText = "select p.code printer_name from ItemGroups g inner join itemgroup_printers gp on g.itmgID = gp.itmg_id inner join receipt_printers p on gp.printer_id = p.id where g.itmgNAME = @group_name"
                            comm.Parameters.Add("@group_name", SqlDbType.NVarChar, 100)
                            If PD.DocumentName = "order" Then
                                conn.Open()
                            End If
                            Dim groupName As String = String.Empty
                            Dim groupWidth As Integer = 0
                            Dim rows_dictionary As New Dictionary(Of String, GridItemInfo)

                            For i As Integer = 0 To DGV_Sales.Rows.Count - 1
                                If DGV_Sales.Rows(i).Cells(4).Value <> 0 Then
                                    If PD.DocumentName = "order" Then
                                        If DGV_Sales.Rows(i).Cells(7).Value = True Then
                                            Continue For
                                        End If
                                        If groupName <> DGV_Sales.Rows(i).Cells(1).Value.ToString() Then
                                            groupName = DGV_Sales.Rows(i).Cells(1).Value.ToString()
                                        End If
                                        If i > 0 Then
                                            If DGV_Sales.Rows(i - 1).DividerHeight > 0 Then
                                                j += 15
                                                groupWidth = 0 ' e.Graphics.MeasureString(groupName, FontXS).Width
                                                e.Graphics.DrawLine(Pens.Black, marginL, j + 6, Convert.ToInt32((marginR - groupWidth) / 2), j + 6)
                                                'e.Graphics.DrawString(groupName, FontXS, Brushes.Black, (marginR - groupWidth) / 2, j)
                                                e.Graphics.DrawLine(Pens.Black, Convert.ToInt32((marginR - groupWidth) / 2 + groupWidth), j + 6, marginR, j + 6)
                                            End If
                                        End If
                                        comm.Parameters("@group_name").Value = groupName

                                        Dim printers As New List(Of String)
                                        Using reader As SqlClient.SqlDataReader = comm.ExecuteReader()
                                            While reader.Read()
                                                If Not printers.Contains(reader.Item("printer_name").ToString()) Then
                                                    printers.Add(reader.Item("printer_name").ToString())
                                                End If
                                            End While
                                        End Using

                                        If printers.Count = 0 Then
                                            If PD.PrinterSettings.PrinterName <> printerSettings.PrinterName Then
                                                Continue For
                                            End If
                                        Else
                                            If Not printers.Contains(PD.PrinterSettings.PrinterName) Then
                                                Continue For
                                            End If
                                        End If
                                        j += 15
                                        e.Graphics.DrawString(DGV_Sales.Rows(i).Cells(2).Value, FontNP, Brushes.Black, 2, j)
                                        e.Graphics.DrawString(DGV_Sales.Rows(i).Cells(4).Value, FontNP, Brushes.Black, 264, j + 15)
                                        j += 15
                                        e.Graphics.DrawString(DGV_Sales.Rows(i).Cells(0).Value, FontXS, Brushes.Black, 2, j)
                                    Else
                                        If Not rows_dictionary.ContainsKey(DGV_Sales.Rows(i).Cells(0).Value) Then
                                            rows_dictionary.Add(DGV_Sales.Rows(i).Cells(0).Value, New GridItemInfo With {.Name = DGV_Sales.Rows(i).Cells(2).Value,
                                                                .Quantity = Val(DGV_Sales.Rows(i).Cells(4).Value),
                                                                .Price = Val(DGV_Sales.Rows(i).Cells(3).Value) * local_vat_sub,
                                                                .Amount = Math.Round(Val(DGV_Sales.Rows(i).Cells(4).Value) * Val(DGV_Sales.Rows(i).Cells(3).Value) * local_vat_sub, 2, MidpointRounding.AwayFromZero)
                                                                })
                                        Else
                                            rows_dictionary(DGV_Sales.Rows(i).Cells(0).Value).Quantity += Val(DGV_Sales.Rows(i).Cells(4).Value)
                                            rows_dictionary(DGV_Sales.Rows(i).Cells(0).Value).Amount = Math.Round(rows_dictionary(DGV_Sales.Rows(i).Cells(0).Value).Quantity * rows_dictionary(DGV_Sales.Rows(i).Cells(0).Value).Price, 2, MidpointRounding.AwayFromZero)
                                        End If
                                    End If
                                End If
                            Next
                            If PD.DocumentName <> "order" Then
                                Dim namestring As String
                                Dim calcstring As String
                                Dim amountString As String
                                Dim namewidth As Integer
                                Dim calcwidth As Integer
                                Dim amountWidth As Integer

                                For Each kvp In rows_dictionary
                                    namestring = kvp.Value.Name
                                    namewidth = e.Graphics.MeasureString(namestring, FontNP).Width
                                    calcstring = kvp.Value.Quantity.ToString() + " x " + kvp.Value.Price.ToString("#####0.00") + " = "
                                    calcwidth = e.Graphics.MeasureString(calcstring, FontTS).Width
                                    amountString = kvp.Value.Amount.ToString("#####0.00")
                                    amountWidth = e.Graphics.MeasureString(amountString, FontNP).Width
                                    j += 15
                                    e.Graphics.DrawString(kvp.Value.Name, FontNP, Brushes.Black, 2, j)
                                    If namewidth + calcwidth + amountWidth + 4 > marginR Then
                                        j += 15
                                    End If
                                    'e.Graphics.DrawString(kvp.Key, FontNP, Brushes.Black, 2, j)
                                    e.Graphics.DrawString(calcstring, FontTS, Brushes.Black, marginR - calcwidth - amountWidth - 2, j + 1)
                                    e.Graphics.DrawString(amountString, FontNP, Brushes.Black, marginR - amountWidth, j)
                                    'e.Graphics.DrawString("*", FontNP, Brushes.Black, 159, j)
                                    'e.Graphics.DrawString(kvp.Value.Quantity.ToString(), FontNP, Brushes.Black, 176, j)
                                    'e.Graphics.DrawString("=", FontNP, Brushes.Black, 221, j)
                                    'e.Graphics.DrawString(kvp.Value.Amount.ToString("#####0.00"), FontNP, Brushes.Black, 244, j)
                                Next
                            End If
                        End Using
                    End Using
                    If PD.DocumentName <> "order" Then
                        e.Graphics.DrawLine(Pens.Black, marginL, j + 20, marginR, j + 20)
                        Dim sumtext As String = IIf(UITerms.ContainsKey("ჯამი"), CheckTermsValue("ჯამი"), "ჯამი") + "         " + (d_Tanxa * local_vat_sub).ToString("#####0.00") + " " + IIf(UITerms.ContainsKey("₾"), CheckTermsValue("₾"), "₾")
                        'Dim vattext As String = IIf(UITerms.ContainsKey("დღგ"), CheckTermsValue("დღგ"), "დღგ") + "         " + (d_Tanxa * (1 - local_vat_sub)).ToString("#####0.00") + " " + IIf(UITerms.ContainsKey("₾"), CheckTermsValue("₾"), "₾")
                        Dim paytext As String = IIf(UITerms.ContainsKey("სულ გადასახდელი"), CheckTermsValue("სულ გადასახდელი"), "სულ გადასახდელი") + "     " + d_Tanxa.ToString("#####0.00") + " " + IIf(UITerms.ContainsKey("₾"), CheckTermsValue("₾"), "₾")
                        Dim vatIncludedText As String = "*" + IIf(UITerms.ContainsKey("თანხა მოიცავს დღგ-ს"), CheckTermsValue("თანხა მოიცავს დღგ-ს"), "თანხა მოიცავს დღგ-ს")
                        Dim sumtextsize = e.Graphics.MeasureString(sumtext, FontTB)
                        'Dim vattextsize = e.Graphics.MeasureString(vattext, FontTB)
                        Dim paytextsize = e.Graphics.MeasureString(paytext, FontHB)
                        Dim vatIncludedTextSize = e.Graphics.MeasureString(vatIncludedText, FontTB)
                        j += 22
                        e.Graphics.DrawString(sumtext, FontTB, Brushes.Black, marginR - sumtextsize.Width - 6, j)
                        'j += 15
                        'e.Graphics.DrawString(vattext, FontTB, Brushes.Black, marginR - vattextsize.Width - 2, j)
                        j += 20
                        e.Graphics.DrawString(paytext, FontHB, Brushes.Black, marginR - paytextsize.Width - 6, j)
                        j += 20
                        e.Graphics.DrawString(vatIncludedText, FontTB, Brushes.Black, marginR - vatIncludedTextSize.Width - 6, j)
                    End If
                    If Mid(lbl_SaleType.Text, 1, 6) <> "დაბრუნ" Then
                        If Not lbl_SaleType.Text.Contains("შეკვეთა") Then
                            If Not lbl_SaleType.Text.Contains("უნაღდო") Then
                                Dim calctext As String = IIf(UITerms.ContainsKey("გადახდილი"), CheckTermsValue("გადახდილი"), "გადახდილი") + "      " + txt_Gad_Tan.Text + "      " + IIf(UITerms.ContainsKey("ხურდა"), CheckTermsValue("ხურდა"), "ხურდა") + "      " + lbl_Gasacemi.Text
                                Dim calctextsize = e.Graphics.MeasureString(calctext, FontNP)
                                j += 24
                                e.Graphics.DrawString(calctext, FontNP, Brushes.Black, (marginR - calctextsize.Width) / 2, j)
                            End If
                        End If
                        j += 24
                        e.Graphics.DrawLine(Pens.Black, marginL, j, marginR, j)
                        If (Now.Month = 12 And Now.Day > 24) Or (Now.Month = 1 And Now.Day < 15) Then
                            Dim congratstext = Company_Name + " " + IIf(UITerms.ContainsKey("გილოცავთ"), CheckTermsValue("გილოცავთ"), "გილოცავთ")
                            Dim holidaytext = IIf(UITerms.ContainsKey("შობა-ახალ წელს"), CheckTermsValue("შობა-ახალ წელს"), "შობა-ახალ წელს")
                            Dim congratstextsize = e.Graphics.MeasureString(congratstext, FontHB)
                            Dim holidaytextsize = e.Graphics.MeasureString(holidaytext, FontHB)
                            j += 2
                            e.Graphics.DrawString(congratstext, FontHB, Brushes.Black, (marginR - congratstextsize.Width) / 2, j)
                            j += 18
                            e.Graphics.DrawString(holidaytext, FontHB, Brushes.Black, (marginR - holidaytextsize.Width) / 2, j)
                            j += 18
                            e.Graphics.DrawString(".", FontHB, Brushes.WhiteSmoke, 1, j)
                        Else
                            Dim footnote As String = IIf(UITerms.ContainsKey("გმადლობთ"), CheckTermsValue("გმადლობთ"), "გმადლობთ")
                            Dim footnotesize = e.Graphics.MeasureString(footnote, FontHB)
                            If Company_Name.Contains("ანტრე") And PD.DocumentName <> "order" Then
                                Dim footnotez As String = IIf(UITerms.ContainsKey("დამზადებულია გემოვნებით"), CheckTermsValue("დამზადებულია გემოვნებით"), "დამზადებულია გემოვნებით")
                                Dim footnotezsize = e.Graphics.MeasureString(footnotez, FontHB)
                                j += 2
                                e.Graphics.DrawString(footnotez, FontHB, Brushes.Black, (marginR - footnotezsize.Width) / 2, j)
                                j += 18
                                e.Graphics.DrawString(footnote, FontHB, Brushes.Black, (marginR - footnotesize.Width) / 2, j)
                            ElseIf PD.DocumentName <> "order" Then
                                j += 2
                                e.Graphics.DrawString(footnote, FontHB, Brushes.Black, (marginR - footnotesize.Width) / 2, j)
                            End If
                            j += 18
                            e.Graphics.DrawString(".", FontHB, Brushes.WhiteSmoke, 1, j)
                        End If
                    End If
                End If
            End If
            b_Daibechda(1) = Not (e.Cancel)
        Catch ex As Exception
            Mesigi(ex.Message + Environment.NewLine + ex.StackTrace, "Err_PrintPage")
            Write_In_Log("Err_PrintPage: " & ex.Message + ex.StackTrace)
        End Try
    End Sub

    Private Sub Look_Last_Sales()
        Dim Conn As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Dim Reader As SqlClient.SqlDataReader
        Dim Passed As Boolean = False

        txt_kodi.Visible = False

        Comm.Connection = Conn
        Try
            Conn.Open()
            Comm.CommandText = "SELECT l.code, l.quantity, l.price, Round(l.quantity * l.price,2) amount, l.ttime, jgufi, dasaxeleba, isnull(wonis, 0) wonis, l.id, s.fiscal_docid, l.order_printed, isnull(price_list.pType, 1) pType FROM pos_salelines l inner join pos_sales s on l.check_n = s.check_n LEFT JOIN price_list ON code=kodi WHERE l.parentid is null and s.check_n='" & Check_Number & "' order by l.id"
            Reader = Comm.ExecuteReader
            While Reader.Read

                If Not (Reader.Item(4) Is DBNull.Value) Then
                    If Reader.Item(4).ToString = "diplomat" Then
                        b_Fasdakleba_Moxda = 18
                        lbl_SaleType.Text = "გაყიდვა -18%"
                    ElseIf Reader.Item(4).ToString = "restaurant" Then
                        b_Fasdakleba_Moxda = 8
                        lbl_SaleType.Text = "გაყიდვა -8%"
                    ElseIf Reader.Item(4).ToString = "discount_10p" Then
                        b_Fasdakleba_Moxda = 10
                        lbl_SaleType.Text = "გაყიდვა -10%"
                    Else
                        lbl_SaleType.Text = "დაბრუნება"
                        lbl_SaleType.ForeColor = Color.Red
                        lbl_Gadasaxdeli.Text = "დასაბრუნებელი თანხა"
                        lbl_Tanxa.ForeColor = Color.Red
                        ReturnFiscalDocId = Reader.Item(9).ToString()
                    End If
                End If

                If Not Passed Then
                    Try
                        If fp_daisy > 0 Then
                            If DaisyFP.NonFiscalDocIsOpen Then
                                DaisyFP.NonFiscalDocClose()
                            End If
                            If DaisyFP.FiscalDocIsOpen Then
                                DaisyFP.FiscalDocCancel()
                            End If
                            'If Not DaisyFP.PrintAllowed Then
                            '    DaisyFP.Dispose()
                            '    Throw New Exception("Print of document is not allowed")
                            'End If
                        End If
                    Catch ex As Exception
                        Mesigi(ex.Message, ex.Source)

                        b_Fasdakleba_Moxda = 0
                        lbl_SaleType.Text = "გაყიდვა"
                        lbl_SaleType.ForeColor = Color.Green
                        lbl_Gadasaxdeli.Text = "გადასახდელი თანხა"
                        lbl_Tanxa.ForeColor = Color.Blue
                        TranslateUI(Me, UITerms)
                        If fp_daisy > 0 Then
                            DaisyFP.Dispose()
                        End If

                        Exit Sub
                    End Try
                End If

                DGV_Sales.Rows.Add()

                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value = Reader.Item(8)

                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value = Reader.Item(0)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = Math.Abs(Reader.Item(1))
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value = Reader.Item(2)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Math.Abs(Reader.Item(3))

                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(1).Value = Reader.Item(5)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(2).Value = Reader.Item(6)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(7).Value = Reader.Item(10)

                a_WonisStatusebi.Add(Reader.Item(7))
                If Reader.Item(1) = 0 Then
                    a_NulebisStatusebi.Add(0)
                Else
                    a_NulebisStatusebi.Add(1)
                End If
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                a_TaxGroups.Add(Reader.Item(11))
                Add_Row_to_Monitor(DGV_Sales.Rows.Count - 1)
            End While
            Reader.Close()

            Adjust_GridHeight()

            Dim i_Count As Integer
            Dim i_RowCount As Integer = DGV_Sales.Rows.Count
            For i_Count = 0 To i_RowCount - 1
                d_Tanxa += Val(DGV_Sales.Rows(i_Count).Cells(5).Value)
            Next
            's_Tanxa = f_Damrgvaleba(d_Tanxa).ToString("#####0.00")
            'Label_Tanxa.Text = s_Tanxa
            lbl_Tanxa.Text = Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero).ToString("#####0.00")
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Look_Last_Sales:")
            Write_In_Log("Err_Look_Last_Sales: " & ex.Message)
        Finally
            Conn.Close()
            txt_kodi.Visible = True
            txt_kodi.Focus()
        End Try
    End Sub

    Private Sub Fill_Preorder(ByVal check_n As Integer)
        Dim Conn As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Dim Reader As SqlClient.SqlDataReader
        Dim Passed As Boolean = False
        Dim Rank As Integer = 0

        txt_kodi.Visible = False

        Comm.Connection = Conn
        Try
            Conn.Open()
            Comm.CommandText = "SELECT l.code, l.quantity, l.price, Round(l.quantity * l.price,2) amount, l.ttime, p.jgufi, p.dasaxeleba, isnull(p.wonis, 0) wonis, l.id, s.fiscal_docid, l.order_printed, l.order_rank, isnull(p.pType, 1) pType FROM pos_salelines l inner join pos_sales s on l.check_n = s.check_n LEFT JOIN price_list p ON l.code=p.kodi WHERE l.parentid is null and s.check_n='" & check_n & "' order by l.id"
            Reader = Comm.ExecuteReader
            Check_Number = check_n
            lbl_Check_N.Text = Pos_N.ToString & Check_Number.ToString("000000")
            While Reader.Read
                If Not (Reader.Item(4) Is DBNull.Value) And Not lbl_SaleType.Text.EndsWith("%") Then
                    If Reader.Item(4).ToString = "diplomat" Then
                        b_Fasdakleba_Moxda = 18
                        lbl_SaleType.Text += " -18%"
                    ElseIf Reader.Item(4).ToString = "restaurant" Then
                        b_Fasdakleba_Moxda = 8
                        lbl_SaleType.Text += " -8%"
                    ElseIf Reader.Item(4).ToString = "discount_10p" Then
                        b_Fasdakleba_Moxda = 10
                        lbl_SaleType.Text += " -10%"
                    End If
                End If

                If Not Passed Then
                    Try
                        If fp_daisy > 0 Then
                            If DaisyFP.NonFiscalDocIsOpen Then
                                DaisyFP.NonFiscalDocClose()
                            End If
                            If DaisyFP.FiscalDocIsOpen Then
                                DaisyFP.FiscalDocCancel()
                            End If
                        End If
                    Catch ex As Exception
                        Mesigi(ex.Message, ex.Source)

                        b_Fasdakleba_Moxda = 0
                        lbl_SaleType.Text = "გაყიდვა"
                        lbl_SaleType.ForeColor = Color.Green
                        lbl_Gadasaxdeli.Text = "გადასახდელი თანხა"
                        lbl_Tanxa.ForeColor = Color.Blue
                        TranslateUI(Me, UITerms)
                        If fp_daisy > 0 Then
                            DaisyFP.Dispose()
                        End If

                        Exit Sub
                    End Try
                End If

                DGV_Sales.Rows.Add()

                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value = Reader.Item(8)

                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value = Reader.Item(0)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = Math.Abs(Reader.Item(1))
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value = Reader.Item(2)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Math.Abs(Reader.Item(3))

                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(1).Value = Reader.Item(5)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(2).Value = Reader.Item(6)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(7).Value = Reader.Item(10)
                Rank = Reader.Item(11)
                If Rank <> 0 Then
                    DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).DividerHeight = 4
                End If
                a_WonisStatusebi.Add(Reader.Item(7))
                If Reader.Item(1) = 0 Then
                    a_NulebisStatusebi.Add(0)
                Else
                    a_NulebisStatusebi.Add(1)
                End If
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                a_TaxGroups.Add(Reader.Item(12))
                Add_Row_to_Monitor(DGV_Sales.Rows.Count - 1)
            End While
            Reader.Close()

            Adjust_GridHeight()

            Dim i_Count As Integer
            Dim i_RowCount As Integer = DGV_Sales.Rows.Count
            For i_Count = 0 To i_RowCount - 1
                d_Tanxa += Val(DGV_Sales.Rows(i_Count).Cells(5).Value)
            Next
            's_Tanxa = f_Damrgvaleba(d_Tanxa).ToString("#####0.00")
            'Label_Tanxa.Text = s_Tanxa
            lbl_Tanxa.Text = Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero).ToString("#####0.00")
            btnPrintBill.Visible = True
            btnPrintOrder.Visible = True
            btnNew.Visible = True
            lbl_Gadasaxdeli.Spring = False
            lbl_Gadasaxdeli.Width = 286
            lbl_Gadasaxdeli.Spring = True
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Look_Last_Sales:")
            Write_In_Log("Err_Look_Last_Sales: " & ex.Message)
        Finally
            Conn.Close()
            txt_kodi.Visible = True
            txt_kodi.Focus()
        End Try
    End Sub

    Private Sub Adjust_GridHeight()
        Dim grid_height As Integer = DGV_Sales.ColumnHeadersHeight + DGV_Sales.RowTemplate.Height * DGV_Sales.Rows.Count
        Dim max_height = Panel_Body.Height - (Panel_Body.Margin.Top + Panel_Body.Margin.Bottom) - txt_kodi.Height
        If grid_height <= max_height Then
            DGV_Sales.Height = grid_height
            DGV_Sales.ScrollBars = ScrollBars.None
        Else
            Dim max_rows = Math.Floor((max_height - DGV_Sales.ColumnHeadersHeight) / DGV_Sales.RowTemplate.Height)
            DGV_Sales.Height = DGV_Sales.ColumnHeadersHeight + max_rows * DGV_Sales.RowTemplate.Height
            DGV_Sales.ScrollBars = ScrollBars.Vertical
        End If
        txt_kodi.Top = DGV_Sales.Height
    End Sub

    Private Sub Get_NewCheckN()
        Try
            Using Conn As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
                Using comm As New SqlClient.SqlCommand
                    comm.Connection = Conn
                    comm.CommandText = "SELECT Max(check_n) FROM pos_sales"
                    Conn.Open()
                    Dim value = comm.ExecuteScalar()
                    Dim MaxCheckN As Integer? = IIf(IsDBNull(value) = True, Nothing, value)
                    If MaxCheckN.HasValue Then
                        Check_Number = MaxCheckN.Value
                    Else
                        Check_Number = 0
                    End If

                    Check_Number += 1
                    'lbl_Check_N.Text = Convert.ToInt32(lbl_Check_N.Text) + 1
                    lbl_Check_N.Text = Pos_N.ToString & Check_Number.ToString("000000")
                End Using
            End Using
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Get_NewCheckN:")
            Write_In_Log("Err_Get_NewCheckN: " & ex.Message)
        End Try
    End Sub

    Private Sub Get_NewCheckN_On_Load()
        Dim Conn As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
        Dim comm As New SqlClient.SqlCommand
        Dim reader As SqlClient.SqlDataReader
        Check_Number = 0
        lbl_Check_N.Text = "0"
        comm.Connection = Conn
        comm.CommandText = "SELECT Max(check_n) FROM pos_sales where (sale_type = 1 or sale_type = 5) and close_status = 0 GROUP BY close_status"
        Try
            Conn.Open()
            reader = comm.ExecuteReader
            If reader.Read() Then
                If Not (reader.Item(0) Is DBNull.Value) Then
                    Check_Number = reader.GetInt32(0)
                    lbl_Check_N.Text = Pos_N & Check_Number.ToString("000000")
                End If
            Else
                reader.Close()
                comm.CommandText = "SELECT Max(check_n) FROM pos_sales"
                Dim value = comm.ExecuteScalar()
                Dim MaxCheckN As Integer? = IIf(IsDBNull(value) = True, Nothing, value)
                If MaxCheckN.HasValue Then
                    Check_Number = MaxCheckN.Value + 1
                    lbl_Check_N.Text = Pos_N & Check_Number.ToString("000000")
                End If
            End If
            If Check_Number = 0 Then
                Check_Number = 1
                lbl_Check_N.Text = Pos_N & "000001"
                Me.Refresh()
            End If
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Get_NewCheckN_On_Load:")
            Write_In_Log("Err_Get_NewCheckN_On_Load: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Friend Sub refresh_Form()
        Try
            Get_NewCheckN()
            DGV_Sales.Rows.Clear()
            DGV_Sales.Height = 29
            Panel_Body.AutoScrollPosition = New System.Drawing.Point(0, 0)
            txt_kodi.Top = DGV_Sales.Height
            b_Fasdakleba_Moxda = 0
            BankTerminalData = String.Empty
            ReturnFiscalDocId = String.Empty
            SetOrderControls(False)
            OrderedTable = Nothing
            lbl_Saxeli.Text = p_Person.Name
            txt_Guests.Text = String.Empty
            d_Tanxa = 0
            's_Tanxa = 0
            lbl_Tanxa.Text = "0.00"
            txt_Gad_Tan.Clear()
            lbl_Gasacemi.Text = String.Empty
            a_WonisStatusebi.Clear()
            a_NulebisStatusebi.Clear()
            a_Fasdaklebebi.Clear()
            a_TaxGroups.Clear()
            lbl_SaleType.Text = "გაყიდვა"
            lbl_SaleType.ForeColor = Color.Green
            lbl_Gadasaxdeli.Text = "გადასახდელი თანხა"
            lbl_Tanxa.ForeColor = Color.Blue
            txt_kodi.Focus()
            TranslateUI(Me, UITerms)
            btnPrintBill.Visible = False
            btnPrintOrder.Visible = False
            btnNew.Visible = False
            lbl_Gadasaxdeli.Spring = False
            lbl_Gadasaxdeli.Width = 286
            lbl_Gadasaxdeli.Spring = True
            Me.Refresh()

            'GCAnator.AdvancedGC.Collect()
        Catch ex As Exception
            Write_In_Log("refresh_Form: " & ex.Message)
        End Try
    End Sub

    Private Sub TimerDate_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerDate.Tick
        lbl_Time.Text = Now
        'If (Now - dt_Servertan_Kavshirisatvis).TotalMinutes > 30 Then
        '    b_Servertan_Aris_Kavshiri = True
        'End If
    End Sub

    Dim tic As Integer = 0

    Private Sub drawer_timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles drawer_timer.Tick
        Try
            tic = tic + 1

            If Me.Focused Or txt_kodi.Focused Then
                tic = 0
                Throw New Exception()
            End If

            If tic = 1 Then
                SendKeys.Send("o")
            End If
            If tic = 2 Then
                SendKeys.Send("{ENTER}")
            End If
            If tic = 3 Then
                SendKeys.Send("1")
            End If
            If tic = 4 Then
                SendKeys.Send("{ENTER}")
            End If
            If tic = 5 Then
                SendKeys.Send("c")
            End If
            If tic = 6 Then
                SendKeys.Send("{ENTER}")
            End If
            If tic = 7 Then
                SendKeys.Send("q")
            End If
            If tic > 7 Then
                SendKeys.Send("{ENTER}")
                tic = 0
                drawer_timer.Stop()
            End If
        Catch
            tic = 0
            drawer_timer.Stop()
        End Try
    End Sub

    Private Sub DGV_Sales_CausesValidationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV_Sales.CausesValidationChanged

    End Sub

    Private Sub DGV_Sales_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGV_Sales.CellBeginEdit
        d_Shecvlamde = Val(DGV_Sales.SelectedCells(0).Value)
    End Sub

    Private Sub DGV_Sales_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Sales.CellEndEdit
        If Not IsNumeric(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) Then
            DGV_Sales.Rows(e.RowIndex).Cells(4).Value = IIf(d_Shecvlamde = 0, 1, d_Shecvlamde)
        Else
            If a_WonisStatusebi(e.RowIndex) = False And (Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) Mod 1) > 0 Then
                DGV_Sales.Rows(e.RowIndex).Cells(4).Value = CInt(Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value))
            End If
            If Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) = 0 And a_NulebisStatusebi(e.RowIndex) = 1 Then
                If p_Person.Role = 9 Or Mid(lbl_SaleType.Text, 1, 6) = "დაბრუნ" Then
                    DGV_Sales.Rows(e.RowIndex).Cells(4).Value = 0
                    a_NulebisStatusebi(e.RowIndex) = 0
                Else
                    If Avtorizacia() Then
                        If p_Person.Role2 = 9 Then
                            DGV_Sales.Rows(e.RowIndex).Cells(4).Value = 0
                            a_NulebisStatusebi(e.RowIndex) = 0
                        Else
                            DGV_Sales.Rows(e.RowIndex).Cells(4).Value = IIf(d_Shecvlamde = 0, 1, d_Shecvlamde)
                        End If
                    Else
                        DGV_Sales.Rows(e.RowIndex).Cells(4).Value = IIf(d_Shecvlamde = 0, 1, d_Shecvlamde)
                    End If
                End If
            Else
                DGV_Sales.Rows(e.RowIndex).Cells(4).Value = Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value)
            End If
        End If
        If Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) > 100 Then
            DGV_Sales.Rows(e.RowIndex).Cells(4).Value = d_Shecvlamde
        End If
        If p_Person.Role <> 9 And Mid(lbl_SaleType.Text, 1, 6) <> "დაბრუნ" Then
            If Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) <> 0 And d_Shecvlamde > Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) Then
                DGV_Sales.Rows(e.RowIndex).Cells(4).Value = d_Shecvlamde
            End If
        End If
        If Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) < 0 Then
            DGV_Sales.Rows(e.RowIndex).Cells(4).Value = d_Shecvlamde
        End If

        If d_Shecvlamde <> Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) Then
            d_Tanxa -= Math.Round(Val(DGV_Sales.Rows(e.RowIndex).Cells(5).Value), 2, MidpointRounding.AwayFromZero)
            DGV_Sales.Rows(e.RowIndex).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(e.RowIndex).Cells(3).Value) * Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
            d_Tanxa += Math.Round(Val(DGV_Sales.Rows(e.RowIndex).Cells(5).Value), 2, MidpointRounding.AwayFromZero)
            lbl_Tanxa.Text = Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero).ToString("#####0.00")
            If Mid(lbl_SaleType.Text, 1, 6) = "დაბრუნ" Then
                M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(e.RowIndex).Cells(6).Value), Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value) - 2 * Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value))
            Else
                M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(e.RowIndex).Cells(6).Value), Val(DGV_Sales.Rows(e.RowIndex).Cells(4).Value))
            End If
        End If
        If e.ColumnIndex = 4 Then
            Update_Monitor_Row(e.RowIndex, e.ColumnIndex)
        End If
        txt_kodi.Focus()
    End Sub

    Private Sub DGV_Sales_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV_Sales.GotFocus
        DGV_Sales.DefaultCellStyle.SelectionBackColor = Color.DarkBlue
    End Sub

    Private Sub DGV_Sales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV_Sales.KeyDown
        If e.KeyCode = Keys.Enter Then 'Enter
            If DGV_Sales.Rows.Count > 0 Then
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                DGV_Sales.DefaultCellStyle.SelectionBackColor = Color.Tomato
            End If
            txt_kodi.Focus()
        End If
    End Sub

    Private Sub DGV_Sales_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV_Sales.LostFocus
        DGV_Sales.DefaultCellStyle.SelectionBackColor = Color.Tomato
    End Sub

    Private Sub DGV_Sales_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV_Sales.SelectionChanged
        If DGV_Sales.SelectedCells.Count > 0 Then
            'If DGV_Sales.SelectedCells(0).ColumnIndex <> 4 Then
            '    DGV_Sales.Rows(DGV_Sales.SelectedCells(0).RowIndex).Cells(4).Selected = True
            'End If
            If DGV_Sales.Focused Then
                Panel_Body.AutoScrollPosition = New System.Drawing.Point(0, DGV_Sales.SelectedCells(0).RowIndex * 22)
            End If
        End If
    End Sub

    Public Sub Sale_Back()
        Dim i_Check_N As Integer = M_Z.pos_Check_N(Inputi("ჩაწერეთ დასაბრუნებელი ჩეკის ნომერი", "დაბრუნება"))
        Dim Conn1 As New System.Data.SqlClient.SqlConnection(LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Dim Reader As SqlClient.SqlDataReader
        Dim p_Type As Short = 0
        Comm.Connection = Conn1
        Try
            Conn1.Open()
            Comm.CommandText = "SELECT code, quantity, price, Round(quantity * price,2) amount, ttime, jgufi, dasaxeleba, isnull(wonis, 0) wonis, payment_type, fiscal_docid, isnull(price_list.pType, 1) pType FROM pos_sales LEFT JOIN pos_salelines ON pos_sales.check_n=pos_salelines.check_n LEFT JOIN price_list ON code=kodi WHERE pos_salelines.parentid is null and pos_sales.check_n=" & i_Check_N & " AND (ttime IS NULL OR ttime = 'diplomat' OR ttime = 'restaurant') AND ((SELECT Max(check_n) FROM pos_salelines WHERE ttime='" & Pos_N & i_Check_N.ToString("000000") & "') IS NULL)"
            'AND ('" & s_Check_N & "' NOT IN (SELECT ttime FROM pos_salelines))
            Reader = Comm.ExecuteReader
            While Reader.Read
                shemdegi()
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value = Reader.Item(0)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = Reader.Item(1)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value = Reader.Item(2)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Reader.Item(3)
                ' Ttime=reader.Item(4)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(1).Value = Reader.Item(5)
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(2).Value = Reader.Item(6)
                a_WonisStatusebi.Add(Reader.Item(7))
                'If Reader.Item(1) = 0 Then
                a_NulebisStatusebi.Add(0)
                'Else
                'a_NulebisStatusebi.Add(1)
                'End If
                a_TaxGroups.Add(Reader.Item(10))
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                If DGV_Sales.Rows.Count = 1 Then
                    M_SQL.Open_Sale(Check_Number)
                End If
                Dim id As Integer = M_SQL.Do_SaleLines(Check_Number, DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value, Val(DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value) - 2 * (Val(DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value)), DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value, Pos_N & i_Check_N.ToString("000000"))
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value = id
                p_Type = Reader.Item(8)
                ReturnFiscalDocId = IIf(IsDBNull(Reader.Item(9)), Nothing, Reader.Item(9).ToString())
            End While
            Reader.Close()
            Dim i_Count As Integer
            Dim i_RowCount As Integer = DGV_Sales.Rows.Count
            For i_Count = 0 To i_RowCount - 1
                d_Tanxa += Val(DGV_Sales.Rows(i_Count).Cells(5).Value)
            Next
            's_Tanxa = f_Damrgvaleba(d_Tanxa).ToString("#####0.00")
            'Label_Tanxa.Text = s_Tanxa
            lbl_Tanxa.Text = Math.Round(d_Tanxa, 2, MidpointRounding.AwayFromZero).ToString("#####0.00")
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Sale_Back:")
            Write_In_Log("Err_Sale_Back: " & ex.Message)
        Finally
            Conn1.Close()
        End Try
        If DGV_Sales.Rows.Count > 0 Then
            If p_Type = 0 Then
                lbl_SaleType.Text = "დაბრუნება"
            Else
                lbl_SaleType.Text = "დაბრუნება უნაღდო"
            End If
            lbl_SaleType.ForeColor = Color.Red
            lbl_Gadasaxdeli.Text = "დასაბრუნებელი თანხა"
            lbl_Tanxa.ForeColor = Color.Red
        Else
            Mesigi("ასეთი ნომრის ჩეკი არ არსებობს ან უკვე დაბრუნებულია", "შეცდომა")
        End If
    End Sub

    Private Sub Check_Log_Size()
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\pos_log") Then
            Try
                Dim i, j As Integer
                FileOpen(1, My.Application.Info.DirectoryPath & "\pos_log", OpenMode.Input)
                While Not EOF(1)
                    LineInput(1)
                    i += 1
                End While
                FileClose(1)
                If i > 400 Then
                    FileOpen(1, My.Application.Info.DirectoryPath & "\pos_log", OpenMode.Input)
                    FileOpen(2, My.Application.Info.DirectoryPath & "\pos_log2", OpenMode.Output)
                    j = 0
                    Dim s As String = String.Empty
                    While Not EOF(1)
                        If j > i - 250 Then
                            s = LineInput(1)
                            If Len(s) > 2 Then
                                WriteLine(2, Mid(s, 2, Len(s) - 2))
                            End If
                            j += 1
                        Else
                            LineInput(1)
                            j += 1
                        End If
                    End While
                    FileClose(1)
                    FileClose(2)
                    FileSystem.Kill(My.Application.Info.DirectoryPath & "\pos_log")
                    FileSystem.Rename(My.Application.Info.DirectoryPath & "\pos_log2", My.Application.Info.DirectoryPath & "\pos_log")
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Check_Log_Size")
            End Try
        End If
    End Sub

    Public Sub Write_In_Log(ByVal s_Log As String)
        Try
            FileOpen(1, My.Application.Info.DirectoryPath & "\pos_log", OpenMode.Append)
            WriteLine(1, Now & " - " & s_Log)
            FileClose(1)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt_kodi_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SetOrderControls(ByVal visible As Boolean)
        btn_EditUser.Visible = visible
        lbl_Guests.Visible = visible
        panel_OrderCtrls.Visible = visible
        btn_BookinsReport.Left = IIf(visible = True, lbl_Guests, lbl_Status).Left - btn_BookinsReport.Width - 3
    End Sub

    Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton1.Click
        frmNumpad.Visible = False
        If DGV_Sales.RowCount < 1 And OrdersAllowed = True Then
            If Market_N = 72 Then
                Using tables_form As New frmOrderTablesSagaOne
                    If tables_form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        OrderedTable = tables_form.SelectedTable
                        lbl_SaleType.Text = "შეკვეთა - " + OrderedTable.Name
                        SetOrderControls(True)
                        If OrderedTable.CheckN.HasValue Then
                            txt_Guests.Text = OrderedTable.Guests.ToString()
                            If Not String.IsNullOrEmpty(OrderedTable.Supervisor) Then
                                lbl_Saxeli.Text = OrderedTable.Supervisor
                            End If
                            Fill_Preorder(OrderedTable.CheckN.Value)
                            Exit Sub
                        Else
                            FillPersonnel()
                            If personnel_list.Count > 0 Then
                                Using fuserselect As New FUserSelect()
                                    fuserselect.ShowDialog()
                                    fusers.SelectedCellIndex = fuserselect.SelectedCellIndex
                                End Using
                            Else
                                OrderedTable.Supervisor = p_Person.Name
                            End If
                            Dim guests_str = Inputi("სტუმრების რაოდენობა:", "სტუმრები")
                            If IsNumeric(guests_str) Then
                                OrderedTable.Guests = Val(guests_str)
                                txt_Guests.Text = guests_str
                            End If
                        End If
                    End If
                End Using
            Else
                Using tables_form As New frmOrderTables
                    If tables_form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        OrderedTable = tables_form.SelectedTable
                        lbl_SaleType.Text = "შეკვეთა - " + OrderedTable.Name
                        SetOrderControls(True)
                        If OrderedTable.CheckN.HasValue Then
                            txt_Guests.Text = OrderedTable.Guests.ToString()
                            If Not String.IsNullOrEmpty(OrderedTable.Supervisor) Then
                                lbl_Saxeli.Text = OrderedTable.Supervisor
                            End If
                            Fill_Preorder(OrderedTable.CheckN.Value)
                            Exit Sub
                        Else
                            FillPersonnel()
                            If personnel_list.Count > 0 Then
                                Using fuserselect As New FUserSelect()
                                    fuserselect.ShowDialog()
                                    fusers.SelectedCellIndex = fuserselect.SelectedCellIndex
                                End Using
                            Else
                                OrderedTable.Supervisor = p_Person.Name
                            End If
                            Dim guests_str = Inputi("სტუმრების რაოდენობა:", "სტუმრები")
                            If IsNumeric(guests_str) Then
                                OrderedTable.Guests = Val(guests_str)
                                txt_Guests.Text = guests_str
                            End If
                        End If
                    End If
                End Using
            End If
        End If

        FSaleSublines.Visible = False

        frmThumbs.isFmain = True
        frmThumbs.WindowState = FormWindowState.Normal
        'frmThumbs.Left = Screen.AllScreens(0).WorkingArea.Width + 10
        frmThumbs.WindowState = FormWindowState.Maximized
        frmThumbs.Visible = True
    End Sub

    Private Sub txt_Gad_Tan_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Gad_Tan.Enter

    End Sub

    Private Sub txt_Gad_Tan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Gad_Tan.Click
        FSaleSublines.Visible = False

        frmNumpad.Visible = False
        frmNumpad.Left = txt_Gad_Tan.Left - frmNumpad.Width
        frmNumpad.Top = txt_Gad_Tan.Top
        frmNumpad.fSender = Me
        frmNumpad.Visible = True
        Me.Focus()
    End Sub

    Private Sub txt_kodi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kodi.Click
        frmNumpad.Visible = False
        If txt_kodi.Top < txt_kodi.Parent.Height - frmNumpad.Height Then
            frmNumpad.Left = txt_kodi.Left
            frmNumpad.Top = txt_kodi.Top + txt_kodi.Parent.Top + txt_kodi.Height + 1
        Else
            frmNumpad.Left = txt_kodi.Left
            frmNumpad.Top = (txt_kodi.Top + txt_kodi.Parent.Top) - frmNumpad.Height - 1
        End If
        frmNumpad.fSender = Me
        frmNumpad.Visible = True
        Me.Focus()
    End Sub

    Private Sub txt_kodi_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kodi.Enter
        'txt_kodi.SelectionStart = txt_kodi.Text.Length
        'txt_kodi.SelectionLength = 0
    End Sub

    Private Sub txt_kodi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kodi.Leave
        'txt_kodi.SelectionStart = txt_kodi.Text.Length
        'txt_kodi.SelectionLength = 0
    End Sub

    Private Sub DGV_Sales_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Sales.CellEnter
    End Sub

    Private Sub DGV_Sales_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Sales.CellClick
        FSaleSublines.Visible = False
        frmNumpad.Visible = False
        If DGV_Sales.SelectedCells(0).ColumnIndex = 4 Then
            If (e.RowIndex + 1) * DGV_Sales.RowTemplate.Height - DGV_Sales.VerticalScrollingOffset < DGV_Sales.Parent.Height - frmNumpad.Height Then
                frmNumpad.Left = DGV_Sales.Columns(0).Width + DGV_Sales.Columns(1).Width + DGV_Sales.Columns(2).Width + DGV_Sales.Columns(3).Width - frmNumpad.Width + 2
                frmNumpad.Top = DGV_Sales.Parent.Top + (e.RowIndex + 1) * DGV_Sales.RowTemplate.Height + DGV_Sales.ColumnHeadersHeight - DGV_Sales.VerticalScrollingOffset
            Else
                frmNumpad.Left = DGV_Sales.Columns(0).Width + DGV_Sales.Columns(1).Width + DGV_Sales.Columns(2).Width + DGV_Sales.Columns(3).Width - frmNumpad.Width + 2
                frmNumpad.Top = Height - frmNumpad.Height
            End If
            frmNumpad.fSender = Me
            frmNumpad.Visible = True
            Me.Focus()
        Else
            Dim code As String = DGV_Sales.Rows(DGV_Sales.SelectedCells(0).RowIndex).Cells(0).Value.ToString()
            If IsMenu(code) Then
                Dim name As String = DGV_Sales.Rows(DGV_Sales.SelectedCells(0).RowIndex).Cells(2).Value.ToString()
                FSaleSublines.Text = name + " - მენიუს შემადგენლობა"
                FSaleSublines.lblDescription.Text = M_SQL.GetDescription(code)
                FSaleSublines.Left = DGV_Sales.Left + 2
                If (e.RowIndex + 1) * DGV_Sales.RowTemplate.Height < DGV_Sales.Parent.Height - FSaleSublines.Height Then
                    FSaleSublines.Top = DGV_Sales.Parent.Top + (e.RowIndex + 1) * DGV_Sales.RowTemplate.Height + DGV_Sales.ColumnHeadersHeight
                Else
                    FSaleSublines.Top = DGV_Sales.Parent.Top + (e.RowIndex + 1) * DGV_Sales.RowTemplate.Height + DGV_Sales.ColumnHeadersHeight - DGV_Sales.RowTemplate.Height - FSaleSublines.Height
                End If
                FSaleSublines.pId = Convert.ToInt32(DGV_Sales.Rows(DGV_Sales.SelectedCells(0).RowIndex).Cells(6).Value)
                FSaleSublines.Load_Sublines()
                FSaleSublines.Visible = True
            End If
        End If
    End Sub

    Private Sub Panel_Body_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_Body.Click
        frmNumpad.Visible = False
        FSaleSublines.Visible = False
    End Sub

    Private Sub Panel_Header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_Header.Click
        frmNumpad.Visible = False
        FSaleSublines.Visible = False
    End Sub

    Private Sub PicLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmNumpad.Visible = False
        FSaleSublines.Visible = False
    End Sub

    Private Sub Fmain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        frmMonitor.Visible = False
        frmMonitor.WindowState = FormWindowState.Normal
        frmMonitor.Left = Screen.AllScreens(0).WorkingArea.Width + 10
        frmMonitor.WindowState = FormWindowState.Maximized
        frmMonitor.Visible = True
        frmMonitor.UltraPictureBox1.Dock = DockStyle.Fill

        Me.Focus()
    End Sub

    Private Sub DGV_Sales_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_Sales.RowsAdded


    End Sub

    Private Sub lbl_SaleType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_SaleType.TextChanged
        Label4.Text = lbl_SaleType.Text
    End Sub

    Private Sub btnPrintOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintOrder.Click
        frmNumpad.Visible = False
        If Printer_N = 1 Then

            'DGV_Sales.Rows.Clear()
            'DGV_Sales.Height = 29
            'Panel_Body.AutoScrollPosition = New System.Drawing.Point(0, 0)
            'txt_kodi.Top = DGV_Sales.Height

            'Fill_Preorder(OrderedTable.CheckN.Value)
            Dim printers As New List(Of String)
            Using conn As New SqlClient.SqlConnection(LOCAL_CONN_STR)
                Using comm As New SqlClient.SqlCommand()
                    comm.Connection = conn
                    comm.CommandType = CommandType.Text
                    comm.CommandText = "select count(*) from pos_salelines where order_printed = 0 and check_n = @check_n"
                    comm.Parameters.Add("@check_n", SqlDbType.Int).Value = Check_Number
                    conn.Open()
                    Dim printables As Integer = comm.ExecuteScalar()
                    If printables = 0 Then
                        If Mesigi("შეკვეთა უკვე დაბეჭდილია, გნებავთ ხელმეორედ დაბეჭდვა?", , True) = False Then
                            Exit Sub
                        End If
                        comm.CommandText = "select distinct	p.code printer_name from pos_salelines l inner join items i on l.code = i.itmkey left join itemgroup_printers gp on i.itmgID = gp.itmg_id left join receipt_printers p on gp.printer_id = p.id where l.check_n = @check_n"
                        For i As Integer = 0 To DGV_Sales.Rows.Count - 1
                            DGV_Sales.Rows(i).Cells(7).Value = False
                        Next
                    Else
                        comm.CommandText = "select distinct	p.code printer_name from pos_salelines l inner join items i on l.code = i.itmkey left join itemgroup_printers gp on i.itmgID = gp.itmg_id left join receipt_printers p on gp.printer_id = p.id where l.check_n = @check_n and l.order_printed = 0"
                    End If
                    Using reader As SqlClient.SqlDataReader = comm.ExecuteReader()
                        While reader.Read()
                            If IsDBNull(reader.Item("printer_name")) And Not printers.Contains(printerSettings.PrinterName) Then
                                printers.Add(printerSettings.PrinterName)
                            ElseIf Not printers.Contains(reader.Item("printer_name").ToString()) Then
                                printers.Add(reader.Item("printer_name").ToString())
                            End If
                        End While
                    End Using
                End Using
            End Using

            If printers.Count = 0 Then
                printers.Add(printerSettings.PrinterName)
            End If

            For Each printer_name In printers
                b_Daibechda(0) = False
                b_Daibechda(1) = False
                b_Daibechda(2) = False
                Do While (((b_Daibechda(0) And b_Daibechda(1)) And b_Daibechda(2)) = False)
                    PD.DocumentName = "order"
                    PD.PrinterSettings.PrinterName = printer_name
                    PD.Print()
                    Me.Refresh()
                Loop
            Next
            PD.DocumentName = "check"
            PD.PrinterSettings.PrinterName = printerSettings.PrinterName
            Using conn As New SqlClient.SqlConnection(LOCAL_CONN_STR)
                Using comm As New SqlClient.SqlCommand()
                    comm.Connection = conn
                    comm.CommandType = CommandType.Text
                    comm.CommandText = "update pos_salelines set order_printed = 1 where check_n = @check_n and order_printed = 0"
                    comm.Parameters.Add("@check_n", SqlDbType.Int).Value = Check_Number
                    conn.Open()
                    comm.ExecuteNonQuery()
                End Using
            End Using

            refresh_Form()
        End If
    End Sub

    Private Sub btnPrintBill_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintBill.Click
        frmNumpad.Visible = False
        End_Of_Prebill(8)
    End Sub

    Private Sub lbl_Saxeli_SizeChanged(sender As Object, e As EventArgs) Handles lbl_Saxeli.SizeChanged
        btn_EditUser.Left = lbl_Saxeli.Left + lbl_Saxeli.Width + 6
    End Sub

    Dim fusers As New FUserSelect()
    Public personnel_list As List(Of String) = Nothing

    Private Sub btn_EditUser_Click(sender As Object, e As EventArgs) Handles btn_EditUser.Click
        frmNumpad.Visible = False
        FSaleSublines.Visible = False
        FillPersonnel()

        fusers.Visible = True
        If fusers.SelectedCellIndex > -1 And fusers.GridF.Rows.Count > 0 Then
            fusers.GridF.Rows(fusers.SelectedCellIndex).Cells(0).Selected = True
        End If
        fusers.BringToFront()
    End Sub

    Private Sub FillPersonnel()
        If personnel_list Is Nothing Then
            personnel_list = New List(Of String)
            Using conn As New SqlClient.SqlConnection(LOCAL_CONN_STR)
                Using comm As New SqlClient.SqlCommand()
                    comm.Connection = conn
                    comm.CommandType = CommandType.Text
                    comm.CommandText = "select useris_name from users where role != 9"
                    conn.Open()
                    Using reader As SqlClient.SqlDataReader = comm.ExecuteReader()
                        While reader.Read()
                            personnel_list.Add(reader.Item("useris_name").ToString())
                        End While
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub txt_Guests_Click(sender As Object, e As EventArgs) Handles txt_Guests.Click
        FSaleSublines.Visible = False

        frmNumpad.Visible = False
        frmNumpad.Left = panel_OrderCtrls.Left - frmNumpad.Width
        frmNumpad.Top = panel_OrderCtrls.Top
        frmNumpad.fSender = Me
        frmNumpad.Visible = True
        Me.Focus()
        txt_Guests.SelectAll()
    End Sub

    Private Sub btn_Line_Click(sender As Object, e As EventArgs) Handles btn_Line.Click
        frmNumpad.Visible = False
        FSaleSublines.Visible = False

        Dim row As DataGridViewRow
        If DGV_Sales.SelectedCells IsNot Nothing And DGV_Sales.SelectedCells.Count > 0 And DGV_Sales.SelectedCells(0).ColumnIndex <> 4 Then
            row = DGV_Sales.Rows(DGV_Sales.SelectedCells(0).RowIndex)
        Else
            row = DGV_Sales.Rows(DGV_Sales.Rows.Count - 1)
        End If

        If row.DividerHeight = 4 Then
            row.DividerHeight = 0
        Else
            row.DividerHeight = 4
        End If
        Using conn As New SqlClient.SqlConnection(LOCAL_CONN_STR)
            Using comm As New SqlClient.SqlCommand()
                comm.Connection = conn
                comm.CommandType = CommandType.Text
                comm.CommandText = "update pos_salelines set order_rank = @rank where check_n = @check_n and id = @id"
                comm.Parameters.Add("@rank", SqlDbType.Int).Value = Convert.ToInt32(row.DividerHeight / 4)
                comm.Parameters.Add("@check_n", SqlDbType.Int).Value = Check_Number
                comm.Parameters.Add("@id", SqlDbType.Int).Value = row.Cells(6).Value
                conn.Open()
                comm.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub txt_Guests_Validated(sender As Object, e As EventArgs) Handles txt_Guests.Validated
        If OrderedTable IsNot Nothing And IsNumeric(txt_Guests.Text) Then
            OrderedTable.Guests = Val(txt_Guests.Text)
            If OrderedTable.CheckN.HasValue Then
                Using conn As New SqlClient.SqlConnection(LOCAL_CONN_STR)
                    Using comm As New SqlClient.SqlCommand()
                        comm.Connection = conn
                        comm.CommandType = CommandType.Text
                        comm.CommandText = "update table_orders set guests = @guests where check_n = @check_n"
                        comm.Parameters.Add("@check_n", SqlDbType.Int).Value = OrderedTable.CheckN
                        comm.Parameters.Add("@guests", SqlDbType.Int).Value = OrderedTable.Guests
                        conn.Open()
                        comm.ExecuteNonQuery()
                    End Using
                End Using
            End If
        End If
    End Sub

    Private Sub txt_Guests_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Guests.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.Handled = True
                e.SuppressKeyPress = True
                txt_kodi.Focus()
        End Select

    End Sub

    Private Sub btn_BookinsReport_Click(sender As Object, e As EventArgs) Handles btn_BookinsReport.Click
        frmNumpad.Visible = False
        FSaleSublines.Visible = False
        Using frmBookings As New frmBookingsReport()
            frmBookingsReport.ShowDialog()
        End Using
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        frmNumpad.Visible = False
        refresh_Form()
    End Sub
End Class
