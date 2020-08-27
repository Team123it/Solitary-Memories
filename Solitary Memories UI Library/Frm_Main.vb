Imports Microsoft.DirectX
Imports Microsoft.DirectX.DirectSound
Public Class Frm_Main
	Dim MainBGMPlayer As New Device()
	Dim MainBGMBuffer As New SecondaryBuffer(My.Application.Info.DirectoryPath & "\data\resources\Main_Loop.wav", MainBGMBufferDesc, MainBGMPlayer)
	Dim MainBGMBufferDesc As New BufferDescription() With {
		.ControlVolume = True,
		.CanGetCurrentPosition = True,
		.GlobalFocus = False}
	Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		MainBGMPlayer.SetCooperativeLevel(Me, CooperativeLevel.Priority) '设置优先级
		MainBGMBuffer.Play(0, BufferPlayFlags.Looping) '播放BGM
	End Sub

	Private Sub Frm_Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		If [Global].My.MySettings.Default.IsFirstStart Then
			Dim FirstStart As New Frm_FirstStart
			FirstStart.ShowDialog(Me)
		End If
	End Sub
End Class