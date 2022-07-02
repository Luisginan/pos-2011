Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Imports SEMICO_Dialog
Partial Class PublicFunction
    Private Function SetValueOwner()
        Dim temp As New T_Owner
        With temp
            .Nama = NN(Gconn("Nama"))
            .Alamat = NN(Gconn("Alamat"))
            .Telepon = NN(Gconn("Telepon"))
            .Mobile = NN(Gconn("Mobile"))
            .Fax = NN(Gconn("Fax"))
            .EMail = NN(Gconn("EMail"))
            .NoRegister = NN(Gconn("NoRegister"))
            .UserName = NN(Gconn("UserName"))
            .TglInput = NDD(Gconn("TglInput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .IsStatus = NN(Gconn("IsStatus"))
            .NamaToko = NN(Gconn("NamaToko"))
        End With
        Return temp
    End Function
    Public Function GetSingleOwner() As T_Owner
        Dim temp As New T_Owner
        Gconn.StringQuery = QSelect("T_Owner")
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        temp = SetValueOwner()
        Return temp
    End Function
    Public Sub SetFieldValueOwner(T_Owner As T_Owner)
        If T_Owner Is Nothing Then Return
        FieldCollection.Clear()
        FieldCollection.Add("Nama")
        FieldCollection.Add("alamat")
        FieldCollection.Add("telepon")
        FieldCollection.Add("mobile")
        FieldCollection.Add("fax")
        FieldCollection.Add("email")
        FieldCollection.Add("Noregister")
        FieldCollection.Add("username")
        FieldCollection.Add("tglInput")
        FieldCollection.Add("tglUpdate")
        FieldCollection.Add("IsStatus")
        FieldCollection.Add("NamaToko")
        With T_Owner
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.Nama))
            ValueCollection.Add(CSQL(.Alamat))
            ValueCollection.Add(CSQL(.Telepon))
            ValueCollection.Add(CSQL(.Mobile))
            ValueCollection.Add(CSQL(.Fax))
            ValueCollection.Add(CSQL(.EMail))
            ValueCollection.Add(CSQL(.NoRegister))
            ValueCollection.Add(CSQL(.UserName))
            ValueCollection.Add(CSQLdate(NDD(.TglInput)))
            ValueCollection.Add(CSQLdate(NDD(.TglUpdate)))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.NamaToko))
        End With
    End Sub
    Public Sub SetOldValueT_owner(T_owner As T_Owner)
        If T_owner Is Nothing Then Return
        With T_owner
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.Nama))
            OldValueCollection.Add(CSQL(.Alamat))
            OldValueCollection.Add(CSQL(.Telepon))
            OldValueCollection.Add(CSQL(.Mobile))
            OldValueCollection.Add(CSQL(.Fax))
            OldValueCollection.Add(CSQL(.EMail))
            OldValueCollection.Add(CSQL(.NoRegister))
            OldValueCollection.Add(CSQL(.UserName))
            OldValueCollection.Add(CSQLdate(NDD(.TglInput)))
            OldValueCollection.Add(CSQLdate(NDD(.TglUpdate)))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.NamaToko))
        End With
    End Sub
    Private Sub Execute(ByVal T_Owner As T_Owner, ByVal Tipe As CRUD)
        SetFieldValueOwner(T_Owner)
        If Tipe = CRUD.ON_SAVE Then
            Gconn.StringQuery = Qinsert("T_Owner", FieldCollection, ValueCollection)
        ElseIf Tipe = CRUD.ON_UPDATE Then
            Gconn.StringQuery = QUpdate("T_Owner", FieldCollection, ValueCollection) &
            AddCriteria(Equal("NAMA", CSQL(T_Owner.Nama)))
        End If
        Gconn.Execute()
        If Gconn.RowsEffected = 0 Then Throw New Exception(MSGNoDataAffected)
    End Sub
    Private Sub SetOldValueAuditTrail()
        Dim OldT_owner = GetSingleOwner()
        SetOldValueT_owner(OldT_owner)
    End Sub
    Private Sub SetNewValueAuditTrail(ByVal T_Owner As T_Owner, ByVal Tipe As CRUD)
        SetFieldValueOwner(GetSingleOwner())
        Dim audittrail As New AuditTrail With {.KdAuditTrail = GetGenerateKdAuditTrails(), .Actions = Tipe.ToString, .Hosts = My.Computer.Name, .Modules = "", .Operations = Tipe.ToString, .TglInput = Now, .Username = T_Owner.UserName}
        SetSaveAuditTrail(audittrail, CRUD.ON_SAVE)
    End Sub
    Public Sub SetSaveOwner(T_Owner As T_Owner, Tipe As CRUD)
        SetOldValueAuditTrail()
        Execute(T_Owner, Tipe)
        SetNewValueAuditTrail(T_Owner, Tipe)
        MessageText = MSGDataSave
    End Sub
End Class