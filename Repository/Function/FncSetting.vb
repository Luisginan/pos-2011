Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Partial Class PublicFunction
    Public Function GetListT_Setting() As List(Of T_Setting)
        Dim temp As New List(Of T_Setting)
        Gconn.StringQuery = QSelect("T_Setting") &
                            AddCriteria(Equal("IsStatus", 1))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValueT_Setting)
            Gconn.NextRow()
        Next
        Return temp
    End Function
    Public Function GetSingleT_Setting(TName As String) As T_Setting
        Dim temp As New T_Setting
        Gconn.StringQuery = QSelect("T_Setting") & _
                            AddCriteria(Equal("TName", CSQL(TName)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        temp = SetValueT_Setting()
        Return temp
    End Function
    Public Sub SetFieldValueT_Setting(T_Setting As T_Setting)
        FieldCollection.Clear()
        FieldCollection.Add("TName")
        FieldCollection.Add("TValue")
        With T_Setting
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.Tname))
            ValueCollection.Add(CSQL(.TValue))
        End With
    End Sub
    Private Sub Execute(ByVal T_Setting As T_Setting, ByVal Tipe As CRUD)
        If Tipe = CRUD.ON_SAVE Then
            Gconn.StringQuery = Qinsert("T_Setting", FieldCollection, ValueCollection)
            MessageText = MSGDataSave
        ElseIf Tipe = CRUD.ON_UPDATE Then
            Gconn.StringQuery = QUpdate("T_Setting", FieldCollection, ValueCollection) &
                                AddCriteria(Equal("TName", CSQL(T_Setting.Tname)))
            MessageText = MSGDataUpdate
        ElseIf Tipe = CRUD.ON_DELETE Then
            Gconn.StringQuery = QUpdate("T_Setting", "IsStatus=0" & _
                                AddCriteria(Equal("TName", CSQL(T_Setting.Tname))))
            MessageText = MSGDataDelete
        End If
    End Sub
    Private Function SetValueT_Setting()
        Dim temp As New T_Setting
        With temp
            .Tname = NN(Gconn("TName"))
            .TValue = NN(Gconn("TValue"))
        End With
        Return temp
    End Function
End Class