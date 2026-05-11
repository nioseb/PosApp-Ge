<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_NCR_CLS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_NCR_CLS))
        Me.NCRCashDrawer = New AxOposCashDrawer_1_10_Lib.AxOPOSCashDrawer
        CType(Me.NCRCashDrawer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NCRCashDrawer
        '
        Me.NCRCashDrawer.Enabled = True
        Me.NCRCashDrawer.Location = New System.Drawing.Point(12, 12)
        Me.NCRCashDrawer.Name = "NCRCashDrawer"
        Me.NCRCashDrawer.OcxState = CType(resources.GetObject("NCRCashDrawer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.NCRCashDrawer.Size = New System.Drawing.Size(165, 117)
        Me.NCRCashDrawer.TabIndex = 0
        '
        'F_NCR_CLS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 325)
        Me.ControlBox = False
        Me.Controls.Add(Me.NCRCashDrawer)
        Me.Name = "F_NCR_CLS"
        Me.ShowIcon = False
        Me.Text = "F_NCR_CLS"
        CType(Me.NCRCashDrawer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NCRCashDrawer As AxOposCashDrawer_1_10_Lib.AxOPOSCashDrawer
End Class
