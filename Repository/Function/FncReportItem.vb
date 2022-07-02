Imports SEMICO_Dialog.ClsQueryBuilder
Imports BPRoc_LIB.Setting
Imports SEMICO_Dialog.ClsQuickCode
Imports BPRoc_LIB.EntitiesModel
Partial Class PublicFunction
    Private Function SetValueReportvw_laporanBarang() As Vw_LaporanBarang
        Dim temp As New Vw_LaporanBarang
        With temp
            .Nama = NN(Gconn("Nama"))
            .KdKategori = NN(Gconn("kdKategori"))
            .Lokasi = NN(Gconn("Lokasi"))
            .KdSatuan = NN(Gconn("kdSatuan"))
            .Par = NN(Gconn("Par"))
            .HargaJual = NN(Gconn("HargaJual"))
            .HargaBeli = NN(Gconn("HargaBeli"))
            .KdBarang = NN(Gconn("KdBarang"))
        End With
        Return temp
    End Function
    Public Function GetListvw_laporanBarang(Optional Kriteria As String = "") As IList(Of Vw_LaporanBarang)
        Dim temp As New List(Of Vw_LaporanBarang)
        Gconn.StringQuery = QSelect("vw_laporanBarang") & IIf(Kriteria = "", "", AddCriteria(Kriteria))
        Gconn.Execute()
        If Gconn.HasRows = False Then Throw New Exception(MSGNoData)
        For i = 0 To Gconn.RowCount - 1
            temp.Add(SetValueReportvw_laporanBarang)
            Gconn.NextRow()
        Next
        Return temp
    End Function
End Class