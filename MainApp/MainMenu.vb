Imports BProc_UI
Imports Reporting
Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQuickCode
Imports Utility_UI
Imports SEMICO_Dialog.ClsMessage
Imports BPRoc_LIB
Imports BPRoc_LIB.Setting
Imports BPRoc_LIB.Commonly
Imports BPRoc_LIB.SharedFunction

Public Class MainMenu
    Private Property Password As String = ""
    Private Property UserName As String = ""
    Private Property Userlevel As USER_LEVEL

    Public Property BarcodeMode As BARCODE_MODE
        Get
            Return My.Settings.BarcodeMode
        End Get
        Set(value As BARCODE_MODE)
            My.Settings.BarcodeMode = value
            My.Settings.Save()
        End Set
    End Property

    Private Sub RadButtonElement1_Click(sender As Object, e As EventArgs) Handles RadButtonElement1.Click
        If AllowEntryUserCome() = False Then Exit Sub
        Using customer As New Frm_Customer() With {.UserName = UserName}
            customer.ShowDialog()
        End Using
    End Sub

    Private Sub MnuCashier_Click(sender As Object, e As EventArgs) Handles MenuCashier.Click
        Using cashier As New Frm_Cashier() With {.UserName = UserName, .BarcodeMode = BarcodeMode}
            cashier.ShowDialog()
        End Using
    End Sub

    Private Sub MenuSupplier_Click(sender As Object, e As EventArgs) Handles MenuSupplier.Click
        If AllowEntryUserCome() = False Then Exit Sub
        Using supplier As New FRm_Supplier() With {.userName = UserName}
            supplier.ShowDialog()
        End Using
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As EventArgs) Handles MenuItem.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using item As New Frm_Item() With {.UserName = UserName}
                item.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub MenuCostOperatinal_Click(sender As Object, e As EventArgs) Handles MenuCostOperatinal.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using cashier As New Frm_Cashier() With {.UserName = UserName, .ModePenjualan = CASHIER_MODE.ON_CANCELATION}
                cashier.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub MenuSetting_Click(sender As Object, e As EventArgs) Handles MenuSetting.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using settings As New Frm_Setting() With {.UserName = UserName}
                settings.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub MEnuAbout_Click(sender As Object, e As EventArgs) Handles MEnuAbout.Click
        On Error Resume Next
        Using about As New DialogAbout
            about.ShowDialog()
        End Using
    End Sub

    Private Sub TestConnection(ByRef shouldReturn As Boolean)
        shouldReturn = False
        Dim Conn As New ClsSQL
        Try
            Conn.Connection.ConnectionString = ConectionString
            Conn.Connection.Open()
        Catch ex As Exception
            WarnMessage(ex.Message)
            shouldReturn = True : Exit Sub
        End Try
    End Sub
    Private Shared Sub RegisterApp()
        Using registerApp As New RegisterApp()
            registerApp.ShowDialog()
            If registerApp.Value = False Then End
        End Using
        My.Settings.Register = True
    End Sub
    Private Sub CheckRegisteredHost(ByRef temp As Boolean, ByRef Tusername As String, ByVal lgn As DialogLogin)
        If GetStatusRegisterdHost(My.Computer.Name) Then
            temp = True
            Tusername = lgn.VALUE_USERID
            Password = lgn.VALUE_PASSWORD
            stsHostName.Text = My.Computer.Name
            Userlevel = GetLevelUser(lgn.VALUE_USERID)
            ShowWhatNewMessage(True)
        Else
            WarnMessage("Your Computer not registered")
            End
        End If
    End Sub
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load, mnuLogout.Click
        Try
            TabMenuUserActivity.IsSelected = True
            Visible = False
            Dim STATUS As Boolean
            TestConnection(STATUS)
            If My.Settings.Register = False Or STATUS Then
                RegisterApp()
            End If
            Dim temp = False
            Dim Tusername As String = ""
            Using login As New DialogLogin(ConectionString, "T_user", "username", "passwordUser")
                login.ShowDialog()
                If login.HASVALUE = False Then End
                CheckRegisteredHost(temp, Tusername, login)
            End Using
            If temp Then
                UserName = Tusername
                btnUserName.Text = UserName
                Visible = True
            End If
            Using cashier As New Frm_Cashier() With {.UserName = UserName, .BarcodeMode = BarcodeMode}
                cashier.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement2_Click(sender As Object, e As EventArgs) Handles RadButtonElement2.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Process.Start(AppPath)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement11_Click(sender As Object, e As EventArgs) Handles RadButtonElement11.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Process.Start(AppPath)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement4_Click(sender As Object, e As EventArgs) Handles RadButtonElement4.Click
        Try
            Using supplier As New Frm_ReportSupplier
                supplier.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement3_Click(sender As Object, e As EventArgs) Handles RadButtonElement3.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using reportCustomer As New Frm_ReportCustomer
                reportCustomer.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement5_Click(sender As Object, e As EventArgs) Handles RadButtonElement5.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using reportSellingOption As New Frm_ReportOptionSelling
                reportSellingOption.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            stsDatetime.Text = String.Format("Date and Time : {0}", Date.Now)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement7_Click(sender As Object, e As EventArgs) Handles RadButtonElement7.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using userManager As New Frm_UserManager() With {.UserName = UserName}
                userManager.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement15_Click(sender As Object, e As EventArgs) Handles RadButtonElement15.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using reportUnit As New Frm_reportUnit
                reportUnit.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement6_Click(sender As Object, e As EventArgs) Handles RadButtonElement6.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using reportOptionSelling As New Frm_ReportOptionSelling() With {.MOde = CASHIER_MODE.ON_CANCELATION}
                reportOptionSelling.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement8_Click(sender As Object, e As EventArgs) Handles RadButtonElement8.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using backup As New Frm_Backup
                backup.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement9_Click(sender As Object, e As EventArgs) Handles RadButtonElement9.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using restore As New Frm_Restore
                restore.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub MnuQueryTransaction_Click(sender As Object, e As EventArgs) Handles RadButtonElement14.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using queryTransaction As New Frm_QueryTransaction
                queryTransaction.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadMenuItem6_Click(sender As Object, e As EventArgs) Handles RadMenuItem6.Click
        Try
            Using changePassword As New DialogChangePassword() With {.FIELD_PASSWORD = "PasswordUser", .FIELD_USERID = "username", .TABLE = "T_user", .USERID = UserName, _
                                                                           .Password = Password, .StringConnection = ConectionString}
                changePassword.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Shared Sub CallingExternalApp(appName As String, Optional parameter As String = "")
        Try
            Using appCaller As New Process() With {.StartInfo = New ProcessStartInfo(appName, parameter)}
                appCaller.Start()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub
    Private Sub mnuCalc_Click(sender As Object, e As EventArgs) Handles mnuCalc.Click
        Try
            CallingExternalApp("calc")
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuNotepad_Click(sender As Object, e As EventArgs) Handles mnuNotepad.Click
        Try
            CallingExternalApp("notepad")
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuPing_Click(sender As Object, e As EventArgs) Handles mnuPing.Click
        Try
            CallingExternalApp("ping", "-n 25 " & ServerName)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuPublishVersion_Click(sender As Object, e As EventArgs) Handles mnuPublishVersion.Click
        Try
            If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                Dim PV As String = " Publish Version : " & System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
                InfoMessage(PV)
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuSync_Click(sender As Object, e As EventArgs)
        Try
            Dim syncSystem As New Frm_SyncSystem
            syncSystem.ShowDialog()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuDownloadDB_Click(sender As Object, e As EventArgs) Handles mnuDownloadDB.Click
        If AllowEntryUserCome() = False Then Exit Sub
        Using restore As New Frm_Restore() With {.MODE = DB_MODE.ON_DOWNLOAD_BACKUP}
            restore.ShowDialog()
        End Using
    End Sub

    Private Sub mnuRegister_Click(sender As Object, e As EventArgs) Handles mnuRegister.Click
        Try
            Dim registerApp As New RegisterApp() With {.Registered = True}
            registerApp.ShowDialog()
            If registerApp.Value = False Then Exit Sub
            My.Settings.Register = True
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Public Shared WhatNewStatus As Boolean = False
    Private Shared Sub RemoveNotifyWhatNew(ByVal fileName As Object, ByVal WNpath As String)
        ClsFile.DeleteFile(WNpath)
        ClsFile.CopyTo(fileName, WNpath)
        ClsFile.DeleteFile(fileName)
    End Sub
    Private Shared Sub ShowWhatNewMessage(Optional startup As Boolean = False)
        Try
            Dim fileName = AppPath("File\whatnew.txt")
            Const WNpath As String = "D:\WN.txt"
            If ClsFile.ExistFile(fileName) = False Then
                If startup Then Return
                fileName = WNpath
            End If
            Dim MSG As String = ClsFile.OpenTXT(fileName)
            If MSG.Trim = "" Then
                WarnMessage("No Feature found")
                Return
            End If
            InfoMessage(MSG, "What New ?")
            If startup Then
                If AskMessage("Always show update information after login?") = Windows.Forms.DialogResult.No Then
                    RemoveNotifyWhatNew(fileName, WNpath)
                End If
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuWhatNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuWhatNew.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            ShowWhatNewMessage(False)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub RadButtonElement16_Click(sender As Object, e As EventArgs) Handles RadButtonElement16.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using runPackage As New Frm_RunPackage
                runPackage.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuSQLserver_Click(sender As Object, e As EventArgs) Handles mnuSQLserver.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Process.Start("C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\Ssms.exe")
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuConFigDB_Click(sender As Object, e As EventArgs) Handles mnuConFigDB.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Process.Start("C:\Windows\SysWOW64\mmc.exe", " /32 C:\Windows\SysWOW64\SQLServerManager10.msc")
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuWebserverVersion_Click(sender As Object, e As EventArgs) Handles mnuWebserverVersion.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using serverWebVersion As New Frm_ServerWebVersion()
                serverWebVersion.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub mnuSetting_Click(sender As Object, e As EventArgs) Handles mnuSetting.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using settingForm As New Frm_SettingForm() With {.BarcodeMode = BarcodeMode}
                settingForm.ShowDialog()
                BarcodeMode = settingForm.BarcodeMode
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Function AllowEntryUserCome() As Boolean
        Try
            If Userlevel = USER_LEVEL.USER_ENTRY Then
                WarnMessage(MSGAccessDenied)
                Return False
            End If

        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
        Return True
    End Function
    Private Sub mnuMessage_Click(sender As Object, e As EventArgs) Handles mnuMessage.Click
        Try
            If AllowEntryUserCome() = False Then Exit Sub
            Using serverWebVersion As New Frm_ServerWebVersion() With {.Text = "Message", .urlServerPage = "https://www.facebook.com/messages/", .WindowState = FormWindowState.Maximized}
                serverWebVersion.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

End Class