<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_UserManager
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCommandColumn1 As Telerik.WinControls.UI.GridViewCommandColumn = New Telerik.WinControls.UI.GridViewCommandColumn()
        Dim GridViewCommandColumn2 As Telerik.WinControls.UI.GridViewCommandColumn = New Telerik.WinControls.UI.GridViewCommandColumn()
        Dim GridViewCommandColumn3 As Telerik.WinControls.UI.GridViewCommandColumn = New Telerik.WinControls.UI.GridViewCommandColumn()
        Me.GrpInputUser = New Telerik.WinControls.UI.RadPanel()
        Me.pnlInputUser = New Telerik.WinControls.UI.RadPanel()
        Me.DDLevel = New Telerik.WinControls.UI.RadDropDownList()
        Me.btnSaveUser = New Telerik.WinControls.UI.RadButton()
        Me.btnCancelUser = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.txtUserName = New Telerik.WinControls.UI.RadTextBox()
        Me.BtnNewUser = New Telerik.WinControls.UI.RadButton()
        Me.GVuser = New Telerik.WinControls.UI.RadGridView()
        CType(Me.GrpInputUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpInputUser.SuspendLayout()
        CType(Me.pnlInputUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInputUser.SuspendLayout()
        CType(Me.DDLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSaveUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnNewUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVuser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GVuser.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpInputUser
        '
        Me.GrpInputUser.BackColor = System.Drawing.Color.White
        Me.GrpInputUser.Controls.Add(Me.pnlInputUser)
        Me.GrpInputUser.Location = New System.Drawing.Point(1, 0)
        Me.GrpInputUser.Name = "GrpInputUser"
        Me.GrpInputUser.Size = New System.Drawing.Size(472, 232)
        Me.GrpInputUser.TabIndex = 52
        Me.GrpInputUser.Visible = False
        '
        'pnlInputUser
        '
        Me.pnlInputUser.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pnlInputUser.Controls.Add(Me.DDLevel)
        Me.pnlInputUser.Controls.Add(Me.btnSaveUser)
        Me.pnlInputUser.Controls.Add(Me.btnCancelUser)
        Me.pnlInputUser.Controls.Add(Me.RadLabel10)
        Me.pnlInputUser.Controls.Add(Me.RadLabel9)
        Me.pnlInputUser.Controls.Add(Me.txtUserName)
        Me.pnlInputUser.Location = New System.Drawing.Point(15, 18)
        Me.pnlInputUser.Name = "pnlInputUser"
        Me.pnlInputUser.Size = New System.Drawing.Size(381, 100)
        Me.pnlInputUser.TabIndex = 64
        '
        'DDLevel
        '
        Me.DDLevel.DropDownAnimationEnabled = True
        Me.DDLevel.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        RadListDataItem1.Text = "SuperVisor"
        RadListDataItem1.TextWrap = True
        RadListDataItem2.Selected = True
        RadListDataItem2.Text = "UserEntry"
        RadListDataItem2.TextWrap = True
        Me.DDLevel.Items.Add(RadListDataItem1)
        Me.DDLevel.Items.Add(RadListDataItem2)
        Me.DDLevel.Location = New System.Drawing.Point(84, 41)
        Me.DDLevel.Name = "DDLevel"
        Me.DDLevel.ShowImageInEditorArea = True
        Me.DDLevel.Size = New System.Drawing.Size(148, 20)
        Me.DDLevel.TabIndex = 65
        Me.DDLevel.Tag = "LeveUser"
        Me.DDLevel.Text = "UserEntry"
        '
        'btnSaveUser
        '
        Me.btnSaveUser.Image = Global.Utility_UI.My.Resources.Resources.disks
        Me.btnSaveUser.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSaveUser.Location = New System.Drawing.Point(306, 14)
        Me.btnSaveUser.Name = "btnSaveUser"
        Me.btnSaveUser.Size = New System.Drawing.Size(62, 76)
        Me.btnSaveUser.TabIndex = 63
        Me.btnSaveUser.Text = "Save"
        Me.btnSaveUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCancelUser
        '
        Me.btnCancelUser.Image = Global.Utility_UI.My.Resources.Resources.cancel
        Me.btnCancelUser.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCancelUser.Location = New System.Drawing.Point(238, 14)
        Me.btnCancelUser.Name = "btnCancelUser"
        Me.btnCancelUser.Size = New System.Drawing.Size(62, 76)
        Me.btnCancelUser.TabIndex = 64
        Me.btnCancelUser.Text = "Cancel"
        Me.btnCancelUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'RadLabel10
        '
        Me.RadLabel10.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel10.Location = New System.Drawing.Point(14, 14)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(62, 18)
        Me.RadLabel10.TabIndex = 47
        Me.RadLabel10.Text = "User Name"
        '
        'RadLabel9
        '
        Me.RadLabel9.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel9.Location = New System.Drawing.Point(14, 38)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(32, 18)
        Me.RadLabel9.TabIndex = 49
        Me.RadLabel9.Text = "Level"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(84, 14)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(148, 20)
        Me.txtUserName.TabIndex = 46
        Me.txtUserName.TabStop = False
        Me.txtUserName.Tag = "UserName"
        '
        'BtnNewUser
        '
        Me.BtnNewUser.Image = Global.Utility_UI.My.Resources.Resources.File_add32
        Me.BtnNewUser.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnNewUser.Location = New System.Drawing.Point(493, 12)
        Me.BtnNewUser.Name = "BtnNewUser"
        Me.BtnNewUser.Size = New System.Drawing.Size(58, 66)
        Me.BtnNewUser.TabIndex = 53
        Me.BtnNewUser.Text = "New"
        Me.BtnNewUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GVuser
        '
        Me.GVuser.Controls.Add(Me.GrpInputUser)
        Me.GVuser.Location = New System.Drawing.Point(14, 12)
        '
        'GVuser
        '
        Me.GVuser.MasterTemplate.AllowAddNewRow = False
        Me.GVuser.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.FieldName = "UserName"
        GridViewTextBoxColumn1.FormatString = ""
        GridViewTextBoxColumn1.HeaderText = "User Name"
        GridViewTextBoxColumn1.Name = "UserName"
        GridViewTextBoxColumn1.Width = 100
        GridViewTextBoxColumn2.FieldName = "LevelUser"
        GridViewTextBoxColumn2.FormatString = ""
        GridViewTextBoxColumn2.HeaderText = "Level "
        GridViewTextBoxColumn2.Name = "LevelUser"
        GridViewTextBoxColumn2.Width = 200
        GridViewCommandColumn1.DefaultText = "Reset"
        GridViewCommandColumn1.HeaderText = ""
        GridViewCommandColumn1.Name = "Reset"
        GridViewCommandColumn1.UseDefaultText = True
        GridViewCommandColumn2.DefaultText = "Edit"
        GridViewCommandColumn2.HeaderText = ""
        GridViewCommandColumn2.Name = "Edit"
        GridViewCommandColumn2.UseDefaultText = True
        GridViewCommandColumn2.Width = 30
        GridViewCommandColumn3.DefaultText = "X"
        GridViewCommandColumn3.HeaderText = ""
        GridViewCommandColumn3.Name = "Delete"
        GridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewCommandColumn3.UseDefaultText = True
        GridViewCommandColumn3.Width = 30
        Me.GVuser.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewCommandColumn1, GridViewCommandColumn2, GridViewCommandColumn3})
        Me.GVuser.MasterTemplate.EnableGrouping = False
        Me.GVuser.Name = "GVuser"
        Me.GVuser.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.GVuser.ReadOnly = True
        '
        '
        '
        Me.GVuser.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.GVuser.Size = New System.Drawing.Size(473, 232)
        Me.GVuser.TabIndex = 55
        Me.GVuser.Text = "RadGridView1"
        '
        'Frm_UserManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 256)
        Me.Controls.Add(Me.GVuser)
        Me.Controls.Add(Me.BtnNewUser)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_UserManager"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Manager"
        CType(Me.GrpInputUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpInputUser.ResumeLayout(False)
        CType(Me.pnlInputUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInputUser.ResumeLayout(False)
        Me.pnlInputUser.PerformLayout()
        CType(Me.DDLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSaveUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnNewUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVuser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GVuser.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpInputUser As Telerik.WinControls.UI.RadPanel
    Friend WithEvents pnlInputUser As Telerik.WinControls.UI.RadPanel
    Friend WithEvents btnSaveUser As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancelUser As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtUserName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents BtnNewUser As Telerik.WinControls.UI.RadButton
    Friend WithEvents DDLevel As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents GVuser As Telerik.WinControls.UI.RadGridView
End Class

