Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Partial Class PublicFunction
    Public Sub SetFieldValueAuditTrailDet(AuditTrailDet As AuditTrailDet)
        FieldCollection.Clear()
        FieldCollection.Add("kdAudit")
        FieldCollection.Add("Fields")
        FieldCollection.Add("OldValues")
        FieldCollection.Add("NewValues")
        With AuditTrailDet
            ValueCollection.Clear()
            ValueCollection.Add(.KdAudit)
            ValueCollection.Add(CSQL(.Fields))
            ValueCollection.Add(.OldValues)
            ValueCollection.Add(.NewValues)
        End With
    End Sub

    Private Sub DeleteListAuditTrail(ByVal LAuditTrailDet As IList(Of AuditTrailDet))
        Gconn.StringQuery = QDelete("AuditTrailDet", "kdAudit", LAuditTrailDet(0).KdAudit)
        Gconn.Execute()
        If Gconn.RowsEffected = 0 Then Throw New Exception("Failed at Delete list AuditTrailDet")
    End Sub
    Private Sub InsertListDetAuditTrail(ByVal LAuditTrailDet As IList(Of AuditTrailDet))
        For i = 0 To LAuditTrailDet.Count - 1
            SetFieldValueAuditTrailDet(LAuditTrailDet(i))
            Gconn.StringQuery = Qinsert("AuditTrailDet", FieldCollection, ValueCollection)
            Gconn.Execute()
            If Gconn.RowsEffected = 0 Then Throw New Exception("Failed at Insert List AuditTrailDet")
        Next
    End Sub
    Private Sub CheckExistData(ByVal LAuditTrailDet As IList(Of AuditTrailDet))
        Gconn.StringQuery = QSelect("AuditTrailDet") & AddCriteria(Equal("kdAudit", CSQL(LAuditTrailDet(0).KdAudit)))
        Gconn.Execute()
    End Sub
    Public Sub SetSaveListAuditTrailDet(LAuditTrailDet As IList(Of AuditTrailDet))
        If LAuditTrailDet.Count = 0 Then Throw New Exception("List AuditTrailDet Nothing")
        CheckExistData(LAuditTrailDet)
        If Gconn.HasRows Then
            DeleteListAuditTrail(LAuditTrailDet)
        End If
        InsertListDetAuditTrail(LAuditTrailDet)
    End Sub
End Class