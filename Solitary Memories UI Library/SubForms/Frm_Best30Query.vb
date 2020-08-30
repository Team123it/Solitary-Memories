Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports Team123it.Arcaea.Solimmr.Global
Imports Team123it.Arcaea.Solimmr.UI.Frm_Main

Public Class Frm_Best30Query
	Dim Null As String = ""
	Dim RawJsonStr As String
	Private Sub Frm_Best30Query_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		For Each Player In Directory.GetFiles(PlayersPath) '遍历添加存储的玩家信息
			cbb_playersList.Items.Add(Split(Player, "\", Compare:=CompareMethod.Text)(Split(Player, "\", Compare:=CompareMethod.Text).Length - 1))
		Next
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
		Else
			bgwk_Best30Query.RunWorkerAsync()
		End If
	End Sub

	Private Sub Bgwk_Best30Query_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwk_Best30Query.DoWork
		Try
			Dim playerId As String
			Invoke(New Action(Sub()
								  playerId = tbx_playerId.Text
								  cbb_playersList.Enabled = False
								  tbx_playerId.Enabled = False
								  btn_goQuery.Enabled = False
								  tbx_result.Clear()
							  End Sub))
#Region "  核心查询模块(相关API文档可参见 https://github.com/TheSnowfield/BotArcAPI/wiki/Reference-of-v2-userbest30 )  "
			Dim ApiUrl As String = $"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userbest30?usercode={tbx_playerId.Text}"
			Invoke(New Action(Sub()
								  tbx_result.Text = "Best30数据正在查询中,请耐心等待"
							  End Sub))
			Dim ReturnJsonStr As String = GetAPIReturnJsonStr(ApiUrl, Encoding.UTF8)
			RawJsonStr = ReturnJsonStr
			Dim ResultBuilder As New StringBuilder()
			Dim Result As JObject = JObject.Parse(ReturnJsonStr)
			Dim Status As Int32 = Result.Value(Of Integer)("status")
			Select Case Status
				Case 0  'everything is OK
					Dim PlayerApiUrl As String = $"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={tbx_playerId.Text}"
					Dim PlayerResult As JObject = GetAPIReturnJson(PlayerApiUrl, Encoding.UTF8).Value(Of JObject)("content")
					Dim PlayerNick As String = PlayerResult.Value(Of String)("name")
					Dim Potential As Double = Math.Round(PlayerResult.Value(Of Integer)("rating") / 100, 2)
					ResultBuilder.Append($"用户名:{PlayerNick}")
					If Potential = -0.01D Then
						ResultBuilder.Append($"(--){vbCrLf}")
					Else
						ResultBuilder.Append($"({Potential}){vbCrLf}")
					End If
					Dim Best30Avg As Double = Result.Value(Of JObject)("content").Value(Of Double)("best30_avg")
					Dim Recent10Avg As Double = Result.Value(Of JObject)("content").Value(Of Double)("recent10_avg")
					ResultBuilder.Append("Best30平均值: ").Append(Best30Avg).Append(vbCrLf).
						Append("Recent10平均值: ").Append(Recent10Avg).Append(vbCrLf).
						Append(vbCrLf).
						Append("Best30 列表:").Append(vbCrLf)
					Dim i As Byte = 1
					For Each Best30SingleData As JObject In Result.Value(Of JObject)("content").Value(Of JArray)("best30_list")
						Dim SongApi As String = $"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/songinfo?songname={Best30SingleData.Value(Of String)("song_id")}"
						Dim SongName, DiffStr, ScoreLevel, ClearType As String
						Dim Score, BigPureCount, PureCount, FarCount, LostCount As Integer
						Dim Rating As Double
						Dim SongData As JObject = GetAPIReturnJson(SongApi, Encoding.UTF8).Value(Of JObject)("content")
						If SongData.Value(Of JObject)("title_localized").TryGetValue("ja", Null) Then
							SongName = SongData.Value(Of JObject)("title_localized").Value(Of String)("ja")
						Else
							SongName = SongData.Value(Of JObject)("title_localized").Value(Of String)("en")
						End If
						Select Case Best30SingleData.Value(Of Integer)("difficulty")
							Case 0 : DiffStr = "Past "
							Case 1 : DiffStr = "Present "
							Case 2 : DiffStr = "Future "
							Case 3 : DiffStr = "Beyond "
							Case Else : DiffStr = "Unknown "
						End Select
						Dim SongDifficulties As JArray = SongData.Value(Of JArray)("difficulties")
						DiffStr = DiffStr & JObject.FromObject(SongDifficulties(Best30SingleData.Value(Of Integer)("difficulty"))).Value(Of Integer)("rating")
						If JObject.FromObject(SongDifficulties(Best30SingleData.Value(Of Integer)("difficulty"))).TryGetValue("ratingPlus", Null) _
							AndAlso JObject.FromObject(SongDifficulties(Best30SingleData.Value(Of Integer)("difficulty"))).Value(Of Boolean)("ratingPlus") Then
							DiffStr = DiffStr & "+"
						End If
						Select Case Best30SingleData.Value(Of Integer)("clear_type")
							Case 0 : ClearType = "Track Lost"
							Case 4 : ClearType = "Easy Clear"
							Case 1 : ClearType = "Normal Clear"
							Case 5 : ClearType = "Hard Clear"
							Case 2 : ClearType = "Full Recall"
							Case 3 : ClearType = "Pure Memory"
							Case Else : ClearType = "Unknown Type"
						End Select
						Score = Best30SingleData.Value(Of Integer)("score")
						BigPureCount = Best30SingleData.Value(Of Integer)("shiny_perfect_count")
						PureCount = Best30SingleData.Value(Of Integer)("perfect_count")
						FarCount = Best30SingleData.Value(Of Integer)("near_count")
						LostCount = Best30SingleData.Value(Of Integer)("miss_count")
						Rating = Best30SingleData.Value(Of Double)("rating")
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
						ResultBuilder.Append(i).Append(". ").Append(SongName).Append("[").Append(DiffStr).Append("]").Append(vbCrLf).
							Append("分数: ").Append(Score).Append(Space(1)).Append("[ ").Append(ScoreLevel).Append(" / ").Append(ClearType).Append(" ]").Append(vbCrLf).
							Append("Pure: ").Append(PureCount).Append(" Far: ").Append(FarCount).Append(" Lost: ").Append(LostCount).Append(vbCrLf).
							Append("Potential: ").Append(Rating.ToString("#0.000")).Append(vbCrLf).
							Append(vbCrLf)
						i += 1
					Next
				Case Else
					ResultBuilder.Clear().Append("错误:未知错误(" & Status & ")")
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
								  btn_goQuery.Enabled = True
							  End Sub))
		End Try
	End Sub

	Private Sub Btn_copyRaw_Click(sender As Object, e As EventArgs) Handles btn_copyRaw.Click
		If RawJsonStr <> Nothing Then
			Clipboard.SetText(RawJsonStr, TextDataFormat.Text)
			MsgBox("原数据已复制到剪切板", 64, "提示")
		Else
			MsgBox("请先查询Best30数据", 64, "提示")
		End If
	End Sub
End Class