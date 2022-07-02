Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsValidasi
Imports BPRoc_LIB.Setting
Public Class Frm_Backup
    ReadOnly gconn As New ClsSQL(BPRoc_LIB.Setting.ConectionStringMaster)
    Private path As String = BackupPath

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        EnabledFormControl(RadGroupBox1, False)
        RadWaitingBar1.Visible = True
        RadWaitingBar1.StartWaiting()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        gconn.StringQuery = "Exec BackupDB " & CSQL(String.Format("{0}{1}.{2}", path, txtFileName.Text, Ext))
        Try
            gconn.Execute()
        Catch ex As Exception
            If ex.Message Like "*Cannot find table 0*" Then
                'SKIP ini bug semico dll
                Exit Sub
            End If
            WarnMessage(ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        RadWaitingBar1.StopWaiting()
        RadWaitingBar1.Visible = False
        EnabledFormControl(RadGroupBox1, True)
        If e.Cancelled = True Then
            WarnMessage("Backup Database Failed")
        Else
            InfoMessage("Backup Database backup successfully")
        End If
    End Sub

    Private Sub Frm_Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFileName.Text = String.Format("mandiriBackup{0:dd-MMM-yyyy-hh-mm-ss}", Date.Now)
    End Sub
End Class