Imports BPRoc_LIB
Imports SEMICO_Dialog.ClsMessage
Imports SEMICO_Dialog.ClsQueryBuilder

Public Class Frm_ReportOptionSelling
    Dim Fnc As New PublicFunction
    Public Property MOde As CASHIER_MODE = CASHIER_MODE.ON_DEFAULT
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim Criteria As String = ""
            If PV.SelectedPage Is PByDatePeriode Then
                Criteria = AddCriteria(BetweenDate("tglJual", String.Format("{0:yyyy-MM-dd} {1}:00:00", DDperiodeStart.Value, DDHourStart.Text), String.Format("{0:yyyy-MM-dd} {1}:00:00", DTperiodeEnd.Value, DDHourEnd.Text)))

                If txtCustomerByPeriode.Text <> "" Then
                    Criteria += AddAndCriteria(Equal("customer", CSQL(txtCustomerByPeriode.Text)))
                End If

                If txtUserByPeriode.Text <> "" Then
                    Criteria += AddAndCriteria(Equal("username", CSQL(txtUserByPeriode.Text)))
                End If

            ElseIf PV.SelectedPage Is PbyMonth Then
                If DDyearByMonth.Text <> "" Then
                    Criteria = AddCriteria(Equal("Year(tglJual)", DDyearByMonth.SelectedValue))
                Else
                    Throw New Exception("Year canot be blank")
                End If
                If DDMonthByMonth.Text <> "" Then
                    Criteria += AddAndCriteria(Equal("Month(tglJual)", DDMonthByMonth.SelectedValue))
                End If

                If txtCustomerByMonth.Text <> "" Then
                    Criteria += AddAndCriteria(Equal("customer", CSQL(txtCustomerByMonth.Text)))
                End If

                If txtUserByMonth.Text <> "" Then
                    Criteria += AddAndCriteria(Equal("username", CSQL(txtUserByMonth.Text)))
                End If
            ElseIf PV.SelectedPage Is PbyFaktur Then
                If txtNoFaktur.Text <> "" Then
                    Criteria = AddCriteria(Equal("kdFakturPenj", CSQL(txtNoFaktur.Text)))
                Else
                    Throw New Exception("Faktur canot be blank")
                End If
            End If

            If MOde = CASHIER_MODE.ON_CANCELATION Then
                Criteria += " and IsStatus=0"
            Else
                Criteria += " and IsStatus=1"
            End If

            Using Rpt As New Frm_reportSelling() With {.Criteria = Criteria}
                Rpt.ShowDialog()
            End Using
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try

    End Sub

    Private Sub RadForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim index = 0
        For i = Today.Year To Today.Year - 5 Step -1
            DDyearByMonth.Items.Insert(index, New Telerik.WinControls.UI.RadListDataItem With {.Text = i, .Value = i.ToString})
            index += 1
        Next
        For i = 0 To 24
            DDHourStart.Items.Add(i.ToString("00"))
            DDHourEnd.Items.Add(i.ToString("00"))
        Next
        index = 0
        For i = 1 To 12
            DDMonthByMonth.Items.Insert(index, New Telerik.WinControls.UI.RadListDataItem With {.Text = i, .Value = i.ToString})
        Next
    End Sub

    Private Sub btnFindFaktur_Click(sender As Object, e As EventArgs) Handles btnFindFaktur.Click
        Try
            Dim Penjualan = Fnc.FindPenjualan
            If Fnc.HasValue = True Then
                txtNoFaktur.Text = Penjualan.KdFakturPenj
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnFindCustomerByPeriode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFindCustomerByPeriode.Click
        Dim Customer = Fnc.FindPelanggan
        If Fnc.HasValue = False Then Exit Sub
        txtCustomerByPeriode.Text = Customer.Nmplgn
    End Sub

    Private Sub BtnFindCustomerByMonth_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFindCustomerByMonth.Click
        Dim Customer = Fnc.FindPelanggan
        If Fnc.HasValue = False Then Exit Sub
        txtCustomerByMonth.Text = Customer.Nmplgn
    End Sub

    Private Sub btnFindUserByPeriode_Click(sender As Object, e As EventArgs) Handles btnFindUserByPeriode.Click
        Dim users = Fnc.FindT_user
        If Fnc.HasValue = False Then Exit Sub
        txtUserByPeriode.Text = users.UserName
    End Sub

    Private Sub BtnFindUserByMonth_Click(sender As Object, e As EventArgs) Handles BtnFindUserByMonth.Click
        Dim users = Fnc.FindT_user
        If Fnc.HasValue = False Then Exit Sub
        txtUserByMonth.Text = users.UserName
    End Sub
End Class