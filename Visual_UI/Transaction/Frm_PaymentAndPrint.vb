Imports BPRoc_LIB
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsValidasi
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.SharedFunction
Imports BPRoc_LIB.Setting
Public Class Frm_PaymentAndPrint
    Public Property UserName As String = ""
    Public Property InputPenjualan As Penjualan
    Public Property OutputValue As Boolean

    Private Sub Frm_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTotal.Text = InputPenjualan.TotalBayar
        txtRefund.Text = InputPenjualan.TotalBayar
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
#If DEBUG Then
        CetakFile(InputPenjualan, txtPaidOut.Text)
#Else
        cetakdot(InputPenjualan, txtPaidOut.Text)
#End If
        Close()
    End Sub

    Private Sub Frm_PaymentAndPrint_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtPaidOut.Focus()
    End Sub

    Private Sub txtPaidOut_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaidOut.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            BtnCancel.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.Enter Then
            BtnSave.PerformClick()
        End If
    End Sub

    Private Sub txtPaidOut_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaidOut.KeyPress
        SharedFunction.InputOnlyNumeric(e)
    End Sub
    Private Sub txtPaidOut_TextChanged(sender As Object, e As EventArgs) Handles txtPaidOut.TextChanged
        Try
            txtRefund.Text = txtPaidOut.Text - lblTotal.Text
        Catch ex As Exception
            txtRefund.Text = 0
        End Try
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class