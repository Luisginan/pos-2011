Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Partial Class PublicFunction
    Public Function GetSingleHostReg(HostName As String) As HostReg
        Dim temp As New HostReg
        Gconn.StringQuery = QSelect("HostReg") & _
                            AddCriteria(Equal("HostName", CSQL(HostName)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception("Host is not registered")
        temp = SetValueHostReg()
        Return temp
    End Function
    Private Function SetValueHostReg()
        Dim temp As New HostReg
        With temp
            .HostName = NN(Gconn("HostName"))
            .DescReg = NN(Gconn("DescReg"))
            .DateReg = NDD(Gconn("DateReg"))
            .IsStatus = NN(Gconn("IsStatus"))
        End With
        Return temp
    End Function
End Class