Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Partial Class PublicFunction
    Public Function GetSingleSatuanDet(KdBarang As String, Kdsatuan As String) As SatuanDet
        Gconn.StringQuery = QSelect("satuanDet") & _
                            AddCriteria(Equal("kdbarang", CSQL(KdBarang))) & _
                            AddAndCriteria(Equal("kdsatuan", CSQL(Kdsatuan)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        Return SetValueSatuanDet()
    End Function

    Public Function GetSingleSatuanDet(barcode As String) As SatuanDet
        Gconn.StringQuery = QSelect("satuanDet") & _
                            AddCriteria(Equal("barcode", CSQL(barcode))) & _
                            AddOrderASC("par")
        Gconn.Execute()
        If Gconn.HasRows = False Then Return Nothing
        Return SetValueSatuanDet()
    End Function
    Private Function SetValueSatuanDet() As SatuanDet
        Dim temp As New SatuanDet
        With temp
            .Kdbarang = NN(Gconn("kdbarang"))
            .KdSatuan = NN(Gconn("kdsatuan"))
            .Par = NN(Gconn("par"))
            .HargaJual = NN(Gconn("HargaJual"))
            .HargaBeli = NN(Gconn("hargaBeli"))
            .IsStatus = NN(Gconn("IsStatus"))
            .Barcode = NN(Gconn("barcode"))
            .TglInput = NDD(Gconn("TglInput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .FormName = NN(Gconn("FormName"))
            .Username = NN(Gconn("Username"))
        End With
        Return temp
    End Function
    Public Sub SetDeleteLisSatuanDet(KdBarang As String)
        Gconn.StringQuery = QUpdate("satuandet", "IsStatus=0 , TglUpdate = Getdate()") & _
                             AddCriteria(Equal("kdbarang", CSQL(KdBarang)))
        Gconn.Execute()
        MessageText = "Deleted " & Gconn.RowsEffected
    End Sub
    Public Function GetListSatuanDet(Optional Kriteria As String = "") As List(Of SatuanDet)
        Dim temp As New List(Of SatuanDet)
        Gconn.StringQuery = QSelect("SatuanDet") & IIf(Kriteria = "", "", AddCriteria(Kriteria) & AddOrderASC("par"))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValueSatuanDet)
            Gconn.NextRow()
        Next
        Return temp
    End Function
    Public Sub SetFieldValueSatuanDet(SatuanDet As SatuanDet)
        FieldCollection.Clear()
        FieldCollection.Add("kdbarang")
        FieldCollection.Add("kdsatuan")
        FieldCollection.Add("par")
        FieldCollection.Add("hargajual")
        FieldCollection.Add("hargabeli")
        FieldCollection.Add("IsStatus")
        FieldCollection.Add("barcode")
        FieldCollection.Add("Tglinput")
        FieldCollection.Add("TglUpdate")
        FieldCollection.Add("FormName")
        FieldCollection.Add("UserName")
        ValueCollection.Clear()
        If SatuanDet Is Nothing Then Return 'buat audit trail saat hapus
        With SatuanDet
            ValueCollection.Add(CSQL(.Kdbarang))
            ValueCollection.Add(CSQL(.KdSatuan))
            ValueCollection.Add(NNol(.Par))
            ValueCollection.Add(NNol(.HargaJual))
            ValueCollection.Add(NNol(.HargaBeli))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.Barcode))
            ValueCollection.Add(CSQLDateTime(.TglInput))
            ValueCollection.Add(CSQLDateTime(.TglUpdate))
            ValueCollection.Add(CSQL(.FormName))
            ValueCollection.Add(CSQL(.Username))
        End With
    End Sub
    Public Sub SetOldValueSatuandet(satuandet As SatuanDet)
        If satuandet Is Nothing Then Return
        With satuandet
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.Kdbarang))
            OldValueCollection.Add(CSQL(.KdSatuan))
            OldValueCollection.Add(NNol(.Par))
            OldValueCollection.Add(NNol(.HargaJual))
            OldValueCollection.Add(NNol(.HargaBeli))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.Barcode))
            OldValueCollection.Add(CSQLDateTime(.TglInput))
            OldValueCollection.Add(CSQLDateTime(.TglUpdate))
            OldValueCollection.Add(CSQL(.FormName))
            OldValueCollection.Add(CSQL(.Username))
        End With
    End Sub
    Private Sub Execute(ByVal SatuanDEt As SatuanDet, ByVal Tipe As CRUD)
        If Tipe = CRUD.ON_SAVE Then
            Gconn.StringQuery = Qinsert("SatuanDEt", FieldCollection, ValueCollection)
            MessageText = MSGDataSave
        ElseIf Tipe = CRUD.ON_UPDATE Then
            Gconn.StringQuery = QUpdate("SatuanDEt", FieldCollection, ValueCollection) &
                                AddCriteria(Equal("kdbarang", CSQL(SatuanDEt.Kdbarang))) &
                                AddAndCriteria(Equal("kdSatuan", CSQL(SatuanDEt.KdSatuan)))
            MessageText = MSGDataUpdate
        ElseIf Tipe = CRUD.ON_DELETE Then
            Gconn.StringQuery = QUpdate("SatuanDEt", "IsStatus=0 , tglUpdate=getdate(), username=" & CSQL(SatuanDEt.Username)) &
                                AddCriteria(Equal("kdbarang", CSQL(SatuanDEt.Kdbarang))) &
                                AddAndCriteria(Equal("kdSatuan", CSQL(SatuanDEt.KdSatuan)))
            MessageText = MSGDataDelete
        ElseIf Tipe = CRUD.ON_HARD_DELETE Then
            Gconn.StringQuery = QDelete("SatuanDEt") &
                                AddCriteria(Equal("kdbarang", CSQL(SatuanDEt.Kdbarang))) &
                                AddAndCriteria(Equal("kdSatuan", CSQL(SatuanDEt.KdSatuan)))
            MessageText = MSGDataDelete
        End If
        Gconn.Execute()
        If Gconn.RowsEffected = 0 Then Throw New Exception(MSGNoDataAffected)
    End Sub
    Private Sub SetNewValueAuditTrail(ByVal SatuanDEt As SatuanDet, ByVal Tipe As CRUD, ByVal OldSatuanDEt As SatuanDet)
        SetOldValueSatuandet(OldSatuanDEt)
        SetFieldValueSatuanDet(GetSingleSatuanDet(SatuanDEt.Kdbarang, SatuanDEt.KdSatuan))
        Dim audittrail As New AuditTrail With {.KdAuditTrail = GetGenerateKdAuditTrails(), .Actions = Tipe.ToString, .Hosts = My.Computer.Name, .Modules = SatuanDEt.FormName, .Operations = Tipe.ToString, .TglInput = Now, .Username = SatuanDEt.Username}
        SetSaveAuditTrail(audittrail, CRUD.ON_SAVE)
    End Sub
    Public Sub SetSaveSatuanDEt(SatuanDEt As SatuanDet, Tipe As CRUD)
        SetFieldValueSatuanDet(SatuanDEt)
        Dim OldSatuanDEt = GetSingleSatuanDet(SatuanDEt.Kdbarang, SatuanDEt.KdSatuan)
        Execute(SatuanDEt, Tipe)
        SetNewValueAuditTrail(SatuanDEt, Tipe, OldSatuanDEt)
    End Sub
    Private Sub HapusDataYangTidakTerdaftarDiListYangBaru(ByVal LSatuanDet As IList(Of SatuanDet), ByVal f As List(Of SatuanDet))
        For i = 0 To f.Count - 1
            Dim index = i
            Dim v = From c In LSatuanDet Where c.Kdbarang = f(index).Kdbarang And c.KdSatuan = f(index).KdSatuan Select c

            If v.Count = 0 Then
                SetSaveSatuanDEt(f(index), CRUD.ON_HARD_DELETE)
            End If
        Next
    End Sub
    Private Sub InsertList(ByVal LSatuanDet As IList(Of SatuanDet))
        For i = 0 To LSatuanDet.Count - 1
            Dim satuandet = GetSingleSatuanDet(LSatuanDet(i).Kdbarang, LSatuanDet(i).KdSatuan)
            If satuandet Is Nothing Then
                SetSaveSatuanDEt(LSatuanDet(i), CRUD.ON_SAVE)
            Else
                SetSaveSatuanDEt(LSatuanDet(i), CRUD.ON_UPDATE)
            End If
        Next
    End Sub
    Public Sub SetSaveListSatuanDet(LSatuanDet As IList(Of SatuanDet))
        If LSatuanDet.Count = 0 Then Throw New Exception("List SatuanDet Nothing")
        Dim f = GetListSatuanDet(Equal("kdbarang", CSQL(LSatuanDet(0).Kdbarang)))
        InsertList(LSatuanDet)
        HapusDataYangTidakTerdaftarDiListYangBaru(LSatuanDet, f)
    End Sub
End Class