Imports BPRoc_LIB.SharedFunction
Imports BPRoc_LIB
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsValidasi
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Setting
Imports BPRoc_LIB.CRUD
Imports SEMICO_Dialog.EnumModeButton

Public Class FRm_Supplier
    Dim EditMode As CRUD
    ReadOnly Fnc As New PublicFunction()
    Property userName As String

    Function ValidationInput() As Boolean
        If txtName.Text = "" Then
            ShieldMessage("Name  Must have value")
            Return False
        End If
        Return True
    End Function

    Private Sub FRm_Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStyleAllControlDefault()
    End Sub

    Private Sub SetStyleControlInsert()
        ClearAllRadControl(Me)
        EnableAllControl(Me, True)
        txtID.Enabled = False
        SetModeButtons(PnlCommand, added)
        txtName.Focus()
    End Sub

    Private Sub SetStyleAllControlEdited()
        EnableAllControl(Me, True)
        txtID.Enabled = False
        SetModeButtons(PnlCommand, edited)
    End Sub

    Private Sub SetStyleAllControlDefault()
        EnableAllControl(Me, False)
        ClearAllRadControl(Me)
        SetModeButtons(PnlCommand, normal)
        BtnAdd.Focus()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Try
            SetStyleControlInsert()
            txtID.Text = Fnc.GetGenerateKdSupplier
            EditMode = ON_SAVE
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub FillDataToObject(ByVal supplier As Supplier)
        With supplier
            .AlmtSup = txtAddress.Text
            .Kota = txtCity.Text
            .FaxSup = txtFax.Text
            .FormName = Name
            .HpSup = txtMobile.Text
            .KdSupplier = txtID.Text
            .Kota = txtCity.Text
            .NmSup = txtName.Text
            .IsStatus = "1"
            If EditMode = ON_SAVE Then
                .TglInput = Date.Today
            End If
            .TglUpdate = Date.Today
            .TlpSup = txtPhone.Text
            .UserName = Me.userName
        End With
    End Sub
    Private Function InitObject() As Supplier
        Dim supplier As New Supplier
        If EditMode = BPRoc_LIB.CRUD.ON_SAVE Then
            supplier = New Supplier()
        Else
            supplier = Fnc.GetSingleSupplier(txtID.Text)
        End If
        Return supplier
    End Function

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            If ValidationInput() = False Then Return
            Dim supplier = InitObject()
            FillDataToObject(supplier)
            Fnc.SetSaveSupplier(supplier, EditMode)
            InfoMessage(Fnc.MessageText)
            SetStyleAllControlDefault()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Dim supplier = Fnc.FindSupplier
            If Fnc.HasValue = False Then Exit Sub
            EditMode = CRUD.ON_UPDATE
            BindAllControl(Me, supplier)
            SetStyleAllControlEdited()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Try
            SetStyleAllControlDefault()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnDElete_Click(sender As Object, e As EventArgs) Handles BtnDElete.Click
        Try
            If AskMessage(MSGAskDelete) = Windows.Forms.DialogResult.No Then Exit Sub
            Dim suplier = Fnc.GetSingleSupplier(txtID.Text)
            suplier.UserName = userName
            Fnc.SetSaveSupplier(suplier, ON_DELETE)
            InfoMessage(Fnc.MessageText)
            SetStyleAllControlDefault()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub txtName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress, txtAddress.KeyPress, _
                                                                                                txtCity.KeyPress, txtFax.KeyPress, txtMobile.KeyPress, txtPhone.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            Windows.Forms.SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub FRm_Supplier_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAdd.Focus()
    End Sub
End Class