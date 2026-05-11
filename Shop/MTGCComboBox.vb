'-------------------------------------------------------------------
'       *****************************
'       *   MTGCComboBox for .NET   *
'       ***************************** 
'
'   Copyright © 2004, MT Global Consulting srl. All rights reserved

'   Version: 1.0.0.0
'   Developed by: Claudio Di Flumeri, Massimiliano Silvestro
'   Web Site: http://www.mtgc.net
'   e-mail: claudio@mtgc.net
'
' You may include the source code, modified source code, assembly
' within your own projects for either personal or commercial use
'
' 
' Disclaimer: 
' This code is provided as is and without warranty, written or implied.
'-------------------------------------------------------------------

Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Globalization
Imports System.Reflection

'<Designer(GetType(MTGCComboBox.MyTypeDesigner))> _
Public Class MTGCComboBox
    Inherits System.Windows.Forms.ComboBox

#Region " **************** Enumerations and class variables ****************"
    Dim PressedKey As Boolean = False

    Dim wcol, wcol1, wcol2, wcol3, wcol4, wcol5 As String  'Column widths
    Dim currentColor As Color                       'Current border color

    Dim arrowWidth As Integer = 12
    Dim bUsingLargeFont As Boolean = False
    Dim arrowColor As Color = Color.Black
    Dim arrowDisableColor As Color = Color.LightGray
    Dim customBorderColor As Color = Color.Empty
    Dim borderColor As Color = SystemColors.Highlight
    Dim dropDownArrowAreaNormalColor As Color = SystemColors.Control
    Dim dropDownArrowAreaHotColor As Color = Color.Black
    Dim dropDownArrowAreaPressedColor As Color = Color.Black
    Dim Highlighted As Boolean = True
    Dim Indice(4) As Integer

    'constants for CharacterCasing
    Const CBS_UPPERCASE As Integer = &H2000
    Const CBS_LOWERCASE As Integer = &H4000

    'Property Declaration
    Private WithEvents mComboBox As System.Windows.Forms.ComboBox
    Dim m_ColumnNum As Integer = 1
    Dim m_ColumnWidth As String = Me.Width
    Dim m_NormalBorderColor As Color = Color.Black
    Dim m_DropDownForeColor As Color = Color.Black
    Dim m_DropDownBackColor As Color = Color.FromArgb(193, 210, 238)
    Dim m_DropDownArrowBackColor As Color = Color.FromArgb(136, 169, 223)
    Dim m_GridLineVertical As Boolean = False
    Dim m_GridLineHorizontal As Boolean = False
    Dim m_GridLineColor As Color = Color.LightGray
    Dim m_CharacterCasing As CharacterCasing = CharacterCasing.Normal
    Dim m_HighlightBorderColor As Color = Color.Blue
    Dim m_DataTable As DataTable
    Dim m_SourceDataString As String()
#End Region

#Region " **************** Custom Events ****************"
    Public Shadows Event DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
#End Region

