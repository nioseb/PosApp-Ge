Public Class Favtorizacia

    Public b_Dashvebulia As Boolean

    Private Sub Favtorizacia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextID.Focused And Len(TextID.Text) = 6 Then
                TextPass.Focus()
            ElseIf (TextID.Text <> String.Empty Or TextPass.Text <> String.Empty) Then
                Shemowmeba()
                'ElseIf Len(TextID.Text) = 34 Then
                '    TextID.Text = TextID.Text.Substring(TextID.Text.IndexOf("=") - 4, TextID.Text.IndexOf("="))
                '    TextPass.Text = TextID.Text.Substring(Text
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            TextID.Clear()
            TextPass.Clear()
            TextID.Focus()
            Me.Close()
        End If
        If e.Control Then
            If e.KeyCode = Keys.M Then
                'Favtorizacia_KeyDown(sender, New System.Windows.Forms.KeyEventArgs(Keys.Enter))
                SendKeys.Send("{ENTER}")
            End If
            If e.KeyCode = Keys.I Then
                'Favtorizacia_KeyDown(sender, New System.Windows.Forms.KeyEventArgs(Keys.Tab))
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Sub Shemowmeba()
        Dim Conn1 As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
        Dim Comm1 As New System.Data.SqlClient.SqlCommand
        Dim Reader1 As SqlClient.SqlDataReader
        Dim s_ID, s_Pass As String
        If Len(TextID.Text) = 34 Then
            s_ID = Mid(TextID.Text, 13, 4)
            s_Pass = Mid(TextID.Text, 13, 15)
        ElseIf Len(TextID.Text) = 6 Then
            s_ID = Mid(TextID.Text, 2, 4)
            s_Pass = Mid(TextPass.Text, 2, 15)
        ElseIf Len(TextID.Text) = 17 Then
            s_ID = Mid(TextID.Text, 2, 4)
            s_Pass = Mid(TextID.Text, 2, 15)
        ElseIf Len(TextID.Text) = 19 Then
            s_ID = Mid(TextID.Text, 1, 4)
            s_Pass = Mid(TextID.Text, 5, 15)
            'MessageBox.Show(s_ID.ToString() + " | " + s_Pass.ToString())
        Else
            's_ID = TextID.Text
            's_ID =Mid(TextPass.Text, 2, 4) signagistvis
            s_ID = Mid(TextPass.Text, 1, 4)
            s_Pass = TextPass.Text
        End If
        Comm1.Connection = Conn1
        Comm1.CommandText = "SELECT * FROM users WHERE useris_id='" & s_ID & "' AND password='" & s_Pass & "'"
        Try
            Conn1.Open()
            Reader1 = Comm1.ExecuteReader
            While Reader1.Read
                Fmain.p_Person.ID2 = Reader1.Item(0)
                Fmain.p_Person.Name2 = Reader1.Item(1)
                If Not (Reader1.Item(3) Is DBNull.Value) Then
                    Fmain.p_Person.Role2 = Reader1.Item(3)
                End If
                If Fmain.p_Person.Role2 = 9 Or Fmain.p_Person.Role2 = 10 Then
                    b_Dashvebulia = True
                End If
            End While
            Reader1.Close()
        Catch ex As Exception
            Mesigi(ex.Message, "Err_Shemowmeba:")
            Fmain.Write_In_Log("Err_Shemowmeba: " & ex.Message)
        Finally
            Conn1.Close()
        End Try
        If b_Dashvebulia Then
            TextID.Clear()
            TextPass.Clear()
            TextID.Focus()
            Me.Close()
        Else
            Mesigi("ავტორიზაცია ვერ გაიარეთ, გთხოვთ სცადოთ თავიდან")
            Fmain.Write_In_Log("avtorizacia ver gaiara: ID=" & TextID.Text & ", PassWord=" & TextPass.Text)
            TextID.Clear()
            TextPass.Clear()
            TextID.Focus()
        End If
    End Sub

    Private Sub Favtorizacia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Fmain.TranslateUI(Me, Fmain.UITerms)
    End Sub

    Private Sub Favtorizacia_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        TextID.Text = "0594"
        TextPass.Text = "0594=9439102487"
        Shemowmeba()
    End Sub
End Class