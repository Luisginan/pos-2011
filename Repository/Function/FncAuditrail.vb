Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly

Partial Class PublicFunction
    Public Function GetGenerateKdAuditTrails() As Decimal
        Dim temp As Decimal
        Gconn.StringQuery = QSelectCOUNT("kdaudittrail", "audittrail")
        Gconn.Execute()
        If Gconn(0) = 0 Then
            temp = 0
        Else
            Gconn.StringQuery = "SELECT MAX(kdAudittrail) + 1 AS MaxNum  FROM audittrail "
            Gconn.Execute()
            temp = Gconn(0)
        End If
        Return temp
    End Function

    Public Sub SetFieldValueAuditTrail(AuditTrail As AuditTrail)
        FieldCollection.Clear()
        FieldCollection.Add("kdAuditTrail")
        FieldCollection.Add("TglInput")
        FieldCollection.Add("Username")
        FieldCollection.Add("Operations")
        FieldCollection.Add("Modules")
        FieldCollection.Add("Actions")
        FieldCollection.Add("Hosts")
        With AuditTrail
            ValueCollection.Clear()
            ValueCollection.Add(.KdAuditTrail)
            ValueCollection.Add(CSQLDateTime(.TglInput))
            ValueCollection.Add(CSQL(.Username))
            ValueCollection.Add(CSQL(.Operations))
            ValueCollection.Add(CSQL(.Modules))
            ValueCollection.Add(CSQL(.Actions))
            ValueCollection.Add(CSQL(.Hosts))
        End With
    End Sub

    Private Sub SaveListDetailAuditTrails(ByVal LAuditTrailDets As List(Of AuditTrailDet))
        Gconn.Execute()
        SetSaveListAuditTrailDet(LAuditTrailDets)
    End Sub
    Private Sub OnSave(ByVal LAuditTrailDets As List(Of AuditTrailDet))
        Gconn.StringQuery = Qinsert("AuditTrail", FieldCollection, ValueCollection)
        SaveListDetailAuditTrails(LAuditTrailDets)
    End Sub
    Public Sub SetSaveAuditTrail(AuditTrail As AuditTrail, Tipe As CRUD)
        Dim LAuditTrailDets = SetBuildAuditTrailDets(AuditTrail.KdAuditTrail)
        SetFieldValueAuditTrail(AuditTrail)
        If Tipe = CRUD.ON_SAVE Then
            OnSave(LAuditTrailDets)
        Else
            Throw New Exception("Methode not implement")
        End If
    End Sub

    Private Function SetBuildAuditTrailDets(kodeAudit As Integer) As List(Of AuditTrailDet)
        Dim temp As New List(Of AuditTrailDet)

        For i = 0 To FieldCollection.Count - 1
            Dim auditraildet As New AuditTrailDet
            With auditraildet
                .Fields = FieldCollection(i)
                If OldValueCollection.Count > 0 Then
                    .OldValues = NN(OldValueCollection(i))
                Else
                    .OldValues = "''"
                End If
                If ValueCollection.Count > 0 Then
                    .NewValues = ValueCollection(i)
                Else
                    .NewValues = "''"
                End If
                .KdAudit = kodeAudit
                temp.Add(auditraildet)
            End With
        Next
        Return temp
    End Function
End Class