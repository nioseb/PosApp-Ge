Imports Excel = Microsoft.Office.Interop.Excel

Module M_SQL

    Public Function Do_SaleLines(ByVal i_N As Integer, ByVal s_Code As String, ByVal d_Quantity As Double, ByVal d_Price As Double, ByVal s_Ttime As String, Optional ByVal parent_id As Integer = 0) As Integer
        Dim ret_val As Integer
        Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Comm.Connection = Conn
        Comm.CommandText = "INSERT INTO pos_salelines (check_n, code, quantity, price, ttime, parentId) VALUES (@check_n, @code, @quantity, @price, @ttime, @parentId)"
        Try
            Conn.Open()
            Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = i_N
            Comm.Parameters.Add("@code", SqlDbType.NVarChar, 16).Value = s_Code
            Comm.Parameters.Add("@quantity", SqlDbType.Float).Value = d_Quantity
            Comm.Parameters.Add("@price", SqlDbType.Float).Value = d_Price
            Comm.Parameters.Add("@ttime", SqlDbType.NVarChar, 15).Value = DBNull.Value
            If s_Ttime <> String.Empty Then
                Comm.Parameters.Item("@ttime").Value = s_Ttime
            End If
            Comm.Parameters.Add("@parentId", SqlDbType.Int).Value = DBNull.Value
            If parent_id <> 0 Then
                Comm.Parameters("@parentId").Value = parent_id
            End If
            Comm.ExecuteNonQuery()
            Comm.Parameters.Clear()
            Comm.CommandText = "SELECT MAX(id) AS id FROM Pos_Salelines WHERE check_n = " + i_N.ToString() + " AND code = '" + s_Code + "'"
            ret_val = Convert.ToInt32(Comm.ExecuteScalar())
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Do_Salelines:")
            Fmain.Write_In_Log("Err_Do_Salelines: " & i_N & " - " & s_Code & " - " & d_Quantity & "  " & ex.Message)
            ret_val = 0
        Finally
            Conn.Close()
        End Try
        Return (ret_val)
    End Function

    Public Function Open_Sale(ByVal i_N As Integer, Optional ByVal sale_type As Integer = 1, Optional ByVal table_id As Integer? = Nothing, Optional ByVal supervisor As String = Nothing, Optional ByVal guests As Integer? = Nothing) As Boolean
        Dim ret_val As Boolean
        Using Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
            Dim Comm As New SqlClient.SqlCommand
            Comm.Connection = Conn
            Comm.CommandText = "INSERT INTO pos_sales (check_n, sale_date, sale_type, market_n, pos_n, person_id, check_amount, payment_type, status, close_status, table_id) VALUES (@check_n, @sale_date, @sale_type, @market_n, @pos_n, @person_id, 0, 0, 0, 0, @table_id)"
            Try
                Conn.Open()
                Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = i_N
                Comm.Parameters.Add("@sale_date", SqlDbType.DateTime).Value = Now
                Comm.Parameters.Add("sale_type", SqlDbType.Int).Value = sale_type
                Comm.Parameters.Add("@market_n", SqlDbType.TinyInt).Value = Fmain.Market_N
                Comm.Parameters.Add("@pos_n", SqlDbType.TinyInt).Value = Fmain.Pos_N
                Comm.Parameters.Add("@person_id", SqlDbType.NVarChar, 16).Value = Fmain.p_Person.ID
                Comm.Parameters.Add("@table_id", SqlDbType.Int).Value = DBNull.Value
                If Not table_id Is Nothing Then
                    Comm.Parameters("@table_id").Value = table_id
                End If
                Comm.ExecuteNonQuery()
                Comm.Parameters.Clear()
                If sale_type = 8 And Not table_id Is Nothing Then
                    Comm.CommandText = "INSERT INTO table_orders (table_id, check_n, order_closed, open_date, supervisor, guests) VALUES (@table_id, @check_n, 0, @open_date, @supervisor, @guests)"
                    Comm.Parameters.Add("@table_id", SqlDbType.Int).Value = table_id
                    Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = i_N
                    Comm.Parameters.Add("@open_date", SqlDbType.DateTime).Value = Now
                    Comm.Parameters.Add("@supervisor", SqlDbType.NVarChar, 100).Value = IIf(supervisor Is Nothing, DBNull.Value, supervisor)
                    Comm.Parameters.Add("@guests", SqlDbType.Int).Value = IIf(guests Is Nothing, DBNull.Value, guests)
                    Comm.ExecuteNonQuery()
                End If
                ret_val = True
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Open_Sale:")
                Fmain.Write_In_Log("Err_Open_Sale: " & i_N & "  " & ex.Message)
                ret_val = False
            Finally
                Conn.Close()
            End Try
        End Using
        Return (ret_val)
    End Function

    Public Function Close_Sale(ByVal i_N As Integer, ByVal i_SaleType As Integer, ByVal d_CheckAmount As Double, ByVal i_PaymentType As Integer, Optional ByVal close As Boolean = True, Optional ByVal table_id As Integer? = Nothing, Optional ByVal supervisor As String = Nothing, Optional ByVal guests As Integer? = Nothing) As Boolean
        Dim ret_val As Boolean = False
        Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Comm.Connection = Conn

        Comm.CommandText = "UPDATE pos_sales SET sale_date = @sale_date, sale_type = @sale_type, check_amount = @check_amount, payment_type = @payment_type, status = 0, table_id = @table_id WHERE check_n = @check_n"
        Conn.Open()

        Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = i_N
        Comm.Parameters.Add("@sale_date", SqlDbType.DateTime).Value = Now
        Comm.Parameters.Add("@sale_type", SqlDbType.TinyInt).Value = i_SaleType
        Comm.Parameters.Add("@check_amount", SqlDbType.Float).Value = d_CheckAmount
        Comm.Parameters.Add("@payment_type", SqlDbType.TinyInt).Value = i_PaymentType
        Comm.Parameters.Add("@table_id", SqlDbType.Int).Value = DBNull.Value
        If Not table_id Is Nothing Then
            Comm.Parameters("@table_id").Value = table_id
        End If
        Comm.ExecuteNonQuery()

        Comm.CommandText = "select s.id from pos_salelines s inner join items i on s.code = i.itmKEY where s.check_n = @check_n and i.isMenu = 1 and s.parentid is null and s.quantity > 0"
        Comm.Parameters.Clear()
        Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = i_N
        Dim reader As SqlClient.SqlDataReader = Comm.ExecuteReader()
        Dim menuSids As New List(Of Integer)
        Dim i As Integer = 0
        While reader.Read()
            menuSids.Add(reader(0))
            i = i + 1
        End While
        reader.Close()

        Comm.Parameters.Add("@pid", SqlDbType.Int)
        For Each pid As Integer In menuSids
            Comm.CommandText = "select count(*) from pos_salelines where check_n = @check_n and parentId = @pid"
            Comm.Parameters("@pid").Value = pid
            Dim count As Integer = Comm.ExecuteScalar()
            If count < 1 Then
                Throw New Exception("მენიუ არ არის შევსებული")
            End If
        Next
        Comm.Parameters.Clear()

        Try
            If close = True And i_SaleType <> 8 Then
                Comm.CommandText = "UPDATE pos_sales SET close_status = @close WHERE check_n = @check_n"
                Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = i_N
                Comm.Parameters.Add("@close", SqlDbType.Bit).Value = close
                'If i_SaleType = 6 Then
                '    Comm.Parameters("@status").Value = 1
                'Else
                '    Comm.Parameters("@status").Value = 0
                'End If
                Comm.ExecuteNonQuery()
                Comm.Parameters.Clear()
                Comm.CommandText = "UPDATE table_orders SET order_closed = 1, close_date = getdate(), supervisor = isnull(@supervisor, supervisor), guests = isnull(@guests, guests) WHERE check_n = @check_n"
                Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = i_N
                Comm.Parameters.Add("@supervisor", SqlDbType.NVarChar, 50).Value = DBNull.Value
                Comm.Parameters.Add("@guests", SqlDbType.Int).Value = DBNull.Value
                If Not String.IsNullOrEmpty(supervisor) Then
                    Comm.Parameters("@supervisor").Value = supervisor
                End If
                If guests.HasValue Then
                    Comm.Parameters("@guests").Value = guests.Value
                End If
                Comm.ExecuteNonQuery()
                Comm.Parameters.Clear()
            End If
            ret_val = True
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Close_Sale: " & i_N & " - " & d_CheckAmount & "  " & ex.Message)
            Throw New Exception(ex.Message)
        Finally
            Conn.Close()
        End Try
        Return (ret_val)
    End Function

    Public Function Update_CloseStatus(ByVal check_n As Integer, ByVal close As Boolean, ByVal amount As Double, Optional ByVal fiscalDocId As String = "") As Boolean
        Dim ret_val As Boolean
        Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Comm.Connection = Conn
        Comm.CommandText = "UPDATE pos_sales SET close_status=@close, check_amount=@amount, fiscal_docid = @fiscalDocId WHERE check_n=@check_n"
        Try
            Conn.Open()
            Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = check_n
            Comm.Parameters.Add("@close", SqlDbType.Bit).Value = close
            Comm.Parameters.Add("@amount", SqlDbType.Float).Value = amount
            Comm.Parameters.Add("@fiscalDocId", SqlDbType.NVarChar, 64).Value = IIf(String.IsNullOrEmpty(fiscalDocId), DBNull.Value, fiscalDocId)
            Comm.ExecuteNonQuery()
            Comm.Parameters.Clear()
            If close = True Then
                Comm.CommandText = "UPDATE table_orders SET order_closed = 1, close_date = getdate() WHERE check_n = @check_n and order_closed = 0"
                Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = check_n
                Comm.ExecuteNonQuery()
                Comm.Parameters.Clear()
            End If
            ret_val = True
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Update_CloseStatus:")
            Fmain.Write_In_Log("Err_Update_CloseStatus: " & check_n & " - " & close & "  " & ex.Message)
            ret_val = False
        Finally
            Conn.Close()
        End Try
        Return (ret_val)
    End Function

    Public Function Update_SaleLines(ByVal id As Integer, ByVal d_Quantity As Double) As Boolean
        Dim ret_val As Boolean
        Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Comm.Connection = Conn
        Comm.CommandText = "UPDATE pos_salelines SET quantity=@quantity WHERE id=@id"
        Try
            Conn.Open()
            Comm.Parameters.Add("@id", SqlDbType.Int).Value = id
            Comm.Parameters.Add("@quantity", SqlDbType.Float).Value = d_Quantity
            Comm.ExecuteNonQuery()
            Comm.Parameters.Clear()
            ret_val = True
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Update_Salelines:")
            Fmain.Write_In_Log("Err_Update_Salelines: " & id & " - " & d_Quantity & "  " & ex.Message)
            ret_val = False
        Finally
            Conn.Close()
        End Try
        Return (ret_val)
    End Function

    Public Sub Update_For_Discount(ByVal i_N As Integer, ByVal s_Code As String, ByVal d_Price As Double, ByVal s_T As String)
        Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand("UPDATE pos_salelines SET price=@price, ttime=@ttime WHERE check_n=@check_n AND code=@code AND parentId is null", Conn)
        Try
            Conn.Open()
            Comm.Parameters.Add("@check_n", SqlDbType.Int).Value = i_N
            Comm.Parameters.Add("@code", SqlDbType.NVarChar, 16).Value = s_Code
            Comm.Parameters.Add("@price", SqlDbType.Float).Value = d_Price
            Comm.Parameters.Add("@ttime", SqlDbType.NVarChar, 15).Value = s_T
            Comm.ExecuteNonQuery()
            Comm.Parameters.Clear()
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Update_For_Discount:")
            Fmain.Write_In_Log("Err_Update_For_Discount: " & i_N & " - " & s_Code & "  " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Public Sub Delete_Old_Sales()
        'Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        'Dim Comm As New SqlClient.SqlCommand
        'Comm.Connection = Conn
        'Comm.CommandText = "DELETE pos_sales WHERE sale_date < @sale_date AND status=1"
        'Try
        '    Conn.Open()
        '    Comm.Parameters.Add("@sale_date", SqlDbType.DateTime).Value = Now.AddDays(-30)
        '    Comm.ExecuteNonQuery()
        '    Comm.Parameters.Clear()
        'Catch ex As Exception
        '    Mesigi(ex.Message, "Err_Delete_Old_Sales:")
        '    Fmain.Write_In_Log("Err_Delete_Old_Sales: " & ex.Message)
        'Finally
        '    Conn.Close()
        'End Try
    End Sub

    Public Function Delete_SaleLine(ByVal id As Integer) As Boolean
        Dim ret_val As Boolean
        Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Comm.Connection = Conn
        Comm.CommandText = "delete from pos_salelines where id = @id"
        Try
            Conn.Open()
            Comm.Parameters.Add("@id", SqlDbType.Int).Value = id

            Comm.ExecuteNonQuery()
            ret_val = True
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Do_Salelines:")
            Fmain.Write_In_Log("Err_Do_Salelines: " & id & " - " & ex.Message)
            ret_val = False
        Finally
            Conn.Close()
        End Try
        Return (ret_val)
    End Function

    Public Function IsMenu(ByVal code As String) As Boolean
        Dim Conn As New SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim command As New SqlClient.SqlCommand("select isMenu from Items where itmKey = @code", Conn)
        command.Parameters.AddWithValue("@code", code)
        Try
            Conn.Open()
            Return Convert.ToBoolean(command.ExecuteScalar())
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Get_ItemIsMenu: " & ex.Message)
            Mesigi(ex.Message, "Err_Get_ItemIsMenu")
        Finally
            Conn.Close()
        End Try
    End Function

    Public Function GetDescription(ByVal code As String) As String
        Dim retValue As String = String.Empty

        Dim Conn As New SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim command As New SqlClient.SqlCommand("select itmNOTE from Items where itmKey = @code", Conn)
        command.Parameters.AddWithValue("@code", code)
        Try
            Conn.Open()
            retValue = Convert.ToString(command.ExecuteScalar())
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Get_ItemIsMenu: " & ex.Message)
            Mesigi(ex.Message, "Err_Get_ItemIsMenu")
        Finally
            Conn.Close()
        End Try

        Return retValue
    End Function

    Public Function GetCompanyName() As String
        Dim retValue As String = String.Empty

        Dim Conn As New SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim command As New SqlClient.SqlCommand("select company_name from settings", Conn)

        Try
            Conn.Open()
            retValue = Convert.ToString(command.ExecuteScalar())
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Get_CompanyName: " & ex.Message)
            Mesigi(ex.Message, "Err_Get_CompanyName")
        Finally
            Conn.Close()
        End Try

        Return retValue
    End Function

    Public Function GetUiTerms() As Dictionary(Of String, String)
        Dim retValue As New Dictionary(Of String, String)

        Dim Conn As New SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim command As New SqlClient.SqlCommand("select TermKey, TermValue from UITerms where TypeCode is null", Conn)
        Dim reader As SqlClient.SqlDataReader

        Try
            Conn.Open()
            reader = command.ExecuteReader
            While reader.Read
                retValue.Add(reader.Item("TermKey").ToString(), reader.Item("TermValue").ToString())
            End While
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Get_UITerms: " & ex.Message)
            Mesigi(ex.Message, "Err_Get_UITerms")
        Finally
            Conn.Close()
        End Try

        Return retValue
    End Function

    Public Function GetCheckTerms() As Dictionary(Of String, String)
        Dim retValue As New Dictionary(Of String, String)

        Dim Conn As New SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim command As New SqlClient.SqlCommand("select TermKey, TermValue from UITerms where TypeCode = 'PosReceipt'", Conn)
        Dim reader As SqlClient.SqlDataReader

        Try
            Conn.Open()
            reader = command.ExecuteReader
            While reader.Read
                retValue.Add(reader.Item("TermKey").ToString(), reader.Item("TermValue").ToString())
            End While
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Get_CheckTerms: " & ex.Message)
            Mesigi(ex.Message, "Err_Get_CheckTerms")
        Finally
            Conn.Close()
        End Try

        Return retValue
    End Function

    Public Sub Shrink_pos_db()
        Dim Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand
        Dim reader As SqlClient.SqlDataReader
        Dim b_Exec_Shrink As Boolean = True
        Comm.Connection = Conn
        Comm.CommandText = "SELECT date1 FROM date_times"
        Try
            Conn.Open()
            reader = Comm.ExecuteReader
            While reader.Read
                If Not reader.IsDBNull(0) Then
                    If Now.AddDays(-30) < reader.GetDateTime(0) Then
                        b_Exec_Shrink = False
                    End If
                End If
            End While
            reader.Close()
            If b_Exec_Shrink Then
                Comm.CommandText = "DBCC SHRINKDATABASE (pos_db)"
                Comm.ExecuteNonQuery()
                Comm.CommandText = "UPDATE date_times SET date1=@date1"
                Comm.Parameters.Add("@date1", SqlDbType.DateTime).Value = Now
                Comm.ExecuteNonQuery()
                Comm.Parameters.Clear()
                Fmain.Write_In_Log("Shrink_pos_db: Daishrinka")
            End If
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Shrink_pos_db:")
            Fmain.Write_In_Log("Err_Shrink_pos_db: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    'Public Sub Update_Price()
    '    Dim Thr As New Threading.Thread(AddressOf Reload_Price)
    '    Thr.Start()
    'End Sub
    Public Sub Update_MasterData()
        Dim ConnS As New System.Data.SqlClient.SqlConnection(Fmain.SERVER_CONN_STR)
        Try
            ConnS.Open()
            Fmain.lbl_Status.ForeColor = Color.Green
        Catch ex As Exception
            Fmain.b_Servertan_Aris_Kavshiri = False
            Fmain.lbl_Status.ForeColor = Color.Red
            Fmain.dt_Servertan_Kavshirisatvis = Now
            Fmain.Write_In_Log("servertan kavshiri ar aris: New_'PriceList'")
            Mesigi("სერვერთან კავშირი არ არის")
            Exit Sub
        End Try

        Dim s_conn As New SqlClient.SqlConnection()
        Dim l_conn As New SqlClient.SqlConnection()
        Dim s_cs, l_cs As String
        s_cs = Fmain.SERVER_CONN_STR
        l_cs = Fmain.LOCAL_CONN_STR

        Dim s_comm As New SqlClient.SqlCommand()
        Dim l_comm As New SqlClient.SqlCommand()

        Dim s_reader As SqlClient.SqlDataReader

        s_conn.ConnectionString = s_cs
        l_conn.ConnectionString = l_cs

        s_comm.CommandType = CommandType.StoredProcedure
        s_comm.CommandText = "sp_ItemGroupsByCompany"
        s_comm.Parameters.Add("@m_code", SqlDbType.Int).Value = Fmain.Market_N
        s_comm.Connection = s_conn

        l_comm.CommandType = CommandType.Text
        l_comm.CommandText = "DELETE FROM Items"
        l_comm.Connection = l_conn

        l_conn.Open()
        l_comm.ExecuteNonQuery()
        l_comm.CommandText = "DELETE FROM ItemGroups"
        l_comm.ExecuteNonQuery()
        l_comm.CommandText = "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ItemGroups_ItemGroups]') AND type = 'F') ALTER TABLE [dbo].[ItemGroups] DROP CONSTRAINT [FK_ItemGroups_ItemGroups]"
        l_comm.ExecuteNonQuery()

        l_comm.CommandText = "INSERT INTO ItemGroups select @itmgID, @itmgKEY, @itmgNAME, @itmgSID, @itmgPID, @dsID, @itmgAlterNAME"


        l_comm.Parameters.Add("@itmgID", SqlDbType.Int)
        l_comm.Parameters.Add("@itmgKEY", SqlDbType.NVarChar, 16)
        l_comm.Parameters.Add("@itmgNAME", SqlDbType.NVarChar, 100)
        l_comm.Parameters.Add("@itmgSID", SqlDbType.Int)
        l_comm.Parameters.Add("@itmgPID", SqlDbType.Int)
        l_comm.Parameters.Add("@dsID", SqlDbType.Int)
        l_comm.Parameters.Add("@itmgAlterNAME", SqlDbType.NVarChar, 100)

        s_conn.Open()
        s_reader = s_comm.ExecuteReader
        While s_reader.Read()
            l_comm.Parameters(0).Value = s_reader(0)
            l_comm.Parameters(1).Value = s_reader(1)
            l_comm.Parameters(2).Value = s_reader(2)
            l_comm.Parameters(3).Value = s_reader(3)
            l_comm.Parameters(4).Value = s_reader(4)
            l_comm.Parameters(5).Value = s_reader(5)
            l_comm.Parameters(6).Value = s_reader(6)
            l_comm.ExecuteNonQuery()
        End While
        l_comm.Parameters.Clear()
        s_reader.Close()

        l_comm.CommandText = "ALTER TABLE [dbo].[ItemGroups]  WITH NOCHECK ADD  CONSTRAINT [FK_ItemGroups_ItemGroups] FOREIGN KEY([itmgPID]) REFERENCES [dbo].[ItemGroups] ([itmgID])"
        l_comm.ExecuteNonQuery()

        s_comm.CommandText = "sp_ItemsByCompany"
        l_comm.CommandText = "INSERT INTO Items (itmID, itmKEY, itmNAME, itmgID, dmID, itmImage, itmAlterNAME, isMenu, itmNOTE) select @itmID, @itmKEY, @itmNAME, @itmgID, @dmID, @itmImage, @itmAlterNAME, @isMenu, @Description"

        l_comm.Parameters.Add("@itmID", SqlDbType.Int)
        l_comm.Parameters.Add("@itmKEY", SqlDbType.NVarChar, 16)
        l_comm.Parameters.Add("@itmNAME", SqlDbType.NVarChar, 100)
        l_comm.Parameters.Add("@itmgID", SqlDbType.Int)
        l_comm.Parameters.Add("@dmID", SqlDbType.Int)
        l_comm.Parameters.Add("@itmImage", SqlDbType.Image)
        l_comm.Parameters.Add("@itmAlterNAME", SqlDbType.NVarChar, 100)
        l_comm.Parameters.Add("@isMenu", SqlDbType.Bit)
        l_comm.Parameters.Add("@Description", SqlDbType.NVarChar, 250)

        s_reader = s_comm.ExecuteReader
        While s_reader.Read()
            l_comm.Parameters(0).Value = s_reader(0)
            l_comm.Parameters(1).Value = s_reader(1)
            l_comm.Parameters(2).Value = s_reader(2)
            l_comm.Parameters(3).Value = s_reader(3)
            l_comm.Parameters(4).Value = s_reader(4)
            l_comm.Parameters(5).Value = s_reader(5)
            l_comm.Parameters(6).Value = s_reader(6)
            l_comm.Parameters(7).Value = s_reader(7)
            l_comm.Parameters(8).Value = s_reader(8)

            l_comm.ExecuteNonQuery()
        End While
        l_comm.Parameters.Clear()
        s_reader.Close()

        l_comm.CommandText = "delete from UITerms"
        l_comm.ExecuteNonQuery()

        s_comm.Parameters.Clear()
        s_comm.CommandType = CommandType.Text
        s_comm.CommandText = "select Id, TermKey, TermValue from dbo.[zUITermValuesByLanguage](@uiLanguage, @typeCode)"
        s_comm.Parameters.AddWithValue("@uiLanguage", Fmain.UI_Language)
        s_comm.Parameters.AddWithValue("@typeCode", DBNull.Value)
        l_comm.CommandText = "insert into UITerms (Id, TermKey, TermValue, TypeCode) select @Id, @TermKey, @TermValue, @TypeCode"

        l_comm.Parameters.Add("@Id", SqlDbType.Int)
        l_comm.Parameters.Add("@TermKey", SqlDbType.NVarChar, 250)
        l_comm.Parameters.Add("@TermValue", SqlDbType.NVarChar, 250)
        l_comm.Parameters.Add("@TypeCode", SqlDbType.NVarChar, 32).Value = DBNull.Value

        s_reader = s_comm.ExecuteReader
        Dim c As Integer = 0
        While s_reader.Read
            c = s_reader(0)
            l_comm.Parameters(0).Value = c
            l_comm.Parameters(1).Value = s_reader(1)
            l_comm.Parameters(2).Value = s_reader(2)

            l_comm.ExecuteNonQuery()
        End While
        s_reader.Close()

        s_comm.Parameters("@typeCode").Value = "PosReceipt"
        l_comm.Parameters("@TypeCode").Value = "PosReceipt"
        s_reader = s_comm.ExecuteReader
        Fmain.CheckTerms.Clear()
        While s_reader.Read
            c = c + 1
            l_comm.Parameters(0).Value = c
            l_comm.Parameters(1).Value = s_reader(1)
            l_comm.Parameters(2).Value = s_reader(2)

            l_comm.ExecuteNonQuery()
        End While

        l_comm.Parameters.Clear()
        s_comm.Parameters.Clear()
        s_reader.Close()

        s_comm.CommandText = "select * from zMarketInfo(@m_code)"
        s_comm.Parameters.AddWithValue("@m_code", Fmain.Market_N)

        l_comm.CommandText = "update settings set market_address = case when isnull(@address, '') = '' then market_address else @address end, bank_terminal_id = case when isnull(@terminalid, '') = '' then bank_terminal_id else @terminalid end, bank_terminal_port = case when isnull(@terminalport, '') = '' then bank_terminal_port else @terminalport end"
        l_comm.Parameters.Add("@address", SqlDbType.NVarChar, 30)
        l_comm.Parameters.Add("@terminalid", SqlDbType.NVarChar, 64)
        l_comm.Parameters.Add("@terminalport", SqlDbType.NVarChar, 32)

        s_reader = s_comm.ExecuteReader
        s_reader.Read()
        l_comm.Parameters(0).Value = s_reader("cmpAddress").ToString()
        Try
            l_comm.Parameters(1).Value = s_reader("BankTerminalId").ToString()
            l_comm.Parameters(2).Value = s_reader("BankTerminalPort").ToString()
        Catch ex As Exception
            l_comm.Parameters(1).Value = String.Empty
            l_comm.Parameters(2).Value = String.Empty
        End Try

        l_comm.ExecuteNonQuery()

        s_comm.Parameters.Clear()
        l_comm.Parameters.Clear()
        s_reader.Close()

        s_conn.Close()
        l_conn.Close()

        Fmain.UITerms = GetUiTerms()
        Fmain.CheckTerms = GetCheckTerms()

        Dim e As New System.EventArgs()
        frmThumbs.frmThumbs_Load(frmThumbs, e)
    End Sub
    Public Sub Update_Price()
        '##### price-ის განახლება
        Dim ConnS As New System.Data.SqlClient.SqlConnection(Fmain.SERVER_CONN_STR)
        Try
            ConnS.Open()
            Fmain.lbl_Status.ForeColor = Color.Green
        Catch ex As Exception
            Fmain.b_Servertan_Aris_Kavshiri = False
            Fmain.lbl_Status.ForeColor = Color.Red
            Fmain.dt_Servertan_Kavshirisatvis = Now
            Fmain.Write_In_Log("servertan kavshiri ar aris: Update_'PriceList'")
            Mesigi("სერვერთან კავშირი არ არის")
            Exit Sub
        End Try
        Dim ConnL As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm1 As New SqlClient.SqlCommand("SELECT itmKEY, itmgNAME, itmNAME, sPrice, dmKEY, isScanner, pType FROM zPriceByMarket_x_11(@m_code, @Up_Link)", ConnS)
        Dim Comm2 As New SqlClient.SqlCommand("INSERT INTO price_list(kodi, jgufi, dasaxeleba, gas_fasi, wonis, lock_status, pType) VALUES (@kodi, @jgufi, @dasaxeleba, @gas_fasi, @wonis, @lock_status, @pType)", ConnL)
        Dim Comm3 As New SqlClient.SqlCommand("DELETE price_list WHERE kodi=@kodi", ConnL)
        Dim Comm4 As New SqlClient.SqlCommand("UPDATE date_times SET price_update_time=@price_update_time", ConnL)
        Dim Comm5 As New SqlClient.SqlCommand("SELECT price_update_time FROM date_times", ConnL)

        Dim Reader As SqlClient.SqlDataReader
        Dim Last_Update As Date = Now.AddYears(-5)

        Dim DS2 As New DataSet
        Dim SDA2 As New System.Data.SqlClient.SqlDataAdapter
        Dim DRow As DataRow
        Dim Trans1 As SqlClient.SqlTransaction
        Comm1.CommandTimeout = 500
        Try
            ConnL.Open()
            Reader = Comm5.ExecuteReader
            While Reader.Read
                If Not (Reader.Item(0) Is DBNull.Value) Then
                    Last_Update = Reader.Item(0)
                End If
            End While
            Reader.Close()

            Comm1.Parameters.Add("@m_code", SqlDbType.Int).Value = Fmain.Market_N
            Comm1.Parameters.Add("@Up_Link", SqlDbType.DateTime).Value = Last_Update
            SDA2.SelectCommand = Comm1
            SDA2.Fill(DS2)
            Comm1.Parameters.Clear()

            Trans1 = ConnL.BeginTransaction
            Comm3.Transaction = Trans1
            Comm2.Transaction = Trans1
            Comm4.Transaction = Trans1
            Comm3.Parameters.Add("@kodi", SqlDbType.NVarChar, 16)
            Comm2.Parameters.Add("@kodi", SqlDbType.NVarChar, 16)
            Comm2.Parameters.Add("@jgufi", SqlDbType.NVarChar, 50)
            Comm2.Parameters.Add("@dasaxeleba", SqlDbType.NVarChar, 50)
            Comm2.Parameters.Add("@gas_fasi", SqlDbType.Float)
            Comm2.Parameters.Add("@wonis", SqlDbType.Bit)
            Comm2.Parameters.Add("@lock_status", SqlDbType.Bit)
            Comm2.Parameters.Add("@pType", SqlDbType.Int)
            For Each DRow In DS2.Tables(0).Rows
                Comm3.Parameters(0).Value = DRow(0)
                Comm3.ExecuteNonQuery()
                'If DRow(5) Then
                Comm2.Parameters(0).Value = DRow(0)
                Comm2.Parameters(1).Value = DRow(1)
                Comm2.Parameters(2).Value = DRow(2)
                Comm2.Parameters(3).Value = DRow(3)
                Comm2.Parameters(4).Value = DRow(4)
                Comm2.Parameters(5).Value = DRow(5)
                Comm2.Parameters(6).Value = DRow(6)
                Comm2.ExecuteNonQuery()
                'End If
            Next
            Comm3.Parameters.Clear()
            Comm2.Parameters.Clear()
            Dim i_Raod As Integer = DS2.Tables(0).Rows.Count
            DS2.Clear()
            Comm4.Parameters.Add("@price_update_time", SqlDbType.DateTime).Value = Now.AddMinutes(-2)
            Comm4.ExecuteNonQuery()
            Comm4.Parameters.Clear()
            Trans1.Commit()

            'Update_MasterData()

            Fmain.Write_In_Log("fasebis ganaxleba, " & i_Raod & " striqoni")
            Dim thr As New Threading.Thread(AddressOf Ganaxlebulia)
            thr.Start()

            Fmain.price_List_Load()

        Catch ex As Exception
            Try
                Trans1.Rollback()
            Catch exc As Exception
                Fmain.Write_In_Log("Err_Price_Update: " & exc.Message)
            End Try
            Mesigi(ex.Message, "Err_Price_Update: ფასები არ განახლდა")
            Fmain.Write_In_Log("Err_Price_Update: " & ex.Message)
        Finally
            ConnL.Close()
            ConnS.Close()
        End Try
    End Sub

    Public Sub New_Price()
        '##### NewPriceList
        Dim ConnS As New System.Data.SqlClient.SqlConnection(Fmain.SERVER_CONN_STR)
        Try
            ConnS.Open()
            Fmain.lbl_Status.ForeColor = Color.Green
        Catch ex As Exception
            Fmain.b_Servertan_Aris_Kavshiri = False
            Fmain.lbl_Status.ForeColor = Color.Red
            Fmain.dt_Servertan_Kavshirisatvis = Now
            Fmain.Write_In_Log("servertan kavshiri ar aris: New_'PriceList'")
            Mesigi("სერვერთან კავშირი არ არის")
            Exit Sub
        End Try
        Dim ConnL As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm1 As New SqlClient.SqlCommand
        Dim Comm2 As New SqlClient.SqlCommand
        Dim Comm3 As New SqlClient.SqlCommand
        Dim Comm4 As New SqlClient.SqlCommand
        Dim DS2 As New DataSet
        Dim SDA2 As New System.Data.SqlClient.SqlDataAdapter
        Dim DRow As DataRow
        Dim Trans1 As SqlClient.SqlTransaction
        Comm1.CommandText = "SELECT itmKEY, itmgNAME, itmNAME, sPrice, dmKEY, isScanner, pType FROM zPriceByMarket_x(@m_code)"
        Comm2.CommandText = "INSERT INTO price_list(kodi, jgufi, dasaxeleba, gas_fasi, wonis, lock_status, pType) VALUES (@kodi, @jgufi, @dasaxeleba, @gas_fasi, @wonis, @lock_status, @pType)"
        Comm3.CommandText = "DELETE price_list"
        Comm4.CommandText = "UPDATE date_times SET price_update_time=@price_update_time"
        Comm1.Connection = ConnS
        Comm2.Connection = ConnL
        Comm3.Connection = ConnL
        Comm4.Connection = ConnL
        Comm1.CommandTimeout = 600
        Try
            Comm1.Parameters.Add("@m_code", SqlDbType.Int).Value = Fmain.Market_N
            SDA2.SelectCommand = Comm1
            SDA2.Fill(DS2)
            ConnL.Open()
            Trans1 = ConnL.BeginTransaction
            Comm1.Transaction = Trans1
            Comm2.Transaction = Trans1
            Comm3.Transaction = Trans1
            Comm4.Transaction = Trans1
            Comm3.ExecuteNonQuery()
            Comm2.Parameters.Add("@kodi", SqlDbType.NVarChar, 16)
            Comm2.Parameters.Add("@jgufi", SqlDbType.NVarChar, 50)
            Comm2.Parameters.Add("@dasaxeleba", SqlDbType.NVarChar, 50)
            Comm2.Parameters.Add("@gas_fasi", SqlDbType.Float)
            Comm2.Parameters.Add("@wonis", SqlDbType.Bit)
            Comm2.Parameters.Add("@lock_status", SqlDbType.Bit)
            Comm2.Parameters.Add("@pType", SqlDbType.Int)
            For Each DRow In DS2.Tables(0).Rows
                Comm2.Parameters(0).Value = DRow(0)
                Comm2.Parameters(1).Value = DRow(1)
                Comm2.Parameters(2).Value = DRow(2)
                Comm2.Parameters(3).Value = DRow(3)
                Comm2.Parameters(4).Value = DRow(4)
                Comm2.Parameters(5).Value = DRow(5)
                Comm2.Parameters(6).Value = DRow(6)
                Comm2.ExecuteNonQuery()
            Next
            Comm2.Parameters.Clear()
            Dim i_Raod As Integer = DS2.Tables(0).Rows.Count
            DS2.Clear()
            Comm1.Parameters.Clear()
            Comm4.Parameters.Add("@price_update_time", SqlDbType.DateTime).Value = Now.AddMinutes(-5)
            Comm4.ExecuteNonQuery()
            Comm4.Parameters.Clear()
            Trans1.Commit()

            Update_MasterData()

            Fmain.Write_In_Log("'PriceList'-is gadmowera, " & i_Raod & " striqoni")
            Dim thr As New Threading.Thread(AddressOf Ganaxlebulia_Srulad)
            thr.Start()

            Fmain.price_List_Load()

        Catch ex As Exception
            Try
                Trans1.Rollback()
            Catch exc As Exception
                Fmain.Write_In_Log("Err_New_Price: " & exc.Message)
            End Try
            Mesigi(ex.Message, "Err_New_Price:")
            Fmain.Write_In_Log("Err_New_Price: " & ex.Message)
        Finally
            ConnL.Close()
            ConnS.Close()
        End Try
    End Sub

    Private Sub Ganaxlebulia()
        Mesigi("ფასები განახლებულია")
    End Sub

    Private Sub Ganaxlebulia_Srulad()
        Mesigi("ფასები განახლებულია სრულად")
    End Sub
End Module
