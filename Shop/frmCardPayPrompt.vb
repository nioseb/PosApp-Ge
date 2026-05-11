Public Class frmCardPayPrompt
    Public Paytype As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Height < 400 Then
            Height += 170
            Button2.Image = My.Resources.double_arrow_up
        Else
            Height -= 170
            Button2.Image = My.Resources.double_arrow_down
        End If
    End Sub

    Private Sub MsgYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MsgYes.Click
        Paytype = 1
    End Sub

    Private Sub btnInstallment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInstallment.Click
        Paytype = 2
    End Sub
End Class