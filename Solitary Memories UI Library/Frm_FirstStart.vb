Imports System.IO
Imports System.Text
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Team123it.Arcaea.Solimmr.Global
Imports System.Data.SQLite
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Frm_FirstStart
	Dim Progress As Byte = 0
	Dim BotArcAPIUpdateChecked As Boolean = False
	Dim NpmConfigPath As String

	Private Sub Frm_FirstStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		ttp_Step2_RunningPort.SetToolTip(npd_Step2_RunningPort, "该端口是BotArcAPI运行所使用的端口。" & vbCrLf &
										 "该端口为HTTP API所对应的本机端口,Solitary Memories将使用该端口连接BotArcAPI。" & vbCrLf &
										 "在BotArcAPI启动后，您通过手动访问http://127.0.0.1:{端口号}/v2/也可以访问API(详细信息参见BotArcAPI开发文档)。" & vbCrLf &
										 "推荐的端口范围为1000-65535, 默认61666。")
		Pnl_Welcome.Visible = True
		Pnl_Step1.Visible = False
		Pnl_Step2.Visible = False
		Pnl_Step3.Visible = False
		Pnl_Finish.Visible = False
		btn_previous.Enabled = False
		btn_next.Enabled = True
		btn_finish.Enabled = False
		Text = "Solitary Memories 初始化向导 - 第1步,共5步"
	End Sub

	Private Sub Btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
		Select Case Progress
			Case 0 'Welcome->Step1
				If Not BotArcAPIUpdateChecked Then
					btn_previous.Enabled = True
					Pnl_Step1.Visible = True
					Progress += 1
					Text = "Solitary Memories 初始化向导 - 第2步,共5步"
					Refresh()
					bgwk_Step1_CheckUpdate.RunWorkerAsync()
				Else
					Pnl_Step1.Visible = True
					Pnl_Step2.Visible = True
					Progress += 2
					Text = "Solitary Memories 初始化向导 - 第3步,共5步"
				End If
			Case 1 'Step1->Step2
				Pnl_Step2.Visible = True
				Progress += 1
				Text = "Solitary Memories 初始化向导 - 第3步,共5步"
			Case 2 'Step2->Step3
				Pnl_Step3.Visible = True
				btn_next.Enabled = False
				Progress += 1
				Text = "Solitary Memories 初始化向导 - 第4步,共5步"
			Case 3 'Step3->Finish
				Pnl_Finish.Visible = True
				btn_next.Enabled = False
				btn_finish.Enabled = True
				Progress += 1
				Text = "Solitary Memories 初始化向导 - 第5步,共5步"
		End Select
	End Sub

	Private Sub Btn_Step3_ImportAccountList_Click(sender As Object, e As EventArgs) Handles btn_Step3_ImportAccountList.Click
		ofd_Step2_ImportAccountsList.ShowDialog()
		If (ofd_Step2_ImportAccountsList.FileName <> Nothing) AndAlso (File.Exists(ofd_Step2_ImportAccountsList.FileName)) Then
			Try
				btn_next.Enabled = False
				btn_previous.Enabled = False
				btn_Step3_ImportAccountList.Enabled = False
				Dim AccountListArray As String() = File.ReadAllLines(ofd_Step2_ImportAccountsList.FileName, Encoding.UTF8)
				If AccountListArray(0).StartsWith("123 ArcAccountGenerator生成结果") Then
					Dim AccountList As New ArrayList(AccountListArray)
					AccountList.RemoveAt(0)
					AccountList.RemoveAt(0) '移除友好文本内容
					If (AccountList.Item(AccountList.Count - 1) = Nothing) OrElse (AccountList.Item(AccountList.Count - 1) = String.Empty) Then
						'如果最后一项是个Nothing或者空字符串
						AccountList.RemoveAt(AccountList.Count - 1)
					End If
					Dim BotArcAPI_arcaccount As New SQLiteConnection($"Data Source={My.Application.Info.DirectoryPath}\nodejs\node_modules\BotArcAPI\savedata\arcaccount.db")
					BotArcAPI_arcaccount.Open()
					Dim arcaccount_insertcmd As New SQLiteCommand(BotArcAPI_arcaccount)
					Dim CurrentAccountList As Integer = 0
					For Each Account As String In AccountList
						Dim AccountData As String() = Split(Split(Account, ":", 2, CompareMethod.Text)(1), ",", -1, CompareMethod.Text)
						Dim name As String = AccountData(0)
						Dim passwd As String = AccountData(1)
						Dim token As String = AccountData(2)
						arcaccount_insertcmd.CommandText = $"INSERT INTO 'accounts' ('name','passwd','ucode','token','banned') VALUES ('{name}','{passwd}','','{token}','false');"
						CurrentAccountList += arcaccount_insertcmd.ExecuteNonQuery()
						arcaccount_insertcmd.Reset()
					Next
					lbl_Step3_AccountsCount.Text = CurrentAccountList
					BotArcAPI_arcaccount.Close()
					btn_next.Enabled = True
				Else
					MsgBox("选择的文件不是有效的 123 ArcAccountGenerator 账号生成文本文件,请重新选择", 16, "错误")
					btn_Step3_ImportAccountList.Enabled = True
				End If
			Catch ex As Exception
				MsgBox("导入时出现异常:" & ex.ToString & vbCrLf &
					   "请尝试重新导入账号列表文件。")
				btn_Step3_ImportAccountList.Enabled = True
			Finally
				btn_previous.Enabled = True
			End Try
		End If
	End Sub

	Private Sub Frm_FirstStart_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
		If Progress < 5 Then
			e.Cancel = True
			If MsgBox("尚未完成向导。确定要退出吗?", vbExclamation + vbYesNo, "提示") = vbYes Then
				Environment.Exit(0)
			End If
		Else
			e.Cancel = True
		End If
	End Sub

	Private Sub Btn_previous_Click(sender As Object, e As EventArgs) Handles btn_previous.Click
		Select Case Progress
			Case 0 '?<-Welcome
				btn_previous.Enabled = False
			Case 2 'Welcome<-Step2 (No Step1)
				Progress = 0
				Pnl_Step2.Visible = False
				Pnl_Step1.Visible = False
				btn_previous.Enabled = True
				Text = "Solitary Memories 初始化向导 - 第1步,共5步"
				btn_next.Enabled = True
			Case 3 'Step2<-Step3
				Progress = 2
				Pnl_Step3.Visible = False
				Text = "Solitary Memories 初始化向导 - 第3步,共5步"
				btn_next.Enabled = True
			Case 4 'Step3<-Finish
				Progress = 3
				Pnl_Finish.Visible = False
				btn_next.Enabled = True
				btn_finish.Enabled = False
				Text = "Solitary Memories 初始化向导 - 第4步,共5步"
		End Select
	End Sub

	Private Sub Btn_finish_Click(sender As Object, e As EventArgs) Handles btn_finish.Click
		[Global].My.MySettings.Default.IsFirstStart = False '设置首次启动标志为False
		[Global].My.MySettings.Default.APIPort = npd_Step2_RunningPort.Value() '设置BotArcAPI运行端口
		[Global].My.MySettings.Default.Save() '保存设置
		Dim BotArcAPIConfig As String = File.ReadAllText(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", Encoding.UTF8)
		BotArcAPIConfig = BotArcAPIConfig.Replace("'SERVER_PORT': 61666,", $"'SERVER_PORT': {npd_Step2_RunningPort.Value},")
		File.WriteAllText(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", BotArcAPIConfig, Encoding.UTF8)
		Dim BotArcAPICompilation As Process
		Dim BotArcAPICompilationInfo As New ProcessStartInfo(NpmConfigPath & "\tsc.cmd") With {
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden
				}
		BotArcAPICompilation = Process.Start(BotArcAPICompilationInfo)
		BotArcAPICompilation.WaitForExit()
		Shell(Application.ExecutablePath & " -restart", AppWinStyle.NormalFocus)
		Environment.Exit(0)
	End Sub

	Private Sub Bgwk_Step1_CheckUpdate_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwk_Step1_CheckUpdate.DoWork
		Try
			Invoke(New Action(Sub()
								  btn_previous.Enabled = False
								  btn_next.Enabled = False
								  lbl_step1_status.Text = "请稍后，程序正在检查是否有 BotArcAPI 更新..."
							  End Sub))
			Dim ReturnArray As JArray = GetAPIReturnJsonArray([Global].My.Resources.BotArcAPI_UpdateApi)
			Dim LatestBotArcAPI As JObject = ReturnArray(0)
			Dim LatestVersionRawTag As String = LatestBotArcAPI.Value(Of String)("tag_name")
			Dim LatestVersionTag As String = LatestVersionRawTag.Split("-")(0).Replace("v", "")
			'返回如0.0.9的版本号
			Dim LatestVersionArray(2) As Integer
			LatestVersionArray(0) = CInt(LatestVersionTag.Split(".")(0)) '主版本号 '0.0.9="0"
			LatestVersionArray(1) = CInt(LatestVersionTag.Split(".")(1)) '次版本号 '0.0.9="0"
			LatestVersionArray(2) = CInt(LatestVersionTag.Split(".")(2)) '修订版本号 '0.0.9="9"
			Dim LatestBotArcAPIVersion As New Version(LatestVersionArray(0), LatestVersionArray(1), 0, LatestVersionArray(2))
			'返回如0.0.0.9(实际为0.0.9)或1.2.0.4(实际为1.2.4)的版本对象
			Dim CurrentBotArcAPIVersionArray(2) As Integer
			With New StreamReader(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", Encoding.UTF8)
				For i = 1 To 6
					.ReadLine()
				Next
				CurrentBotArcAPIVersionArray(0) =
					CInt(.ReadLine().Split(":")(1).Trim.Replace(",", "")) '第7行('BOTARCAPI_MAJOR': 0,)
				CurrentBotArcAPIVersionArray(1) =
					CInt(.ReadLine().Split(":")(1).Trim.Replace(",", "")) '第8行('BOTARCAPI_MINOR': 0,)
				CurrentBotArcAPIVersionArray(2) =
					CInt(.ReadLine().Split(":")(1).Trim.Replace(",", "")) '第9行('BOTARCAPI_VERSION': 8,)
				.Close()
			End With
			Dim CurrentBotArcAPIVersion As New Version(CurrentBotArcAPIVersionArray(0), CurrentBotArcAPIVersionArray(1), 0, CurrentBotArcAPIVersionArray(2))
			'返回如0.0.0.8(实际为0.0.8)或1.2.0.3(实际为1.2.3)的版本对象
			If LatestBotArcAPIVersion > CurrentBotArcAPIVersion Then
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = $"发现新版本BotArcAPI({LatestVersionRawTag}), 正在尝试更新……"
									  lbl_step1_status.Refresh()
								  End Sub))
				Dim UpdateProcess As Process
				Dim UpdateProcessInfo As New ProcessStartInfo("git", "fetch --all") With {
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden
				}
				UpdateProcess = Process.Start(UpdateProcessInfo)
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "正在更新 BotArcAPI 核心……"
									  lbl_step1_status.Refresh()
								  End Sub))
				UpdateProcess.WaitForExit()
				Dim UpdateProcess2 As Process
				Dim UpdateProcessInfo2 As New ProcessStartInfo("git", "reset --hard origin/master") With {
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden
				}
				UpdateProcess2 = Process.Start(UpdateProcessInfo2)
				UpdateProcess2.WaitForExit()
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "正在更新 BotArcAPI 曲目数据库……"
									  lbl_step1_status.Refresh()
								  End Sub))
				My.Computer.Network.DownloadFile(LatestBotArcAPI.Value(Of JArray)("assets")(0).Value(Of String)("browser_download_url"), My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\savedata\arcsong.db", "", "", False, 100, True)
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "更新完成"
									  lbl_step1_status.Refresh()
								  End Sub))
			Else
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "当前已是最新版本"
									  lbl_step1_status.Refresh()
								  End Sub))
				Thread.Sleep(200)
			End If
			Invoke(New Action(Sub()
								  lbl_step1_status.Text = "正在初始化 BotArcAPI (Node.js:npm) ……"
								  lbl_step1_status.Refresh()
							  End Sub))
			If Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User).EndsWith(";") Then
				Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User) & My.Application.Info.DirectoryPath & "\nodejs", EnvironmentVariableTarget.User)
			Else
				Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User) & ";" & My.Application.Info.DirectoryPath & "\nodejs", EnvironmentVariableTarget.User)
			End If
			Dim NpmInitialization As Process
			Dim NpmInitializationInfo As New ProcessStartInfo(My.Application.Info.DirectoryPath & "\nodejs\npm.cmd") With {
					.Arguments = "config get prefix",
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden,
					.RedirectStandardOutput = True
				}
			NpmInitialization = Process.Start(NpmInitializationInfo)
			Dim NpmStdOut As StreamReader = NpmInitialization.StandardOutput
			NpmConfigPath = NpmStdOut.ReadLine()
			NpmInitialization.Kill()
			If Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User).EndsWith(";") Then
				Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User) & NpmConfigPath, EnvironmentVariableTarget.User)
			Else
				Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User) & ";" & NpmConfigPath, EnvironmentVariableTarget.User)
			End If
			'将npm配置路径写入用户环境变量Path中
			Invoke(New Action(Sub()
								  lbl_step1_status.Text = "正在初始化 BotArcAPI (Node.js:TypeScript) ……"
								  lbl_step1_status.Refresh()
							  End Sub))
			Dim TypeScriptInitialization As Process
			Dim TypeScriptInitializationInfo As New ProcessStartInfo("npm", "install -g typescript") With {
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden
				}
			TypeScriptInitialization = Process.Start(TypeScriptInitializationInfo)
			TypeScriptInitialization.WaitForExit() '等待TypeScript安装完成
			If File.Exists(NpmConfigPath & "\tsc.cmd") Then '如果TypeScript已经安装完成
				Dim BotArcAPICompilation As Process
				Dim BotArcAPICompilationInfo As New ProcessStartInfo("tsc") With {
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden
				}
				BotArcAPICompilation = Process.Start(BotArcAPICompilationInfo)
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "正在初始化 BotArcAPI (Node.js:编译中(TypeScript))"
									  lbl_step1_status.Refresh()
								  End Sub))
				BotArcAPICompilation.WaitForExit()
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "BotArcAPI 初始化完成"
									  Thread.Sleep(500)
									  btn_previous.Enabled = True
									  btn_next.Enabled = True
								  End Sub))
				BotArcAPIUpdateChecked = True
			Else
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "初始化 BotArcAPI 失败: TypeScript安装失败"
									  lbl_step1_status.Refresh()
									  MsgBox("BotArcAPI初始化失败,请尝试重新启动向导以便重新尝试初始化。" & vbCrLf &
											 "程序即将退出。", 16, "提示")
								  End Sub))
				Environment.Exit(0)
			End If
		Catch ex As Exception
			Invoke(New Action(Sub()
								  lbl_step1_status.Text = "正在初始化 BotArcAPI (Node.js:npm) ……"
								  lbl_step1_status.Refresh()
							  End Sub))
			Dim NpmInitialization As Process
			Dim NpmInitializationInfo As New ProcessStartInfo("npm.cmd", "config get prefix") With {
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden,
					.RedirectStandardOutput = True
				}
			NpmInitialization = Process.Start(NpmInitializationInfo)
			NpmInitialization.WaitForExit()
			Dim NpmStdOut As StreamReader = NpmInitialization.StandardOutput
			Dim NpmConfigPath As String = NpmStdOut.ReadLine() '获取npm配置路径
			If Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User).EndsWith(";") Then
				Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User) & NpmConfigPath, EnvironmentVariableTarget.User)
			Else
				Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User) & ";" & NpmConfigPath, EnvironmentVariableTarget.User)
			End If
			'将npm配置路径写入用户环境变量Path中
			Invoke(New Action(Sub()
								  lbl_step1_status.Text = "正在初始化 BotArcAPI (Node.js:TypeScript) ……"
								  lbl_step1_status.Refresh()
							  End Sub))
			If Not File.Exists(NpmConfigPath & "\tsc.cmd") Then '如果未安装TypeScript
				Dim TypeScriptInitialization As Process
				Dim TypeScriptInitializationInfo As New ProcessStartInfo("npm.cmd", "install -g typescript") With {
						.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs",
						.CreateNoWindow = True,
						.UseShellExecute = False,
						.WindowStyle = ProcessWindowStyle.Hidden
					}
				TypeScriptInitialization = Process.Start(TypeScriptInitializationInfo)
				TypeScriptInitialization.WaitForExit() '等待TypeScript安装完成
			End If
			If File.Exists(NpmConfigPath & "\tsc.cmd") Then '如果TypeScript已经安装完成
				Dim BotArcAPICompilation As Process
				Dim BotArcAPICompilationInfo As New ProcessStartInfo(NpmConfigPath & "\tsc.cmd") With {
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden
				}
				BotArcAPICompilation = Process.Start(BotArcAPICompilationInfo)
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "正在初始化 BotArcAPI (Node.js:编译中(TypeScript))"
									  lbl_step1_status.Refresh()
								  End Sub))
				BotArcAPICompilation.WaitForExit()
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "BotArcAPI 初始化完成,单击""下一步""继续。"
									  Thread.Sleep(500)
									  btn_previous.Enabled = True
									  btn_next.Enabled = True
								  End Sub))
				BotArcAPIUpdateChecked = True
			Else
				Invoke(New Action(Sub()
									  lbl_step1_status.Text = "初始化 BotArcAPI 失败: TypeScript安装失败"
									  lbl_step1_status.Refresh()
									  MsgBox("BotArcAPI初始化失败,请尝试重新启动向导以便重新尝试初始化。" & vbCrLf &
											 "程序即将退出。", 16, "提示")
								  End Sub))
				Environment.Exit(0)
			End If
		End Try
	End Sub
End Class