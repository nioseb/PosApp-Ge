Public Class frmMonitorCheck
    Dim state As Boolean
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If state Then
            If Me.Opacity < 0.8 Then
                Me.Opacity = Me.Opacity + 0.05
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity = Me.Opacity - 0.05
            Else
                Me.Close()
            End If
        End If

    End Sub

    Private Sub frmMonitorCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        state = True
        Fmain.TranslateUI(Me, Fmain.UITerms)
        'Opacity = 1
        'UltraGrid1.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:0.00} " + Fmain.UITermsValue("ლ.")
        Me.Timer1.Enabled = True

        If IO.File.Exists("panel_item.jpg") Then
            PictureBox1.Image = Image.FromFile("panel_item.jpg")
        End If
    End Sub

    Public Sub CloseEx()
        state = False
        'Me.Close()
    End Sub
End Class