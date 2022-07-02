Imports BPRoc_LIB
Imports SEMICO_Dialog.ClsMessage
Imports BPRoc_LIB.SharedFunction
Imports Telerik.WinControls.UI
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Setting
Imports System.Xml
Partial Class Frm_Setting
    Private editModeOwner As CRUD
    Sub LoadOwner()
        Dim Owner = Fnc.GetSingleOwner
        If Fnc.HasError = False Then
            BindAllControl(pageOwner, Owner)
            editModeOwner = CRUD.ON_UPDATE
        Else
            editModeOwner = CRUD.ON_SAVE
        End If
    End Sub

    Private Sub btnSaveOwner_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveOwner.Click
        Dim Own As T_Owner
        If editModeOwner = CRUD.ON_UPDATE Then
            Own = Fnc.GetSingleOwner()
        Else
            Own = New T_Owner()
        End If
        SetOwner(Own)
        Fnc.SetSaveOwner(Own, editModeOwner)
        If Fnc.HasError = False Then
            InfoMessage(Fnc.MessageText)
        Else
            WarnMessage(Fnc.MessageText)
        End If
    End Sub

    Private Sub SetOwner(owner As T_Owner)
        With owner
            .Nama = TxtOwnerName.Text
            .Alamat = txtOwnerAddress.Text
            .Telepon = txtOwnerPhone.Text
            .Mobile = txtOwnerMobile.Text
            .Fax = txtOwnerFax.Text
            .EMail = txtOwnerEmail.Text
            .NoRegister = txtOwnerNoRegister.Text
            .UserName = UserName
            If editModeOwner = CRUD.ON_SAVE Then
                .TglInput = Date.Today
            End If
            .TglUpdate = Date.Today
            .IsStatus = True
            .NamaToko = txtOwnserStorename.Text
        End With
    End Sub

End Class