Imports System.Xml
Imports SEMICO_Dialog.ClsQuickCode
Imports System.Drawing
Public Class Frm_RunPackage

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        OpenFileDialog1.Filter = "Text files (*.dtsx)|*.dtsx|All files (*.*)|*.*"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = AppPath("Package")
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then
            txtFilePath.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        Process.Start("""C:\Program Files (x86)\Microsoft SQL Server\100\DTS\Binn\DTExec.exe""", String.Format("/F ""{0}""", txtFilePath.Text))
    End Sub

    Private Sub Frm_RunPackage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFilePath.Text = AppPath("Package\ImportBarang.dtsx")
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Process.Start(String.Format("""{0}""", txtFilePath.Text))
    End Sub
End Class