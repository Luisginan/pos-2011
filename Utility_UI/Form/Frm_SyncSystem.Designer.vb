<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SyncSystem
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
        Me.btnDeleteOlderVersion = New Telerik.WinControls.UI.RadButton()
        Me.BtnManualCopyUpdate = New Telerik.WinControls.UI.RadButton()
        Me.btnGoodSyncUpdate = New Telerik.WinControls.UI.RadButton()
        CType(Me.btnDeleteOlderVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnManualCopyUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGoodSyncUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDeleteOlderVersion
        '
        Me.btnDeleteOlderVersion.Location = New System.Drawing.Point(12, 12)
        Me.btnDeleteOlderVersion.Name = "btnDeleteOlderVersion"
        Me.btnDeleteOlderVersion.Size = New System.Drawing.Size(269, 24)
        Me.btnDeleteOlderVersion.TabIndex = 0
        Me.btnDeleteOlderVersion.Text = "Delete Older Version"
        '
        'BtnManualCopyUpdate
        '
        Me.BtnManualCopyUpdate.Location = New System.Drawing.Point(12, 42)
        Me.BtnManualCopyUpdate.Name = "BtnManualCopyUpdate"
        Me.BtnManualCopyUpdate.Size = New System.Drawing.Size(269, 24)
        Me.BtnManualCopyUpdate.TabIndex = 1
        Me.BtnManualCopyUpdate.Text = "Manual Copy Update"
        '
        'btnGoodSyncUpdate
        '
        Me.btnGoodSyncUpdate.Location = New System.Drawing.Point(12, 72)
        Me.btnGoodSyncUpdate.Name = "btnGoodSyncUpdate"
        Me.btnGoodSyncUpdate.Size = New System.Drawing.Size(269, 24)
        Me.btnGoodSyncUpdate.TabIndex = 2
        Me.btnGoodSyncUpdate.Text = "Goodsync Update"
        '
        'Frm_SyncSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 106)
        Me.Controls.Add(Me.btnGoodSyncUpdate)
        Me.Controls.Add(Me.BtnManualCopyUpdate)
        Me.Controls.Add(Me.btnDeleteOlderVersion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_SyncSystem"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sync System"
        CType(Me.btnDeleteOlderVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnManualCopyUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGoodSyncUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDeleteOlderVersion As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnManualCopyUpdate As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnGoodSyncUpdate As Telerik.WinControls.UI.RadButton
End Class

