<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Options
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
		Me.tcl_Options = New System.Windows.Forms.TabControl()
		Me.tclpg_Common = New System.Windows.Forms.TabPage()
		Me.gbx_Subscribe = New System.Windows.Forms.GroupBox()
		Me.lbl_SubScribe_ifmt3 = New System.Windows.Forms.Label()
		Me.lbl_SubScribe_ifmt2 = New System.Windows.Forms.Label()
		Me.npd_SubScribe_AutoQueryFrequency = New System.Windows.Forms.NumericUpDown()
		Me.lbl_SubScribe_ifmt = New System.Windows.Forms.Label()
		Me.btn_General_Save = New System.Windows.Forms.Button()
		Me.gbx_PlayersManager = New System.Windows.Forms.GroupBox()
		Me.lbl_PlayersManager_ifmt = New System.Windows.Forms.Label()
		Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd = New System.Windows.Forms.CheckBox()
		Me.gbx_BotArcAPI = New System.Windows.Forms.GroupBox()
		Me.lbl_api_ifmt2 = New System.Windows.Forms.Label()
		Me.npd_api_RunningPort = New System.Windows.Forms.NumericUpDown()
		Me.lbl_api_ifmt = New System.Windows.Forms.Label()
		Me.tclpg_General = New System.Windows.Forms.TabPage()
		Me.btn_Common_Save = New System.Windows.Forms.Button()
		Me.gbx_Other = New System.Windows.Forms.GroupBox()
		Me.lbl_Other_ifmt = New System.Windows.Forms.Label()
		Me.btn_Other_FormatData = New System.Windows.Forms.Button()
		Me.gbx_General_Run = New System.Windows.Forms.GroupBox()
		Me.lbl_Running_Best30UnlockStat = New System.Windows.Forms.Label()
		Me.cbx_Running_AutoCheckUpdate = New System.Windows.Forms.CheckBox()
		Me.cbx_Running_SystemStart = New System.Windows.Forms.CheckBox()
		Me.tcl_Options.SuspendLayout()
		Me.tclpg_Common.SuspendLayout()
		Me.gbx_Subscribe.SuspendLayout()
		CType(Me.npd_SubScribe_AutoQueryFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.gbx_PlayersManager.SuspendLayout()
		Me.gbx_BotArcAPI.SuspendLayout()
		CType(Me.npd_api_RunningPort, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tclpg_General.SuspendLayout()
		Me.gbx_Other.SuspendLayout()
		Me.gbx_General_Run.SuspendLayout()
		Me.SuspendLayout()
		'
		'tcl_Options
		'
		Me.tcl_Options.Controls.Add(Me.tclpg_Common)
		Me.tcl_Options.Controls.Add(Me.tclpg_General)
		Me.tcl_Options.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tcl_Options.Location = New System.Drawing.Point(0, 0)
		Me.tcl_Options.Name = "tcl_Options"
		Me.tcl_Options.SelectedIndex = 0
		Me.tcl_Options.Size = New System.Drawing.Size(561, 307)
		Me.tcl_Options.TabIndex = 0
		'
		'tclpg_Common
		'
		Me.tclpg_Common.Controls.Add(Me.gbx_Subscribe)
		Me.tclpg_Common.Controls.Add(Me.btn_General_Save)
		Me.tclpg_Common.Controls.Add(Me.gbx_PlayersManager)
		Me.tclpg_Common.Controls.Add(Me.gbx_BotArcAPI)
		Me.tclpg_Common.Location = New System.Drawing.Point(4, 22)
		Me.tclpg_Common.Name = "tclpg_Common"
		Me.tclpg_Common.Padding = New System.Windows.Forms.Padding(3)
		Me.tclpg_Common.Size = New System.Drawing.Size(553, 281)
		Me.tclpg_Common.TabIndex = 0
		Me.tclpg_Common.Text = "常规"
		Me.tclpg_Common.UseVisualStyleBackColor = True
		'
		'gbx_Subscribe
		'
		Me.gbx_Subscribe.Controls.Add(Me.lbl_SubScribe_ifmt3)
		Me.gbx_Subscribe.Controls.Add(Me.lbl_SubScribe_ifmt2)
		Me.gbx_Subscribe.Controls.Add(Me.npd_SubScribe_AutoQueryFrequency)
		Me.gbx_Subscribe.Controls.Add(Me.lbl_SubScribe_ifmt)
		Me.gbx_Subscribe.Location = New System.Drawing.Point(8, 185)
		Me.gbx_Subscribe.Name = "gbx_Subscribe"
		Me.gbx_Subscribe.Size = New System.Drawing.Size(537, 59)
		Me.gbx_Subscribe.TabIndex = 2
		Me.gbx_Subscribe.TabStop = False
		Me.gbx_Subscribe.Text = "成绩订阅"
		'
		'lbl_SubScribe_ifmt3
		'
		Me.lbl_SubScribe_ifmt3.AutoSize = True
		Me.lbl_SubScribe_ifmt3.Location = New System.Drawing.Point(272, 26)
		Me.lbl_SubScribe_ifmt3.Name = "lbl_SubScribe_ifmt3"
		Me.lbl_SubScribe_ifmt3.Size = New System.Drawing.Size(71, 12)
		Me.lbl_SubScribe_ifmt3.TabIndex = 1
		Me.lbl_SubScribe_ifmt3.Text = "(范围:2-60)"
		'
		'lbl_SubScribe_ifmt2
		'
		Me.lbl_SubScribe_ifmt2.AutoSize = True
		Me.lbl_SubScribe_ifmt2.Location = New System.Drawing.Point(237, 26)
		Me.lbl_SubScribe_ifmt2.Name = "lbl_SubScribe_ifmt2"
		Me.lbl_SubScribe_ifmt2.Size = New System.Drawing.Size(29, 12)
		Me.lbl_SubScribe_ifmt2.TabIndex = 1
		Me.lbl_SubScribe_ifmt2.Text = "分钟"
		'
		'npd_SubScribe_AutoQueryFrequency
		'
		Me.npd_SubScribe_AutoQueryFrequency.Location = New System.Drawing.Point(108, 24)
		Me.npd_SubScribe_AutoQueryFrequency.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
		Me.npd_SubScribe_AutoQueryFrequency.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
		Me.npd_SubScribe_AutoQueryFrequency.Name = "npd_SubScribe_AutoQueryFrequency"
		Me.npd_SubScribe_AutoQueryFrequency.Size = New System.Drawing.Size(120, 21)
		Me.npd_SubScribe_AutoQueryFrequency.TabIndex = 1
		Me.npd_SubScribe_AutoQueryFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.npd_SubScribe_AutoQueryFrequency.Value = New Decimal(New Integer() {2, 0, 0, 0})
		'
		'lbl_SubScribe_ifmt
		'
		Me.lbl_SubScribe_ifmt.AutoSize = True
		Me.lbl_SubScribe_ifmt.Location = New System.Drawing.Point(19, 26)
		Me.lbl_SubScribe_ifmt.Name = "lbl_SubScribe_ifmt"
		Me.lbl_SubScribe_ifmt.Size = New System.Drawing.Size(83, 12)
		Me.lbl_SubScribe_ifmt.TabIndex = 1
		Me.lbl_SubScribe_ifmt.Text = "自动查分频率:"
		'
		'btn_General_Save
		'
		Me.btn_General_Save.Location = New System.Drawing.Point(451, 250)
		Me.btn_General_Save.Name = "btn_General_Save"
		Me.btn_General_Save.Size = New System.Drawing.Size(94, 23)
		Me.btn_General_Save.TabIndex = 1
		Me.btn_General_Save.Text = "保存设置(&S)"
		Me.btn_General_Save.UseVisualStyleBackColor = True
		'
		'gbx_PlayersManager
		'
		Me.gbx_PlayersManager.Controls.Add(Me.lbl_PlayersManager_ifmt)
		Me.gbx_PlayersManager.Controls.Add(Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd)
		Me.gbx_PlayersManager.Location = New System.Drawing.Point(8, 76)
		Me.gbx_PlayersManager.Name = "gbx_PlayersManager"
		Me.gbx_PlayersManager.Size = New System.Drawing.Size(537, 103)
		Me.gbx_PlayersManager.TabIndex = 1
		Me.gbx_PlayersManager.TabStop = False
		Me.gbx_PlayersManager.Text = "玩家列表"
		'
		'lbl_PlayersManager_ifmt
		'
		Me.lbl_PlayersManager_ifmt.Location = New System.Drawing.Point(19, 39)
		Me.lbl_PlayersManager_ifmt.Name = "lbl_PlayersManager_ifmt"
		Me.lbl_PlayersManager_ifmt.Size = New System.Drawing.Size(489, 61)
		Me.lbl_PlayersManager_ifmt.TabIndex = 2
		Me.lbl_PlayersManager_ifmt.Text = """玩家正确性校验""会在添加玩家时检查所输入的玩家是否存在或填写的玩家信息是否与实际一致。强烈建议启用该功能。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "若试图添加自行定义的玩家昵称(如将h1r的玩家" &
	"昵称定义为郝一日),请禁用该功能。"
		'
		'cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd
		'
		Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.AutoSize = True
		Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.Location = New System.Drawing.Point(21, 20)
		Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.Name = "cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd"
		Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.Size = New System.Drawing.Size(156, 16)
		Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.TabIndex = 1
		Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.Text = "启用玩家信息正确性校验"
		Me.cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd.UseVisualStyleBackColor = True
		'
		'gbx_BotArcAPI
		'
		Me.gbx_BotArcAPI.Controls.Add(Me.lbl_api_ifmt2)
		Me.gbx_BotArcAPI.Controls.Add(Me.npd_api_RunningPort)
		Me.gbx_BotArcAPI.Controls.Add(Me.lbl_api_ifmt)
		Me.gbx_BotArcAPI.Location = New System.Drawing.Point(8, 6)
		Me.gbx_BotArcAPI.Name = "gbx_BotArcAPI"
		Me.gbx_BotArcAPI.Size = New System.Drawing.Size(537, 64)
		Me.gbx_BotArcAPI.TabIndex = 0
		Me.gbx_BotArcAPI.TabStop = False
		Me.gbx_BotArcAPI.Text = "BotArcAPI"
		'
		'lbl_api_ifmt2
		'
		Me.lbl_api_ifmt2.AutoSize = True
		Me.lbl_api_ifmt2.Location = New System.Drawing.Point(237, 28)
		Me.lbl_api_ifmt2.Name = "lbl_api_ifmt2"
		Me.lbl_api_ifmt2.Size = New System.Drawing.Size(239, 12)
		Me.lbl_api_ifmt2.TabIndex = 1
		Me.lbl_api_ifmt2.Text = "(范围:1-65535,推荐设置大于1000的端口号)"
		'
		'npd_api_RunningPort
		'
		Me.npd_api_RunningPort.Location = New System.Drawing.Point(98, 26)
		Me.npd_api_RunningPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
		Me.npd_api_RunningPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.npd_api_RunningPort.Name = "npd_api_RunningPort"
		Me.npd_api_RunningPort.Size = New System.Drawing.Size(120, 21)
		Me.npd_api_RunningPort.TabIndex = 2
		Me.npd_api_RunningPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.npd_api_RunningPort.Value = New Decimal(New Integer() {61666, 0, 0, 0})
		'
		'lbl_api_ifmt
		'
		Me.lbl_api_ifmt.AutoSize = True
		Me.lbl_api_ifmt.Location = New System.Drawing.Point(19, 28)
		Me.lbl_api_ifmt.Name = "lbl_api_ifmt"
		Me.lbl_api_ifmt.Size = New System.Drawing.Size(59, 12)
		Me.lbl_api_ifmt.TabIndex = 1
		Me.lbl_api_ifmt.Text = "运行端口:"
		'
		'tclpg_General
		'
		Me.tclpg_General.Controls.Add(Me.btn_Common_Save)
		Me.tclpg_General.Controls.Add(Me.gbx_Other)
		Me.tclpg_General.Controls.Add(Me.gbx_General_Run)
		Me.tclpg_General.Location = New System.Drawing.Point(4, 22)
		Me.tclpg_General.Name = "tclpg_General"
		Me.tclpg_General.Padding = New System.Windows.Forms.Padding(3)
		Me.tclpg_General.Size = New System.Drawing.Size(553, 281)
		Me.tclpg_General.TabIndex = 1
		Me.tclpg_General.Text = "通用"
		Me.tclpg_General.UseVisualStyleBackColor = True
		'
		'btn_Common_Save
		'
		Me.btn_Common_Save.Location = New System.Drawing.Point(451, 250)
		Me.btn_Common_Save.Name = "btn_Common_Save"
		Me.btn_Common_Save.Size = New System.Drawing.Size(94, 23)
		Me.btn_Common_Save.TabIndex = 1
		Me.btn_Common_Save.Text = "保存设置(&S)"
		Me.btn_Common_Save.UseVisualStyleBackColor = True
		'
		'gbx_Other
		'
		Me.gbx_Other.Controls.Add(Me.lbl_Other_ifmt)
		Me.gbx_Other.Controls.Add(Me.btn_Other_FormatData)
		Me.gbx_Other.Location = New System.Drawing.Point(8, 121)
		Me.gbx_Other.Name = "gbx_Other"
		Me.gbx_Other.Size = New System.Drawing.Size(532, 105)
		Me.gbx_Other.TabIndex = 1
		Me.gbx_Other.TabStop = False
		Me.gbx_Other.Text = "其它"
		'
		'lbl_Other_ifmt
		'
		Me.lbl_Other_ifmt.Location = New System.Drawing.Point(16, 25)
		Me.lbl_Other_ifmt.Name = "lbl_Other_ifmt"
		Me.lbl_Other_ifmt.Size = New System.Drawing.Size(499, 33)
		Me.lbl_Other_ifmt.TabIndex = 1
		Me.lbl_Other_ifmt.Text = "如果您频繁遇到由于数据损坏而导致的异常, 您可以在此处清除所有数据以重新开始使用Solitary Memories。"
		'
		'btn_Other_FormatData
		'
		Me.btn_Other_FormatData.Location = New System.Drawing.Point(18, 61)
		Me.btn_Other_FormatData.Name = "btn_Other_FormatData"
		Me.btn_Other_FormatData.Size = New System.Drawing.Size(204, 23)
		Me.btn_Other_FormatData.TabIndex = 0
		Me.btn_Other_FormatData.Text = "清除所有数据并恢复出厂设置(&C)"
		Me.btn_Other_FormatData.UseVisualStyleBackColor = True
		'
		'gbx_General_Run
		'
		Me.gbx_General_Run.Controls.Add(Me.lbl_Running_Best30UnlockStat)
		Me.gbx_General_Run.Controls.Add(Me.cbx_Running_AutoCheckUpdate)
		Me.gbx_General_Run.Controls.Add(Me.cbx_Running_SystemStart)
		Me.gbx_General_Run.Location = New System.Drawing.Point(8, 6)
		Me.gbx_General_Run.Name = "gbx_General_Run"
		Me.gbx_General_Run.Size = New System.Drawing.Size(532, 109)
		Me.gbx_General_Run.TabIndex = 0
		Me.gbx_General_Run.TabStop = False
		Me.gbx_General_Run.Text = "运行"
		'
		'lbl_Running_Best30UnlockStat
		'
		Me.lbl_Running_Best30UnlockStat.AutoSize = True
		Me.lbl_Running_Best30UnlockStat.Location = New System.Drawing.Point(16, 71)
		Me.lbl_Running_Best30UnlockStat.Name = "lbl_Running_Best30UnlockStat"
		Me.lbl_Running_Best30UnlockStat.Size = New System.Drawing.Size(167, 12)
		Me.lbl_Running_Best30UnlockStat.TabIndex = 1
		Me.lbl_Running_Best30UnlockStat.Text = "????????????? Status: False"
		'
		'cbx_Running_AutoCheckUpdate
		'
		Me.cbx_Running_AutoCheckUpdate.AutoSize = True
		Me.cbx_Running_AutoCheckUpdate.Location = New System.Drawing.Point(18, 42)
		Me.cbx_Running_AutoCheckUpdate.Name = "cbx_Running_AutoCheckUpdate"
		Me.cbx_Running_AutoCheckUpdate.Size = New System.Drawing.Size(474, 16)
		Me.cbx_Running_AutoCheckUpdate.TabIndex = 2
		Me.cbx_Running_AutoCheckUpdate.Text = "启动Solitary Memories时自动检查程序及 BotArcAPI 依赖项更新(需要手动安装Git)"
		Me.cbx_Running_AutoCheckUpdate.UseVisualStyleBackColor = True
		'
		'cbx_Running_SystemStart
		'
		Me.cbx_Running_SystemStart.AutoSize = True
		Me.cbx_Running_SystemStart.Location = New System.Drawing.Point(18, 20)
		Me.cbx_Running_SystemStart.Name = "cbx_Running_SystemStart"
		Me.cbx_Running_SystemStart.Size = New System.Drawing.Size(330, 16)
		Me.cbx_Running_SystemStart.TabIndex = 1
		Me.cbx_Running_SystemStart.Text = "开机自动启动Solitary Memories(隐藏启动动画及主界面)"
		Me.cbx_Running_SystemStart.UseVisualStyleBackColor = True
		'
		'Frm_Options
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(561, 307)
		Me.Controls.Add(Me.tcl_Options)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(577, 346)
		Me.MinimumSize = New System.Drawing.Size(577, 346)
		Me.Name = "Frm_Options"
		Me.ShowIcon = False
		Me.Text = "选项"
		Me.tcl_Options.ResumeLayout(False)
		Me.tclpg_Common.ResumeLayout(False)
		Me.gbx_Subscribe.ResumeLayout(False)
		Me.gbx_Subscribe.PerformLayout()
		CType(Me.npd_SubScribe_AutoQueryFrequency, System.ComponentModel.ISupportInitialize).EndInit()
		Me.gbx_PlayersManager.ResumeLayout(False)
		Me.gbx_PlayersManager.PerformLayout()
		Me.gbx_BotArcAPI.ResumeLayout(False)
		Me.gbx_BotArcAPI.PerformLayout()
		CType(Me.npd_api_RunningPort, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tclpg_General.ResumeLayout(False)
		Me.gbx_Other.ResumeLayout(False)
		Me.gbx_General_Run.ResumeLayout(False)
		Me.gbx_General_Run.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents tcl_Options As Windows.Forms.TabControl
	Friend WithEvents tclpg_Common As Windows.Forms.TabPage
	Friend WithEvents tclpg_General As Windows.Forms.TabPage
	Friend WithEvents gbx_BotArcAPI As Windows.Forms.GroupBox
	Friend WithEvents lbl_api_ifmt As Windows.Forms.Label
	Friend WithEvents npd_api_RunningPort As Windows.Forms.NumericUpDown
	Friend WithEvents lbl_api_ifmt2 As Windows.Forms.Label
	Friend WithEvents gbx_PlayersManager As Windows.Forms.GroupBox
	Friend WithEvents cbx_PlayersManager_IsCheckPlayerInfoBeforeAdd As Windows.Forms.CheckBox
	Friend WithEvents lbl_PlayersManager_ifmt As Windows.Forms.Label
	Friend WithEvents btn_General_Save As Windows.Forms.Button
	Friend WithEvents gbx_General_Run As Windows.Forms.GroupBox
	Friend WithEvents cbx_Running_SystemStart As Windows.Forms.CheckBox
	Friend WithEvents cbx_Running_AutoCheckUpdate As Windows.Forms.CheckBox
	Friend WithEvents lbl_Running_Best30UnlockStat As Windows.Forms.Label
	Friend WithEvents gbx_Subscribe As Windows.Forms.GroupBox
	Friend WithEvents lbl_SubScribe_ifmt As Windows.Forms.Label
	Friend WithEvents npd_SubScribe_AutoQueryFrequency As Windows.Forms.NumericUpDown
	Friend WithEvents lbl_SubScribe_ifmt2 As Windows.Forms.Label
	Friend WithEvents lbl_SubScribe_ifmt3 As Windows.Forms.Label
	Friend WithEvents gbx_Other As Windows.Forms.GroupBox
	Friend WithEvents btn_Other_FormatData As Windows.Forms.Button
	Friend WithEvents lbl_Other_ifmt As Windows.Forms.Label
	Friend WithEvents btn_Common_Save As Windows.Forms.Button
End Class
