Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports Team123it.Arcaea.Solimmr.Global

Public Class Frm_SubScribesList
	Private Sub Frm_SubSribesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim i As ULong = 1UL
		For Each SubScribe In Directory.GetFiles(Frm_Main.SubScribesPath)
			Dim SubScribeData() As String = Split(File.ReadAllText(SubScribe, Encoding.UTF8), ",", Compare:=CompareMethod.Text)
			Dim PlayerName, PlayerId, SongName, Difficulty, Score As String
			PlayerId = SubScribeData(0)
			SongName = SubScribeData(1)
			Select Case SubScribeData(2)
				Case "0" : Difficulty = "Past"
				Case "1" : Difficulty = "Present"
				Case "2" : Difficulty = "Future"
				Case "3" : Difficulty = "Beyond"
				Case Else : Difficulty = "<未知>"
			End Select
			Score = SubScribeData(3)
			PlayerName = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={PlayerId}", Encoding.UTF8).Value(Of JObject)("content").Value(Of String)("name")
			Dim NewRow As DataRow = dtst_subscribeList.Tables(0).NewRow()
			NewRow(0) = i
			NewRow(1) = PlayerName
			NewRow(2) = SongName
			NewRow(3) = Difficulty
			NewRow(4) = Score
			dtst_subscribeList.Tables(0).Rows.Add(NewRow)
			i += 1
		Next
		Me.dbdgv_subscribes.DataSource = dtst_subscribeList.Tables(0)
	End Sub
End Class