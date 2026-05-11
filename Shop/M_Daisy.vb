Module M_Daisy
    Public Sub SetStartupSettings(Optional ByVal all As Boolean = True)
        Try
            Fmain.DaisyFP.SetSysParameter(2, "2")
            Fmain.DaisyFP.SetSysParameter(3, IIf(all, "3", "1"))
            Fmain.DaisyFP.SetSysParameter(6, "0001")
            Fmain.DaisyFP.SetSysParameter(8, IIf(all, "00000000", "10000000"))
            Fmain.DaisyFP.SetSysParameter(9, IIf(all, "000000", "100000"))
            Fmain.DaisyFP.SetSysParameter(40, "03")
            'Dim img_h As String = String.Empty
            'Fmain.DaisyFP.ReadSysParameter(27, img_h)
            'If Not img_h.Contains("065") And all Then
            '    Fmain.DaisyFP.SetGraphicLogo(New Bitmap(Fmain.PictureFPLogo.Image))
            'End If
            'Fmain.DaisyFP.SetSysParameter(27, IIf(all, "065", "000"))

            Fmain.DaisyFP.SetHeaderLine(0, Fmain.Company_Name)
            Fmain.DaisyFP.SetHeaderLine(1, Fmain.Market_Address)
            Fmain.DaisyFP.SetHeaderLine(8, IIf(all, "გმადლობთ შენაძენისთვის!", "გმადლობთ"))
            'Fmain.DaisyFP.SetHeaderLine(9, "პოპული - თქვენი ყოველდღიური")
            'Fmain.DaisyFP.SetHeaderLine(10, "არჩევანი")

        Catch ex As Exception
            'MessageBox.Show("System parameters setting error:" + Environment.NewLine + ex.Message, "Fiscal printer error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DebugOrPrint(ByVal s As String, ByVal dbg As Boolean)
        If Fmain.fp_daisy = 2 Then
            If String.IsNullOrEmpty(s) Then
                Fmain.DaisyFP.PaperFeed(1)
            Else
                If dbg = True Then
                    Fmain.DaisyFP.NonFiscalDocAddText(s)
                Else
                    Fmain.DaisyFP.FiscalDocPrintText(s)
                End If
            End If
        Else
            Debug.WriteLine(s)
        End If
    End Sub

    Private Sub PrintTerminalResponse(ByVal source As String, ByVal header As String, Optional ByVal dbg As Boolean = False)
        Dim sep As String() = {"@#$%"}
        Dim src As String = source.Replace(Environment.NewLine, Environment.NewLine + sep(0))
        Dim lines As String() = src.Split(sep, StringSplitOptions.RemoveEmptyEntries)
        Debug.Flush()
        DebugOrPrint("", dbg)
        DebugOrPrint("----------TBC Bank----------", dbg)
        DebugOrPrint("", dbg)
        If lines.Length > 3 Then
            Dim u As Integer = lines.Length - 2
            Dim si As String = String.Empty
            For j As Integer = lines.Length - 2 To 0 Step -1
                si += lines(j).Trim()
                If Not String.IsNullOrEmpty(si) Then
                    u = j
                    Exit For
                End If
            Next j

            For i As Integer = 1 To u
                Dim stri As String = lines(i)
                'If s.StartsWith("ტერმინალ ID:") Then
                '    s = "ტერმინალ ID:" + s.Replace("ტერმინალ ID:", "").Trim().PadLeft(16, " ")
                'ElseIf s.StartsWith("თანხა") Then
                '    s = "თანხა" + s.Replace("თანხა", "").Trim().PadLeft(23, " ")
                'ElseIf s.StartsWith("AID") Then
                '    s = "AID" + s.Replace("AID", "").Trim().PadLeft(25, " ")
                If stri.StartsWith("ბარათის მფლობელი:") Then
                    stri = stri.Replace("ბარათის მფლობელი:", "").Trim()
                    DebugOrPrint("ბარათის მფლობელი:", dbg)
                    'ElseIf s.StartsWith("პასუხის კოდი:") Then
                    '    s = "პასუხის კოდი:" + s.Replace("პასუხის კოდი:", "").Trim().PadLeft(15, " ")
                    'ElseIf s.StartsWith("თარიღი") Then
                    '    s = s.Replace("    დრო", "დრო").Trim()
                Else
                    Dim length As Integer = 28
                    Dim spacePos As Integer
                    spacePos = stri.IndexOf("   ")
                    If (spacePos > 1) Then
                        Dim before = stri.Substring(0, spacePos).Trim()
                        Dim after = stri.Replace(before, "").Trim()
                        If Not String.IsNullOrEmpty(after) Then
                            stri = before + after.PadLeft(length - before.Length, " ")
                        Else
                            stri = before
                        End If
                    Else
                        Dim sourceTrm = stri.Trim()
                        If sourceTrm.Length > length Then
                            sourceTrm = stri.Substring(0, length).Trim()
                        End If
                        Dim spaces As Integer = length - sourceTrm.Length
                        Dim padLeft As Integer = spaces / 2 + sourceTrm.Length

                        stri = sourceTrm.PadLeft(padLeft)
                    End If
                End If
                If stri.Trim() = "~0xDA^^" Then
                    Mesigi("აიღეთ ქვითარი")
                    DebugOrPrint("----------TBC Bank----------", dbg)
                    DebugOrPrint("", dbg)
                Else
                    DebugOrPrint(stri, dbg)
                End If
            Next i
            DebugOrPrint("", dbg)
        End If
    End Sub

    Public Sub Print_Check(ByVal s_Name() As String, ByVal d_Number() As Double, ByVal d_Price() As Double, ByVal d_Discount As Double, ByVal tax_group() As String)
        Dim gift As Boolean = False
        Dim sum As Decimal = 0

        Dim s_name_distinct As New List(Of String)
        Dim d_number_distinct As New List(Of Double)
        Dim d_price_distinct As New List(Of Double)
        Dim s_tax_group_distinct As New List(Of String)
        Dim index As Integer

        For i As Integer = 0 To s_Name.Length - 1
            If d_Number(i) * d_Price(i) > 0.009999 Then
                If Not s_name_distinct.Contains(s_Name(i)) Then
                    s_name_distinct.Add(s_Name(i))
                    d_number_distinct.Add(d_Number(i))
                    d_price_distinct.Add(d_Price(i))
                    s_tax_group_distinct.Add(tax_group(i))
                Else
                    index = s_name_distinct.IndexOf(s_Name(i))
                    d_number_distinct(index) += d_Number(i)
                End If
                sum += d_Number(i) * d_Price(i)
            End If
        Next

        Dim cashSum = Val(Fmain.txt_Gad_Tan.Text)

        If Fmain.lbl_SaleType.Text.IndexOf("უნაღდო") >= 0 Then
            cashSum = 0
        ElseIf cashSum < sum Then
            Mesigi("მიღებული თანხა არასაკმარისია, გთხოვთ შეამოწმოთ", "შეცდომა")
            Fmain.Write_In_Log("Incorrect cash amount" & Math.Round(sum, 2, MidpointRounding.AwayFromZero) & "  " & Math.Round(cashSum, 2, MidpointRounding.AwayFromZero))
        End If

        If Not Fmain.DaisyFP.FiscalDocIsOpen Then
            Fmain.DaisyFP.FiscalDocOpen(Fmain.operator_num, Fmain.operator_pwd)
        End If

        Fmain.DaisyFP.FiscalDocPrintText("ქვითარი:" + Fmain.lbl_Check_N.Text.PadLeft(20, " "))

        If Not String.IsNullOrEmpty(Fmain.BankTerminalData) Then
            PrintTerminalResponse(Fmain.BankTerminalData, "-----ტერმინალით გადახდა-----", False)
        End If

        Fmain.DaisyFP.PaperFeed(1)

        For i As Integer = 0 To s_name_distinct.Count - 1
            Fmain.DaisyFP.FiscalDocAddItem(s_name_distinct(i), d_number_distinct(i), d_price_distinct(i), d_Discount, s_tax_group_distinct(i))
        Next

        Fmain.DaisyFP.FiscalDocTotal(cashSum, Fmain.lbl_SaleType.Text.IndexOf("უნაღდო") >= 0)

        Try
            Fmain.DaisyFP.FiscalDocClose()
        Catch ex As Exception
            If ex.Message.Contains("NO_PAPER") Or ex.Message.Contains("PRINT_MECH_ERROR") Then
                Mesigi("პრინტერში გათავდა ქაღალდი, ჩადეთ ახალი რულონი, პრინტერზე დააჭირეთ ღილაკს 'C' და შემდეგ დააჭირეთ 'Enter'-ს", , , , True, True)
                Fmain.DaisyFP.Dispose()
            Else
                Throw New Exception(ex.Message)
            End If
        End Try
    End Sub

    Public Sub Print_Check(ByVal s_Name As String, ByVal d_Number As Double, ByVal d_Price As Double, ByVal d_Discount As Double, ByVal tax_group As String)
        Dim sum As Decimal = 0

        If Not Fmain.DaisyFP.FiscalDocIsOpen Then
            Fmain.DaisyFP.FiscalDocOpen(Fmain.operator_num, Fmain.operator_pwd)
        End If

        If d_Number * d_Price > 0 Then
            Fmain.DaisyFP.FiscalDocAddItem(s_Name, d_Number, d_Price, d_Discount, tax_group)
            sum += d_Number * d_Price
        End If

        sum = Val(Fmain.txt_Gad_Tan.Text)

        If Fmain.lbl_SaleType.Text.IndexOf("უნაღდო") >= 0 Then
            sum = 0
        End If

        Fmain.DaisyFP.FiscalDocTotal(sum, Fmain.lbl_SaleType.Text.IndexOf("უნაღდო") >= 0)

        Try
            Fmain.DaisyFP.FiscalDocClose()
        Catch ex As Exception
            If ex.Message.Contains("NO_PAPER") Then
                Mesigi("პრინტერში გათავდა ქაღალდი, ჩადეთ ახალი რულონი, პრინტერზე დააჭირეთ ღილაკს 'C' და შემდეგ დააჭირეთ 'Enter'-ს", , , , True, True)
                Fmain.DaisyFP.Dispose()
            Else
                Throw New Exception(ex.Message)
            End If
        End Try
    End Sub

    Public Sub Print_Terminal_Response(ByVal response As String, ByVal header As String)
        If Fmain.fp_daisy > 0 Then
            If Not Fmain.DaisyFP.NonFiscalDocIsOpen Then
                Fmain.DaisyFP.NonFiscalDocOpen()
            Else
                Fmain.DaisyFP.NonFiscalDocClose()
                Fmain.DaisyFP.NonFiscalDocOpen()
            End If
        End If

        PrintTerminalResponse(response, header, True)

        If Fmain.fp_daisy > 0 Then
            Fmain.DaisyFP.PaperFeed(1)
            Fmain.DaisyFP.NonFiscalDocClose()
        End If
    End Sub

    Public Sub Print_Prebill_Check(ByVal s_Name() As String, ByVal d_Number() As Double, ByVal d_Price() As Double)
        Dim sum As Decimal = 0

        If Not Fmain.DaisyFP.NonFiscalDocIsOpen Then
            Fmain.DaisyFP.NonFiscalDocOpen()
        Else
            Fmain.DaisyFP.NonFiscalDocClose()
            Fmain.DaisyFP.NonFiscalDocOpen()
        End If

        Fmain.DaisyFP.NonFiscalDocAddText("მაღაზია: " + Fmain.Market_Name)
        Fmain.DaisyFP.NonFiscalDocAddText("თარიღი: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"))
        Fmain.DaisyFP.NonFiscalDocAddText("წინასწარი ქვითარი:" + Fmain.lbl_Check_N.Text.PadLeft(10, " "))
        Fmain.DaisyFP.PaperFeed(1)
        For i As Integer = 0 To s_Name.Length - 1
            If d_Number(i) * d_Price(i) > 0.009999 Then
                Dim sname As String = s_Name(i)
                If sname.Length > 28 Then
                    sname = sname.Substring(0, 28)
                End If
                Fmain.DaisyFP.NonFiscalDocAddText(sname)
                Fmain.DaisyFP.NonFiscalDocAddText((d_Number(i).ToString("# ### ##0.###") + "*" + d_Price(i).ToString("# ### ##0.00") + " = " + (d_Number(i) * d_Price(i)).ToString("# ### ##0.00")).PadLeft(28, " "))
                sum += d_Number(i) * d_Price(i)
            End If
        Next

        'sum = Val(Fmain.txt_Gad_Tan.Text)
        Fmain.DaisyFP.NonFiscalDocAddText(("_").PadLeft("27", "_"))
        Fmain.DaisyFP.NonFiscalDocAddText("ჯამი" + sum.ToString("# ### ##0.00").PadLeft(24, "."))
        Fmain.DaisyFP.PaperFeed(1)
        Fmain.DaisyFP.NonFiscalDocClose()
    End Sub

    Public Sub Print_Z_Appx(ByVal XorZ As String, ByVal sCashSum As Double, ByVal sCardSum As Double, ByVal rCashSum As Double, ByVal rCardSum As Double, ByVal rGiftSum As Double, ByVal bCashSum As Double, ByVal bCardSum As Double, ByVal pBillSum As Double)
        If Not Fmain.DaisyFP.NonFiscalDocIsOpen Then
            Fmain.DaisyFP.NonFiscalDocOpen()
        Else
            Fmain.DaisyFP.NonFiscalDocClose()
            Fmain.DaisyFP.NonFiscalDocOpen()
        End If
        Fmain.DaisyFP.NonFiscalDocAddText("მაღაზია: " + Fmain.Market_Name)
        Fmain.DaisyFP.NonFiscalDocAddText("თარიღი: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"))
        Fmain.DaisyFP.NonFiscalDocAddText(XorZ & " ანგარიშის დამატება")

        'If Not String.IsNullOrEmpty(Fmain.BankTerminalData) Then
        '    Fmain.DaisyFP.PaperFeed(1)
        '    PrintTerminalResponse(Fmain.BankTerminalData, "-----ტერმინალის რეპორტი-----", True)
        'End If

        Fmain.DaisyFP.PaperFeed(1)
        Fmain.DaisyFP.NonFiscalDocAddText("გაყიდვები:")
        Fmain.DaisyFP.NonFiscalDocAddText("გაყიდვა ნაღდი" & sCashSum.ToString("# ### ##0.00").PadLeft(15, "."))
        Fmain.DaisyFP.NonFiscalDocAddText("გაყიდვა უნაღდო" & sCardSum.ToString("# ### ##0.00").PadLeft(14, "."))
        Fmain.DaisyFP.NonFiscalDocAddText("გაყიდვა სულ" & (sCardSum + sCashSum).ToString("# ### ##0.00").PadLeft(17, "."))

        'Fmain.DaisyFP.NonFiscalDocAddText("ბონუსით გადახდა:")
        'Fmain.DaisyFP.NonFiscalDocAddText("გადახდა ნაღდი" & bCashSum.ToString("# ### ##0.00").PadLeft(15, "."))
        'Fmain.DaisyFP.NonFiscalDocAddText("გადახდა უნაღდო" & bCardSum.ToString("# ### ##0.00").PadLeft(14, "."))
        'Fmain.DaisyFP.NonFiscalDocAddText("გადახდა სულ" & (bCardSum + bCashSum).ToString("# ### ##0.00").PadLeft(17, "."))

        Fmain.DaisyFP.NonFiscalDocAddText("დაბრუნებები:")
        Fmain.DaisyFP.NonFiscalDocAddText("დაბრუნება ნაღდი" & (-1 * rCashSum).ToString("# ### ##0.00").PadLeft(13, "."))
        Fmain.DaisyFP.NonFiscalDocAddText("დაბრუნება უნაღდო" & (-1 * rCardSum).ToString("# ### ##0.00").PadLeft(12, "."))
        Fmain.DaisyFP.NonFiscalDocAddText("დაბრუნება სულ" & (-1 * (rCardSum + rCashSum)).ToString("# ### ##0.00").PadLeft(15, "."))
        Fmain.DaisyFP.PaperFeed(1)
        Fmain.DaisyFP.NonFiscalDocAddText("ნაღდი თანხა სულ" & (sCashSum + rCashSum - bCashSum).ToString("# ### ##0.00").PadLeft(13, "."))
        Fmain.DaisyFP.NonFiscalDocAddText("უნაღდო თანხა სულ" & (sCardSum + rCardSum - bCardSum).ToString("# ### ##0.00").PadLeft(12, "."))

        Fmain.DaisyFP.PaperFeed(1)
        Fmain.DaisyFP.NonFiscalDocAddText("ნავაჭრი სულ" & (sCashSum + sCardSum + rCardSum + rCashSum).ToString("# ### ##0.00").PadLeft(17, "."))
        Fmain.DaisyFP.PaperFeed(1)
        Fmain.DaisyFP.NonFiscalDocAddText("წინასწარი ქვითრები" & pBillSum.ToString("# ### ##0.00").PadLeft(10, "."))
        Fmain.DaisyFP.PaperFeed(1)
        Fmain.DaisyFP.NonFiscalDocClose()
    End Sub

    'Public Sub Print_Gift_Check(ByVal s_Name() As String, ByVal d_Number() As Double, ByVal d_Price() As Double, ByVal d_Discount As Double, ByVal tax_group As String)
    '    Dim sum As Decimal = 0

    '    If Not Fmain.DaisyFP.NonFiscalDocIsOpen Then
    '        Fmain.DaisyFP.NonFiscalDocOpen()
    '    Else
    '        Fmain.DaisyFP.NonFiscalDocClose()
    '        Fmain.DaisyFP.NonFiscalDocOpen()
    '    End If
    '    Fmain.DaisyFP.NonFiscalDocAddText("ქვითარი:" + Fmain.lbl_Check_N.Text.PadLeft(20, " "))
    '    Fmain.DaisyFP.NonFiscalDocAddText("მომხმარებელი:" + Fmain.Customer.Key.PadLeft(15, " "))

    '    Fmain.DaisyFP.PaperFeed(1)

    '    Fmain.DaisyFP.NonFiscalDocAddText("        * საჩუქარი *")
    '    Fmain.DaisyFP.PaperFeed(1)

    '    For i As Integer = 0 To s_Name.Length - 1
    '        Fmain.DaisyFP.NonFiscalDocAddText(s_Name(i))
    '        Fmain.DaisyFP.NonFiscalDocAddText((d_Number(i).ToString("0.000") & " x " & d_Price(i).ToString("0.00") & " = " & (d_Number(i) * d_Price(i)).ToString("0.00")).PadLeft(28, " "))
    '        sum += d_Number(i) * d_Price(i)
    '    Next

    '    Fmain.DaisyFP.PaperFeed(1)
    '    Fmain.DaisyFP.NonFiscalDocAddText("თქვენ დაგრჩათ " + (Fmain.Customer.PopBonus - Fmain.d_Tanxa).ToString("0.#") + " პოპულარი")
    '    Fmain.DaisyFP.PaperFeed(1)

    '    Try
    '        Fmain.DaisyFP.NonFiscalDocClose()
    '    Catch ex As Exception
    '        If ex.Message.Contains("NO_PAPER") Then
    '            Mesigi("პრინტერში გათავდა ქაღალდი, ჩადეთ ახალი რულონი, პრინტერზე დააჭირეთ ღილაკს 'C' და შემდეგ დააჭირეთ 'Enter'-ს", , , , True, True)
    '            Fmain.DaisyFP.Dispose()
    '        Else
    '            Throw New Exception(ex.Message)
    '        End If
    '    End Try
    'End Sub
End Module
