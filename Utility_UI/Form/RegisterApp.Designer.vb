<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterApp
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
        Me.txtSerialNumber = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtServerDatabase = New Telerik.WinControls.UI.RadTextBox()
        Me.txtUserName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtPassword = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.txtSqlScript = New Telerik.WinControls.UI.RadTextBox()
        Me.BtnRegister = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.BtnTestConnection = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnOpenFile = New Telerik.WinControls.UI.RadButton()
        Me.DOFfileScript = New System.Windows.Forms.OpenFileDialog()
        CType(Me.txtSerialNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServerDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSqlScript, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnRegister, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.BtnTestConnection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.btnOpenFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Location = New System.Drawing.Point(116, 28)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(248, 20)
        Me.txtSerialNumber.TabIndex = 0
        Me.txtSerialNumber.TabStop = False
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(12, 30)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(78, 18)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "Serial Number"
        '
        'txtServerDatabase
        '
        Me.txtServerDatabase.Location = New System.Drawing.Point(117, 21)
        Me.txtServerDatabase.Name = "txtServerDatabase"
        Me.txtServerDatabase.Size = New System.Drawing.Size(248, 20)
        Me.txtServerDatabase.TabIndex = 2
        Me.txtServerDatabase.TabStop = False
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(117, 47)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(248, 20)
        Me.txtUserName.TabIndex = 3
        Me.txtUserName.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(117, 73)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(248, 20)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.TabStop = False
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(13, 23)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(87, 18)
        Me.RadLabel2.TabIndex = 2
        Me.RadLabel2.Text = "Server Database"
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(13, 49)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(62, 18)
        Me.RadLabel3.TabIndex = 5
        Me.RadLabel3.Text = "User Name"
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(13, 75)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(53, 18)
        Me.RadLabel4.TabIndex = 6
        Me.RadLabel4.Text = "Password"
        '
        'RadLabel5
        '
        Me.RadLabel5.Location = New System.Drawing.Point(13, 54)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(47, 18)
        Me.RadLabel5.TabIndex = 8
        Me.RadLabel5.Text = "Package"
        '
        'txtSqlScript
        '
        Me.txtSqlScript.Location = New System.Drawing.Point(116, 52)
        Me.txtSqlScript.Multiline = True
        Me.txtSqlScript.Name = "txtSqlScript"
        Me.txtSqlScript.PasswordChar = Global.Microsoft.VisualBasic.ChrW(36)
        '
        '
        '
        Me.txtSqlScript.RootElement.StretchVertically = True
        Me.txtSqlScript.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSqlScript.Size = New System.Drawing.Size(248, 67)
        Me.txtSqlScript.TabIndex = 7
        Me.txtSqlScript.TabStop = False
        '
        'BtnRegister
        '
        Me.BtnRegister.Location = New System.Drawing.Point(247, 322)
        Me.BtnRegister.Name = "BtnRegister"
        Me.BtnRegister.Size = New System.Drawing.Size(130, 24)
        Me.BtnRegister.TabIndex = 9
        Me.BtnRegister.Text = "Register"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.BtnTestConnection)
        Me.RadGroupBox1.Controls.Add(Me.txtServerDatabase)
        Me.RadGroupBox1.Controls.Add(Me.txtUserName)
        Me.RadGroupBox1.Controls.Add(Me.txtPassword)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "Connection"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        Me.RadGroupBox1.Size = New System.Drawing.Size(379, 135)
        Me.RadGroupBox1.TabIndex = 10
        Me.RadGroupBox1.Text = "Connection"
        '
        'BtnTestConnection
        '
        Me.BtnTestConnection.Location = New System.Drawing.Point(235, 99)
        Me.BtnTestConnection.Name = "BtnTestConnection"
        Me.BtnTestConnection.Size = New System.Drawing.Size(130, 24)
        Me.BtnTestConnection.TabIndex = 12
        Me.BtnTestConnection.Text = "Test Connection"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.btnOpenFile)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox2.Controls.Add(Me.txtSerialNumber)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel5)
        Me.RadGroupBox2.Controls.Add(Me.txtSqlScript)
        Me.RadGroupBox2.FooterImageIndex = -1
        Me.RadGroupBox2.FooterImageKey = ""
        Me.RadGroupBox2.HeaderImageIndex = -1
        Me.RadGroupBox2.HeaderImageKey = ""
        Me.RadGroupBox2.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox2.HeaderText = "Register Parameter"
        Me.RadGroupBox2.Location = New System.Drawing.Point(12, 153)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        '
        '
        '
        Me.RadGroupBox2.RootElement.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        Me.RadGroupBox2.Size = New System.Drawing.Size(378, 163)
        Me.RadGroupBox2.TabIndex = 11
        Me.RadGroupBox2.Text = "Register Parameter"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(116, 125)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(248, 24)
        Me.btnOpenFile.TabIndex = 10
        Me.btnOpenFile.Text = "Open File"
        '
        'OpenFileDialog1
        '
        Me.DOFfileScript.FileName = "OpenFileDialog1"
        '
        'RegisterApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 352)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.BtnRegister)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RegisterApp"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register App"
        CType(Me.txtSerialNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServerDatabase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSqlScript, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnRegister, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.BtnTestConnection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.btnOpenFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSerialNumber As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtServerDatabase As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtUserName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtPassword As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtSqlScript As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents BtnRegister As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents BtnTestConnection As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnOpenFile As Telerik.WinControls.UI.RadButton
    Friend WithEvents DOFfileScript As System.Windows.Forms.OpenFileDialog
End Class
