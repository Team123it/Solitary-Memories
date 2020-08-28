#Disable Warning BC42104, IDE1006
Imports System.Data.SQLite
Imports System.IO
Imports System.Text
Imports Team123it.Arcaea.Solimmr.UI.Frm_Main
Imports Team123it.Arcaea.Solimmr.Global
Imports Newtonsoft.Json.Linq
Imports System.Windows.Forms

Public Class Frm_ScoreQuery
	Dim Null As JToken
	Dim RawJsonStr As String
	Private Sub Frm_ScoreQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		For Each Player In Directory.GetFiles(PlayersPath) '遍历添加存储的玩家信息
			cbb_playersList.Items.Add(Split(Player, "\", Compare:=CompareMethod.Text)(Split(Player, "\", Compare:=CompareMethod.Text).Length - 1))
		Next
		Dim ArcSongConnection As New SQLiteConnection($"Data Source={My.Application.Info.DirectoryPath}\nodejs\node_modules\BotArcAPI\savedata\arcsong.db")
		ArcSongConnection.Open() '打开arcsong数据库连接
		Dim ArcSongCmd As New SQLiteCommand("SELECT name_en,name_jp FROM songs;", ArcSongConnection)
		Dim ArcSongDataAdapter As New SQLiteDataAdapter(ArcSongCmd)
		Dim ArcSongDataSet As New DataSet()
		ArcSongDataAdapter.Fill(ArcSongDataSet)
		For Each ArcSongSingleRow As DataRow In ArcSongDataSet.Tables(0).Rows '遍历曲目信息
			If ArcSongSingleRow(1) <> Nothing Then
				cbb_selectedSong.Items.Add(ArcSongSingleRow(1))
			Else
				cbb_selectedSong.Items.Add(ArcSongSingleRow(0))
			End If
		Next
		ArcSongDataSet.Dispose()
		ArcSongDataAdapter.Dispose()
		ArcSongCmd.Dispose()
		ArcSongConnection.Close()

	End Sub

	Private Sub Cbb_playersList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbb_playersList.SelectedIndexChanged
		If cbb_playersList.SelectedItem <> "(手动输入id)" Then '读取存储好的玩家id
			tbx_playerId.Enabled = False
			tbx_playerId.Text = File.ReadAllText(PlayersPath & "\" & cbb_playersList.SelectedItem)
		Else
			tbx_playerId.Text = String.Empty
			tbx_playerId.Enabled = True
		End If
	End Sub

	Private Sub Btn_goQuery_Click(sender As Object, e As EventArgs) Handles btn_goQuery.Click
		If tbx_playerId.Text = Nothing Then
			MsgBox("请选择玩家或手动输入玩家id", 64, "提示")
		ElseIf cbb_selectedSong.Text.Trim = "(未选择)" Then
			MsgBox("请选择要查询的曲目名称", 64, "提示")
		ElseIf cbb_Difficulty.Text.Trim = "(未选择)" Then
			MsgBox("请选择要查询的曲目难度", 64, "提示")
		Else
			bgwk_ScoreQuery.RunWorkerAsync()
		End If
	End Sub

	Private Sub btn_copyRaw_Click(sender As Object, e As EventArgs) Handles btn_copyRaw.Click
		If RawJsonStr <> Nothing Then
			Clipboard.SetText(RawJsonStr, TextDataFormat.Text)
			MsgBox("原数据已复制到剪切板", 64, "提示")
		Else
			MsgBox("请先查询成绩", 64, "提示")
		End If
	End Sub

	Private Sub bgwk_ScoreQuery_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwk_ScoreQuery.DoWork
		Try
			Dim playerId, selectedSong, selectedDifficulty As String
			Invoke(New Action(Sub()
								  playerId = tbx_playerId.Text
								  selectedSong = cbb_selectedSong.SelectedItem
								  selectedDifficulty = cbb_Difficulty.SelectedItem
								  cbb_playersList.Enabled = False
								  tbx_playerId.Enabled = False
								  cbb_selectedSong.Enabled = False
								  cbb_Difficulty.Enabled = False
								  btn_goQuery.Enabled = False
								  tbx_result.Clear()
							  End Sub))
#Region "  核心查询模块(相关API文档可参见 https://github.com/TheSnowfield/BotArcAPI/wiki/Reference-of-v2-userbest )  "
			Dim Difficulty As Byte
			Invoke(New Action(Sub()
								  Select Case selectedDifficulty
									  Case "Past"
										  Difficulty = 0
									  Case "Present"
										  Difficulty = 1
									  Case "Future"
										  Difficulty = 2
									  Case "Beyond"
										  Difficulty = 3
								  End Select
							  End Sub))
			Dim ApiUrl As String = $"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userbest?usercode={tbx_playerId.Text}&songname={selectedSong}&difficulty={Difficulty}"
			Dim ReturnJsonStr As String = GetAPIReturnJsonStr(ApiUrl, Encoding.UTF8)
			RawJsonStr = ReturnJsonStr
			Dim ResultBuilder As New StringBuilder()
			Dim Result As JObject = JObject.Parse(ReturnJsonStr)
			Dim Status As Int32 = Result.Value(Of Integer)("status")
			Select Case Status
				Case 0  'everything is OK
					Dim ResultContent As JObject = Result.Value(Of JObject)("content")
					Dim SongName, DiffStr, ScoreLevel, ClearType, PlayerNick As String
					Dim Score, BigPureCount, PureCount, FarCount, LostCount As Integer
					Dim Rating As Double, Potential As Decimal
					Dim PlayDate As DateTime
					Select Case ResultContent.Value(Of String)("difficulty")
						Case 0 : DiffStr = "Past "
						Case 1 : DiffStr = "Present "
						Case 2 : DiffStr = "Future "
						Case 3 : DiffStr = "Beyond "
						Case Else : DiffStr = "Unknown "
					End Select
					Dim SongApiUrl As String = $"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/songinfo?songname={ResultContent.Value(Of String)("song_id")}"
					Dim SongData As JObject = GetAPIReturnJson(SongApiUrl, Encoding.UTF8).Value(Of JObject)("content")
					If SongData.Value(Of JObject)("title_localized").TryGetValue("ja", Null) Then
						SongName = SongData.Value(Of JObject)("title_localized").Value(Of String)("ja")
					Else
						SongName = SongData.Value(Of JObject)("title_localized").Value(Of String)("en")
					End If
					Dim SongDifficulties As JArray = SongData.Value(Of JArray)("difficulties")
					Select Case ResultContent.Value(Of String)("difficulty")
						Case 0 : DiffStr = DiffStr & SongDifficulties(0).Value(Of Integer)("rating")
						Case 1 : DiffStr = DiffStr & SongDifficulties(1).Value(Of Integer)("rating")
						Case 2
							DiffStr = DiffStr & SongDifficulties(2).Value(Of Integer)("rating")
							If (JObject.FromObject(SongDifficulties(2)).TryGetValue("ratingPlus", Null) AndAlso (SongDifficulties(2).Value(Of Boolean)("ratingPlus"))) Then
								DiffStr = DiffStr & "+"
							End If
						Case 3
							DiffStr = DiffStr & SongDifficulties(3).Value(Of Integer)("rating")
							If (JObject.FromObject(SongDifficulties(3)).TryGetValue("ratingPlus", Null) AndAlso (SongDifficulties(3).Value(Of Boolean)("ratingPlus"))) Then
								DiffStr = DiffStr & "+"
							End If
					End Select
					Select Case ResultContent.Value(Of Integer)("clear_type")
						Case 0 : ClearType = "Track Lost"
						Case 4 : ClearType = "Easy Clear"
						Case 1 : ClearType = "Normal Clear"
						Case 5 : ClearType = "Hard Clear"
						Case 2 : ClearType = "Full Recall"
						Case 3 : ClearType = "Pure Memory"
						Case Else : ClearType = "Unknown Type"
					End Select
					Score = ResultContent.Value(Of Integer)("score")
					BigPureCount = ResultContent.Value(Of Integer)("shiny_perfect_count")
					PureCount = ResultContent.Value(Of Integer)("perfect_count")
					FarCount = ResultContent.Value(Of Integer)("near_count")
					LostCount = ResultContent.Value(Of Integer)("miss_count")
					Rating = ResultContent.Value(Of Double)("rating")
					If Score >= 9900000 Then
						ScoreLevel = "EX+"
					ElseIf Score >= 9800000 AndAlso Score <= 9899999 Then
						ScoreLevel = "EX"
					ElseIf Score >= 9500000 AndAlso Score <= 9799999 Then
						ScoreLevel = "AA"
					ElseIf Score >= 9200000 AndAlso Score <= 9499999 Then
						ScoreLevel = "A"
					ElseIf Score >= 8900000 AndAlso Score <= 9199999 Then
						ScoreLevel = "B"
					ElseIf Score >= 8600000 AndAlso Score <= 8899999 Then
						ScoreLevel = "C"
					Else
						ScoreLevel = "D"
					End If
					PlayDate = TimeZone.CurrentTimeZone.ToLocalTime(New DateTime(1970, 1, 1))
					Dim PlayDateUNIXTickStr As String = ResultContent.Value(Of Long)("time_played").ToString & "0000"
					Dim PlayDateAddSpan As New TimeSpan(PlayDateUNIXTickStr)
					PlayDate = PlayDate.Add(PlayDateAddSpan)
					Dim PlayerApiUrl As String = $"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={tbx_playerId.Text}"
					Dim PlayerResult As JObject = GetAPIReturnJson(PlayerApiUrl, Encoding.UTF8).Value(Of JObject)("content")
					PlayerNick = PlayerResult.Value(Of String)("name")
					Potential = Math.Round(PlayerResult.Value(Of Integer)("rating") / 100, 2)
					ResultBuilder.Append($"用户名:{PlayerNick}")
					If Potential = -0.01D Then
						ResultBuilder.Append($"(--){vbCrLf}")
					Else
						ResultBuilder.Append($"({Potential}){vbCrLf}")
					End If
					ResultBuilder.Append("曲名: ").Append(SongName).Append(" [").Append(DiffStr).Append("]").Append(vbCrLf).
						Append("分数: ").Append(Score).Append(" ( ").Append(ScoreLevel).Append(" / ").Append(ClearType).Append(" )").Append(vbCrLf).
						Append("Pure: ").Append(PureCount).Append(" ( +").Append(BigPureCount).Append(" )").Append(vbCrLf).
						Append("Far: ").Append(FarCount).Append(vbCrLf).
						Append("Lost: ").Append(LostCount).Append(vbCrLf).
						Append("Potential: ").Append(Rating.ToString("#0.000")).Append(vbCrLf).
						Append("游玩日期: ").Append(Format(PlayDate, "yyyy-MM-dd HH:mm:ss"))
				Case -1 'invalid usercode
					ResultBuilder.Append("错误:无效的玩家id(-1)")
				Case -2 'invalid songname
					ResultBuilder.Append("错误:无效的曲名(-2)")
				Case -3 'invalid difficulty
					ResultBuilder.Append("错误:无效的难度(-3)")
				Case -4 'invalid difficulty (map format failed)
					ResultBuilder.Append("错误:无效的难度(谱面格式不支持)(-4)" & vbCrLf &
										 "疑难解答:该错误通常在BotArcAPI为非最新版本时出现, 请检查BotArcAPI是否为最新版本(主界面-""帮助(&H)""-""检查 BotArcAPI 更新(&B)"")。")
				Case -5 'this song is not recorded in the database
					ResultBuilder.Append("错误:未找到曲目信息,可能未收录进数据库(-5)")
				Case -6 'too many records(of the song alias)
					ResultBuilder.Append("提示:查询结果过多,请提供更准确的曲名(-6)")
				Case -7 'internal error(-7)
					ResultBuilder.Append("错误:内部:未知错误(-7)")
				Case -8 'this song has no beyond level
					ResultBuilder.Append("提示:此曲目无Beyond难度,换个查询难度试试?(-8)")
				Case -9 'allocate an arc account failed
					ResultBuilder.Append("错误:内部:分配某个查分用账号失败(-9)")
				Case -10 'clear friend list failed
					ResultBuilder.Append("错误:内部:好友列表清空失败(-10)")
				Case -11 'add friend failed
					ResultBuilder.Append("错误:内部:好友添加失败(-11)")
				Case -12 'internal error(-12)
					ResultBuilder.Append("错误:内部:未知错误(-12)")
				Case -13 'internal error(-13)
					ResultBuilder.Append("错误:内部:未知错误(-13)")
				Case -14 'not played yet
					ResultBuilder.Append("提示:该玩家还未游玩该难度谱面(或游玩但未提交成绩)(-14)")
				Case -233 'unknown error occurred
					ResultBuilder.Append("错误:未知错误(-233)")
			End Select
			Invoke(New Action(Sub()
								  tbx_result.Text = ResultBuilder.ToString
							  End Sub))
#End Region
		Catch ex As Exception
			Invoke(New Action(Sub()
								  tbx_result.Text = "未知异常:" & ex.ToString
							  End Sub))
		Finally
			Invoke(New Action(Sub()
								  cbb_playersList.Enabled = True
								  tbx_playerId.Enabled = True
								  cbb_selectedSong.Enabled = True
								  cbb_Difficulty.Enabled = True
								  btn_goQuery.Enabled = True
							  End Sub))
		End Try
	End Sub
End Class