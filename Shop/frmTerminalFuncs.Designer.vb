<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTerminalFuncs
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
        Me.btnFullReport = New System.Windows.Forms.Button
        Me.btnShortReport = New System.Windows.Forms.Button
        Me.btnReconciliation = New System.Windows.Forms.Button
        Me.btnLastReceiptCopy = New System.Windows.Forms.Button
        Me.btnReceiptCopy = New System.Windows.Forms.Button
        Me.btnCheckConnection = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnFullReport
        '
        Me.btnFullReport.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnFullReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFullReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnFullReport.Location = New System.Drawing.Point(183, 29)
        Me.btnFullReport.Name = "btnFullReport"
        Me.btnFullReport.Size = New System.Drawing.Size(124, 110)
        Me.btnFullReport.TabIndex = 5
        Me.btnFullReport.Text = "სრული რეპორტი"
        Me.btnFullReport.UseVisualStyleBackColor = True
        '
        'btnShortReport
        '
        Me.btnShortReport.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnShortReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnShortReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnShortReport.Location = New System.Drawing.Point(30, 29)
        Me.btnShortReport.Name = "btnShortReport"
        Me.btnShortReport.Size = New System.Drawing.Size(124, 110)
        Me.btnShortReport.TabIndex = 4
        Me.btnShortReport.Text = "მოკლე რეპორტი (X)"
        Me.btnShortReport.UseVisualStyleBackColor = True
        '
        'btnReconciliation
        '
        Me.btnReconciliation.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReconciliation.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReconciliation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnReconciliation.Location = New System.Drawing.Point(337, 29)
        Me.btnReconciliation.Name = "btnReconciliation"
        Me.btnReconciliation.Size = New System.Drawing.Size(124, 110)
        Me.btnReconciliation.TabIndex = 6
        Me.btnReconciliation.Text = "დღის დახურვა (Z)"
        Me.btnReconciliation.UseVisualStyleBackColor = True
        '
        'btnLastReceiptCopy
        '
        Me.btnLastReceiptCopy.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLastReceiptCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLastReceiptCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnLastReceiptCopy.Location = New System.Drawing.Point(30, 167)
        Me.btnLastReceiptCopy.Name = "btnLastReceiptCopy"
        Me.btnLastReceiptCopy.Size = New System.Drawing.Size(124, 110)
        Me.btnLastReceiptCopy.TabIndex = 7
        Me.btnLastReceiptCopy.Text = "ბოლო ქვითრის ასლი"
        Me.btnLastReceiptCopy.UseVisualStyleBackColor = True
        '
        'btnReceiptCopy
        '
        Me.btnReceiptCopy.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReceiptCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReceiptCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnReceiptCopy.Location = New System.Drawing.Point(183, 167)
        Me.btnReceiptCopy.Name = "btnReceiptCopy"
        Me.btnReceiptCopy.Size = New System.Drawing.Size(124, 110)
        Me.btnReceiptCopy.TabIndex = 8
        Me.btnReceiptCopy.Text = "კონკრეტული ქვითრის ასლი"
        Me.btnReceiptCopy.UseVisualStyleBackColor = True
        '
        'btnCheckConnection
        '
        Me.btnCheckConnection.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCheckConnection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCheckConnection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnCheckConnection.Location = New System.Drawing.Point(337, 167)
        Me.btnCheckConnection.Name = "btnCheckConnection"
        Me.btnCheckConnection.Size = New System.Drawing.Size(124, 110)
        Me.btnCheckConnection.TabIndex = 9
        Me.btnCheckConnection.Text = "კავშირის შემოწმება"
        Me.btnCheckConnection.UseVisualStyleBackColor = True
        '
        'frmTerminalFuncs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 310)
        Me.Controls.Add(Me.btnCheckConnection)
        Me.Controls.Add(Me.btnReceiptCopy)
        Me.Controls.Add(Me.btnLastReceiptCopy)
        Me.Controls.Add(Me.btnReconciliation)
        Me.Controls.Add(Me.btnFullReport)
        Me.Controls.Add(Me.btnShortReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTerminalFuncs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ტერმინალის ფუნქციები"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFullReport As System.Windows.Forms.Button
    Friend WithEvents btnShortReport As System.Windows.Forms.Button
    Friend WithEvents btnReconciliation As System.Windows.Forms.Button
    Friend WithEvents btnLastReceiptCopy As System.Windows.Forms.Button
    Friend WithEvents btnReceiptCopy As System.Windows.Forms.Button
    Friend WithEvents btnCheckConnection As System.Windows.Forms.Button
End Class
