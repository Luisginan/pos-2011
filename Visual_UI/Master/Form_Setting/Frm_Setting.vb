Imports BPRoc_LIB
Imports SEMICO_Dialog.ClsMessage
Imports Telerik.WinControls.UI
Imports BPRoc_LIB.EntitiesModel
Imports BPRoc_LIB.Setting
Imports System.Xml
Public Class Frm_Setting
    Public Property UserName = ""
    ReadOnly Fnc As New PublicFunction()
    Private Sub Frm_Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOwner()
        LoadDataKategori()
        LoadDataunit()
    End Sub
End Class