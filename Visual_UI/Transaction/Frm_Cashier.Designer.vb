<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cashier
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
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn17 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn18 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn19 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn20 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn21 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Me.RadThemeManager1 = New Telerik.WinControls.RadThemeManager()
        Me.pnlHeader = New Telerik.WinControls.UI.RadPanel()
        Me.lblCustomer = New Telerik.WinControls.UI.RadLabel()
        Me.lblNoTransaction = New Telerik.WinControls.UI.RadLabel()
        Me.ChkClasicMode = New Telerik.WinControls.UI.RadCheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.pnlKet = New Telerik.WinControls.UI.RadPanel()
        Me.lblTotalItem = New Telerik.WinControls.UI.RadLabel()
        Me.lblHarga = New Telerik.WinControls.UI.RadLabel()
        Me.GVITem = New Telerik.WinControls.UI.RadGridView()
        Me.txtBarcode = New Telerik.WinControls.UI.RadTextBox()
        Me.btnAddItem = New Telerik.WinControls.UI.RadButton()
        Me.PnlCommand = New Telerik.WinControls.UI.RadPanel()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.BtnDElete = New Telerik.WinControls.UI.RadButton()
        Me.BtnSave = New Telerik.WinControls.UI.RadButton()
        Me.BtnCancel = New Telerik.WinControls.UI.RadButton()
        Me.BtnAdd = New Telerik.WinControls.UI.RadButton()
        Me.BtnSearch = New Telerik.WinControls.UI.RadButton()
        CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        CType(Me.lblCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkClasicMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlKet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKet.SuspendLayout()
        CType(Me.lblTotalItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblHarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVITem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVITem.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PnlCommand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlCommand.SuspendLayout()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDElete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHeader.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlHeader.Controls.Add(Me.lblCustomer)
        Me.pnlHeader.Controls.Add(Me.lblNoTransaction)
        Me.pnlHeader.Controls.Add(Me.ChkClasicMode)
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.RadLabel1)
        Me.pnlHeader.Location = New System.Drawing.Point(5, 1)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(944, 84)
        Me.pnlHeader.TabIndex = 43
        '
        'lblCustomer
        '
        Me.lblCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCustomer.AutoSize = False
        Me.lblCustomer.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.Black
        Me.lblCustomer.Location = New System.Drawing.Point(375, 18)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(538, 37)
        Me.lblCustomer.TabIndex = 55
        Me.lblCustomer.Text = "..."
        Me.lblCustomer.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNoTransaction
        '
        Me.lblNoTransaction.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoTransaction.Location = New System.Drawing.Point(89, 43)
        Me.lblNoTransaction.Name = "lblNoTransaction"
        Me.lblNoTransaction.Size = New System.Drawing.Size(21, 25)
        Me.lblNoTransaction.TabIndex = 54
        Me.lblNoTransaction.Text = "..."
        '
        'ChkClasicMode
        '
        Me.ChkClasicMode.Location = New System.Drawing.Point(239, 18)
        Me.ChkClasicMode.Name = "ChkClasicMode"
        Me.ChkClasicMode.Size = New System.Drawing.Size(81, 18)
        Me.ChkClasicMode.TabIndex = 53
        Me.ChkClasicMode.Text = "Clasic Mode"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.BProc_UI.My.Resources.Resources.cashbox
        Me.PictureBox1.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(74, 76)
        Me.PictureBox1.TabIndex = 52
        Me.PictureBox1.TabStop = False
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(86, 11)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(149, 33)
        Me.RadLabel1.TabIndex = 44
        Me.RadLabel1.Text = "Mandiri Store"
        '
        'pnlKet
        '
        Me.pnlKet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKet.Controls.Add(Me.lblTotalItem)
        Me.pnlKet.Controls.Add(Me.lblHarga)
        Me.pnlKet.Location = New System.Drawing.Point(5, 91)
        Me.pnlKet.Name = "pnlKet"
        Me.pnlKet.Size = New System.Drawing.Size(944, 63)
        Me.pnlKet.TabIndex = 51
        '
        'lblTotalItem
        '
        Me.lblTotalItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalItem.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalItem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblTotalItem.Location = New System.Drawing.Point(894, 13)
        Me.lblTotalItem.Name = "lblTotalItem"
        Me.lblTotalItem.Size = New System.Drawing.Size(25, 37)
        Me.lblTotalItem.TabIndex = 52
        Me.lblTotalItem.Text = "0"
        '
        'lblHarga
        '
        Me.lblHarga.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHarga.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblHarga.Location = New System.Drawing.Point(4, 4)
        Me.lblHarga.Name = "lblHarga"
        Me.lblHarga.Size = New System.Drawing.Size(32, 49)
        Me.lblHarga.TabIndex = 51
        Me.lblHarga.Text = "0"
        '
        'GVITem
        '
        Me.GVITem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GVITem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GVITem.Location = New System.Drawing.Point(5, 186)
        '
        'GVITem
        '
        Me.GVITem.MasterTemplate.AllowAddNewRow = False
        Me.GVITem.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn15.FieldName = "kdbarang"
        GridViewTextBoxColumn15.HeaderText = "code"
        GridViewTextBoxColumn15.IsVisible = False
        GridViewTextBoxColumn15.Name = "code"
        GridViewTextBoxColumn16.FieldName = "Nomor"
        GridViewTextBoxColumn16.HeaderText = "No"
        GridViewTextBoxColumn16.IsVisible = False
        GridViewTextBoxColumn16.Name = "No"
        GridViewTextBoxColumn17.FieldName = "Nama"
        GridViewTextBoxColumn17.HeaderText = "Item Name"
        GridViewTextBoxColumn17.Name = "Name"
        GridViewTextBoxColumn17.Width = 600
        GridViewTextBoxColumn18.FieldName = "Qty"
        GridViewTextBoxColumn18.HeaderText = "QTY"
        GridViewTextBoxColumn18.Name = "Qty"
        GridViewTextBoxColumn19.FieldName = "kdSatuan"
        GridViewTextBoxColumn19.HeaderText = "Unit"
        GridViewTextBoxColumn19.Name = "Unit"
        GridViewTextBoxColumn20.FieldName = "hargaJual"
        GridViewTextBoxColumn20.FormatString = "{0:##,#}"
        GridViewTextBoxColumn20.HeaderText = "Price"
        GridViewTextBoxColumn20.Name = "Price"
        GridViewTextBoxColumn20.Width = 100
        GridViewTextBoxColumn21.FieldName = "Total"
        GridViewTextBoxColumn21.FormatString = "{0:##,#}"
        GridViewTextBoxColumn21.HeaderText = "Total"
        GridViewTextBoxColumn21.Name = "Total"
        GridViewTextBoxColumn21.Width = 100
        Me.GVITem.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn15, GridViewTextBoxColumn16, GridViewTextBoxColumn17, GridViewTextBoxColumn18, GridViewTextBoxColumn19, GridViewTextBoxColumn20, GridViewTextBoxColumn21})
        Me.GVITem.MasterTemplate.EnableGrouping = False
        Me.GVITem.Name = "GVITem"
        Me.GVITem.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.GVITem.ReadOnly = True
        '
        '
        '
        Me.GVITem.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.GVITem.Size = New System.Drawing.Size(944, 224)
        Me.GVITem.TabIndex = 52
        Me.GVITem.Text = "RadGridView4"
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(5, 160)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(910, 20)
        Me.txtBarcode.TabIndex = 59
        Me.txtBarcode.TabStop = False
        '
        'btnAddItem
        '
        Me.btnAddItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddItem.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddItem.Location = New System.Drawing.Point(921, 156)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(28, 28)
        Me.btnAddItem.TabIndex = 64
        Me.btnAddItem.Text = ">>"
        '
        'PnlCommand
        '
        Me.PnlCommand.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PnlCommand.Controls.Add(Me.btnPrint)
        Me.PnlCommand.Controls.Add(Me.BtnDElete)
        Me.PnlCommand.Controls.Add(Me.BtnSave)
        Me.PnlCommand.Controls.Add(Me.BtnCancel)
        Me.PnlCommand.Controls.Add(Me.BtnAdd)
        Me.PnlCommand.Controls.Add(Me.BtnSearch)
        Me.PnlCommand.Location = New System.Drawing.Point(5, 416)
        Me.PnlCommand.Name = "PnlCommand"
        Me.PnlCommand.Size = New System.Drawing.Size(421, 96)
        Me.PnlCommand.TabIndex = 68
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.BProc_UI.My.Resources.Resources.print
        Me.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrint.Location = New System.Drawing.Point(282, 11)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(62, 76)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnDElete
        '
        Me.BtnDElete.Image = Global.BProc_UI.My.Resources.Resources.edit_delete
        Me.BtnDElete.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnDElete.Location = New System.Drawing.Point(214, 11)
        Me.BtnDElete.Name = "BtnDElete"
        Me.BtnDElete.Size = New System.Drawing.Size(62, 76)
        Me.BtnDElete.TabIndex = 3
        Me.BtnDElete.Text = "Delete"
        Me.BtnDElete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnSave
        '
        Me.BtnSave.Image = Global.BProc_UI.My.Resources.Resources.disks
        Me.BtnSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnSave.Location = New System.Drawing.Point(146, 11)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(62, 76)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnCancel
        '
        Me.BtnCancel.Image = Global.BProc_UI.My.Resources.Resources.cancel
        Me.BtnCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnCancel.Location = New System.Drawing.Point(78, 11)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(62, 76)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnAdd
        '
        Me.BtnAdd.Image = Global.BProc_UI.My.Resources.Resources.document_new
        Me.BtnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnAdd.Location = New System.Drawing.Point(10, 10)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(62, 77)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnSearch
        '
        Me.BtnSearch.Image = Global.BProc_UI.My.Resources.Resources.searchall
        Me.BtnSearch.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnSearch.Location = New System.Drawing.Point(350, 11)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(62, 76)
        Me.BtnSearch.TabIndex = 5
        Me.BtnSearch.Text = "Find"
        Me.BtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Frm_Cashier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 544)
        Me.Controls.Add(Me.GVITem)
        Me.Controls.Add(Me.PnlCommand)
        Me.Controls.Add(Me.btnAddItem)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.pnlKet)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "Frm_Cashier"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cashier"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.lblCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkClasicMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlKet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKet.ResumeLayout(False)
        Me.pnlKet.PerformLayout()
        CType(Me.lblTotalItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblHarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVITem.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVITem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PnlCommand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlCommand.ResumeLayout(False)
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDElete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadThemeManager1 As Telerik.WinControls.RadThemeManager
    Friend WithEvents pnlHeader As Telerik.WinControls.UI.RadPanel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents pnlKet As Telerik.WinControls.UI.RadPanel
    Friend WithEvents GVITem As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblHarga As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtBarcode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnAddItem As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTotalItem As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ChkClasicMode As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents PnlCommand As Telerik.WinControls.UI.RadPanel
    Friend WithEvents BtnDElete As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnAdd As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnSearch As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblNoTransaction As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblCustomer As Telerik.WinControls.UI.RadLabel
End Class
