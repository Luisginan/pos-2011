Imports SEMICO_Dialog
Imports BPRoc_LIB.Setting
Public Class PublicFunction
    Private Const STR_IsStatusTrue As String = "IsStatus=1"
    ReadOnly Gconn As New ClsSQL(ConectionString)
    Public Property HasError As Boolean
    Public Property MessageText As String
    Public Property HasValue As Boolean
    Private ReadOnly FieldCollection As New ArrayList()
    Private ReadOnly OldValueCollection As New ArrayList()
    Private ReadOnly ValueCollection As New ArrayList()
End Class