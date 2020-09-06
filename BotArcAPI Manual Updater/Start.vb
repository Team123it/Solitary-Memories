Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Text

Public Module Start
	Public Sub Main()
		Dim LatestArcaeaVerStr As String = Nothing
		Dim LatestArcaeaSongDbPath As String = Nothing
		Console.ForegroundColor = ConsoleColor.White
		Console.BackgroundColor = ConsoleColor.Green
		Console.Clear()
		Console.Title = "BotArcAPI 更新程序"
		Console.WriteLine("欢迎使用BotArcAPI更新程序。")
		Console.WriteLine("本程序可以通过手动更新BotArcAPI的方式来进行Solitary Memories的依赖项更新。")
		Console.WriteLine("请完全退出Solitary Memories(右键任务栏图标-退出)后按任意键继续...")
		Console.ReadKey(True)
		Do
			Dim CurrentProcesses() As Process = Process.GetProcesses()
			For Each CurrentProcess In CurrentProcesses
				If CurrentProcess.ProcessName.ToLower.Contains("solitary memories") Then
					Console.WriteLine("Solitary Memories主程序仍在运行,请完全退出后按任意键重试...")
					Console.ReadKey(True)
					Continue Do
				ElseIf CurrentProcess.ProcessName.ToLower.Contains("node.js") OrElse CurrentProcess.ProcessName.ToLower.Contains("nodejs.exe") Then
					Console.WriteLine("Solitary Memories依赖项程序(Node.js)仍在运行,请在任务管理器内终止有""Node.js""字样的所有进程后按任意键重试...")
					Continue Do
				End If
			Next
			Exit Do
		Loop
		Do
			Console.WriteLine("请输入当前最新版本的Arcaea的版本号(如3.1.2)")
			Console.WriteLine("如果您的所安装的最新版本的Arcaea的版本号末尾带c(如3.1.2c),请不要输入字符'c'")
			Dim InputVersion As String = Console.ReadLine()
			If String.IsNullOrWhiteSpace(InputVersion) Then
				Continue Do
			Else
				LatestArcaeaVerStr = InputVersion
				Exit Do
			End If
		Loop
		Do
			Console.WriteLine("请输入当前最新版本对应的arcsong.db数据库文件的完整绝对路径(右键文件-属性-位置加上""\文件名""),如C:\Users\Test\arcsong.db")
			Dim InputArcSongDbPath As String = Console.ReadLine()
			If String.IsNullOrWhiteSpace(InputArcSongDbPath) Then
				Continue Do
			ElseIf Not File.Exists(InputArcSongDbPath) Then
				Console.WriteLine("找不到输入的路径对应的文件,请重新输入")
				Continue Do
			Else
				LatestArcaeaSongDbPath = InputArcSongDbPath
				Exit Do
			End If
		Loop
		Console.WriteLine("按任意键开始更新")
		Console.ReadKey()
		Console.WriteLine()
		Console.WriteLine("正在更新版本...")
		Dim BotArcAPIConfigLines As String() = File.ReadAllLines(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", Encoding.UTF8)
		BotArcAPIConfigLines(19) = $"  'ARCAPI_APPVERSION': '{LatestArcaeaVerStr}c',"
		File.Delete(Directory.GetParent(My.Application.Info.DirectoryPath).ToString & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts")
		File.WriteAllLines(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", BotArcAPIConfigLines, Encoding.UTF8)
		Console.WriteLine("正在更新曲目数据库...")
		File.Delete(Directory.GetParent(My.Application.Info.DirectoryPath).ToString & "\nodejs\node_modules\BotArcAPI\savedata\arcsong.db")
		File.Copy(LatestArcaeaSongDbPath, Directory.GetParent(My.Application.Info.DirectoryPath).ToString & "\nodejs\node_modules\BotArcAPI\savedata\arcsong.db")
		Dim BotArcAPICompilation As Process
		Dim BotArcAPICompilationInfo As New ProcessStartInfo("tsc.cmd") With {
					.WorkingDirectory = Directory.GetParent(My.Application.Info.DirectoryPath).ToString & "\nodejs\node_modules\BotArcAPI",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden
				}
		BotArcAPICompilation = Process.Start(BotArcAPICompilationInfo)
		Console.WriteLine("正在重新初始化BotArcAPI:Node.js(编译中:TypeScript))")
		BotArcAPICompilation.WaitForExit()
		Console.WriteLine("更新完毕,按任意键退出")
		Console.ReadKey(True)
		End
	End Sub
End Module
