Public Class Commonly
    Public Shared Function NDD(obj As Object) As Object
        Dim dat As New Date(1800, 1, 1)
        Dim temp As Date
        If IsNothing(obj) Or IsDBNull(obj) Then
            temp = dat
        ElseIf CDate(obj).Year < 1800 Then
            temp = dat
        Else
            temp = obj
        End If
        Return temp
    End Function
    Public Shared Function NNol(obj As Object) As Decimal
        Dim temp As Decimal
        Try
            If IsNumeric(obj) Then
                temp = CInt(obj)
            Else
                Throw New Exception
            End If
        Catch ex As Exception
            temp = 0
        End Try
        Return temp
    End Function
    Public Shared Function CSQLDateTime(dates As Date) As String
        Return String.Format("'{0:yyyy-MM-dd HH:mm:ss }'", dates)
    End Function
End Class