Imports SEMICO_Dialog.ClsMessage
Public Class Frm_SyncSystem

    Private Sub btnDeleteOlderVersion_Click(sender As Object, e As EventArgs) Handles btnDeleteOlderVersion.Click
        Using p As New Process()
            Try
                Const path As String = "\\user-PC\update\Application Files\"
                System.IO.Directory.Delete(path, True)
                InfoMessage("Delete Success")
            Catch ex As Exception
                WarnMessage(ex.Message)
            End Try

        End Using
    End Sub

    Private Sub btnGoodSyncUpdate_Click(sender As Object, e As EventArgs) Handles btnGoodSyncUpdate.Click
        Dim p As New Process
        p.StartInfo = New ProcessStartInfo("C:\Program Files\Siber Systems\GoodSync\GoodSync.exe")
        p.Start()
    End Sub

    Private Sub BtnManualCopyUpdate_Click(sender As Object, e As EventArgs) Handles BtnManualCopyUpdate.Click
        Dim p As New Process
        InfoMessage("User : mandiri@semico-web.com and Password : mandiri")
        InfoMessage("Copy and Replace to D:\Update")
        p.StartInfo = New ProcessStartInfo("explorer", "ftp://semico-web.com/publish")
        p.Start()
    End Sub
End Class