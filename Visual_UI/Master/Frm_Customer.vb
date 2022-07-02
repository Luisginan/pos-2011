Imports BPRoc_LIB
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.SharedFunction
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsValidasi
Imports BPRoc_LIB.Setting
Public Class Frm_Customer
    Dim EditMode As CRUD
    Dim Fnc As New PublicFunction()
    Public Property UserName As String = ""

    Function ValidationInput() As Boolean
        Dim temp As Boolean = True
        If TxtName.Text = "" Then
            ShieldMessage("name Must have value")
            temp = False
        End If
        Return temp
    End Function
    Sub alwaysDisableControl()
        txtID.Enabled = False
    End Sub
    Private Sub Frm_Customer_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        BtnAdd.Focus()
    End Sub
    Private Sub FRm_Custommer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            EnableAllControl(Me, False)
            ClearAllRadControl(Me)
            SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.normal)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Try
            EditMode = CRUD.ON_SAVE
            ClearAllRadControl(Me)
            alwaysDisableControl()
            EnableAllControl(Me, True)
            txtID.Enabled = False
            txtID.Text = Fnc.GetGenerateKdPelanggan
            SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.added)
            TxtName.Focus()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub SetCustomer(ByVal Customer As Pelanggan)
        With Customer
            .Almtplgn = txtAddress.Text
            .Kotaplgn = TxtCity.Text
            .Faxplgn = txtFax.Text
            .FormName = Name
            .Hpplgn = txtMobile.Text
            .Kotaplgn = TxtCity.Text
            .Nmplgn = TxtName.Text
            .IsStatus = 1
            If EditMode = CRUD.ON_SAVE Then
                .Kdplgn = Fnc.GetGenerateKdPelanggan
                .TglInput = Date.Today
            End If
            .TglUpdate = Date.Today
            .Telpplgn = txtPhone.Text
            .UserName = UserName
        End With
    End Sub
    Private Sub SetControllSaveClick()
        EnableAllControl(Me, False)
        ClearAllRadControl(Me)
        SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.normal)
        BtnAdd.Focus()
    End Sub
    Private Function InitCustomer() As Pelanggan
        Dim Customer As New Pelanggan
        If EditMode = CRUD.ON_SAVE Then
            Customer = New Pelanggan()
        Else
            Customer = Fnc.GetSinglePelanggan(txtID.Text)
        End If
        Return Customer
    End Function
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            If ValidationInput() = False Then Exit Sub
            Dim Customer As Pelanggan = InitCustomer()
            SetCustomer(Customer)
            Fnc.SetSavePelanggan(Customer, EditMode)
            InfoMessage(Fnc.MessageText)
            SetControllSaveClick()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub SetControllFindClick(ByVal Customer As Pelanggan)
        BindAllControl(Me, Customer)
        EditMode = CRUD.ON_UPDATE
        EnableAllControl(Me, True)
        SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.edited)
    End Sub
    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Dim Customer = Fnc.FindPelanggan
            If Fnc.HasValue = False Then Exit Sub
            SetControllFindClick(Customer)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Try
            EnableAllControl(Me, False)
            SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.normal)
            ClearAllRadControl(Me)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnDElete_Click(sender As Object, e As EventArgs) Handles BtnDElete.Click
        Try
            If AskMessage(MSGAskDelete) = Windows.Forms.DialogResult.No Then Exit Sub
            Dim Customer = Fnc.GetSinglePelanggan(txtID.Text)
            Customer.UserName = UserName
            Fnc.SetSavePelanggan(Customer, CRUD.ON_DELETE)
            InfoMessage(Fnc.MessageText)
            EnableAllControl(Me, False)
            ClearAllRadControl(Me)
            SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.normal)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress, txtAddress.KeyPress, TxtCity.KeyPress, txtFax.KeyPress, txtMobile.KeyPress, txtPhone.KeyPress
        Try
            If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
                Windows.Forms.SendKeys.Send("{TAB}")
                e.Handled = True
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub
End Class