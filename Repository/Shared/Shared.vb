Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports SEMICO_Dialog.ClsQuickCode
Imports SEMICO_Dialog.ClsMessage
Public Class SharedFunction
    Shared Fnc As New PublicFunction
    Private Shared _control As Control
    Public Shared ReadOnly Property ServerName
        Get
            Dim svr = Split(BPRoc_LIB.My.MySettings.Default.Server, "\")
            If svr.Count > 0 Then
                Return svr(0)
            Else
                Return BPRoc_LIB.My.MySettings.Default.Server
            End If
        End Get
    End Property
    Public Shared ReadOnly Property GetStatusRegisterdHost(HostName) As Boolean
        Get
            Dim StsReg = False
            Dim Fnc As New PublicFunction
            Fnc.GetSingleHostReg(HostName)
            If Fnc.HasError = False Then
                StsReg = True
            Else
                StsReg = False
            End If
            Return StsReg
        End Get
    End Property
    Public Shared Function GetLevelUser(username As String) As USER_LEVEL
        Dim temp As USER_LEVEL
        Dim tuser = Fnc.GetSingleT_user(username)
        If tuser.LevelUser.ToUpper = "SUPERVISOR" Then
            temp = USER_LEVEL.SUPERVISOR
        Else
            temp = USER_LEVEL.USER_ENTRY
        End If
        Return temp
    End Function
    Public Shared ReadOnly Property ControlError() As Control
        Get
            Return _control
        End Get
    End Property
    Public Shared Function FormatMoney(money As Double) As String
        Dim temp As String = "'"
        temp = Format(money, "##,0")
        Return temp
    End Function
    Public Shared ReadOnly Property ControlErrorName() As String
        Get
            Return ControlError.Name.Replace("txt", "").Replace("NU", "")
        End Get
    End Property
    Public Shared Function SetFixChar(charx As String, width As Integer) As String
        Dim temp As New System.Text.StringBuilder
        Dim Len = charx.Length
        If Len = width Then
            Return charx
        End If
        If Len > width Then
            charx = charx.Substring(0, width)
            Return charx
        End If
        temp.Append(charx)
        For i = 0 To width - (Len + 1)
            temp.Append(" ")
        Next
        Return temp.ToString
    End Function
    Public Shared Sub cetakdot(InputPenjual As BPRoc_LIB.EntitiesModel.Penjualan, Optional paidOut As Double = 0)
        Using SerialPort1 As New System.IO.Ports.SerialPort()
            Try
                If SerialPort1.IsOpen Then
                    SerialPort1.Close()
                End If
                SerialPort1.PortName = "COM1"
                SerialPort1.BaudRate = 9600
                SerialPort1.Parity = IO.Ports.Parity.None
                SerialPort1.StopBits = IO.Ports.StopBits.One
                SerialPort1.DataBits = 8
                SerialPort1.Open()
                With InputPenjual
                    SerialPort1.WriteLine("========================================")
                    SerialPort1.WriteLine("               M A N D I R I            ")
                    SerialPort1.WriteLine("              ---------------           ")
                    SerialPort1.WriteLine("Jl.Tata Surya No.29 Metro Margahayu Raya")
                    SerialPort1.WriteLine("               B A N D U N G    ")
                    SerialPort1.WriteLine("           Telp. 7530529 / 70356714     ")
                    SerialPort1.WriteLine("----------------------------------------")
                    SerialPort1.WriteLine(" No faktur  : " & .KdFakturPenj)
                    SerialPort1.WriteLine(" Tanggal    : " & .TglJual.ToShortDateString)
                    SerialPort1.WriteLine(" Jam        : " & .Jam.ToString("hh:mm:ss"))
                    If .Customer <> "" Then
                        SerialPort1.WriteLine(" Customer   : " & .Customer)
                    End If
                    SerialPort1.WriteLine(" Operator   : " & .UserName)
                    SerialPort1.WriteLine("----------------------------------------")
                    SerialPort1.WriteLine("Nama Barang Qty  Stn   Harga   Jumlh(Rp)")
                    SerialPort1.WriteLine("----------------------------------------")
                    For X = 0 To .PenjualanDets.Count - 1
                        Dim PD = .PenjualanDets(X)
                        Dim nama = SetFixChar(PD.Nama, 11)
                        Dim qty = SetFixChar(PD.Qty, 3)
                        Dim satuan = SetFixChar(PD.Kdsatuan, 3)
                        Dim harga = SetFixChar(PD.HargaJual, 6)
                        Dim total = SetFixChar(PD.Total, 7)
                        Dim item = String.Format("{0} {1}  {2}   {3}  {4}", nama, qty, satuan, harga, total)
                        SerialPort1.WriteLine(item)
                        If X Mod 20 = 0 Then
                            System.Threading.Thread.Sleep(4000)
                        End If
                    Next
                    SerialPort1.WriteLine("----------------------------------------")
                    SerialPort1.WriteLine("Jumlah Barang  : " & .PenjualanDets.Count.ToString)
                    SerialPort1.WriteLine("Total          : Rp. " & .TotalBayar.ToString)
                    If paidOut > 0 Then
                        SerialPort1.WriteLine("Dibayarkan     : Rp. " & paidOut.ToString)
                        SerialPort1.WriteLine("Kembalian       : Rp. " & (paidOut - .TotalBayar).ToString)
                    End If
                    SerialPort1.WriteLine("========================================")
                    SerialPort1.WriteLine("              Terima Kasih              ")
                    SerialPort1.WriteLine("========================================")
                    SerialPort1.WriteLine("")
                    SerialPort1.WriteLine("")
                    SerialPort1.WriteLine("")
                    SerialPort1.WriteLine("")
                    SerialPort1.WriteLine("")
                    SerialPort1.WriteLine("")
                End With
                SerialPort1.Close()
            Catch ex As Exception
                SerialPort1.Close()
                InfoMessage(ex.Message)
            End Try
        End Using
    End Sub
    Public Shared Sub CetakFile(InputPenjual As BPRoc_LIB.EntitiesModel.Penjualan, Optional paidOut As Double = 0)
        Dim stringItem As New System.Text.StringBuilder
        With InputPenjual
            stringItem.AppendLine("========================================")
            stringItem.AppendLine("               M A N D I R I            ")
            stringItem.AppendLine("              ---------------           ")
            stringItem.AppendLine("Jl.Tata Surya No.29 Metro Margahayu Raya")
            stringItem.AppendLine("               B A N D U N G    ")
            stringItem.AppendLine("           Telp. 7530529 / 70356714     ")
            stringItem.AppendLine("----------------------------------------")
            stringItem.AppendLine(" No faktur  : " & .KdFakturPenj)
            stringItem.AppendLine(" Tanggal    : " & .TglJual.ToShortDateString)
            stringItem.AppendLine(" Jam        : " & .Jam.ToString("hh:mm:ss"))
            If .Customer <> "" Then
                stringItem.AppendLine(" Customer   : " & .Customer)
            End If
            stringItem.AppendLine(" Operator   : " & .UserName)
            stringItem.AppendLine("----------------------------------------")
            stringItem.AppendLine("Nama Barang Qty  Stn   Harga   Jumlh(Rp)")
            stringItem.AppendLine("----------------------------------------")
            For X = 0 To .PenjualanDets.Count - 1
                Dim PD = .PenjualanDets(X)
                Dim nama = SetFixChar(PD.Nama, 11)
                Dim qty = SetFixChar(PD.Qty, 3)
                Dim satuan = SetFixChar(PD.Kdsatuan, 3)
                Dim harga = SetFixChar(PD.HargaJual, 6)
                Dim total = SetFixChar(PD.Total, 7)
                Dim item = String.Format("{0} {1}  {2}   {3}  {4}", nama, qty, satuan, harga, total)
                stringItem.AppendLine(item)
            Next
            stringItem.AppendLine("----------------------------------------")
            'rev keyboard ------------------------------------------------------------------
            stringItem.AppendLine("Jumlah Barang  : " & .PenjualanDets.Count.ToString)
            '#------------------------------------------------------------------------------
            stringItem.AppendLine("Total          : Rp. " & .TotalBayar.ToString)
            If paidOut > 0 Then
                stringItem.AppendLine("Dibayarkan     : Rp. " & paidOut.ToString)
                stringItem.AppendLine("Kembalian      : Rp. " & (paidOut - .TotalBayar).ToString)
            End If
            stringItem.AppendLine("========================================")
            stringItem.AppendLine("              Terima Kasih              ")
            stringItem.AppendLine("========================================")
            stringItem.AppendLine("")
            stringItem.AppendLine("")
            stringItem.AppendLine("")
            stringItem.AppendLine("")
            stringItem.AppendLine("")
            stringItem.AppendLine("")
        End With
        SEMICO_Dialog.ClsFile.WriteTXT(AppPath("File.txt"), stringItem.ToString)
        Process.Start(AppPath("File.txt"))
    End Sub
    Public Shared Sub BindAllControl(ByRef Grp As Control, ByVal datasource As Object)
        If TypeOf datasource Is DataRow Then
            Dim DT As New DataTable
            Dim DR As DataRow = datasource
            DT = DR.Table.Copy
            datasource = DT
        End If
        Dim BS As New BindingSource() With {.DataSource = datasource}
        Dim ctrl As Control
        For Each i In Grp.Controls
            ctrl = i
            i.DataBindings.Clear()
            If ctrl.Tag = "" Then Continue For
            Try
                If TypeOf (i) Is RadTextBox Then
                    Dim tb As RadTextBox = i
                    tb.DataBindings.Add("Text", BS, tb.Tag)
                ElseIf TypeOf (i) Is RadDropDownList Then
                    Dim tb As RadDropDownList = i
                    tb.DataBindings.Add("Text", BS, tb.Tag)
                ElseIf TypeOf (i) Is NumericUpDown Then
                    Dim tb As NumericUpDown = i
                    tb.DataBindings.Add("value", BS, tb.Tag)
                ElseIf TypeOf (i) Is RadDateTimePicker Then
                    Dim tb As RadDateTimePicker = i
                    tb.DataBindings.Add("value", BS, tb.Tag)
                ElseIf TypeOf (i) Is RadCheckBox Then
                    Dim tb As RadCheckBox = i
                    tb.DataBindings.Add("checked", BS, tb.Tag)
                ElseIf TypeOf (i) Is RadRadioButton Then
                    Dim tb As RadRadioButton = i
                    tb.DataBindings.Add("checked", BS, tb.Tag)
                ElseIf TypeOf (i) Is RadGridView Then
                    Dim tb As RadGridView = i
                    tb.DataSource = BS
                End If
            Catch ex As Exception
                _control = ctrl
            End Try
        Next
    End Sub
    Public Shared Sub clearFormRadTextBox(ByRef FRM As Control)
        Dim control As Control
        Dim LControl As Control.ControlCollection = FRM.Controls
        For Each control In LControl
            If TypeOf control Is RadTextBox Then
                control.Text = ""
            End If
        Next
    End Sub
    Public Shared Sub ClearRadDateTimePicker(ByRef FRM As Control)
        Dim control As Control
        For Each control In FRM.Controls
            If TypeOf control Is RadDateTimePicker Then
                Dim DTP As RadDateTimePicker = control
                DTP.Value = Date.Today
            End If
        Next
    End Sub
    Public Shared Sub ClearRadGridView(ByRef FRM As Control)
        Dim control As Control
        For Each control In FRM.Controls
            If TypeOf control Is RadGridView Then
                Dim DG As RadGridView = control
                Try
                    DG.Rows.Clear()
                Catch ex As Exception

                    DG.DataSource = Nothing
                End Try
            End If
        Next
    End Sub
    Public Shared Sub ClearNumericUpDown(ByRef FRM As Control)
        Dim control As Control
        For Each control In FRM.Controls
            If TypeOf control Is NumericUpDown Then
                Dim DG As NumericUpDown = control
                DG.Value = 0
            End If
        Next
    End Sub
    Public Shared Sub EnableAllControl(ByRef FRM As Control, Optional ByVal Status As Boolean = False)
        Dim control As Control
        For Each control In FRM.Controls
            If TypeOf control Is RadLabel Then Continue For
            If TypeOf control Is RadGroupBox Or TypeOf control Is RadPanel Then Continue For
            If TypeOf control Is RadTextBox Then
                Dim txt As RadTextBox = control
                txt.ReadOnly = Not Status
            Else
                control.Enabled = Status
            End If
        Next
    End Sub
    Public Shared Sub ClearAllRadControl(ByRef FRM As Control)
        Dim control As Control
        For Each control In FRM.Controls
            control.DataBindings.Clear()
            If TypeOf control Is RadGroupBox Or TypeOf control Is RadPanel Then
                ClearAllRadControl(control)
            ElseIf TypeOf control Is RadTextBox Then
                clearFormRadTextBox(FRM)
            ElseIf TypeOf control Is RadGridView Then
                ClearRadGridView(FRM)
            ElseIf TypeOf control Is NumericUpDown Then
                ClearNumericUpDown(FRM)
            ElseIf TypeOf control Is RadDateTimePicker Then
                ClearRadDateTimePicker(FRM)
            End If
        Next
    End Sub
    Public Shared Function AllAntiNullRad(ByRef FRM As Control) As Boolean
        Dim status As Boolean = True
        If RadTeksboxAntiNull(FRM) = False Then
            status = False
        ElseIf RadComboBoxAntiNull(FRM) = False Then
            status = False
        ElseIf NumericUpDownAntiNull(FRM) = False Then
            status = False
        ElseIf RadGridAntiNull(FRM) = False Then
            status = False
        End If
        Return status
    End Function
    Public Shared Function RadTeksboxAntiNull(ByRef FRM As Control) As Boolean
        Dim status As Boolean = True
        Dim ctrl As Control
        For Each ctrl In FRM.Controls
            If TypeOf ctrl Is RadTextBox Then
                If ctrl.Text = "" Or ctrl.Text.Length = 0 Then
                    _control = ctrl
                    status = False
                    Exit For
                End If
            End If
        Next
        Return status
    End Function
    Public Shared Function RadComboBoxAntiNull(ByRef FRM As Control) As Boolean
        Dim status As Boolean = True
        Dim ctrl As Control
        For Each ctrl In FRM.Controls
            If TypeOf ctrl Is RadDropDownList Then
                Dim CBO As RadDropDownList = ctrl
                If CBO.Text = "" Or CBO.SelectedIndex = -1 Then
                    _control = ctrl
                    status = False
                    Exit For
                End If
            End If
        Next
        Return status
    End Function
    Public Shared Function RadGridAntiNull(ByRef FRM As Control) As Boolean
        Dim status As Boolean = True
        Dim ctrl As Control
        For Each ctrl In FRM.Controls
            If TypeOf ctrl Is RadGridView Then
                Dim DGV As RadGridView = ctrl
                If DGV.RowCount = 0 Then
                    _control = ctrl
                    status = False
                    Exit For
                End If
            End If
        Next
        Return status
    End Function
    Public Shared Function NumericUpDownAntiNull(ByRef FRM As Control) As Boolean
        Dim status As Boolean = True
        Dim ctrl As Control
        For Each ctrl In FRM.Controls
            If TypeOf ctrl Is NumericUpDown Then
                Dim NUD As NumericUpDown = ctrl
                If NUD.Value <= 0 Then
                    _control = ctrl
                    status = False
                    Exit For
                End If
            End If
        Next
        Return status
    End Function
    Public Shared Sub clearFormRadComboBox(ByRef FRM As Control)
        Dim control As Control
        For Each control In FRM.Controls
            If TypeOf control Is RadDropDownList Then
                Dim combo As RadDropDownList = control
                combo.SelectedIndex = -1
                If combo.Text <> "" Then
                    combo.Text = ""
                End If
            End If
        Next
    End Sub
    Public Shared Sub InputOnlyNumeric(ByRef e As KeyPressEventArgs, Optional ByVal AllowMinus As Boolean = False)
        If Not IsNumeric(e.KeyChar) Then
            If AllowMinus = False Then
                If Not ((e.KeyChar = ".") Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13) Then
                    e.KeyChar = Chr(Keys.None)
                End If
            Else
                If Not ((e.KeyChar = ".") Or (e.KeyChar = "-") Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13) Then
                    e.KeyChar = Chr(Keys.None)
                End If
            End If
        End If
    End Sub
End Class