Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsQuickCode
Imports SEMICO_Dialog.ClsFile

Public Class RegisterApp

    Public Property Registered = False
    Public Property Value = False

    Private Sub RegisterApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += " For Computer Name : " & My.Computer.Name
        If Registered Then
            Dim Fnc As New PublicFunction
            txtServerDatabase.Text = BPRoc_LIB.My.MySettings.Default.Server
            txtUserName.Text = BPRoc_LIB.My.MySettings.Default.User
            txtPassword.Text = BPRoc_LIB.My.MySettings.Default.Password
            Dim Owner = Fnc.GetSingleOwner()
            If Fnc.HasError = False Then
                txtSerialNumber.Text = Owner.NoRegister
            End If
        End If
    End Sub

    Private Sub TestConnection()
        Dim Conn As New SEMICO_Dialog.ClsSQL
        Conn.Connection.ConnectionString = ProviderSQLserver(txtUserName.Text, txtPassword.Text, txtServerDatabase.Text, "Mandiri")
        Conn.Connection.Open()
        UpdateMySetting(txtServerDatabase.Text, txtUserName.Text, txtPassword.Text)
    End Sub

    Private Sub ExecuteTextScript()
        Dim conn As New SEMICO_Dialog.ClsSQL(ConectionString)
        If txtSqlScript.Text <> "" Then
            conn.Execute(txtSqlScript.Text)
        End If
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        Try
            TestConnection()
            ExecuteTextScript()
            Dim Fnc As New PublicFunction
            Dim Owner = Fnc.GetSingleOwner()
            If Fnc.HasError Then Throw New Exception("Invalid Register Number")
            Dim Host = Fnc.GetSingleHostReg(My.Computer.Name)
            If Fnc.HasError Then Throw New Exception(Fnc.MessageText & " For HostReg")
            If Host.IsStatus = False Then Throw New Exception("No Host registered in your database")
            If Owner.NoRegister Is Nothing Then Throw New Exception("No Owner Registered")
            InfoMessage("registered successfully")
            Value = True
            Close()
        Catch ex As Exception
            WarnMessage(ex.Message)
            Value = False
        End Try
    End Sub

    Private Sub BtnTestConnection_Click(sender As Object, e As EventArgs) Handles BtnTestConnection.Click
        TestConnection()
        InfoMessage("Connection to Server Successfully")
    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        DOFfileScript.DefaultExt = ".sfr"
        DOFfileScript.FileName = ""
        DOFfileScript.ShowDialog()
        If DOFfileScript.FileName <> "" Then
            txtSqlScript.Text = OpenTXT(DOFfileScript.FileName)
            txtSqlScript.Text = txtSqlScript.Text.Replace("MyName", My.Computer.Name)
        End If
    End Sub
End Class