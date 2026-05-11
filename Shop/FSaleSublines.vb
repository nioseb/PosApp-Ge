Public Class FSaleSublines
    Dim screen_X As Integer
    Dim screen_Y As Integer
    Dim a_WonisStatusebi As New ArrayList
    Dim a_NulebisStatusebi As New ArrayList
    Dim DS1 As New DataSet

    Public pId As Integer

    Private Sub area_Control()
        '##### ეკრანის კონტროლი
        Const KODI_SIGRDZE As Short = 160
        Dim JGUFI_SIGRDZE As Integer
        Dim DASAXELEBA_SIGRDZE As Integer
        Const FASI_SIGRDZE As Short = 0
        Const RAODENOBA_SIGRDZE As Short = 0
        Const JAMI_SIGRDZE As Short = 0

        'Dim Screens() As System.Windows.Forms.Screen = System.Windows.Forms.Screen.AllScreens
        screen_X = Width 'Screens(0).WorkingArea.Width
        screen_Y = Height 'Screens(0).WorkingArea.Height
        DGV_Sales.Left = 2
        DGV_Sales.Top = 0

        JGUFI_SIGRDZE = 0 'Math.Round((screen_X - KODI_SIGRDZE - 22) * 0.4, 0)
        DASAXELEBA_SIGRDZE = Math.Round((screen_X - KODI_SIGRDZE - JGUFI_SIGRDZE - 22), 0)

        'DGV_Price.Width = KODI_SIGRDZE + DASAXELEBA_SIGRDZE + 16
        DGV_Sales.Width = KODI_SIGRDZE + JGUFI_SIGRDZE + DASAXELEBA_SIGRDZE + 3

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
        btnRemove.Left = DGV_Sales.Left + KODI_SIGRDZE + DASAXELEBA_SIGRDZE - btnRemove.Width
    End Sub

    Private Sub FSaleSublines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        area_Control()
        Load_Sublines()

        'DS1.Clear()
        'Dim Conn1 As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        'Dim Comm1 As New System.Data.SqlClient.SqlCommand
        ''##### price_list-ის ბუფერში გადმოტანა
        'Dim SDA1 As New System.Data.SqlClient.SqlDataAdapter
        'Comm1.Connection = Conn1
        'Comm1.CommandText = "SELECT TOP 1 kodi, jgufi, dasaxeleba, gas_fasi, CASE wonis WHEN 1 THEN N'წონის' ELSE N'ცალობის' END wonis FROM dbo.price_list ORDER BY jgufi, dasaxeleba"
        'SDA1.SelectCommand = Comm1
        'SDA1.Fill(DS1, "price_list")

        'Dim dr As DataRow = DS1.Tables("price_list").NewRow
        ''dr.Item(0) = String.Empty
        ''dr.Item(1) = String.Empty
        ''dr.Item(2) = String.Empty
        ''dr.Item(3) = String.Empty
        ''dr.Item(4) = String.Empty
        'DS1.Tables("price_list").Rows.InsertAt(dr, 0)
        'txt_kodi.SelectedIndex = -1
        'txt_kodi.Items.Clear()
        'txt_kodi.ColumnNum = 5
        'txt_kodi.SourceDataString = New String(4) {"kodi", "jgufi", "dasaxeleba", "gas_fasi", "wonis"}
        'txt_kodi.SourceDataTable = DS1.Tables("price_list")
    End Sub

    Private Sub txt_kodi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kodi.Click
        btnRemove.Visible = False
        'frmNumpad.Visible = False
        'If txt_kodi.Top + txt_kodi.FindForm().Top < txt_kodi.Parent.Height - frmNumpad.Height Then
        '    frmNumpad.Left = txt_kodi.Left
        '    frmNumpad.Top = txt_kodi.Top + txt_kodi.Parent.Top + txt_kodi.FindForm().Top + txt_kodi.Height + 1
        'Else
        '    frmNumpad.Left = txt_kodi.Left
        '    frmNumpad.Top = (txt_kodi.Top + txt_kodi.Parent.Top + txt_kodi.FindForm().Top) - frmNumpad.Height - 1
        'End If
        'frmNumpad.fSender = Me
        'frmNumpad.Visible = True
        'Me.Focus()
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

    Private Sub shemdegi()
        txt_kodi.Focus()
        txt_kodi.Top += 35

        DGV_Sales.Height += 35
        DGV_Sales.Rows.Add()
    End Sub

    Private Sub txt_kodi_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_kodi.KeyDown
        If Not IsNumeric(txt_kodi.Text) Then
            txt_kodi.Text = String.Empty
        End If
        'Dim fThumbs As New frmThumbs
        Select Case e.KeyCode
            Case Keys.Enter
