Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Imports Team123it.Arcaea.Solimmr.Global.Globals

Public Class Frm_Options
	Private Sub Btn_General_Save_Click(sender As Object, e As EventArgs) Handles btn_General_Save.Click
		Dim BeforeAPIPort As Integer = [Global].My.MySettings.Default.APIPort
		[Global].My.MySettings.Default.IsCheckPlayerInfoBeforeAdd = cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.Checked
		[Global].My.MySettings.Default.QueryFrequency = npd_SubScribe_AutoQueryFrequency.Value
		[Global].My.MySettings.Default.APIPort = npd_api_RunningPort.Value
		[Global].My.MySettings.Default.Save()
		BotArcAPI.Stop()
		Dim BotArcAPIConfig As String = File.ReadAllText(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", Encoding.UTF8)
		BotArcAPIConfig = BotArcAPIConfig.Replace($"'SERVER_PORT': {BeforeAPIPort},", $"'SERVER_PORT': {npd_api_RunningPort.Value},")
		File.WriteAllText(My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI\source\corefunc\config.ts", BotArcAPIConfig, Encoding.UTF8)
		Dim BotArcAPICompilation As Process
		Dim BotArcAPICompilationInfo As New ProcessStartInfo("tsc") With {
					.WorkingDirectory = My.Application.Info.DirectoryPath & "\nodejs\node_modules\BotArcAPI",
					.CreateNoWindow = True,
					.UseShellExecute = False,
					.WindowStyle = ProcessWindowStyle.Hidden
				}
		BotArcAPICompilation = Process.Start(BotArcAPICompilationInfo)
		BotArcAPICompilation.WaitForExit()
		BotArcAPI.Start()
		MsgBox("设置保存成功,部分设置需要重启Solitary Memories才能生效。", 64, "提示")
	End Sub

	Private Sub Frm_Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		If My.User.IsInRole(BuiltInRole.Administrator) Then
			cbx_Running_SystemStart.Text = "开机自动启动Solitary Memories(隐藏启动动画及主界面)"
			cbx_Running_SystemStart.Enabled = True
		Else
			cbx_Running_SystemStart.Text = "开机自动启动Solitary Memories(设置该项需要管理员权限)"
			cbx_Running_SystemStart.Enabled = False
		End If
		npd_api_RunningPort.Value = [Global].My.MySettings.Default.APIPort
		cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.Checked = [Global].My.MySettings.Default.IsCheckPlayerInfoBeforeAdd
		npd_SubScribe_AutoQueryFrequency.Value = [Global].My.MySettings.Default.QueryFrequency
		cbx_Running_SystemStart.Checked = [Global].My.MySettings.Default.IsSystemAutoStart
		cbx_Running_AutoCheckUpdate.Checked = [Global].My.MySettings.Default.IsCheckUpdateOnStart
		If [Global].My.MySettings.Default.IsBest30FunctionUnlocked Then
			lbl_Running_Best30UnlockStat.Text = "Best30 Function Unlock Status: True"
		Else
			lbl_Running_Best30UnlockStat.Text = "????????????? Status: False"
		End If
	End Sub

	Private Sub btn_Common_Save_Click(sender As Object, e As EventArgs) Handles btn_Common_Save.Click
		[Global].My.MySettings.Default.IsSystemAutoStart = cbx_Running_SystemStart.Checked
		[Global].My.MySettings.Default.IsCheckUpdateOnStart = cbx_Running_AutoCheckUpdate.Checked
		[Global].My.MySettings.Default.Save()
		If [Global].My.MySettings.Default.IsSystemAutoStart <> cbx_Running_SystemStart.Checked Then
			If cbx_Running_SystemStart.Checked = False Then
				Registry.LocalMachine.OpenSubKey("SOFTWARE", True).OpenSubKey("Microsoft", True).OpenSubKey("Windows", True).
						OpenSubKey("CurrentVersion", True).OpenSubKey("Run", True).SetValue("Solitary Memories", "-")
			Else
				Registry.LocalMachine.OpenSubKey("SOFTWARE", True).OpenSubKey("Microsoft", True).OpenSubKey("Windows", True).
						OpenSubKey("CurrentVersion", True).OpenSubKey("Run", True).SetValue("Solitary Memories", Application.ExecutablePath & " -sysrun")
			End If
		End If
		MsgBox("设置保存成功", 64, "提示")
	End Sub

	Private Sub btn_Other_FormatData_Click(sender As Object, e As EventArgs) Handles btn_Other_FormatData.Click
		If MsgBox("确实要清空所有数据并恢复出厂设置吗?" & vbCrLf & "此操作不可撤销!", vbExclamation + vbYesNo) = vbYes Then
			Directory.Delete(My.Application.Info.DirectoryPath & "\data\subscribes", True)
			Directory.Delete(My.Application.Info.DirectoryPath & "\data\players", True)
			[Global].My.MySettings.Default.Reset()
			Shell(Application.ExecutablePath & " -restart", AppWinStyle.NormalFocus)
			Environment.Exit(0)
		End If
	End Sub
End Class