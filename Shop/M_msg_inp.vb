Module M_msg_inp

    Public Function Mesigi(ByVal s_STR As String, Optional ByVal s_Status As String = "შეტყობინება:", Optional ByVal YN As Boolean = False, Optional ByVal s_Header As String = "მესიჯი", Optional ByVal No_Focus As Boolean = False, Optional ByVal pause As Boolean = False, Optional ByVal blink As Boolean = False, Optional ByVal dialog As Boolean = True, Optional ByVal NoButtons As Boolean = False) As Boolean
        Dim M As New Fmesigi
        For j As Integer = 38 To Len(s_STR)
            If Mid(s_STR, j, 1) = " " Then
                s_STR = s_STR.Insert(j, Chr(13))
                j += 38
            End If
        Next
        M.MsgLabel.Text = s_STR
        M.Text = s_Header
        M.MsgStatus.Text = s_Status
        If No_Focus Then
            M.MsgNo.TabIndex = 1
        End If
        If YN Then
            M.MsgOK.Visible = False
            M.MsgYes.Visible = True
            M.MsgNo.Visible = True
            M.MsgYes.Focus()
        Else
            M.MsgOK.Visible = True
            M.MsgYes.Visible = False
            M.MsgNo.Visible = False
            M.MsgOK.Focus()
        End If
        Beep()
        M.ShowDialog()
        Return (M.mesig_Status)
    End Function

    Public Function Inputi(ByVal s_STR As String, Optional ByVal s_Header As String = "Input") As String
        Dim Inp As New FInputi
        For j As Integer = 30 To Len(s_STR)
            If Mid(s_STR, j, 1) = " " Then
                s_STR = s_STR.Insert(j, Chr(13))
                j += 30
            End If
        Next
        Inp.InpTxt.Text = s_STR
        Inp.Text = s_Header
        Inp.ShowDialog()
        Return (Inp.Input_Text)
    End Function

    Public Function Avtorizacia() As Boolean
        Dim Avtorizacia_NEW As New Favtorizacia
        Avtorizacia_NEW.ShowDialog()
        Return (Avtorizacia_NEW.b_Dashvebulia)
    End Function
End Module
