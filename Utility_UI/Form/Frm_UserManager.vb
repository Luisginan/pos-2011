Imports BPRoc_LIB
Imports BPRoc_LIB.SharedFunction
Imports SEMICO_Dialog.ClsMessage
Imports Telerik.WinControls.UI
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Setting
Imports System.Xml
Imports BPRoc_LIB.CRUD

Public Class Frm_UserManager
    Private editModeTuser As CRUD
    Dim Fnc As New PublicFunction
    Public Property UserName As String = ""

    Function ValidateInputControls() As Boolean
        Dim temp = True
        If AllAntiNullRad(GrpInputUser) = False Then
            temp = False
            ShieldMessage(SharedFunction.ControlErrorName & _MSGmustHaveValue)
        End If
        Return temp
    End Function

    Private Sub LoadDataListUser()
        GVuser.DataSource = Fnc.GetListT_user
    End Sub

    Private Sub EditUser(ByVal T_user As T_User)
        txtUserName.Enabled = False
        editModeTuser = ON_UPDATE
        txtUserName.Text = T_user.UserName
        DDLevel.Text = T_user.LevelUser
        GrpInputUser.Visible = True
    End Sub
    Private Sub DeleteUser(ByVal tuser As T_User)
        If AskShieldMesage(MSGAskDelete) = Windows.Forms.DialogResult.Yes Then
            Fnc.SetSaveT_user(tuser, ON_DELETE)
            InfoMessage(Fnc.MessageText)
            LoadDataListUser()
            GrpInputUser.Visible = False
        End If
    End Sub
    Private Sub ResetPasswordUser()
        If AskShieldMesage(MSGAskDelete) = Windows.Forms.DialogResult.Yes Then
            resetpassword()
        End If
    End Sub
    Private Sub GVUser_CommandCellClick(sender As Object, e As EventArgs) Handles GVuser.CommandCellClick
        Dim evenArgs As GridViewCellEventArgs = e
        Dim KdKategoy = GVuser.CurrentRow.Cells("UserName").Value
        Dim tuser = Fnc.GetSingleT_user(KdKategoy)
        If evenArgs.Column.Name = "Edit" Then
            EditUser(tuser)
        ElseIf evenArgs.Column.Name = "Reset" Then
            ResetPasswordUser()
        ElseIf evenArgs.Column.Name = "Delete" Then
            DeleteUser(tuser)
        End If
    End Sub

    Private Sub btnNewT_user_Click(sender As Object, e As EventArgs) Handles BtnNewUser.Click
        editModeTuser = CRUD.ON_SAVE
        GrpInputUser.Visible = True
        txtUserName.Enabled = True
        ClearAllRadControl(GrpInputUser)
    End Sub

    Private Sub Frm_UserManager_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataListUser()
    End Sub

    Private Sub btnCancelUser_Click(sender As Object, e As EventArgs) Handles btnCancelUser.Click
        GrpInputUser.Visible = False
    End Sub

    Private Sub FillDataToObject(ByVal tuser As T_User)
        With tuser
            .UserName = txtUserName.Text
            .LevelUser = DDLevel.Text
            If editModeTuser = ON_SAVE Then
                .PasswordUser = "mandiri"
            End If
            .IsStatus = 1
            If editModeTuser = ON_SAVE Then
                .TglInput = Now
            End If
            .TglUpdate = Now
            .UserInput = UserName
            .FormName = Name
        End With
    End Sub
    Private Sub SetStyleControlDefault()
        InfoMessage(Fnc.MessageText)
        ClearAllRadControl(GrpInputUser)
        LoadDataListUser()
        GrpInputUser.Visible = False
    End Sub
    Private Sub btnSaveUser_Click(sender As Object, e As EventArgs) Handles btnSaveUser.Click
        Try
            Dim tuser = Fnc.GetSingleT_user(txtUserName.Text)
            If Fnc.HasError = False And editModeTuser = ON_SAVE Then
                WarnMessage(MSGDataDuplicat)
                Exit Sub
            End If
            If ValidateInputControls() = False Then Exit Sub
            If tuser Is Nothing Then tuser = New T_User
            FillDataToObject(tuser)
            Fnc.SetSaveT_user(tuser, editModeTuser)
            SetStyleControlDefault()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try

    End Sub

    Sub resetpassword()
        Dim tuser = Fnc.GetSingleT_user(GVuser.CurrentRow.Cells("UserName").Value)
        tuser.PasswordUser = TextResetPassword
        Fnc.SetSaveT_user(tuser, BPRoc_LIB.CRUD.ON_UPDATE)
        SetStyleControlDefault()
    End Sub
End Class