#Region " **************** Constructor and Dispose ****************"
    'Constructor
    Public Sub New()
        MyBase.New()
        mComboBox = Me
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then MyBase.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region " **************** Properties **************** "
    <Description("Border Color when the Combobox is not Highlighted")> _
    Public Property NormalBorderColor() As Color
        Get
            Return m_NormalBorderColor
        End Get
        Set(ByVal Value As Color)
            m_NormalBorderColor = Value
            Me.Invalidate()
        End Set
    End Property

    <Description("Text Color of the item selected in the DropDownList")> _
    Public Property DropDownForeColor() As Color
        Get
            Return m_DropDownForeColor
        End Get
        Set(ByVal Value As Color)
            m_DropDownForeColor = Value
        End Set
    End Property

    <Description("Back Color of the item selected in the DropDownList")> _
        Public Property DropDownBackColor() As Color
        Get
            Return m_DropDownBackColor
        End Get
        Set(ByVal Value As Color)
            m_DropDownBackColor = Value
        End Set
    End Property

    <Description("Background Color of the Arrow when the Dropdownlist is open")> _
        Public Property DropDownArrowBackColor() As Color
        Get
            Return m_DropDownArrowBackColor
        End Get
        Set(ByVal Value As Color)
            m_DropDownArrowBackColor = Value
        End Set
    End Property

    <Description("Columns number (max 5)")> _
    Public Property ColumnNum() As Integer
        Get
            Return m_ColumnNum
        End Get
        Set(ByVal Value As Integer)
            If Value > 5 Then
                m_ColumnNum = 5
            ElseIf Value < 1 Then
                m_ColumnNum = 1
            Else
                m_ColumnNum = Value
            End If
        End Set
    End Property

    <Description("Size of columns in pixel, splitted by ;"), RefreshProperties(RefreshProperties.All)> _
    Public Property ColumnWidth() As String
        Get
            Return m_ColumnWidth
        End Get
        Set(ByVal Value As String)
            m_ColumnWidth = Value
            Select Case Me.ColumnNum
                Case 1
                    wcol1 = m_ColumnWidth
                    If Me.DropDownWidth < CInt(wcol1) + 20 Then
                        Me.DropDownWidth = CInt(wcol1) + 20 '+20 to take care of vertical scrollbar
                    End If
                Case 2
                    wcol = m_ColumnWidth
                    wcol1 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol2 = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol1) - 1)
                    If Me.DropDownWidth < CInt(wcol1) + CInt(wcol2) + 20 Then
                        Me.DropDownWidth = CInt(wcol1) + CInt(wcol2) + 20 '+20 to take care of vertical scrollbar
                    End If
                Case 3
                    wcol = m_ColumnWidth
                    wcol1 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol1) - 1)
                    wcol2 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol3 = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol2) - 1)
                    If Me.DropDownWidth < CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + 20 Then
                        Me.DropDownWidth = CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + 20 '+20 to take care of vertical scrollbar
                    End If
                Case 4
                    wcol = m_ColumnWidth
                    wcol1 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol1) - 1)
                    wcol2 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol2) - 1)
                    wcol3 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol4 = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol3) - 1)
                    If Me.DropDownWidth < CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) + 20 Then
                        Me.DropDownWidth = CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) + 20 '+20 to take care of vertical scrollbar
                    End If
                Case 5
                    wcol = m_ColumnWidth
                    wcol1 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol1) - 1)
                    wcol2 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol2) - 1)
                    wcol3 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol3) - 1)
                    wcol4 = Microsoft.VisualBasic.Left(wcol, InStr(wcol, ";") - 1)
                    wcol5 = Microsoft.VisualBasic.Right(wcol, Len(wcol) - Len(wcol4) - 1)
                    If Me.DropDownWidth < CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) + CInt(wcol5) + 20 Then
                        Me.DropDownWidth = CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) + CInt(wcol5) + 20 '+20 to take care of vertical scrollbar
                    End If
            End Select
        End Set
    End Property

    <Description("Set to true if you want the vertical line to divide every column in the Dropdownlist")> _
    Public Property GridLineVertical() As Boolean
        Get
            Return m_GridLineVertical
        End Get
        Set(ByVal Value As Boolean)
            m_GridLineVertical = Value
        End Set
    End Property

    <Description("Set to true if you want the horizontal line to divide every column in the Dropdownlist")> _
    Public Property GridLineHorizontal() As Boolean
        Get
            Return m_GridLineHorizontal
        End Get
        Set(ByVal Value As Boolean)
            m_GridLineHorizontal = Value
        End Set
    End Property

    <Description("Color of the gridlines in the Dropdownlist")> _
    Public Property GridLineColor() As Color
        Get
            Return m_GridLineColor
        End Get
        Set(ByVal Value As Color)
            m_GridLineColor = Value
        End Set
    End Property

    <Description("Combobox text style: Normal, Upper, Lower")> _
    Public Property CharacterCasing() As CharacterCasing
        Get
            Return m_CharacterCasing
        End Get
        Set(ByVal Value As CharacterCasing)
            If m_CharacterCasing <> Value Then
                m_CharacterCasing = Value
                RecreateHandle()
            End If
        End Set
    End Property
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If m_CharacterCasing = CharacterCasing.Lower Then
                cp.Style = cp.Style Or CBS_LOWERCASE
            ElseIf m_CharacterCasing = CharacterCasing.Upper Then
                cp.Style = cp.Style Or CBS_UPPERCASE
            End If
            Return cp
        End Get
    End Property

    <Description("Color of the Border when the combo is focused or the mouse is over")> _
        Public Property HighlightBorderColor() As Color
        Get
            Return m_HighlightBorderColor
        End Get
        Set(ByVal Value As Color)
            m_HighlightBorderColor = Value
        End Set
    End Property

    <Description("ColumnNames of the Datatable passed through SourceDataTable Property to show in the Dropdownlist")> _
        Public Property SourceDataString() As String()
        Get
            Return m_SourceDataString
        End Get
        Set(ByVal Value As String())
            m_SourceDataString = Value

            Dim j As Integer = 0
            If Not m_DataTable Is Nothing Then
                For Each Column_Name As String In m_SourceDataString
                    If m_DataTable.Columns.Contains(Column_Name) Then
                        Dim i As Integer = 0
                        For Each Colonna As DataColumn In m_DataTable.Columns
                            If UCase(Colonna.ColumnName) = UCase(Column_Name) Then
                                Indice(j) = i
                            End If
                            i += 1
                        Next
                        j += 1
                    End If
                Next
            End If
        End Set
    End Property

    <Description("DataTable used as source in the Combobox")> _
    Public Property SourceDataTable() As DataTable
        Get
            Return m_DataTable
        End Get
        Set(ByVal Value As DataTable)
            m_DataTable = Value
            If Not Value Is Nothing Then
                Dim j As Integer = 0
                If Not (m_SourceDataString Is Nothing) AndAlso (m_SourceDataString.Length > 0) Then
                    For Each Column_Name As String In m_SourceDataString
                        If m_DataTable.Columns.Contains(Column_Name) Then
                            Dim i As Integer = 0
                            For Each Colonna As DataColumn In m_DataTable.Columns
                                If UCase(Colonna.ColumnName) = UCase(Column_Name) Then
                                    Indice(j) = i
                                End If
                                i += 1
                            Next
                            j += 1
                        End If
                    Next
                Else
                    'the SourceDataString Property hasn't been set ---> columns are taken in the order they are in datatable
                    Indice(0) = 0
                    Indice(1) = 1
                    Indice(2) = 2
                    Indice(3) = 3
                    Indice(4) = 4
                End If
            End If

            For Each dr As DataRow In Value.Rows
                Select Case Me.ColumnNum
                    Case 1
                        Me.Items.Add(New MTGCComboBoxItem(Assegna(dr(Indice(0)))))
                    Case 2
                        Me.Items.Add(New MTGCComboBoxItem(Assegna(dr(Indice(0))), Assegna(dr(Indice(1)))))
                    Case 3
                        Me.Items.Add(New MTGCComboBoxItem(Assegna(dr(Indice(0))), Assegna(dr(Indice(1))), Assegna(dr(Indice(2)))))
                    Case 4
                        Me.Items.Add(New MTGCComboBoxItem(Assegna(dr(Indice(0))), Assegna(dr(Indice(1))), Assegna(dr(Indice(2))), Assegna(dr(Indice(3)))))
                    Case 5
                        Me.Items.Add(New MTGCComboBoxItem(Assegna(dr(Indice(0))), Assegna(dr(Indice(1))), Assegna(dr(Indice(2))), Assegna(dr(Indice(3))), Assegna(dr(Indice(4)))))
                End Select
            Next
        End Set
    End Property
