Imports BPRoc_LIB.SharedFunction
Imports BPRoc_LIB
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsValidasi
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.EnumModeButton
Imports System.Windows.Forms
Imports BPRoc_LIB.CRUD

Public Class Frm_Item

    ReadOnly Fnc As New PublicFunction()
    Dim EditMode As CRUD
    Public Property UserName As String = ""

    Private Sub ClearAll()
        ClearAllRadControl(Me)
        ClearAllRadControl(PageBarang)
        ClearAllRadControl(PnlCategory)
        ClearAllRadControl(PnlLocation)
        ClearAllRadControl(PnlSatuan1)
        ClearAllRadControl(pnlSatuan2)
        ClearAllRadControl(pnlSatuan3)
        ClearAllRadControl(pnlSatuan4)
        ClearAllRadControl(PageUnit1)
        ClearAllRadControl(PageUnit2)
        ClearAllRadControl(pageUnit3)
        ClearAllRadControl(pageUnit4)
    End Sub

    Sub alwaysDisableControl()
        txtID.Enabled = False
        txtKodeCategory.Enabled = False
        txtLocation.Enabled = False
        txtCodeUnit1.Enabled = False
        txtCodeUnit2.Enabled = False
        txtCodeUnit3.Enabled = False
        txtCodeUnit4.Enabled = False
    End Sub

    Private Sub EnabledAll(Optional sts = True)
        EnableAllControl(PageBarang, sts)
        EnableAllControl(PnlCategory, sts)
        EnableAllControl(PnlLocation, sts)
        EnableAllControl(PnlSatuan1, sts)
        EnableAllControl(pnlSatuan2, sts)
        EnableAllControl(pnlSatuan3, sts)
        EnableAllControl(pnlSatuan4, sts)
        alwaysDisableControl()
        txtFindBarcode.Enabled = True
    End Sub

    Private Sub ValidateUni1()
        If chkConfirmUnit1.Checked = False Then
            PageTab.SelectedPage = PageUnit1
            Throw New Exception("Unit 1" & MSGMUstConfirm)
        ElseIf AllAntiNullRad(PnlSatuan1) = False Then
            ShieldMessage(SharedFunction.ControlErrorName & _MSGmustHaveValue)
            PageTab.SelectedPage = PageUnit1
        ElseIf txtPricePurchase1.Value > txtPriceSelling1.Value Then
            PageTab.SelectedPage = PageUnit1
            txtPricePurchase1.Focus()
            Throw New Exception("Price Purchase on Unit 1 cannot exceed Price Selling")
        ElseIf (txtPriceSelling1.Value - txtPricePurchase1.Value) < 50 Then
            PageTab.SelectedPage = PageUnit1
            txtPriceSelling1.Focus()
            Throw New Exception("Price Selling must  minimum 50 than Purchase")
        End If
    End Sub

    Private Sub ValidateUnit2()
        If chkConfirmUnit2.Checked = False Then
            PageTab.SelectedPage = PageUnit2
            Throw New Exception("Unit 2" & MSGMUstConfirm)
        ElseIf txtCodeUnit2.Text <> "" And txtpar2.Value <= 1 Then
            PageTab.SelectedPage = PageUnit2
            txtpar2.Focus()
            Throw New Exception("par unit 2 must exceed par unit 1")
        ElseIf txtCodeUnit2.Text <> "" And txtPricePurchase2.Value > txtPriceSelling2.Value Then
            PageTab.SelectedPage = PageUnit2
            txtPricePurchase2.Focus()
            Throw New Exception("Price Purchase on Unit 2 cannot exceed Price Selling")
        ElseIf (txtPriceSelling2.Value - txtPricePurchase2.Value) < 50 Then
            PageTab.SelectedPage = PageUnit2
            txtPriceSelling2.Focus()
            Throw New Exception("Price Selling 2 must  minimum 50 than Purchase 2")
        End If
    End Sub

    Private Sub ValidateUnit3()
        If ChkconfimUnit3.Checked = False Then
            PageTab.SelectedPage = pageUnit3
            Throw New Exception("Unit 3" & MSGMUstConfirm)
        ElseIf txtCodeUnit3.Text <> "" And txtPar3.Value <= txtpar2.Value Then
            PageTab.SelectedPage = pageUnit3
            txtpar1.Focus()
            Throw New Exception("par unit 3 must exceed par unit 2")
        ElseIf txtCodeUnit3.Text <> "" And txtPricePurchase3.Value > txtPriceSelling3.Value Then
            PageTab.SelectedPage = pageUnit3
            txtPricePurchase3.Focus()
            Throw New Exception("Price Purchase cannot exceed Price Selling on Unit 3 ")
        ElseIf (txtPriceSelling3.Value - txtPricePurchase3.Value) < 50 Then
            PageTab.SelectedPage = pageUnit3
            txtPriceSelling3.Focus()
            Throw New Exception("Price Selling 3 must  minimum 50 than Purchase 3")
        End If
    End Sub

    Private Sub ValidateUnit4()
        If chkConfirmUnit4.Checked = False Then
            PageTab.SelectedPage = pageUnit4
            Throw New Exception("Unit 4" & MSGMUstConfirm)
        ElseIf txtCodeUnit4.Text <> "" And txtPar4.Value <= txtPar3.Value Then
            PageTab.SelectedPage = pageUnit4
            txtPar4.Focus()
            Throw New Exception("par unit 4 must exceed par unit 3")
        ElseIf txtCodeUnit4.Text <> "" And txtPricePurchase4.Value > txtPriceSelling4.Value Then
            PageTab.SelectedPage = pageUnit4
            txtPricePurchase4.Focus()
            Throw New Exception("Price Purchase cannot exceed Price Selling on Unit 4")
        ElseIf (txtPriceSelling4.Value - txtPricePurchase4.Value) < 50 Then
            PageTab.SelectedPage = pageUnit4
            txtPriceSelling4.Focus()
            Throw New Exception("Price Selling 4 must  minimum 50 than Purchase 4")
        End If
    End Sub
    ''' <summary>
    ''' Hanya digunakan untuk header barang bukan untuk satuan
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ThrowErrorPages()
        PageTab.SelectedPage = PageBarang
        Throw New Exception(SharedFunction.ControlErrorName & _MSGmustHaveValue)
    End Sub
    Sub ValidationInput()
        If AllAntiNullRad(PageBarang) = False Then ThrowErrorPages()
        If AllAntiNullRad(PnlCategory) = False Then ThrowErrorPages()
        If AllAntiNullRad(PnlLocation) = False Then ThrowErrorPages()
        If txtCodeUnit1.Text <> "" Then ValidateUni1()
        If txtCodeUnit2.Text <> "" Then ValidateUnit2()
        If txtCodeUnit3.Text <> "" Then ValidateUnit3()
        If txtCodeUnit4.Text <> "" Then ValidateUnit4()
    End Sub

    Private Sub FillObjectBarang(ByRef barang As Barang)
        If barang Is Nothing Then barang = New Barang
        With barang
            .KdBarang = txtID.Text
            .Nama = txtName.Text
            .Lokasi = txtLocation.Text
            .KdKategori = txtKodeCategory.Text
            .UserName = Me.UserName
            .TglInput = Now
            .TglUpdate = Now
            .FormName = Me.Name
            .IsStatus = True
            If EditMode = ON_SAVE Then
                .TglInput = Now
            End If
        End With
    End Sub

    Private Sub FillObjectUnit1(ByVal barang As Barang)
        Dim satuanDet As New SatuanDet
        If EditMode = CRUD.ON_UPDATE Then
            satuanDet = Fnc.GetSingleSatuanDet(txtID.Text, txtCodeUnit1.Text)
        End If
        If satuanDet Is Nothing Then satuanDet = New SatuanDet
        With satuanDet
            .Kdbarang = txtID.Text
            .HargaBeli = txtPricePurchase1.Value
            .HargaJual = txtPriceSelling1.Value
            .IsStatus = True
            .Par = txtpar1.Value
            .KdSatuan = txtCodeUnit1.Text
            .Barcode = txtBarcode1.Text
            .FormName = Me.Name
            .Username = Me.UserName
            .TglUpdate = Now
            If EditMode = CRUD.ON_SAVE Then
                .TglInput = Now
            End If
        End With
        barang.SatuanDets.Add(satuanDet)
    End Sub

    Private Sub FillObjectUnit2(ByVal barang As Barang)
        Dim satuanDet As New SatuanDet
        If EditMode = CRUD.ON_UPDATE Then
            satuanDet = Fnc.GetSingleSatuanDet(txtID.Text, txtCodeUnit2.Text)
        End If
        If satuanDet Is Nothing Then satuanDet = New SatuanDet
        With satuanDet
            .Kdbarang = txtID.Text
            .HargaBeli = txtPricePurchase2.Value
            .HargaJual = txtPriceSelling2.Value
            .IsStatus = True
            .Par = txtpar2.Value
            .KdSatuan = txtCodeUnit2.Text
            .Barcode = txtBarcode2.Text
            .FormName = Me.Name
            .Username = Me.UserName
            .TglUpdate = Now
            If EditMode = CRUD.ON_SAVE Then
                .TglInput = Now
            End If
        End With
        barang.SatuanDets.Add(satuanDet)
    End Sub

    Private Sub FillObjectUnit3(ByVal barang As Barang)
        Dim satuanDet As New SatuanDet
        If EditMode = CRUD.ON_UPDATE Then
            satuanDet = Fnc.GetSingleSatuanDet(txtID.Text, txtCodeUnit3.Text)
        End If
        If satuanDet Is Nothing Then satuanDet = New SatuanDet
        With satuanDet
            .Kdbarang = txtID.Text
            .HargaBeli = txtPricePurchase3.Value
            .HargaJual = txtPriceSelling3.Value
            .IsStatus = True
            .Par = txtPar3.Value
            .KdSatuan = txtCodeUnit3.Text
            .Barcode = txtBarcode3.Text
            .FormName = Me.Name
            .Username = Me.UserName
            .TglUpdate = Now
            If EditMode = CRUD.ON_SAVE Then
                .TglInput = Now
            End If
        End With
        barang.SatuanDets.Add(satuanDet)
    End Sub

    Private Sub FillObjectUnit4(ByVal barang As Barang)
        Dim satuanDet As New SatuanDet
        If EditMode = CRUD.ON_UPDATE Then
            satuanDet = Fnc.GetSingleSatuanDet(txtID.Text, txtCodeUnit4.Text)
        End If
        If satuanDet Is Nothing Then satuanDet = New SatuanDet
        With satuanDet
            .Kdbarang = txtID.Text
            .HargaBeli = txtPricePurchase4.Value
            .HargaJual = txtPriceSelling4.Value
            .IsStatus = True
            .Par = txtPar4.Value
            .KdSatuan = txtCodeUnit4.Text
            .Barcode = txtBarcode4.Text
            .FormName = Me.Name
            .Username = Me.UserName
            .TglUpdate = Now
            If EditMode = CRUD.ON_SAVE Then
                .TglInput = Now
            End If
        End With
        barang.SatuanDets.Add(satuanDet)
    End Sub

    Private Sub SetStyleControlNormal()
        EnabledAll(False)
        ClearAll()
        PageTab.SelectedPage = PageBarang
        SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.normal)
    End Sub

    Private Function InitBarang() As Barang
        Dim barang As New Barang
        If EditMode = CRUD.ON_UPDATE Then
            barang = Fnc.GetSingleBarang(txtID.Text)
        ElseIf EditMode = CRUD.ON_SAVE Then
            txtID.Text = Fnc.GetGenerateKdBarang
        End If
        Return barang
    End Function

    Private Sub BindPageDataToControl(ByVal barang As Barang)
        BindAllControl(PageBarang, barang)
        BindAllControl(PnlLocation, barang)
        BindAllControl(PnlCategory, barang)
    End Sub
    Private Sub BindDataUnitToControls(ByVal LsatuanDEt As List(Of SatuanDet))
        If LsatuanDEt.Count > 0 Then BindAllControl(PnlSatuan1, LsatuanDEt(0))
        If LsatuanDEt.Count > 1 Then BindAllControl(pnlSatuan2, LsatuanDEt(1))
        If LsatuanDEt.Count > 2 Then
            BindAllControl(pnlSatuan3, LsatuanDEt(2))
            EditMode = CRUD.ON_UPDATE
        End If
        If LsatuanDEt.Count > 3 Then BindAllControl(pnlSatuan4, LsatuanDEt(3))
    End Sub
    Private Sub BindForm(ByVal barang As Barang)
        BindPageDataToControl(barang)
        Dim LsatuanDEt = Fnc.GetListSatuanDet("kdbarang=" & CSQL(barang.KdBarang))
        If LsatuanDEt Is Nothing Then Throw New Exception("No Unit Found")
        If LsatuanDEt.Count = 0 Then Throw New Exception("No Unit Found")
        BindDataUnitToControls(LsatuanDEt)
        EditMode = CRUD.ON_UPDATE
        EnabledAll()
        SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.edited)
        PageTab.SelectedPage = PageBarang
    End Sub

    Private Sub Frm_Item_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtFindBarcode.Focus()
    End Sub

    Private Sub FRm_Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PageTab.SelectedPage = PageBarang
        SetStyleControlNormal()
    End Sub

    Private Sub SetStyleControlAdd()
        ClearAll()
        EnabledAll()
        SetModeButtons(PnlCommand, added)
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        SetStyleControlAdd()
        EditMode = ON_SAVE
        txtID.Text = Fnc.GetGenerateKdBarang
        txtID.Enabled = False
        txtpar1.Value = 1
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            ValidationInput()
            Dim barang = InitBarang()
            FillObjectBarang(barang)
            If txtCodeUnit1.Text = "" Then
                PageTab.SelectedPage = PageUnit1
                Throw New Exception("Item must have Unit")
            End If
            FillObjectUnit1(barang)
            If txtCodeUnit2.Text <> "" Then FillObjectUnit2(barang)
            If txtCodeUnit3.Text <> "" Then FillObjectUnit3(barang)
            If txtCodeUnit4.Text <> "" Then FillObjectUnit4(barang)
            Fnc.SetSaveBarang(barang, EditMode)
            InfoMessage(Fnc.MessageText)
            SetStyleControlNormal()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Dim barang = Fnc.FindBarang
            If Fnc.HasValue = False Then Exit Sub
            BindForm(barang)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        SetStyleControlNormal()
    End Sub

    Private Sub BtnDElete_Click(sender As Object, e As EventArgs) Handles BtnDElete.Click
        Try
            Dim barang = Fnc.GetSingleBarang(txtID.Text)
            If AskMessage(MSGAskDelete) = DialogResult.No Then Exit Sub
            Fnc.SetSaveBarang(barang, ON_DELETE)
            InfoMessage(Fnc.MessageText)
            SetStyleControlNormal()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnFindCategory_Click(sender As Object, e As EventArgs) Handles BtnFindCategory.Click
        Dim kategori = Fnc.Findkategori()
        If Fnc.HasValue = False Then Exit Sub
        BindAllControl(PnlCategory, kategori)
    End Sub

    Private Sub BtnFindUnit_Click(sender As Object, e As EventArgs) Handles BtnFindUnit1.Click
        Dim satuan = Fnc.FindSatuan
        If Fnc.HasValue = False Then Exit Sub
        BindAllControl(PnlSatuan1, satuan)
    End Sub

    Private Sub BtnFindModel_Click(sender As Object, e As EventArgs) Handles BtnFindModel.Click
        txtLocation.Text = Fnc.FindLokasiBarang()
    End Sub

    Private Sub btnFindUnit2_Click(sender As Object, e As EventArgs) Handles btnFindUnit2.Click
        Dim satuan = Fnc.FindSatuan
        If Fnc.HasValue = False Then Exit Sub
        BindAllControl(pnlSatuan2, satuan)
    End Sub

    Private Sub btnfindunit3_Click(sender As Object, e As EventArgs) Handles btnfindunit3.Click
        Dim satuan = Fnc.FindSatuan
        If Fnc.HasValue = False Then Exit Sub
        BindAllControl(pnlSatuan3, satuan)
    End Sub

    Private Sub btnFindUnit4_Click(sender As Object, e As EventArgs) Handles btnFindUnit4.Click
        Dim satuan = Fnc.FindSatuan
        If Fnc.HasValue = False Then Exit Sub
        BindAllControl(pnlSatuan4, satuan)
    End Sub

    Private Sub txtBarcode1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode1.KeyPress, txtBarcode2.KeyPress, txtBarcode3.KeyPress, txtBarcode4.KeyPress
        SharedFunction.InputOnlyNumeric(e)
    End Sub

    Private Sub txtFindBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFindBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim barang = Fnc.GetSingleBarangByBarcode(txtFindBarcode.Text)
                If Fnc.HasError = False Then
                    BindForm(barang)
                Else
                    WarnMessage(Fnc.MessageText)
                End If
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub txtFindBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtFindBarcode.TextChanged
        If txtFindBarcode.Text.Length >= 12 Or Not IsNumeric(txtFindBarcode.Text) Then
            Dim barang = Fnc.GetSingleBarangByBarcode(txtFindBarcode.Text)
            If Fnc.HasError = False Then
                BindForm(barang)
            Else
                WarnMessage(Fnc.MessageText)
            End If
            Return
        End If
    End Sub

    Private Sub txtpar2_ValueChanged(sender As Object, e As EventArgs) Handles txtpar2.ValueChanged
        txtPriceSelling2.Value = txtPriceSelling1.Value * txtpar2.Value
        txtPricePurchase2.Value = txtPricePurchase1.Value * txtpar2.Value
    End Sub

    Private Sub txtPar3_ValueChanged(sender As Object, e As EventArgs) Handles txtPar3.ValueChanged
        txtPriceSelling3.Value = txtPriceSelling1.Value * txtPar3.Value
        txtPricePurchase3.Value = txtPricePurchase1.Value * txtPar3.Value
    End Sub

    Private Sub txtPar4_ValueChanged(sender As Object, e As EventArgs) Handles txtPar4.ValueChanged
        txtPriceSelling4.Value = txtPriceSelling1.Value * txtPar4.Value
        txtPricePurchase4.Value = txtPricePurchase1.Value * txtPar4.Value
    End Sub

    Private Sub btnDeleteUnit2_Click(sender As Object, e As EventArgs) Handles btnDeleteUnit2.Click
        ClearAllRadControl(pnlSatuan2)
    End Sub

    Private Sub btnDeleteunit3_Click(sender As Object, e As EventArgs) Handles btnDeleteunit3.Click
        ClearAllRadControl(pnlSatuan3)
    End Sub

    Private Sub btnDEleteUnit4_Click(sender As Object, e As EventArgs) Handles btnDEleteUnit4.Click
        ClearAllRadControl(pnlSatuan3)
    End Sub

    Private Sub btnCalculator_Click(sender As Object, e As EventArgs) Handles btnCalculator.Click
        Using appCaller As New Process() With {.StartInfo = New ProcessStartInfo("calc")}
            appCaller.Start()
        End Using
    End Sub
End Class