Public Class Fmesigi

    Public mesig_Status As Boolean = False

    Private Sub Fmesigi_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Dim i_Top As Integer = MsgLabel.Top + MsgLabel.Height + 10
        MsgYes.Top = i_Top
        MsgOK.Top = i_Top
        MsgNo.Top = i_Top

        MsgOK.Left = Int((Me.Width - MsgOK.Width) / 2)
        MsgYes.Left = MsgOK.Left - 55
        MsgNo.Left = MsgOK.Left + 55
    End Sub

    Private Sub MsgOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MsgOK.Click
        Me.Close()
    End Sub

    Private Sub MsgYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MsgYes.Click
        mesig_Status = True
        Me.Close()
    End Sub

    Private Sub MsgNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MsgNo.Click
        Me.Close()
    End Sub

    Private Sub Fmesigi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Fmain.TranslateUI(Me, Fmain.UITerms)
    End Sub
End Class