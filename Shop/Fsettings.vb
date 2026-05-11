Public Class Fsettings

    Private Sub Fsettings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Fsettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Flist.Close()
        cmb_Fiscal.Items.Add("არა")
        cmb_Fiscal.Items.Add("SLP დეტალური ჩეკით")
        cmb_Fiscal.Items.Add("SLP არადეტალური ჩეკით")

        cmb_Scanner.Items.Add("არა")
        cmb_Scanner.Items.Add("დიახ")

        cmb_Drawer.Items.Add("არა")
        cmb_Drawer.Items.Add("დიახ")

        cmb_Printer.Items.Add("არა")
        cmb_Printer.Items.Add("დიახ")
        Dim ConnL As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand("SELECT fiscal, scanner, drawer, printer FROM settings", ConnL)
        Dim Reader As SqlClient.SqlDataReader
        Try
            ConnL.Open()
            Reader = Comm.ExecuteReader
            While Reader.Read
                Select Case Reader.Item(0)
                    Case 0
                        cmb_Fiscal.SelectedIndex = 0
                    Case 2
                        cmb_Fiscal.SelectedIndex = 1
                    Case 3
                        cmb_Fiscal.SelectedIndex = 2
                End Select
                cmb_Scanner.SelectedIndex = Reader.Item(1)
                cmb_Drawer.SelectedIndex = Reader.Item(2)
                cmb_Printer.SelectedIndex = Reader.Item(3)
            End While
            Reader.Close()
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Settings.Load: " & ex.Message)
            Mesigi("Err_Settings.Load: " & ex.Message)
        Finally
            ConnL.Close()
        End Try
    End Sub

    Private Sub btn_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Dim ConnL As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm As New SqlClient.SqlCommand("UPDATE settings SET fiscal=@fiscal, scanner=@scanner, drawer=@drawer, printer=@printer", ConnL)
        Try
            ConnL.Open()
            Comm.Parameters.Add("@fiscal", SqlDbType.TinyInt)
            Select Case cmb_Fiscal.SelectedIndex
                Case 0
                    Comm.Parameters.Item(0).Value = 0
                Case 1
                    Comm.Parameters.Item(0).Value = 2
                Case 2
                    Comm.Parameters.Item(0).Value = 3
            End Select
            Comm.Parameters.Add("@scanner", SqlDbType.TinyInt).Value = cmb_Scanner.SelectedIndex
            Comm.Parameters.Add("@drawer", SqlDbType.TinyInt).Value = cmb_Drawer.SelectedIndex
            Comm.Parameters.Add("@printer", SqlDbType.TinyInt).Value = cmb_Printer.SelectedIndex
            Comm.ExecuteNonQuery()
            Comm.Parameters.Clear()
            If Mesigi("ცვლილებების სისრულეში მოსაყვანად პროგრამა უნდა გაეშვას თავიდან, გსურთ პროგრამის თავიდან გაშვება?", , True) Then
                Application.Exit()
            End If
        Catch ex As Exception
            Fmain.Write_In_Log("Err_Settings_Update: " & ex.Message)
            Mesigi("Err_Settings_Update: " & ex.Message)
        Finally
            ConnL.Close()
        End Try
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub
End Class