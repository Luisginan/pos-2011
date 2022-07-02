Imports SEMICO_Dialog.ClsQuickCode
Public Class Setting
    Public Const TextResetPassword = "mandiri"
    Public Const MSGAskDelete = "Are You Sure Delete data?"
    Public Const MSGAskReset = "Are You Sure Reset data?"
    Public Const MSGNoData = "No Data"
    Public Const MSGNoDataAffected = "No Data Affected"
    Public Const MSGDataSave = "Insert data Successfully"
    Public Const MSGDataUpdate = "Data Modify Successfully"
    Public Const MSGDataDelete = "Data Deleted Successfully"
    Public Const _MSGmustHaveValue = " Must have value"
    Public Const MSGDataDuplicat = "Data duplicate key"
    Public Const MSGAskDeleteData = "Are you sure delete this data ?"
    Public Const MSGAskDeleteItem = "Are you sure delete this item ?"
    Public Const MSGMUstConfirm = " Must be Confirm "
    Public Const MSGAccessDenied = "Access Denied"
    Public Shared ReadOnly Property ConectionString As String
        Get
            Return ProviderSQLserver(My.Settings.User, My.Settings.Password, My.Settings.Server, "mandiri")
        End Get
    End Property
    Public Shared ReadOnly Property BackupPath As String
        Get
            Dim Fnc As New PublicFunction
            Dim Temp As String = ""
            Dim Setting = Fnc.GetSingleT_Setting("BackupPath")
            If Fnc.HasError = False Then
                Temp = Setting.TValue
            End If
            Return Temp
        End Get
    End Property
    Public Shared ReadOnly Property Ext As String
        Get
            Dim Fnc As New PublicFunction
            Dim Temp As String = ""
            Dim Setting = Fnc.GetSingleT_Setting("Ext")
            If Fnc.HasError = False Then
                Temp = Setting.TValue
            End If
            Return Temp
        End Get
    End Property
    Public Shared ReadOnly Property ConectionStringMaster As String
        Get
            Return ProviderSQLserver(My.Settings.User, My.Settings.Password, My.Settings.Server, "Master")
        End Get
    End Property
    Private Shared Sub UpdateMySetting(settingName As String, ByVal Value As String)
        My.Settings.Item(settingName) = Value
        My.Settings.Save()
    End Sub
    Public Shared Sub UpdateMySetting(ServerName As String, username As String, Password As String)
        UpdateMySetting("server", ServerName)
        UpdateMySetting("user", username)
        UpdateMySetting("Password", Password)
    End Sub
End Class