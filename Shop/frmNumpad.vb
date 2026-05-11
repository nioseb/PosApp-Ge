Public Class frmNumpad

    Private _FocusForm As Form

    Public Property fSender() As Form
        Get
            fSender = _FocusForm
        End Get
        Set(ByVal value As Form)
            _FocusForm = value
        End Set
    End Property

    Private Sub UltraButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton8.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("7")
    End Sub

    Private Sub UltraButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton15.Click
        _FocusForm.Focus()
        SendKeys.Send("{ESC}")
    End Sub

    Private Sub UltraButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton14.Click
        If (_FocusForm IsNot Nothing) Then
            _FocusForm.Focus()
        Else
            Fmain.Focus()
        End If
        Try
            SendKeys.Send("{F5}")
        Catch
        End Try
        Me.Visible = False
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("0")
    End Sub

    Private Sub UltraButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton11.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send(".")
    End Sub

    Private Sub UltraButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton2.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("1")
    End Sub

    Private Sub UltraButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton3.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("2")
    End Sub

    Private Sub UltraButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton4.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("3")
    End Sub

    Private Sub UltraButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton5.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("4")
    End Sub

    Private Sub UltraButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton6.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("5")
    End Sub

    Private Sub UltraButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton7.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("6")
    End Sub

    Private Sub UltraButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton9.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("8")
    End Sub

    Private Sub UltraButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton10.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("9")
    End Sub

    Private Sub UltraButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton16.Click
        _FocusForm.Focus()
        SendKeys.Send("{DEL}")
    End Sub

    Private Sub UltraButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton13.Click
        _FocusForm.Focus()
        Fmain.txt_kodi.SelectionStart = Fmain.txt_kodi.Text.Length
        Fmain.txt_kodi.SelectionLength = 0
        SendKeys.Send("{BACKSPACE}")
    End Sub

    Private Sub UltraButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton12.Click
        _FocusForm.Focus()
        SendKeys.Send("{ENTER}")
        Me.Visible = False
    End Sub

    Private Sub frmNumpad_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmNumpad_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmNumpad_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
End Class