Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Partial Class PublicFunction
    Public Function GetGenerateKdPelanggan() As String
        Dim temp As String
        Gconn.StringQuery = QSelectCOUNT("kdplgn", "pelanggan")
        Gconn.Execute()
        If Gconn(0) = 0 Then
            temp = "C" & "0001"
        Else
            Gconn.StringQuery = "SELECT MAX(cast(RIGHT(kdplgn,4) AS INT)) + 1 AS MaxNum  FROM pelanggan "
            Gconn.Execute()
            temp = "C" & Format(Gconn(0), "0000")
        End If
        Return temp
    End Function
    Public Function FindPelanggan() As Pelanggan
        Dim temp As New Pelanggan
        Using Fnd As New DialogCariData()
            Fnd.StringConection = ConectionString
            Fnd.Table = "Pelanggan"
            Fnd.TITLE = "Find Customer"
            Fnd.Field1 = "kdPlgn"
            Fnd.Field2 = "NmPlgn"
            Fnd.DisplayField1 = "Code"
            Fnd.DisplayField2 = "Name"
            Fnd.Criteria = STR_IsStatusTrue
            Fnd.IndexFocus = 1
            Fnd.AutoQuery = True
            Fnd.ShowDialog()
            If Fnd.HasValue Then
                temp = GetSinglePelanggan(Fnd.Value)
                HasValue = True
            Else
                HasValue = False
            End If
        End Using
        Return temp
    End Function

    Public Function GetSinglePelanggan(KdPelanggan As String) As Pelanggan
        Dim temp As New Pelanggan
        Gconn.StringQuery = QSelect("Pelanggan") & _
                            AddCriteria(Equal("kdPlgn", CSQL(KdPelanggan)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        temp = SetValuePelanggan()
        Return temp
    End Function
    Public Sub SetFieldValuePelanggan(Pelanggan As Pelanggan)
        If Pelanggan Is Nothing Then Return
        FieldCollection.Clear()
        FieldCollection.Add("Almtplgn")
        FieldCollection.Add("Faxplgn")
        FieldCollection.Add("FormName")
        FieldCollection.Add("Kdplgn")
        FieldCollection.Add("Kotaplgn")
        FieldCollection.Add("Nmplgn")
        FieldCollection.Add("isStatus")
        FieldCollection.Add("Telpplgn")
        FieldCollection.Add("TglInput")
        FieldCollection.Add("TglUpdate")
        FieldCollection.Add("UserName")
        With Pelanggan
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.Almtplgn))
            ValueCollection.Add(CSQL(.Faxplgn))
            ValueCollection.Add(CSQL(.FormName))
            ValueCollection.Add(CSQL(.Kdplgn))
            ValueCollection.Add(CSQL(.Kotaplgn))
            ValueCollection.Add(CSQL(.Nmplgn))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.Telpplgn))
            ValueCollection.Add(CSQLdate(NDD(.TglInput)))
            ValueCollection.Add(CSQLdate(NDD(.TglUpdate)))
            ValueCollection.Add(CSQL(.UserName))
        End With
    End Sub
    Public Sub SetOldValuePelanggan(Pelanggan As Pelanggan)
        If Pelanggan Is Nothing Then Return
        With Pelanggan
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.Almtplgn))
            OldValueCollection.Add(CSQL(.Faxplgn))
            OldValueCollection.Add(CSQL(.FormName))
            OldValueCollection.Add(CSQL(.Kdplgn))
            OldValueCollection.Add(CSQL(.Kotaplgn))
            OldValueCollection.Add(CSQL(.Nmplgn))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.Telpplgn))
            OldValueCollection.Add(CSQLdate(NDD(.TglInput)))
            OldValueCollection.Add(CSQLdate(NDD(.TglUpdate)))
            OldValueCollection.Add(CSQL(.UserName))
        End With
    End Sub
    Private Sub SetOldValueAuditTrail(ByVal Pelanggan As Pelanggan)
        Dim OldPelangan = GetSinglePelanggan(Pelanggan.Kdplgn)
        SetOldValuePelanggan(OldPelangan)
    End Sub
    Private Sub SetNewValueAuditTrail(ByVal Pelanggan As Pelanggan, ByVal Tipe As CRUD, ByVal kdpelanggan As String)
        SetFieldValuePelanggan(GetSinglePelanggan(kdpelanggan))
        Dim audittrail As New AuditTrail With {.KdAuditTrail = GetGenerateKdAuditTrails(), .Actions = Tipe.ToString, .Hosts = My.Computer.Name, .Modules = Pelanggan.FormName, .Operations = Tipe.ToString, .TglInput = Now, .Username = Pelanggan.UserName}
        SetSaveAuditTrail(audittrail, CRUD.ON_SAVE)
    End Sub
    Private Sub Execute(ByVal Pelanggan As Pelanggan, ByVal Tipe As CRUD)
        If Tipe = CRUD.ON_SAVE Then
            Gconn.StringQuery = Qinsert("Pelanggan", FieldCollection, ValueCollection)
            MessageText = MSGDataSave
        ElseIf Tipe = CRUD.ON_UPDATE Then
            Gconn.StringQuery = QUpdate("Pelanggan", FieldCollection, ValueCollection) &
                                AddCriteria(Equal("kdplgn", CSQL(Pelanggan.Kdplgn)))
            MessageText = MSGDataUpdate
        ElseIf Tipe = CRUD.ON_DELETE Then
            Gconn.StringQuery = QUpdate("Pelanggan", "IsStatus=0 , tglUpdate=getdate(), username=" & CSQL(Pelanggan.UserName)) &
                                AddCriteria(Equal("kdplgn", CSQL(Pelanggan.Kdplgn)))
            MessageText = MSGDataDelete
        End If
        Gconn.Execute()
        If Gconn.RowsEffected = 0 Then Throw New Exception(MSGNoDataAffected)
    End Sub
    Public Sub SetSavePelanggan(Pelanggan As Pelanggan, Tipe As CRUD)
        Dim kdpelanggan = Pelanggan.Kdplgn
        SetFieldValuePelanggan(Pelanggan)
        SetOldValueAuditTrail(Pelanggan)
        Execute(Pelanggan, Tipe)
        SetNewValueAuditTrail(Pelanggan, Tipe, kdpelanggan)
    End Sub
    Private Function SetValuePelanggan()
        Dim temp As New Pelanggan
        With temp
            .Almtplgn = NN(Gconn("Almtplgn"))
            .Faxplgn = NN(Gconn("Faxplgn"))
            .FormName = NN(Gconn("FormName"))
            .Kdplgn = NN(Gconn("Kdplgn"))
            .Kotaplgn = NN(Gconn("Kotaplgn"))
            .Nmplgn = NN(Gconn("Nmplgn"))
            .IsStatus = NN(Gconn("isStatus"))
            .Telpplgn = NN(Gconn("Telpplgn"))
            .TglInput = NDD(Gconn("TglInput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .UserName = NN(Gconn("UserName"))
            .Hpplgn = NN(Gconn("hpplgn"))
        End With
        Return temp
    End Function
    Public Function GetListPelanggan() As List(Of Pelanggan)
        Dim temp As New List(Of Pelanggan)
        Gconn.StringQuery = QSelect("Pelanggan")
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValuePelanggan)
            Gconn.NextRow()
        Next
        Return temp
    End Function
End Class