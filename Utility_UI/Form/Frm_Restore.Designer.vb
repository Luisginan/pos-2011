<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Restore
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
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.LV = New Telerik.WinControls.UI.RadGridView()
        Me.BtnRestore = New Telerik.WinControls.UI.RadButton()
        Me.RadWaitingBar1 = New Telerik.WinControls.UI.RadWaitingBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ChkSplitFile = New Telerik.WinControls.UI.RadCheckBox()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.LV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadWaitingBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkSplitFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.ChkSplitFile)
        Me.RadGroupBox1.Controls.Add(Me.LV)
        Me.RadGroupBox1.Controls.Add(Me.BtnRestore)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "List File Backup"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        Me.RadGroupBox1.Size = New System.Drawing.Size(355, 242)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "List File Backup"
        '
        'LV
        '
        Me.LV.Location = New System.Drawing.Point(16, 21)
        '
        'LV
        '
        Me.LV.MasterTemplate.AllowAddNewRow = False
        Me.LV.MasterTemplate.AllowDeleteRow = False
        Me.LV.MasterTemplate.AllowDragToGroup = False
        Me.LV.MasterTemplate.AllowEditRow = False
        Me.LV.MasterTemplate.AllowRowResize = False
        Me.LV.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        Me.LV.Name = "LV"
        Me.LV.ShowGroupPanel = False
        Me.LV.Size = New System.Drawing.Size(322, 183)
        Me.LV.TabIndex = 5
        Me.LV.Text = "RadGridView1"
        '
        'BtnRestore
        '
        Me.BtnRestore.Location = New System.Drawing.Point(208, 210)
        Me.BtnRestore.Name = "BtnRestore"
        Me.BtnRestore.Size = New System.Drawing.Size(130, 24)
        Me.BtnRestore.TabIndex = 4
        Me.BtnRestore.Text = "Restore"
        '
        'RadWaitingBar1
        '
        Me.RadWaitingBar1.Location = New System.Drawing.Point(12, 260)
        Me.RadWaitingBar1.Name = "RadWaitingBar1"
        Me.RadWaitingBar1.Size = New System.Drawing.Size(355, 24)
        Me.RadWaitingBar1.TabIndex = 5
        Me.RadWaitingBar1.Text = "RadWaitingBar1"
        Me.RadWaitingBar1.Visible = False
        Me.RadWaitingBar1.WaitingIndicatorSize = New System.Drawing.Size(50, 30)
        Me.RadWaitingBar1.WaitingSpeed = 100
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'ChkSplitFile
        '
        Me.ChkSplitFile.Location = New System.Drawing.Point(16, 210)
        Me.ChkSplitFile.Name = "ChkSplitFile"
        Me.ChkSplitFile.Size = New System.Drawing.Size(62, 18)
        Me.ChkSplitFile.TabIndex = 6
        Me.ChkSplitFile.Text = "Spilt File"
        Me.ChkSplitFile.Visible = False
        '
        'Frm_Restore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 292)
        Me.Controls.Add(Me.RadWaitingBar1)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Restore"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restore Database"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.LV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadWaitingBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkSplitFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents BtnRestore As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadWaitingBar1 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents LV As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ChkSplitFile As Telerik.WinControls.UI.RadCheckBox
End Class

