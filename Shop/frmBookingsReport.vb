Imports System.Net
Imports System.Text

Public Class frmBookingsReport
    Private Sub frmBookingsReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ssrsUser As String = "WebUser"
        Dim ssrsPswd As String = "A30f9dff"
        Using webClient As New WebClient()
            webClient.Headers(HttpRequestHeader.Authorization) = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(ssrsUser + ":" + ssrsPswd))
            Dim credCache As New CredentialCache()
            Dim baseUrl As String = "http://db01.entree.ge:8024/ReportServer"
            credCache.Add(New Uri(baseUrl), "Basic", New NetworkCredential(ssrsUser, ssrsPswd))
            webClient.Credentials = credCache
            Dim fromDate As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            Dim endpoint As String = baseUrl + "/Pages/ReportViewer.aspx?%2fEntreeWebReports%2fSales+reports%2fReservations+report&restaurantId=" + Fmain.ResOSId + "&startDate=" + fromDate.ToString("yyyy-MM-dd") + "&endDate=" + fromDate.AddDays(1).ToString("yyyy-MM-dd") + "&rs:Format=HTML4.0&rc:toolbar=false"
            Dim data = webClient.DownloadData(endpoint)
            Dim content = Encoding.UTF8.GetString(data)
            wbHtmlHost.Refresh(WebBrowserRefreshOption.Completely)
            wbHtmlHost.DocumentText = content
        End Using
    End Sub
End Class