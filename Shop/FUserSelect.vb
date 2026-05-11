Public Class FUserSelect
    Public SelectedCellIndex As Integer = -1

    Private Sub FUserSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridF.Rows.Clear()
        GridF.Height = 30
        Dim index As Integer = 0
        For Each person As String In Fmain.personnel_list
            GridF.Height += 42
            GridF.Rows.Add()
            GridF.Rows(index).Cells(0).Value = person
            index += 1
        Next
        Me.Height = GridF.Height
        Me.Top = (Screen.AllScreens(0).WorkingArea.Height - Me.Height) / 2
    End Sub

    Private Sub GridF_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridF.CellClick
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub GridF_KeyDown(sender As Object, e As KeyEventArgs) Handles GridF.KeyDown
        If e.KeyCode = Keys.Enter Then
            If GridF.Rows.Count > 0 Then
                SelectedCellIndex = GridF.SelectedCells(0).RowIndex
                Fmain.lbl_Saxeli.Text = GridF.SelectedCells(0).Value.ToString()
                If Fmain.OrderedTable IsNot Nothing Then
                    Fmain.OrderedTable.Supervisor = GridF.SelectedCells(0).Value.ToString()
                    If Fmain.OrderedTable.CheckN.HasValue Then
                        Using conn As New SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
                            Using comm As New SqlClient.SqlCommand()
                                comm.Connection = conn
                                comm.CommandType = CommandType.Text
                                comm.CommandText = "update table_orders set supervisor = @supervisor where check_n = @check_n"
                                comm.Parameters.Add("@check_n", SqlDbType.Int).Value = Fmain.OrderedTable.CheckN
                                comm.Parameters.Add("@supervisor", SqlDbType.NVarChar, 50).Value = Fmain.OrderedTable.Supervisor
                                conn.Open()
                                comm.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End If
                DialogResult = DialogResult.OK
                Visible = False
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            DialogResult = DialogResult.Cancel
            Visible = False
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Visible = False
    End Sub

    Private Sub FUserSelect_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Visible = False
    End Sub
End Class