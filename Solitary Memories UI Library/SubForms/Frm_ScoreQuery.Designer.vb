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
		Me.lbl_ifmt.AutoSize = True
		Me.lbl_ifmt.Location = New System.Drawing.Point(12, 9)
		Me.lbl_ifmt.Name = "lbl_ifmt"
		Me.lbl_ifmt.Size = New System.Drawing.Size(83, 12)
		Me.lbl_ifmt.TabIndex = 0
		Me.lbl_ifmt.Text = "要查询的玩家:"
		'
		'cbb_playersList
		'
		Me.cbb_playersList.FormattingEnabled = True
		Me.cbb_playersList.Items.AddRange(New Object() {"(手动输入id)"})
		Me.cbb_playersList.Location = New System.Drawing.Point(101, 6)
		Me.cbb_playersList.Name = "cbb_playersList"
		Me.cbb_playersList.Size = New System.Drawing.Size(121, 20)
		Me.cbb_playersList.TabIndex = 1
		Me.cbb_playersList.Text = "(手动输入id)"
		'
		'tbx_playerId
		'
		Me.tbx_playerId.Location = New System.Drawing.Point(306, 5)
		Me.tbx_playerId.MaxLength = 9
		Me.tbx_playerId.Name = "tbx_playerId"
		Me.tbx_playerId.Size = New System.Drawing.Size(112, 21)
		Me.tbx_playerId.TabIndex = 2
		'
		'lbl_ifmt2
		'
		Me.lbl_ifmt2.AutoSize = True
		Me.lbl_ifmt2.Location = New System.Drawing.Point(244, 9)
		Me.lbl_ifmt2.Name = "lbl_ifmt2"
		Me.lbl_ifmt2.Size = New System.Drawing.Size(47, 12)
		Me.lbl_ifmt2.TabIndex = 3
		Me.lbl_ifmt2.Text = "玩家id:"
		'
		'lbl_ifmt3
		'
		Me.lbl_ifmt3.AutoSize = True
		Me.lbl_ifmt3.Location = New System.Drawing.Point(12, 42)
		Me.lbl_ifmt3.Name = "lbl_ifmt3"
		Me.lbl_ifmt3.Size = New System.Drawing.Size(35, 12)
		Me.lbl_ifmt3.TabIndex = 4
		Me.lbl_ifmt3.Text = "曲目:"
		'
		'cbb_selectedSong
		'
		Me.cbb_selectedSong.FormattingEnabled = True
		Me.cbb_selectedSong.Location = New System.Drawing.Point(53, 39)
		Me.cbb_selectedSong.Name = "cbb_selectedSong"
		Me.cbb_selectedSong.Size = New System.Drawing.Size(238, 20)
		Me.cbb_selectedSong.TabIndex = 5
		Me.cbb_selectedSong.Text = "(未选择)"
		'
		'lbl_ifmt4
		'
		Me.lbl_ifmt4.AutoSize = True
		Me.lbl_ifmt4.Location = New System.Drawing.Point(304, 42)
		Me.lbl_ifmt4.Name = "lbl_ifmt4"
		Me.lbl_ifmt4.Size = New System.Drawing.Size(35, 12)
		Me.lbl_ifmt4.TabIndex = 6
		Me.lbl_ifmt4.Text = "难度:"
		'
		'cbb_Difficulty
		'
		Me.cbb_Difficulty.AutoCompleteCustomSource.AddRange(New String() {"Past", "Present", "Future", "Beyond"})
		Me.cbb_Difficulty.FormattingEnabled = True
		Me.cbb_Difficulty.Items.AddRange(New Object() {"Past", "Present", "Future", "Beyond"})
		Me.cbb_Difficulty.Location = New System.Drawing.Point(345, 39)
		Me.cbb_Difficulty.Name = "cbb_Difficulty"
		Me.cbb_Difficulty.Size = New System.Drawing.Size(121, 20)
		Me.cbb_Difficulty.TabIndex = 7
		Me.cbb_Difficulty.Text = "(未选择)"
		'
		'btn_goQuery
		'
		Me.btn_goQuery.Location = New System.Drawing.Point(493, 37)
		Me.btn_goQuery.Name = "btn_goQuery"
		Me.btn_goQuery.Size = New System.Drawing.Size(75, 23)
		Me.btn_goQuery.TabIndex = 8
		Me.btn_goQuery.Text = "开查(&G)!"
		Me.btn_goQuery.UseVisualStyleBackColor = True
		'
		'gbx_queryResult
		'
		Me.gbx_queryResult.Controls.Add(Me.btn_copyRaw)
		Me.gbx_queryResult.Controls.Add(Me.tbx_result)
		Me.gbx_queryResult.Location = New System.Drawing.Point(14, 65)
		Me.gbx_queryResult.Name = "gbx_queryResult"
		Me.gbx_queryResult.Size = New System.Drawing.Size(565, 177)
		Me.gbx_queryResult.TabIndex = 9
		Me.gbx_queryResult.TabStop = False
		Me.gbx_queryResult.Text = "查询结果"
		'
		'btn_copyRaw
		'
		Me.btn_copyRaw.Location = New System.Drawing.Point(425, 20)
		Me.btn_copyRaw.Name = "btn_copyRaw"
		Me.btn_copyRaw.Size = New System.Drawing.Size(111, 23)
		Me.btn_copyRaw.TabIndex = 10
		Me.btn_copyRaw.Text = "复制原数据(&C)"
		Me.btn_copyRaw.UseVisualStyleBackColor = True
		'
		'tbx_result
		'
		Me.tbx_result.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tbx_result.Font = New System.Drawing.Font("宋体", 11.0!)
		Me.tbx_result.Location = New System.Drawing.Point(3, 17)
		Me.tbx_result.Multiline = True
		Me.tbx_result.Name = "tbx_result"
		Me.tbx_result.ReadOnly = True
		Me.tbx_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.tbx_result.Size = New System.Drawing.Size(559, 157)
		Me.tbx_result.TabIndex = 11
		'
		'bgwk_ScoreQuery
		'
		Me.bgwk_ScoreQuery.WorkerReportsProgress = True
		Me.bgwk_ScoreQuery.WorkerSupportsCancellation = True
		'
		'Frm_ScoreQuery
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(591, 254)
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
		Me.Text = "成绩查询"
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
