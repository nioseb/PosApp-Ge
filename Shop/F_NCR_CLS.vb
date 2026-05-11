Imports OposCashDrawer_1_10_Lib

Public Class F_NCR_CLS
    Public Sub OpenNCRDrawer(ByVal drawer_name As String)
        NCRCashDrawer.Open(drawer_name)
        NCRCashDrawer.ClaimDevice(200)
        NCRCashDrawer.DeviceEnabled = True
    End Sub
End Class