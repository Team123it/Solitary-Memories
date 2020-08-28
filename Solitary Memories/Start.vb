Imports System.Runtime.InteropServices
Imports System.Text
Imports Team123it.Arcaea.Solimmr.UI
Imports Team123it.Arcaea.Solimmr.Global

Public Class Start
	Public Shared Sub Main()
		If (Not Command().Trim().ToLower = "-restart") AndAlso (Not IsFirstInstance()) Then '如果已经有Solitary Memories的实例在运行
			MsgBox("不能同时运行多个Solitary Memories实例。", 16, "Solitary Memories")
			End
		End If
		Select Case System.Environment.GetCommandLineArgs.Length
			Case 1
NormalStart:
				If [Global].My.MySettings.Default.IsFirstStart Then
					If MsgBox("Arcaea查分已违反了Lowiro服务协议(Terms of Service)第3.2-3与第3.2-6条。" & vbCrLf &
						   "由于使用本工具带来的一切后果, 123 Open-Source Organization不承担任何责任。" & vbCrLf &
						   "是否继续使用本工具?" & vbCrLf &
						   "(此提示仅会在首次启动Solitary Memories时出现)", vbExclamation + vbYesNo, "警告") <> vbYes Then
						End
					End If
				End If
				Dim Start As New Frm_Start
				Application.Run(Start)
			Case 2
				Dim arg1 As String = System.Environment.GetCommandLineArgs(1).Trim.ToLower
				Select Case arg1
					Case "-?" '帮助
						GetCommandLineHelp()
					Case "-sysrun" '开机自启模式

					Case "-restart"
						GoTo NormalStart
					Case Else
						GetCommandLineHelp()
				End Select
			Case Else
				GetCommandLineHelp()
		End Select
	End Sub

	Public Shared Sub GetCommandLineHelp(Optional WrongArgs As String = Nothing)
		Dim ConsoleHelp As New StringBuilder()
		AllocConsole()
		Console.Title = "Solitary Memories Console"
		With ConsoleHelp
			.Append("Solitary Memories ")
			Select Case System.Globalization.CultureInfo.InstalledUICulture.Name.ToLower.Split("-")(0)
				Case "zh" '中文
					.Append("命令行帮助").Append(vbCrLf)
					.Append(My.Resources.Copyright_zh_CN).Append(vbCrLf)
					.Append(vbCrLf)
					If WrongArgs <> Nothing Then
						.Append("未知参数:").Append(WrongArgs).Append(vbCrLf)
					End If
					.Append(My.Resources.UsagePrefix_zh_CN).Append(Space(1)).Append(My.Resources.Usage).Append(vbCrLf)
					.Append(vbCrLf)
					.Append(My.Resources.UsageList_zh_CN).Append(vbCrLf)
					Console.Write(ConsoleHelp.ToString)
					Console.WriteLine("请按任意键继续...")
					Console.ReadKey(True)
					FreeConsole()
					System.Environment.Exit(0)
				Case "en" '英语
					.Append("Command Line Help").Append(vbCrLf)
					.Append(My.Resources.Copyright_en_US).Append(vbCrLf)
					.Append(vbCrLf)
					If WrongArgs <> Nothing Then
						.Append("Unknown Argument(s):").Append(WrongArgs).Append(vbCrLf)
					End If
					.Append(My.Resources.UsagePrefix_en_US).Append(Space(1)).Append(My.Resources.Usage).Append(vbCrLf)
					.Append(vbCrLf)
					.Append(My.Resources.UsageList_en_US).Append(vbCrLf)
					Console.Write(ConsoleHelp.ToString)
					Console.WriteLine("Press any key to continue...")
					Console.ReadKey(True)
					FreeConsole()
					System.Environment.Exit(0)
				Case "ja" '日语(暂时使用英语进行替代)
					.Append("Command Line Help").Append(vbCrLf)
					.Append(My.Resources.Copyright_en_US).Append(vbCrLf)
					.Append(vbCrLf)
					If WrongArgs <> Nothing Then
						.Append("Unknown Argument(s):").Append(WrongArgs).Append(vbCrLf)
					End If
					.Append(My.Resources.UsagePrefix_en_US).Append(Space(1)).Append(My.Resources.Usage).Append(vbCrLf)
					.Append(vbCrLf)
					.Append(My.Resources.UsageList_en_US).Append(vbCrLf)
					Console.Write(ConsoleHelp.ToString)
					Console.WriteLine("Press any key to continue...")
					Console.ReadKey(True)
					FreeConsole()
					System.Environment.Exit(0)
				Case Else '其它(使用英语)
					.Append("Command Line Help").Append(vbCrLf)
					.Append(My.Resources.Copyright_en_US).Append(vbCrLf)
					.Append(vbCrLf)
					If WrongArgs <> Nothing Then
						.Append("Unknown Argument(s):").Append(WrongArgs).Append(vbCrLf)
					End If
					.Append(My.Resources.UsagePrefix_en_US).Append(Space(1)).Append(My.Resources.Usage).Append(vbCrLf)
					.Append(vbCrLf)
					.Append(My.Resources.UsageList_en_US).Append(vbCrLf)
					Console.Write(ConsoleHelp.ToString)
					Console.WriteLine("Press any key to continue...")
					Console.ReadKey(True)
					FreeConsole()
					System.Environment.Exit(0)
			End Select
		End With
		Return
	End Sub

	<DllImport("kernel32.dll")>
	Public Shared Function AllocConsole() As Boolean : End Function

	<DllImport("kernel32.dll")>
	Public Shared Function FreeConsole() As Boolean : End Function
End Class
