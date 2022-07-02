Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Partial Class PublicFunction
    Private Function SetValueReportvw_laporanPenjualan() As Vw_laporanPenjualan
        Dim temp As New Vw_laporanPenjualan
        With temp
            .KdFakturPenj = NN(Gconn("KdFakturPenj"))
            .TglJual = NN(Gconn("TglJual"))
            .UserName = NN(Gconn("UserName"))
            .Nama = NN(Gconn("Nama"))
            .Kdsatuan = NN(Gconn("kdsatuan"))
            .Qty = NN(Gconn("Qty"))
            .HargaJual = NN(Gconn("HargaJual"))
            .Laba = NN(Gconn("laba"))
            .Total = NN(Gconn("Total"))
            .Customer = NN(Gconn("Customer"))
        End With
        Return temp
    End Function
    Public Function GetListvw_laporanPenjualan(Optional Kriteria As String = "") As IList(Of Vw_laporanPenjualan)
        Dim temp As New List(Of Vw_laporanPenjualan)
        Gconn.StringQuery = QSelect("vw_laporanPenjualan") & IIf(Kriteria = "", "", Kriteria)
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValueReportvw_laporanPenjualan)
            Gconn.NextRow()
        Next
        Return temp
    End Function
End Class