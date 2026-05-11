Public Class Fstart

    Private Sub Fstart_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Process_Control()
        LoadUITerms()
        If Avtorizacia() Then
            Person_Initials()
            Fmain.Show()
            Me.Close()
        Else
            Me.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub Process_Control()
        Dim a_Process_List As New ArrayList
        Dim ProcListi() As Process
        Dim P As Process
        ProcListi = Process.GetProcesses
        For Each P In ProcListi
            a_Process_List.Add(P.ProcessName)
        Next
        If a_Process_List.Contains("Shop") Then
            a_Process_List.Remove("Shop")
            If a_Process_List.Contains("Shop") Then
                Application.Exit()
            End If
        End If
        a_Process_List.Clear()
    End Sub

    Private Sub Person_Initials()
        Fmain.p_Person.ID = Fmain.p_Person.ID2
        Fmain.p_Person.Name = Fmain.p_Person.Name2
        Fmain.p_Person.Pass = Fmain.p_Person.Pass2
        Fmain.p_Person.Role = Fmain.p_Person.Role2
        Fmain.lbl_Saxeli.Text = Fmain.p_Person.Name2
        Select Case Fmain.p_Person.Role
            Case 9
                Fmain.lbl_Status.Text = "▲"
            Case 10
                Fmain.lbl_Status.Text = "▼"
        End Select
    End Sub

    Private Sub LoadUITerms()
        Fmain.UITerms = M_SQL.GetUiTerms()
        Fmain.CheckTerms = M_SQL.GetCheckTerms()
    End Sub
End Class