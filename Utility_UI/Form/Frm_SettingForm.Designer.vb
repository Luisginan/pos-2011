<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SettingForm
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
        Me.btnOk = New Telerik.WinControls.UI.RadButton()
        Me.GBbarcodeMode = New Telerik.WinControls.UI.RadGroupBox()
        Me.RBNormal = New Telerik.WinControls.UI.RadRadioButton()
        Me.RBautoEnter = New Telerik.WinControls.UI.RadRadioButton()
        CType(Me.btnOk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GBbarcodeMode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBbarcodeMode.SuspendLayout()
        CType(Me.RBNormal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RBautoEnter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(235, 82)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(130, 24)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        '
        'GBbarcodeMode
        '
        Me.GBbarcodeMode.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.GBbarcodeMode.Controls.Add(Me.RBautoEnter)
        Me.GBbarcodeMode.Controls.Add(Me.RBNormal)
        Me.GBbarcodeMode.FooterImageIndex = -1
        Me.GBbarcodeMode.FooterImageKey = ""
        Me.GBbarcodeMode.HeaderImageIndex = -1
        Me.GBbarcodeMode.HeaderImageKey = ""
        Me.GBbarcodeMode.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.GBbarcodeMode.HeaderText = "Barcode Mode"
        Me.GBbarcodeMode.Location = New System.Drawing.Point(12, 12)
        Me.GBbarcodeMode.Name = "GBbarcodeMode"
        Me.GBbarcodeMode.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        '
        '
        '
        Me.GBbarcodeMode.RootElement.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        Me.GBbarcodeMode.Size = New System.Drawing.Size(353, 64)
        Me.GBbarcodeMode.TabIndex = 1
        Me.GBbarcodeMode.Text = "Barcode Mode"
        '
        'RBNormal
        '
        Me.RBNormal.Location = New System.Drawing.Point(28, 32)
        Me.RBNormal.Name = "RBNormal"
        Me.RBNormal.Size = New System.Drawing.Size(110, 18)
        Me.RBNormal.TabIndex = 0
        Me.RBNormal.Text = "Normal"
        '
        'RBautoEnter
        '
        Me.RBautoEnter.Location = New System.Drawing.Point(110, 32)
        Me.RBautoEnter.Name = "RBautoEnter"
        Me.RBautoEnter.Size = New System.Drawing.Size(110, 18)
        Me.RBautoEnter.TabIndex = 1
        Me.RBautoEnter.Text = "Auto Enter"
        '
        'Frm_SettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 112)
        Me.Controls.Add(Me.GBbarcodeMode)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_SettingForm"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting App"
        CType(Me.btnOk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GBbarcodeMode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBbarcodeMode.ResumeLayout(False)
        CType(Me.RBNormal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RBautoEnter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOk As Telerik.WinControls.UI.RadButton
    Friend WithEvents GBbarcodeMode As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RBautoEnter As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RBNormal As Telerik.WinControls.UI.RadRadioButton
End Class

