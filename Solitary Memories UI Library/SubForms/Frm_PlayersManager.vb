Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Team123it.Arcaea.Solimmr.Global

Public Class Frm_PlayersManager
	Private Sub Frm_PlayersManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		For Each Player In Directory.GetFiles(Frm_Main.PlayersPath)
			Dim PlayerName As String = Split(Player, "\", Compare:=CompareMethod.Text)(Split(Player, "\", Compare:=CompareMethod.Text).LongLength - 1L)
			Dim PlayerId As String = File.ReadAllText(Player, Encoding.UTF8)
			Dim NewRow As DataRow = dtst_Players.Tables(0).NewRow()
			NewRow(0) = PlayerName
			NewRow(1) = PlayerId
			dtst_Players.Tables(0).Rows.Add(NewRow)
		Next
		dbdgv_Players.DataSource = dtst_Players.Tables(0)
		btn_Add.Enabled = True
		btn_Remove.Enabled = False
	End Sub

	Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
		If (tbx_PlayerNick.Text = Nothing) OrElse (tbx_PlayerNick.Text.Trim = String.Empty) Then
			MsgBox("请输入要添加的玩家昵称", 64, "提示")
		ElseIf (tbx_PlayerId.Text = Nothing) Then
			MsgBox("请输入要添加的玩家id(9位数字id,即好友id)", 64, "提示")
		ElseIf (Not IsNumeric(tbx_PlayerId.Text)) OrElse (tbx_PlayerId.Text.Length <> 9) Then
			MsgBox("请输入正确的9位玩家id(好友id)", 16, "提示")
		Else
			If [Global].My.MySettings.Default.IsCheckPlayerInfoBeforeAdd Then '如果需要在添加玩家前检查玩家信息的正确性
				Try
					Dim ReturnJson As JObject = GetAPIReturnJson($"http://127.0.0.1:{[Global].My.MySettings.Default.APIPort}/v2/userinfo?usercode={tbx_PlayerId.Text}")
					If ReturnJson.Value(Of Integer)("status") = 0 Then
						Dim PlayerTrueName As String = ReturnJson.Value(Of JObject)("content").Value(Of String)("name")
						If PlayerTrueName = tbx_PlayerNick.Text Then
							If File.Exists(Frm_Main.PlayersPath & "\" & tbx_PlayerNick.Text) Then
								MsgBox("试图添加的玩家已经存在于数据库中", 16, "添加失败")
							Else
								File.WriteAllText(Frm_Main.PlayersPath & "\" & tbx_PlayerNick.Text, tbx_PlayerId.Text, Encoding.UTF8)
								Dim NewRow As DataRow = dtst_Players.Tables(0).NewRow()
								NewRow(0) = tbx_PlayerNick.Text
								NewRow(1) = tbx_PlayerId.Text
								dtst_Players.Tables(0).Rows.Add(NewRow)
								MsgBox("添加完成", 64, "提示")
								Focus()
								btn_Remove.Enabled = False
								tbx_PlayerId.Clear()
								tbx_PlayerNick.Clear()
							End If
						Else
							MsgBox("添加失败:玩家信息正确性校验失败:填写的玩家昵称与玩家的实际昵称不符" & vbCrLf &
								   "如需关闭正确性校验,请在主界面中单击""选项(&O)""。", 16, "添加失败")
						End If
					Else
						Throw New JsonException("BotArcAPI返回错误代码" & ReturnJson.Value(Of Integer)("status"))
					End If
				Catch ex As Exception
					MsgBox("添加失败:玩家信息正确性校验失败:发生了未知异常" & vbCrLf &
						   "如需关闭正确性校验,请在主界面中单击""选项(&O)""。" & vbCrLf &
						   vbCrLf &
						   "异常的详细信息:" & vbCrLf &
						   ex.ToString, 16, "添加失败")
				End Try
			Else
				If File.Exists(Frm_Main.PlayersPath & "\" & tbx_PlayerNick.Text) Then
					MsgBox("试图添加的玩家已经存在于数据库中", 16, "添加失败")
				Else
					File.WriteAllText(Frm_Main.PlayersPath & "\" & tbx_PlayerNick.Text, tbx_PlayerId.Text, Encoding.UTF8)
					Dim NewRow As DataRow = dtst_Players.Tables(0).NewRow()
					NewRow(0) = tbx_PlayerNick.Text
					NewRow(1) = tbx_PlayerId.Text
					dtst_Players.Tables(0).Rows.Add(NewRow)
					MsgBox("添加完成", 64, "提示")
					Focus()
					btn_Remove.Enabled = False
					tbx_PlayerId.Clear()
					tbx_PlayerNick.Clear()
				End If
			End If
		End If
	End Sub

	Private Sub Btn_Remove_Click(sender As Object, e As EventArgs) Handles btn_Remove.Click
		If (dbdgv_Players.SelectedRows Is Nothing) OrElse (dbdgv_Players.SelectedRows.Count = 0) Then
			MsgBox("请选中一行玩家信息后再执行移除操作", 16, "提示")
		Else
			Dim RemovePlayerListId As Integer = dbdgv_Players.SelectedRows(0).Index
			Dim RemovePlayerNick As String = dbdgv_Players.Item(0, RemovePlayerListId).Value()
			If MsgBox("确实要将玩家 " & RemovePlayerNick & " 移除吗?", vbYesNo + vbQuestion, "玩家移除确认") = vbYes Then
				File.Delete(Frm_Main.PlayersPath & "\" & RemovePlayerNick)
				Focus()
				dtst_Players.Tables(0).Rows.RemoveAt(RemovePlayerListId)
				MsgBox("移除完成", 64, "提示")
				btn_Add.Enabled = True
				btn_Remove.Enabled = False
				tbx_PlayerId.Clear()
				tbx_PlayerNick.Clear()
			End If
		End If
	End Sub

	Private Sub Dbdgv_Players_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dbdgv_Players.CellClick
		If e.RowIndex <> -1 AndAlso e.ColumnIndex <> -1 Then
			Dim SelectedPlayerName As String = dbdgv_Players.SelectedRows.Item(0).Cells(0).Value()
			Dim SelectedPlayerId As String = dbdgv_Players.SelectedRows.Item(0).Cells(1).Value()
			tbx_PlayerNick.Text = SelectedPlayerName
			tbx_PlayerId.Text = SelectedPlayerId
			btn_Remove.Enabled = True
		End If
	End Sub
End Class