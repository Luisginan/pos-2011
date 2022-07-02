Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Partial Class PublicFunction
    Public Function GetGenerateKdBarang() As String
        Dim temp As String
        Gconn.StringQuery = QSelectCOUNT("Kdbarang", "barang")
        Gconn.Execute()
        If Gconn(0) = 0 Then
            temp = "BJ" & "000001"
        Else
            Gconn.StringQuery = "SELECT MAX(cast(RIGHT(kdbarang,6) AS INT)) + 1 AS MaxNum  FROM barang "
            Gconn.Execute()
            temp = "BJ" & Format(Gconn(0), "000000")
        End If
        Return temp
    End Function
    Public Function FindLokasiBarang() As String
        Dim temp As String = ""
        Using Fnd As New DialogCariData()
            Fnd.StringConection = ConectionString
            Fnd.Table = "barang"
            Fnd.TITLE = "Find Location"
            Fnd.Field1 = "Lokasi"
            Fnd.DisplayField1 = "Lokasi"
            Fnd.Criteria = STR_IsStatusTrue
            Fnd.ShowDialog()
            If Fnd.HasValue Then
                temp = Fnd.Value
                HasValue = True
            Else
                HasValue = False
            End If
        End Using
        Return temp
    End Function
    Public Function FindBarang() As Barang
        Dim temp As New Barang
        Using Fnd As New DialogCariData()
            Fnd.StringConection = ConectionString
            Fnd.Table = "barang"
            Fnd.TITLE = "Find Barang"
            Fnd.Field1 = "kdbarang"
            Fnd.Field2 = "Nama"
            Fnd.DisplayField1 = "ID"
            Fnd.DisplayField2 = "Name"
            Fnd.IndexFocus = 1
            Fnd.AutoQuery = True
            Fnd.Criteria = STR_IsStatusTrue
            Fnd.ShowDialog()
            If Fnd.HasValue Then
                temp = GetSingleBarang(Fnd.Value)
                HasValue = True
            Else
                HasValue = False
            End If
        End Using
        Return temp
    End Function
    Public Function GetSingleBarang(KdBarang As String) As Barang
        Gconn.StringQuery = QSelect("Barang") & AddCriteria(Equal("kdbarang", CSQL(KdBarang)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        Return SetValueBarang()
    End Function
    Public Function GetSingleBarangByBarcode(barcode As String) As Barang
        Dim kdbarang = ""
        Dim Satuandet As SatuanDet
        Try
            Satuandet = GetListSatuanDet(FirstLIKES("barcode", barcode))(0)
        Catch ex As Exception
            Throw New Exception(MSGNoData)
        End Try
        If Not Satuandet Is Nothing Then
            kdbarang = Satuandet.Kdbarang
        Else
            Throw New Exception(MSGNoData)
        End If
        Gconn.StringQuery = QSelect("Barang") & AddCriteria(Equal("kdbarang", CSQL(kdbarang)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        Return SetValueBarang()
    End Function

    Public Sub SetFieldValueBarang(barang As Barang)
        If barang Is Nothing Then Return
        FieldCollection.Clear()
        FieldCollection.Add("kdbarang")
        FieldCollection.Add("Nama")
        FieldCollection.Add("Lokasi")
        FieldCollection.Add("[UserName]")
        FieldCollection.Add("TglInput")
        FieldCollection.Add("TglUpdate")
        FieldCollection.Add("FormName")
        FieldCollection.Add("IsStatus")
        FieldCollection.Add("kdKategori")
        With barang
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.KdBarang))
            ValueCollection.Add(CSQL(.Nama))
            ValueCollection.Add(CSQL(.Lokasi))
            ValueCollection.Add(CSQL(.UserName))
            ValueCollection.Add(CSQLDateTime(.TglInput))
            ValueCollection.Add(CSQLDateTime(.TglUpdate))
            ValueCollection.Add(CSQL(.FormName))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.KdKategori))
        End With
    End Sub
    Public Sub SetOldValueBarang(barang As Barang)
        If barang Is Nothing Then Return
        With barang
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.KdBarang))
            OldValueCollection.Add(CSQL(.Nama))
            OldValueCollection.Add(CSQL(.Lokasi))
            OldValueCollection.Add(CSQL(.UserName))
            OldValueCollection.Add(CSQLDateTime(.TglInput))
            OldValueCollection.Add(CSQLDateTime(.TglUpdate))
            OldValueCollection.Add(CSQL(.FormName))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.KdKategori))
        End With
    End Sub
    Public Function GetListBarang() As List(Of Barang)
        Dim temp As New List(Of Barang)
        Gconn.StringQuery = QSelect("Barang")
        Try
            Gconn.Execute()
            If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
            For i = 0 To Gconn.RowCount - 1
                temp.Add(SetValueBarang)
            Next
            HasError = False
        Catch ex As Exception
            HasError = True
            MessageText = ex.Message
        End Try
        Return temp
    End Function
    Private Sub OnSave(ByVal barang As Barang)
        Try
            Gconn.BeginsTrans()
            Gconn.StringQuery = Qinsert("barang", FieldCollection, ValueCollection)
            Gconn.Execute()
            SetSaveListSatuanDet(barang.SatuanDets)
            Gconn.CommitTrans()
            MessageText = MSGDataSave
        Catch ex As Exception
            Gconn.RollBackTrans()
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub OnUpdate(ByVal barang As Barang)
        Try
            Gconn.BeginsTrans()

            Gconn.StringQuery = QUpdate("barang", FieldCollection, ValueCollection) &
                                AddCriteria(Equal("kdbarang", CSQL(barang.KdBarang)))
            Gconn.Execute()
            SetSaveListSatuanDet(barang.SatuanDets)
            Gconn.CommitTrans()
            MessageText = MSGDataUpdate
        Catch ex As Exception
            Gconn.RollBackTrans()
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Function OnDelete(ByVal barang As Barang) As Integer
        Dim temp As Integer
        Gconn.BeginsTrans()
        Gconn.StringQuery = QUpdate("barang", "IsStatus=0 , tglupdate = getdate()") &
                            AddCriteria(Equal("kdbarang", CSQL(barang.KdBarang)))
        Gconn.Execute()
        SetDeleteLisSatuanDet(barang.KdBarang)
        Gconn.CommitTrans()
        temp = Gconn.RowsEffected
        MessageText = MSGDataDelete
        Return temp
    End Function
    Private Sub Execute(ByVal barang As Barang, ByVal Tipe As CRUD)
        SetFieldValueBarang(barang)
        If Tipe = CRUD.ON_SAVE Then
            OnSave(barang)
        ElseIf Tipe = CRUD.ON_UPDATE Then
            OnUpdate(barang)
        ElseIf Tipe = CRUD.ON_DELETE Then
            OnDelete(barang)
        End If
    End Sub
    Private Sub SetNewValueAuditTrail(ByVal barang As Barang, ByVal Tipe As CRUD, ByVal kdbarang As String, ByVal oldbarang As Barang)
        SetOldValueBarang(oldbarang)
        SetFieldValueBarang(GetSingleBarang(kdbarang))
        Dim audittrail As New AuditTrail With {.KdAuditTrail = GetGenerateKdAuditTrails(), .Actions = Tipe.ToString, .Hosts = My.Computer.Name, .Modules = barang.FormName, .Operations = "Barang", .TglInput = Now, .Username = barang.UserName}
        SetSaveAuditTrail(audittrail, CRUD.ON_SAVE)
    End Sub
    Public Sub SetSaveBarang(barang As Barang, Tipe As CRUD)
        Dim kdbarang = barang.KdBarang
        Dim oldbarang = GetSingleBarang(barang.KdBarang)
        Execute(barang, Tipe)
        SetNewValueAuditTrail(barang, Tipe, kdbarang, oldbarang)
    End Sub
    Private Function SetValueBarang() As Barang
        Dim temp As New Barang
        With temp
            .KdBarang = NN(Gconn("kdBarang"))
            .TglInput = NDD(Gconn("TglInput"))
            .Nama = NN(Gconn("nama"))
            .KdKategori = NN(Gconn("KdKategori"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .UserName = NN(Gconn("UserName"))
            .FormName = NN(Gconn("FormName"))
            .IsStatus = NN(Gconn("IsStatus"))
            .Lokasi = NN(Gconn("Lokasi"))
        End With
        Return temp
    End Function
End Class