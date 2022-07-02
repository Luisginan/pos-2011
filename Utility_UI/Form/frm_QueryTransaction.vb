Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsFile
Imports BPRoc_LIB.Setting
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI.Export
Imports SEMICO_Dialog.ClsQuickCode

Public Class Frm_QueryTransaction
    Private gconn As New ClsSQL

    Private Sub executeWithCMD()
        Dim par = String.Format(" -E -d{0} -i""{1}""", DDDB.Text, txtFilePath.Text)
        Dim textcmd = String.Format("SQLCMD {0}{1}CMD", par, vbCrLf)
        Dim PathCMD = txtFilePath.Text.Replace(".SQL", ".bat")
        WriteTXT(PathCMD, textcmd)
        Process.Start(PathCMD)
    End Sub
    Private Sub executeWithVisual()
        GV.DataSource = Nothing
        GV.DataSource = gconn.Execute(txtQuery.Text)
        GV.Refresh()
        Text = "Query Transaction - Record Found : " & gconn.Table.Rows.Count
    End Sub
    Private Sub RadButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadButton1.Click
        Try
            If chkRunCMD.Checked = True Then
                executeWithCMD()
                Return
            End If
            If txtQuery.Text.ToUpper.Contains("SELECT") Then
                executeWithVisual()
            Else
                gconn.Execute(txtQuery.Text)
                InfoMessage("RowsEffected : " & gconn.RowsEffected)
            End If
        Catch ex As Exception
            If ex.Message Like "*0*" Then
                InfoMessage("Query Successfully")
                Exit Sub
            End If
            ErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnOpenFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOpenFile.Click
        Try
            OpenFileDialog1.Filter = "Text files (*.SQL)|*.SQL|All files (*.*)|*.*"
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.InitialDirectory = AppPath("Query")
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName <> "" Then
                txtFilePath.Text = OpenFileDialog1.FileName
                txtQuery.Text = OpenTXT(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try

    End Sub

    Private Sub DDDB_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles DDDB.SelectedIndexChanged
        Try
            LoadConnectionString()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try

    End Sub

    Private Sub LoadConnectionString()
        With BPRoc_LIB.My.MySettings.Default
            gconn = New ClsSQL(.User, .Password, .Server, DDDB.Text)
        End With
    End Sub
    Private Sub Frm_QueryTransaction_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadConnectionString()
    End Sub

    Private Sub ValidatingCollumnGridView()
        For Each collum In GV.Columns
            If collum.Name Like "*Tgl*" Or collum.Name Like "*Tanggal*" Then
                collum.ExcelExportType = DisplayFormatType.Custom
                collum.ExcelExportFormatString = "dd-MM-yyyy"
            End If
        Next
    End Sub
    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        Try
            ValidatingCollumnGridView()
            FolderBrowserDialog1.ShowDialog()
            Dim exporter = New ExportToExcelML(GV) With {.HiddenColumnOption = HiddenOption.DoNotExport}
            If FolderBrowserDialog1.SelectedPath <> "" Then
                exporter.RunExport(String.Format("{0}\Export-{1:ddMMyyyyhhmmss}.xls", FolderBrowserDialog1.SelectedPath, Now))
                InfoMessage("Export Success")
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try

    End Sub
End Class