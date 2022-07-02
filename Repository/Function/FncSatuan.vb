Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Partial Class PublicFunction
    Public Sub SetFieldValueSatuan(Satuan As Satuan)
        If Satuan Is Nothing Then Return
        FieldCollection.Clear()
        FieldCollection.Add("FormName")
        FieldCollection.Add("Nama")
        FieldCollection.Add("IsStatus")
        FieldCollection.Add("kdSatuan")
        FieldCollection.Add("TglInput")
        FieldCollection.Add("TglUpdate")
        FieldCollection.Add("UserName")
        With Satuan
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.FormName))
            ValueCollection.Add(CSQL(.Nama))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.KdSatuan))
            ValueCollection.Add(CSQLdate(.TglInput))
            ValueCollection.Add(CSQLdate(.TglUpdate))
            ValueCollection.Add(CSQL(.UserName))
        End With
    End Sub
    Public Sub SetOldValuesatuan(satuan As Satuan)
        If satuan Is Nothing Then Return
        With satuan
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.FormName))
            OldValueCollection.Add(CSQL(.Nama))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.KdSatuan))
            OldValueCollection.Add(CSQLdate(.TglInput))
            OldValueCollection.Add(CSQLdate(.TglUpdate))
            OldValueCollection.Add(CSQL(.UserName))
        End With
    End Sub
    Public Function FindSatuan() As Satuan
        Dim temp As New Satuan
        Using Fnd As New DialogCariData()
            Fnd.StringConection = ConectionString
            Fnd.Table = "Satuan"
            Fnd.TITLE = "Find Unit"
            Fnd.Field1 = "kdSatuan"
            Fnd.Field2 = "Nama"
            Fnd.DisplayField1 = "Code"
            Fnd.DisplayField2 = "Name"
            Fnd.Criteria = STR_IsStatusTrue
            Fnd.ShowDialog()
            If Fnd.HasValue Then
                temp = GetSingleSatuan(Fnd.Value)
                HasValue = True
            Else
                HasValue = False
            End If
        End Using
        Return temp
    End Function
    Public Function GetListSatuan() As List(Of Satuan)
        Dim temp As New List(Of Satuan)
        Gconn.StringQuery = QSelect("Satuan") &
                            AddCriteria(Equal("IsStatus", 1))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValueSatuan)
            Gconn.NextRow()
        Next
        Return temp
    End Function
    Public Function GetSingleSatuan(KdSatuan As String) As Satuan
        Dim temp As New Satuan
        Gconn.StringQuery = QSelect("Satuan") & _
                            AddCriteria(Equal("kdSatuan", CSQL(KdSatuan)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        temp = SetValueSatuan()
        Return temp
    End Function
    Private Function SetValueSatuan()
        Dim temp As New Satuan
        With temp
            .FormName = NN(Gconn("FormName"))
            .Nama = NN(Gconn("Nama"))
            .KdSatuan = NN(Gconn("KdSatuan"))
            .TglInput = NDD(Gconn("TglInput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .UserName = NN(Gconn("UserName"))
            .IsStatus = NN(Gconn("IsStatus"))
        End With
        Return temp
    End Function
    Private Function SetOldValueAuditTrail(ByVal Satuan As Satuan) As String
        Dim kdsatuan = Satuan.KdSatuan
        Dim Oldsatuan = GetSingleSatuan(Satuan.KdSatuan)
        SetOldValuesatuan(Oldsatuan)
        Return kdsatuan
    End Function
    Private Sub Execute(ByVal Satuan As Satuan, ByVal Tipe As CRUD)
        SetFieldValueSatuan(Satuan)
        If Tipe = CRUD.ON_SAVE Then
            Gconn.StringQuery = Qinsert("satuan", FieldCollection, ValueCollection)
            MessageText = MSGDataSave
        ElseIf Tipe = CRUD.ON_UPDATE Then
            Gconn.StringQuery = QUpdate("satuan", FieldCollection, ValueCollection) &
            AddCriteria(Equal("kdsatuan", CSQL(Satuan.KdSatuan)))
            MessageText = MSGDataUpdate
        ElseIf Tipe = CRUD.ON_DELETE Then
            Gconn.StringQuery = QUpdate("satuan", "IsStatus=0,tglUpdate=getdate(),Username=" & CSQL(Satuan.KdSatuan)) &
                                AddCriteria(Equal("kdsatuan", CSQL(Satuan.KdSatuan)))
            MessageText = MSGDataDelete
        End If
    End Sub
    Private Sub SetNewValueAuditTrail(ByVal Satuan As Satuan, ByVal Tipe As CRUD, ByVal kdsatuan As String)
        SetFieldValueSatuan(GetSingleSatuan(kdsatuan))
        Dim audittrail As New AuditTrail With {.KdAuditTrail = GetGenerateKdAuditTrails(), .Actions = Tipe.ToString, .Hosts = My.Computer.Name, .Modules = Satuan.FormName, .Operations = Tipe.ToString, .TglInput = Now, .Username = Satuan.UserName}
        SetSaveAuditTrail(audittrail, CRUD.ON_SAVE)
    End Sub
    Public Sub SetSaveSatuan(Satuan As Satuan, Tipe As CRUD)
        Dim kdsatuan As String = SetOldValueAuditTrail(Satuan)
        Execute(Satuan, Tipe)
        Gconn.Execute()
        If Gconn.RowsEffected = 0 Then Throw New Exception(MSGNoDataAffected)
        SetNewValueAuditTrail(Satuan, Tipe, kdsatuan)
    End Sub
End Class