#End Region

#Region " **************** General Methods and Overrides ****************"
    'This function is used to take care of DBNull in the DataTable
    Private Function Assegna(ByVal Value As Object) As String
        If IsDBNull(Value) Then
            Assegna = ""
        Else
            Assegna = CStr(Value)
        End If
    End Function

    'Calculate the location of the Arrow Box
    Private Sub ArrowBoxPosition(ByRef left As Integer, ByRef top As Integer, ByRef width As Integer, ByRef height As Integer)
        Dim rc As Rectangle = ClientRectangle
        width = arrowWidth
        left = rc.Right - width - 2
        top = rc.Top + 2
        height = rc.Height - 4
    End Sub

    'Custom painting of the DropDownList
    Private Sub mComboBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles mComboBox.DrawItem
        Dim g As Graphics = e.Graphics
        Dim r As Rectangle = e.Bounds
        Dim b As SolidBrush
        If e.Index >= 0 Then
            Dim rd As Rectangle = r
            rd.Width = rd.Left + 100
            b = New SolidBrush(sender.ForeColor)
            g.FillRectangle(b, rd)
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Near
            '******************* WINDOWS 98 **********************
            If e.State = DrawItemState.Selected Then
                'item selected
                e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), r)
                Select Case Me.ColumnNum
                    Case 1
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                            If Me.m_GridLineHorizontal Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                            End If
                        End If
                    Case 2
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 3
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 4
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If wcol4 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(3))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 5
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If wcol4 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(3))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3), rd.Y, sf)
                        End If
                        If wcol5 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) - CInt(wcol4) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(4))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                End Select
                e.DrawFocusRectangle()

                '******************* WINDOWS 2000/XP **********************
            ElseIf (e.State = (DrawItemState.NoAccelerator Or DrawItemState.Selected)) Or (e.State = (DrawItemState.Selected Or DrawItemState.NoAccelerator Or DrawItemState.NoFocusRect)) Then
                'item selected
                e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), r)
                Select Case Me.ColumnNum
                    Case 1
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                            If Me.m_GridLineHorizontal Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                            End If
                        End If
                    Case 2
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 3
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 4
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If wcol4 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(3))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 5
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If wcol4 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(3))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3), rd.Y, sf)
                        End If
                        If wcol5 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(DropDownBackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) - CInt(wcol4) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(4))).ToString, Me.Font, New SolidBrush(DropDownForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                End Select
                e.DrawFocusRectangle()
            Else
                'items NOT selected
                e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), r)
                Select Case Me.ColumnNum
                    Case 1
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X, rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 2
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 3
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 4
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If wcol4 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(3))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                    Case 5
                        If wcol1 > 0 Then
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(0))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X, rd.Y, sf)
                        End If
                        If wcol2 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) - 2, rd.Y, rd.X + CInt(wcol1) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) - 1, rd.Y, r.Width - CInt(wcol1) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(1))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1), rd.Y, sf)
                        End If
                        If wcol3 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) + CInt(wcol2) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(2))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1) + CInt(wcol2), rd.Y, sf)
                        End If
                        If wcol4 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(3))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3), rd.Y, sf)
                        End If
                        If wcol5 > 0 Then
                            If Me.m_GridLineVertical Then
                                e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 2, rd.Y, rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 2, rd.Y + 15)
                            End If
                            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4) - 1, rd.Y, r.Width - CInt(wcol1) - CInt(wcol2) - CInt(wcol3) - CInt(wcol4) + 1, r.Height)
                            e.Graphics.DrawString(Assegna(m_DataTable.Rows(e.Index)(Indice(4))).ToString, Me.Font, New SolidBrush(sender.ForeColor), rd.X + CInt(wcol1) + CInt(wcol2) + CInt(wcol3) + CInt(wcol4), rd.Y, sf)
                        End If
                        If Me.m_GridLineHorizontal Then
                            e.Graphics.DrawLine(New Pen(GridLineColor, 1), rd.X, rd.Y + rd.Height - 1, rd.X + Me.DropDownWidth, rd.Y + rd.Height - 1)
                        End If
                End Select
                e.DrawFocusRectangle()
            End If
        End If
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'AUTOCOMPLETE: we have to know when a key has been really pressed

        PressedKey = True
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        'AUTOCOMPLETING

        'WARNING: With VB.Net 2003 there is a strange behaviour. This event is raised not just when any key is pressed
        'but also when the Me.Text property changes. Particularly, it happens when you write in a fast way (for example you
        'you press 2 keys and the event is raised 3 times). To manage this we have added a boolean variable PressedKey that
        'is set to true in the OnKeyPress Event

        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        '' '' '' '' ''Dim sAppendText As String

        If PressedKey Then
            'Ignoring alphanumeric chars
            Select Case e.KeyCode
                Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down, Keys.End, Keys.Home
                    Return
            End Select

            If Me.DroppedDown Then
                'Get the Typed Text and Find it in the list
                sTypedText = Me.Text
                iFoundIndex = Me.FindString(sTypedText)

                'If we found the Typed Text in the list then Autocomplete
                If iFoundIndex >= 0 Then

                    'Get the Item from the list (Return Type depends if Datasource was bound 
                    ' or List Created)
                    oFoundItem = Me.Items(iFoundIndex)

                    'Use the ListControl.GetItemText to resolve the Name in case the Combo 
                    ' was Data bound
                    sFoundText = Me.GetItemText(oFoundItem)

                    'Select the Appended Text
                    '' '' '' '' ''Me.SelectionStart = sTypedText.Length

                    If e.KeyCode = Keys.Enter Then
                        iFoundIndex = Me.FindStringExact(Me.Text)
                        Me.SelectedIndex = iFoundIndex
                        '' '' '' '' ''SendKeys.Send(vbTab)
                        e.Handled = True
                    End If
                End If
            End If
        End If
        PressedKey = False
    End Sub
