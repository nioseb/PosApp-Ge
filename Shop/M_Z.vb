Module M_Z

    Public Sub Check_Z()
        Try
            If Fmain.DGV_Sales.Rows.Count = 0 Then
                If Now > Fmain.dt_Last_Z_Time Then
                    If (Now - Fmain.dt_Last_Z_Time).TotalMinutes >= 1438 Then
                        If Mesigi("გაფრთხილება ადმინისტრატორს დაუყონებლივ გააკეთეთ Z ანგარიში", "გაფრთხილება", True, "Z ანგარიში") Then
                            Do_Z(Fmain.dt_Last_Z_Time)
                        Else
                            Application.Exit()
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Check_Z" & ex.Message)
        End Try
    End Sub

    Public Sub Jast_Do_Z()
        Try
            If Fmain.DGV_Sales.Rows.Count = 0 Then
                'If Now > Fmain.dt_Last_Z_Time.AddSeconds(30) Then
                Do_Z(Fmain.dt_Last_Z_Time)
                'Else
                'Mesigi("Z-ის ამოღება არ შეგიძლიათ " & Fmain.dt_Last_Z_Time.AddSeconds(30).ToString & " -მდე")
                'End If
            End If
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Jast_Do_Z" & ex.Message)
        End Try
    End Sub

    Private Sub Do_Z(ByVal Last_Z_DateTime As Date)
        If Avtorizacia() Then
            If Fmain.p_Person.Role2 = 9 Then
                Dim d_Sum As Double = 0
                Dim ConnL As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
                Dim Comm As New SqlClient.SqlCommand
                Dim Reader As SqlClient.SqlDataReader
                Dim log_msg As String
                Comm.Connection = ConnL
                Comm.CommandText = "SELECT Sum(check_amount) FROM pos_sales WHERE check_n > (SELECT Max(check_n) FROM pos_sales WHERE sale_type=6)"
                Try
                    ConnL.Open()
                    'Comm.Parameters.Add("@sale_date", SqlDbType.DateTime).Value = Last_Z_DateTime
                    Reader = Comm.ExecuteReader
                    While Reader.Read
                        If Not (Reader.Item(0) Is DBNull.Value) Then
                            d_Sum = Reader.Item(0)
                        End If
                    End While
                    Reader.Close()
                    'Comm.Parameters.Clear()
                Catch ex As Exception
                    Mesigi(ex.Message, "Err_Do_Zsum:")
                    Fmain.Write_In_Log("Err_Do_Zsum: " & ex.Message)
                Finally
                    ConnL.Close()
                End Try
                '############## ჩეკის დაბეჭდვა
                Try
                    If Fmain.fp_daisy = 1 Then
                        'Fmain.daisy_FP.ZReport()
                        Fmain.DaisyFP.ZReport()
                    End If

                    'If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
                    '    Dim port As String = Fmain.BankTerminalPort
                    '    Dim terminal As New eptcvx.Terminal(Fmain.BankTerminalId)
                    '    terminal.PortInfo.PortName = Fmain.BankTerminalPort
                    '    Dim term_res As String = terminal.Reconciliation()
                    '    Fmain.BankTerminalData = terminal.ReceiptData

                    '    M_Daisy.Print_Terminal_Response(Fmain.BankTerminalData)

                    '    If Not String.IsNullOrEmpty(term_res) Then
                    '        Fmain.Write_In_Log("Err terminal transaction: " & Fmain.Check_Number.ToString() & " : " & term_res)
                    '        MessageBox.Show("ტერმინალით ტრანზაქციის განხორციელება შეუძლებელია" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - Card Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '        Exit Sub
                    '    End If

                    'End If

                    If Fmain.fp_daisy = 2 Then
                        Try
                            If Fmain.DaisyFP.FiscalDocIsOpen Then
                                Fmain.DaisyFP.FiscalDocCancel()
                            End If
                            If Fmain.DaisyFP.NonFiscalDocIsOpen Then
                                Fmain.DaisyFP.NonFiscalDocClose()
                            End If
                            Fmain.DaisyFP.ZReport()
                            Mesigi("აიღეთ Z ანგარიში პრინტერიდან და დააჭირეთ Enter-ს", , , , True)
                            Fmain.Init_Z_Appx("Z")
                        Catch ex As Exception
                            Fmain.Write_In_Log("Err Daisy FP print Z: " & ex.Message)
                            MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Fmain.DaisyFP.Dispose()
                        End Try
                        'ElseIf Fmain.Fiscal_N = 4 Then
                        '    Try
                        '        Dim shiftstatus = Fmain.ACFiscalbox.GetShiftStatus(Fmain.ACLogin.Data.Access_token)
                        '        If shiftstatus.Code <> "0" Then
                        '            Mesigi(shiftstatus.Message + " (" + shiftstatus.Code + ")", "Fiscalbox: GetShiftStatus")
                        '            Exit Sub
                        '        End If
                        '        If shiftstatus.Data.Shift_open Then
                        '            Dim closeshift = Fmain.ACFiscalbox.CloseShift(Fmain.ACLogin.Data.Access_token, Fmain.p_Person.ID2)
                        '            If closeshift.Code <> "0" Then
                        '                Mesigi(closeshift.Message + " (" + closeshift.Code + ")", "Fiscalbox: CloseShift")
                        '                Exit Sub
                        '            End If
                        '        End If
                        '    Catch ex As Exception
                        '        Fmain.Write_In_Log("Err ACFiscalbox CloseShift: " & ex.Message)
                        '        MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '        Fmain.DaisyFP.Dispose()
                        '    End Try
                    End If

                    If Fmain.Fiscal_N = 1 Then
                        F_FP_SC_DR.Z_Amogheba()
                        F_FP_SC_DR.SetDate()
                        'MessageBox.Show("Z Amovida")
                        F_FP_SC_DR.Close_Fiscal()
                        'MessageBox.Show("Z Amovida")
                        Try
                            Fmain.Init_Z_Appx("Z")
                        Catch ex_x As Exception
                            Fmain.Write_In_Log("Err_Do_Z_Appx: Z_Appx ar amodis")
                        End Try
                    ElseIf Fmain.Fiscal_N = 2 Or Fmain.Fiscal_N = 3 Then
                        M_SLP.SetDate_SLP()
                        If M_SLP.Z_Amogheba_SLP() Then
                        Else
                            Mesigi("Z არ ამოდის", "Err_Do_Z:")
                            Fmain.Write_In_Log("Err_Do_Z: Z ar amodis1")
                            Application.Exit()
                            Exit Sub
                        End If
                    End If
                    log_msg = "Err_Do_Z: Z ar amodis"
                    'Try
                    If Fmain.Printer_N = 1 And Fmain.fp_daisy = 0 Then
                        Fmain.b_Daibechda(0) = False
                        Fmain.b_Daibechda(1) = False
                        Fmain.b_Daibechda(2) = False
                        Do While (((Fmain.b_Daibechda(0) And Fmain.b_Daibechda(1)) And Fmain.b_Daibechda(2)) = False)
                            Fmain.PD.DocumentName = "Z"
                            Fmain.PD.Print()
                            Fmain.Refresh()
                        Loop
                        Fmain.Refresh()
                        Threading.Thread.Sleep(7000)
                        Fmain.b_Daibechda(0) = False
                        Fmain.b_Daibechda(1) = False
                        Fmain.b_Daibechda(2) = False
                        Do While (((Fmain.b_Daibechda(0) And Fmain.b_Daibechda(1)) And Fmain.b_Daibechda(2)) = False)
                            Fmain.PD.DocumentName = "Z"
                            Fmain.PD.Print()
                            Fmain.Refresh()
                        Loop
                        Fmain.Refresh()
                    End If
                    log_msg = "Err_Do_Z: Z ar ibechdeba"
                    'Catch ex2 As Exception
                    'Mesigi(ex2.Message, "Err_Do_Z")
                    'Fmain.Write_In_Log("Err_Do_Z: Z ar ibechdeba")
                    'Application.Exit()
                    'Exit Sub
                    'End Try
                    '##########################
                    'Fmain.Write_In_Log(Fmain.dt_Last_Z_Time.ToString())
                    Threading.Thread.Sleep(2000)
                    If Now > Fmain.dt_Last_Z_Time.AddSeconds(30) Then
                        M_SQL.Open_Sale(Fmain.Check_Number)
                        '############### SaleLines-ში ჩაწერა
                        Dim s_Ttime As String = String.Empty
                        If Fmain.Fiscal_N > 0 Then
                            s_Ttime = Inputi("შეიყვანეთ მიმდინარე ცვლის შესაბამისი ფისკალური პრინტერის Z ანგარიშიდან თანხის ოდენობა", "Z ანგარიში")
                        End If
                        M_SQL.Do_SaleLines(Fmain.Check_Number, "00992", 0, 0, s_Ttime)
                        '#################################
                        M_SQL.Close_Sale(Fmain.Check_Number, 6, Math.Round(d_Sum, 2, MidpointRounding.AwayFromZero), 0)
                        Fmain.dt_Last_Z_Time = Now
                        Mesigi("Z ამოღებულია", , , "Z ანგარიში")
                        Fmain.Write_In_Log("Z amoghebulia")
                        If Fmain.b_Servertan_Aris_Kavshiri Then
                            M_Transfer.Do_Transfer()
                        End If
                    End If
                Catch ex1 As Exception
                    Mesigi(ex1.Message, "Err_Do_Z")
                    'Fmain.Write_In_Log(log_msg)
                    Application.Exit()
                    Exit Sub
                End Try
                Application.Exit()
            Else
                Fmain.Write_In_Log("Z-is amoghebis mcdeloba molaris baratit")
                Mesigi("Z-ის ამოღება შეუძლია მხოლოდ ადმინისტრატორს", "შეცდომა")
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub

    Public Function pos_Check_N(ByVal s_ChckN As String) As Integer
        If Fmain.Pos_N > 0 And Fmain.Pos_N < 10 Then
            Return (Convert.ToInt32(Mid(s_ChckN, 2, (Len(s_ChckN) - 1))))
        ElseIf Fmain.Pos_N > 0 And Fmain.Pos_N < 100 Then
            Return (Convert.ToInt32(Mid(s_ChckN, 3, (Len(s_ChckN) - 2))))
        Else
            Mesigi("შეასწორეთ POS-ის ნომერი", "შეცდომა")
            Fmain.Write_In_Log("pos_Check_N: POS-is nomeri ara sworia")
        End If
    End Function

    'Private Sub daxure()
    '    If Fmain.Fiscal_N = 1 Then
    '        F_FP_SC_DR.Close_Fiscal()
    '    ElseIf Fmain.Fiscal_N = 2 Or Fmain.Fiscal_N = 3 Then
    '        M_SLP.Close_SLP()
    '    End If
    '    If Fmain.Scanner_N = 1 Then
    '        F_FP_SC_DR.Close_Scanner()
    '    End If
    '    If Fmain.Drawer_N = 1 Then
    '        F_FP_SC_DR.Close_Drawer()
    '    End If
    '    End
    'End Sub
End Module
