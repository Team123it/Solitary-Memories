Public NotInheritable Class Frm_About
	Dim ClickTimes As Byte = 0

	Private Sub Frm_About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		lbl_version.Text = My.Application.Info.Version.ToString.TrimEnd(".0")
	End Sub

	Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		Me.Close()
	End Sub

	Private Sub ptbx_Title_Click(sender As Object, e As EventArgs) Handles ptbx_Title.Click
		If Not [Global].My.MySettings.Default.IsUnlockedAnomalyFunc Then
			ClickTimes += 1
			If ClickTimes >= 10 Then
				ClickTimes = 0
				Dim AnomalyFunc As New Frm_AnomalyFuncUnlock
				AnomalyFunc.Show()
			End If
		Else
			MsgBox("Welcome to the Extended Arcaea Fanmade Project - Arcaba!" & vbCrLf &
				   "Click the OK button to join the group now!",, "Welcome to Arcaba")
			Process.Start("http://qq.cn.hn/2EK")
		End If
	End Sub
End Class
