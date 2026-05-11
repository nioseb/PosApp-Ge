<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThumbs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThumbs))
        Dim DockAreaPane1 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, New System.Guid("73a9cdad-cf0d-4d47-98ff-57ff7a792271"))
        Dim DockableControlPane1 As Infragistics.Win.UltraWinDock.DockableControlPane = New Infragistics.Win.UltraWinDock.DockableControlPane(New System.Guid("dff271cd-50eb-46f7-ab8f-e1e186218aa5"), New System.Guid("00000000-0000-0000-0000-000000000000"), -1, New System.Guid("73a9cdad-cf0d-4d47-98ff-57ff7a792271"), -1)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraTree1 = New Infragistics.Win.UltraWinTree.UltraTree
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UltraDockManager1 = New Infragistics.Win.UltraWinDock.UltraDockManager(Me.components)
        Me._frmThumbsUnpinnedTabAreaLeft = New Infragistics.Win.UltraWinDock.UnpinnedTabArea
        Me._frmThumbsUnpinnedTabAreaRight = New Infragistics.Win.UltraWinDock.UnpinnedTabArea
        Me._frmThumbsUnpinnedTabAreaTop = New Infragistics.Win.UltraWinDock.UnpinnedTabArea
        Me._frmThumbsUnpinnedTabAreaBottom = New Infragistics.Win.UltraWinDock.UnpinnedTabArea
        Me._frmThumbsAutoHideControl = New Infragistics.Win.UltraWinDock.AutoHideControl
        Me.DockableWindow1 = New Infragistics.Win.UltraWinDock.DockableWindow
        Me.WindowDockingArea1 = New Infragistics.Win.UltraWinDock.WindowDockingArea
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnHomepage = New Infragistics.Win.Misc.UltraButton
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.UltraListView1 = New Infragistics.Win.UltraWinListView.UltraListView
        Me.Panel1.SuspendLayout()
        CType(Me.UltraTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._frmThumbsAutoHideControl.SuspendLayout()
        Me.DockableWindow1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.UltraListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraTree1)
        Me.Panel1.Location = New System.Drawing.Point(0, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(407, 636)
        Me.Panel1.TabIndex = 0
        '
        'UltraTree1
        '
        Appearance1.BorderColor = System.Drawing.Color.CornflowerBlue
        Appearance1.Image = "fold_closed.bmp"
        Me.UltraTree1.Appearance = Appearance1
        Me.UltraTree1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraTree1.ColumnSettings.AutoFitColumns = Infragistics.Win.UltraWinTree.AutoFitColumns.ResizeAllColumns
        Appearance6.Image = "fold_closed.bmp"
        Me.UltraTree1.ColumnSettings.CellAppearance = Appearance6
        Me.UltraTree1.ColumnSettings.TipStyleCell = Infragistics.Win.UltraWinTree.TipStyleCell.Show
        Me.UltraTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTree1.ExpansionIndicatorColor = System.Drawing.Color.Red
        Me.UltraTree1.Font = New System.Drawing.Font("Sylfaen", 19.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UltraTree1.FullRowSelect = True
        Me.UltraTree1.HideSelection = False
        Me.UltraTree1.ImageList = Me.ImageList1
        Me.UltraTree1.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.UltraTree1.LeftImagesSize = New System.Drawing.Size(26, 26)
        Me.UltraTree1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTree1.Name = "UltraTree1"
        Me.UltraTree1.NodeConnectorColor = System.Drawing.Color.Coral
        Me.UltraTree1.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid
        Override1.ShowColumns = Infragistics.Win.DefaultableBoolean.[False]
        Override1.ShowExpansionIndicator = Infragistics.Win.UltraWinTree.ShowExpansionIndicator.CheckOnDisplay
        Override1.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending
        Me.UltraTree1.Override = Override1
        Me.UltraTree1.ScrollBounds = Infragistics.Win.UltraWinTree.ScrollBounds.ScrollToFill
        Me.UltraTree1.Size = New System.Drawing.Size(407, 636)
        Me.UltraTree1.TabIndex = 0
        Me.UltraTree1.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraTree1.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.OutlookExpress
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Red
        Me.ImageList1.Images.SetKeyName(0, "fold_closed.bmp")
        '
        'UltraDockManager1
        '
        Me.UltraDockManager1.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus3
        Me.UltraDockManager1.AutoHideDelay = 10
        Me.UltraDockManager1.BorderStyleSplitterBars = Infragistics.Win.UIElementBorderStyle.Etched
        Me.UltraDockManager1.BorderStyleUnpinnedTabArea = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        DockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.SlidingGroup
        DockableControlPane1.Control = Me.Panel1
        DockableControlPane1.FlyoutSize = New System.Drawing.Size(407, -1)
        DockableControlPane1.OriginalControlBounds = New System.Drawing.Rectangle(182, 88, 344, 414)
        DockableControlPane1.Pinned = False
        DockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.[False]
        DockableControlPane1.Settings.AllowPin = Infragistics.Win.DefaultableBoolean.[True]
        Appearance2.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance2.BackColor2 = System.Drawing.Color.Silver
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance2.BorderColor = System.Drawing.Color.DarkSalmon
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 14.0!
        Appearance2.ForeColor = System.Drawing.Color.DimGray
        DockableControlPane1.Settings.TabAppearance = Appearance2
        DockableControlPane1.Settings.TabWidth = 168
        DockableControlPane1.Size = New System.Drawing.Size(100, 100)
        DockableControlPane1.Text = "ჯგუფები"
        DockAreaPane1.Panes.AddRange(New Infragistics.Win.UltraWinDock.DockablePaneBase() {DockableControlPane1})
        DockAreaPane1.Size = New System.Drawing.Size(318, 656)
        Me.UltraDockManager1.DockAreas.AddRange(New Infragistics.Win.UltraWinDock.DockAreaPane() {DockAreaPane1})
        Me.UltraDockManager1.HostControl = Me
        Me.UltraDockManager1.ImageSizeTab = New System.Drawing.Size(38, 38)
        Me.UltraDockManager1.ShowCloseButton = False
        Appearance5.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance5.BackColor2 = System.Drawing.Color.Silver
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        Me.UltraDockManager1.SplitterBarAppearance = Appearance5
        Me.UltraDockManager1.SplitterBarWidth = 25
        Me.UltraDockManager1.UnpinnedTabStyle = Infragistics.Win.UltraWinTabs.TabStyle.VisualStudio2005
        Me.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.VisualStudio2008
        '
        '_frmThumbsUnpinnedTabAreaLeft
        '
        Me._frmThumbsUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me._frmThumbsUnpinnedTabAreaLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmThumbsUnpinnedTabAreaLeft.Location = New System.Drawing.Point(0, 0)
        Me._frmThumbsUnpinnedTabAreaLeft.Name = "_frmThumbsUnpinnedTabAreaLeft"
        Me._frmThumbsUnpinnedTabAreaLeft.Owner = Me.UltraDockManager1
        Me._frmThumbsUnpinnedTabAreaLeft.Size = New System.Drawing.Size(45, 656)
        Me._frmThumbsUnpinnedTabAreaLeft.TabIndex = 1
        '
        '_frmThumbsUnpinnedTabAreaRight
        '
        Me._frmThumbsUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right
        Me._frmThumbsUnpinnedTabAreaRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmThumbsUnpinnedTabAreaRight.Location = New System.Drawing.Point(1002, 0)
        Me._frmThumbsUnpinnedTabAreaRight.Name = "_frmThumbsUnpinnedTabAreaRight"
        Me._frmThumbsUnpinnedTabAreaRight.Owner = Me.UltraDockManager1
        Me._frmThumbsUnpinnedTabAreaRight.Size = New System.Drawing.Size(0, 656)
        Me._frmThumbsUnpinnedTabAreaRight.TabIndex = 2
        '
        '_frmThumbsUnpinnedTabAreaTop
        '
        Me._frmThumbsUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top
        Me._frmThumbsUnpinnedTabAreaTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmThumbsUnpinnedTabAreaTop.Location = New System.Drawing.Point(45, 0)
        Me._frmThumbsUnpinnedTabAreaTop.Name = "_frmThumbsUnpinnedTabAreaTop"
        Me._frmThumbsUnpinnedTabAreaTop.Owner = Me.UltraDockManager1
        Me._frmThumbsUnpinnedTabAreaTop.Size = New System.Drawing.Size(957, 0)
        Me._frmThumbsUnpinnedTabAreaTop.TabIndex = 3
        '
        '_frmThumbsUnpinnedTabAreaBottom
        '
        Me._frmThumbsUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me._frmThumbsUnpinnedTabAreaBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmThumbsUnpinnedTabAreaBottom.Location = New System.Drawing.Point(45, 656)
        Me._frmThumbsUnpinnedTabAreaBottom.Name = "_frmThumbsUnpinnedTabAreaBottom"
        Me._frmThumbsUnpinnedTabAreaBottom.Owner = Me.UltraDockManager1
        Me._frmThumbsUnpinnedTabAreaBottom.Size = New System.Drawing.Size(957, 0)
        Me._frmThumbsUnpinnedTabAreaBottom.TabIndex = 4
        '
        '_frmThumbsAutoHideControl
        '
        Me._frmThumbsAutoHideControl.Controls.Add(Me.DockableWindow1)
        Me._frmThumbsAutoHideControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmThumbsAutoHideControl.Location = New System.Drawing.Point(55, 0)
        Me._frmThumbsAutoHideControl.Name = "_frmThumbsAutoHideControl"
        Me._frmThumbsAutoHideControl.Owner = Me.UltraDockManager1
        Me._frmThumbsAutoHideControl.Size = New System.Drawing.Size(32, 656)
        Me._frmThumbsAutoHideControl.TabIndex = 5
        '
        'DockableWindow1
        '
        Me.DockableWindow1.Controls.Add(Me.Panel1)
        Me.DockableWindow1.Location = New System.Drawing.Point(-10000, 18)
        Me.DockableWindow1.Name = "DockableWindow1"
        Me.DockableWindow1.Owner = Me.UltraDockManager1
        Me.DockableWindow1.Size = New System.Drawing.Size(407, 656)
        Me.DockableWindow1.TabIndex = 9
        '
        'WindowDockingArea1
        '
        Me.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left
        Me.WindowDockingArea1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea1.Location = New System.Drawing.Point(0, 0)
        Me.WindowDockingArea1.Name = "WindowDockingArea1"
        Me.WindowDockingArea1.Owner = Me.UltraDockManager1
        Me.WindowDockingArea1.Size = New System.Drawing.Size(343, 656)
        Me.WindowDockingArea1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnHomepage)
        Me.Panel2.Controls.Add(Me.UltraButton1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(45, 591)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(957, 65)
        Me.Panel2.TabIndex = 7
        '
        'btnHomepage
        '
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Appearance4.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnHomepage.Appearance = Appearance4
        Me.btnHomepage.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.btnHomepage.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnHomepage.ImageSize = New System.Drawing.Size(55, 55)
        Me.btnHomepage.ImageTransparentColor = System.Drawing.Color.White
        Me.btnHomepage.Location = New System.Drawing.Point(0, 0)
        Me.btnHomepage.Name = "btnHomepage"
        Me.btnHomepage.ShowFocusRect = False
        Me.btnHomepage.ShowOutline = False
        Me.btnHomepage.Size = New System.Drawing.Size(75, 65)
        Me.btnHomepage.TabIndex = 1
        '
        'UltraButton1
        '
        Appearance7.Image = CType(resources.GetObject("Appearance7.Image"), Object)
        Appearance7.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraButton1.Appearance = Appearance7
        Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.UltraButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.UltraButton1.ImageSize = New System.Drawing.Size(55, 55)
        Me.UltraButton1.ImageTransparentColor = System.Drawing.Color.White
        Me.UltraButton1.Location = New System.Drawing.Point(882, 0)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.ShowFocusRect = False
        Me.UltraButton1.ShowOutline = False
        Me.UltraButton1.Size = New System.Drawing.Size(75, 65)
        Me.UltraButton1.TabIndex = 0
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.White
        Me.ImageList2.Images.SetKeyName(0, "close1.bmp")
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.UltraListView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(45, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(957, 591)
        Me.Panel3.TabIndex = 8
        '
        'UltraListView1
        '
        Appearance3.BackColor = System.Drawing.Color.MistyRose
        Appearance3.BackColor2 = System.Drawing.Color.WhiteSmoke
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.UltraListView1.Appearance = Appearance3
        Me.UltraListView1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraListView1.Font = New System.Drawing.Font("Sylfaen", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UltraListView1.ImageTransparentColor = System.Drawing.Color.White
        Me.UltraListView1.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.[Single]
        Me.UltraListView1.Location = New System.Drawing.Point(0, 0)
        Me.UltraListView1.Name = "UltraListView1"
        Me.UltraListView1.Size = New System.Drawing.Size(957, 591)
        Me.UltraListView1.TabIndex = 0
        Me.UltraListView1.Text = "UltraListView1"
        Me.UltraListView1.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraListView1.ViewSettingsIcons.ImageSize = New System.Drawing.Size(64, 64)
        Me.UltraListView1.ViewSettingsIcons.ItemSize = New System.Drawing.Size(150, 135)
        Me.UltraListView1.ViewSettingsIcons.MaxLines = 3
        Me.UltraListView1.ViewSettingsIcons.Spacing = New System.Drawing.Size(5, 5)
        Me.UltraListView1.ViewSettingsIcons.Tag = " "
        Me.UltraListView1.ViewSettingsThumbnails.ImageSize = New System.Drawing.Size(64, 64)
        Me.UltraListView1.ViewSettingsThumbnails.ItemSize = New System.Drawing.Size(150, 0)
        Me.UltraListView1.ViewSettingsThumbnails.MaxLines = 3
        Me.UltraListView1.ViewSettingsThumbnails.Spacing = New System.Drawing.Size(5, 5)
        '
        'frmThumbs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 656)
        Me.Controls.Add(Me._frmThumbsAutoHideControl)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.WindowDockingArea1)
        Me.Controls.Add(Me._frmThumbsUnpinnedTabAreaTop)
        Me.Controls.Add(Me._frmThumbsUnpinnedTabAreaBottom)
        Me.Controls.Add(Me._frmThumbsUnpinnedTabAreaRight)
        Me.Controls.Add(Me._frmThumbsUnpinnedTabAreaLeft)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmThumbs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmThumbs"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraTree1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._frmThumbsAutoHideControl.ResumeLayout(False)
        Me.DockableWindow1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.UltraListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraTree1 As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents UltraDockManager1 As Infragistics.Win.UltraWinDock.UltraDockManager
    Friend WithEvents _frmThumbsAutoHideControl As Infragistics.Win.UltraWinDock.AutoHideControl
    Friend WithEvents _frmThumbsUnpinnedTabAreaTop As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmThumbsUnpinnedTabAreaBottom As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmThumbsUnpinnedTabAreaLeft As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmThumbsUnpinnedTabAreaRight As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents DockableWindow1 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents WindowDockingArea1 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraListView1 As Infragistics.Win.UltraWinListView.UltraListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnHomepage As Infragistics.Win.Misc.UltraButton
End Class
