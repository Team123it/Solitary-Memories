Imports System.Data.SQLite
Imports System.IO
Imports System.Text
Imports Microsoft.DirectX.DirectSound
Imports System.Timers
Public Class Frm_Main
	Public Shared BotArcAPIConig As String = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts"
	Public Shared PlayersPath As String = My.Application.Info.DirectoryPath & "\data\players"
	Public Shared SubScribesPath As String = My.Application.Info.DirectoryPath & "\data\subscribes"
	Dim ConfigLines As String() = File.ReadAllLines(BotArcAPIConig, Encoding.UTF8)
	Public Shared arcaccount As New SQLiteConnection($"Data Source={My.Application.Info.DirectoryPath}\nodejs\node_modules\BotArcAPI\savedata\arcaccount.db")
	Dim MainBGMPlayer As New Device()
	Dim MainBGMBufferDesc As New BufferDescription() With {
		.ControlVolume = True,
		.CanGetCurrentPosition = True,
		.GlobalFocus = True}
	Dim MainBGMBuffer As New SecondaryBuffer(My.Application.Info.DirectoryPath & "\data\resources\Main_Loop.wav", MainBGMBufferDesc, MainBGMPlayer)
	Dim AutoQueryTimer As New Timer([Global].My.MySettings.Default.QueryFrequency * 60 * 1000)

	Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
		MainBGMPlayer.SetCooperativeLevel(Me, CooperativeLevel.Priority) '设置优先级
		MainBGMBuffer.Volume = -500 '范围为-1000到0
		MainBGMBuffer.Play(0, BufferPlayFlags.Looping) '播放BGM
	End Sub

	Private Sub Frm_Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
	End Sub

	Private Sub MainStart()

	End Sub

	Private Sub Frm_Main_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Me.Paint
		lbl_tips.Text = "(暂无)"
		If Directory.GetFiles(SubScribesPath).Length = 0 Then
			lbl_tips.Text = "看起来您还没有添加任何成绩订阅呢" & vbCrLf & vbCrLf & "单击""成绩(&S)""-""订阅(&S)""-""添加订阅(&A)""以添加成绩订阅。"
		End If
	End Sub

	Private Sub Tsmi_scores_query_Click(sender As Object, e As EventArgs) Handles tsmi_scores_query.Click
		Dim ScoreQuery As New Frm_ScoreQuery
		ScoreQuery.Show()
	End Sub
End Class