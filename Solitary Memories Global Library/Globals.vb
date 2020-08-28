Imports System.ComponentModel
Imports System.Environment
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading

''' <summary>
''' Solitary Memories 公用方法模块
''' </summary>
Public Module Globals
	''' <summary>
	''' 封装 BotArcAPI 后台进程的操作类。此类不能被继承。
	''' </summary>
	Public MustInherit Class BotArcAPI

		Private Shared _State As Boolean

		Private Shared _BotArcAPI As Process

		Private Shared _KeepBotArcAPIRun As Thread

		''' <summary>
		''' 获取 BotArcAPI 进程是否正在运行的标志。
		''' </summary>
		Public Shared ReadOnly Property State As Boolean
			Get
				Return _State
			End Get
		End Property

		''' <summary>
		''' 获取当前正在运行的 BotArcAPI 的Windows进程实例。
		''' </summary>
		''' <returns></returns>
		Public Shared ReadOnly Property BotArcAPI As Process
			Get
				Return _BotArcAPI
			End Get
		End Property

		''' <summary>
		''' 启动 BotArcAPI 后台进程并返回启动成功与否的标志。
		''' </summary>
		''' <exception cref="Win32Exception" />
		Public Shared Function Start() As Boolean
			If _State Then '如果BotArcAPI已在运行
				Throw New Win32Exception("BotArcAPI Process is already running")
				Return False
			Else '如果BotArcAPI未在运行
				Dim Result As Boolean = BotArcAPIStart()
				_State = Result
				Return Result
			End If
		End Function

		''' <summary>
		''' 停止 BotArcAPI 后台进程并返回停止成功与否的标志。
		''' </summary>
		''' <exception cref="Win32Exception" />
		Public Shared Function [Stop]() As Boolean
			If Not _State Then '如果BotArcAPI未在运行
				Throw New Win32Exception("BotArcAPI Process isn't running")
				Return False
			Else '如果BotArcAPI已在运行
				Dim Result As Boolean = BotArcAPIStop()
				_State = -Result
				Return Result
			End If
		End Function

		Private Shared Function BotArcAPIStart() As Boolean
			Try
				Dim BotArcAPIStartInfo As New ProcessStartInfo With {
				.Arguments = "/c npm start",
				.FileName = $"{System.Environment.GetFolderPath(SpecialFolder.System)}\cmd.exe",
				.RedirectStandardOutput = True,
				.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
				.UseShellExecute = False,
				.WindowStyle = ProcessWindowStyle.Hidden,
				.CreateNoWindow = True
			}
				_BotArcAPI = Process.Start(BotArcAPIStartInfo)
				Do
					Dim CurrentString As String = _BotArcAPI.StandardOutput.ReadLine()
					If CurrentString.ToLower.Contains("http server started at") Then '如果程序已启动
						_KeepBotArcAPIRun = New Thread(New ThreadStart(Sub()
																		   Do
																			   _BotArcAPI.StandardOutput.ReadLine()
																		   Loop
																	   End Sub))
						_KeepBotArcAPIRun.Start()
						Return True
					End If
				Loop
			Catch ex As Exception
				Return False
			End Try
		End Function

		Private Shared Function BotArcAPIStop() As Boolean
			Try
				Dim ProcessStdOut As StreamReader = _BotArcAPI.StandardOutput
				AttachConsole(_BotArcAPI.Id)
				SetConsoleCtrlHandler(IntPtr.Zero, True)
				GenerateConsoleCtrlEvent(0, 0) '发送Ctrl+C
				_KeepBotArcAPIRun.Interrupt()
				Do
					Dim CurrentString As String = _BotArcAPI.StandardOutput.ReadLine()
					If CurrentString.ToLower.Contains("stop logging") Then '如果程序已关闭
						Thread.Sleep(10)
						SetConsoleCtrlHandler(IntPtr.Zero, False)
						_BotArcAPI.Kill()
						Return True
					End If
				Loop
			Catch ex As Exception
				Return False
			End Try
		End Function
	End Class

	''' <summary>
	''' 判断当前进程是否为本程序的第一个实例。
	''' </summary>
	Public Function IsFirstInstance() As Boolean
		Dim ps As Process() = Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)
		If ps.Length <= 1 Then
			Return True
		Else
			Return False
		End If
	End Function

	<DllImport("kernel32.dll")>
	Private Function GenerateConsoleCtrlEvent(dwCtrlEvent As Int32, dwProcessGroupId As Int32) As Boolean : End Function

	<DllImport("kernel32.dll")>
	Private Function SetConsoleCtrlHandler(handerRoutine As IntPtr, add As Boolean) As Boolean : End Function

	<DllImport("kernel32.dll")>
	Private Function AttachConsole(dwProcessId As Int32) As Boolean : End Function
End Module
