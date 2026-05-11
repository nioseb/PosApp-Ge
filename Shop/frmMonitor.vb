Public Class frmMonitor

    Private Sub frmMonitor_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'Cursor.Hide()
    End Sub

    Private Sub frmMonitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IO.File.Exists("panel_monitor.jpg") Then
            UltraPictureBox1.Image = Image.FromFile("panel_monitor.jpg")
        End If
    End Sub
End Class