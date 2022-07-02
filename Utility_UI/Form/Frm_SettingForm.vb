Imports BPRoc_LIB
Public Class Frm_SettingForm
    Public Property BarcodeMode As BARCODE_MODE = BARCODE_MODE.ON_NORMAL
    Private Sub Frm_SettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If BarcodeMode = BARCODE_MODE.ON_NORMAL Then
            RBNormal.IsChecked = True
        Else
            RBautoEnter.IsChecked = True
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If RBNormal.IsChecked = True Then
            BarcodeMode = BARCODE_MODE.ON_NORMAL
        ElseIf RBautoEnter.IsChecked = True Then
            BarcodeMode = BARCODE_MODE.ON_AUTOENTER
        End If
        Close()
    End Sub
End Class