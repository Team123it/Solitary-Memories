Imports System.Data.SQLite
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports Team123it.Arcaea.Solimmr.Global
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.IO.Compression

Public Class Frm_Main
	Public Shared BotArcAPIConig As String = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts"
	Public Shared PlayersPath As String = My.Application.Info.DirectoryPath & "\data\players"
	Public Shared SubScribesPath As String = My.Application.Info.DirectoryPath & "\data\subscribes"
	Dim ConfigLines As String() = File.ReadAllLines(BotArcAPIConig, Encoding.UTF8)
	Public Shared arcaccount As New SQLiteConnection($"Data Source={My.Application.Info.DirectoryPath}\nodejs\node_modules\BotArcAPI\savedata\arcaccount.db")
	Dim AutoQueryTimer As New Timers.Timer([Global].My.MySettings.Default.QueryFrequency * 60 * 1000)
	Dim SubScribeList As New ArrayList()

	Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		If Tag = "sysrun" Then
			Hide()
		Else
			Call RefreshStatus()
			For Each SubScribeDataFile In Directory.GetFiles(SubScribesPath) '遍历添加成绩订阅
				SubScribeList.Add(File.ReadAllText(SubScribeDataFile, Encoding.UTF8))
			Next
			AddHandler AutoQueryTimer.Elapsed, AddressOf AutoQuery
			awmp_Main.URL = My.Application.Info.DirectoryPath & "\data\resources\Main_Loop.mp3"
			awmp_Main.settings.playCount = Integer.MaxValue
		End If
		AutoQueryTimer.Start()
		If [Global].My.MySettings.Default.IsCheckUpdateOnStart Then
			bgwk_AutoUpdate.RunWorkerAsync()
		End If
	End Sub

	Private Sub Frm_Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		awmp_Main.Ctlcontrols.play()
		If Tag = "afterUpdate" Then
			Dim UpdateLog As String = File.ReadAllText(My.Application.Info.DirectoryPath & $"\data\_staging\updlog_{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}.txt", Encoding.UTF8)
			Dim UpdateDate As String = File.ReadAllText(My.Application.Info.DirectoryPath & $"\data\_staging\upddate_{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}.txt", Encoding.UTF8)
			File.Delete(My.Application.Info.DirectoryPath & $"\data\_staging\updlog_{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}.txt")
			File.Delete(My.Application.Info.DirectoryPath & $"\data\_staging\upddate_{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}.txt")
			MsgBox($"Solitary Memories 已更新至 {My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}" & vbCrLf &
					"更新日期:" & UpdateDate &
					"更新日志:" & vbCrLf &
					UpdateLog, 0, "Solitary Memories 已更新")
		End If
	End Sub

	Private Sub AutoQuery()
		Dim LastQueryTime As DateTime = Now - New TimeSpan(0, [Global].My.MySettings.Default.QueryFrequency, 0)
		Dim i As ULong = 1UL
		For Each SubScribe As String In SubScribeList
			Dim SubScribeData As String() = Split(SubScribe, ",", Compare:=CompareMethod.Text)
			Dim PlayerId As String = SubScribeData(0)
			Dim SongName As String = SubScribeData(1)
			Dim SongDiff As String = SubScribeData(2)
			Dim TrigScore As String = SubScribeData(3)
			Dim Result As JObject = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userbest?usercode={PlayerId}&songname={SongName}&difficulty={SongDiff}")
			If Result.Value(Of Integer)("status") = 0 Then
				Dim ResultContent As JObject = Result.Value(Of JObject)("content")
				Dim Score As Integer = ResultContent.Value(Of Integer)("score")
				If Score >= TrigScore Then
					Dim PlayTime As DateTime = TimeZone.CurrentTimeZone.ToLocalTime(New DateTime(1970, 1, 1))
					Dim PlayTimeUNIXTickStr As String = ResultContent.Value(Of Long)("time_played").ToString & "0000"
					Dim PlayTimeAddSpan As New TimeSpan(PlayTimeUNIXTickStr)
					PlayTime = PlayTime.Add(PlayTimeAddSpan)
					If PlayTime > LastQueryTime Then
						Dim PlayerInfo As JObject = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={PlayerId}")
						Dim PlayerName As String = PlayerInfo.Value(Of JObject)("content").Value(Of String)("name")
						Dim SongDiffFriendlyStr As String = ""
						Select Case SongDiff
							Case "0" : SongDiffFriendlyStr = "[PST]"
							Case "1" : SongDiffFriendlyStr = "[PRS]"
							Case "2" : SongDiffFriendlyStr = "[FTR]"
							Case "3" : SongDiffFriendlyStr = "[BYD]"
						End Select
						Invoke(New Action(Sub()
											  ntfi_Main.ShowBalloonTip(10000, "成绩订阅提醒", $"您订阅的玩家{PlayerName}刚刚在{SongName}{SongDiffFriendlyStr}中达成{Score}分的成绩.", ToolTipIcon.Info)
										  End Sub))
						SubScribeList.Remove(SubScribe)
						File.Delete(SubScribesPath & "\" & i)
						i += 1
						Continue For
					End If
				End If
			Else
				i += 1
				Continue For
			End If
		Next
	End Sub

	Private Sub RefreshStatus()
		Dim playersCount As Long = Directory.GetFiles(PlayersPath).LongLength
		Dim subscribesCount As Long = Directory.GetFiles(SubScribesPath).LongLength
		arcaccount.Open()
		Dim arcaccountcmd As New SQLiteCommand("SELECT count('token') FROM accounts", arcaccount)
		Dim arcaccountsCount As Integer = arcaccountcmd.ExecuteScalar
		arcaccount.Close()
		Dim BotArcAPIDetails(2) As String
		For Each ConfigLine In ConfigLines
			If ConfigLine.Contains("BOTARCAPI_VERSTR") Then ' 'BOTARCAPI_VERSTR': 'BotArcAPI v0.0.9',
				BotArcAPIDetails(0) = Split(Split(ConfigLine, "'BOTARCAPI_VERSTR': 'BotArcAPI ", 2, CompareMethod.Text)(1), "'", 2, CompareMethod.Text)(0)
			ElseIf ConfigLine.Contains("ARCAPI_APPVERSION") Then ' 'ARCAPI_APPVERSION': '3.1.0c',
				BotArcAPIDetails(1) = Split(Split(ConfigLine, "'ARCAPI_APPVERSION': '", 2, CompareMethod.Text)(1), "'", 2, CompareMethod.Text)(0)
			Else
				Continue For
			End If
		Next
		lbl_savedPlayerCount.Text = playersCount
		lbl_subscribesCount.Text = subscribesCount
		lbl_queryAccountsCount.Text = arcaccountsCount
		lbl_autoQueryFreq.Text = [Global].My.MySettings.Default.QueryFrequency
		lbl_botarcapiVer.Text = BotArcAPIDetails(0)
		lbl_coreArcaeaVer.Text = BotArcAPIDetails(1)
		tsmi_scores_best30.Visible = [Global].My.MySettings.Default.IsBest30FunctionUnlocked
		tsmi_ntfi_Scores_Best30Query.Visible = [Global].My.MySettings.Default.IsBest30FunctionUnlocked
		Refresh()
	End Sub

	Private Sub Frm_Main_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
		lbl_tips.Text = "(暂无)"
		If Directory.GetFiles(SubScribesPath).Length = 0 Then
			lbl_tips.Text = "看起来您还没有添加任何成绩订阅呢" & vbCrLf & vbCrLf & "单击""成绩(&S)""-""订阅(&S)""-""添加订阅(&A)""以添加成绩订阅。"
		End If
	End Sub

	Private Sub Tsmi_scores_query_Click(sender As Object, e As EventArgs) Handles tsmi_scores_query.Click
		Dim ScoreQuery As New Frm_ScoreQuery
		ScoreQuery.Show()
	End Sub

	Private Sub Tsmi_score_subscribe_Add_Click(sender As Object, e As EventArgs) Handles tsmi_score_subscribe_Add.Click
		Dim NewSubScribePlayerId As Integer, NewSubScribeSongName As String, NewSubScribeDifficulty As String, NewSubScribeScore As UInteger
		NewSubScribeDifficulty = ""
		Do
			Dim NewSubScribePlayer As String = InputBox("请输入要添加的订阅的对应玩家昵称(若已添加该玩家信息)或玩家id(必须是9位数字)", "添加新成绩订阅")
			If IsNumeric(NewSubScribePlayer) Then
				Exit Do
			ElseIf NewSubScribePlayer <> Nothing Then
				If File.Exists(PlayersPath & "\" & NewSubScribePlayer) Then
					NewSubScribePlayerId = File.ReadAllText(PlayersPath & "\" & NewSubScribePlayer, Encoding.UTF8)
					Exit Do
				Else
					MsgBox("输入的不是有效的玩家id或不存在输入的昵称对应的玩家信息,请重新输入", 16, "提示")
					Continue Do
				End If
			Else
				Exit Sub
			End If
		Loop
		Do
			Dim NewSubScribeSongNameStr As String = InputBox("请输入要订阅的曲目名(支持模糊查询,必须是英文名,不支持别名)" & vbCrLf &
															 "Solitary Memories在玩家游玩对应曲目后若满足设定的成绩条件则会弹出任务栏气泡提示。", "添加新成绩订阅")
			If NewSubScribeSongNameStr <> Nothing Then
				Dim arcsong As New SQLiteConnection($"Data Source={My.Application.Info.DirectoryPath}\nodejs\node_modules\BotArcAPI\savedata\arcsong.db")
				arcsong.Open()
				Dim arcsongcmd As New SQLiteCommand($"SELECT count('name_en') FROM songs WHERE name_en LIKE '%{NewSubScribeSongNameStr}%';", arcsong)
				Dim arcsongcmd_GetSongName As New SQLiteCommand($"SELECT name_en FROM songs WHERE name_en LIKE '%{NewSubScribeSongNameStr}%';")
				Dim songCount As Integer = arcsongcmd.ExecuteScalar()
				Dim songName As String = ""
				If songCount = 1 Then
					arcsongcmd_GetSongName.Connection = arcsong
					songName = arcsongcmd_GetSongName.ExecuteScalar()
				End If
				arcsong.Close()
				If songCount = 1 Then
					NewSubScribeSongName = songName
					Exit Do
				ElseIf songCount > 1 Then
					MsgBox("输入的曲目名查询结果过多,请重新输入更完整的曲目名", 16, "提示")
					Continue Do
				Else
					MsgBox("未找到对应曲目,请重新输入一个存在的曲目名", 16, "提示")
					Continue Do
				End If
			Else
				Exit Sub
			End If
		Loop
		Do
			Dim NewSubScribeDifficultyStr As String = InputBox("请输入要订阅的曲目难度(0-3)" & vbCrLf &
												   "0 - Past" & vbCrLf &
												   "1 - Present" & vbCrLf &
												   "2 - Future" & vbCrLf &
												   "3 - Beyond", "添加新成绩订阅", "2")
			If NewSubScribeDifficultyStr <> Nothing Then
				If IsNumeric(NewSubScribeDifficultyStr) Then
					Dim arcsong2 As New SQLiteConnection($"Data Source={My.Application.Info.DirectoryPath}\nodejs\node_modules\BotArcAPI\savedata\arcsong.db")
					arcsong2.Open()
					Dim arcsongcmd2 As New SQLiteCommand($"SELECT difficultly_byn FROM songs WHERE name_en LIKE '%{NewSubScribeSongName}%';", arcsong2)
					Dim CurrentSongBeyondDiff As Integer = arcsongcmd2.ExecuteScalar()
					arcsong2.Close()
					Select Case NewSubScribeDifficultyStr
						Case "0"
							NewSubScribeDifficulty = NewSubScribeDifficultyStr
							Exit Do
						Case "1"
							NewSubScribeDifficulty = NewSubScribeDifficultyStr
							Exit Do
						Case "2"
							NewSubScribeDifficulty = NewSubScribeDifficultyStr
							Exit Do
						Case "3"
							If CurrentSongBeyondDiff <> -1 Then
								NewSubScribeDifficulty = NewSubScribeDifficultyStr
								Exit Do
							Else
								MsgBox("该曲目不存在Beyond难度,请输入一个其他的难度", 16, "提示")
								Continue Do
							End If
					End Select
				Else
					MsgBox("输入的不是数字,请重新输入", 16, "提示")
					Continue Do
				End If
			Else
				Exit Sub
			End If
		Loop
		Do
			Dim NewSubScribeScoreStr As String = InputBox("请输入要订阅的分数(即玩家在指定曲目的指定难度中达成了大于或等于设定的分数后提醒本计算机用户):" & vbCrLf &
														  "警告:Solitary Memories不会判断分数的有效性,请勿输入不可能达到的分数,否则此订阅将永远无法起作用。", "添加新订阅")
			If IsNumeric(NewSubScribeScoreStr) Then
				Try
					NewSubScribeScore = CUInt(NewSubScribeScoreStr)
					Exit Do
				Catch ex As OverflowException
					MsgBox("输入的分数已超过UInteger的上限(4294967295)或低于下限(0),请重新输入", 16, "提示")
					Continue Do
				End Try
			ElseIf NewSubScribeScoreStr <> Nothing Then
				MsgBox("输入的分数不是数字,请重新输入")
			End If
		Loop
		Try
			Dim PlayerInfo As JObject = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={NewSubScribePlayerId}")
			If PlayerInfo.Value(Of Integer)("status") = -1 Then
				MsgBox("添加新订阅失败:对应玩家不存在(-1)", 16, "添加失败")
			ElseIf PlayerInfo.Value(Of Integer)("status") = 0 Then
				Dim NewSubScribePlayerName As String = PlayerInfo.Value(Of JObject)("content").Value(Of String)("name")
				Dim NewSubScribeDiffFriendlyStr As String
				Select Case NewSubScribeDifficulty
					Case "0" : NewSubScribeDiffFriendlyStr = "Past"
					Case "1" : NewSubScribeDiffFriendlyStr = "Present"
					Case "2" : NewSubScribeDiffFriendlyStr = "Future"
					Case "3" : NewSubScribeDiffFriendlyStr = "Beyond"
					Case Else : NewSubScribeDiffFriendlyStr = "Unknown"
				End Select
				If MsgBox("即将添加新的成绩订阅,详细信息:" & vbCrLf &
						  "玩家:" & NewSubScribePlayerName & vbCrLf &
						  "曲目:" & NewSubScribeSongName & vbCrLf &
						  "难度:" & NewSubScribeDiffFriendlyStr & vbCrLf &
						  "提醒触发分数:" & NewSubScribeScore & vbCrLf &
						  vbCrLf &
						  "是否添加该成绩订阅?", vbQuestion + vbYesNo, "添加新订阅") = vbYes Then
					Dim CurrentSubScribeId As Long = Directory.GetFiles(SubScribesPath).LongLength + 1L
					Dim NewSubScribeCreation As New StreamWriter(SubScribesPath & "\" & CurrentSubScribeId, False, Encoding.UTF8)
					NewSubScribeCreation.Write(NewSubScribePlayerId & "," & NewSubScribeSongName & "," & NewSubScribeDifficulty & "," & NewSubScribeScore)
					NewSubScribeCreation.Close()
					SubScribeList.Add(NewSubScribePlayerId & "," & NewSubScribeSongName & "," & NewSubScribeDifficulty & "," & NewSubScribeScore)
					MsgBox("订阅添加成功,新订阅编号为 " & CurrentSubScribeId, 64, "提示")
				End If
			Else
				MsgBox("添加新订阅失败:错误代码:" & PlayerInfo.Value(Of Integer)("status"), 16, "添加失败")
			End If
		Catch ex As Exception
			MsgBox("添加新订阅失败:发生未知异常:" & vbCrLf &
				   ex.ToString, 16, "添加失败")
		End Try
	End Sub

	Private Sub Tsmi_score_subscribe_Remove_Click(sender As Object, e As EventArgs) Handles tsmi_score_subscribe_Remove.Click
		Try
			Do
				Dim DeleteSubScribeIdStr As String = InputBox("成绩订阅会在首次提醒后自动移除,如需要手动移除成绩订阅请在下方输入订阅id", "移除订阅")
				If DeleteSubScribeIdStr <> Nothing Then
					If File.Exists(SubScribesPath & "\" & DeleteSubScribeIdStr) Then
						Dim SubScribeDataStr As String = File.ReadAllText(SubScribesPath & "\" & DeleteSubScribeIdStr, Encoding.UTF8)
						Dim SubScribeData() As String = Split(SubScribeDataStr, ",", Compare:=CompareMethod.Text)
						Dim PlayerId, PlayerName, SongName, SongDiff, Score As String
						PlayerId = SubScribeData(0)
						SongName = SubScribeData(1)
						SongDiff = SubScribeData(2)
						Score = SubScribeData(3)
						Dim PlayerInfo As JObject = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={PlayerId}")
						PlayerName = PlayerInfo.Value(Of JObject)("content").Value(Of String)("name")
						If MsgBox("您将要移除如下成绩订阅:" & vbCrLf &
									"玩家:" & PlayerName & vbCrLf &
									"曲名:" & SongName & vbCrLf &
									"难度:" & SongDiff & vbCrLf &
									"触发分数:" & Score & vbCrLf &
									vbCrLf &
									"是否确实要移除此订阅?", vbYesNo + vbQuestion, "移除订阅") = vbYes Then
							File.Delete(SubScribesPath & "\" & DeleteSubScribeIdStr)
							SubScribeList.Remove(SubScribeDataStr)
							MsgBox("成功移除id为" & DeleteSubScribeIdStr & "的成绩订阅", 64, "提示")
							Exit Do
						End If
					Else
						MsgBox("输入的订阅id无效,请重新输入", 16, "提示")
						Continue Do
					End If
				Else
					Exit Sub
				End If
			Loop
		Catch ex As Exception
			MsgBox("移除成绩订阅失败,发生未知异常:" & vbCrLf &
				   ex.ToString, 16, "移除失败")
		End Try
	End Sub

	Private Sub Tsmi_score_subscribe_List_Click(sender As Object, e As EventArgs) Handles tsmi_score_subscribe_List.Click
		Dim SubScribesList As New Frm_SubScribesList
		SubScribesList.Show()
	End Sub

	Private Sub Frm_Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
		e.Cancel = True
		awmp_Main.Ctlcontrols.pause()
		Hide()
		ntfi_Main.ShowBalloonTip(5000, "提示", "Solitary Memories已最小化到任务栏,双击图标打开主窗口", ToolTipIcon.Info)
	End Sub

	Private Sub Tsmi_players_RefreshStat_Click(sender As Object, e As EventArgs) Handles tsmi_players_RefreshStat.Click
		Call RefreshStatus()
	End Sub

	Private Sub Tsmi_players_Manage_Click(sender As Object, e As EventArgs) Handles tsmi_players_Manage.Click
		Dim PlayersManager As New Frm_PlayersManager
		PlayersManager.Show()
	End Sub

	Private Sub Tsmi_options_Click(sender As Object, e As EventArgs) Handles tsmi_options.Click
		Dim Options As New Frm_Options
		Options.Show()
	End Sub

	Private Sub Tsmi_scores_best30_Click(sender As Object, e As EventArgs) Handles tsmi_scores_best30.Click
		Dim Best30Query As New Frm_Best30Query
		Best30Query.Show()
	End Sub

	Private Sub Tsmi_help_checkupd_Click(sender As Object, e As EventArgs) Handles tsmi_help_checkupd.Click
		Try
			Dim RawData As String = GetAPIReturnJsonStr("https://123-open-source-organization.github.io/api/solimmr/latest.txt", Encoding.UTF8)
			Dim LatestVersionTag As String = Split(RawData, ",", 2, CompareMethod.Text)(0)
			Dim LatestVersionUpdateDate As String = Split(RawData, ",", 2, CompareMethod.Text)(1)
			Dim LatestVersionUpdateLog As String = GetAPIReturnJsonStr("https://123-open-source-organization.github.io/api/solimmr/updlog.txt", Encoding.UTF8)
			Dim LatestVersionDownloadURL As String = GetAPIReturnJsonStr("https://123-open-source-organization.github.io/api/solimmr/latest_downurl.txt", Encoding.UTF8)
			'返回如0.0.9的版本号
			Dim LatestVersionArray(2) As Integer
			LatestVersionArray(0) = CInt(LatestVersionTag.Split(".")(0)) '主版本号 '0.0.9="0"
			LatestVersionArray(1) = CInt(LatestVersionTag.Split(".")(1)) '次版本号 '0.0.9="0"
			LatestVersionArray(2) = CInt(LatestVersionTag.Split(".")(2)) '修订版本号 '0.0.9="9"
			Dim LatestSolitaryMemoriesVersion As New Version(LatestVersionArray(0), LatestVersionArray(1), LatestVersionArray(2))
			'返回如0.0.9.0(实际为0.0.9)或1.2.4.0(实际为1.2.4)的版本对象
			Dim CurrentSolitaryMemoriesVersion As Version = My.Application.Info.Version
			'返回如0.0.8.0(实际为0.0.8)或1.2.3.0(实际为1.2.3)的版本对象
			If LatestSolitaryMemoriesVersion > CurrentSolitaryMemoriesVersion Then
				If MsgBox("发现新版本的Solitary Memories,是否立即更新?" & vbCrLf &
						  "当前版本:" & CurrentSolitaryMemoriesVersion.ToString.Trim(".0") & vbCrLf &
						  "新版本:" & LatestVersionTag & vbCrLf &
						  "更新日期:" & LatestVersionUpdateDate & vbCrLf &
						  "更新日志:" & vbCrLf &
						  LatestVersionUpdateLog, vbQuestion + vbYesNo, "发现新版本") = vbYes Then
					Dim NowStr As String = Format(Now, "yyyyMMddHHmmss")
					Dim TempDownloadFile As String = My.Application.Info.DirectoryPath & "\data\_staging\" & NowStr & ".zip"
					If Not Directory.Exists(My.Application.Info.DirectoryPath & "\data\_staging") Then
						Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\data\_staging")
						File.SetAttributes(My.Application.Info.DirectoryPath & "\data\_staging", FileAttributes.Hidden)
					End If
					My.Computer.Network.DownloadFile(LatestVersionDownloadURL,
						TempDownloadFile, "", "", True, 5000, False)
					Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\data\_staging\" & NowStr)
					ZipFile.ExtractToDirectory(TempDownloadFile, My.Application.Info.DirectoryPath & "\data\_staging\" & NowStr)
					File.Delete(TempDownloadFile)
					MsgBox("Solitary Memories需要重启以完成更新进程。" & vbCrLf &
						   "单击""确定""重启Solitary Memories。", 64, "提示")
					BotArcAPI.Stop()
					Shell(My.Application.Info.DirectoryPath & "\data\_staging\" & NowStr & "\Update.exe -progpath:" & My.Application.Info.DirectoryPath, AppWinStyle.NormalFocus)
					Environment.Exit(0)
				End If
			Else
				MsgBox("当前已是最新版本", 64, "提示")
			End If
		Catch ex As Exception
			MsgBox("更新失败:" & ex.ToString, 16, "更新失败")
		End Try
	End Sub

	Private Sub Tsmi_help_checkapiupd_Click(sender As Object, e As EventArgs) Handles tsmi_help_checkapiupd.Click
		Try
			MsgBox("当前版本不再支持自动检查更新,请运行程序目录下的apiupdate.exe手动更新。", 64, "提示")
			'	Dim ReturnArray As JArray = GetAPIReturnJsonArray([Global].My.Resources.BotArcAPI_UpdateApi)
			'	Dim LatestBotArcAPI As JObject = ReturnArray(0)
			'	Dim LatestVersionRawTag As String = LatestBotArcAPI.Value(Of String)("tag_name")
			'	Dim LatestVersionTag As String = LatestVersionRawTag.Split("-")(0).Replace("v", "")
			'	'返回如0.0.9的版本号
			'	Dim LatestVersionArray(2) As Integer
			'	LatestVersionArray(0) = CInt(LatestVersionTag.Split(".")(0)) '主版本号 '0.0.9="0"
			'	LatestVersionArray(1) = CInt(LatestVersionTag.Split(".")(1)) '次版本号 '0.0.9="0"
			'	LatestVersionArray(2) = CInt(LatestVersionTag.Split(".")(2)) '修订版本号 '0.0.9="9"
			'	Dim LatestBotArcAPIVersion As New Version(LatestVersionArray(0), LatestVersionArray(1), 0, LatestVersionArray(2))
			'	'返回如0.0.0.9(实际为0.0.9)或1.2.0.4(实际为1.2.4)的版本对象
			'	Dim CurrentBotArcAPIVersionArray(2) As Integer
			'	With New StreamReader(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", Encoding.UTF8)
			'		For i = 1 To 6
			'			.ReadLine()
			'		Next
			'		CurrentBotArcAPIVersionArray(0) =
			'			CInt(.ReadLine().Split(":")(1).Trim.Replace(",", "")) '第7行('BOTARCAPI_MAJOR': 0,)
			'		CurrentBotArcAPIVersionArray(1) =
			'			CInt(.ReadLine().Split(":")(1).Trim.Replace(",", "")) '第8行('BOTARCAPI_MINOR': 0,)
			'		CurrentBotArcAPIVersionArray(2) =
			'			CInt(.ReadLine().Split(":")(1).Trim.Replace(",", "")) '第9行('BOTARCAPI_VERSION': 8,)
			'		.Close()
			'	End With
			'	Dim CurrentBotArcAPIVersion As New Version(CurrentBotArcAPIVersionArray(0), CurrentBotArcAPIVersionArray(1), CurrentBotArcAPIVersionArray(2), 0)
			'	'返回如0.0.8.0(实际为0.0.8)或1.2.0.3(实际为1.2.3)的版本对象
			'	If LatestBotArcAPIVersion > CurrentBotArcAPIVersion Then
			'		If MsgBox("发现新版本的 BotArcAPI, 是否立即更新?" & vbCrLf &
			'				  "与Solitary Memories主程序不同,强烈建议立即更新BotArcAPI以保证主程序的正常运行。" & vbCrLf &
			'				  "新版本BotArcAPI版本号:" & LatestBotArcAPIVersion.ToString & vbCrLf &
			'				  "当前版本BotArcAPI版本号:" & CurrentBotArcAPIVersion.ToString, vbQuestion + vbYesNo, "发现 BotArcAPI 新版本") = vbYes Then
			'			BotArcAPI.Stop()
			'			Dim UpdateProcess As Process
			'			Dim UpdateProcessInfo As New ProcessStartInfo("git", "fetch --all") With {
			'				.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
			'				.CreateNoWindow = True,
			'				.UseShellExecute = False,
			'				.WindowStyle = ProcessWindowStyle.Hidden
			'			}
			'			UpdateProcess = Process.Start(UpdateProcessInfo)
			'			UpdateProcess.WaitForExit()
			'			Dim UpdateProcess2 As Process
			'			Dim UpdateProcessInfo2 As New ProcessStartInfo("git", "reset --hard origin/master") With {
			'				.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
			'				.CreateNoWindow = True,
			'				.UseShellExecute = False,
			'				.WindowStyle = ProcessWindowStyle.Hidden
			'			}
			'			UpdateProcess2 = Process.Start(UpdateProcessInfo2)
			'			UpdateProcess2.WaitForExit()
			'			My.Computer.Network.DownloadFile(LatestBotArcAPI.Value(Of JArray)("assets")(0).Value(Of String)("browser_download_url"), My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\savedata\arcsong.db", "", "", True, 5000, True)
			'			Dim BotArcAPIConfig As String = File.ReadAllText(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", Encoding.UTF8)
			'			BotArcAPIConfig = BotArcAPIConfig.Replace("'SERVER_PORT': 80,", $"'SERVER_PORT': {[Global].My.MySettings.Default.APIPort},")
			'			File.WriteAllText(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", BotArcAPIConfig, Encoding.UTF8)
			'			Dim BotArcAPICompilation As Process
			'			Dim BotArcAPICompilationInfo As New ProcessStartInfo("tsc") With {
			'				.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
			'				.CreateNoWindow = True,
			'				.UseShellExecute = False,
			'				.WindowStyle = ProcessWindowStyle.Hidden
			'			}
			'			BotArcAPICompilation = Process.Start(BotArcAPICompilationInfo)
			'			BotArcAPICompilation.WaitForExit()
			'			MsgBox("Solitary Memories需要重启以完成BotArcAPI更新进程。" & vbCrLf &
			'					   "单击""确定""重启Solitary Memories。", 64, "提示")
			'			Shell(Application.ExecutablePath & " -restart", AppWinStyle.NormalFocus)
			'			Environment.Exit(0)
			'		End If
			'	End If
		Catch ex As Win32Exception
			MsgBox("BotArcAPI更新失败,请手动安装Git for Windows后再检查BotArcAPI更新。", 16, "更新失败")
		Catch ex As Exception
			MsgBox("更新失败:" & ex.ToString, 16, "更新失败")
		End Try
	End Sub

	Private Sub Tsmi_ntfi_Players_Manage_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_Players_Manage.Click
		Call Tsmi_players_Manage_Click(sender, e)
	End Sub

	Private Sub Tsmi_ntfi_Scores_Query_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_Scores_Query.Click
		Call Tsmi_scores_query_Click(sender, e)
	End Sub

	Private Sub Tsmi_ntfi_Scores_Subscribe_Add_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_Scores_Subscribe_Add.Click
		Call Tsmi_score_subscribe_Add_Click(sender, e)
	End Sub

	Private Sub Tsmi_ntfi_Scores_Subscribe_Remove_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_Scores_Subscribe_Remove.Click
		Call Tsmi_score_subscribe_Remove_Click(sender, e)
	End Sub

	Private Sub Tsmi_ntfi_Scores_Subscribe_ShowList_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_Scores_Subscribe_ShowList.Click
		Call Tsmi_score_subscribe_List_Click(sender, e)
	End Sub

	Private Sub Tsmi_ntfi_Scores_Best30Query_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_Scores_Best30Query.Click
		Call Tsmi_scores_best30_Click(sender, e)
	End Sub

	Private Sub Tsmi_ntfi_Options_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_Options.Click
		Call Tsmi_options_Click(sender, e)
	End Sub

	Private Sub Tsmi_ntfi_ShowMain_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_ShowMain.Click
		awmp_Main.Ctlcontrols.play()
		Show()
	End Sub

	Private Sub Tsmi_ntfi_Exit_Click(sender As Object, e As EventArgs) Handles tsmi_ntfi_Exit.Click
		If MsgBox("确实要退出Solitary Memories吗?" & vbCrLf &
				  "退出后将不再推送任何已存储的成绩订阅。", vbYesNo + vbQuestion, "退出确认") = vbYes Then
			AutoQueryTimer.Stop()
			awmp_Main.Ctlcontrols.stop()
			BotArcAPI.Stop()
			[Global].My.MySettings.Default.Save()
			Environment.Exit(0)
		End If
	End Sub

	Private Sub Ntfi_Main_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ntfi_Main.MouseDoubleClick
		Call Tsmi_ntfi_ShowMain_Click(sender, e)
	End Sub

	Private Sub Bgwk_AutoUpdate_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwk_AutoUpdate.DoWork
		Try
			Dim ReturnArray As JArray = GetAPIReturnJsonArray("https://api.github.com/repos/123-Open-Source-Organization/Solitary-Memories/releases")
			Dim LatestSolitaryMemories As JObject = ReturnArray(0)
			Dim LatestVersionRawTag As String = LatestSolitaryMemories.Value(Of String)("tag_name")
			Dim LatestVersionTag As String = LatestVersionRawTag.Split("-")(0).Replace("v", "")
			'返回如0.0.9的版本号
			Dim LatestVersionArray(2) As Integer
			LatestVersionArray(0) = CInt(LatestVersionTag.Split(".")(0)) '主版本号 '0.0.9="0"
			LatestVersionArray(1) = CInt(LatestVersionTag.Split(".")(1)) '次版本号 '0.0.9="0"
			LatestVersionArray(2) = CInt(LatestVersionTag.Split(".")(2)) '修订版本号 '0.0.9="9"
			Dim LatestSolitaryMemoriesVersion As New Version(LatestVersionArray(0), LatestVersionArray(1), LatestVersionArray(2))
			'返回如0.0.0.9(实际为0.0.9)或1.2.0.4(实际为1.2.4)的版本对象
			Dim CurrentSolitaryMemoriesVersion As Version = My.Application.Info.Version
			'返回如0.0.0.8(实际为0.0.8)或1.2.0.3(实际为1.2.3)的版本对象
			If LatestSolitaryMemoriesVersion > CurrentSolitaryMemoriesVersion Then
				If Invoke(New Func(Of String)(Function() As String
												  Return MsgBox("发现新版本的Solitary Memories,是否立即更新?" & vbCrLf &
																		"新版本:" & LatestSolitaryMemoriesVersion.ToString & vbCrLf &
																		"当前版本:" & CurrentSolitaryMemoriesVersion.ToString, vbQuestion + vbYesNo, "发现新版本")
											  End Function)) = vbYes Then
					Dim NowStr As String = Format(Now, "yyyyMMddHHmmss")
					Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp & "\Solitary Memories")
					Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp & "\Solitary Memories\" & NowStr)
					Dim TempDownloadFile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & "Solitary Memories\" & NowStr & ".zip"
					My.Computer.Network.DownloadFile(LatestSolitaryMemories.Value(Of JArray)("assets")(0).Value(Of String)("browser_download_url"),
					TempDownloadFile, "", "", True, 5000, False)
					ZipFile.ExtractToDirectory(TempDownloadFile, My.Computer.FileSystem.SpecialDirectories.Temp & "\Solitary Memories\" & NowStr)
					Invoke(New Action(Sub()
										  MsgBox("Solitary Memories需要重启以完成更新进程。" & vbCrLf &
												 "单击""确定""重启Solitary Memories。", 64, "提示")
									  End Sub))
					BotArcAPI.Stop()
					Invoke(New Action(Sub()
										  Shell(My.Computer.FileSystem.SpecialDirectories.Temp & "\Solitary Memories\" & NowStr & "\Update.exe", AppWinStyle.NormalFocus)
									  End Sub))
					Environment.Exit(0)
				End If
			End If
		Catch ex As Exception
			Invoke(New Action(Sub()
								  MsgBox("更新失败:" & ex.ToString, 16, "更新失败")
							  End Sub))
		End Try
	End Sub

	Private Sub Tsmi_help_about_Click(sender As Object, e As EventArgs) Handles tsmi_help_about.Click
		Dim About As New Frm_About
		About.ShowDialog()
	End Sub

End Class