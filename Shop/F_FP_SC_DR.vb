Public Class F_FP_SC_DR


    '_________________________________________________________________Fiscal mbs
    'Dim FP As New OposFiscalPrinter_1_7_Lib.OPOSFiscalPrinter
    'Dim FP As New MercFPrtX.MercuryFPrtX
    'Const FPTR_RT_CASH_IN As Integer = 0
    'Const FPTR_RS_RECEIPT As Integer = 0
    'Const FPTR_RT_SERVICE As Integer = 5

    Private Function RT(ByVal s_STR As String) As String
        Dim s_Real As String = String.Empty
        Dim i As Integer
        For i = 1 To Len(s_STR)
            Select Case Mid(s_STR, i, 1)
                Case "ა" : s_Real = s_Real & ChrW(9617)
                Case "ბ" : s_Real = s_Real & ChrW(9618)
                Case "გ" : s_Real = s_Real & ChrW(9619)
                Case "დ" : s_Real = s_Real & ChrW(9569)
                Case "ე" : s_Real = s_Real & ChrW(9558)
                Case "ვ" : s_Real = s_Real & ChrW(9557)
                Case "ზ" : s_Real = s_Real & ChrW(9564)
                Case "თ" : s_Real = s_Real & ChrW(9563)
                Case "ი" : s_Real = s_Real & ChrW(4310)
                Case "კ" : s_Real = s_Real & ChrW(4320)
                Case "ლ" : s_Real = s_Real & ChrW(4322)
                Case "მ" : s_Real = s_Real & ChrW(4323)
                Case "ნ" : s_Real = s_Real & ChrW(4324)
                Case "ო" : s_Real = s_Real & ChrW(4325)
                Case "პ" : s_Real = s_Real & ChrW(4326)
                Case "ჟ" : s_Real = s_Real & ChrW(4331)
                Case "რ" : s_Real = s_Real & ChrW(4332)
                Case "ს" : s_Real = s_Real & ChrW(4333)
                Case "ტ" : s_Real = s_Real & ChrW(4334)
                Case "უ" : s_Real = s_Real & ChrW(4335)
                Case "ფ" : s_Real = s_Real & ChrW(9581)
                Case "ქ" : s_Real = s_Real & ChrW(9582)
                Case "ღ" : s_Real = s_Real & ChrW(9583)
                Case "ყ" : s_Real = s_Real & ChrW(9584)
                Case "შ" : s_Real = s_Real & ChrW(8594)
                Case "ჩ" : s_Real = s_Real & ChrW(8592)
                Case "ც" : s_Real = s_Real & ChrW(8595)
                Case "ძ" : s_Real = s_Real & ChrW(8593)
                Case "წ" : s_Real = s_Real & ChrW(247)
                Case "ჭ" : s_Real = s_Real & ChrW(177)
                Case "ხ" : s_Real = s_Real & ChrW(8470)
                Case "ჯ" : s_Real = s_Real & ChrW(164)
                Case "ჰ" : s_Real = s_Real & ChrW(8208)
                Case Else : s_Real = s_Real & Mid(s_STR, i, 1)
            End Select
        Next
        Return (s_Real)
    End Function


    Public Sub Open_Fiscal()
        If FP.DevStatus = 0 Then
            Try
                FP.PortNum = 1
                FP.BaudRate = 9600
                FP.Password = "0000"
                FP.Open()
            Catch ex As Exception
                MsgBox("Open - " & ex.Message)
                Fmain.Write_In_Log("Err_Open_Fiscal: " & ex.Message)
            End Try

            Try
                FP.OpenDay(Fmain.Pos_N, RT(Fmain.p_Person.Name), True, MercFPrtX.TxMercProtocol.mprXOnXoff)
                FP.SetAutocut(True)
            Catch ex As Exception
                MsgBox("Open_Day - " & ex.Message)
                Fmain.Write_In_Log("Err_Open_Day: " & ex.Message)
            End Try

        End If


        'Err_Handler(FP.Open("mbsFiscalPrinter"))
        'Err_Handler(FP.ClaimDevice(1000))
        'FP.DeviceEnabled = True
        'FP.AdditionalTrailer = "         гипждлюа шенпыентмпавтм"
        'If Not FP.DayOpened Then
        '    Opan_Day()
        'End If
    End Sub

    Private Sub Opan_Day()
        'Try
        '    FP.OpenDay(Fmain.Pos_N, RT(Fmain.p_Person.Name), True, MercFPrtX.TxMercProtocol.mprBS)
        '    FP.SetAutocut(True)
        'Catch ex As Exception
        '    MsgBox("Open_Day - " & ex.Message)
        'End Try

        'Dim Bolo_2 As String = String.Empty
        'If Len(Fmain.p_Person.ID) > 2 Then
        '    Bolo_2 = Microsoft.VisualBasic.Left(Fmain.p_Person.ID, 2)
        'Else
        '    Bolo_2 = Fmain.p_Person.ID
        'End If
        'Err_Handler(FP.SetPOSID(Fmain.Pos_N, RT(Bolo_2 + "-/-" + Fmain.p_Person.Name)))
    End Sub

    Public Sub Close_Fiscal()
        If FP.DevStatus <> 0 Then
            Try
                FP.Close(False)
            Catch ex As Exception
                MsgBox("Close - " & ex.Message)
                Fmain.Write_In_Log("Err_Close_Fiscal: " & ex.Message)
            End Try

        End If
        'FP.PrintRecVoid(String.Empty)
        'FP.DeviceEnabled = False
        'Err_Handler(FP.ReleaseDevice())
        'Err_Handler(FP.Close())
    End Sub

    Public Sub SetDate()
        Try
            FP.SynchronizeEcrDateTime()
        Catch ex As Exception
            MsgBox("SetDate - " & ex.Message)
        End Try

        'Err_Handler(FP.SetDate(Now))
    End Sub

    Public Sub Open_Check(ByVal s_N As String)
        Try

            If Mid(s_N, 1, 6) = "დაბრუნ" Then
                If s_N.IndexOf("უნაღდო") >= 0 Then
                    FP.OpenFiscalDoc(MercFPrtX.TxMercOperType.motRefundCashless)
                Else
                    FP.OpenFiscalDoc(MercFPrtX.TxMercOperType.motRefund)
                End If
            Else
                FP.OpenFiscalDoc(MercFPrtX.TxMercOperType.motSale)
            End If
        Catch ex As Exception
            MsgBox("Open_Check - " & ex.Message)
            Fmain.Write_In_Log("Err_Open_Check: " & ex.Message)
        End Try

        'Dim CheckNum As Long
        'FP.FiscalReceiptType = FPTR_RT_CASH_IN
        'Err_Handler(FP.PrinterState)
        'Err_Handler(FP.BeginFiscalReceipt(False))
        'CheckNum = Val(Fmain.lbl_Nom.Text)
        'Err_Handler(FP.DirectIO(3, CheckNum, String.Empty)) 'ჩეკის ნომრის მინიჭება
        'FP.FiscalReceiptType = FPTR_RT_CASH_IN
        'Err_Handler(FP.SetVatValue(1, 180))
    End Sub

    Public Sub Print_Z_Appx(ByVal XorZ As String, ByVal sCashSum As Double, ByVal sCardSum As Double, ByVal rCashSum As Double, ByVal rCardSum As Double)
        Dim flags As Integer = 0
        Dim v_Offset As Integer = 0

        Try
            FP.AddGraphicHeader(flags, v_Offset, v_Offset)
            v_Offset += 1

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 1

            FP.AddHeaderLine(1, 10, 0, v_Offset)
            v_Offset += 1
            FP.AddSerialNumber(flags, 0, v_Offset)  ' печать серийного номера ККМ
            v_Offset += 1

            FP.AddCustom(RT("მისამართი:"), flags, 0, v_Offset)
            FP.AddHeaderLine(2, 0, 11, v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("თარიღი:"), flags, 0, v_Offset)
            FP.AddDateTime(flags, 8, v_Offset) ' печать текущих даты и времени
            v_Offset += 1

            FP.AddDocNumber(flags, 0, v_Offset)
            FP.AddReceiptNumber(flags, 9, v_Offset)
            v_Offset += 1

            FP.AddOperInfo(MercFPrtX.TxMercOperInfo.moiNumberName, flags, 0, v_Offset) ' печать информации об операторе
            v_Offset += 1

            FP.AddCustom(XorZ + RT(" ანგარიშის"), MercFPrtX.TxMercPropFlags.MERC_PROPF_DOUBLE_WIDTH, 9, v_Offset)
            v_Offset += 1
            FP.AddCustom(RT("დამატება"), MercFPrtX.TxMercPropFlags.MERC_PROPF_DOUBLE_WIDTH, 12, v_Offset)
            v_Offset += 1

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("გ ა ყ ი დ ვ ე ბ ი"), flags, 11, v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("გაყიდვა ნაღდი"), flags, 0, v_Offset)
            FP.AddCustom(sCashSum.ToString("# ### ##0.00"), flags, 40 - sCashSum.ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("გაყიდვა უნაღდო"), flags, 0, v_Offset)
            FP.AddCustom(sCardSum.ToString("# ### ##0.00"), flags, 40 - sCardSum.ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("გაყიდვა სულ"), flags, 0, v_Offset)
            FP.AddCustom((sCashSum + sCardSum).ToString("# ### ##0.00"), flags, 40 - (sCashSum + sCardSum).ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("გაყიდვების დაბრუნება"), flags, 11, v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("დაბრუნება ნაღდი"), flags, 0, v_Offset)
            FP.AddCustom((-1 * rCashSum).ToString("# ### ##0.00"), flags, 40 - (-1 * rCashSum).ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("დაბრუნება უნაღდო"), flags, 0, v_Offset)
            FP.AddCustom((-1 * rCardSum).ToString("# ### ##0.00"), flags, 40 - (-1 * rCardSum).ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("დაბრუნება სულ"), flags, 0, v_Offset)
            FP.AddCustom((-1 * (rCashSum + rCardSum)).ToString("# ### ##0.00"), flags, 40 - (-1 * (rCashSum + rCardSum)).ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("ნაღდი თანხა სულ"), flags, 0, v_Offset)
            FP.AddCustom((sCashSum + rCashSum).ToString("# ### ##0.00"), flags, 40 - (sCashSum + rCashSum).ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("უნაღდო თანხა სულ"), flags, 0, v_Offset)
            FP.AddCustom((sCardSum + rCardSum).ToString("# ### ##0.00"), flags, 40 - (sCardSum + rCardSum).ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("ნავაჭრი სულ"), flags, 11, v_Offset)
            FP.AddCustom((sCashSum + sCardSum + rCardSum + rCashSum).ToString("# ### ##0.00"), flags, 40 - (sCashSum + sCardSum + rCardSum + rCashSum).ToString("# ### ##0.00").Length(), v_Offset)
            v_Offset += 1

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 2

            FP.AddItem(MercFPrtX.TxMercItemType.mitItem, 0, False, 0, 0, 0, 0, 0, 1, RT(""), flags, 0, v_Offset, 0)
            v_Offset += 1

            FP.CloseFiscalDoc()
            FP.CancelFiscalDoc(False)

        Catch ex As Exception
            FP.CancelFiscalDoc(False)
            MsgBox("Print_Z_Appx - " & ex.Message)
            Fmain.Write_In_Log("Err_Print_Check: " & ex.Message)
        End Try

    End Sub

    Public Sub Print_Check(ByVal s_Name() As String, ByVal s_Code() As String, ByVal d_Number() As Double, ByVal d_Price() As Double, ByVal b_Weight() As Boolean, ByVal d_Discount As Double)
        Dim flags As Integer = 0
        Dim v_Offset As Integer = 0
        Dim CheckNum As String
        Dim CheckSum As Double
        Dim Perc As Integer = 2
        Dim s As String
        CheckNum = Fmain.lbl_Check_N.Text
        CheckSum = 0
        Try
            FP.AddGraphicHeader(flags, v_Offset, v_Offset)
            v_Offset += 1

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 1

            FP.AddHeaderLine(1, 10, 0, v_Offset)
            v_Offset += 1
            FP.AddSerialNumber(flags, 0, v_Offset)  ' печать серийного номера ККМ
            v_Offset += 1

            FP.AddCustom(RT("მისამართი:"), flags, 0, v_Offset)
            FP.AddHeaderLine(2, 0, 11, v_Offset)
            v_Offset += 1

            FP.AddTaxPayerNumber(flags, 0, v_Offset)
            v_Offset += 1

            FP.AddCustom(RT("თარიღი:"), flags, 0, v_Offset)
            FP.AddDateTime(flags, 8, v_Offset) ' печать текущих даты и времени
            v_Offset += 1

            FP.AddCustom(RT("ჩეკის #:"), flags, 0, v_Offset)
            FP.AddCustom(RT(CheckNum), flags, 9, v_Offset)
            v_Offset += 1

            FP.AddDocNumber(flags, 0, v_Offset)
            FP.AddReceiptNumber(flags, 9, v_Offset)
            v_Offset += 1

            FP.AddOperInfo(MercFPrtX.TxMercOperInfo.moiNumberName, flags, 0, v_Offset) ' печать информации об операторе
            v_Offset += 1

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 1

            For i As Integer = 0 To s_Name.Length - 1
                If d_Number(i).ToString().IndexOf(".") > 0 Then
                    Perc = System.Math.Round(d_Number(i), 3).ToString().Substring(System.Math.Round(d_Number(i), 3).ToString().IndexOf(".") + 1).Length()
                Else
                    Perc = 0
                End If

                If s_Name(i).Length() > 40 Then
                    s = RT(s_Name(i).Substring(0, 40))
                Else
                    s = RT(s_Name(i))
                End If
                FP.AddCustom(s, flags, 0, v_Offset)
                v_Offset += 1
                If Fmain.lbl_SaleType.Text.IndexOf("18") >= 0 Then
                    FP.AddItem(MercFPrtX.TxMercItemType.mitItem, d_Price(i), False, 0, 0, 1000, System.Math.Round(d_Number(i), 3, MidpointRounding.AwayFromZero) * System.Math.Pow(10, Perc), Perc, 0, IIf(b_Weight(i), RT("კგ"), RT("ც")), flags, 0, v_Offset, 0)
                Else
                    FP.AddItem(MercFPrtX.TxMercItemType.mitItem, d_Price(i), False, 0, 0, 1000, System.Math.Round(d_Number(i), 3, MidpointRounding.AwayFromZero) * System.Math.Pow(10, Perc), Perc, 1, IIf(b_Weight(i), RT("კგ"), RT("ც")), flags, 0, v_Offset, 0)
                End If
                CheckSum += System.Math.Round((System.Math.Round(d_Number(i), 3) * d_Price(i)) + 0.000001, 2, MidpointRounding.AwayFromZero)
                v_Offset += 1
            Next

            'MsgBox(System.Math.Round(CheckSum, 2).ToString())

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 1

            FP.AddTotal(flags, 0, v_Offset, 0)
            v_Offset += 1
            If Mid(Fmain.lbl_SaleType.Text, 1, 6) <> "დაბრუნ" Then
                If Fmain.lbl_SaleType.Text.IndexOf("უნაღდო") >= 0 Then
                    FP.AddPay(MercFPrtX.TxMercPayType.mptCashCard, 0, System.Math.Round(CheckSum, 2, MidpointRounding.AwayFromZero), "", flags, 0, v_Offset, 0)
                Else
                    FP.AddPay(MercFPrtX.TxMercPayType.mptCash, Val(Fmain.txt_Gad_Tan.Text), 0, "", flags, 0, v_Offset, 0)
                End If
                v_Offset += 1
                FP.AddChange(flags, 0, v_Offset, 0)
                v_Offset += 1
            End If

            FP.AddCustom("________________________________________", flags, 0, v_Offset)
            v_Offset += 2

            If (Now.Month = 12 And Now.Day > 24) Or (Now.Month = 1 And Now.Day < 15) Then
                FP.AddCustom(RT("* " + Fmain.Company_Name + " ანტრე გილოცავთ შობა-ახალ წელს *"), MercFPrtX.TxMercPropFlags.MERC_PROPF_FONT_14X30, 4, v_Offset)
            Else
                FP.AddCustom(RT("დამზადებულია გემოვნებით"), MercFPrtX.TxMercPropFlags.MERC_PROPF_FONT_14X30, 8, v_Offset)
            End If

        Catch ex As Exception
            FP.CancelFiscalDoc(False)
            MsgBox("Print_Check - " & ex.Message)
            Fmain.Write_In_Log("Err_Print_Check: " & CheckNum & ". " & ex.Message)
        End Try
        ''### LONG PrintRecItem(BSTR Description, CURRENCY, LONG Quantity, LONG VatInfo, CURRENCY UnitPrice, BSTR UnitName)
        'For i As Integer = 0 To s_Name.Length - 1
        '    Err_Handler(FP.PrintRecItem(RT((s_Name(i)) & "-/-" & s_Code(i)), d_Number(i) * d_Price(i) * 100, IIf(b_Weight(i), d_Number(i) * 1000, d_Number(i)), 1, d_Price(i) * 100, IIf(b_Weight(i), 1, 0)))
        'Next
    End Sub

    Public Sub Close_Check(ByVal b_TypeNaghdi As Byte, ByVal d_Total As Double, ByVal d_Payment As Double)
        Try
            FP.CloseFiscalDoc()
            'FP.QueryLastDocInfo()
            'MsgBox(FP.LastDocSum.ToString())
        Catch ex As Exception
            FP.CancelFiscalDoc(False)
            MsgBox("Close_Check - " & ex.Message)
            Fmain.Write_In_Log("Err_Close_Check: " & Fmain.lbl_Check_N.Text & ". " & ex.Message)
        End Try

        'FP.FiscalReceiptStation = FPTR_RS_RECEIPT
        'FP.FiscalReceiptType = FPTR_RT_CASH_IN
        'Err_Handler(FP.PrintRecTotal(d_Total * 100, d_Payment * 100, IIf(b_TypeNaghdi = 0, "na", "nb")))
        'Err_Handler(FP.EndFiscalReceipt(True))
    End Sub

    Public Sub Z_Amogheba()
        'Try
        FP.ZReport(1)
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'Fmain.Write_In_Log("Err_Do_Z: " & ex.Message)
        'End Try

        'Try

        '    FP.SetHeader(RT("შპს ""ანტრე 2008"""), RT(Fmain.Market_Address), "Email: info@antre.ge", "Tel: 24 46 32")
        '    FP.SetTax(1, RT("დღგ"), 1800)

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Fmain.Write_In_Log("Err_Set_Headers: " & ex.Message)
        'End Try

        'Err_Handler(FP.PrintZReport())
    End Sub

    Public Sub X_Amogheba()
        Try
            FP.XReport(1)
        Catch ex As Exception
            MsgBox(ex.Message)
            Fmain.Write_In_Log("Err_Do_X: " & ex.Message)
        End Try

        'Err_Handler(FP.PrintXReport)
    End Sub

    Private Sub Err_Handler(ByVal Err As Long)
        'If Err Then
        '    Dim sTmp As String = String.Empty
        '    Dim MbsResponceCode As Long = 0
        '    FP.DirectIO(1, MbsResponceCode, sTmp)
        '    Mesigi(MbsResponceCode & "  " & sTmp)
        'End If
    End Sub

    'Private Function RT(ByVal s_STR As String) As String
    '    Dim s_Real As String = String.Empty
    '    Dim i As Integer
    '    For i = 1 To Len(s_STR)
    '        Select Case AscW(Mid(s_STR, i, 1))
    '            Case 4304 : s_Real = s_Real & "п" 'a
    '            Case 4305 : s_Real = s_Real & "ю" 'b
    '            Case 4306 : s_Real = s_Real & "г" 'g
    '            Case 4307 : s_Real = s_Real & "ж" 'd
    '            Case 4308 : s_Real = s_Real & "е" 'e
    '            Case 4309 : s_Real = s_Real & "в" 'v
    '            Case 4310 : s_Real = s_Real & "з" 'z
    '            Case 4311 : s_Real = s_Real & "а" 'T
    '            Case 4312 : s_Real = s_Real & "т" 'i
    '            Case 4313 : s_Real = s_Real & "к" 'k
    '            Case 4314 : s_Real = s_Real & "д" 'l
    '            Case 4315 : s_Real = s_Real & "и" 'm
    '            Case 4316 : s_Real = s_Real & "н" 'n
    '            Case 4317 : s_Real = s_Real & "л" 'o
    '            Case 4318 : s_Real = s_Real & "р" 'p
    '            Case 4319 : s_Real = s_Real & "б" 'J
    '            Case 4320 : s_Real = s_Real & "о" 'r
    '            Case 4321 : s_Real = s_Real & "м" 's
    '            Case 4322 : s_Real = s_Real & "ь" 't
    '            Case 4323 : s_Real = s_Real & "у" 'u
    '            Case 4324 : s_Real = s_Real & "ф" 'f
    '            Case 4325 : s_Real = s_Real & "э" 'q
    '            Case 4326 : s_Real = s_Real & "й" 'R
    '            Case 4327 : s_Real = s_Real & "с" 'y
    '            Case 4328 : s_Real = s_Real & "ш" 'S
    '            Case 4329 : s_Real = s_Real & "ч" 'C
    '            Case 4330 : s_Real = s_Real & "ъ" 'c
    '            Case 4331 : s_Real = s_Real & "ы" 'Z
    '            Case 4332 : s_Real = s_Real & "щ" 'w
    '            Case 4333 : s_Real = s_Real & "я" 'W
    '            Case 4334 : s_Real = s_Real & "х" 'x
    '            Case 4335 : s_Real = s_Real & "ц" 'j
    '            Case 4336 : s_Real = s_Real & "ё" 'h
    '            Case Else : s_Real = s_Real & Mid(s_STR, i, 1)
    '        End Select
    '    Next
    '    RT = s_Real
    'End Function
    '____________________________________________________________ Fiscal mbs
    Public Sub Open_Scanner()
        SC.Open("scanner1")
        SC.ClaimDevice(1000)
        SC.DeviceEnabled = True
        SC.DataEventEnabled = True
        SC.DecodeData = True
    End Sub

    Public Sub Close_Scanner()
        SC.DecodeData = False
        SC.DataEventEnabled = False
        SC.DeviceEnabled = False
        SC.ReleaseDevice()
        SC.Close()
    End Sub

    Private Sub SC_DataEvent(ByVal sender As Object, ByVal e As AxSCANNERLib._DOPOS_ScannerEvents_DataEventEvent) Handles SC.DataEvent
        If Fmain.txt_kodi.Focused Then
            Fmain.txt_kodi.Text = SC.ScanDataLabel
        End If
        SC.DataEventEnabled = True
        SendKeys.Send("0")
        SendKeys.Send("{BACKSPACE}")
        Fmain.b_From_Scanner = True
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub SC_ErrorEvent(ByVal sender As Object, ByVal e As AxSCANNERLib._DOPOS_ScannerEvents_ErrorEventEvent) Handles SC.ErrorEvent
        Fmain.Write_In_Log("Err_Scanner ErrorEvent: (ResultCode = " & ResultCode2String(e.resultCode) & " , ErrorLocus = " & ErrorLocus2String(e.errorLocus) & ")")
        Mesigi("Scanner ErrorEvent: (ResultCode = " & ResultCode2String(e.resultCode) & " , ErrorLocus = " & ErrorLocus2String(e.errorLocus) & ")")
        SC.DataEventEnabled = True
    End Sub

    Public Function ResultCode2String(ByVal X As Long) As String
        Select Case X
            Case 0 : ResultCode2String = "SUCCESS"
                '*** State Properties ***
            Case 1 : ResultCode2String = "Status CLOSED"
            Case 2 : ResultCode2String = "Status IDLE"
            Case 3 : ResultCode2String = "Status BUSY"
            Case 4 : ResultCode2String = "Status ERROR"
                '*** ResultCode Properties ***
            Case 101 : ResultCode2String = "CLOSED"
            Case 102 : ResultCode2String = "CLAIMED"
            Case 103 : ResultCode2String = "NOT Claimed"
            Case 104 : ResultCode2String = "NO SERVICE"
            Case 105 : ResultCode2String = "DISABLED"
            Case 106 : ResultCode2String = "ILLEGAL"
            Case 107 : ResultCode2String = "NO HARDWARE"
            Case 108 : ResultCode2String = "OFFLINE"
            Case 109 : ResultCode2String = "NO EXIST"
            Case 110 : ResultCode2String = "EXIST"
            Case 111 : ResultCode2String = "FAILURE"
            Case 112 : ResultCode2String = "TIMEOUT"
            Case 113 : ResultCode2String = "BUSY"
            Case 114 : ResultCode2String = "EXTENDED"
                '*** StatusUpdate Events ***
            Case 2001 : ResultCode2String = "Power Online"
            Case 2002 : ResultCode2String = "Power Off"
            Case 2003 : ResultCode2String = "Power Offline"
            Case 2004 : ResultCode2String = "Power Off & Offline"
            Case Else : ResultCode2String = "Illegal Value  " & X
        End Select
    End Function

    Public Function ErrorLocus2String(ByVal X As Long) As String
        Select Case X
            Case 1 : ErrorLocus2String = "Output"
            Case 2 : ErrorLocus2String = "Input"
            Case 3 : ErrorLocus2String = "Input Data"
            Case Else : ErrorLocus2String = "Illegal Value  " + Format(X)
        End Select
    End Function

    Public Sub Open_Drawer()
        DR.Open("drawer4")
        DR.ClaimDevice(1000)
        DR.DeviceEnabled = True
        DR.DataEventEnabled = True
    End Sub

    Public Sub Close_Drawer()
        DR.DataEventEnabled = False
        DR.DeviceEnabled = False
        DR.ReleaseDevice()
        DR.Close()
    End Sub

    Private Sub DR_StatusUpdateEvent(ByVal sender As Object, ByVal e As AxDRAWERLib._DOPOS_DrawerEvents_StatusUpdateEventEvent) Handles DR.StatusUpdateEvent
        If e.data = 1 Then
            If Fmain.b_BoxIsOpen = False Then
                DR.WaitForDrawerClose(1000, 700, 1, 0)
            End If
        End If
    End Sub
End Class