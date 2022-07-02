Imports BPRoc_LIB
Imports SEMICO_Dialog.ClsMessage
Imports BPRoc_LIB.SharedFunction
Imports Telerik.WinControls.UI
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Setting
Imports System.Xml
Partial Class Frm_Setting
    Private editModeunit As CRUD

    Function Validasiunit() As Boolean
        Dim temp = True
        If AllAntiNullRad(GrpInputUnit) = False Then
            temp = False
            ShieldMessage(SharedFunction.ControlErrorName & _MSGmustHaveValue)
        End If
        Return temp
    End Function

    Private Sub LoadDataunit()
        GVunit.DataSource = Fnc.GetListSatuan
    End Sub

    Private Sub btnSaveunit_Click(sender As Object, e As EventArgs) Handles btnSaveunit.Click
        Try
            Dim unit As Satuan = Fnc.GetSingleSatuan(txtkodeUnit.Text)
            If Validasiunit() = False Then
                Exit Sub
            End If
            If Fnc.HasError = False And editModeunit = CRUD.ON_SAVE Then
                WarnMessage(MSGDataDuplicat)
                Exit Sub
            End If
            With unit
                .KdSatuan = txtkodeUnit.Text
                .Nama = txtNameUnit.Text
                .IsStatus = 1
                If editModeunit = CRUD.ON_SAVE Then
                    .TglInput = Date.Today
                End If
                .TglUpdate = Date.Today
                .UserName = UserName
                .FormName = Name
            End With
            Fnc.SetSaveSatuan(unit, editModeunit)
            InfoMessage(Fnc.MessageText)
            GrpInputUnit.Visible = False
            ClearAllRadControl(GrpInputUnit)
            LoadDataunit()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnCancelUnit_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelUnit.Click
        GrpInputUnit.Visible = False
    End Sub
    Private Sub GVunit_CommandCellClick(sender As Object, e As EventArgs) Handles GVunit.CommandCellClick
        Try
            Dim x As Telerik.WinControls.UI.GridViewCellEventArgs = e
            Dim KdSatuan = GVunit.CurrentRow.Cells("Code").Value
            Dim unit = Fnc.GetSingleSatuan(KdSatuan)
            If x.Column.Name = "Edit" Then
                txtkodeUnit.Enabled = False
                editModeunit = CRUD.ON_UPDATE
                BindAllControl(pnlInputUnit, unit)
                GrpInputUnit.Visible = True
            ElseIf x.Column.Name = "Delete" Then
                If AskShieldMesage(MSGAskDelete) = Windows.Forms.DialogResult.Yes Then
                    Fnc.SetSaveSatuan(unit, CRUD.ON_DELETE)
                    InfoMessage(Fnc.MessageText)
                    LoadDataunit()
                End If
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try

    End Sub

    Private Sub btnNewunit_Click(sender As Object, e As EventArgs) Handles BtnNewUnit.Click
        editModeunit = CRUD.ON_SAVE
        GrpInputUnit.Visible = True
        txtkodeUnit.Enabled = True
        ClearAllRadControl(GrpInputUnit)
    End Sub
End Class