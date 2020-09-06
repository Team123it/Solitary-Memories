#Disable Warning IDE1006
Imports Team123it.Arcaea.Solimmr.Global
Imports Team123it.Arcaea.Solimmr.Global.BotArcAPI
Imports System.Drawing
Imports System.Net
Imports System.Environment
Imports System.ComponentModel
Imports System.Threading
Imports System.IO
Imports System.IO.Compression

Public Class Frm_Start
	Dim ScrollProgress As Short = 0 '当前移动的Tick数,Max=235
	Dim MovePerTick As Single = 0.9! '每Tick图片向上移动的像素数
	Dim NowY As Single = 0
	Dim Initialized As Boolean = False
	Dim StartTimer As New Timers.Timer(1)
	Dim FirstStart As Boolean = False
	Dim ThisTimer As New Timers.Timer(1000)

	Private Sub Tmr_Start_Tick(sender As Object, e As EventArgs)
		If NowY <= -492.5 Then
			If awmp_Start.Ctlcontrols.currentPosition < 12.43 Then
				Exit Sub
			End If
		End If
		If awmp_Start.Ctlcontrols.currentPosition <= 0.0000 Then
			Exit Sub
		End If
		If awmp_Start.Ctlcontrols.currentPosition < 12.43 Then '如果没到最后一个Tick
			NowY = NowY - MovePerTick
			ptbx_Start.Location = New Point(0, NowY)
		ElseIf awmp_Start.Ctlcontrols.currentPosition < 15 Then
			ptbx_Start.Location = New Point(0, -492.5)
		Else
			StartTimer.Stop()
			Call BGMChorusStart()
		End If
	End Sub

	Private Sub Frm_Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		AddHandler StartTimer.Elapsed, AddressOf Tmr_Start_Tick
		If Not Tag = "sysrun" Then
			Refresh()
			FormFade(Me, FadeType.FadeIn)
			awmp_Start.URL = My.Application.Info.DirectoryPath & "\data\resources\Startup_Full.mp3"
		Else
			Hide()
			bgwk_Start.RunWorkerAsync()
		End If
	End Sub


	Private Sub Frm_Start_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		If Not Tag = "sysrun" Then
			bgwk_Start.RunWorkerAsync()
			StartTimer.Start()
			awmp_Start.Ctlcontrols.play()
		Else
			Hide()
			bgwk_Start.RunWorkerAsync()
		End If
	End Sub

	Private Sub ptbx_Start_Click(sender As Object, e As EventArgs) Handles ptbx_Start.Click
		If StartTimer.Enabled Then
			StartTimer.Stop() ' 计时器结束
			Call BGMChorusStart(True) '跳到副歌开始处
		Else
			If Initialized Then
				awmp_Start.Ctlcontrols.stop()
				FormFade(Me, FadeType.FadeOut)
				If FirstStart Then
					Dim FirstStart As New Frm_FirstStart
					FirstStart.Show()
					Hide()
				Else
					Dim Main As New Frm_Main
					If Tag <> Nothing Then
						Main.Tag = Tag
					End If
					Main.Show()
					Hide()
				End If
			End If
		End If
	End Sub

	Private Sub bgwk_Start_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwk_Start.DoWork
		Try
			Invoke(New Action(Sub()
								  lbl_start.Visible = True
							  End Sub))
			Threading.Thread.Sleep(500)
			If [Global].My.MySettings.Default.IsFirstStart Then '如果是首次启动Solitary Memories
				Invoke(New Action(Sub()
									  lbl_start.Text = "Unpacking BotArcAPI Data Pack..."
								  End Sub))
				Dim BotArcAPIUnpack As String = My.Application.Info.DirectoryPath & "\data\nodejs.zip"
				Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\nodejs")
				ZipFile.ExtractToDirectory(BotArcAPIUnpack, My.Application.Info.DirectoryPath & "\nodejs")
				Invoke(New Action(Sub()
									  lbl_start.Text = "Unpacking Portable JRE Data Pack..."
								  End Sub))
				Dim PortableJreUnpack As String = My.Application.Info.DirectoryPath & "\data\portable_jre.zip"
				Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\bin\Portable_JRE")
				ZipFile.ExtractToDirectory(PortableJreUnpack, My.Application.Info.DirectoryPath & "\bin\Portable_JRE")
				Invoke(New Action(Sub()
									  lbl_start.Text = "Loading Main Window Components..."
								  End Sub))
				Thread.Sleep(200)
				Invoke(New Action(Sub()
									  lbl_start.Text = "Preparing for the first start..."
								  End Sub))
				FirstStart = True
				Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\data\players")
				Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\data\subscribes")
				Do Until lbl_start.Location.Y >= 360
					Threading.Thread.Sleep(15)
					Invoke(New Action(Sub()
										  lbl_start.Location = New Point(lbl_start.Location.X, lbl_start.Location.Y + 1)
									  End Sub))
				Loop
				Initialized = True
			Else
				Invoke(New Action(Sub()
									  lbl_start.Text = "Checking Port Status..."
								  End Sub))
				If IsPortInUse(NetworkPortType.TCP, [Global].My.MySettings.Default.APIPort) Then
					Invoke(New Action(Sub()
										  lbl_start.Text = "Error: Port already used"
									  End Sub))
					Throw New WebException($"BotArcAPI启动端口已被占用: {[Global].My.MySettings.Default.APIPort}{vbCrLf}" &
										   $"请关闭任何有可能占用此端口的进程, 然后重启Solitary Memories。")
				End If
				Invoke(New Action(Sub()
									  lbl_start.Text = "Starting BotArcAPI..."
								  End Sub))
				Dim Result As Boolean = Start()
				If Result Then
					Invoke(New Action(Sub()
										  lbl_start.Text = "Loading Main Window Components..."
									  End Sub))
					Initialized = True
					If Tag = "sysrun" Then
						Invoke(New Action(Sub()
											  Dim Main As New Frm_Main With {
												  .Tag = "sysrun"
											  }
											  Main.Show()
										  End Sub))
					Else
						Dim i As Byte = 0
						Do Until i > 10
							Thread.Sleep(15)
							Invoke(New Action(Sub()
												  lbl_start.Location = New Point(lbl_start.Location.X, lbl_start.Location.Y + 5)
											  End Sub))
							i += 1
						Loop
					End If
					Exit Sub
				Else
					Invoke(New Action(Sub()
										  lbl_start.Text = "Error: BotArcAPI start failed"
									  End Sub))
					Throw New Win32Exception($"BotArcAPI启动失败")
				End If
			End If
		Catch ex As Exception
			Invoke(New Action(Sub()
								  tmr_Start.Stop()
								  MsgBox("Solitary Memories初始化时出现严重异常:" & vbCrLf &
										 ex.Message & vbCrLf &
										 "程序即将退出......" & vbCrLf &
										 vbCrLf &
										 "详细的异常堆栈信息:" & vbCrLf &
										 ex.StackTrace, 16, "初始化失败")
							  End Sub))
			[Exit](1)
		End Try
	End Sub

	Private Sub BGMChorusStart(Optional ManualStartChorus As Boolean = False)
		If ManualStartChorus Then '如果是手动跳到BGM副歌起始处
			ptbx_Start.Location = New Point(0, -492.5) '调整启动背景图片为动画结束后的位置
			awmp_Start.Ctlcontrols.currentPosition = 15.0
		End If
		ptbx_Title.Visible = True '显示标题
		lbl_cprt.Visible = True '显示版权信息
	End Sub

	Private Sub ptbx_Title_Click(sender As Object, e As EventArgs) Handles ptbx_Title.Click
		Call ptbx_Start_Click(sender, e)
	End Sub

	Private Sub lbl_cprt_Click(sender As Object, e As EventArgs) Handles lbl_cprt.Click
		Process.Start("https://github.com/123-Open-Source-Organization")
	End Sub
End Class