Public Class Frm_ServerWebVersion
    Public Property urlServerPage = "http://www.semico-web.com/mandiri/publish/publish.htm"
    Private Sub Frm_ServerWebVersion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate(urlServerPage)
        WebBrowser1.Refresh()
    End Sub
End Class