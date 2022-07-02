Imports BPRoc_LIB
Imports BPRoc_LIB.EntitiesModel
Public Class Frm_ReportSupplier
    Dim Fnc As New PublicFunction

    Private Sub Frm_Customer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.SupplierBindingSource.DataSource = Fnc.GetListSupplier()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class