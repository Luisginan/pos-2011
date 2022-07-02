Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Partial Class PublicFunction
    Public Function Findkategori(Optional master As Object = Nothing) As Kategori
        Dim temp As New Kategori
        Using Fnd As New DialogCariData()
            Fnd.StringConection = ConectionString
            Fnd.Table = "kategori"
            Fnd.TITLE = "Find Category"
            Fnd.Field1 = "kdkategori"
            Fnd.Field2 = "Nama"
            Fnd.DisplayField1 = "Code"
            Fnd.DisplayField2 = "Name"
            Fnd.Criteria = STR_IsStatusTrue
            If master IsNot Nothing Then
                Fnd.InputForm = master
            End If
            Fnd.ShowDialog()
            If Fnd.HasValue Then
                temp = GetSinglekategori(Fnd.Value)
                HasValue = True
            Else
                HasValue = False
            End If
        End Using
        Return temp
    End Function

    Public Function GetListkategori() As List(Of Kategori)
        Dim temp As New List(Of Kategori)
        Gconn.StringQuery = QSelect("kategori") &
                            AddCriteria(Equal("IsStatus", 1))
        Try
            Gconn.Execute()
            If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
            For i = 0 To Gconn.RowCount - 1
                temp.Add(SetValueKategori)
                Gconn.NextRow()
            Next
            HasError = False
        Catch ex As Exception
            HasError = True
            MessageText = ex.Message
        End Try
        Return temp
    End Function

    Public Function GetSinglekategori(KdKategori As String) As Kategori
        Gconn.StringQuery = QSelect("kategori") & _
                            AddCriteria(Equal("kdKategori", CSQL(KdKategori)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        Return SetValueKategori()
    End Function
    Public Sub SetFieldValueKategori(kategori As Kategori)
        FieldCollection.Clear()
        FieldCollection.Add("KdKategori")
        FieldCollection.Add("Nama")
        FieldCollection.Add("IsStatus")
        FieldCollection.Add("TglInput")
        FieldCollection.Add("TglUpdate")
        FieldCollection.Add("UserName")
        FieldCollection.Add("FormName")
        With kategori
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.KdKategori))
            ValueCollection.Add(CSQL(.Nama))
            ValueCollection.Add(CSQL(.IsStatus))
            ValueCollection.Add(CSQLdate(.TglInput))
            ValueCollection.Add(CSQLdate(.TglUpdate))
            ValueCollection.Add(CSQL(.UserName))
            ValueCollection.Add(CSQL(.FormName))
        End With
    End Sub
    Public Sub SetOldValuekategori(kategori As Kategori)
        If kategori Is Nothing Then Return
        With kategori
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.KdKategori))
            OldValueCollection.Add(CSQL(.Nama))
            OldValueCollection.Add(CSQL(.IsStatus))
            OldValueCollection.Add(CSQLdate(.TglInput))
            OldValueCollection.Add(CSQLdate(.TglUpdate))
            OldValueCollection.Add(CSQL(.UserName))
            OldValueCollection.Add(CSQL(.FormName))
        End With
    End Sub
    Private Sub SetNewValueAuditTrail(ByVal kategori As Kategori, ByVal Tipe As CRUD, ByVal kdkategori As String)
        SetFieldValueKategori(GetSinglekategori(kdkategori))
        Dim audittrail As New AuditTrail With {.KdAuditTrail = GetGenerateKdAuditTrails(), .Actions = Tipe.ToString, .Hosts = My.Computer.Name, .Modules = kategori.FormName, .Operations = Tipe.ToString, .TglInput = Now, .Username = kategori.UserName}
        SetSaveAuditTrail(audittrail, CRUD.ON_SAVE)
    End Sub
    Private Sub SetOldValueAuditTrail(ByVal kategori As Kategori)
        Dim Oldkategori = GetSinglekategori(kategori.KdKategori)
        SetOldValuekategori(Oldkategori)
    End Sub
    Private Sub Execute(ByVal kategori As Kategori, ByVal Tipe As CRUD)
        If Tipe = CRUD.ON_SAVE Then
            Gconn.StringQuery = Qinsert("kategori", FieldCollection, ValueCollection)
            MessageText = MSGDataSave
        ElseIf Tipe = CRUD.ON_UPDATE Then
            Gconn.StringQuery = QUpdate("kategori", FieldCollection, ValueCollection) &
                                AddCriteria(Equal("KdKategori", CSQL(kategori.KdKategori)))
            MessageText = MSGDataUpdate
        ElseIf Tipe = CRUD.ON_DELETE Then
            Gconn.StringQuery = QUpdate("kategori", "IsStatus=0,tglUpdate=getdate(),Username=" & CSQL(kategori.UserName)) &
                                AddCriteria(Equal("KdKategori", CSQL(kategori.KdKategori)))
            MessageText = MSGDataDelete
        End If
        Gconn.Execute()
    End Sub
    Public Sub SetSaveKategori(kategori As Kategori, Tipe As CRUD)
        Dim kdkategori = kategori.KdKategori
        SetOldValueAuditTrail(kategori)
        SetFieldValueKategori(kategori)
        Execute(kategori, Tipe)
        If Gconn.RowsEffected = 0 Then Throw New Exception(MSGNoDataAffected)
        SetNewValueAuditTrail(kategori, Tipe, kdkategori)
    End Sub
    Private Function SetValueKategori()
        Dim temp As New Kategori
        With temp
            .KdKategori = NN(Gconn("KdKategori"))
            .Nama = NN(Gconn("Nama"))
            .TglInput = NDD(Gconn("TglInput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .UserName = NN(Gconn("UserName"))
            .FormName = NN(Gconn("FormName"))
            .IsStatus = NN(Gconn("IsStatus"))
        End With
        Return temp
    End Function
End Class