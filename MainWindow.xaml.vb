Class MainWindow
    Dim 定时器 As New System.Windows.Threading.DispatcherTimer
    Dim T As New Class时间
    Private Sub slider模式选择_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles slider模式选择.ValueChanged
        T.剩余时间 = New Class时分秒(0) '重置剩余时间
        T.开始时刻 = Date.Now
        If slider模式选择.Value = 0 Then
            T.Is倒计时模式 = True
            label倒计时模式.FontWeight = FontWeights.Bold
            label倒计时模式.Foreground = Brushes.Red
            label定时模式.FontWeight = FontWeights.Normal
            label定时模式.Foreground = Brushes.Black
        Else
            T.Is倒计时模式 = False
            label倒计时模式.FontWeight = FontWeights.Normal
            label倒计时模式.Foreground = Brushes.Black
            label定时模式.FontWeight = FontWeights.Bold
            label定时模式.Foreground = Brushes.Red
        End If
        label时间.Content = T.ToStr()
        '  AddHandler DateTime.Now.
    End Sub
    Private Sub BT0_Click(sender As Object, e As RoutedEventArgs) Handles BT0.Click
        If BT0.Content = "开始" Then
            BT0.Content = "停止"
            T.Is程序开始 = True
            If T.Is倒计时模式 Then
                T.开始时刻 = Date.Now
            End If
            slider模式选择.IsEnabled = False

            BT1.IsEnabled = False
            BT2.IsEnabled = False
            BT3.IsEnabled = False
            BT4.IsEnabled = False
            BT5.IsEnabled = False
            BT6.IsEnabled = False
        Else
            T.剩余时间 = T.剩余时间
            If T.剩余时间.t < 0 Then
                T.剩余时间 = New Class时分秒(0)
            End If
            T.Is程序开始 = False
            BT0.Content = "开始"

            slider模式选择.IsEnabled = True
            BT1.IsEnabled = True
            BT2.IsEnabled = True
            BT3.IsEnabled = True
            BT4.IsEnabled = True
            BT5.IsEnabled = True
            BT6.IsEnabled = True
        End If
    End Sub

    Sub 刷新()
        label时间.Content = T.ToStr()
        label状态栏.Content = "本地时间：" & DateTime.Now.ToLongDateString() & “ ” & DateTime.Now.ToLongTimeString()
        Me.PB秒.Value = T.剩余时间.S
        PB分.Value = T.剩余时间.M
        Me.Title = T.Is倒计时模式

    End Sub
    Sub 定时器事件（）
        ' MsgBox（“执行到此了 ” & T.t & " , " & T.ToString()）
        If T.Is程序开始 = True Then
            If T.剩余时间.t <= 0 Then
                '关机
                System.Diagnostics.Process.Start("shutdown", "/s /t 0")
                ' MsgBox("gua ji")
            End If
        Else
            If T.Is倒计时模式 Then
                T.开始时刻 = Date.Now
            End If
            groupBox时间.Header = "关机时间: " & T.结束时刻.ToLongDateString & " " & T.结束时刻.ToLongTimeString
        End If
        刷新()
    End Sub

    Private Sub BT1_Click(sender As Object, e As RoutedEventArgs) Handles BT1.Click
        T.gain(3600)
        label时间.Content = T.ToStr()
    End Sub
    Private Sub BT2_Click(sender As Object, e As RoutedEventArgs) Handles BT2.Click
        T.gain(-3600)
        label时间.Content = T.ToStr()
    End Sub
    Private Sub BT3_Click(sender As Object, e As RoutedEventArgs) Handles BT3.Click
        T.gain(60)
        label时间.Content = T.ToStr()
    End Sub
    Private Sub BT4_Click(sender As Object, e As RoutedEventArgs) Handles BT4.Click
        T.gain(-60)
        label时间.Content = T.ToStr()
    End Sub
    Private Sub BT5_Click(sender As Object, e As RoutedEventArgs) Handles BT5.Click
        T.gain(1)
        label时间.Content = T.ToStr()
    End Sub
    Private Sub BT6_Click(sender As Object, e As RoutedEventArgs) Handles BT6.Click
        T.gain(-1)
        label时间.Content = T.ToStr()
    End Sub

    Private Sub window_Loaded(sender As Object, e As RoutedEventArgs) Handles window.Loaded
        定时器.Interval = New TimeSpan(0, 0, 0, 0, 200)
        AddHandler 定时器.Tick, AddressOf 定时器事件 ' 定时器.SynchronizingObject.Invoke(New Action(Of 委托类）（AddressOf 刷新）)
        T.Is倒计时模式 = True
        T.Is程序开始 = False
        T.剩余时间.t = 330
        'Me.Title = T.Is倒计时模式
        label时间.Content = T.ToStr()
        定时器.Start()
    End Sub


End Class

