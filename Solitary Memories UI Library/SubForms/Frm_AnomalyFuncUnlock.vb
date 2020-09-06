Imports Newtonsoft.Json.Linq
Imports Team123it.Arcaea.Solimmr.Global
Imports Team123it.Arcaea.Solimmr.Global.My.MySettings

Public Class Frm_AnomalyFuncUnlock
	Private Sub Frm_AnomalyFuncUnlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		If [Default].IsBest30FunctionUnlocked Then
			lbl_solibox.Text = "√ 通过 Solitary Boxxx 挑战"
		Else
			lbl_solibox.Text = "[Locked]"
		End If
		If [Default].AnomalyFunc_TotalManualQueryTimes >= 50 Then
			lbl_querytimes.Text = "√ 手动查询超过50次玩家单曲成绩"
		Else
			lbl_querytimes.Text = "[Locked]"
		End If
		If [Default].AnomalyFunc_IsPlayersCountBiggerThan10 Then
			lbl_playersCount.Text = "√ 已存储的玩家数量超过10个"
		Else
			lbl_playersCount.Text = "[Locked]"
		End If
		If [Default].AnomalyFunc_IsQuerySpecialOrder Then
			lbl_querySpecialOrder.Text = "√ 按顺序查询【Grievous Lady】【Fracture Ray】【Tempestissimo】[FTR]成绩且均通关"
		Else
			lbl_querySpecialOrder.Text = "[Locked]"
		End If
		If [Default].AnomalyFunc_IsConnectStringCorrect Then
			lbl_connectStrCorrect.Text = "√ ???"
		Else
			lbl_connectStrCorrect.Text = "[Locked]"
		End If
	End Sub

	Private Sub Tmr_UnlockEffect_Tick(sender As Object, e As EventArgs) Handles tmr_UnlockEffect.Tick
		Static CurrentProgress As Integer = 0
		CurrentProgress += 1
		Beep() '每1sBeep1次
		If CurrentProgress > 5 Then
			tmr_UnlockEffect.Stop()
			btn_unlock.Enabled = True
		End If
	End Sub

	Private Sub btn_unlock_Click(sender As Object, e As EventArgs) Handles btn_unlock.Click
		[Default].IsUnlockedAnomalyFunc = True
		MsgBox("Welcome...",,)
		MsgBox("To...")
		MsgBox("The")
		MsgBox("Fanmade")
		MsgBox("Sky!")
		Threading.Thread.Sleep(500)
		MsgBox("Welcome to the Extended Arcaea Fanmade Project - Arcaba!" & vbCrLf &
			   "Click the OK button to join the group now!",, "Welcome to Arcaba")
		Process.Start("http://qq.cn.hn/2EK")
		Close()
	End Sub

	Private Sub lbl_connectStrCorrect_Click(sender As Object, e As EventArgs) Handles lbl_connectStrCorrect.Click
		If Not [Default].AnomalyFunc_IsConnectStringCorrect Then
			Dim InputConnectStr As String = InputBox("", "").ToLower
			Dim CorrectConnectStr As String = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/connect").Value(Of JObject)("content").Value(Of String)("key")
			If InputConnectStr = CorrectConnectStr Then
				[Default].AnomalyFunc_IsConnectStringCorrect = True
				lbl_connectStrCorrect.Text = "√ ???"
				If IsAllUnlockedNow() Then
					tmr_UnlockEffect.Start()
				End If
			End If
		End If
	End Sub

	Private Sub Frm_AnomalyFuncUnlock_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		If IsAllUnlockedNow() Then
			tmr_UnlockEffect.Start()
		End If
	End Sub

	Private Function IsAllUnlockedNow() As Boolean
		If ([Default].AnomalyFunc_IsConnectStringCorrect) AndAlso ([Default].AnomalyFunc_IsPlayersCountBiggerThan10) _
						AndAlso [Default].AnomalyFunc_IsQuerySpecialOrder AndAlso [Default].AnomalyFunc_IsSolitaryBoxxxPassed _
						AndAlso ([Default].AnomalyFunc_TotalManualQueryTimes > 50) Then
			Return True
		Else
			Return False
		End If
	End Function
End Class