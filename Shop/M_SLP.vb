Module M_SLP

    'Dim SLP As New SlpFp.Exchange

    Public Sub Open_SLP()
        'SLP.Port = "COM1"
        'SLP.AdmPassword = "123456"
        'SLP.Password = "000001"
        'If SLP.OpenPort <> 0 Then
        '    Mesigi("Can't Open Port(COM1, SLP): " & SLP.ErrorMessage)
        '    Fmain.Write_In_Log("SLP - Can't Open Port(COM1)")
        'End If
    End Sub

    Public Sub Close_SLP()
        'Try
        '    If SLP.ClosePort <> 0 Then
        '        Mesigi("Can't Close Port(COM1, SLP): " & SLP.ErrorMessage)
        '        Fmain.Write_In_Log("SLP - Can't Close Port(COM1)")
        '    End If
        'Catch ex As Exception
        '    Mesigi(ex.ToString)
        'End Try
    End Sub

    Public Sub SetDate_SLP()
        'If SLP.SetDateTime <> 0 Then
        '    Mesigi("Can't SetDateTime(SLP): " & SLP.ErrorMessage)
        '    Fmain.Write_In_Log("SLP - Can't SetDateTime")
        'End If
    End Sub

    Public Sub CheckItem_SLP(ByVal s_Name() As String, ByVal d_Number() As Double, ByVal d_Price() As Double)
        ''CheckOpenFl jer 1 mere 0
        'For i As Integer = 0 To s_Name.Length - 1
        '    If SLP.CheckItem(s_Name(i), d_Number(i), d_Price(i), 0, 1, IIf(i = 0, 1, 0)) <> 0 Then
        '        Mesigi("Can't Do Sale(SLP): " & SLP.ErrorMessage)
        '        Exit Sub
        '    End If
        'Next
    End Sub

    Public Sub Close_Check_SLP(ByVal i_CheckType As Integer, ByVal d_Payer As Double)
        'If SLP.CheckClose(i_CheckType, d_Payer, 0) <> 0 Then
        '    Mesigi("Can't Close Check(SLP): " & SLP.ErrorMessage)
        '    Fmain.Write_In_Log("SLP - Can't Close Check")
        'End If
    End Sub

    Public Sub RestoreStock_SLP(ByVal s_Name As String, ByVal d_Number As Double, ByVal d_Price As Double)
        'If SLP.RestoreStock(s_Name, d_Number, d_Price, 0, 1) <> 0 Then
        '    Mesigi("Can't RestoreStock Check(SLP): " & SLP.ErrorMessage)
        '    Fmain.Write_In_Log("SLP - Can't RestoreStock Check")
        'End If
    End Sub

    Public Function Z_Amogheba_SLP() As Boolean
        'If SLP.StocksZReport() <> 0 Then
        '    Mesigi("Can't Do ZReport(SLP): " & SLP.ErrorMessage)
        '    Fmain.Write_In_Log("SLP - Can't Do ZReport")
        '    Return (False)
        'Else
        '    Fmain.Write_In_Log("SLP - ZReport")
        '    Return (True)
        'End If
    End Function

    Public Sub X_Amogheba_SLP()
        'If SLP.StocksXReport() <> 0 Then
        '    Mesigi("Can't Do XReport(SLP): " & SLP.ErrorMessage)
        '    Fmain.Write_In_Log("SLP - Can't Do XReport")
        'End If
        'Close_SLP()
        'Open_SLP()
    End Sub
End Module
