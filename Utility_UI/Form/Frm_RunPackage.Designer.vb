<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RunPackage
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
        Me.DDDB = New Telerik.WinControls.UI.RadDropDownList()
        Me.BtnBrowse = New Telerik.WinControls.UI.RadButton()
        Me.btnExecute = New Telerik.WinControls.UI.RadButton()
        Me.txtFilePath = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpen = New Telerik.WinControls.UI.RadButton()
        CType(Me.DDDB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExecute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilePath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DDDB
        '
        Me.DDDB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DDDB.DropDownAnimationEnabled = True
        Me.DDDB.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        RadListDataItem1.Selected = True
        RadListDataItem1.Text = "32"
        RadListDataItem1.TextWrap = True
        RadListDataItem2.Text = "64"
        RadListDataItem2.TextWrap = True
        Me.DDDB.Items.Add(RadListDataItem1)
        Me.DDDB.Items.Add(RadListDataItem2)
        Me.DDDB.Location = New System.Drawing.Point(67, 12)
        Me.DDDB.Name = "DDDB"
        Me.DDDB.ShowImageInEditorArea = True
        Me.DDDB.Size = New System.Drawing.Size(44, 20)
        Me.DDDB.TabIndex = 8
        Me.DDDB.Text = "32"
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Location = New System.Drawing.Point(12, 36)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(99, 24)
        Me.BtnBrowse.TabIndex = 7
        Me.BtnBrowse.Text = "Browse"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(350, 110)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(99, 24)
        Me.btnExecute.TabIndex = 6
        Me.btnExecute.Text = "Execute"
        '
        'txtFilePath
        '
        Me.txtFilePath.AllowDrop = True
        Me.txtFilePath.AllowShowFocusCues = True
        Me.txtFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilePath.AutoScroll = True
        Me.txtFilePath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilePath.Location = New System.Drawing.Point(117, 37)
        Me.txtFilePath.MaxLength = 10000000
        Me.txtFilePath.Multiline = True
        Me.txtFilePath.Name = "txtFilePath"
        '
        '
        '
        Me.txtFilePath.RootElement.StretchVertically = True
        Me.txtFilePath.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFilePath.Size = New System.Drawing.Size(332, 67)
        Me.txtFilePath.TabIndex = 5
        Me.txtFilePath.TabStop = False
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(12, 12)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(49, 18)
        Me.RadLabel1.TabIndex = 9
        Me.RadLabel1.Text = "Run On :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(245, 110)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(99, 24)
        Me.btnOpen.TabIndex = 10
        Me.btnOpen.Text = "Open Package"
        '
        'Frm_RunPackage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 146)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.DDDB)
        Me.Controls.Add(Me.BtnBrowse)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.txtFilePath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RunPackage"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Run Package"
        CType(Me.DDDB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExecute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilePath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DDDB As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents BtnBrowse As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExecute As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtFilePath As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnOpen As Telerik.WinControls.UI.RadButton
End Class

