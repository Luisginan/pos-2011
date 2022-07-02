Imports BPRoc_LIB
Imports BPRoc_LIB.EntitiesModel
Public Class Frm_ReportCustomer
    Dim Fnc As New PublicFunction

    Private Sub Frm_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PelangganBindingSource.DataSource = Fnc.GetListPelanggan()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class