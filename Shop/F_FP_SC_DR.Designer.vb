<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_FP_SC_DR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_FP_SC_DR))
        Me.SC = New AxSCANNERLib.AxOPOS_Scanner
        Me.DR = New AxDRAWERLib.AxOPOS_Drawer
        Me.FP = New AxMercFPrtX.AxMercuryFPrtX
        CType(Me.SC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SC
        '
        Me.SC.Enabled = True
        Me.SC.Location = New System.Drawing.Point(0, 2)
        Me.SC.Name = "SC"
        Me.SC.OcxState = CType(resources.GetObject("SC.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SC.Size = New System.Drawing.Size(110, 145)
        Me.SC.TabIndex = 0
        '
        'DR
        '
        Me.DR.Enabled = True
        Me.DR.Location = New System.Drawing.Point(116, 2)
        Me.DR.Name = "DR"
        Me.DR.OcxState = CType(resources.GetObject("DR.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DR.Size = New System.Drawing.Size(159, 143)
        Me.DR.TabIndex = 1
        '
        'FP
        '
        Me.FP.Location = New System.Drawing.Point(0, 153)
        Me.FP.Name = "FP"
        Me.FP.OcxState = CType(resources.GetObject("FP.OcxState"), System.Windows.Forms.AxHost.State)
        Me.FP.Size = New System.Drawing.Size(275, 206)
        Me.FP.TabIndex = 2
        '
        'F_FP_SC_DR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 520)
        Me.ControlBox = False
        Me.Controls.Add(Me.FP)
        Me.Controls.Add(Me.DR)
        Me.Controls.Add(Me.SC)
        Me.Name = "F_FP_SC_DR"
        Me.ShowIcon = False
        Me.Text = "F_FP_SC_DR"
        CType(Me.SC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SC As AxSCANNERLib.AxOPOS_Scanner
    Friend WithEvents DR As AxDRAWERLib.AxOPOS_Drawer
    Friend WithEvents FP As AxMercFPrtX.AxMercuryFPrtX
End Class
