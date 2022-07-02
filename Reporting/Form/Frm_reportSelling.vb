Imports BPRoc_LIB
Imports BPRoc_LIB.EntitiesModel
Public Class Frm_reportSelling
    Dim Fnc As New PublicFunction
    Public Property UserName As String = ""
    Public Property Mode As CASHIER_MODE
    Property Criteria As String = ""
    Private Sub Frm_Customer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Vw_laporanPenjualanBindingSource.DataSource = Fnc.GetListvw_laporanPenjualan(Criteria)
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class