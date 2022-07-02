<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_QueryTransaction
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
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.GV = New Telerik.WinControls.UI.RadGridView()
        Me.BtnOpenFile = New Telerik.WinControls.UI.RadButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtQuery = New Telerik.WinControls.UI.RadTextBox()
        Me.DDDB = New Telerik.WinControls.UI.RadDropDownList()
        Me.btnExport = New Telerik.WinControls.UI.RadButton()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtFilePath = New Telerik.WinControls.UI.RadTextBox()
        Me.chkRunCMD = New Telerik.WinControls.UI.RadCheckBox()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOpenFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DDDB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilePath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRunCMD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(113, 210)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(118, 24)
        Me.RadButton1.TabIndex = 1
        Me.RadButton1.Text = "Execute"
        '
        'GV
        '
        Me.GV.AllowDrop = True
        Me.GV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GV.Location = New System.Drawing.Point(8, 240)
        '
        'GV
        '
        Me.GV.MasterTemplate.AllowAddNewRow = False
        Me.GV.MasterTemplate.AllowDeleteRow = False
        Me.GV.MasterTemplate.AllowDragToGroup = False
        Me.GV.MasterTemplate.AllowEditRow = False
        Me.GV.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        Me.GV.Name = "GV"
        Me.GV.ShowGroupPanel = False
        Me.GV.Size = New System.Drawing.Size(532, 177)
        Me.GV.TabIndex = 2
        Me.GV.Text = "RadGridView1"
        '
        'BtnOpenFile
        '
        Me.BtnOpenFile.Location = New System.Drawing.Point(8, 38)
        Me.BtnOpenFile.Name = "BtnOpenFile"
        Me.BtnOpenFile.Size = New System.Drawing.Size(99, 24)
        Me.BtnOpenFile.TabIndex = 3
        Me.BtnOpenFile.Text = "Open File"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtQuery
        '
        Me.txtQuery.AllowDrop = True
        Me.txtQuery.AllowShowFocusCues = True
        Me.txtQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuery.AutoScroll = True
        Me.txtQuery.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuery.Location = New System.Drawing.Point(8, 99)
        Me.txtQuery.MaxLength = 10000000
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        '
        '
        '
        Me.txtQuery.RootElement.StretchVertically = True
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtQuery.Size = New System.Drawing.Size(532, 105)
        Me.txtQuery.TabIndex = 0
        Me.txtQuery.TabStop = False
        '
        'DDDB
        '
        Me.DDDB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DDDB.DropDownAnimationEnabled = True
        RadListDataItem1.Text = "Mandiri"
        RadListDataItem1.TextWrap = True
        RadListDataItem2.Text = "Master"
        RadListDataItem2.TextWrap = True
        Me.DDDB.Items.Add(RadListDataItem1)
        Me.DDDB.Items.Add(RadListDataItem2)
        Me.DDDB.Location = New System.Drawing.Point(8, 12)
        Me.DDDB.Name = "DDDB"
        Me.DDDB.ShowImageInEditorArea = True
        Me.DDDB.Size = New System.Drawing.Size(532, 20)
        Me.DDDB.TabIndex = 4
        Me.DDDB.Text = "Mandiri"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(422, 210)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(118, 24)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "Export"
        '
        'txtFilePath
        '
        Me.txtFilePath.AllowDrop = True
        Me.txtFilePath.AllowShowFocusCues = True
        Me.txtFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilePath.AutoScroll = True
        Me.txtFilePath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilePath.Location = New System.Drawing.Point(113, 38)
        Me.txtFilePath.MaxLength = 10000000
        Me.txtFilePath.Multiline = True
        Me.txtFilePath.Name = "txtFilePath"
        '
        '
        '
        Me.txtFilePath.RootElement.StretchVertically = True
        Me.txtFilePath.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFilePath.Size = New System.Drawing.Size(427, 55)
        Me.txtFilePath.TabIndex = 6
        Me.txtFilePath.TabStop = False
        '
        'chkRunCMD
        '
        Me.chkRunCMD.Location = New System.Drawing.Point(12, 213)
        Me.chkRunCMD.Name = "chkRunCMD"
        Me.chkRunCMD.Size = New System.Drawing.Size(95, 18)
        Me.chkRunCMD.TabIndex = 7
        Me.chkRunCMD.Text = "Run With CMD"
        '
        'Frm_QueryTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 429)
        Me.Controls.Add(Me.chkRunCMD)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.DDDB)
        Me.Controls.Add(Me.BtnOpenFile)
        Me.Controls.Add(Me.GV)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.txtQuery)
        Me.Name = "Frm_QueryTransaction"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Query Transaction"
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOpenFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DDDB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilePath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRunCMD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents GV As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BtnOpenFile As Telerik.WinControls.UI.RadButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtQuery As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents DDDB As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents btnExport As Telerik.WinControls.UI.RadButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtFilePath As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents chkRunCMD As Telerik.WinControls.UI.RadCheckBox
End Class

