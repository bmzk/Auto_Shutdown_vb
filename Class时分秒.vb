Public Class Class时分秒
    Public t As Int64 = 0
    Public Sub New(Optional n As Int64 = 0)
        ''0
        t = n
    End Sub
    Public ReadOnly Property H As Int64
        Get
            Return t \ 3600
        End Get
    End Property
    Public ReadOnly Property M As Int64
        Get
            Return (t - H * 3600) \ 60
        End Get
    End Property
    Public ReadOnly Property S As Int64
        Get
            Return t Mod 60
        End Get
    End Property
    Private Function f(n) As String
        '格式化数字
        Return Format(n, "00")
    End Function
    Overrides Function ToString() As String
        Return H & " : " & f(M) & " : " & f(S)
    End Function
End Class
