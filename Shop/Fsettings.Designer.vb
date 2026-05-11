<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fsettings
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
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.cmb_Printer = New System.Windows.Forms.ComboBox
        Me.cmb_Drawer = New System.Windows.Forms.ComboBox
        Me.cmb_Scanner = New System.Windows.Forms.ComboBox
        Me.cmb_Fiscal = New System.Windows.Forms.ComboBox
        Me.lbl_Printer = New System.Windows.Forms.Label
        Me.lbl_Drawer = New System.Windows.Forms.Label
        Me.lbl_Scanner = New System.Windows.Forms.Label
        Me.lbl_Fiscal = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btn_Cancel.Location = New System.Drawing.Point(159, 126)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 5
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btn_OK.Location = New System.Drawing.Point(51, 126)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 4
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'cmb_Printer
        '
        Me.cmb_Printer.Font = New System.Drawing.Font("Sylfaen", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmb_Printer.FormattingEnabled = True
        Me.cmb_Printer.Location = New System.Drawing.Point(117, 87)
        Me.cmb_Printer.Name = "cmb_Printer"
        Me.cmb_Printer.Size = New System.Drawing.Size(161, 24)
        Me.cmb_Printer.TabIndex = 3
        '
        'cmb_Drawer
        '
        Me.cmb_Drawer.Font = New System.Drawing.Font("Sylfaen", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmb_Drawer.FormattingEnabled = True
        Me.cmb_Drawer.Location = New System.Drawing.Point(117, 59)
        Me.cmb_Drawer.Name = "cmb_Drawer"
        Me.cmb_Drawer.Size = New System.Drawing.Size(161, 24)
        Me.cmb_Drawer.TabIndex = 2
        '
        'cmb_Scanner
        '
        Me.cmb_Scanner.Font = New System.Drawing.Font("Sylfaen", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmb_Scanner.FormattingEnabled = True
        Me.cmb_Scanner.Location = New System.Drawing.Point(117, 31)
        Me.cmb_Scanner.Name = "cmb_Scanner"
        Me.cmb_Scanner.Size = New System.Drawing.Size(161, 24)
        Me.cmb_Scanner.TabIndex = 1
        '
        'cmb_Fiscal
        '
        Me.cmb_Fiscal.Font = New System.Drawing.Font("Sylfaen", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmb_Fiscal.FormattingEnabled = True
        Me.cmb_Fiscal.Location = New System.Drawing.Point(117, 3)
        Me.cmb_Fiscal.Name = "cmb_Fiscal"
        Me.cmb_Fiscal.Size = New System.Drawing.Size(161, 24)
        Me.cmb_Fiscal.TabIndex = 0
        '
        'lbl_Printer
        '
        Me.lbl_Printer.AutoSize = True
        Me.lbl_Printer.Font = New System.Drawing.Font("Sylfaen", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Printer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Printer.Location = New System.Drawing.Point(8, 88)
        Me.lbl_Printer.Name = "lbl_Printer"
        Me.lbl_Printer.Size = New System.Drawing.Size(82, 18)
        Me.lbl_Printer.TabIndex = 14
        Me.lbl_Printer.Text = "პრინტერი:"
        '
        'lbl_Drawer
        '
        Me.lbl_Drawer.AutoSize = True
        Me.lbl_Drawer.Font = New System.Drawing.Font("Sylfaen", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Drawer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Drawer.Location = New System.Drawing.Point(8, 60)
        Me.lbl_Drawer.Name = "lbl_Drawer"
        Me.lbl_Drawer.Size = New System.Drawing.Size(105, 18)
        Me.lbl_Drawer.TabIndex = 13
        Me.lbl_Drawer.Text = "ფულის უჯრა:"
        '
        'lbl_Scanner
        '
        Me.lbl_Scanner.AutoSize = True
        Me.lbl_Scanner.Font = New System.Drawing.Font("Sylfaen", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Scanner.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Scanner.Location = New System.Drawing.Point(8, 32)
        Me.lbl_Scanner.Name = "lbl_Scanner"
        Me.lbl_Scanner.Size = New System.Drawing.Size(67, 18)
        Me.lbl_Scanner.TabIndex = 12
        Me.lbl_Scanner.Text = "სკანერი:"
        '
        'lbl_Fiscal
        '
        Me.lbl_Fiscal.AutoSize = True
        Me.lbl_Fiscal.Font = New System.Drawing.Font("Sylfaen", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Fiscal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Fiscal.Location = New System.Drawing.Point(8, 4)
        Me.lbl_Fiscal.Name = "lbl_Fiscal"
        Me.lbl_Fiscal.Size = New System.Drawing.Size(93, 18)
        Me.lbl_Fiscal.TabIndex = 11
        Me.lbl_Fiscal.Text = "ფისკალური:"
        '
        'Fsettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(286, 153)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.cmb_Printer)
        Me.Controls.Add(Me.cmb_Drawer)
        Me.Controls.Add(Me.cmb_Scanner)
        Me.Controls.Add(Me.cmb_Fiscal)
        Me.Controls.Add(Me.lbl_Printer)
        Me.Controls.Add(Me.lbl_Drawer)
        Me.Controls.Add(Me.lbl_Scanner)
        Me.Controls.Add(Me.lbl_Fiscal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "Fsettings"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "მოწყობილობები"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents cmb_Printer As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Drawer As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Scanner As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Fiscal As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Printer As System.Windows.Forms.Label
    Friend WithEvents lbl_Drawer As System.Windows.Forms.Label
    Friend WithEvents lbl_Scanner As System.Windows.Forms.Label
    Friend WithEvents lbl_Fiscal As System.Windows.Forms.Label
End Class
