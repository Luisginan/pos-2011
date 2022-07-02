Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Partial Class PublicFunction
    Public Function FindT_user(Optional master As Object = Nothing) As T_User
        Dim temp As New T_User
        Using Fnd As New DialogCariData()
            Fnd.StringConection = ConectionString
            Fnd.Table = "T_user"
            Fnd.TITLE = "Find Category"
            Fnd.Field1 = "UserName"
            Fnd.Field2 = "Leveluser"
            Fnd.DisplayField1 = "Name"
            Fnd.DisplayField2 = "Level"
            Fnd.Criteria = STR_IsStatusTrue
            If master IsNot Nothing Then
                Fnd.InputForm = master
            End If
            Fnd.ShowDialog()
            If Fnd.HasValue Then
                temp = GetSingleT_user(Fnd.Value)
                HasValue = True
            Else
                HasValue = False
            End If
        End Using
        Return temp
    End Function
    Public Function GetListT_user() As List(Of T_User)
        Dim temp As New List(Of T_User)
        Gconn.StringQuery = QSelect("T_user") &
                            AddCriteria(Equal("IsStatus", 1))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValueT_user)
            Gconn.NextRow()
        Next
        Return temp
    End Function
    Public Function GetSingleT_user(UserName As String) As T_User
        Gconn.StringQuery = QSelect("T_user") & _
                            AddCriteria(Equal("UserName", CSQL(UserName)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        Return SetValueT_user()
    End Function
    Public Sub SetFieldValueT_user(T_user As T_User)
        FieldCollection.Clear()
        FieldCollection.Add("UserName")
        FieldCollection.Add("LevelUser")
        FieldCollection.Add("PasswordUser")
        FieldCollection.Add("TglInput")
        FieldCollection.Add("TglUpdate")
        FieldCollection.Add("FormName")
        FieldCollection.Add("IsStatus")
        FieldCollection.Add("UserInput")
        With T_user
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.UserName))
            ValueCollection.Add(CSQL(.LevelUser))
            ValueCollection.Add(CSQL(.PasswordUser))
            ValueCollection.Add(CSQLDateTime(.TglInput))
            ValueCollection.Add(CSQLDateTime(.TglUpdate))
            ValueCollection.Add(CSQL(.FormName))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.UserInput))
        End With
    End Sub
    Public Sub SetOldValueT_User(T_User As T_User)
        If T_User Is Nothing Then Return
        With T_User
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.UserName))
            OldValueCollection.Add(CSQL(.LevelUser))
            OldValueCollection.Add(CSQL(.PasswordUser))
            OldValueCollection.Add(CSQLDateTime(.TglInput))
            OldValueCollection.Add(CSQLDateTime(.TglUpdate))
            OldValueCollection.Add(CSQL(.FormName))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.UserInput))
        End With
    End Sub
    Private Function SetOldValueAuditTrails(ByVal T_user As T_User) As String
        Dim kdT_User = T_user.UserName
        Dim OldT_User = GetSingleT_user(T_user.UserName)
        SetOldValueT_User(OldT_User)
        Return kdT_User
    End Function
    Private Sub Execute(ByVal T_user As T_User, ByVal Tipe As CRUD)
        SetFieldValueT_user(T_user)
        If Tipe = CRUD.ON_SAVE Then
            Gconn.StringQuery = Qinsert("T_user", FieldCollection, ValueCollection)
            MessageText = MSGDataSave
        ElseIf Tipe = CRUD.ON_UPDATE Then
            Gconn.StringQuery = QUpdate("T_user", FieldCollection, ValueCollection) &
            AddCriteria(Equal("UserName", CSQL(T_user.UserName)))
            MessageText = MSGDataUpdate
        ElseIf Tipe = CRUD.ON_DELETE Then
            Gconn.StringQuery = QUpdate("T_user", "IsStatus=0,tglUpdate=getdate(),Username=" & CSQL(T_user.UserName)) &
                                AddCriteria(Equal("UserName", CSQL(T_user.UserName)))
            MessageText = MSGDataDelete
        End If
        Gconn.Execute()
        If Gconn.RowsEffected = 0 Then Throw New Exception(MSGNoDataAffected)
    End Sub
    Private Sub SetNewValueAuditTrail(ByVal T_user As T_User, ByVal Tipe As CRUD, ByVal kdT_User As String)
        SetFieldValueT_user(GetSingleT_user(kdT_User))
        Dim audittrail As New AuditTrail With {.KdAuditTrail = GetGenerateKdAuditTrails(), .Actions = Tipe.ToString, .Hosts = My.Computer.Name, _
                                               .Modules = T_user.FormName, .Operations = "T_User", .TglInput = Now, .Username = T_user.UserInput}
        SetSaveAuditTrail(audittrail, CRUD.ON_SAVE)
    End Sub
    Public Sub SetSaveT_user(ByVal T_user As T_User, ByVal Tipe As CRUD)
        Dim kdT_User As String = SetOldValueAuditTrails(T_user)
        Execute(T_user, Tipe)
        SetNewValueAuditTrail(T_user, Tipe, kdT_User)
    End Sub
    Private Function SetValueT_user()
        Dim temp As New T_User
        With temp
            .UserName = NN(Gconn("UserName"))
            .LevelUser = NN(Gconn("LevelUser"))
            .PasswordUser = NN(Gconn("PasswordUser"))
            .TglInput = NDD(Gconn("TglInput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .UserName = NN(Gconn("UserName"))
            .FormName = NN(Gconn("FormName"))
            .IsStatus = NN(Gconn("IsStatus"))
        End With
        Return temp
    End Function
End Class