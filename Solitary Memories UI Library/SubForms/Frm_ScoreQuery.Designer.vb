<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ScoreQuery
	Inherits System.Windows.Forms.Form

	'Form 重写 Dispose，以清理组件列表。
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Windows 窗体设计器所必需的
	Private components As System.ComponentModel.IContainer

	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器修改它。  
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ScoreQuery))
		Me.lbl_ifmt = New System.Windows.Forms.Label()
		Me.cbb_playersList = New System.Windows.Forms.ComboBox()
		Me.tbx_playerId = New System.Windows.Forms.TextBox()
		Me.lbl_ifmt2 = New System.Windows.Forms.Label()
		Me.lbl_ifmt3 = New System.Windows.Forms.Label()
		Me.cbb_selectedSong = New System.Windows.Forms.ComboBox()
		Me.lbl_ifmt4 = New System.Windows.Forms.Label()
		Me.cbb_Difficulty = New System.Windows.Forms.ComboBox()
		Me.btn_goQuery = New System.Windows.Forms.Button()
		Me.gbx_queryResult = New System.Windows.Forms.GroupBox()
		Me.btn_copyRaw = New System.Windows.Forms.Button()
		Me.tbx_result = New System.Windows.Forms.TextBox()
		Me.bgwk_ScoreQuery = New System.ComponentModel.BackgroundWorker()
		Me.gbx_queryResult.SuspendLayout()
		Me.SuspendLayout()
		'
		'lbl_ifmt
		'
		resources.ApplyResources(Me.lbl_ifmt, "lbl_ifmt")
		Me.lbl_ifmt.Name = "lbl_ifmt"
		'
		'cbb_playersList
		'
		Me.cbb_playersList.FormattingEnabled = True
		Me.cbb_playersList.Items.AddRange(New Object() {resources.GetString("cbb_playersList.Items")})
		resources.ApplyResources(Me.cbb_playersList, "cbb_playersList")
		Me.cbb_playersList.Name = "cbb_playersList"
		'
		'tbx_playerId
		'
		resources.ApplyResources(Me.tbx_playerId, "tbx_playerId")
		Me.tbx_playerId.Name = "tbx_playerId"
		'
		'lbl_ifmt2
		'
		resources.ApplyResources(Me.lbl_ifmt2, "lbl_ifmt2")
		Me.lbl_ifmt2.Name = "lbl_ifmt2"
		'
		'lbl_ifmt3
		'
		resources.ApplyResources(Me.lbl_ifmt3, "lbl_ifmt3")
		Me.lbl_ifmt3.Name = "lbl_ifmt3"
		'
		'cbb_selectedSong
		'
		Me.cbb_selectedSong.FormattingEnabled = True
		resources.ApplyResources(Me.cbb_selectedSong, "cbb_selectedSong")
		Me.cbb_selectedSong.Name = "cbb_selectedSong"
		'
		'lbl_ifmt4
		'
		resources.ApplyResources(Me.lbl_ifmt4, "lbl_ifmt4")
		Me.lbl_ifmt4.Name = "lbl_ifmt4"
		'
		'cbb_Difficulty
		'
		Me.cbb_Difficulty.AutoCompleteCustomSource.AddRange(New String() {resources.GetString("cbb_Difficulty.AutoCompleteCustomSource"), resources.GetString("cbb_Difficulty.AutoCompleteCustomSource1"), resources.GetString("cbb_Difficulty.AutoCompleteCustomSource2"), resources.GetString("cbb_Difficulty.AutoCompleteCustomSource3")})
		Me.cbb_Difficulty.FormattingEnabled = True
		Me.cbb_Difficulty.Items.AddRange(New Object() {resources.GetString("cbb_Difficulty.Items"), resources.GetString("cbb_Difficulty.Items1"), resources.GetString("cbb_Difficulty.Items2"), resources.GetString("cbb_Difficulty.Items3")})
		resources.ApplyResources(Me.cbb_Difficulty, "cbb_Difficulty")
		Me.cbb_Difficulty.Name = "cbb_Difficulty"
		'
		'btn_goQuery
		'
		resources.ApplyResources(Me.btn_goQuery, "btn_goQuery")
		Me.btn_goQuery.Name = "btn_goQuery"
		Me.btn_goQuery.UseVisualStyleBackColor = True
		'
		'gbx_queryResult
		'
		Me.gbx_queryResult.Controls.Add(Me.btn_copyRaw)
		Me.gbx_queryResult.Controls.Add(Me.tbx_result)
		resources.ApplyResources(Me.gbx_queryResult, "gbx_queryResult")
		Me.gbx_queryResult.Name = "gbx_queryResult"
		Me.gbx_queryResult.TabStop = False
		'
		'btn_copyRaw
		'
		resources.ApplyResources(Me.btn_copyRaw, "btn_copyRaw")
		Me.btn_copyRaw.Name = "btn_copyRaw"
		Me.btn_copyRaw.UseVisualStyleBackColor = True
		'
		'tbx_result
		'
		resources.ApplyResources(Me.tbx_result, "tbx_result")
		Me.tbx_result.Name = "tbx_result"
		Me.tbx_result.ReadOnly = True
		'
		'bgwk_ScoreQuery
		'
		Me.bgwk_ScoreQuery.WorkerReportsProgress = True
		Me.bgwk_ScoreQuery.WorkerSupportsCancellation = True
		'
		'Frm_ScoreQuery
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.gbx_queryResult)
		Me.Controls.Add(Me.btn_goQuery)
		Me.Controls.Add(Me.cbb_Difficulty)
		Me.Controls.Add(Me.lbl_ifmt4)
		Me.Controls.Add(Me.cbb_selectedSong)
		Me.Controls.Add(Me.lbl_ifmt3)
		Me.Controls.Add(Me.lbl_ifmt2)
		Me.Controls.Add(Me.tbx_playerId)
		Me.Controls.Add(Me.cbb_playersList)
		Me.Controls.Add(Me.lbl_ifmt)
		Me.MaximizeBox = False
		Me.Name = "Frm_ScoreQuery"
		Me.ShowIcon = False
		Me.gbx_queryResult.ResumeLayout(False)
		Me.gbx_queryResult.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents lbl_ifmt As Windows.Forms.Label
	Friend WithEvents cbb_playersList As Windows.Forms.ComboBox
	Friend WithEvents tbx_playerId As Windows.Forms.TextBox
	Friend WithEvents lbl_ifmt2 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt3 As Windows.Forms.Label
	Friend WithEvents cbb_selectedSong As Windows.Forms.ComboBox
	Friend WithEvents lbl_ifmt4 As Windows.Forms.Label
	Friend WithEvents cbb_Difficulty As Windows.Forms.ComboBox
	Friend WithEvents btn_goQuery As Windows.Forms.Button
	Friend WithEvents gbx_queryResult As Windows.Forms.GroupBox
	Friend WithEvents btn_copyRaw As Windows.Forms.Button
	Friend WithEvents tbx_result As Windows.Forms.TextBox
	Friend WithEvents bgwk_ScoreQuery As ComponentModel.BackgroundWorker
End Class
