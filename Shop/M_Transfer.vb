Imports PosManualSync

Module M_Transfer
    Dim b_Transfering As Boolean
    Dim b_IsConnection As Boolean
    Dim d_DateForConnection As Date
    Dim wsId As String

    Public Sub Do_Transfer()
        '######################## გაყიდვების გაგზავნა
        Try
            wsId = "POS-" + Fmain.Market_N.ToString("00") + "-" + Fmain.Pos_N.ToString("00")

            If b_IsConnection Then
                Fmain.lbl_Status.ForeColor = Color.Green
            Else
                Fmain.lbl_Status.ForeColor = Color.Red
            End If
            If Not b_IsConnection And d_DateForConnection.AddMinutes(20) < Now Then
                b_IsConnection = True
            End If
            If (Not b_Transfering) And b_IsConnection = True Then
                b_Transfering = True
                Dim thr_tran As New Threading.Thread(AddressOf thr_Transfer)
                thr_tran.Start()
            End If
        Catch ex As Exception
            Write_Transfer_Log("Err_Do_Transfer: " & ex.Message)
        End Try
    End Sub
    Private Sub thr_Transfer()
        Dim ma As New MainAnator()

        Dim localconn As New SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim serverconn As New SqlClient.SqlConnection(Fmain.SERVER_CONN_STR)
        Dim ErrNum As New List(Of Integer)

        ma.SourceInstance = New SqlInstance()
        ma.SourceInstance.ServerName = localconn.DataSource
        ma.SourceInstance.DBName = localconn.Database
        ma.SourceInstance.IntegratedSecurity = True

        ma.DestinationInstance = New SqlInstance()
        ma.DestinationInstance.ServerName = serverconn.DataSource
        ma.DestinationInstance.DBName = serverconn.Database
        ma.DestinationInstance.IntegratedSecurity = False
        'ge
        'ma.DestinationInstance.UserID = "gspm_pos"
        'ma.DestinationInstance.Password = "userclient"
        'ge
        'az
        ma.DestinationInstance.UserID = "appuser"
        ma.DestinationInstance.Password = "tesla555"
        'az
        'en()
        'ma.DestinationInstance.UserID = "sa"
        'ma.DestinationInstance.Password = "userclient"
        'ma.DestinationInstance.WorkStationId = wsId
        'en()

        ma.LogicA = False

        Try
            ma.Initialize()
            If Not (ma.Message = String.Empty) Then
                ma.Close()
                Throw New Exception(ma.Message)
            End If
        Catch ex As Exception
            b_IsConnection = False
            d_DateForConnection = Now
            Write_Transfer_Log("Err_Transfer: " & ex.Message)
            b_Transfering = False
            Exit Sub
        End Try

        Try
            If Not (ma.SyncList Is Nothing) Then
                If (ma.SyncList.Length > 0) Then
                    Dim count As Integer = ma.SyncList.Length
                    For i As Integer = 0 To ma.SyncList.Length - 1
                        ma.SyncEntry(ma.SyncList(i))
                        If Not (ma.Message = String.Empty) Then
                            ErrNum.Add(ma.ErrorNumber)
                            If Not (ma.ErrorNumber = 2627 Or ma.ErrorNumber = 105 Or ma.ErrorNumber = -2) Then
                                Write_Transfer_Log("Err_Transfer: " & ma.Message & " (" & ma.ErrorNumber.ToString() & ")")
                            ElseIf (ma.ErrorNumber = -2) Then
                                Write_Transfer_Log("Err_Transfer_-2: Timeout error, skipping syncronization until next attempt")
                                Exit Sub
                            ElseIf (ma.ErrorNumber = 105) Then
                                b_IsConnection = False
                                d_DateForConnection = Now.AddMinutes(-10)
                                Write_Transfer_Log("Err_Transfer_105: server unavailable, skipping syncronization until next attempt")
                                Exit Sub
                            Else
                                Write_Transfer_Log("Err_Transfer_2627: " & ma.Message & System.Environment.NewLine & "attempting to check entry...")
                                ma.CheckLocalEntry(ma.SyncList(i), True)
                                If Not (ma.Message = String.Empty) Then
                                    Write_Transfer_Log("Err_CheckLocalEntry: " & ma.Message & " (" & ma.ErrorNumber.ToString() & ")")
                                End If
                            End If
                            count = count - 1
                        End If
                    Next i
                    'Write_Transfer_Log("Transfer: " & count.ToString() & " Transaction(s) out of " & ma.SyncList.Length.ToString() & " syncronized successfully")
                End If
            End If
        Catch ex As Exception
            Write_Transfer_Log("Err_ma_sync: " & ex.Message)
            Mesigi(ex.Message)
        Finally
            b_Transfering = False
            ma.Close()
            ma = Nothing
        End Try
    End Sub

    Private Sub Check_Transfer()
        Dim ConnS As New System.Data.SqlClient.SqlConnection(Fmain.SERVER_CONN_STR)
        Dim ConnL As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim CommS As New SqlClient.SqlCommand
        Dim CommSEL As New SqlClient.SqlCommand("SELECT sale_date, check_n, market_n, pos_n FROM pos_sales WHERE status=0", ConnL)
        Dim CommUPD As New SqlClient.SqlCommand("UPDATE pos_sales SET status=1 WHERE check_n=@check_n", ConnL)
        Dim ReaderL As SqlClient.SqlDataReader
        Dim ReaderS As SqlClient.SqlDataReader
        CommS.Connection = ConnS
        Dim b_Gasvla As Boolean = False
        CommS.CommandTimeout = 5
        Try
            ConnS.Open()
            ConnL.Open()
            ReaderL = CommSEL.ExecuteReader
            While ReaderL.Read
                CommS.CommandText = "SELECT EntryKEY FROM Entries WHERE EntryDate='" & _
                Format(ReaderL.GetDateTime(0), "yyyy-MM-dd HH:mm:ss.") & Format(ReaderL.GetDateTime(0).Millisecond, "000") & _
                "' AND EntryKEY='" & ReaderL.Item(3) & Format(ReaderL.Item(1), "000000") & _
                "' AND ComputerKEY='POS-" & Format(ReaderL.Item(2), "00") & "-" & Format(ReaderL.Item(3), "00") & "'"

                ReaderS = CommS.ExecuteReader
                While ReaderS.Read
                    CommUPD.Parameters.Add("@check_n", SqlDbType.Int).Value = ReaderL.GetInt32(1)
                    ReaderL.Close()
                    CommUPD.ExecuteNonQuery()
                    CommUPD.Parameters.Clear()
                    b_Gasvla = True
                End While
                ReaderS.Close()
                If b_Gasvla Then
                    Exit While
                End If
            End While
            'If Not ReaderL.IsClosed Then
            '    ReaderL.Close()
            'End If
        Catch ex As Exception
            Write_Transfer_Log("Err_Check_Transfer: " & ex.Message)
        Finally
            ConnL.Close()
            ConnS.Close()
        End Try
        Write_Transfer_Log("Check_Transfer")
    End Sub

    Private Sub Write_Transfer_Log(ByVal s_Log As String)
        Try
            FileOpen(1, My.Application.Info.DirectoryPath & "\pos_log", OpenMode.Append)
            WriteLine(1, Now & " - " & s_Log)
            FileClose(1)
        Catch ex As Exception
        End Try
    End Sub
End Module
