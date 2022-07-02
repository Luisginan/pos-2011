Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsValidasi
Imports BPRoc_LIB.Setting
Imports BPRoc_LIB

Public Class Frm_Restore
    ReadOnly gconn As New ClsSQL(Setting.ConectionStringMaster)
    Private Path = BackupPath
    Private errorMessage As String
    Property MODE As DB_MODE = DB_MODE.ON_RESTORE

    Private Sub Frm_Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            gconn.StringQuery = String.Format("EXECUTE sp_ListFiles {0},NULL,NULL,NULL,1", CSQL(Path))
            gconn.Execute()
            LV.DataSource = gconn.Table
            If MODE = DB_MODE.ON_DOWNLOAD_BACKUP Then
                BtnRestore.Text = "Download"
                Me.Text = "Download Database"
                Me.ChkSplitFile.Visible = True
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        RadWaitingBar1.StopWaiting()
        RadWaitingBar1.Visible = False
        EnabledFormControl(RadGroupBox1, True)
        If e.Cancelled = True Then
            WarnMessage(errorMessage)
        Else
            InfoMessage("Restore Database successfully")
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        gconn.StringQuery = "Exec RestoreDB " & CSQL(Path & LV.CurrentRow.Cells(0).Value)
        Try
            gconn.TimeOut = 100000
            gconn.Execute()
        Catch ex As Exception
            If ex.Message Like "*0*" Then
                'SKIP ini bug semico dll
                Exit Sub
            End If
            errorMessage = ex.Message
            e.Cancel = True
        End Try
    End Sub

    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        If MODE = DB_MODE.ON_RESTORE Then
            EnabledFormControl(RadGroupBox1, False)
            RadWaitingBar1.Visible = True
            RadWaitingBar1.StartWaiting()
            BackgroundWorker1.RunWorkerAsync()
        Else
            If ChkSplitFile.Checked Then
                Using split As New DialogSplitDB(Path & LV.CurrentRow.Cells(0).Value)
                    split.ShowDialog()
                End Using
            Else
                Using BCk As New DialogBackupRestore(Path & LV.CurrentRow.Cells(0).Value, EnumTipeBackupRestore.Mode_BackupData) With {.Text = "Download Database"}
                    BCk.ShowDialog()
                End Using
            End If
        End If
    End Sub
End Class