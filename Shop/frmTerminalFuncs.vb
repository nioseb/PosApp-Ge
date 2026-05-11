Public Class frmTerminalFuncs

    Private Function InitTerminal() As eptcvx.Terminal
        Dim port As String = Fmain.BankTerminalPort
        Dim terminal As New eptcvx.Terminal(Fmain.BankTerminalId)
        terminal.PortInfo.PortName = Fmain.BankTerminalPort

        InitTerminal = terminal
    End Function

    Private Sub btnShortReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShortReport.Click
        If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
            Try
                If Not Fmain.CheckPrinter() Then
                    Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                    Exit Sub
                End If

                Dim terminal As eptcvx.Terminal = InitTerminal()
                Dim term_res As String = terminal.ShortReport()

                If Not String.IsNullOrEmpty(terminal.ReceiptData) Then
                    Fmain.BankTerminalData = terminal.ReceiptData
                    If Fmain.fp_daisy = 2 Then
                        M_Daisy.Print_Terminal_Response(terminal.ReceiptData, "-------მოკლე  რეპორტი-------")
                    ElseIf Fmain.Printer_N = 1 Then
                        Fmain.PD.DocumentName = "terminal_check"
                        Fmain.PD.Print()
                    End If
                End If

                If Not String.IsNullOrEmpty(term_res) Then
                    Fmain.Write_In_Log("Err terminal short report: " & term_res)
                    MessageBox.Show("ტერმინალის შეცდომა" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - Short report", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Terminal_ShortReport:")
                Fmain.Write_In_Log("Err_Terminal_ShortReport: " & ex.Message + Environment.NewLine + ex.StackTrace)
                Exit Sub
            Finally
                Fmain.BankTerminalData = String.Empty
            End Try

            Mesigi("ოპერაცია შესრულდა წარმატებით")
        End If
    End Sub

    Private Sub btnFullReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFullReport.Click
        If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
            Try
                If Not Fmain.CheckPrinter() Then
                    Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                    Exit Sub
                End If

                Dim terminal As eptcvx.Terminal = InitTerminal()
                Dim term_res As String = terminal.FullReport()

                If Not String.IsNullOrEmpty(terminal.ReceiptData) Then
                    Fmain.BankTerminalData = terminal.ReceiptData
                    If Fmain.fp_daisy = 2 Then
                        M_Daisy.Print_Terminal_Response(terminal.ReceiptData, "-------სრული  რეპორტი-------")
                    ElseIf Fmain.Printer_N = 1 Then
                        Fmain.PD.DocumentName = "terminal_check"
                        Fmain.PD.Print()
                    End If
                End If

                If Not String.IsNullOrEmpty(term_res) Then
                    Fmain.Write_In_Log("Err terminal full report: " & term_res)
                    MessageBox.Show("ტერმინალის შეცდომა" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - Full report", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Terminal_FullReport:")
                Fmain.Write_In_Log("Err_Terminal_FullReport: " & ex.Message + Environment.NewLine + ex.StackTrace)
                Exit Sub
            Finally
                Fmain.BankTerminalData = String.Empty
            End Try

            Mesigi("ოპერაცია შესრულდა წარმატებით")
        End If
    End Sub

    Private Sub btnReconciliation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconciliation.Click
        If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
            Try
                If Not Fmain.CheckPrinter() Then
                    Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                    Exit Sub
                End If

                Dim terminal As eptcvx.Terminal = InitTerminal()
                Dim term_res As String = terminal.Reconciliation()

                If Not String.IsNullOrEmpty(terminal.ReceiptData) Then
                    Fmain.BankTerminalData = terminal.ReceiptData
                    If Fmain.fp_daisy = 2 Then
                        M_Daisy.Print_Terminal_Response(terminal.ReceiptData, "--------დღის დახურვა--------")
                    ElseIf Fmain.Printer_N = 1 Then
                        Fmain.PD.DocumentName = "terminal_check"
                        Fmain.PD.Print()
                    End If
                End If

                If Not String.IsNullOrEmpty(term_res) Then
                    Fmain.Write_In_Log("Err terminal reconciliation: " & term_res)
                    MessageBox.Show("ტერმინალის შეცდომა" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - Reconciliation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Terminal_Reconciliation:")
                Fmain.Write_In_Log("Err_Terminal_Reconciliation: " & ex.Message + Environment.NewLine + ex.StackTrace)
                Exit Sub
            Finally
                Fmain.BankTerminalData = String.Empty
            End Try

            Mesigi("ოპერაცია შესრულდა წარმატებით")
        End If
    End Sub

    Private Sub btnLastReceiptCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastReceiptCopy.Click
        If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
            Try
                If Not Fmain.CheckPrinter() Then
                    Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                    Exit Sub
                End If

                Dim terminal As eptcvx.Terminal = InitTerminal()
                Dim term_res As String = terminal.LastReceiptCopy()

                If Not String.IsNullOrEmpty(terminal.ReceiptData) Then
                    Fmain.BankTerminalData = terminal.ReceiptData
                    If Fmain.fp_daisy = 2 Then
                        M_Daisy.Print_Terminal_Response(terminal.ReceiptData, "-----ბოლო  ქვითრის ასლი-----")
                    ElseIf Fmain.Printer_N = 1 Then
                        Fmain.PD.DocumentName = "terminal_check"
                        Fmain.PD.Print()
                    End If
                End If

                If Not String.IsNullOrEmpty(term_res) Then
                    Fmain.Write_In_Log("Err terminal last receipt copy: " & term_res)
                    MessageBox.Show("ტერმინალის შეცდომა" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - Last receipt copy", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Terminal_LastReceiptCopy:")
                Fmain.Write_In_Log("Err_Terminal_LastReceiptCopy: " & ex.Message + Environment.NewLine + ex.StackTrace)
                Exit Sub
            Finally
                Fmain.BankTerminalData = String.Empty
            End Try

            Mesigi("ოპერაცია შესრულდა წარმატებით")
        End If
    End Sub

    Private Sub btnReceiptCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptCopy.Click
        If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
            Try
                If Not Fmain.CheckPrinter() Then
                    Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                    Exit Sub
                End If

                Dim terminal As eptcvx.Terminal = InitTerminal()
                Dim term_res As String = terminal.ReceiptCopy()

                If Not String.IsNullOrEmpty(terminal.ReceiptData) Then
                    Fmain.BankTerminalData = terminal.ReceiptData
                    If Fmain.fp_daisy = 2 Then
                        M_Daisy.Print_Terminal_Response(terminal.ReceiptData, "--------ქვითრის ასლი--------")
                    ElseIf Fmain.Printer_N = 1 Then
                        Fmain.PD.DocumentName = "terminal_check"
                        Fmain.PD.Print()
                    End If
                End If

                If Not String.IsNullOrEmpty(term_res) Then
                    Fmain.Write_In_Log("Err terminal last receipt copy: " & term_res)
                    MessageBox.Show("ტერმინალის შეცდომა" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - Last receipt copy", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Terminal_ReceiptCopy:")
                Fmain.Write_In_Log("Err_Terminal_ReceiptCopy: " & ex.Message + Environment.NewLine + ex.StackTrace)
                Exit Sub
            Finally
                Fmain.BankTerminalData = String.Empty
            End Try

            Mesigi("ოპერაცია შესრულდა წარმატებით")
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckConnection.Click
        If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
            Try
                If Not Fmain.CheckPrinter() Then
                    Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                    Exit Sub
                End If

                Dim terminal As eptcvx.Terminal = InitTerminal()
                Dim term_res As String = terminal.CheckHostConnection()

                If Not String.IsNullOrEmpty(terminal.ReceiptData) Then
                    Fmain.BankTerminalData = terminal.ReceiptData
                    If Fmain.fp_daisy = 2 Then
                        M_Daisy.Print_Terminal_Response(terminal.ReceiptData, "-----კავშირის შემოწმება-----")
                    ElseIf Fmain.Printer_N = 1 Then
                        Fmain.PD.DocumentName = "terminal_check"
                        Fmain.PD.Print()
                    End If
                End If

                If Not String.IsNullOrEmpty(term_res) Then
                    Fmain.Write_In_Log("Err terminal check connection: " & term_res)
                    MessageBox.Show("ტერმინალის შეცდომა" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - check connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Terminal_CheckConnection:")
                Fmain.Write_In_Log("Err_Terminal_CheckConnection: " & ex.Message + Environment.NewLine + ex.StackTrace)
                Exit Sub
            Finally
                Fmain.BankTerminalData = String.Empty
            End Try

            Mesigi("ოპერაცია შესრულდა წარმატებით")
        End If
    End Sub

    Private Sub btnCheckConnection2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(Fmain.BankTerminalId) Then
            Try
                If Not Fmain.CheckPrinter() Then
                    Mesigi("საბეჭდი მოწყობილობა არ არის გამართული. ოპერაციის განხორციელება შეუძლებელია")
                    Exit Sub
                End If

                Dim terminal As eptcvx.Terminal = InitTerminal()
                terminal.Id = String.Empty
                Dim term_res As String = terminal.CheckHostConnection()

                If Not String.IsNullOrEmpty(terminal.ReceiptData) Then
                    Fmain.BankTerminalData = terminal.ReceiptData
                    If Fmain.fp_daisy = 2 Then
                        M_Daisy.Print_Terminal_Response(terminal.ReceiptData, "-----კავშირის შემოწმება-----")
                    ElseIf Fmain.Printer_N = 1 Then
                        Fmain.PD.DocumentName = "terminal_check"
                        Fmain.PD.Print()
                    End If
                End If

                If Not String.IsNullOrEmpty(term_res) Then
                    Fmain.Write_In_Log("Err terminal check connection: " & term_res)
                    MessageBox.Show("ტერმინალის შეცდომა" + Environment.NewLine + "(" + term_res + ")", "Bank Terminal Error - check connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
                Mesigi(ex.Message, "Err_Terminal_CheckConnection:")
                Fmain.Write_In_Log("Err_Terminal_CheckConnection: " & ex.Message + Environment.NewLine + ex.StackTrace)
                Exit Sub
            Finally
                Fmain.BankTerminalData = String.Empty
            End Try

            Mesigi("ოპერაცია შესრულდა წარმატებით")
        End If
    End Sub
End Class