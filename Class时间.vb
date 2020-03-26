Public Class Class时间
    ''' <summary>
    ''' 注释
    ''' </summary>
    ''' 
    Public Is程序开始 As Boolean = False
    Public Is倒计时模式 As Boolean = True
    Public 开始时刻 As Date = Date.Now
    Public ReadOnly Property 结束时刻 As Date
        Get
            Return 开始时刻.AddSeconds(剩余时间vale)
        End Get
    End Property

    Private 剩余时间vale As Int64 = 0
    Public Property 剩余时间 As Class时分秒
        Get
            If Is程序开始 Then
                Return New Class时分秒(DateDiff(DateInterval.Second, Date.Now, 结束时刻))
            Else
                Return New Class时分秒(剩余时间vale)
            End If
        End Get
        Set(value As Class时分秒)
            剩余时间vale = value.t
        End Set
    End Property



    Function ToStr() As String
        If Is程序开始 Then
            Return 剩余时间.ToString
        Else
            If Is倒计时模式 Then
                Return 剩余时间.ToString()
            Else
                Return 结束时刻.Hour & " : " & f(结束时刻.Minute) & " : " & f(结束时刻.Second)
            End If
        End If
    End Function

    Private Function f(n) As String
            '格式化数字
            Return Format(n, "00")
        End Function

    Sub gain(n As Int64)
        剩余时间vale = 剩余时间vale + n
        If 剩余时间vale < 0 Then
            剩余时间vale = 0
        End If
    End Sub

End Class
