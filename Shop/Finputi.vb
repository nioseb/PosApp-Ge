Public Class Finputi

    Public Input_Text As String = String.Empty

    Private Sub Finputi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Finputi_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Dim i_Top As Integer
        If (InpTxt.Top + InpTxt.Height) > (InpCancel.Top + InpCancel.Height) Then
            i_Top = InpTxt.Top + InpTxt.Height + 10
        Else
            i_Top = InpCancel.Top + InpCancel.Height + 10
        End If
        If InpTxt.Width > 245 Then
            InpOK.Left = InpTxt.Width + 10
            InpCancel.Left = InpTxt.Width + 10
        End If
        Text_Input.Top = i_Top
        Text_Input.Width = Me.Width - 30
    End Sub

    Private Sub InpOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InpOK.Click
        Input_Text = Text_Input.Text
        Me.Close()
    End Sub

    Private Sub InpCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InpCancel.Click
        Me.Close()
    End Sub

    Private Sub Text_Input_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Text_Input.KeyDown
        If e.KeyCode = Keys.Enter Then
            Input_Text = Text_Input.Text
            Me.Close()
        End If
    End Sub

    Private Sub Text_Input_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_Input.Click
        frmNumpad.Visible = False
        frmNumpad.Left = Me.Left + Text_Input.Left
        frmNumpad.Top = Me.Top + Text_Input.Top + 2 * Text_Input.Height + 1
        frmNumpad.fSender = Me
        frmNumpad.Visible = True
        Me.Focus()
    End Sub

    Private Sub Text_Input_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_Input.Enter
        frmNumpad.Visible = False
        frmNumpad.Left = Me.Left + Text_Input.Left
        frmNumpad.Top = Me.Top + Text_Input.Top + 2 * Text_Input.Height + 1
        frmNumpad.fSender = Me
        frmNumpad.Visible = True
        Me.Focus()
    End Sub

    Private Sub Finputi_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmNumpad.Visible = False
    End Sub

    Private Sub Finputi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Fmain.TranslateUI(Me, Fmain.UITerms)
    End Sub
End Class