x:              If txt_kodi.Text <> String.Empty Then
                    If Fmain.lbl_SaleType.Text = "გაყიდვა" Then
                        Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
                        Dim Comm As New System.Data.SqlClient.SqlCommand
                        Dim Reader As System.Data.SqlClient.SqlDataReader
                        Dim b_DGV_Sales_Focus As Boolean
                        Dim b_Not_In_Price As Boolean = True
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
                                If (Fmain.b_From_Scanner Or (Not b_Lock_Status1)) Or (Fmain.Scanner_N = 0) Then
                                    Dim i_Pozicia As Integer = f_Arsebulis_Pozicia(txt_kodi.Text)
                                    If i_Pozicia <> -1 Then

                                        If M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(i_Pozicia).Cells(6).Value), Val(DGV_Sales.Rows(i_Pozicia).Cells(4).Value) + 0) Then
                                            DGV_Sales.Rows(i_Pozicia).Cells(4).Value = Val(DGV_Sales.Rows(i_Pozicia).Cells(4).Value) + 0
                                            DGV_Sales.Rows(i_Pozicia).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(i_Pozicia).Cells(3).Value) * Val(DGV_Sales.Rows(i_Pozicia).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
                                        Else
                                            Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                            Fmain.Write_In_Log("Err_Ver_Gatarda: " & Fmain.Check_Number & " - " & txt_kodi.Text)
                                        End If

                                    Else
                                        Dim b_Gaixsna = True
                                        Dim d_Raodenoba As Double = 0
                                        If Not Reader.Item(4) Then
                                            d_Raodenoba = 1
                                        End If
                                        If b_Gaixsna Then
                                            Dim id As Integer = M_SQL.Do_SaleLines(Fmain.Check_Number, Reader.Item(0), d_Raodenoba, Reader.Item(3), String.Empty, pId)
                                            shemdegi()
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value = id

                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value = Reader.Item(0)
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(1).Value = Reader.Item(1)
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(2).Value = Reader.Item(2)
                                            DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value = Reader.Item(3)
                                            'DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                                            If Reader.Item(4) Then
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = 0
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = 0
                                                b_DGV_Sales_Focus = True
                                            Else
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = 1
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Reader.Item(3)
                                            End If
                                            a_WonisStatusebi.Add(Reader.Item(4))
                                            a_NulebisStatusebi.Add(1)
                                        Else
                                            Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                            Fmain.Write_In_Log("Err_Ver_Gatarda: " & Fmain.Check_Number & " - " & txt_kodi.Text)

                                        End If
                                    End If
                                    txt_kodi.Text = String.Empty
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
                                    If (Fmain.b_From_Scanner Or (Not b_Lock_Status2)) Or (Fmain.Scanner_N = 0) Then
                                        Dim i_Pozicia2 As Integer = f_Arsebulis_Pozicia(s_Code)
                                        If i_Pozicia2 <> -1 Then
                                            If Reader.Item(4) Then
                                                If M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(i_Pozicia2).Cells(6).Value), Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + i_raod / 1000) Then
                                                    DGV_Sales.Rows(i_Pozicia2).Cells(4).Value = Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + i_raod / 1000
                                                    DGV_Sales.Rows(i_Pozicia2).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value) * Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
                                                Else
                                                    Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                                    Fmain.Write_In_Log("Err_Ver_Gatarda: " & Fmain.Check_Number & " - " & txt_kodi.Text)
                                                End If
                                            Else
                                                If i_raod > 100 Then
                                                    If M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(i_Pozicia2).Cells(6).Value), Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + 1) Then
                                                        DGV_Sales.Rows(i_Pozicia2).Cells(4).Value = Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + 1
                                                        DGV_Sales.Rows(i_Pozicia2).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value) * Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
                                                    Else
                                                        Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                                        Fmain.Write_In_Log("Err_Ver_Gatarda: " & Fmain.Check_Number & " - " & txt_kodi.Text)
                                                    End If
                                                Else
                                                    If M_SQL.Update_SaleLines(Convert.ToInt32(DGV_Sales.Rows(i_Pozicia2).Cells(6).Value), Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + i_raod) Then
                                                        DGV_Sales.Rows(i_Pozicia2).Cells(4).Value = Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value) + i_raod
                                                        DGV_Sales.Rows(i_Pozicia2).Cells(5).Value = Math.Round(Val(DGV_Sales.Rows(i_Pozicia2).Cells(3).Value) * Val(DGV_Sales.Rows(i_Pozicia2).Cells(4).Value), 2, MidpointRounding.AwayFromZero)
                                                    Else
                                                        Mesigi("ვერ გატარდა, სცადეთ თავიდან")
                                                        Fmain.Write_In_Log("Err_Ver_Gatarda: " & Fmain.Check_Number & " - " & txt_kodi.Text)
                                                    End If
                                                End If
                                            End If
                                        Else

                                            Dim b_Gaixsna As Boolean = True

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

                                            Dim id = M_SQL.Do_SaleLines(Fmain.Check_Number, Reader.Item(0), d_Raodenoba, Reader.Item(3), String.Empty, pId)
                                            If id > 0 Then

                                                shemdegi()
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value = id
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(0).Value = Reader.Item(0)
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(1).Value = Reader.Item(1)
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(2).Value = Reader.Item(2)
                                                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(3).Value = Reader.Item(3)
                                                'DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
                                                If Reader.Item(4) Then
                                                    DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = i_raod / 1000
                                                    DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Math.Round(i_raod * Reader.Item(3) / 1000, 2, MidpointRounding.AwayFromZero)
                                                Else
                                                    If i_raod > 100 Then
                                                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = 1
                                                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Reader.Item(3)
                                                    Else
                                                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Value = i_raod
                                                        DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(5).Value = Math.Round(i_raod * Reader.Item(3), 2, MidpointRounding.AwayFromZero)
                                                    End If
                                                End If
                                                a_WonisStatusebi.Add(Reader.Item(4))
                                                a_NulebisStatusebi.Add(1)
                                            Else
                                                Fmain.Write_In_Log("Err_Ver_Gatarda: " & Fmain.Check_Number & " - " & txt_kodi.Text)
                                                Mesigi("ვერ გატარდა, სცადეთ თავიდან")

                                            End If
                                        End If
                                        txt_kodi.Text = String.Empty
                                    End If
                                End While
                                Reader.Close()
                            End If
                            '____________________________
                        Catch ex As Exception
                            Mesigi(ex.Message, "Err_CodeKeyDown_Enter:")
                            Fmain.Write_In_Log("Err_CodeKeyDown_Enter: " & ex.Message + Environment.NewLine + ex.StackTrace)
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
                    txt_kodi.Text = String.Empty
                    'txt_kodi.SelectedText = String.Empty
                    'txt_kodi.Text = String.Empty
                End If
                Fmain.b_From_Scanner = False
            Case Keys.Up
                If Not txt_kodi.DroppedDown Then
                    If DGV_Sales.Rows.Count > 0 Then
                        'DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(4).Selected = True
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
                    txt_kodi.Text = String.Empty
                End If
                'txt_kodi.SelectedText = String.Empty
                'txt_kodi.Text = String.Empty
            Case Keys.F2
                txt_kodi.SelectionStart = txt_kodi.Text.Length
                txt_kodi.SelectionLength = 0
        End Select
    End Sub

    Public Sub Load_Sublines()
        Dim Conn1 As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Dim Reader As SqlClient.SqlDataReader
        Dim p_Type As Short = 0
        Comm.Connection = Conn1

        If DGV_Sales.Columns.Count < 7 Then
            Dim column As New DataGridViewColumn()
            column.Name = "ID"
            column.HeaderText = "ID"
            column.Visible = True
            column.CellTemplate = DGV_Sales.Columns(4).CellTemplate.Clone()
            column.Visible = False
            DGV_Sales.Columns.Add(column)
        End If

        DGV_Sales.Rows.Clear()
        DGV_Sales.Height = 30
        txt_kodi.Top = 28
        Try
            Conn1.Open()
            Comm.CommandText = "SELECT code, quantity, price, Round(quantity * price,2) amount, ttime, jgufi, dasaxeleba, wonis, 0 payment_type, pos_salelines.id FROM pos_salelines LEFT JOIN price_list ON code=kodi WHERE pos_salelines.parentid=@pid"
            'AND ('" & s_Check_N & "' NOT IN (SELECT ttime FROM pos_salelines))
            Comm.Parameters.Add("@pid", SqlDbType.Int).Value = pId

            Reader = Comm.ExecuteReader
            While Reader.Read
                shemdegi()
                DGV_Sales.Rows(DGV_Sales.Rows.Count - 1).Cells(6).Value = Reader.Item(9)
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
                p_Type = Reader.Item(8)
            End While
            Reader.Close()
            Dim i_RowCount As Integer = DGV_Sales.Rows.Count
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Sale_Back:")
            Fmain.Write_In_Log("Err_Sale_Back: " & ex.Message)
        Finally
            Conn1.Close()
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmNumpad.Visible = False
        frmThumbs.isFmain = False
        btnRemove.Visible = False

        frmThumbs.WindowState = FormWindowState.Normal
        'frmThumbs.Left = Screen.AllScreens(0).WorkingArea.Width + 10
        frmThumbs.WindowState = FormWindowState.Maximized
        frmThumbs.Visible = True
    End Sub

    Private Sub txt_kodi_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kodi.Enter
        'txt_kodi.SelectionStart = txt_kodi.Text.Length
        'txt_kodi.SelectionLength = 0
    End Sub

    Private Sub txt_kodi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kodi.Leave
        'txt_kodi.SelectionStart = txt_kodi.Text.Length
        'txt_kodi.SelectionLength = 0
    End Sub

    Private Sub DGV_Sales_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Sales.CellClick
        btnRemove.Top = DGV_Sales.Parent.Top + e.RowIndex * DGV_Sales.RowTemplate.Height + DGV_Sales.ColumnHeadersHeight
        btnRemove.Visible = True
    End Sub

    Private Sub Panel_Body_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_Body.Click
        btnRemove.Visible = False
    End Sub

    Private Sub FSaleSublines_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible = False Then
            Me.btnRemove.Visible = False
        End If

        Fmain.ToolStripDropDownButton1.Enabled = Not Me.Visible
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim id As Integer = Convert.ToInt32(DGV_Sales.Rows(DGV_Sales.SelectedCells(0).RowIndex).Cells(6).Value)
        M_SQL.Delete_SaleLine(id)
        DGV_Sales.Rows.RemoveAt(DGV_Sales.SelectedCells(0).RowIndex)

        txt_kodi.Top -= DGV_Sales.RowTemplate.Height

        DGV_Sales.Height -= DGV_Sales.RowTemplate.Height

        btnRemove.Visible = False
    End Sub
End Class