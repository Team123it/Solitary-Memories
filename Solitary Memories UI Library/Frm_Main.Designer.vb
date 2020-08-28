<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Main
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
		Me.components = New System.ComponentModel.Container()
		Me.msp_Main = New System.Windows.Forms.MenuStrip()
		Me.tsmi_players = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsmi_scores = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsmi_options = New System.Windows.Forms.ToolStripMenuItem()
		Me.ntfi_Main = New System.Windows.Forms.NotifyIcon(Me.components)
		Me.gbx_Start = New System.Windows.Forms.GroupBox()
		Me.lbl_autoQueryFreq = New System.Windows.Forms.Label()
		Me.lbl_min = New System.Windows.Forms.Label()
		Me.lbl_ifmt4 = New System.Windows.Forms.Label()
		Me.lbl_coreArcaeaVer = New System.Windows.Forms.Label()
		Me.lbl_botarcapiVer = New System.Windows.Forms.Label()
		Me.lbl_ifmt6 = New System.Windows.Forms.Label()
		Me.lbl_ifmt5 = New System.Windows.Forms.Label()
		Me.lbl_queryAccountsCount = New System.Windows.Forms.Label()
		Me.lbl_ifmt3 = New System.Windows.Forms.Label()
		Me.lbl_subscribesCount = New System.Windows.Forms.Label()
		Me.lbl_ifmt2 = New System.Windows.Forms.Label()
		Me.lbl_savedPlayerCount = New System.Windows.Forms.Label()
		Me.lbl_ifmt = New System.Windows.Forms.Label()
		Me.gbx_tips = New System.Windows.Forms.GroupBox()
		Me.lbl_tips = New System.Windows.Forms.Label()
		Me.tsmi_scores_query = New System.Windows.Forms.ToolStripMenuItem()
		Me.msp_Main.SuspendLayout()
		Me.gbx_Start.SuspendLayout()
		Me.gbx_tips.SuspendLayout()
		Me.SuspendLayout()
		'
		'msp_Main
		'
		Me.msp_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_players, Me.tsmi_scores, Me.tsmi_options})
		Me.msp_Main.Location = New System.Drawing.Point(0, 0)
		Me.msp_Main.Name = "msp_Main"
		Me.msp_Main.Size = New System.Drawing.Size(686, 25)
		Me.msp_Main.TabIndex = 0
		Me.msp_Main.Text = "MenuStrip1"
		'
		'tsmi_players
		'
		Me.tsmi_players.Name = "tsmi_players"
		Me.tsmi_players.Size = New System.Drawing.Size(59, 21)
		Me.tsmi_players.Text = "玩家(&P)"
		'
		'tsmi_scores
		'
		Me.tsmi_scores.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_scores_query})
		Me.tsmi_scores.Name = "tsmi_scores"
		Me.tsmi_scores.Size = New System.Drawing.Size(59, 21)
		Me.tsmi_scores.Text = "成绩(&S)"
		'
		'tsmi_options
		'
		Me.tsmi_options.Name = "tsmi_options"
		Me.tsmi_options.Size = New System.Drawing.Size(62, 21)
		Me.tsmi_options.Text = "选项(&O)"
		'
		'ntfi_Main
		'
		Me.ntfi_Main.Text = "Solitary Memories"
		Me.ntfi_Main.Visible = True
		'
		'gbx_Start
		'
		Me.gbx_Start.Controls.Add(Me.lbl_autoQueryFreq)
		Me.gbx_Start.Controls.Add(Me.lbl_min)
		Me.gbx_Start.Controls.Add(Me.lbl_ifmt4)
		Me.gbx_Start.Controls.Add(Me.lbl_coreArcaeaVer)
		Me.gbx_Start.Controls.Add(Me.lbl_botarcapiVer)
		Me.gbx_Start.Controls.Add(Me.lbl_ifmt6)
		Me.gbx_Start.Controls.Add(Me.lbl_ifmt5)
		Me.gbx_Start.Controls.Add(Me.lbl_queryAccountsCount)
		Me.gbx_Start.Controls.Add(Me.lbl_ifmt3)
		Me.gbx_Start.Controls.Add(Me.lbl_subscribesCount)
		Me.gbx_Start.Controls.Add(Me.lbl_ifmt2)
		Me.gbx_Start.Controls.Add(Me.lbl_savedPlayerCount)
		Me.gbx_Start.Controls.Add(Me.lbl_ifmt)
		Me.gbx_Start.Location = New System.Drawing.Point(12, 37)
		Me.gbx_Start.Name = "gbx_Start"
		Me.gbx_Start.Size = New System.Drawing.Size(662, 100)
		Me.gbx_Start.TabIndex = 2
		Me.gbx_Start.TabStop = False
		Me.gbx_Start.Text = "状态(单击""玩家(&P)""-""刷新状态(&R)""以刷新)"
		'
		'lbl_autoQueryFreq
		'
		Me.lbl_autoQueryFreq.AutoSize = True
		Me.lbl_autoQueryFreq.Location = New System.Drawing.Point(546, 26)
		Me.lbl_autoQueryFreq.Name = "lbl_autoQueryFreq"
		Me.lbl_autoQueryFreq.Size = New System.Drawing.Size(11, 12)
		Me.lbl_autoQueryFreq.TabIndex = 4
		Me.lbl_autoQueryFreq.Text = "2"
		'
		'lbl_min
		'
		Me.lbl_min.AutoSize = True
		Me.lbl_min.Location = New System.Drawing.Point(582, 26)
		Me.lbl_min.Name = "lbl_min"
		Me.lbl_min.Size = New System.Drawing.Size(23, 12)
		Me.lbl_min.TabIndex = 8
		Me.lbl_min.Text = "min"
		'
		'lbl_ifmt4
		'
		Me.lbl_ifmt4.AutoSize = True
		Me.lbl_ifmt4.Location = New System.Drawing.Point(457, 26)
		Me.lbl_ifmt4.Name = "lbl_ifmt4"
		Me.lbl_ifmt4.Size = New System.Drawing.Size(83, 12)
		Me.lbl_ifmt4.TabIndex = 7
		Me.lbl_ifmt4.Text = "自动查分频率:"
		'
		'lbl_coreArcaeaVer
		'
		Me.lbl_coreArcaeaVer.AutoSize = True
		Me.lbl_coreArcaeaVer.Location = New System.Drawing.Point(442, 55)
		Me.lbl_coreArcaeaVer.Name = "lbl_coreArcaeaVer"
		Me.lbl_coreArcaeaVer.Size = New System.Drawing.Size(47, 12)
		Me.lbl_coreArcaeaVer.TabIndex = 6
		Me.lbl_coreArcaeaVer.Text = "v3.1.0c"
		'
		'lbl_botarcapiVer
		'
		Me.lbl_botarcapiVer.AutoSize = True
		Me.lbl_botarcapiVer.Location = New System.Drawing.Point(115, 55)
		Me.lbl_botarcapiVer.Name = "lbl_botarcapiVer"
		Me.lbl_botarcapiVer.Size = New System.Drawing.Size(41, 12)
		Me.lbl_botarcapiVer.TabIndex = 5
		Me.lbl_botarcapiVer.Text = "v0.0.5"
		'
		'lbl_ifmt6
		'
		Me.lbl_ifmt6.AutoSize = True
		Me.lbl_ifmt6.Location = New System.Drawing.Point(275, 55)
		Me.lbl_ifmt6.Name = "lbl_ifmt6"
		Me.lbl_ifmt6.Size = New System.Drawing.Size(161, 12)
		Me.lbl_ifmt6.TabIndex = 3
		Me.lbl_ifmt6.Text = "BotArcAPI 核心 Arcaea版本:"
		'
		'lbl_ifmt5
		'
		Me.lbl_ifmt5.AutoSize = True
		Me.lbl_ifmt5.Location = New System.Drawing.Point(20, 55)
		Me.lbl_ifmt5.Name = "lbl_ifmt5"
		Me.lbl_ifmt5.Size = New System.Drawing.Size(89, 12)
		Me.lbl_ifmt5.TabIndex = 3
		Me.lbl_ifmt5.Text = "BotArcAPI版本:"
		'
		'lbl_queryAccountsCount
		'
		Me.lbl_queryAccountsCount.AutoSize = True
		Me.lbl_queryAccountsCount.Location = New System.Drawing.Point(404, 26)
		Me.lbl_queryAccountsCount.Name = "lbl_queryAccountsCount"
		Me.lbl_queryAccountsCount.Size = New System.Drawing.Size(11, 12)
		Me.lbl_queryAccountsCount.TabIndex = 3
		Me.lbl_queryAccountsCount.Text = "0"
		'
		'lbl_ifmt3
		'
		Me.lbl_ifmt3.AutoSize = True
		Me.lbl_ifmt3.Location = New System.Drawing.Point(315, 26)
		Me.lbl_ifmt3.Name = "lbl_ifmt3"
		Me.lbl_ifmt3.Size = New System.Drawing.Size(83, 12)
		Me.lbl_ifmt3.TabIndex = 3
		Me.lbl_ifmt3.Text = "查分用账号数:"
		'
		'lbl_subscribesCount
		'
		Me.lbl_subscribesCount.AutoSize = True
		Me.lbl_subscribesCount.Location = New System.Drawing.Point(263, 26)
		Me.lbl_subscribesCount.Name = "lbl_subscribesCount"
		Me.lbl_subscribesCount.Size = New System.Drawing.Size(11, 12)
		Me.lbl_subscribesCount.TabIndex = 3
		Me.lbl_subscribesCount.Text = "0"
		'
		'lbl_ifmt2
		'
		Me.lbl_ifmt2.AutoSize = True
		Me.lbl_ifmt2.Location = New System.Drawing.Point(186, 26)
		Me.lbl_ifmt2.Name = "lbl_ifmt2"
		Me.lbl_ifmt2.Size = New System.Drawing.Size(71, 12)
		Me.lbl_ifmt2.TabIndex = 3
		Me.lbl_ifmt2.Text = "成绩订阅数:"
		'
		'lbl_savedPlayerCount
		'
		Me.lbl_savedPlayerCount.AutoSize = True
		Me.lbl_savedPlayerCount.Location = New System.Drawing.Point(133, 26)
		Me.lbl_savedPlayerCount.Name = "lbl_savedPlayerCount"
		Me.lbl_savedPlayerCount.Size = New System.Drawing.Size(11, 12)
		Me.lbl_savedPlayerCount.TabIndex = 4
		Me.lbl_savedPlayerCount.Text = "0"
		'
		'lbl_ifmt
		'
		Me.lbl_ifmt.AutoSize = True
		Me.lbl_ifmt.Location = New System.Drawing.Point(20, 26)
		Me.lbl_ifmt.Name = "lbl_ifmt"
		Me.lbl_ifmt.Size = New System.Drawing.Size(107, 12)
		Me.lbl_ifmt.TabIndex = 3
		Me.lbl_ifmt.Text = "存储的玩家账号数:"
		'
		'gbx_tips
		'
		Me.gbx_tips.Controls.Add(Me.lbl_tips)
		Me.gbx_tips.Location = New System.Drawing.Point(12, 156)
		Me.gbx_tips.Name = "gbx_tips"
		Me.gbx_tips.Size = New System.Drawing.Size(662, 100)
		Me.gbx_tips.TabIndex = 3
		Me.gbx_tips.TabStop = False
		Me.gbx_tips.Text = "Tips"
		'
		'lbl_tips
		'
		Me.lbl_tips.Location = New System.Drawing.Point(20, 17)
		Me.lbl_tips.Name = "lbl_tips"
		Me.lbl_tips.Size = New System.Drawing.Size(624, 66)
		Me.lbl_tips.TabIndex = 4
		Me.lbl_tips.Text = "(暂无)"
		'
		'tsmi_scores_query
		'
		Me.tsmi_scores_query.Name = "tsmi_scores_query"
		Me.tsmi_scores_query.Size = New System.Drawing.Size(180, 22)
		Me.tsmi_scores_query.Text = "查询(&Q)"
		'
		'Frm_Main
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(686, 271)
		Me.Controls.Add(Me.gbx_tips)
		Me.Controls.Add(Me.gbx_Start)
		Me.Controls.Add(Me.msp_Main)
		Me.MaximizeBox = False
		Me.Name = "Frm_Main"
		Me.Text = "Solitary Memories"
		Me.msp_Main.ResumeLayout(False)
		Me.msp_Main.PerformLayout()
		Me.gbx_Start.ResumeLayout(False)
		Me.gbx_Start.PerformLayout()
		Me.gbx_tips.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents msp_Main As Windows.Forms.MenuStrip
	Friend WithEvents tsmi_players As Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsmi_scores As Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsmi_options As Windows.Forms.ToolStripMenuItem
	Friend WithEvents ntfi_Main As Windows.Forms.NotifyIcon
	Friend WithEvents gbx_Start As Windows.Forms.GroupBox
	Friend WithEvents lbl_ifmt As Windows.Forms.Label
	Friend WithEvents lbl_savedPlayerCount As Windows.Forms.Label
	Friend WithEvents lbl_subscribesCount As Windows.Forms.Label
	Friend WithEvents lbl_ifmt2 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt3 As Windows.Forms.Label
	Friend WithEvents lbl_queryAccountsCount As Windows.Forms.Label
	Friend WithEvents lbl_ifmt5 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt6 As Windows.Forms.Label
	Friend WithEvents lbl_botarcapiVer As Windows.Forms.Label
	Friend WithEvents lbl_coreArcaeaVer As Windows.Forms.Label
	Friend WithEvents gbx_tips As Windows.Forms.GroupBox
	Friend WithEvents lbl_tips As Windows.Forms.Label
	Friend WithEvents lbl_ifmt4 As Windows.Forms.Label
	Friend WithEvents lbl_min As Windows.Forms.Label
	Friend WithEvents lbl_autoQueryFreq As Windows.Forms.Label
	Friend WithEvents tsmi_scores_query As Windows.Forms.ToolStripMenuItem
End Class
