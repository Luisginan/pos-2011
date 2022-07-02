Imports SEMICO_Dialog
Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Commonly
Imports System.Data.SqlClient
Imports BPRoc_LIB.My
Partial Class PublicFunction
    Private Const TABLE_PENJUALAN As String = "Penjualan"
    Private Const FIELD_KD_FAKTUR_PENJ As String = "kdfakturPenj"
    Public Function GetGenerateKdFakturPenj() As String
        Dim temp As String
        Gconn.StringQuery = QSelectCOUNT(FIELD_KD_FAKTUR_PENJ, TABLE_PENJUALAN) & _
                            AddCriteria(EqualDateToday("tglInput"))
        Gconn.Execute()
        If Gconn(0) = 0 Then
            temp = String.Format("FP{0:ddMMyyyy}000001", Date.Today)
        Else
            Gconn.StringQuery = "SELECT MAX(cast(RIGHT(kdFakturPenj,6) AS INT)) + 1 AS MaxNum  FROM penjualan " & _
                                AddCriteria(EqualDateToday("tglinput"))
            Gconn.Execute()
            temp = String.Format("FP{0:ddMMyyyy}{1}", Date.Today, Format(Gconn(0), "000000"))
        End If
        Return temp
    End Function

    Public Function FindPenjualan() As Penjualan
        Dim temp As New Penjualan
        Using Fnd As New DialogCariData()
            Fnd.StringConection = ConectionString
            Fnd.Table = TABLE_PENJUALAN
            Fnd.TITLE = "Find Transaction Selling"
            Fnd.Field1 = FIELD_KD_FAKTUR_PENJ
            Fnd.Field2 = "TglJual"
            Fnd.DisplayField1 = "Faktur Code"
            Fnd.DisplayField2 = "Date "
            Fnd.IndexFocus = 1
            Fnd.AutoQuery = True
            Fnd.Criteria = STR_IsStatusTrue
            Fnd.ShowDialog()
            If Fnd.HasValue Then
                temp = GetSinglePenjualan(Fnd.Value)
                HasValue = True
                HasError = False
            Else
                HasError = True
                HasValue = False
            End If
        End Using
        Return temp
    End Function

    Public Function GetSinglePenjualan(kdfaktur As String) As Penjualan
        Gconn.StringQuery = QSelect(TABLE_PENJUALAN) & AddCriteria(Equal(FIELD_KD_FAKTUR_PENJ, CSQL(kdfaktur)))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        Return SetValuePenjualan()
    End Function

    Public Sub SetFieldValuePEnjualan(penjualan As Penjualan)
        FieldCollection.Clear()
        FieldCollection.Add(FIELD_KD_FAKTUR_PENJ)
        FieldCollection.Add("TglJual")
        FieldCollection.Add("Jam")
        FieldCollection.Add("TotalBayar")
        FieldCollection.Add("UserName")
        FieldCollection.Add("TglInput")
        FieldCollection.Add("TglUpdate")
        FieldCollection.Add("FormName")
        FieldCollection.Add("IsStatus")
        FieldCollection.Add("Customer")
        With penjualan
            ValueCollection.Clear()
            ValueCollection.Add(CSQL(.KdFakturPenj))
            ValueCollection.Add(CSQLDateTime(.TglJual))
            ValueCollection.Add(CSQL(.Jam.ToString("HH:mm:ss")))
            ValueCollection.Add(CSQL(.TotalBayar))
            ValueCollection.Add(CSQL(.UserName))
            ValueCollection.Add(CSQLDateTime(.TglInput))
            ValueCollection.Add(CSQLDateTime(.TglUpdate))
            ValueCollection.Add(CSQL(.FormName))
            ValueCollection.Add(CInt(.IsStatus))
            ValueCollection.Add(CSQL(.Customer))
        End With
    End Sub
    Public Sub SetOldValuePenjualan(Penjualan As Penjualan)
        If Penjualan Is Nothing Then Return
        With Penjualan
            OldValueCollection.Clear()
            OldValueCollection.Add(CSQL(.KdFakturPenj))
            OldValueCollection.Add(CSQLDateTime(.TglJual))
            OldValueCollection.Add(CSQL(.Jam))
            OldValueCollection.Add(CSQL(.TotalBayar))
            OldValueCollection.Add(CSQL(.UserName))
            OldValueCollection.Add(CSQLdate(.TglInput))
            OldValueCollection.Add(CSQLdate(.TglUpdate))
            OldValueCollection.Add(CSQL(.FormName))
            OldValueCollection.Add(CInt(.IsStatus))
            OldValueCollection.Add(CSQL(.Customer))
        End With
    End Sub
    Private Sub OnSave(ByVal Penjualan As Penjualan)
        Try
            Gconn.BeginsTrans()
            Gconn.StringQuery = Qinsert(TABLE_PENJUALAN, FieldCollection, ValueCollection)
            Gconn.Execute()
            SetSaveListPenjualanDet(Penjualan.PenjualanDets)
            Gconn.CommitTrans()
            MessageText = MSGDataSave
        Catch ex As Exception
            Gconn.RollBackTrans()
            Throw
        End Try
    End Sub
    Private Sub OnUpdate(ByVal Penjualan As Penjualan)
        Try
            Gconn.BeginsTrans()
            Gconn.StringQuery = QUpdate(TABLE_PENJUALAN, FieldCollection, ValueCollection) &
                                AddCriteria(Equal(FIELD_KD_FAKTUR_PENJ, CSQL(Penjualan.KdFakturPenj)))
            Gconn.Execute()
            SetSaveListPenjualanDet(Penjualan.PenjualanDets)
            Gconn.CommitTrans()
            MessageText = MSGDataUpdate
        Catch ex As Exception
            Gconn.RollBackTrans()
            Throw
        End Try
    End Sub
    Private Sub OnDelete(ByVal Penjualan As Penjualan)
        Gconn.BeginsTrans()
        Gconn.StringQuery = QUpdate(TABLE_PENJUALAN, "IsStatus=0 , tglupdate = getdate()") &
                            AddCriteria(Equal(FIELD_KD_FAKTUR_PENJ, CSQL(Penjualan.KdFakturPenj)))
        Gconn.Execute()
        SetDeleteLisPenjualanDet(Penjualan.KdFakturPenj)
        Gconn.CommitTrans()
        MessageText = MSGDataDelete
    End Sub
    Public Sub SetSavePenjualan(Penjualan As Penjualan, Tipe As CRUD)
        SetFieldValuePEnjualan(Penjualan)
        If Tipe = CRUD.ON_SAVE Then
            OnSave(Penjualan)
        ElseIf Tipe = CRUD.ON_UPDATE Then
            OnUpdate(Penjualan)
        ElseIf Tipe = CRUD.ON_DELETE Then
            OnDelete(Penjualan)
        End If
    End Sub
    Private Function SetValuePenjualan() As Penjualan
        Dim temp As New Penjualan
        With temp
            .KdFakturPenj = NN(Gconn(FIELD_KD_FAKTUR_PENJ))
            .TglJual = NDD(Gconn("TglJual"))
            .Jam = NN(Gconn("Jam"))
            .TotalBayar = NN(Gconn("TotalBayar"))
            .UserName = NN(Gconn("UserName"))
            .TglInput = NDD(Gconn("TglInput"))
            .TglUpdate = NDD(Gconn("TglUpdate"))
            .FormName = NN(Gconn("FormName"))
            .IsStatus = NN(Gconn("IsStatus"))
            .Customer = NN(Gconn("customer"))
        End With
        Return temp
    End Function
End Class