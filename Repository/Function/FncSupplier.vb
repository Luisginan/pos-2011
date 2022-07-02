Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Partial Class PublicFunction
    Public Function GetGenerateKdSupplier() As String
        Dim temp As String
        Gconn.StringQuery = QSelectCOUNT("kdsupplier", "Supplier")
        Gconn.Execute()
        If Gconn(0) = 0 Or IsDBNull(Gconn(0)) Then
            temp = "S" & "0001"
        Else
            Gconn.StringQuery = "SELECT MAX(cast(RIGHT(kdsupplier,4) AS INT)) + 1 AS MaxNum  FROM supplier "
            Gconn.Execute()
            temp = "S" & Format(Gconn(0), "0000")
        End If
        Return temp
    End Function
    Private Function SetValueSupplier()
        Dim temp As New Supplier
        With temp
            .KdSupplier = NN(Gconn("kdsupplier"))
            .NmSup = NN(Gconn("NmSup"))
            .HpSup = NN(Gconn("HpSup"))
            .Kota = NN(Gconn("kota"))
            .IsStatus = NN(Gconn("isStatus"))
            .TlpSup = NN(Gconn("TlpSup"))
            .AlmtSup = NN(Gconn("AlmtSup"))
            .FaxSup = NN(Gconn("FaxSup"))
            .TglInput = NDD(Gconn("TglInput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .UserName = NN(Gconn("UserName"))
            .FormName = NN(Gconn("FormName"))
        End With
        Return temp
    End Function
    Public Function FindSupplier() As Supplier
        Dim temp As New Supplier
        Using Fnd As New DialogCariData()
            Fnd.StringConection = ConectionString
            Fnd.Table = "Supplier"
            Fnd.TITLE = "Find Supplier"
            Fnd.Field1 = "kdSupplier"
            Fnd.Field2 = "NmSup"
            Fnd.DisplayField1 = "Code"
            Fnd.DisplayField2 = "Name"
            Fnd.AutoQuery = True
            Fnd.IndexFocus = 1
            Fnd.Criteria = STR_IsStatusTrue
            Fnd.ShowDialog()
            If Fnd.HasValue Then
                temp = GetSingleSupplier(Fnd.Value)
                HasValue = True
            Else
                HasValue = False
            End If
        End Using
        Return temp
    End Function
    Public Function GetListSupplier() As List(Of Supplier)
        Dim temp As New List(Of Supplier)
        Gconn.StringQuery = QSelect("Supplier")
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValueSupplier)
            Gconn.NextRow()
        Next
        Return temp
    End Function

    Public Function GetSingleSupplier(KdSupplier As String) As Supplier
        Gconn.StringQuery = QSelect("Supplier") & _
                            AddCriteria(Equal("kdSupplier", CSQL(KdSupplier)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        Return SetValueSupplier()
    End Function
    Public Sub SetFieldValueSupplier(Supplier As Supplier)
        If Supplier Is Nothing Then Return
        FieldCollection.Clear()
        FieldCollection.Add("KdSupplier")
        FieldCollection.Add("NmSup")
        FieldCollection.Add("AlmtSup")
        FieldCollection.Add("FaxSup")
        FieldCollection.Add("HpSup")
        FieldCollection.Add("[isStatus]")
        FieldCollection.Add("TlpSup")
        FieldCollection.Add("kota")
        FieldCollection.Add("TglInput")
        FieldCollection.Add("TglUpdate")
        FieldCollection.Add("[UserName]")
        FieldCollection.Add("FormName")
        With Supplier
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.KdSupplier))
            ValueCollection.Add(CSQL(.NmSup))
            ValueCollection.Add(CSQL(.AlmtSup))
            ValueCollection.Add(CSQL(.FaxSup))
            ValueCollection.Add(CSQL(.HpSup))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.TlpSup))
            ValueCollection.Add(CSQL(.Kota))
            ValueCollection.Add(CSQLdate(NDD(.TglInput)))
            ValueCollection.Add(CSQLdate(NDD(.TglUpdate)))
            ValueCollection.Add(CSQL(.UserName))
            ValueCollection.Add(CSQL(.FormName))
        End With
    End Sub
    Public Sub SetOldValuesupplier(supplier As Supplier)
        If supplier Is Nothing Then Return
        With supplier
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.KdSupplier))
            OldValueCollection.Add(CSQL(.NmSup))
            OldValueCollection.Add(CSQL(.AlmtSup))
            OldValueCollection.Add(CSQL(.FaxSup))
            OldValueCollection.Add(CSQL(.HpSup))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.TlpSup))
            OldValueCollection.Add(CSQL(.Kota))
            OldValueCollection.Add(CSQLdate(NDD(.TglInput)))
            OldValueCollection.Add(CSQLdate(NDD(.TglUpdate)))
            OldValueCollection.Add(CSQL(.UserName))
            OldValueCollection.Add(CSQL(.FormName))
        End With
    End Sub
    Private Function SetOldValueAuditTrails(ByVal Supplier As Supplier) As String
        Dim kdsupplier = Supplier.KdSupplier
        Dim Oldsupplier = GetSingleSupplier(Supplier.KdSupplier)
        SetOldValuesupplier(Oldsupplier)
        Return kdsupplier
    End Function
    Private Sub Execute(ByVal Supplier As Supplier, ByVal Tipe As CRUD)
        If Tipe = CRUD.ON_SAVE Then
            Gconn.StringQuery = Qinsert("Supplier", FieldCollection, ValueCollection)
            MessageText = MSGDataSave
        ElseIf Tipe = CRUD.ON_UPDATE Then
            Gconn.StringQuery = QUpdate("Supplier", FieldCollection, ValueCollection) &
            AddCriteria(Equal("kdsupplier", CSQL(Supplier.KdSupplier)))
            MessageText = MSGDataUpdate
        ElseIf Tipe = CRUD.ON_DELETE Then
            Gconn.StringQuery = QUpdate("Supplier", "IsStatus=0 , tglUpdate=Getdate(), username=" & CSQL(Supplier.UserName)) &
            AddCriteria(Equal("kdsupplier", CSQL(Supplier.KdSupplier)))
            MessageText = MSGDataDelete
        End If
        Gconn.Execute()
        If Gconn.RowsEffected = 0 Then Throw New Exception(MSGNoDataAffected)
    End Sub
    Private Sub SetNewValueAuditTrail(ByVal Supplier As Supplier, ByVal Tipe As CRUD, ByVal kdsupplier As String)
        SetFieldValueSupplier(GetSingleSupplier(kdsupplier))
        Dim audittrail As New AuditTrail With {.KdAuditTrail = GetGenerateKdAuditTrails(), .Actions = Tipe.ToString, .Hosts = My.Computer.Name, _
                                               .Modules = Supplier.FormName, .Operations = Tipe.ToString, .TglInput = Now, .Username = Supplier.UserName}
        SetSaveAuditTrail(audittrail, CRUD.ON_SAVE)
    End Sub
    Public Sub SetSaveSupplier(Supplier As Supplier, Tipe As CRUD)
        Dim kdsupplier As String = SetOldValueAuditTrails(Supplier)
        SetFieldValueSupplier(Supplier)
        Execute(Supplier, Tipe)
        SetNewValueAuditTrail(Supplier, Tipe, kdsupplier)
    End Sub
End Class