Imports BPRoc_LIB
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Setting
Imports BPRoc_LIB.SharedFunction
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsQueryBuilder
Imports SEMICO_Dialog.ClsValidasi
Imports System.Windows.Forms
Imports BPRoc_LIB.CRUD
Imports BPRoc_LIB.BARCODE_MODE
Imports BPRoc_LIB.CASHIER_MODE
Imports System.Text

Public Class Frm_Cashier

    Private Penjualan As New Penjualan()
    Private ReadOnly Fnc As New PublicFunction()
    Private EditMOde As New CRUD
    Private currentQTY As Integer = 0
    Private GVFullSeize As Boolean = True
    Property ModePenjualan As CASHIER_MODE = ON_DEFAULT
    Public Property UserName As String = ""
    Public Property IndexItem As Int16 = 0
    Public Property BarcodeMode As BARCODE_MODE = ON_NORMAL
    ''' <summary>
    ''' Mengecek apakah barang yang dipilih ada di grid atau tidak
    ''' </summary>
    ''' <returns>False berarti ada, True berarti tidak ada</returns>
    ''' <remarks></remarks>
    Function CheckDetIsNotExist() As Boolean
        Dim DetailPenjualans = From penjualanDet In Penjualan.PenjualanDets _
                               Where penjualanDet.KdBarang = TempSatuanDet.Kdbarang And penjualanDet.Kdsatuan = TempSatuanDet.KdSatuan _
                               Select penjualanDet
        If DetailPenjualans.Count > 0 Then Return False
        Return True
    End Function

    Private Sub ClearAll()
        ClearAllRadControl(Me)
        ClearAllRadControl(pnlHeader)
        ClearAllRadControl(pnlKet)
        lblHarga.Text = ""
        lblNoTransaction.Text = ""
        lblTotalItem.Text = ""
        IndexItem = 0
        lblCustomer.Text = ""
    End Sub

    Private Sub InsertItemsToGrid()
        GVITem.DataSource = Nothing
        Dim tempPenjualanDets = Penjualan.PenjualanDets.OrderByDescending(Function(c) c.nomor).ToList
        Penjualan.PenjualanDets.Clear()
        For Each penjDet In tempPenjualanDets
            Penjualan.PenjualanDets.Add(penjDet)
        Next
        GVITem.DataSource = Penjualan.PenjualanDets
        GetTotalBayarItem()
    End Sub

    ''' <summary>
    ''' Menghapus detail yang duplikat
    ''' </summary>
    ''' <param name="item">Penjualan det yang akan dijadikan pembanding saat dihapus </param>
    ''' <remarks></remarks>
    Private Sub RemoveDuplicateItemsOnGrid(ByVal item As PenjualanDet)
        Dim itemFromGrid = Penjualan.PenjualanDets.Where(Function(c) c.KdBarang = item.KdBarang And c.Kdsatuan = item.Kdsatuan).SingleOrDefault
        If IsNothing(itemFromGrid) <> False Then Return
        item.Qty += itemFromGrid.Qty
        Penjualan.PenjualanDets.Remove(itemFromGrid)
    End Sub

    Private Sub ImplementToGrid(ByVal InputITem As Frm_InputItem)
        If ChkClasicMode.Checked = False Then 'Dialog tidak ditampilkan
            InputITem.GetLoadDetailItem()
        Else
            InputITem.ShowDialog()
        End If
        If InputITem.HasValue Then
            Dim iput = InputITem.Value
            RemoveDuplicateItemsOnGrid(iput)
            IndexItem += 1
            iput.nomor = IndexItem
            Penjualan.PenjualanDets.Add(iput)
            InsertItemsToGrid()
            txtBarcode.Text = ""
            currentQTY = 1
            InputITem.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' Memanggil fungsi atau dialog(Clasic mode) untuk memproses  item, dan memasukan ke grid
    ''' </summary>
    ''' <param name="Qty"> Quantity dari semua item dari satuan terkecil</param>
    ''' <remarks></remarks>
    Private Sub CallInputDialog(Qty As Integer)
        Try
            Dim barang = Fnc.GetSingleBarang(TempSatuanDet.Kdbarang)
            If Fnc.HasError = True Then Throw New Exception(MSGNoData)
            Using InputITem As New Frm_InputItem() With {.InputValueBarang = barang, .ClasicMode = ChkClasicMode.Checked, _
                                                         .QTY = Qty, .UserName = UserName}
                ImplementToGrid(InputITem)
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Sub ModifyPenjualanDet(penjulandet As PenjualanDet, menu As TRANSACTION_MODE)
        Dim tempIndexItem = penjulandet.nomor
        Using InputITem As New Frm_InputItem() With {.InputValuePenjualanDet = penjulandet, .MenuDialog = menu}
            InputITem.ShowDialog()
            If InputITem.HasValue Then
                Penjualan.PenjualanDets.RemoveAt(GVITem.CurrentRow.Index)
                Dim iput = InputITem.Value
                RemoveDuplicateItemsOnGrid(iput)
                iput.nomor = tempIndexItem
                Penjualan.PenjualanDets.Add(iput)
                InsertItemsToGrid()
            End If
        End Using
    End Sub
    ''' <summary>
    ''' Untuk mengisi Form dengan data penjualan
    ''' Biasanya digunakan load data untuk Update
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindControlWithDataFromDB()
        Dim penjuDets = Fnc.GetListPenjualanDet("kdFakturPenj=" & CSQL(Penjualan.KdFakturPenj))
        For Each penjDet In penjuDets
            Penjualan.PenjualanDets.Add(penjDet)
        Next
        lblNoTransaction.Text = String.Format("{0}>>{1}>>{2}", Penjualan.KdFakturPenj, Penjualan.TglJual.ToShortDateString, Penjualan.TglJual.ToShortTimeString)
        InsertItemsToGrid()
        EnabledAll(True)
        EditMOde = CRUD.ON_UPDATE
        SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.edited)
    End Sub

    Function GetTotalBayarItem() As Double
        Dim Totalbayar As Double = 0
        Try
            If Penjualan.PenjualanDets.Count > 0 Then
                For Each penjDet In Penjualan.PenjualanDets
                    Totalbayar += penjDet.Total
                Next
                lblHarga.Text = "Total Price : " & FormatMoney(Totalbayar)
                lblTotalItem.Text = "Total Item : " & Penjualan.PenjualanDets.Count
            Else
                lblHarga.Text = "Total Price : " & 0
                lblTotalItem.Text = "Total Item : " & 0
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
        Return Totalbayar
    End Function
    Private Sub DeleteItem()
        If Penjualan.PenjualanDets.Count = 0 Then Exit Sub
        GetTotalBayarItem()
        If AskMessage(MSGAskDeleteItem) <> DialogResult.Yes Then Return
        Penjualan.PenjualanDets.RemoveAt(GVITem.CurrentRow.Index)
        InsertItemsToGrid()
    End Sub
    ''' <summary>
    ''' count quantity on the grid
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MergeQTYDet() As Integer
        Dim Kdbarang As String = TempSatuanDet.Kdbarang
        Dim kdsatuan As String = TempSatuanDet.KdSatuan
        Dim L = (From i In Penjualan.PenjualanDets _
                    Where i.KdBarang = Kdbarang And i.Kdsatuan = kdsatuan _
                    Select i).SingleOrDefault
        Dim qty = currentQTY + (L.Qty * TempSatuanDet.Par) 'jumlah qty yang lama dalam hitungan terkecil
        Penjualan.PenjualanDets.Remove(L)
        Return qty
    End Function
    ''' <summary>
    ''' Menghitung Quantity tunggal yang tidak ada
    ''' item yg sama di grid
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CountQTYDet() As Integer
        Dim qty As Integer
        If TempSatuanDet.Par <> 1 Then
            qty = TempSatuanDet.Par * CDec(currentQTY)
        Else
            qty = currentQTY
        End If
        Return qty
    End Function
    ''' <summary>
    ''' 'Handle barcode scaner yang lebih karakter 0 dari printernya,
    ''' Hati2 Karena banyak barcode asli yg depannya 0
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NormalizeBarcodeDet(ByRef barcode As String)
        Dim satuandet = Fnc.GetSingleSatuanDet(barcode)
        If satuandet Is Nothing Then
            If Microsoft.VisualBasic.Left(barcode, 1) = "0" Then
                barcode = Mid(barcode, 2, Len(barcode) - 1)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Hanya digunakan di function [AddItem] dan sub functionnya
    ''' </summary>
    ''' <remarks></remarks>
    Private TempSatuanDet As SatuanDet = Nothing
    Private Sub AddItem(barcode As String)
        Dim qty = 0
        NormalizeBarcodeDet(barcode)
        TempSatuanDet = Fnc.GetSingleSatuanDet(barcode)
        If TempSatuanDet Is Nothing Then Throw New Exception(MSGNoData)
        If CheckDetIsNotExist() = False Then
            qty = MergeQTYDet()
        Else
            qty = CountQTYDet()
        End If
        CallInputDialog(qty)
        TempSatuanDet = Nothing
    End Sub
    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Try
            If IsNumeric(txtBarcode.Text) = False Then Throw New Exception("Make sure Barcode is Correct")
            AddItem(txtBarcode.Text)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Shared Sub ShowMeHelpCommand()
        Dim TipsCommand As New StringBuilder
        With TipsCommand
            .AppendLine("Press [Space] for find barang")
            .AppendLine("Press [UP] or [DOWN] for navigation items")
            .AppendLine("Press [Delete] For delete item")
            .AppendLine("Press [Right] for change price item")
            .AppendLine("Press [Left] for Change quantity and price item")
            .AppendLine("Press [Page Up] for Find Customer")
            .AppendLine("Press [Back] for Insert quantity")
            .AppendLine("Press [Insert] for switch to Clasic Mode")
            .AppendLine("Press [Pause] for switch  to suspend mode")
            .AppendLine("Press [End] for finishing transaction")
            .AppendLine("Press [Print] for print transaction")
            .AppendLine("Press [Escape] for cancel transaction")
            .AppendLine("Press [Enter] for process barcode")
            .AppendLine("Press [F1] for Help")
            InfoMessage(.ToString)
        End With
    End Sub
    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        On Error Resume Next
        If BtnAdd.Enabled = True Then Exit Sub
        If e.KeyCode = Keys.Space Then
            Dim barang = Fnc.FindBarang
            Dim satuanDet = Fnc.GetListSatuanDet(String.Format("kdbarang = {0}  and  barcode is not null ", CSQL(barang.KdBarang)))(0)
            If Fnc.HasError = False And Fnc.HasValue Then
                AddItem(satuanDet.Barcode)
            End If
        ElseIf e.KeyCode = Keys.PageUp Then
            Dim Customer = Fnc.FindPelanggan
            If Fnc.HasValue = False Then Exit Sub
            If Customer.Nmplgn.Length > 10 Then
                lblCustomer.Text = "Customer: " + Customer.Nmplgn.Substring(0, 10)
            Else '
                lblCustomer.Text = "Customer: " + Customer.Nmplgn
            End If
            lblCustomer.Tag = Customer.Nmplgn
        ElseIf e.KeyCode = Keys.PageDown Then
            lblCustomer.Text = ""
            lblCustomer.Tag = ""
        ElseIf e.KeyCode = Keys.Enter Then
            btnAddItem.PerformClick()
            txtBarcode.Text = ""
        ElseIf e.KeyCode = Keys.Back Then
            Dim qty = InputBox("Input Qty :")
            currentQTY = qty
        ElseIf e.KeyCode = Keys.Insert Then
            ChkClasicMode.Checked = IIf(ChkClasicMode.Checked = True, False, True)
        ElseIf e.KeyCode = Keys.Escape Then
            BtnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.Delete Then
            DeleteItem()
        ElseIf e.KeyCode = Keys.Left Then
            If Penjualan.PenjualanDets.Count = 0 Then Exit Sub
            Dim penjualanDetSend = Penjualan.PenjualanDets(GVITem.CurrentRow.Index)
            ModifyPenjualanDet(penjualanDetSend, TRANSACTION_MODE.CHANGE_QTY)
        ElseIf e.KeyCode = Keys.Right Then
            If Penjualan.PenjualanDets.Count = 0 Then Exit Sub
            Dim penjualanDetSend = Penjualan.PenjualanDets(GVITem.CurrentRow.Index)
            ModifyPenjualanDet(penjualanDetSend, TRANSACTION_MODE.CHANGE_PRICE)
        ElseIf e.KeyCode = Keys.Up Then
            If GVITem.CurrentRow.Index = 0 Then Exit Sub
            GVITem.Rows(GVITem.CurrentRow.Index - 1).IsCurrent = True
        ElseIf e.KeyCode = Keys.Down Then
            If GVITem.CurrentRow.Index = GVITem.Rows.Count - 1 Then Exit Sub
            GVITem.Rows(GVITem.CurrentRow.Index + 1).IsCurrent = True
        ElseIf e.KeyCode = Keys.Pause Then
            Using cashier As New Frm_Cashier() With {.UserName = UserName, .ModePenjualan = CASHIER_MODE.ON_SUSPEND}
                cashier.ShowDialog()
            End Using
        ElseIf e.KeyCode = Keys.End Then
            BtnSave.PerformClick()
        ElseIf e.KeyCode = Keys.PrintScreen Then
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            ShowMeHelpCommand()
        ElseIf e.KeyCode = Keys.F2 Then
            If GVFullSeize = False Then
                SetGVFullSeize(True)
            Else
                SetGVFullSeize(False)
            End If
        ElseIf e.KeyCode = Keys.F5 Then

        End If
    End Sub

    Private Sub GVITem_KeyDown(sender As Object, e As KeyEventArgs) Handles GVITem.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteItem()
        End If
    End Sub

    Private Sub FillDataToObject()
        With Penjualan
            .FormName = Name
            .IsStatus = 1
            If EditMOde = CRUD.ON_SAVE Then
                .KdFakturPenj = Fnc.GetGenerateKdFakturPenj
                .TglInput = Date.Today
                .TglJual = Now
            End If
            .Jam = Now
            .TglUpdate = Now
            .TotalBayar = GetTotalBayarItem()
            .UserName = UserName
            .Customer = lblCustomer.Tag
        End With
    End Sub
    Private Sub SetStyleControlNormal()
        EnabledAll(False)
        ClearAll()
        SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.normal)
        BtnAdd.Focus()
    End Sub
    Private Sub ShowPaymentInfo()
        Using Payment As New Frm_PaymentAndPrint() With {.UserName = UserName, .InputPenjualan = Penjualan}
            Payment.ShowDialog()
        End Using
    End Sub
    Private Sub SetKodePenjualanToItems()
        For Each i In Penjualan.PenjualanDets
            i.KdFakturPenj = Penjualan.KdFakturPenj
        Next
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            FillDataToObject()
            SetKodePenjualanToItems()
            Fnc.SetSavePenjualan(Penjualan, EditMOde)
            If EditMOde <> ON_SAVE Then
                InfoMessage(Fnc.MessageText)
                SetStyleControlNormal()
                Exit Sub
            End If
            ShowPaymentInfo()
            SetStyleControlNormal()
            If ModePenjualan = ON_SUSPEND Then Close()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub
    Private Sub SetStyleControlAdd()
        SetModeButtons(PnlCommand, SEMICO_Dialog.EnumModeButton.added)
        EnabledAll(True)
        currentQTY = 1
        txtBarcode.Focus()
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Penjualan = New Penjualan
        SetStyleControlAdd()
        lblNoTransaction.Text = Fnc.GetGenerateKdFakturPenj
        EditMOde = ON_SAVE
    End Sub

    Private Sub EnabledAll(Optional sts = True)
        EnableAllControl(Me, sts)
        EnableAllControl(pnlHeader, sts)
        EnableAllControl(pnlKet, sts)
    End Sub

    Private Sub SetupCancelationMode()
        Penjualan = Fnc.FindPenjualan
        If Fnc.HasValue = False Then Close()
        BindControlWithDataFromDB()
        GVFullSeize = False
    End Sub
    Private Sub SetupSuspendMode()
        pnlHeader.BackColor = Drawing.Color.Red
        Me.Text = "Cashier-Suspend"
    End Sub
    Private Sub SetGVFullSeize(sts As Boolean)
        If sts Then
            GVITem.Height += 102
            GVFullSeize = sts
        Else
            GVITem.Height -= 102
            GVFullSeize = sts
        End If
    End Sub
    Private Sub Frm_Cashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnabledAll(False)
        SetStyleControlNormal()
        SetGVFullSeize(True)
        If ModePenjualan = ON_CANCELATION Then SetupCancelationMode()
        If ModePenjualan = ON_SUSPEND Then SetupSuspendMode()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        SetStyleControlNormal()
        If ModePenjualan = ON_SUSPEND Then Close()
    End Sub

    Private Sub Frm_Cashier_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAdd.Focus()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Penjualan = Fnc.FindPenjualan
            If Fnc.HasValue = True Then
                BindControlWithDataFromDB()
                txtBarcode.Focus()
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnDElete_Click(sender As Object, e As EventArgs) Handles BtnDElete.Click
        Try
            If AskMessage(MSGAskDelete) = DialogResult.No Then Exit Sub
            Fnc.SetSavePenjualan(Penjualan, ON_DELETE)
            InfoMessage(Fnc.MessageText)
            SetStyleControlNormal()
            If ModePenjualan = ON_SUSPEND Then Close()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If lblNoTransaction.Text = "" Then
                WarnMessage(MSGNoData)
                Exit Sub
            End If
            ShowPaymentInfo()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        If BarcodeMode = BARCODE_MODE.ON_AUTOENTER Then
            If txtBarcode.Text.Length <= 12 Or Not IsNumeric(txtBarcode.Text) Then
                Return
            End If
            btnAddItem.PerformClick()
            txtBarcode.Text = ""
            txtBarcode.Focus()
        End If
    End Sub

    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtBarcode.Focus()
        End If
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs)
        SharedFunction.InputOnlyNumeric(e)
    End Sub

End Class