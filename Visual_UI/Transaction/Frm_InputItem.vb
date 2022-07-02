Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Imports SEMICO_Dialog.ClsMessage
Imports BPRoc_LIB.SharedFunction
Imports System.Drawing
Imports BPRoc_LIB

Public Class Frm_InputItem

    Property MenuDialog As TRANSACTION_MODE = TRANSACTION_MODE.INSERT_ITEM
    Property UserName As String
    Property satuanDetSelected As New SatuanDet
    Property Value As PenjualanDet

    ReadOnly Property HasValue As Boolean
        Get
            If Value Is Nothing Then Return False
            Return True
        End Get
    End Property
    Property InputValuePenjualanDet As PenjualanDet
    Property InputValueBarang As Barang
    Property ClasicMode As Boolean = False
    Property QTY As Integer
    Public Property BarcodeMode As BARCODE_MODE = BARCODE_MODE.ON_NORMAL

    Private Fnc As New BPRoc_LIB.PublicFunction
    ''' <summary>
    ''' Kumpulan satuan dari barang yang telah terpilih dari parameter
    ''' </summary>
    ''' <remarks></remarks>
    Dim LsatuanDet As New List(Of SatuanDet)

    ''' <summary>
    ''' Set nilai saat keluaran Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetOutPutValue()
        Value = New PenjualanDet
        With Value
            .HargaBeli = satuanDetSelected.HargaBeli
            If MenuDialog = TRANSACTION_MODE.CHANGE_PRICE Then
                .HargaJual = txtPrice.Text
            ElseIf MenuDialog = TRANSACTION_MODE.CHANGE_QTY Then
                .HargaJual = txtPrice.Text
            Else
                .HargaJual = txtPrice.Text
            End If
            If (.HargaJual - .HargaBeli) < 50 Then
                WarnMessage("Minimum 50 From Price Purchase")
                Exit Sub
            End If
            .TglInput = Now
            .TglUpdate = Now
            .IsStatus = 1
            .KdBarang = satuanDetSelected.Kdbarang
            .KdFakturPenj = ""
            .Kdsatuan = satuanDetSelected.KdSatuan
            .Nama = Fnc.GetSingleBarang(satuanDetSelected.Kdbarang).Nama
            .Qty = SafeQty()
            .Total = .Qty * .HargaJual
            .Username = UserName
            .FormName = "Cashier"
        End With
        Close()
    End Sub

    Function SafeQty() As Integer
        If txtQty.Text = "" Then Return 1
        If Val(txtQty.Text) <= 0 Then Return 1
        Return Val(txtQty.Text)
    End Function
    ''' <summary>
    ''' Digunakan jika satuan dengan parameter 1,
    ''' Digunakan untuk mengkonversi dari satuan terkecil ke yg sesuai
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ConvertUnit()
        If satuanDetSelected.Par = 1 Then
            For i = LsatuanDet.Count - 1 To 1 Step -1
                'qty harus pas
                Dim Qty = SafeQty()
                If Qty Mod LsatuanDet(i).Par = 0 And Qty \ LsatuanDet(i).Par >= 1 Then
                    txtQty.Text = Val(txtQty.Text) \ LsatuanDet(i).Par
                    If i = 1 Then
                        BtnUnit2.PerformClick()
                        Return
                    ElseIf i = 2 Then
                        BtnUnit3.PerformClick()
                        Return
                    ElseIf i = 3 Then
                        BtnUnit4.PerformClick()
                        Return
                    End If
                ElseIf Qty \ LsatuanDet(i).Par >= 1 Then
                    Continue For
                End If
            Next

            Try
                Return
            Catch ex As Exception
                Throw New Exception("Failed Converted Unit")
            End Try
        End If
    End Sub

    Sub SelectUnit()
        txtPrice.Text = satuanDetSelected.HargaJual
        txtCount.Text = satuanDetSelected.KdSatuan
        txtCountOf.Text = satuanDetSelected.Par
        txtTotal.Text = satuanDetSelected.HargaJual * SafeQty()
    End Sub

    Private Sub SetupUnitControls()
        If LsatuanDet.Count > 0 Then
            BtnUnit1.Text = LsatuanDet(0).KdSatuan
            btnPar1.Text = LsatuanDet(0).Par
        End If
        If LsatuanDet.Count > 1 Then
            BtnUnit2.Text = LsatuanDet(1).KdSatuan
            btnPar2.Text = LsatuanDet(1).Par
        End If
        If LsatuanDet.Count > 2 Then
            BtnUnit3.Text = LsatuanDet(2).KdSatuan
            btnPar3.Text = LsatuanDet(2).Par
        End If
        If LsatuanDet.Count > 3 Then
            BtnUnit4.Text = LsatuanDet(3).KdSatuan
            btnPar4.Text = LsatuanDet(3).Par
        End If
    End Sub
    Public Sub GetLoadDetailItemModify()
        LsatuanDet = Fnc.GetListSatuanDet("kdbarang=" & CSQL(InputValuePenjualanDet.KdBarang))
        If Fnc.HasError = False Then
            SetupUnitControls()
            Dim barang = Fnc.GetSingleBarang(InputValuePenjualanDet.KdBarang)
            If Fnc.HasError Then
                WarnMessage(Fnc.MessageText)
                Close()
            End If
            BindAllControl(Me, barang)
            With InputValuePenjualanDet
                txtQty.Text = .Qty
                If .Kdsatuan = BtnUnit1.Text Then
                    BtnUnit1.PerformClick()
                ElseIf .Kdsatuan = BtnUnit2.Text Then
                    BtnUnit2.PerformClick()
                ElseIf .Kdsatuan = BtnUnit3.Text Then
                    BtnUnit3.PerformClick()
                ElseIf .Kdsatuan = BtnUnit4.Text Then
                    BtnUnit4.PerformClick()
                End If
                txtPrice.Text = .HargaJual
            End With
        Else
            WarnMessage(MSGNoData)
            Close()
        End If
    End Sub

    Private Sub SetupButtonUnit()
        If LsatuanDet.Count > 0 Then
            BtnUnit1.Text = LsatuanDet(0).KdSatuan
            btnPar1.Text = LsatuanDet(0).Par
        End If
        If LsatuanDet.Count > 1 Then
            BtnUnit2.Text = LsatuanDet(1).KdSatuan
            btnPar2.Text = LsatuanDet(1).Par
        End If
        If LsatuanDet.Count > 2 Then
            BtnUnit3.Text = LsatuanDet(2).KdSatuan
            btnPar3.Text = LsatuanDet(2).Par
        End If
        If LsatuanDet.Count > 3 Then
            BtnUnit4.Text = LsatuanDet(3).KdSatuan
            btnPar4.Text = LsatuanDet(3).Par
        End If
    End Sub
    Public Sub GetLoadDetailItem()
        LsatuanDet = Fnc.GetListSatuanDet("kdbarang=" & CSQL(InputValueBarang.KdBarang))
        If Fnc.HasError = False Then
            SetupButtonUnit()
            BindAllControl(Me, InputValueBarang)
            txtQty.Text = QTY
            BtnUnit1.PerformClick()
            If Me.ClasicMode = False Then
                BtnDone.PerformClick()
            End If
        Else
            WarnMessage(MSGNoData)
            Close()
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged, txtQty.TextChanged
        Try
            If txtPrice.Text = "" Then Exit Sub
            txtTotal.Text = SafeQty() * txtPrice.Text
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
        'On Error Resume Next

    End Sub

    Private Sub Frm_InputItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If MenuDialog = TRANSACTION_MODE.INSERT_ITEM Then
            txtQty.Focus()
        ElseIf MenuDialog = TRANSACTION_MODE.CHANGE_QTY Then
            txtQty.Focus()
        Else
            txtQty.ReadOnly = False
            txtPrice.ReadOnly = False
            txtPrice.Focus()
        End If
    End Sub
    ''' <summary>
    ''' Di eksekusi oleh txtprice  dan txtQty
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtQty_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown, txtPrice.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If sender.name.ToString.ToUpper = "txtprice".ToUpper Then
                BtnDone.PerformClick()
            Else
                txtPrice.ReadOnly = False
                txtPrice.Focus()
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.Escape Then
            If sender.name.ToString.ToUpper = "txtprice".ToUpper Then
                txtQty.Focus()
            Else
                BtnCancel.PerformClick()
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F1 Then
            BtnUnit1.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then
            BtnUnit2.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F3 Then
            BtnUnit3.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F4 Then
            BtnUnit4.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.Left Then
            Dim Det = (From i In LsatuanDet Where i.Par < satuanDetSelected.Par Select i).LastOrDefault
            If Det IsNot Nothing Then
                If Det.KdSatuan = BtnUnit1.Text Then
                    BtnUnit1.PerformClick()
                ElseIf Det.KdSatuan = BtnUnit2.Text Then
                    BtnUnit2.PerformClick()
                ElseIf Det.KdSatuan = BtnUnit3.Text Then
                    BtnUnit3.PerformClick()
                ElseIf Det.KdSatuan = BtnUnit4.Text Then
                    BtnUnit4.PerformClick()
                End If
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.Right Then
            Dim Det = (From i In LsatuanDet Where i.Par > satuanDetSelected.Par Select i).FirstOrDefault
            If Det IsNot Nothing Then
                If Det.KdSatuan = BtnUnit1.Text Then
                    BtnUnit1.PerformClick()
                ElseIf Det.KdSatuan = BtnUnit2.Text Then
                    BtnUnit2.PerformClick()
                ElseIf Det.KdSatuan = BtnUnit3.Text Then
                    BtnUnit3.PerformClick()
                ElseIf Det.KdSatuan = BtnUnit4.Text Then
                    BtnUnit4.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Value = Nothing
        Close()
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnDone.Click
        Try
            'Hanya bila satuan unit par =1 ----------------
            ConvertUnit()
            '----------------------------------------------
            SetOutPutValue()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub
    Private Sub BtnUnit1_Click(sender As Object, e As EventArgs) Handles BtnUnit1.Click, BtnUnit2.Click, BtnUnit3.Click, BtnUnit4.Click
        Try
            If sender.text = "..." Then Exit Sub
            Dim index = sender.name.ToString.Replace("BtnUnit", "") - 1
            satuanDetSelected = LsatuanDet(index)
            lblUnitSelected.Text = String.Format("{0} : {1}", satuanDetSelected.KdSatuan, satuanDetSelected.Par)
            SelectUnit()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub
    Private Sub Frm_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MenuDialog = TRANSACTION_MODE.INSERT_ITEM Then
            GetLoadDetailItem()
        Else
            GetLoadDetailItemModify()
        End If
    End Sub

End Class