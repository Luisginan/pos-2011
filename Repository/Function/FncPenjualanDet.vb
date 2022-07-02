Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Imports System.Data.SqlClient
Imports BPRoc_LIB.My
Imports System.Data.OleDb
Partial Class PublicFunction
    Public Function GetSinglePenjualanDet(KDfaktur As String, kdbarang As String) As PenjualanDet
        Gconn.StringQuery = QSelect("penjualanDet") & _
                            AddCriteria(Equal(FIELD_KD_FAKTUR_PENJ, CSQL(KDfaktur))) & _
                            AddAndCriteria(Equal("kdbarang", CSQL(kdbarang)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        Return SetValuePenjualanDet()
    End Function

    Private Function SetValuePenjualanDet() As PenjualanDet
        Dim temp As New PenjualanDet
        With temp
            .KdFakturPenj = NN(Gconn(FIELD_KD_FAKTUR_PENJ))
            .KdBarang = NN(Gconn("kdbarang"))
            .Qty = NN(Gconn("qty"))
            .Kdsatuan = NN(Gconn("kdsatuan"))
            .HargaBeli = NN(Gconn("hargaBeli"))
            .HargaJual = NN(Gconn("hargaJual"))
            .Total = NN(Gconn("Total"))
            .IsStatus = NN(Gconn("IsStatus"))
            .Nama = NN(Gconn("Nama"))
            .FormName = NN(Gconn("Formname"))
            .Username = NN(Gconn("UserName"))
            .TglInput = NDD(Gconn("tglinput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
        End With

        Return temp
    End Function
    Public Sub SetDeleteLisPenjualanDet(Kdfaktur As String)
        Gconn.StringQuery = QUpdate("PenjualanDet", "IsStatus=0 , TglUpdate = Getdate()") & _
                             AddCriteria(Equal(FIELD_KD_FAKTUR_PENJ, CSQL(Kdfaktur)))
        Gconn.Execute()
        If Gconn.RowsEffected = 0 Then Throw New Exception(MSGNoDataAffected)
        MessageText = "Deleted " & Gconn.RowsEffected
    End Sub
    Public Function GetListPenjualanDet(Optional Kriteria As String = "") As IList(Of PenjualanDet)
        Dim temp As New List(Of PenjualanDet)
        Gconn.StringQuery = QSelect("PenjualanDet") & IIf(Kriteria = " ", " ", AddCriteria(Kriteria))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValuePenjualanDet)
            Gconn.NextRow()
        Next
        Return temp
    End Function

    Public Sub SetFieldValuePenjualanDet(PenjualanDet As PenjualanDet)
        FieldCollection.Clear()
        FieldCollection.Add(FIELD_KD_FAKTUR_PENJ)
        FieldCollection.Add("KdBarang")
        FieldCollection.Add("Qty")
        FieldCollection.Add("Kdsatuan")
        FieldCollection.Add("hargabeli")
        FieldCollection.Add("HargaJual")
        FieldCollection.Add("Total")
        FieldCollection.Add("IsStatus")
        FieldCollection.Add("Nama")
        FieldCollection.Add("FormName")
        FieldCollection.Add("UserName")
        FieldCollection.Add("tglInput")
        FieldCollection.Add("TglUpdate")
        With PenjualanDet
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.KdFakturPenj))
            ValueCollection.Add(CSQL(.KdBarang))
            ValueCollection.Add(NNol(.Qty))
            ValueCollection.Add(CSQL(.Kdsatuan))
            ValueCollection.Add(NNol(.HargaBeli))
            ValueCollection.Add(NNol(.HargaJual))
            ValueCollection.Add(NNol(.Total))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.Nama))
            ValueCollection.Add(CSQL(.FormName))
            ValueCollection.Add(CSQL(.Username))
            ValueCollection.Add(CSQLDateTime(.TglInput))
            ValueCollection.Add(CSQLDateTime(.TglUpdate))
        End With
        If FieldCollection.Count <> ValueCollection.Count Then Throw New Exception("Collection Not Same")
    End Sub
    Public Sub SetOldValuePenjualanDEt(PenjualanDEt As PenjualanDet)
        If PenjualanDEt Is Nothing Then Return
        With PenjualanDEt
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.KdFakturPenj))
            OldValueCollection.Add(CSQL(.KdBarang))
            OldValueCollection.Add(NNol(.Qty))
            OldValueCollection.Add(CSQL(.Kdsatuan))
            OldValueCollection.Add(NNol(.HargaBeli))
            OldValueCollection.Add(NNol(.HargaJual))
            OldValueCollection.Add(NNol(.Total))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.Nama))
            OldValueCollection.Add(CSQL(.FormName))
            OldValueCollection.Add(CSQL(.Username))
            OldValueCollection.Add(CSQLDateTime(.TglInput))
            OldValueCollection.Add(CSQLDateTime(.TglUpdate))
        End With
    End Sub
    Private Sub CekDataDalamDatabase(ByVal LpenjualanDet As IList(Of PenjualanDet))
        Gconn.StringQuery = QSelect("PenjualanDet") & AddCriteria(Equal(FIELD_KD_FAKTUR_PENJ, CSQL(LpenjualanDet(0).KdFakturPenj)))
        Gconn.Execute()
    End Sub
    Private Sub KaloAdaHapusDulu(ByVal LpenjualanDet As IList(Of PenjualanDet))
        If Gconn.HasRows Then
            Gconn.StringQuery = QDelete("PenjualanDet", FIELD_KD_FAKTUR_PENJ, LpenjualanDet(0).KdFakturPenj)
            Gconn.Execute()
            If Gconn.RowsEffected = 0 Then Throw New Exception("Failed at Delete list Penjulan Det")
        End If
    End Sub
    Private Sub InsertList(ByVal LpenjualanDet As IList(Of PenjualanDet))
        For i = 0 To LpenjualanDet.Count - 1
            SetFieldValuePenjualanDet(LpenjualanDet(i))
            Gconn.StringQuery = Qinsert("PenjualanDet", FieldCollection, ValueCollection)
            Gconn.Execute()
            If Gconn.RowsEffected = 0 Then Throw New Exception("Failed at Insert List PenjualanDet")
        Next
    End Sub
    Public Sub SetSaveListPenjualanDet(LpenjualanDet As IList(Of PenjualanDet))
        If LpenjualanDet.Count = 0 Then Throw New Exception("List Penjualan Det Nothing")
        CekDataDalamDatabase(LpenjualanDet)
        KaloAdaHapusDulu(LpenjualanDet)
        InsertList(LpenjualanDet)
    End Sub
End Class