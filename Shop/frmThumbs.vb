Public Class frmThumbs
    Dim ds As New pos_dbDataSet()

    Dim bs_itemGroups As New BindingSource(ds, "ItemGroups")
    Dim bs_items As New BindingSource(ds, "sp_PricedItems")

    Dim bs_topItems As New BindingSource(ds, "sp_getTopItems")


    Dim ta_itemGroups As New pos_dbDataSetTableAdapters.ItemGroupsTableAdapter()
    Dim ta_items As New pos_dbDataSetTableAdapters.sp_pricedItemsTableAdapter()
    Dim ta_topItems As New pos_dbDataSetTableAdapters.sp_getTopItemsTableAdapter()

    Dim oldItem As Infragistics.Win.UltraWinListView.UltraListViewItem
    Dim newItem As Infragistics.Win.UltraWinListView.UltraListViewItem

    Public isFmain As Boolean = True

    Public Sub frmThumbs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Fmain.TranslateUI(Me, Fmain.UITerms)
        UltraDockManager1.DockAreas(0).Panes(0).Text = Fmain.UITermsValue("ჯგუფები")
        Dim _override1 As New Infragistics.Win.UltraWinTree.Override()
        Dim utcs As New Infragistics.Win.UltraWinTree.UltraTreeColumnSet()


        UltraTree1.DataMember = ""
        UltraTree1.DataSource = Nothing

        _override1.ColumnSet = utcs
        _override1.ActiveNodeAppearance.BackColor = Color.FromArgb(192, 192, 255)
        _override1.SelectedNodeAppearance.BackColor = Color.FromArgb(192, 192, 255)

        '_override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended

        _override1.HotTracking = Infragistics.Win.DefaultableBoolean.False
        _override1.NodeDoubleClickAction = Infragistics.Win.UltraWinTree.NodeDoubleClickAction.None
        _override1.ExpandedNodeAppearance.Image = ImageList1.Images(0)

        _override1.NodeAppearance.Image = ImageList1.Images(0)

        _override1.BorderStyleNode = Infragistics.Win.UIElementBorderStyle.RaisedSoft

        _override1.NodeAppearance.BorderColor = Color.Gray

        '_override1.ShowExpansionIndicator = Infragistics.Win.UltraWinTree.ShowExpansionIndicator.Never

        _override1.NodeAppearance.BackColor = Color.FromArgb(255, 255, 255)
        _override1.NodeAppearance.BackColor2 = Color.FromArgb(222, 220, 218)

        _override1.NodeAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical

        _override1.HotTrackingNodeAppearance.BorderColor = Color.FromArgb(230, 150, 0)

        _override1.ShowExpansionIndicator = Infragistics.Win.UltraWinTree.ShowExpansionIndicator.CheckOnDisplay

        _override1.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending

        Me.UltraTree1.Override = _override1
        Me.UltraTree1.NodeLevelOverrides.Add(_override1)

        ds.EnforceConstraints = False
        UltraTree1.DataSource = ds
        UltraTree1.DataMember = "ItemGroups"

        ta_itemGroups.Connection.ConnectionString = Fmain.LOCAL_CONN_STR
        ta_items.Connection.ConnectionString = Fmain.LOCAL_CONN_STR
        ta_topItems.Connection.ConnectionString = Fmain.LOCAL_CONN_STR

        ta_itemGroups.FillBy(ds.ItemGroups)

        If (UltraTree1.ColumnSettings.ColumnSets.Count > 0) Then
            If (UltraTree1.ColumnSettings.ColumnSets(0).Columns.Count > 0) Then
                UltraTree1.ColumnSettings.ColumnSets(0).Columns(0).SortType = Infragistics.Win.UltraWinTree.SortType.None
                UltraTree1.ColumnSettings.ColumnSets(0).Columns(2).SortType = Infragistics.Win.UltraWinTree.SortType.Ascending
            End If
        End If

        ta_items.Fill(ds.sp_pricedItems)
        ta_topItems.Fill(ds.sp_getTopItems, 30)

        UltraTree1.ColumnSettings.ColumnSets(0).NodeTextColumn = UltraTree1.ColumnSettings.ColumnSets(0).Columns(2)
        For Each col As Infragistics.Win.UltraWinTree.UltraTreeNodeColumn In UltraTree1.ColumnSettings.ColumnSets(0).Columns
            If col.Index <> 2 And col.Index <> 7 Then
                col.Visible = False
            End If
        Next

        Me.UltraTree1.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard

        For i As Integer = 0 To Me.UltraTree1.Nodes.Count - 1 Step 1
            If UltraTree1.Nodes(i).Cells("itmgPID").Value.ToString() <> "" Then
                Me.UltraTree1.Nodes(i).Visible = False
            End If
        Next i

        oldItem = New Infragistics.Win.UltraWinListView.UltraListViewItem("-1")
        newItem = New Infragistics.Win.UltraWinListView.UltraListViewItem("-2")

        'UltraTree1.ColumnSettings.ColumnSets(0).Columns(0).SortType = Infragistics.Win.UltraWinTree.SortType.None
        'UltraTree1.ColumnSettings.ColumnSets(0).Columns(2).SortType = Infragistics.Win.UltraWinTree.SortType.Ascending

        LoadTopItems()

    End Sub

    Public Sub ResetView()
        UltraTree1.CollapseAll()
        If Not UltraTree1.ActiveNode Is Nothing Then
            UltraTree1.ActiveNode.Selected = False
        End If

        LoadTopItems()
    End Sub

    Private Sub LoadTopItems()
        Dim itm(bs_topItems.Count) As Infragistics.Win.UltraWinListView.UltraListViewItem

        Dim data() As Byte
        Dim strm(bs_topItems.Count) As IO.MemoryStream
        Dim img As Drawing.Image

        If bs_topItems.Count > 0 Then
            UltraListView1.Items.Clear()
            For i As Integer = 0 To bs_topItems.Count - 1 Step 1
                itm(i) = New Infragistics.Win.UltraWinListView.UltraListViewItem()
                itm(i).Key = bs_topItems(i)(1).ToString()
                itm(i).Value = bs_topItems(i)(2).ToString() + System.Environment.NewLine + bs_topItems(i)(6).ToString() + " " + Fmain.UITermsValue("ლ.")
                strm(i) = New IO.MemoryStream()
                If bs_topItems.Item(i)(4).ToString() <> String.Empty Then
                    data = bs_topItems.Item(i)(4)
                    strm(i).Write(data, 0, data.Length)
                    img = Drawing.Image.FromStream(strm(i))
                Else
                    img = Nothing
                End If
                itm(i).Appearance.Image = img
                UltraListView1.Items.Add(itm(i))
                data = Nothing
            Next i
        End If
        strm = Nothing
        itm = Nothing
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UltraTree1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraTree1.MouseClick

        Dim node As Infragistics.Win.UltraWinTree.UltraTreeNode = UltraTree1.GetNodeFromPoint(e.X, e.Y)

        If node IsNot Nothing Then
            UltraTree1.ActiveNode = node
            UltraTree1.ActiveNode.Selected = True
            If UltraTree1.ActiveNode.Cells.Count > 0 Then
                If UltraTree1.ActiveNode.HasNodes Or UltraTree1.ActiveNode.Cells("itmgPID").Value.ToString() = String.Empty Then
                    Dim prevState = UltraTree1.ActiveNode.Expanded
                    UltraTree1.CollapseAll()
                    If UltraTree1.ActiveNode.Parent IsNot Nothing Then
                        UltraTree1.ActiveNode.Parent.Expanded = Not prevState
                    End If
                    UltraTree1.ActiveNode.Expanded = Not prevState
                End If
            End If
        End If
    End Sub

    Private Sub UltraListView1_ItemActivated(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinListView.ItemActivatedEventArgs) Handles UltraListView1.ItemActivated

    End Sub

    Private Sub UltraListView1_ItemDoubleClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinListView.ItemDoubleClickEventArgs) Handles UltraListView1.ItemDoubleClick
    End Sub

    Private Sub UltraButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Visible = False
        If Fmain.DGV_Sales.RowCount = 0 Then
            Fmain.refresh_Form()
        End If
    End Sub

    Private Sub UltraTree1_AfterSelect(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles UltraTree1.AfterSelect
        If UltraTree1.ActiveNode.Cells.Count > 0 Then
            bs_items.Filter = "itmgID = " + UltraTree1.ActiveNode.Cells(0).Value.ToString()
            Dim itm(bs_items.Count) As Infragistics.Win.UltraWinListView.UltraListViewItem

            Dim data() As Byte
            Dim strm(bs_items.Count) As IO.MemoryStream
            Dim img As Drawing.Image

            UltraListView1.Items.Clear()
            For i As Integer = 0 To bs_items.Count - 1 Step 1
                itm(i) = New Infragistics.Win.UltraWinListView.UltraListViewItem()
                itm(i).Key = bs_items(i)(1).ToString()
                itm(i).Value = bs_items(i)(2).ToString() + System.Environment.NewLine + bs_items(i)(6).ToString() + " " + Fmain.UITermsValue("ლ.")
                strm(i) = New IO.MemoryStream()
                If bs_items.Item(i)(4).ToString() <> String.Empty Then
                    data = bs_items.Item(i)(4)
                    strm(i).Write(data, 0, data.Length)
                    img = Drawing.Image.FromStream(strm(i))
                Else
                    img = Nothing
                End If
                itm(i).Appearance.Image = img
                UltraListView1.Items.Add(itm(i))
                data = Nothing
            Next
            strm = Nothing
            itm = Nothing
        End If

    End Sub

    Private Sub UltraListView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraListView1.Click
        Try
            If UltraListView1.SelectedItems.Count > 0 Then
                If newItem Is Nothing Then
                    Return
                ElseIf Not newItem.IsSelected Then
                    Return
                End If
                If oldItem Is Nothing Then
                    oldItem = New Infragistics.Win.UltraWinListView.UltraListViewItem("-1")
                End If
                If oldItem.Key <> String.Empty Then
                    If oldItem.Key = newItem.Key Then
                        If isFmain Then
                            Fmain.txt_kodi.Focus()
                            Fmain.txt_kodi.Text = newItem.Key
                        Else
                            FSaleSublines.txt_kodi.Focus()
                            FSaleSublines.txt_kodi.Text = newItem.Key
                        End If

                        Me.Visible = False
                        SendKeys.Send("{ENTER}")
                    End If
                End If
                oldItem.Key = newItem.Key
            End If
        Catch ex As Exception
            newItem = New Infragistics.Win.UltraWinListView.UltraListViewItem("-2")
            Fmain.Write_In_Log("Err menu item click: " & " : " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub UltraListView1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraListView1.MouseDown
        newItem = UltraListView1.ItemFromPoint(e.X, e.Y)
    End Sub

    Private Sub btnHomepage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHomepage.Click
        UltraTree1.ActiveNode.Selected = False
        LoadTopItems()
    End Sub
End Class