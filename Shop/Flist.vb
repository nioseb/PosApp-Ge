Public Class Flist

    Private Sub Flist_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridF.Rows.Clear()
        GridF.Height = 30
        GridF.Height += 42
        Me.Height = 78
        GridF.Rows.Add()
        GridF.Rows(0).Cells(0).Value = "დახურვა"
        If Fmain.DGV_Sales.Rows.Count = 0 Then
            GridF.Height += 40
            GridF.Rows.Add()
            GridF.Rows(1).Cells(0).Value = "X-ის ამოღება"
            GridF.Height += 40
            GridF.Rows.Add()
            GridF.Rows(2).Cells(0).Value = "Z-ის ამოღება"
            GridF.Height += 40
            GridF.Rows.Add()
            GridF.Rows(3).Cells(0).Value = "ჩეკის დაბრუნება"
            GridF.Height += 40
            GridF.Rows.Add()
            GridF.Rows(4).Cells(0).Value = "ფასების განახლება"
            GridF.Height += 40
            GridF.Rows.Add()
            GridF.Rows(5).Cells(0).Value = "ფასების სრული განახლება"
            GridF.Height += 40
            GridF.Rows.Add()
            GridF.Rows(6).Cells(0).Value = "მოწყობილობების კონტროლი"
            If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
                GridF.Height += 40
                GridF.Rows.Add()
                GridF.Rows(7).Cells(0).Value = "TBC ტერმინალი"
            End If
            GridF.Height += 40
            GridF.Rows.Add()
            GridF.Rows(GridF.RowCount - 1).Cells(0).Value = "პროგრამიდან გამოსვლა"
        Else
            If Mid(Fmain.lbl_SaleType.Text, 1, 6) <> "დაბრუნ" Then
                Dim row As Integer = 0
                GridF.Height += 40
                row += 1
                GridF.Rows.Add()
                GridF.Rows(row).Cells(0).Value = "უნაღდო გაყიდვა"
                GridF.Height += 40
                If Fmain.PrebillAllowed = True Then
                    row += 1
                    GridF.Rows.Add()
                    GridF.Rows(row).Cells(0).Value = "წინასწარი ქვითრის ბეჭდვა"
                    GridF.Height += 40
                End If

                row += 1
                GridF.Rows.Add()
                GridF.Rows(row).Cells(0).Value = "18% ფასდაკლება"
                GridF.Height += 40
                row += 1
                GridF.Rows.Add()
                GridF.Rows(row).Cells(0).Value = "10% ფასდაკლება"
                GridF.Height += 40
                row += 1
                GridF.Rows.Add()
                GridF.Rows(row).Cells(0).Value = "პროგრამიდან გამოსვლა"
            End If
        End If
        Me.Top = (Screen.AllScreens(0).WorkingArea.Height - Me.Height) / 2
        Fmain.TranslateUI(Me, Fmain.UITerms, True)
    End Sub

    Private Sub GridF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridF.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim termKey As String = GridF.SelectedCells(0).Value.ToString
            If Fmain.UITerms.ContainsValue(termKey) Then
                For Each di As KeyValuePair(Of String, String) In Fmain.UITerms
                    If di.Value = termKey Then
                        termKey = di.Key
                        Exit For
                    End If
                Next
            End If
            Select Case termKey
                Case "უნაღდო გაყიდვა"
                    'If Mid(Fmain.lbl_SaleType.Text, 1, 6) <> "უნაღდო" Then
                    'Dim dt As String = System.IO.File.ReadAllText("c:\termresp.txt")
                    'M_Daisy.Print_Terminal_Response(dt)

                    If Not String.IsNullOrEmpty(Fmain.BankTerminalId) And Fmain.d_Tanxa > 0.001 Then
                        Dim frmpayprompt As New frmCardPayPrompt()
                        If frmpayprompt.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            If Fmain.fp_daisy = 2 Then
                                If Fmain.fp_daisy = 2 And Not Fmain.CheckPrinter() Or Fmain.fp_daisy = 0 And Fmain.Printer_N = 0 Then
                                    Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                                    Exit Sub
                                ElseIf Fmain.fp_daisy = 2 Then
                                    Try
                                        Fmain.DaisyFP.PaperFeed(1)
                                    Catch ex As Exception
                                        If ex.Message.Contains("NO_PAPER") Then
                                            Mesigi("პრინტერში გათავდა ქაღალდი, ჩადეთ ახალი რულონი, პრინტერზე დააჭირეთ ღილაკს 'C' და შემდეგ დააჭირეთ 'Enter'-ს", , , , True, True)
                                            Fmain.DaisyFP.Dispose()
                                            Exit Sub
                                        Else
                                            Throw New Exception(ex.Message)
                                        End If
                                    End Try
                                End If
                            End If

                            Dim port As String = Fmain.BankTerminalPort
                            Dim terminal As New eptcvx.Terminal(Fmain.BankTerminalId)
                            terminal.PortInfo.PortName = Fmain.BankTerminalPort

                            Dim term_res As String = String.Empty
                            If frmpayprompt.Paytype = 1 Then
                                term_res = terminal.Transaction((Fmain.d_Tanxa * 100).ToString("000"), eptcvx.CardTransaction.Payment)
                            ElseIf frmpayprompt.Paytype = 2 Then
                                term_res = terminal.Transaction((Fmain.d_Tanxa * 100).ToString("000"), eptcvx.CardTransaction.Installment)
                            End If

                            Fmain.BankTerminalData = terminal.ReceiptData

                            If Not String.IsNullOrEmpty(term_res) And Not String.IsNullOrEmpty(Fmain.BankTerminalData) Then
                                If Fmain.fp_daisy = 2 Then
                                    M_Daisy.Print_Terminal_Response(Fmain.BankTerminalData, "-----ტერმინალით გადახდა-----")
                                ElseIf Fmain.Printer_N = 1 Then
                                    Fmain.PD.DocumentName = "terminal_check"
                                    Fmain.PD.Print()
                                End If

                                Fmain.BankTerminalData = String.Empty
                            End If

                            If Not String.IsNullOrEmpty(term_res) Then
                                Fmain.Write_In_Log("Err terminal transaction: " & Fmain.Check_Number.ToString() & " : " & term_res)
                                MessageBox.Show("ტერმინალით ტრანზაქციის განხორციელება შეუძლებელია" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - Card Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            If Fmain.lbl_SaleType.Text.Contains("გაყიდვა") Or Fmain.lbl_SaleType.Text.StartsWith("შეკვეთა") Then
                                Fmain.lbl_SaleType.Text = "უნაღდო გაყიდვა"
                            End If
                            Try
                                If Fmain.fp_daisy = 2 Then
                                    M_Daisy.Print_Terminal_Response(Fmain.BankTerminalData, "-----ტერმინალით გადახდა-----")
                                ElseIf Fmain.Printer_N = 1 Then
                                    Dim sep As String() = {"~0xDA^^"}
                                    Dim receipts As String() = terminal.ReceiptData.Split(sep, StringSplitOptions.RemoveEmptyEntries)
                                    For Each terminalData In receipts
                                        Fmain.BankTerminalData = terminalData
                                        Fmain.PD.DocumentName = "terminal_check"
                                        Fmain.PD.Print()
                                    Next
                                End If
                            Catch ex As Exception
                                Fmain.Write_In_Log("Err_Print_Terminal_Response (Flist): " & Fmain.Check_Number.ToString() & " : " & ex.Message & Environment.NewLine & ex.StackTrace & Environment.NewLine & "TerminalData: " & Fmain.BankTerminalData)
                                If ex.Message.Contains("NO_PAPER") Then
                                    Mesigi("პრინტერში გათავდა ქაღალდი, ჩადეთ ახალი რულონი, პრინტერზე დააჭირეთ ღილაკს 'C' და შემდეგ დააჭირეთ 'Enter'-ს", , , , True, True)
                                    Fmain.DaisyFP.Dispose()
                                    Exit Sub
                                Else
                                    Throw New Exception(ex.Message)
                                End If
                            End Try
                            Fmain.BankTerminalData = String.Empty
                            Fmain.End_Of_Sale(False)
                        Else
                            Fmain.BankTerminalData = String.Empty
                            Fmain.lbl_Gasacemi.Focus()
                            If (Fmain.lbl_SaleType.Text.Contains("გაყიდვა") Or Fmain.lbl_SaleType.Text.StartsWith("შეკვეთა")) Then
                                Fmain.lbl_SaleType.Text = "უნაღდო გაყიდვა"
                            End If
                            SendKeys.Send("{ENTER}")
                        End If
                    Else
                        If Mesigi("ნამდვილად გსურთ გააკეთოთ უნაღდო გაყიდვა?", , True) Then
                            If (Fmain.lbl_SaleType.Text.Contains("გაყიდვა")) Then
                                Fmain.lbl_SaleType.Text = "უნაღდო გაყიდვა"
                            End If
                            If (Fmain.lbl_SaleType.Text.Contains("შეკვეთა")) Then
                                Fmain.lbl_SaleType.Text = "შეკვეთა უნაღდო"
                            End If
                            Fmain.lbl_Gasacemi.Focus()
                            SendKeys.Send("{ENTER}")
                        End If
                    End If
                    'End If
                Case "წინასწარი ქვითრის ბეჭდვა"
                    Fmain.End_Of_Prebill()
                Case "X-ის ამოღება"
                    If Mesigi("ნამდვილად გსურთ X-ის ამოღება?", "X ანგარიში", True) Then
                        If Fmain.p_Person.Role = 9 Then
                            If Fmain.fp_daisy = 1 Then
                                'Fmain.daisy_FP.XReport()
                                Try
                                    Fmain.DaisyFP.XReport()
                                Catch ex As Exception
                                    Fmain.Write_In_Log("Err Daisy FP print X: " & ex.Message)
                                    MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Fmain.DaisyFP.Dispose()
                                End Try
                            End If

                            'If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
                            '    Dim port As String = Fmain.BankTerminalPort
                            '    Dim terminal As New eptcvx.Terminal(Fmain.BankTerminalId)
                            '    terminal.PortInfo.PortName = Fmain.BankTerminalPort
                            '    Dim term_res As String = terminal.ShortReport()
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
                                    Fmain.DaisyFP.XReport()
                                    Mesigi("აიღეთ X ანგარიში პრინტერიდან და დააჭირეთ Enter-ს", , , , True)
                                    Fmain.Init_Z_Appx("X")
                                Catch ex As Exception
                                    Fmain.Write_In_Log("Err Daisy FP print X: " & ex.Message)
                                    MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Fmain.DaisyFP.Dispose()
                                End Try
                                'ElseIf Fmain.Fiscal_N = 4 Then
                                '    Try
                                '        Dim xreport = Fmain.ACFiscalbox.GetXReport(Fmain.ACLogin.Data.Access_token, Fmain.p_Person.ID2)
                                '        If xreport.Code <> "0" Then
                                '            Mesigi(xreport.Message + " (" + xreport.Code + ")", "Fiscalbox: GetXReport")
                                '            Exit Sub
                                '        End If
                                '    Catch ex As Exception
                                '        Fmain.Write_In_Log("Err ACFiscalbox GetXReport: " & ex.Message)
                                '        MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                '        Fmain.DaisyFP.Dispose()
                                '    End Try
                            End If

                            If Fmain.Fiscal_N = 1 Then
                                F_FP_SC_DR.X_Amogheba()

                                Try
                                    Fmain.Init_Z_Appx("X")
                                Catch ex_x As Exception
                                    Fmain.Write_In_Log("Err_Do_X_Appx: Z_Appx ar amodis")
                                End Try


                            ElseIf Fmain.Fiscal_N = 2 Or Fmain.Fiscal_N = 3 Then
                                M_SLP.X_Amogheba_SLP()
                            End If
                            If Fmain.Printer_N = 1 And Fmain.fp_daisy = 0 Then
                                Fmain.b_Daibechda(0) = False
                                Fmain.b_Daibechda(1) = False
                                Fmain.b_Daibechda(2) = False
                                Do While (((Fmain.b_Daibechda(0) And Fmain.b_Daibechda(1)) And Fmain.b_Daibechda(2)) = False)
                                    Fmain.PD.DocumentName = "X"
                                    Fmain.PD.Print()
                                    Fmain.Refresh()
                                Loop
                            End If
                        Else
                            If Avtorizacia() Then
                                If Fmain.p_Person.Role2 = 9 Then
                                    If Fmain.fp_daisy = 1 Then
                                        'Fmain.daisy_FP.XReport()
                                        Try
                                            Fmain.DaisyFP.XReport()
                                        Catch ex As Exception
                                            Fmain.Write_In_Log("Err Daisy FP print X: " & ex.Message)
                                            MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Fmain.DaisyFP.Dispose()
                                        End Try
                                    End If
                                    If Fmain.fp_daisy = 2 Then
                                        Try
                                            If Fmain.DaisyFP.FiscalDocIsOpen Then
                                                Fmain.DaisyFP.FiscalDocCancel()
                                            End If
                                            If Fmain.DaisyFP.NonFiscalDocIsOpen Then
                                                Fmain.DaisyFP.NonFiscalDocClose()
                                            End If
                                            Fmain.DaisyFP.XReport()
                                            Mesigi("აიღეთ X ანგარიში პრინტერიდან და დააჭირეთ Enter-ს", , , , True)
                                            Fmain.Init_Z_Appx("X")
                                        Catch ex As Exception
                                            Fmain.Write_In_Log("Err Daisy FP print X: " & ex.Message)
                                            MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Fmain.DaisyFP.Dispose()
                                        End Try
                                        'ElseIf Fmain.Fiscal_N = 4 Then
                                        '    Try
                                        '        Dim xreport = Fmain.ACFiscalbox.GetXReport(Fmain.ACLogin.Data.Access_token, Fmain.p_Person.ID2)
                                        '        If xreport.Code <> "0" Then
                                        '            Mesigi(xreport.Message + " (" + xreport.Code + ")", "Fiscalbox: GetXReport")
                                        '            Exit Sub
                                        '        End If
                                        '    Catch ex As Exception
                                        '        Fmain.Write_In_Log("Err ACFiscalbox GetXReport: " & ex.Message)
                                        '        MessageBox.Show(ex.Message, "Fiscal Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        '        Fmain.DaisyFP.Dispose()
                                        '    End Try
                                    End If

                                    If Fmain.Fiscal_N = 1 Then

                                        F_FP_SC_DR.X_Amogheba()
                                        Try
                                            Fmain.Init_Z_Appx("X")
                                        Catch ex_x As Exception
                                            Fmain.Write_In_Log("Err_Do_X_Appx: Z_Appx ar amodis")
                                        End Try

                                    ElseIf Fmain.Fiscal_N = 2 Or Fmain.Fiscal_N = 3 Then
                                        M_SLP.X_Amogheba_SLP()
                                    End If
                                    If Fmain.Printer_N = 1 And Fmain.fp_daisy = 0 Then
                                        Fmain.b_Daibechda(0) = False
                                        Fmain.b_Daibechda(1) = False
                                        Fmain.b_Daibechda(2) = False
                                        Do While (((Fmain.b_Daibechda(0) And Fmain.b_Daibechda(1)) And Fmain.b_Daibechda(2)) = False)
                                            Fmain.PD.DocumentName = "X"
                                            Fmain.PD.Print()
                                            Fmain.Refresh()
                                        Loop
                                    End If
                                Else
                                    Mesigi("X-ის ამოღება შეუძლია მხოლოდ ადმინისტრატორს", "შეცდომა")
                                End If
                            End If
                        End If
                    End If
                Case "Z-ის ამოღება"
                    If Mesigi("ნამდვილად გსურთ Z-ის ამოღება?", "Z ანგარიში", True) Then
                        M_Z.Jast_Do_Z()
                    End If
                Case "ჩეკის დაბრუნება"
                    If Mesigi("ნამდვილად გსურთ გაყიდული საქონლის დაბრუნება?", , True) Then
                        If Fmain.p_Person.Role = 9 Then
                            Fmain.Sale_Back()
                        Else
                            If Avtorizacia() Then
                                If Fmain.p_Person.Role2 = 9 Then
                                    Fmain.Sale_Back()
                                Else
                                    Mesigi("ჩეკის დაბრუნება შეუძლია მხოლოდ ადმინისტრატორს", "შეცდომა")
                                End If
                            End If
                        End If
                    End If
                Case "18% ფასდაკლება"
                    If Fmain.b_Fasdakleba_Moxda > 0 Then
                        Mesigi("ფასდაკლება უკვე გაკეთებულია", "შეცდომა")
                    Else
                        If Mesigi("ნამდვილად გსურთ 18% ფასდაკლების გაკეთება?", "ფასდაკლება დიპლომატებსათვის", True) Then
                            If Fmain.p_Person.Role = 9 Then
                                fasdakleba(18)
                            Else
                                If Avtorizacia() Then
                                    If Fmain.p_Person.Role2 = 9 Then
                                        fasdakleba(18)
                                    Else
                                        Mesigi("ფასდაკლების გაკეთება შეუძლია მხოლოდ ადმინისტრატორს", "შეცდომა")
                                    End If
                                End If
                            End If
                        End If
                    End If
                Case "10% ფასდაკლება"
                    If Fmain.b_Fasdakleba_Moxda > 0 Then
                        Mesigi("ფასდაკლება უკვე გაკეთებულია", "შეცდომა")
                    Else
                        If Mesigi("ნამდვილად გსურთ 10% ფასდაკლების გაკეთება?", "ფასდაკლება", True) Then
                            If Fmain.p_Person.Role = 9 Then
                                fasdakleba(10)
                            Else
                                If Avtorizacia() Then
                                    If Fmain.p_Person.Role2 = 9 Then
                                        fasdakleba(10)
                                    Else
                                        Mesigi("ფასდაკლების გაკეთება შეუძლია მხოლოდ ადმინისტრატორს", "შეცდომა")
                                    End If
                                End If
                            End If
                        End If
                    End If
                Case "ფასების განახლება"
                    If Mesigi("ნამდვილად გსურთ ფასების განახლება?", , True) Then
                        M_SQL.Update_Price()
                    End If
                Case "ფასების სრული განახლება"
                    Mesigi("ამ ოპერაციის გაკეთება არ არის რეკომენდირებული", "გაფრთხილება")
                    If Mesigi("ნამდვილად გსურთ ახალი 'PriceList'-ის გადმოწერა? ამას შეიძლება დასჭირდეს რამდენიმე წუთი", , True) Then
                        If Fmain.p_Person.Role = 9 Then
                            M_SQL.New_Price()
                        Else
                            If Avtorizacia() Then
                                If Fmain.p_Person.Role2 = 9 Then
                                    M_SQL.New_Price()
                                Else
                                    Mesigi("'PriceList'-ის გადმოწერა შეუძლია მხოლოდ ადმინისტრატორს", "შეცდომა")
                                End If
                            End If
                        End If
                    End If
                Case "მოწყობილობების კონტროლი"
                    Dim F_Sett As New Fsettings
                    F_Sett.ShowDialog()
                    F_Sett = Nothing
                Case "პროგრამიდან გამოსვლა"
                    Fmain.Close()
                    Application.Exit()
                    'Application.Exit()
                Case "TBC ტერმინალი"
                    frmTerminalFuncs.ShowDialog()
            End Select
            Me.Close()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub fasdakleba(ByVal proc As Short)
        If proc = 18 Then
            Fmain.d_Tanxa = 0
            For i As Integer = 0 To Fmain.DGV_Sales.Rows.Count - 1
                Fmain.DGV_Sales.Rows(i).Cells(3).Value = Math.Round(Val(Fmain.DGV_Sales.Rows(i).Cells(3).Value) / 1.18, 2, MidpointRounding.AwayFromZero)
                Fmain.DGV_Sales.Rows(i).Cells(5).Value = Math.Round(Val(Fmain.DGV_Sales.Rows(i).Cells(5).Value) / 1.18, 2, MidpointRounding.AwayFromZero)
                Update_For_Discount(Fmain.Check_Number, Fmain.DGV_Sales.Rows(i).Cells(0).Value, Fmain.DGV_Sales.Rows(i).Cells(3).Value, "diplomat")
                Fmain.d_Tanxa += Val(Fmain.DGV_Sales.Rows(i).Cells(5).Value)
            Next
            Fmain.d_Tanxa = Math.Round(Fmain.d_Tanxa, 2, MidpointRounding.AwayFromZero)
        ElseIf proc = 8 Then
            Fmain.d_Tanxa = 0
            For i As Integer = 0 To Fmain.DGV_Sales.Rows.Count - 1
                Fmain.DGV_Sales.Rows(i).Cells(3).Value = Math.Round(Val(Fmain.DGV_Sales.Rows(i).Cells(3).Value) / 1.08, 2, MidpointRounding.AwayFromZero)
                Fmain.DGV_Sales.Rows(i).Cells(5).Value = Math.Round(Val(Fmain.DGV_Sales.Rows(i).Cells(5).Value) / 1.08, 2, MidpointRounding.AwayFromZero)
                Update_For_Discount(Fmain.Check_Number, Fmain.DGV_Sales.Rows(i).Cells(0).Value, Fmain.DGV_Sales.Rows(i).Cells(3).Value, "restaurant")
                Fmain.d_Tanxa += Val(Fmain.DGV_Sales.Rows(i).Cells(5).Value)
            Next
            Fmain.d_Tanxa = Math.Round(Fmain.d_Tanxa, 2, MidpointRounding.AwayFromZero)
        ElseIf proc = 10 Then
            Fmain.d_Tanxa = 0
            For i As Integer = 0 To Fmain.DGV_Sales.Rows.Count - 1
                Fmain.DGV_Sales.Rows(i).Cells(3).Value = Math.Round(Val(Fmain.DGV_Sales.Rows(i).Cells(3).Value) * 0.9, 2, MidpointRounding.AwayFromZero)
                Fmain.DGV_Sales.Rows(i).Cells(5).Value = Math.Round(Val(Fmain.DGV_Sales.Rows(i).Cells(5).Value) * 0.9, 2, MidpointRounding.AwayFromZero)
                Update_For_Discount(Fmain.Check_Number, Fmain.DGV_Sales.Rows(i).Cells(0).Value, Fmain.DGV_Sales.Rows(i).Cells(3).Value, "discount_10p")
                Fmain.d_Tanxa += Val(Fmain.DGV_Sales.Rows(i).Cells(5).Value)
            Next
            Fmain.d_Tanxa = Math.Round(Fmain.d_Tanxa, 2, MidpointRounding.AwayFromZero)
        End If
        Fmain.lbl_Tanxa.Text = Math.Round(Fmain.d_Tanxa, 2, MidpointRounding.AwayFromZero).ToString("#####0.00")
        Fmain.b_Fasdakleba_Moxda = proc
        Fmain.lbl_SaleType.Text &= " -" & proc & "%"
        Fmain.TranslateUI(Fmain.Panel_Header, Fmain.UITerms)
        Fmain.lbl_Gasacemi.Text = (Math.Round(Fmain.d_Tanxa, 2, MidpointRounding.AwayFromZero) - 2 * Math.Round(Fmain.d_Tanxa, 2, MidpointRounding.AwayFromZero)).ToString("#####0.00")
    End Sub

    Private Sub GridF_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridF.CellClick
        SendKeys.Send("{ENTER}")
    End Sub
End Class