#End Region

#Region " **************** Mouse and focus Overrides ****************"
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        If Highlighted Then
            currentColor = Me.NormalBorderColor
            Dim g As Graphics = Graphics.FromHwnd(Me.Handle)
            g.Dispose()
        End If
    End Sub

    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnGotFocus(e)
        If Not Highlighted Then
            currentColor = Me.HighlightBorderColor
            Dim g As Graphics = Graphics.FromHwnd(Me.Handle)
            g.Dispose()
        End If
    End Sub
#End Region

End Class


#Region " ----- This class is used to create and manage the items of the combobox (with max 5 columns) -----"

Public Class MTGCComboBoxItem
    'Since all we need is a "Text" property for this example we can
    'Subclass by inheriting any object desired.
    'For this example, we'll use the ListViewItem
    Inherits ListViewItem
    Implements IComparable

    'each of the below public declarations will be "visible" to the outside
    'You may add as many of these declarations using whatever types you desire
    Public Col1 As String
    Public Col2 As String
    Public Col3 As String
    Public Col4 As String
    Public Col5 As String

    'every value of MyInfo you want to store, get's added to the NEW declaration 
    Sub New(ByVal C1 As String, Optional ByVal C2 As String = "", Optional ByVal C3 As String = "", Optional ByVal C4 As String = "", Optional ByVal C5 As String = "")
        MyBase.New()
        'transfer all incoming parameters to your local storage
        Col1 = C1
        Col2 = C2
        Col3 = C3
        Col4 = C4
        Col5 = C5
        'and finally, pass back the Text property
        Me.Text = C1
    End Sub

    'Function used to sort the items on first element Col1
    Private Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        'every not nothing object is greater than nothing
        If obj Is Nothing Then Return 1

        'this is used to take care of late binding
        Dim other As MTGCComboBoxItem = CType(obj, MTGCComboBoxItem)

        'comparing strings
        Return StrComp(Col1, other.Col1, CompareMethod.Text)
    End Function
End Class
#End Region
