<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ReportOptionSelling
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PV = New Telerik.WinControls.UI.RadPageView()
        Me.PByDatePeriode = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.btnFindCustomerByPeriode = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCustomerByPeriode = New Telerik.WinControls.UI.RadTextBox()
        Me.DDHourEnd = New Telerik.WinControls.UI.RadDropDownList()
        Me.DDHourStart = New Telerik.WinControls.UI.RadDropDownList()
        Me.DTperiodeEnd = New System.Windows.Forms.DateTimePicker()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.DDperiodeStart = New System.Windows.Forms.DateTimePicker()
        Me.PbyMonth = New Telerik.WinControls.UI.RadPageViewPage()
        Me.BtnFindCustomerByMonth = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCustomerByMonth = New Telerik.WinControls.UI.RadTextBox()
        Me.DDMonthByMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.DDyearByMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.PbyFaktur = New Telerik.WinControls.UI.RadPageViewPage()
        Me.btnFindFaktur = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.txtNoFaktur = New Telerik.WinControls.UI.RadTextBox()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.RadMenuButtonItem1 = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnFindUserByPeriode = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.txtUserByPeriode = New Telerik.WinControls.UI.RadTextBox()
        Me.BtnFindUserByMonth = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.txtUserByMonth = New Telerik.WinControls.UI.RadTextBox()
        CType(Me.PV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PV.SuspendLayout()
        Me.PByDatePeriode.SuspendLayout()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFindCustomerByPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomerByPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DDHourEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DDHourStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PbyMonth.SuspendLayout()
        CType(Me.BtnFindCustomerByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomerByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DDMonthByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DDyearByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PbyFaktur.SuspendLayout()
        CType(Me.btnFindFaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoFaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFindUserByPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserByPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFindUserByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PV
        '
        Me.PV.Controls.Add(Me.PByDatePeriode)
        Me.PV.Controls.Add(Me.PbyMonth)
        Me.PV.Controls.Add(Me.PbyFaktur)
        Me.PV.Location = New System.Drawing.Point(12, 12)
        Me.PV.Name = "PV"
        Me.PV.SelectedPage = Me.PbyMonth
        Me.PV.Size = New System.Drawing.Size(526, 212)
        Me.PV.TabIndex = 0
        '
        'PByDatePeriode
        '
        Me.PByDatePeriode.Controls.Add(Me.btnFindUserByPeriode)
        Me.PByDatePeriode.Controls.Add(Me.RadLabel6)
        Me.PByDatePeriode.Controls.Add(Me.txtUserByPeriode)
        Me.PByDatePeriode.Controls.Add(Me.RadLabel2)
        Me.PByDatePeriode.Controls.Add(Me.btnFindCustomerByPeriode)
        Me.PByDatePeriode.Controls.Add(Me.RadLabel7)
        Me.PByDatePeriode.Controls.Add(Me.txtCustomerByPeriode)
        Me.PByDatePeriode.Controls.Add(Me.DDHourEnd)
        Me.PByDatePeriode.Controls.Add(Me.DDHourStart)
        Me.PByDatePeriode.Controls.Add(Me.DTperiodeEnd)
        Me.PByDatePeriode.Controls.Add(Me.RadLabel1)
        Me.PByDatePeriode.Controls.Add(Me.DDperiodeStart)
        Me.PByDatePeriode.Location = New System.Drawing.Point(10, 37)
        Me.PByDatePeriode.Name = "PByDatePeriode"
        Me.PByDatePeriode.Size = New System.Drawing.Size(505, 164)
        Me.PByDatePeriode.Text = "By Date Periode"
        '
        'RadLabel2
        '
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Location = New System.Drawing.Point(13, 19)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(32, 18)
        Me.RadLabel2.TabIndex = 2
        Me.RadLabel2.Text = "From"
        '
        'btnFindCustomerByPeriode
        '
        Me.btnFindCustomerByPeriode.Location = New System.Drawing.Point(281, 72)
        Me.btnFindCustomerByPeriode.Name = "btnFindCustomerByPeriode"
        Me.btnFindCustomerByPeriode.Size = New System.Drawing.Size(64, 24)
        Me.btnFindCustomerByPeriode.TabIndex = 12
        Me.btnFindCustomerByPeriode.Text = "..."
        '
        'RadLabel7
        '
        Me.RadLabel7.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel7.Location = New System.Drawing.Point(13, 78)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(55, 18)
        Me.RadLabel7.TabIndex = 11
        Me.RadLabel7.Text = "Customer"
        '
        'txtCustomerByPeriode
        '
        Me.txtCustomerByPeriode.Location = New System.Drawing.Point(74, 76)
        Me.txtCustomerByPeriode.Name = "txtCustomerByPeriode"
        Me.txtCustomerByPeriode.Size = New System.Drawing.Size(200, 20)
        Me.txtCustomerByPeriode.TabIndex = 10
        Me.txtCustomerByPeriode.TabStop = False
        '
        'DDHourEnd
        '
        Me.DDHourEnd.DropDownAnimationEnabled = True
        Me.DDHourEnd.Location = New System.Drawing.Point(281, 44)
        Me.DDHourEnd.Name = "DDHourEnd"
        Me.DDHourEnd.ShowImageInEditorArea = True
        Me.DDHourEnd.Size = New System.Drawing.Size(64, 20)
        Me.DDHourEnd.TabIndex = 4
        Me.DDHourEnd.Text = "00"
        '
        'DDHourStart
        '
        Me.DDHourStart.DropDownAnimationEnabled = True
        Me.DDHourStart.Location = New System.Drawing.Point(281, 17)
        Me.DDHourStart.Name = "DDHourStart"
        Me.DDHourStart.ShowImageInEditorArea = True
        Me.DDHourStart.Size = New System.Drawing.Size(64, 20)
        Me.DDHourStart.TabIndex = 3
        Me.DDHourStart.Text = "00"
        '
        'DTperiodeEnd
        '
        Me.DTperiodeEnd.Location = New System.Drawing.Point(74, 44)
        Me.DTperiodeEnd.Name = "DTperiodeEnd"
        Me.DTperiodeEnd.Size = New System.Drawing.Size(200, 20)
        Me.DTperiodeEnd.TabIndex = 2
        '
        'RadLabel1
        '
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Location = New System.Drawing.Point(13, 45)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(19, 18)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "To"
        '
        'DDperiodeStart
        '
        Me.DDperiodeStart.Location = New System.Drawing.Point(74, 18)
        Me.DDperiodeStart.Name = "DDperiodeStart"
        Me.DDperiodeStart.Size = New System.Drawing.Size(200, 20)
        Me.DDperiodeStart.TabIndex = 0
        '
        'PbyMonth
        '
        Me.PbyMonth.Controls.Add(Me.BtnFindUserByMonth)
        Me.PbyMonth.Controls.Add(Me.RadLabel8)
        Me.PbyMonth.Controls.Add(Me.txtUserByMonth)
        Me.PbyMonth.Controls.Add(Me.BtnFindCustomerByMonth)
        Me.PbyMonth.Controls.Add(Me.RadLabel9)
        Me.PbyMonth.Controls.Add(Me.txtCustomerByMonth)
        Me.PbyMonth.Controls.Add(Me.DDMonthByMonth)
        Me.PbyMonth.Controls.Add(Me.DDyearByMonth)
        Me.PbyMonth.Controls.Add(Me.RadLabel4)
        Me.PbyMonth.Controls.Add(Me.RadLabel3)
        Me.PbyMonth.Location = New System.Drawing.Point(10, 37)
        Me.PbyMonth.Name = "PbyMonth"
        Me.PbyMonth.Size = New System.Drawing.Size(505, 164)
        Me.PbyMonth.Text = "By Month"
        '
        'BtnFindCustomerByMonth
        '
        Me.BtnFindCustomerByMonth.Location = New System.Drawing.Point(228, 72)
        Me.BtnFindCustomerByMonth.Name = "BtnFindCustomerByMonth"
        Me.BtnFindCustomerByMonth.Size = New System.Drawing.Size(43, 24)
        Me.BtnFindCustomerByMonth.TabIndex = 15
        Me.BtnFindCustomerByMonth.Text = "..."
        '
        'RadLabel9
        '
        Me.RadLabel9.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel9.Location = New System.Drawing.Point(18, 76)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(55, 18)
        Me.RadLabel9.TabIndex = 14
        Me.RadLabel9.Text = "Customer"
        '
        'txtCustomerByMonth
        '
        Me.txtCustomerByMonth.Location = New System.Drawing.Point(79, 74)
        Me.txtCustomerByMonth.Name = "txtCustomerByMonth"
        Me.txtCustomerByMonth.Size = New System.Drawing.Size(143, 20)
        Me.txtCustomerByMonth.TabIndex = 13
        Me.txtCustomerByMonth.TabStop = False
        '
        'DDMonthByMonth
        '
        Me.DDMonthByMonth.DropDownAnimationEnabled = True
        Me.DDMonthByMonth.Location = New System.Drawing.Point(79, 45)
        Me.DDMonthByMonth.Name = "DDMonthByMonth"
        Me.DDMonthByMonth.ShowImageInEditorArea = True
        Me.DDMonthByMonth.Size = New System.Drawing.Size(192, 20)
        Me.DDMonthByMonth.TabIndex = 8
        Me.DDMonthByMonth.ThemeName = "ControlDefault"
        '
        'DDyearByMonth
        '
        Me.DDyearByMonth.DropDownAnimationEnabled = True
        Me.DDyearByMonth.Location = New System.Drawing.Point(79, 17)
        Me.DDyearByMonth.Name = "DDyearByMonth"
        Me.DDyearByMonth.ShowImageInEditorArea = True
        Me.DDyearByMonth.Size = New System.Drawing.Size(192, 20)
        Me.DDyearByMonth.TabIndex = 7
        Me.DDyearByMonth.ThemeName = "ControlDefault"
        '
        'RadLabel4
        '
        Me.RadLabel4.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel4.Location = New System.Drawing.Point(18, 19)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(28, 18)
        Me.RadLabel4.TabIndex = 6
        Me.RadLabel4.Text = "Year"
        '
        'RadLabel3
        '
        Me.RadLabel3.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel3.Location = New System.Drawing.Point(18, 47)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel3.TabIndex = 4
        Me.RadLabel3.Text = "Month"
        '
        'PbyFaktur
        '
        Me.PbyFaktur.Controls.Add(Me.btnFindFaktur)
        Me.PbyFaktur.Controls.Add(Me.RadLabel5)
        Me.PbyFaktur.Controls.Add(Me.txtNoFaktur)
        Me.PbyFaktur.Location = New System.Drawing.Point(10, 37)
        Me.PbyFaktur.Name = "PbyFaktur"
        Me.PbyFaktur.Size = New System.Drawing.Size(505, 164)
        Me.PbyFaktur.Text = "By Faktur"
        '
        'btnFindFaktur
        '
        Me.btnFindFaktur.Location = New System.Drawing.Point(282, 11)
        Me.btnFindFaktur.Name = "btnFindFaktur"
        Me.btnFindFaktur.Size = New System.Drawing.Size(43, 24)
        Me.btnFindFaktur.TabIndex = 6
        Me.btnFindFaktur.Text = "..."
        '
        'RadLabel5
        '
        Me.RadLabel5.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel5.Location = New System.Drawing.Point(23, 15)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(37, 18)
        Me.RadLabel5.TabIndex = 5
        Me.RadLabel5.Text = "Faktur"
        '
        'txtNoFaktur
        '
        Me.txtNoFaktur.Location = New System.Drawing.Point(69, 13)
        Me.txtNoFaktur.Name = "txtNoFaktur"
        Me.txtNoFaktur.Size = New System.Drawing.Size(209, 20)
        Me.txtNoFaktur.TabIndex = 0
        Me.txtNoFaktur.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(401, 230)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(126, 24)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "Print"
        '
        'RadMenuButtonItem1
        '
        Me.RadMenuButtonItem1.AccessibleDescription = "1"
        Me.RadMenuButtonItem1.AccessibleName = "1"
        '
        '
        '
        Me.RadMenuButtonItem1.ButtonElement.AccessibleDescription = "1"
        Me.RadMenuButtonItem1.ButtonElement.AccessibleName = "1"
        Me.RadMenuButtonItem1.Name = "RadMenuButtonItem1"
        Me.RadMenuButtonItem1.Text = "1"
        Me.RadMenuButtonItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnFindUserByPeriode
        '
        Me.btnFindUserByPeriode.Location = New System.Drawing.Point(281, 98)
        Me.btnFindUserByPeriode.Name = "btnFindUserByPeriode"
        Me.btnFindUserByPeriode.Size = New System.Drawing.Size(64, 24)
        Me.btnFindUserByPeriode.TabIndex = 15
        Me.btnFindUserByPeriode.Text = "..."
        '
        'RadLabel6
        '
        Me.RadLabel6.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel6.Location = New System.Drawing.Point(13, 104)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(29, 18)
        Me.RadLabel6.TabIndex = 14
        Me.RadLabel6.Text = "User"
        '
        'txtUserByPeriode
        '
        Me.txtUserByPeriode.Location = New System.Drawing.Point(74, 102)
        Me.txtUserByPeriode.Name = "txtUserByPeriode"
        Me.txtUserByPeriode.Size = New System.Drawing.Size(200, 20)
        Me.txtUserByPeriode.TabIndex = 13
        Me.txtUserByPeriode.TabStop = False
        '
        'BtnFindUserByMonth
        '
        Me.BtnFindUserByMonth.Location = New System.Drawing.Point(228, 102)
        Me.BtnFindUserByMonth.Name = "BtnFindUserByMonth"
        Me.BtnFindUserByMonth.Size = New System.Drawing.Size(43, 24)
        Me.BtnFindUserByMonth.TabIndex = 18
        Me.BtnFindUserByMonth.Text = "..."
        '
        'RadLabel8
        '
        Me.RadLabel8.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel8.Location = New System.Drawing.Point(18, 104)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(29, 18)
        Me.RadLabel8.TabIndex = 17
        Me.RadLabel8.Text = "User"
        '
        'txtUserByMonth
        '
        Me.txtUserByMonth.Location = New System.Drawing.Point(79, 102)
        Me.txtUserByMonth.Name = "txtUserByMonth"
        Me.txtUserByMonth.Size = New System.Drawing.Size(143, 20)
        Me.txtUserByMonth.TabIndex = 16
        Me.txtUserByMonth.TabStop = False
        '
        'Frm_ReportOptionSelling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 266)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.PV)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ReportOptionSelling"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Cashier"
        CType(Me.PV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PV.ResumeLayout(False)
        Me.PByDatePeriode.ResumeLayout(False)
        Me.PByDatePeriode.PerformLayout()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFindCustomerByPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomerByPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DDHourEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DDHourStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PbyMonth.ResumeLayout(False)
        Me.PbyMonth.PerformLayout()
        CType(Me.BtnFindCustomerByMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomerByMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DDMonthByMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DDyearByMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PbyFaktur.ResumeLayout(False)
        Me.PbyFaktur.PerformLayout()
        CType(Me.btnFindFaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoFaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFindUserByPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserByPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFindUserByMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserByMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PV As Telerik.WinControls.UI.RadPageView
    Friend WithEvents PByDatePeriode As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents DTperiodeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents DDperiodeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents PbyMonth As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PbyFaktur As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents btnFindFaktur As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtNoFaktur As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadMenuButtonItem1 As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents DDMonthByMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents DDyearByMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents DDHourStart As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents DDHourEnd As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents btnFindCustomerByPeriode As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCustomerByPeriode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents BtnFindCustomerByMonth As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCustomerByMonth As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnFindUserByPeriode As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtUserByPeriode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents BtnFindUserByMonth As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtUserByMonth As Telerik.WinControls.UI.RadTextBox
End Class
