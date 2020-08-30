<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Best30Query
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
		Me.gbx_queryResult = New System.Windows.Forms.GroupBox()
		Me.btn_copyRaw = New System.Windows.Forms.Button()
		Me.tbx_result = New System.Windows.Forms.TextBox()
		Me.btn_goQuery = New System.Windows.Forms.Button()
		Me.lbl_ifmt2 = New System.Windows.Forms.Label()
		Me.tbx_playerId = New System.Windows.Forms.TextBox()
		Me.cbb_playersList = New System.Windows.Forms.ComboBox()
		Me.lbl_ifmt = New System.Windows.Forms.Label()
		Me.lbl_ifmt3 = New System.Windows.Forms.Label()
		Me.lbl_ifmt4 = New System.Windows.Forms.Label()
		Me.bgwk_Best30Query = New System.ComponentModel.BackgroundWorker()
		Me.gbx_queryResult.SuspendLayout()
		Me.SuspendLayout()
		'
		'gbx_queryResult
		'
		Me.gbx_queryResult.Controls.Add(Me.btn_copyRaw)
		Me.gbx_queryResult.Controls.Add(Me.tbx_result)
		Me.gbx_queryResult.Location = New System.Drawing.Point(12, 96)
		Me.gbx_queryResult.Name = "gbx_queryResult"
		Me.gbx_queryResult.Size = New System.Drawing.Size(565, 177)
		Me.gbx_queryResult.TabIndex = 15
		Me.gbx_queryResult.TabStop = False
		Me.gbx_queryResult.Text = "查询结果"
		'
		'btn_copyRaw
		'
		Me.btn_copyRaw.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
		'btn_goQuery
		'
		Me.btn_goQuery.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btn_goQuery.Location = New System.Drawing.Point(482, 7)
		Me.btn_goQuery.Name = "btn_goQuery"
		Me.btn_goQuery.Size = New System.Drawing.Size(75, 23)
		Me.btn_goQuery.TabIndex = 14
		Me.btn_goQuery.Text = "开查(&G)!"
		Me.btn_goQuery.UseVisualStyleBackColor = True
		'
		'lbl_ifmt2
		'
		Me.lbl_ifmt2.AutoSize = True
		Me.lbl_ifmt2.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lbl_ifmt2.Location = New System.Drawing.Point(266, 12)
		Me.lbl_ifmt2.Name = "lbl_ifmt2"
		Me.lbl_ifmt2.Size = New System.Drawing.Size(47, 12)
		Me.lbl_ifmt2.TabIndex = 13
		Me.lbl_ifmt2.Text = "玩家id:"
		'
		'tbx_playerId
		'
		Me.tbx_playerId.Location = New System.Drawing.Point(330, 8)
		Me.tbx_playerId.MaxLength = 9
		Me.tbx_playerId.Name = "tbx_playerId"
		Me.tbx_playerId.Size = New System.Drawing.Size(112, 21)
		Me.tbx_playerId.TabIndex = 12
		'
		'cbb_playersList
		'
		Me.cbb_playersList.FormattingEnabled = True
		Me.cbb_playersList.Items.AddRange(New Object() {"(手动输入id)"})
		Me.cbb_playersList.Location = New System.Drawing.Point(108, 8)
		Me.cbb_playersList.Name = "cbb_playersList"
		Me.cbb_playersList.Size = New System.Drawing.Size(121, 20)
		Me.cbb_playersList.TabIndex = 11
		Me.cbb_playersList.Text = "(手动输入id)"
		'
		'lbl_ifmt
		'
		Me.lbl_ifmt.AutoSize = True
		Me.lbl_ifmt.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lbl_ifmt.Location = New System.Drawing.Point(13, 11)
		Me.lbl_ifmt.Name = "lbl_ifmt"
		Me.lbl_ifmt.Size = New System.Drawing.Size(83, 12)
		Me.lbl_ifmt.TabIndex = 10
		Me.lbl_ifmt.Text = "要查询的玩家:"
		'
		'lbl_ifmt3
		'
		Me.lbl_ifmt3.AutoSize = True
		Me.lbl_ifmt3.Location = New System.Drawing.Point(10, 38)
		Me.lbl_ifmt3.Name = "lbl_ifmt3"
		Me.lbl_ifmt3.Size = New System.Drawing.Size(485, 36)
		Me.lbl_ifmt3.TabIndex = 16
		Me.lbl_ifmt3.Text = "Best30 即 玩家所提交的最好的30个成绩(曲目可能重复但对应曲目的难度不重复)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Recent10 即 玩家最近提交的10个成绩(规则与Best30一致)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "一个玩家的个人潜力值即75%的Best30平均值与25%的Recent10平均值之和(保留两位小数)。"
		'
		'lbl_ifmt4
		'
		Me.lbl_ifmt4.AutoSize = True
		Me.lbl_ifmt4.Location = New System.Drawing.Point(12, 81)
		Me.lbl_ifmt4.Name = "lbl_ifmt4"
		Me.lbl_ifmt4.Size = New System.Drawing.Size(545, 12)
		Me.lbl_ifmt4.TabIndex = 17
		Me.lbl_ifmt4.Text = "本程序支持同时打开多个查询窗口查询多个玩家的Best30, 支持的查询并发数上限为查分用账号数量。"
		'
		'bgwk_Best30Query
		'
		Me.bgwk_Best30Query.WorkerReportsProgress = True
		Me.bgwk_Best30Query.WorkerSupportsCancellation = True
		'
		'Frm_Best30Query
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(589, 285)
		Me.Controls.Add(Me.lbl_ifmt4)
		Me.Controls.Add(Me.lbl_ifmt3)
		Me.Controls.Add(Me.gbx_queryResult)
		Me.Controls.Add(Me.btn_goQuery)
		Me.Controls.Add(Me.lbl_ifmt2)
		Me.Controls.Add(Me.tbx_playerId)
		Me.Controls.Add(Me.cbb_playersList)
		Me.Controls.Add(Me.lbl_ifmt)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(605, 324)
		Me.MinimumSize = New System.Drawing.Size(605, 324)
		Me.Name = "Frm_Best30Query"
		Me.ShowIcon = False
		Me.Text = "Best30查询"
		Me.gbx_queryResult.ResumeLayout(False)
		Me.gbx_queryResult.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents gbx_queryResult As Windows.Forms.GroupBox
	Friend WithEvents btn_copyRaw As Windows.Forms.Button
	Friend WithEvents tbx_result As Windows.Forms.TextBox
	Friend WithEvents btn_goQuery As Windows.Forms.Button
	Friend WithEvents lbl_ifmt2 As Windows.Forms.Label
	Friend WithEvents tbx_playerId As Windows.Forms.TextBox
	Friend WithEvents cbb_playersList As Windows.Forms.ComboBox
	Friend WithEvents lbl_ifmt As Windows.Forms.Label
	Friend WithEvents lbl_ifmt3 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt4 As Windows.Forms.Label
	Friend WithEvents bgwk_Best30Query As ComponentModel.BackgroundWorker
End Class
