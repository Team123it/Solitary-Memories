Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports Team123it.Arcaea.Solimmr.Global

Public Class Frm_SolitaryBoxxx
	Public Const Challenge1 As String = "Grievous Lady"
	Public Const Challenge1_Composer As String = "Team Grimoire vs Laur"
	Public Const Challenge1_Past As String = "Past 6"
	Public Const Challenge1_Present As String = "Present 9"
	Public Const Challenge1_Future As String = "Future 11"
	Public Const Challenge2 As String = "Fracture Ray"
	Public Const Challenge2_Composer As String = "Sakuzyo"
	Public Const Challenge2_Past As String = "Past 6"
	Public Const Challenge2_Present As String = "Present 9"
	Public Const Challenge2_Future As String = "Future 11"
	Public Const ChallengeFinal As String = "Tempestissimo"
	Public Const ChallengeFinal_Composer As String = "t+pazolite"
	Public Const ChallengeFinal_Present As String = "Present 9"
	Public Const ChallengeFinal_Future As String = "Future 10"
	Public Const ChallengeFinal_Beyond As String = "Beyond 11"
	Dim Finished As Boolean = False
	Dim StartDate As DateTime
	Public PlayerId As String
	Dim PlayerName As String
	Dim NowProgress As Byte = 0
	Private Sub Frm_Best30Unlocker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		PlayerName = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={PlayerId}", Encoding.UTF8).Value(Of JObject)("content").Value(Of String)("name")
		lbl_Player.Text = PlayerName
		StartDate = Now
		lbl_SongName.Text = Challenge1
		lbl_SongComposer.Text = Challenge1_Composer
		rbtn_pst.Text = Challenge1_Past
		rbtn_prs.Text = Challenge1_Present
		rbtn_ftr.Text = Challenge1_Future
		lbl_Status.Text = "过关条件: 通关时分数评级在 EX+ 或以上"
		tmr_SolitaryBoxxx.Start()
	End Sub

	Private Sub Frm_Best30Unlocker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		If Not Finished Then
			e.Cancel = True
			MsgBox("无法在解锁成功或失败前离开SOLITARY BOXXX", 16, "提示")
		End If
	End Sub

	Private Sub Tmr_SolitaryBoxxx_Tick(sender As Object, e As EventArgs) Handles tmr_SolitaryBoxxx.Tick
		If CInt(lbl_countdown.Text) = 0 Then
			Select Case NowProgress
				Case 0
					lbl_countdown.Text = "180"
					NowProgress = 1
					rbtn_pst.Enabled = False
					rbtn_prs.Enabled = False
					rbtn_ftr.Enabled = False
					btn_Play.Enabled = False
					lbl_Status.Text = "请游玩本曲所选难度后等待倒计时结束"
				Case 1
					tmr_SolitaryBoxxx.Stop()
					lbl_Status.Text = "正在检查游玩成绩……"
					bgwk_SolitaryBoxxx.RunWorkerAsync()
				Case 2
					lbl_countdown.Text = "180"
					NowProgress = 3
					rbtn_pst.Enabled = False
					rbtn_prs.Enabled = False
					rbtn_ftr.Enabled = False
					btn_Play.Enabled = False
					lbl_Status.Text = "请游玩本曲所选难度后等待倒计时结束"
				Case 3
					tmr_SolitaryBoxxx.Stop()
					lbl_Status.Text = "正在检查游玩成绩……"
					bgwk_SolitaryBoxxx.RunWorkerAsync()
				Case 4
					lbl_countdown.Text = "170"
					NowProgress = 5
					rbtn_pst.Enabled = False
					rbtn_prs.Enabled = False
					rbtn_ftr.Enabled = False
					btn_Play.Enabled = False
					lbl_Status.Text = "请游玩本曲所选难度后等待倒计时结束"
				Case 5
					tmr_SolitaryBoxxx.Stop()
					lbl_Status.Text = "正在检查游玩成绩……"
					bgwk_SolitaryBoxxx.RunWorkerAsync()
			End Select
		Else
			lbl_countdown.Text = (CInt(lbl_countdown.Text) - 1).ToString
		End If
	End Sub

	Private Sub Btn_Play_Click(sender As Object, e As EventArgs) Handles btn_Play.Click
		Select Case NowProgress
			Case 0
				NowProgress = 1
				rbtn_pst.Enabled = False
				rbtn_prs.Enabled = False
				rbtn_ftr.Enabled = False
				btn_Play.Enabled = False
				lbl_countdown.Text = "180"
				lbl_Status.Text = "请游玩本曲所选难度后等待倒计时结束"
			Case 2
				NowProgress = 3
				rbtn_pst.Enabled = False
				rbtn_prs.Enabled = False
				rbtn_ftr.Enabled = False
				btn_Play.Enabled = False
				lbl_countdown.Text = "180"
				lbl_Status.Text = "请游玩本曲所选难度后等待倒计时结束"
			Case 4
				NowProgress = 5
				rbtn_pst.Enabled = False
				rbtn_prs.Enabled = False
				rbtn_ftr.Enabled = False
				btn_Play.Enabled = False
				lbl_countdown.Text = "170"
				lbl_Status.Text = "请游玩本曲所选难度后等待倒计时结束"
		End Select
	End Sub

	Private Sub Bgwk_SolitaryBoxxx_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwk_SolitaryBoxxx.DoWork
		Select Case NowProgress
			Case 1
				Dim RecentPlay As JObject = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={PlayerId}&recent=true").Value(Of JObject)("content").Value(Of JObject)("recent_score")
				Dim RecentSongId As String, RecentSongDiff, RecentSongScore, RecentClearType As Integer
				RecentSongId = RecentPlay.Value(Of String)("song_id")
				RecentSongDiff = RecentPlay.Value(Of Integer)("difficulty")
				RecentSongScore = RecentPlay.Value(Of Integer)("score")
				RecentClearType = RecentPlay.Value(Of Integer)("clear_type")
				If RecentClearType > 0 Then
					If RecentSongId = "grievouslady" Then
						Dim IsCorrectDiff As Boolean = False
						Select Case RecentSongDiff
							Case 0
								If rbtn_pst.Checked Then
									IsCorrectDiff = True
								End If
							Case 1
								If rbtn_prs.Checked Then
									IsCorrectDiff = True
								End If
							Case 2
								If rbtn_ftr.Checked Then
									IsCorrectDiff = True
								End If
						End Select
						If IsCorrectDiff Then
							Dim Playdate As DateTime = TimeZone.CurrentTimeZone.ToLocalTime(New DateTime(1970, 1, 1))
							Dim PlayDateUNIXTickStr As String = RecentPlay.Value(Of Long)("time_played").ToString & "0000"
							Dim PlayDateAddSpan As New TimeSpan(PlayDateUNIXTickStr)
							Playdate = Playdate.Add(PlayDateAddSpan)
							If Playdate > StartDate AndAlso RecentSongScore >= 9900000 Then
								NowProgress = 2
								StartDate = Now
								Invoke(New Action(Sub()
													  lbl_SongName.Text = Challenge2
													  lbl_SongComposer.Text = Challenge2_Composer
													  rbtn_pst.Text = Challenge2_Past
													  rbtn_prs.Text = Challenge2_Present
													  rbtn_ftr.Text = Challenge2_Future
													  lbl_countdown.Text = "35"
													  lbl_Status.Text = "过关条件: 通关时分数评级在 EX+ 或以上"
													  rbtn_ftr.Enabled = True
													  rbtn_prs.Enabled = True
													  rbtn_pst.Enabled = True
													  btn_Play.Enabled = True
													  tmr_SolitaryBoxxx.Start()
												  End Sub))
							End If
						Else
							MsgBox("Game over", 0, "Notice")
							Finished = True
							Close()
						End If
					Else
						MsgBox("Game over", 0, "Notice")
						Finished = True
						Close()
					End If
				Else
					MsgBox("Game over", 0, "Notice")
					Finished = True
					Close()
				End If
			Case 3
				Dim RecentPlay As JObject = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={PlayerId}&recent=true").Value(Of JObject)("content").Value(Of JObject)("recent_score")
				Dim RecentSongId As String, RecentSongDiff, RecentSongScore, RecentClearType As Integer
				RecentSongId = RecentPlay.Value(Of String)("song_id")
				RecentSongDiff = RecentPlay.Value(Of Integer)("difficulty")
				RecentSongScore = RecentPlay.Value(Of Integer)("score")
				RecentClearType = RecentPlay.Value(Of Integer)("clear_type")
				If RecentClearType > 0 Then
					If RecentSongId = "fractureray" Then
						Dim IsCorrectDiff As Boolean = False
						Select Case RecentSongDiff
							Case 0
								If rbtn_pst.Checked Then
									IsCorrectDiff = True
								End If
							Case 1
								If rbtn_prs.Checked Then
									IsCorrectDiff = True
								End If
							Case 2
								If rbtn_ftr.Checked Then
									IsCorrectDiff = True
								End If
						End Select
						If IsCorrectDiff Then
							Dim Playdate As DateTime = TimeZone.CurrentTimeZone.ToLocalTime(New DateTime(1970, 1, 1))
							Dim PlayDateUNIXTickStr As String = RecentPlay.Value(Of Long)("time_played").ToString & "0000"
							Dim PlayDateAddSpan As New TimeSpan(PlayDateUNIXTickStr)
							Playdate = Playdate.Add(PlayDateAddSpan)
							If Playdate > StartDate AndAlso RecentSongScore >= 9900000 Then
								NowProgress = 4
								Invoke(New Action(Sub()
													  lbl_SongName.Text = ChallengeFinal
													  lbl_SongName.ForeColor = Color.Red
													  lbl_SongComposer.Text = ChallengeFinal_Composer
													  lbl_SongComposer.ForeColor = Color.Red
													  rbtn_pst.Text = ChallengeFinal_Present
													  rbtn_prs.Text = ChallengeFinal_Future
													  rbtn_ftr.Text = ChallengeFinal_Beyond
													  lbl_countdown.Text = "35"
													  lbl_Status.Text = "过关条件: 通关时分数评级在 EX 或以上"
													  rbtn_ftr.Enabled = True
													  rbtn_prs.Enabled = True
													  rbtn_pst.Enabled = True
													  btn_Play.Enabled = True
													  MsgBox("本曲目难度仅可选择给定的3个难度之一。" & vbCrLf &
															 "游玩本曲目将会消耗掉所有的Unlock Progress。", 0, "警告")
													  StartDate = Now
													  tmr_SolitaryBoxxx.Start()
												  End Sub))
							End If
						Else
							MsgBox("Game over", 0, "Notice")
							Finished = True
							Close()
						End If
					Else
						MsgBox("Game over", 0, "Notice")
						Finished = True
						Close()
					End If
				Else
					MsgBox("Game over", 0, "Notice")
					Finished = True
					Close()
				End If
			Case 5
				Dim RecentPlay As JObject = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={PlayerId}&recent=true").Value(Of JObject)("content").Value(Of JObject)("recent_score")
				Dim RecentSongId As String, RecentSongDiff, RecentSongScore, RecentClearType As Integer
				RecentSongId = RecentPlay.Value(Of String)("song_id")
				RecentSongDiff = RecentPlay.Value(Of Integer)("difficulty")
				RecentSongScore = RecentPlay.Value(Of Integer)("score")
				RecentClearType = RecentPlay.Value(Of Integer)("clear_type")
				If RecentClearType > 0 Then
					If RecentSongId = "tempestissimo" Then
						Dim IsCorrectDiff As Boolean = False
						Select Case RecentSongDiff
							Case 1
								If rbtn_pst.Checked Then
									IsCorrectDiff = True
								End If
							Case 2
								If rbtn_prs.Checked Then
									IsCorrectDiff = True
								End If
							Case 3
								If rbtn_ftr.Checked Then
									IsCorrectDiff = True
								End If
						End Select
						If IsCorrectDiff Then
							Dim Playdate As DateTime = TimeZone.CurrentTimeZone.ToLocalTime(New DateTime(1970, 1, 1))
							Dim PlayDateUNIXTickStr As String = RecentPlay.Value(Of Long)("time_played").ToString & "0000"
							Dim PlayDateAddSpan As New TimeSpan(PlayDateUNIXTickStr)
							Playdate = Playdate.Add(PlayDateAddSpan)
							If Playdate > StartDate AndAlso RecentSongScore >= 9800000 Then
								NowProgress = 255
								[Global].My.MySettings.Default.IsBest30FunctionUnlocked = True
								[Global].My.MySettings.Default.AnomalyFunc_IsSolitaryBoxxxPassed = True
								[Global].My.MySettings.Default.Save()
								Finished = True
								Invoke(New Action(Sub()
													  MsgBox("Congratulations!" & vbCrLf &
															 "您已解锁隐藏模块 - Best30查询模块。" & vbCrLf &
															 "请回到主界面后单击""玩家(&P)""-""刷新状态(&R)""显示Best30查询模块入口。" & vbCrLf &
															 "入口在主界面-""成绩(&S)""-""Best30查询(&B)""。", 0, "SOLITARY BOXXX Challenge Passed")
													  Dim AnomalyFuncUnlock As New Frm_AnomalyFuncUnlock
													  AnomalyFuncUnlock.Show()
													  Close()
												  End Sub))
							Else
								MsgBox("Game over", 0, "Notice")
								Finished = True
								Close()
							End If
						Else
							MsgBox("Game over", 0, "Notice")
							Finished = True
							Close()
						End If
					Else
						MsgBox("Game over", 0, "Notice")
						Finished = True
						Close()
					End If
				Else
					MsgBox("Game over", 0, "Notice")
					Finished = True
					Close()
				End If
		End Select
	End Sub
End Class