Imports BPRoc_LIB
Imports SEMICO_Dialog.ClsMessage
Imports BPRoc_LIB.SharedFunction
Imports Telerik.WinControls.UI
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Setting
Imports System.Xml
Partial Class Frm_Setting
    Private editModekategori As CRUD

    Function ValidasiKategory() As Boolean
        Dim temp = True
        If AllAntiNullRad(GrpInputKategori) = False Then
            temp = False
            ShieldMessage(SharedFunction.ControlErrorName & _MSGmustHaveValue)
        End If
        Return temp
    End Function

    Private Sub BtnSaveKategory_Click(sender As Object, e As EventArgs) Handles BtnSaveKategory.Click
        Try
            Dim kategori = Fnc.GetSinglekategori(txtCodeKategori.Text)
            If editModekategori = CRUD.ON_SAVE Then
                kategori = New Kategori
            End If
            With kategori
                .FormName = Name
                .IsStatus = 1
                .KdKategori = txtCodeKategori.Text
                .Nama = txtNameKategori.Text
                If editModekategori = CRUD.ON_SAVE Then
                    .TglInput = Date.Today
                End If
                .TglUpdate = Date.Today
                .UserName = UserName
                Fnc.SetSaveKategori(kategori, editModekategori)
                InfoMessage(Fnc.MessageText)
                GrpInputKategori.Visible = False
                LoadDataKategori()
            End With
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub LoadDataKategori()
        GVKategori.DataSource = Fnc.GetListkategori
    End Sub

    Private Sub btnSaveKategori_Click(sender As Object, e As EventArgs)
        Try
            Dim kategori = Fnc.GetSinglekategori(txtCodeKategori.Text)
            If Fnc.HasError = False And editModekategori = CRUD.ON_SAVE Then
                WarnMessage(MSGDataDuplicat)
                Exit Sub
            End If

            If ValidasiKategory() = False Then
                Exit Sub
            End If
            With kategori
                .KdKategori = txtCodeKategori.Text
                .Nama = txtNameKategori.Text
                .IsStatus = 1
                If editModekategori = CRUD.ON_SAVE Then
                    .TglInput = Date.Today
                End If
                .TglUpdate = Date.Today
                .UserName = UserName
                .FormName = Name
            End With
            Fnc.SetSaveKategori(kategori, editModekategori)
            InfoMessage(Fnc.MessageText)
            ClearAllRadControl(GrpInputKategori)
            LoadDataKategori()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub
    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        GrpInputKategori.Visible = False
    End Sub
    Private Sub GVKategori_CommandCellClick(sender As Object, e As EventArgs) Handles GVKategori.CommandCellClick
        Try
            Dim x As Telerik.WinControls.UI.GridViewCellEventArgs = e
            Dim KdKategoy = GVKategori.CurrentRow.Cells("Code").Value
            Dim kategori = Fnc.GetSinglekategori(KdKategoy)
            If x.Column.Name = "Edit" Then
                txtCodeKategori.Enabled = False
                editModekategori = CRUD.ON_UPDATE
                BindAllControl(pnlInputkategoti, kategori)
                GrpInputKategori.Visible = True
            ElseIf x.Column.Name = "Delete" Then
                If AskShieldMesage(MSGAskDelete) = Windows.Forms.DialogResult.Yes Then
                    Fnc.SetSaveKategori(kategori, CRUD.ON_DELETE)
                    InfoMessage(Fnc.MessageText)
                    LoadDataKategori()
                End If
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnNewKategori_Click(sender As Object, e As EventArgs) Handles btnNewKategori.Click
        editModekategori = CRUD.ON_SAVE
        GrpInputKategori.Visible = True
        txtCodeKategori.Enabled = True
        ClearAllRadControl(GrpInputKategori)
    End Sub
End Class