<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_FirstStart
	Inherits System.Windows.Forms.Form

	'Form 重写 Dispose，以清理组件列表。
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_FirstStart))
		Me.Spc_FirstStart = New System.Windows.Forms.SplitContainer()
		Me.Pnl_Welcome = New System.Windows.Forms.Panel()
		Me.Pnl_Step1 = New System.Windows.Forms.Panel()
		Me.Pnl_Step2 = New System.Windows.Forms.Panel()
		Me.Pnl_Step3 = New System.Windows.Forms.Panel()
		Me.Pnl_Finish = New System.Windows.Forms.Panel()
		Me.lbl_Finish_ifmt = New System.Windows.Forms.Label()
		Me.lbl_Finish = New System.Windows.Forms.Label()
		Me.btn_Step3_ImportAccountList = New System.Windows.Forms.Button()
		Me.btn_Step3_ManualAdd = New System.Windows.Forms.Button()
		Me.lbl_Step3_AccountsCount = New System.Windows.Forms.Label()
		Me.lbl_Step3_ifmt3 = New System.Windows.Forms.Label()
		Me.lbl_Step3_ifmt2 = New System.Windows.Forms.Label()
		Me.lbl_Step3_ifmt = New System.Windows.Forms.Label()
		Me.lbl_Step3 = New System.Windows.Forms.Label()
		Me.lbl_Step2_ArcAccounts = New System.Windows.Forms.Label()
		Me.npd_Step2_RunningPort = New System.Windows.Forms.NumericUpDown()
		Me.lbl_Step2_RunningPort = New System.Windows.Forms.Label()
		Me.lbl_Step2_ifmt = New System.Windows.Forms.Label()
		Me.lbl_Step2 = New System.Windows.Forms.Label()
		Me.lbl_step1_status = New System.Windows.Forms.Label()
		Me.lbl_step1_ifmt2 = New System.Windows.Forms.Label()
		Me.lbl_step1_ifmt = New System.Windows.Forms.Label()
		Me.lbl_Step1 = New System.Windows.Forms.Label()
		Me.lbl_welcome_ifmt2 = New System.Windows.Forms.Label()
		Me.lbl_welcome_ifmt = New System.Windows.Forms.Label()
		Me.lbl_welcome = New System.Windows.Forms.Label()
		Me.Pnl_Operations = New System.Windows.Forms.Panel()
		Me.btn_previous = New System.Windows.Forms.Button()
		Me.btn_finish = New System.Windows.Forms.Button()
		Me.btn_next = New System.Windows.Forms.Button()
		Me.ttp_Step2_RunningPort = New System.Windows.Forms.ToolTip(Me.components)
		Me.ofd_Step2_ImportAccountsList = New System.Windows.Forms.OpenFileDialog()
		Me.bgwk_Step1_CheckUpdate = New System.ComponentModel.BackgroundWorker()
		CType(Me.Spc_FirstStart, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Spc_FirstStart.Panel1.SuspendLayout()
		Me.Spc_FirstStart.Panel2.SuspendLayout()
		Me.Spc_FirstStart.SuspendLayout()
		Me.Pnl_Welcome.SuspendLayout()
		Me.Pnl_Step1.SuspendLayout()
		Me.Pnl_Step2.SuspendLayout()
		Me.Pnl_Step3.SuspendLayout()
		Me.Pnl_Finish.SuspendLayout()
		CType(Me.npd_Step2_RunningPort, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Pnl_Operations.SuspendLayout()
		Me.SuspendLayout()
		'
		'Spc_FirstStart
		'
		Me.Spc_FirstStart.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Spc_FirstStart.Location = New System.Drawing.Point(0, 0)
		Me.Spc_FirstStart.Name = "Spc_FirstStart"
		Me.Spc_FirstStart.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'Spc_FirstStart.Panel1
		'
		Me.Spc_FirstStart.Panel1.Controls.Add(Me.Pnl_Welcome)
		'
		'Spc_FirstStart.Panel2
		'
		Me.Spc_FirstStart.Panel2.Controls.Add(Me.Pnl_Operations)
		Me.Spc_FirstStart.Size = New System.Drawing.Size(647, 294)
		Me.Spc_FirstStart.SplitterDistance = 257
		Me.Spc_FirstStart.SplitterWidth = 1
		Me.Spc_FirstStart.TabIndex = 0
		'
		'Pnl_Welcome
		'
		Me.Pnl_Welcome.Controls.Add(Me.Pnl_Step1)
		Me.Pnl_Welcome.Controls.Add(Me.lbl_welcome_ifmt2)
		Me.Pnl_Welcome.Controls.Add(Me.lbl_welcome_ifmt)
		Me.Pnl_Welcome.Controls.Add(Me.lbl_welcome)
		Me.Pnl_Welcome.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Pnl_Welcome.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Welcome.Name = "Pnl_Welcome"
		Me.Pnl_Welcome.Size = New System.Drawing.Size(647, 257)
		Me.Pnl_Welcome.TabIndex = 0
		'
		'Pnl_Step1
		'
		Me.Pnl_Step1.Controls.Add(Me.Pnl_Step2)
		Me.Pnl_Step1.Controls.Add(Me.lbl_step1_status)
		Me.Pnl_Step1.Controls.Add(Me.lbl_step1_ifmt2)
		Me.Pnl_Step1.Controls.Add(Me.lbl_step1_ifmt)
		Me.Pnl_Step1.Controls.Add(Me.lbl_Step1)
		Me.Pnl_Step1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Pnl_Step1.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Step1.Name = "Pnl_Step1"
		Me.Pnl_Step1.Size = New System.Drawing.Size(647, 257)
		Me.Pnl_Step1.TabIndex = 2
		'
		'Pnl_Step2
		'
		Me.Pnl_Step2.Controls.Add(Me.Pnl_Step3)
		Me.Pnl_Step2.Controls.Add(Me.lbl_Step2_ArcAccounts)
		Me.Pnl_Step2.Controls.Add(Me.npd_Step2_RunningPort)
		Me.Pnl_Step2.Controls.Add(Me.lbl_Step2_RunningPort)
		Me.Pnl_Step2.Controls.Add(Me.lbl_Step2_ifmt)
		Me.Pnl_Step2.Controls.Add(Me.lbl_Step2)
		Me.Pnl_Step2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Pnl_Step2.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Step2.Name = "Pnl_Step2"
		Me.Pnl_Step2.Size = New System.Drawing.Size(647, 257)
		Me.Pnl_Step2.TabIndex = 1
		'
		'Pnl_Step3
		'
		Me.Pnl_Step3.Controls.Add(Me.Pnl_Finish)
		Me.Pnl_Step3.Controls.Add(Me.btn_Step3_ImportAccountList)
		Me.Pnl_Step3.Controls.Add(Me.btn_Step3_ManualAdd)
		Me.Pnl_Step3.Controls.Add(Me.lbl_Step3_AccountsCount)
		Me.Pnl_Step3.Controls.Add(Me.lbl_Step3_ifmt3)
		Me.Pnl_Step3.Controls.Add(Me.lbl_Step3_ifmt2)
		Me.Pnl_Step3.Controls.Add(Me.lbl_Step3_ifmt)
		Me.Pnl_Step3.Controls.Add(Me.lbl_Step3)
		Me.Pnl_Step3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Pnl_Step3.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Step3.Name = "Pnl_Step3"
		Me.Pnl_Step3.Size = New System.Drawing.Size(647, 257)
		Me.Pnl_Step3.TabIndex = 3
		'
		'Pnl_Finish
		'
		Me.Pnl_Finish.Controls.Add(Me.lbl_Finish_ifmt)
		Me.Pnl_Finish.Controls.Add(Me.lbl_Finish)
		Me.Pnl_Finish.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Pnl_Finish.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Finish.Name = "Pnl_Finish"
		Me.Pnl_Finish.Size = New System.Drawing.Size(647, 257)
		Me.Pnl_Finish.TabIndex = 2
		'
		'lbl_Finish_ifmt
		'
		Me.lbl_Finish_ifmt.AutoSize = True
		Me.lbl_Finish_ifmt.Location = New System.Drawing.Point(16, 39)
		Me.lbl_Finish_ifmt.Name = "lbl_Finish_ifmt"
		Me.lbl_Finish_ifmt.Size = New System.Drawing.Size(347, 36)
		Me.lbl_Finish_ifmt.TabIndex = 1
		Me.lbl_Finish_ifmt.Text = "您已完成 Solitary Memories 初始化向导。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "单击""完成(&F)""重新启动程序以便开始使用 Solitary Memories。"
		'
		'lbl_Finish
		'
		Me.lbl_Finish.AutoSize = True
		Me.lbl_Finish.Font = New System.Drawing.Font("宋体", 15.0!)
		Me.lbl_Finish.Location = New System.Drawing.Point(14, 9)
		Me.lbl_Finish.Name = "lbl_Finish"
		Me.lbl_Finish.Size = New System.Drawing.Size(49, 20)
		Me.lbl_Finish.TabIndex = 1
		Me.lbl_Finish.Text = "完成"
		'
		'btn_Step3_ImportAccountList
		'
		Me.btn_Step3_ImportAccountList.Location = New System.Drawing.Point(280, 224)
		Me.btn_Step3_ImportAccountList.Name = "btn_Step3_ImportAccountList"
		Me.btn_Step3_ImportAccountList.Size = New System.Drawing.Size(147, 23)
		Me.btn_Step3_ImportAccountList.TabIndex = 7
		Me.btn_Step3_ImportAccountList.Text = "导入账号列表(推荐)(&I)"
		Me.btn_Step3_ImportAccountList.UseVisualStyleBackColor = True
		'
		'btn_Step3_ManualAdd
		'
		Me.btn_Step3_ManualAdd.Enabled = False
		Me.btn_Step3_ManualAdd.Location = New System.Drawing.Point(460, 224)
		Me.btn_Step3_ManualAdd.Name = "btn_Step3_ManualAdd"
		Me.btn_Step3_ManualAdd.Size = New System.Drawing.Size(175, 23)
		Me.btn_Step3_ManualAdd.TabIndex = 1
		Me.btn_Step3_ManualAdd.Text = "手动添加账号(&M)(暂不支持)"
		Me.btn_Step3_ManualAdd.UseVisualStyleBackColor = True
		'
		'lbl_Step3_AccountsCount
		'
		Me.lbl_Step3_AccountsCount.AutoSize = True
		Me.lbl_Step3_AccountsCount.Location = New System.Drawing.Point(158, 196)
		Me.lbl_Step3_AccountsCount.Name = "lbl_Step3_AccountsCount"
		Me.lbl_Step3_AccountsCount.Size = New System.Drawing.Size(11, 12)
		Me.lbl_Step3_AccountsCount.TabIndex = 6
		Me.lbl_Step3_AccountsCount.Text = "0"
		'
		'lbl_Step3_ifmt3
		'
		Me.lbl_Step3_ifmt3.AutoSize = True
		Me.lbl_Step3_ifmt3.Location = New System.Drawing.Point(14, 196)
		Me.lbl_Step3_ifmt3.Name = "lbl_Step3_ifmt3"
		Me.lbl_Step3_ifmt3.Size = New System.Drawing.Size(143, 12)
		Me.lbl_Step3_ifmt3.TabIndex = 5
		Me.lbl_Step3_ifmt3.Text = "已导入的查分用账号数量:"
		'
		'lbl_Step3_ifmt2
		'
		Me.lbl_Step3_ifmt2.AutoSize = True
		Me.lbl_Step3_ifmt2.Location = New System.Drawing.Point(14, 95)
		Me.lbl_Step3_ifmt2.Name = "lbl_Step3_ifmt2"
		Me.lbl_Step3_ifmt2.Size = New System.Drawing.Size(593, 84)
		Me.lbl_Step3_ifmt2.TabIndex = 4
		Me.lbl_Step3_ifmt2.Text = resources.GetString("lbl_Step3_ifmt2.Text")
		'
		'lbl_Step3_ifmt
		'
		Me.lbl_Step3_ifmt.AutoSize = True
		Me.lbl_Step3_ifmt.Location = New System.Drawing.Point(14, 39)
		Me.lbl_Step3_ifmt.Name = "lbl_Step3_ifmt"
		Me.lbl_Step3_ifmt.Size = New System.Drawing.Size(413, 36)
		Me.lbl_Step3_ifmt.TabIndex = 2
		Me.lbl_Step3_ifmt.Text = "韵律源点Arcaea的查分原理是通过添加对应玩家好友查分，查完后删除好友。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "故您需要设置一个查分专用账号池用来添加或删除好友。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "注意:不要使用您个人的游玩账号" &
	"当查分账号！"
		'
		'lbl_Step3
		'
		Me.lbl_Step3.AutoSize = True
		Me.lbl_Step3.Font = New System.Drawing.Font("宋体", 15.0!)
		Me.lbl_Step3.Location = New System.Drawing.Point(12, 9)
		Me.lbl_Step3.Name = "lbl_Step3"
		Me.lbl_Step3.Size = New System.Drawing.Size(149, 20)
		Me.lbl_Step3.TabIndex = 1
		Me.lbl_Step3.Text = "设置查分用账号"
		'
		'lbl_Step2_ArcAccounts
		'
		Me.lbl_Step2_ArcAccounts.AutoSize = True
		Me.lbl_Step2_ArcAccounts.Location = New System.Drawing.Point(14, 105)
		Me.lbl_Step2_ArcAccounts.Name = "lbl_Step2_ArcAccounts"
		Me.lbl_Step2_ArcAccounts.Size = New System.Drawing.Size(185, 12)
		Me.lbl_Step2_ArcAccounts.TabIndex = 1
		Me.lbl_Step2_ArcAccounts.Text = "设置查分用账号请单击""下一步""。"
		'
		'npd_Step2_RunningPort
		'
		Me.npd_Step2_RunningPort.Location = New System.Drawing.Point(145, 69)
		Me.npd_Step2_RunningPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
		Me.npd_Step2_RunningPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.npd_Step2_RunningPort.Name = "npd_Step2_RunningPort"
		Me.npd_Step2_RunningPort.Size = New System.Drawing.Size(120, 21)
		Me.npd_Step2_RunningPort.TabIndex = 2
		Me.npd_Step2_RunningPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.npd_Step2_RunningPort.Value = New Decimal(New Integer() {61666, 0, 0, 0})
		'
		'lbl_Step2_RunningPort
		'
		Me.lbl_Step2_RunningPort.AutoSize = True
		Me.lbl_Step2_RunningPort.Location = New System.Drawing.Point(14, 71)
		Me.lbl_Step2_RunningPort.Name = "lbl_Step2_RunningPort"
		Me.lbl_Step2_RunningPort.Size = New System.Drawing.Size(113, 12)
		Me.lbl_Step2_RunningPort.TabIndex = 1
		Me.lbl_Step2_RunningPort.Text = "运行端口(1-65535):"
		'
		'lbl_Step2_ifmt
		'
		Me.lbl_Step2_ifmt.AutoSize = True
		Me.lbl_Step2_ifmt.Location = New System.Drawing.Point(14, 39)
		Me.lbl_Step2_ifmt.Name = "lbl_Step2_ifmt"
		Me.lbl_Step2_ifmt.Size = New System.Drawing.Size(545, 12)
		Me.lbl_Step2_ifmt.TabIndex = 1
		Me.lbl_Step2_ifmt.Text = "依赖项: BotArcAPI 需要一些信息才能正常运行。请在下方填写信息。(鼠标悬停在输入框上显示帮助)"
		'
		'lbl_Step2
		'
		Me.lbl_Step2.AutoSize = True
		Me.lbl_Step2.Font = New System.Drawing.Font("宋体", 15.0!)
		Me.lbl_Step2.Location = New System.Drawing.Point(12, 9)
		Me.lbl_Step2.Name = "lbl_Step2"
		Me.lbl_Step2.Size = New System.Drawing.Size(149, 20)
		Me.lbl_Step2.TabIndex = 1
		Me.lbl_Step2.Text = "配置依赖项信息"
		'
		'lbl_step1_status
		'
		Me.lbl_step1_status.AutoSize = True
		Me.lbl_step1_status.Location = New System.Drawing.Point(20, 83)
		Me.lbl_step1_status.Name = "lbl_step1_status"
		Me.lbl_step1_status.Size = New System.Drawing.Size(269, 12)
		Me.lbl_step1_status.TabIndex = 1
		Me.lbl_step1_status.Text = "请稍后，程序正在检查是否有 BotArcAPI 更新..."
		'
		'lbl_step1_ifmt2
		'
		Me.lbl_step1_ifmt2.AutoSize = True
		Me.lbl_step1_ifmt2.Location = New System.Drawing.Point(20, 60)
		Me.lbl_step1_ifmt2.Name = "lbl_step1_ifmt2"
		Me.lbl_step1_ifmt2.Size = New System.Drawing.Size(563, 12)
		Me.lbl_step1_ifmt2.TabIndex = 1
		Me.lbl_step1_ifmt2.Text = "随 Solitary Memories , BotArcAPI 已安装至系统中, 但程序仍需初始化该依赖项以保证其为最新版本。"
		'
		'lbl_step1_ifmt
		'
		Me.lbl_step1_ifmt.AutoSize = True
		Me.lbl_step1_ifmt.Location = New System.Drawing.Point(20, 39)
		Me.lbl_step1_ifmt.Name = "lbl_step1_ifmt"
		Me.lbl_step1_ifmt.Size = New System.Drawing.Size(617, 12)
		Me.lbl_step1_ifmt.TabIndex = 1
		Me.lbl_step1_ifmt.Text = "由于 Solitary Memories 基于 BotArcAPI , 您需要初始化 BotArcAPI 依赖项才可正常运行 Solitary Memories " &
	"。"
		'
		'lbl_Step1
		'
		Me.lbl_Step1.AutoSize = True
		Me.lbl_Step1.Font = New System.Drawing.Font("宋体", 15.0!)
		Me.lbl_Step1.Location = New System.Drawing.Point(12, 9)
		Me.lbl_Step1.Name = "lbl_Step1"
		Me.lbl_Step1.Size = New System.Drawing.Size(239, 20)
		Me.lbl_Step1.TabIndex = 0
		Me.lbl_Step1.Text = "初始化 BotArcAPI 依赖项"
		'
		'lbl_welcome_ifmt2
		'
		Me.lbl_welcome_ifmt2.AutoSize = True
		Me.lbl_welcome_ifmt2.Location = New System.Drawing.Point(14, 229)
		Me.lbl_welcome_ifmt2.Name = "lbl_welcome_ifmt2"
		Me.lbl_welcome_ifmt2.Size = New System.Drawing.Size(251, 12)
		Me.lbl_welcome_ifmt2.TabIndex = 2
		Me.lbl_welcome_ifmt2.Text = "* 均为123 Open-Source Organization 成员。"
		'
		'lbl_welcome_ifmt
		'
		Me.lbl_welcome_ifmt.Location = New System.Drawing.Point(14, 39)
		Me.lbl_welcome_ifmt.Name = "lbl_welcome_ifmt"
		Me.lbl_welcome_ifmt.Size = New System.Drawing.Size(621, 122)
		Me.lbl_welcome_ifmt.TabIndex = 1
		Me.lbl_welcome_ifmt.Text = resources.GetString("lbl_welcome_ifmt.Text")
		'
		'lbl_welcome
		'
		Me.lbl_welcome.AutoSize = True
		Me.lbl_welcome.Font = New System.Drawing.Font("宋体", 15.0!)
		Me.lbl_welcome.Location = New System.Drawing.Point(12, 9)
		Me.lbl_welcome.Name = "lbl_welcome"
		Me.lbl_welcome.Size = New System.Drawing.Size(49, 20)
		Me.lbl_welcome.TabIndex = 0
		Me.lbl_welcome.Text = "欢迎"
		'
		'Pnl_Operations
		'
		Me.Pnl_Operations.Controls.Add(Me.btn_previous)
		Me.Pnl_Operations.Controls.Add(Me.btn_finish)
		Me.Pnl_Operations.Controls.Add(Me.btn_next)
		Me.Pnl_Operations.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Pnl_Operations.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Operations.Name = "Pnl_Operations"
		Me.Pnl_Operations.Size = New System.Drawing.Size(647, 36)
		Me.Pnl_Operations.TabIndex = 0
		'
		'btn_previous
		'
		Me.btn_previous.Location = New System.Drawing.Point(398, 5)
		Me.btn_previous.Name = "btn_previous"
		Me.btn_previous.Size = New System.Drawing.Size(75, 23)
		Me.btn_previous.TabIndex = 1
		Me.btn_previous.Text = "上一步(&P)"
		Me.btn_previous.UseVisualStyleBackColor = True
		'
		'btn_finish
		'
		Me.btn_finish.Location = New System.Drawing.Point(560, 5)
		Me.btn_finish.Name = "btn_finish"
		Me.btn_finish.Size = New System.Drawing.Size(75, 23)
		Me.btn_finish.TabIndex = 1
		Me.btn_finish.Text = "完成(&F)"
		Me.btn_finish.UseVisualStyleBackColor = True
		'
		'btn_next
		'
		Me.btn_next.Location = New System.Drawing.Point(479, 5)
		Me.btn_next.Name = "btn_next"
		Me.btn_next.Size = New System.Drawing.Size(75, 23)
		Me.btn_next.TabIndex = 0
		Me.btn_next.Text = "下一步(&N)"
		Me.btn_next.UseVisualStyleBackColor = True
		'
		'ttp_Step2_RunningPort
		'
		Me.ttp_Step2_RunningPort.IsBalloon = True
		Me.ttp_Step2_RunningPort.ToolTipTitle = "运行端口"
		'
		'ofd_Step2_ImportAccountsList
		'
		Me.ofd_Step2_ImportAccountsList.DefaultExt = "txt"
		Me.ofd_Step2_ImportAccountsList.Filter = "文本文件(*.txt)|*.txt"
		Me.ofd_Step2_ImportAccountsList.Title = "选择 123 ArcAccGenerator 生成的账号文本文件"
		'
		'bgwk_Step1_CheckUpdate
		'
		Me.bgwk_Step1_CheckUpdate.WorkerSupportsCancellation = True
		'
		'Frm_FirstStart
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(647, 294)
		Me.Controls.Add(Me.Spc_FirstStart)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(663, 333)
		Me.MinimumSize = New System.Drawing.Size(663, 333)
		Me.Name = "Frm_FirstStart"
		Me.ShowIcon = False
		Me.Text = "Solitary Memories 初始化向导"
		Me.Spc_FirstStart.Panel1.ResumeLayout(False)
		Me.Spc_FirstStart.Panel2.ResumeLayout(False)
		CType(Me.Spc_FirstStart, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Spc_FirstStart.ResumeLayout(False)
		Me.Pnl_Welcome.ResumeLayout(False)
		Me.Pnl_Welcome.PerformLayout()
		Me.Pnl_Step1.ResumeLayout(False)
		Me.Pnl_Step1.PerformLayout()
		Me.Pnl_Step2.ResumeLayout(False)
		Me.Pnl_Step2.PerformLayout()
		Me.Pnl_Step3.ResumeLayout(False)
		Me.Pnl_Step3.PerformLayout()
		Me.Pnl_Finish.ResumeLayout(False)
		Me.Pnl_Finish.PerformLayout()
		CType(Me.npd_Step2_RunningPort, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Pnl_Operations.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Spc_FirstStart As Windows.Forms.SplitContainer
	Friend WithEvents Pnl_Welcome As Windows.Forms.Panel
	Friend WithEvents Pnl_Operations As Windows.Forms.Panel
	Friend WithEvents lbl_welcome As Windows.Forms.Label
	Friend WithEvents lbl_welcome_ifmt As Windows.Forms.Label
	Friend WithEvents lbl_welcome_ifmt2 As Windows.Forms.Label
	Friend WithEvents btn_next As Windows.Forms.Button
	Friend WithEvents btn_finish As Windows.Forms.Button
	Friend WithEvents btn_previous As Windows.Forms.Button
	Friend WithEvents Pnl_Step1 As Windows.Forms.Panel
	Friend WithEvents lbl_Step1 As Windows.Forms.Label
	Friend WithEvents lbl_step1_ifmt As Windows.Forms.Label
	Friend WithEvents lbl_step1_ifmt2 As Windows.Forms.Label
	Friend WithEvents lbl_step1_status As Windows.Forms.Label
	Friend WithEvents Pnl_Step2 As Windows.Forms.Panel
	Friend WithEvents lbl_Step2 As Windows.Forms.Label
	Friend WithEvents lbl_Step2_ifmt As Windows.Forms.Label
	Friend WithEvents lbl_Step2_RunningPort As Windows.Forms.Label
	Friend WithEvents npd_Step2_RunningPort As Windows.Forms.NumericUpDown
	Friend WithEvents ttp_Step2_RunningPort As Windows.Forms.ToolTip
	Friend WithEvents lbl_Step2_ArcAccounts As Windows.Forms.Label
	Friend WithEvents Pnl_Step3 As Windows.Forms.Panel
	Friend WithEvents lbl_Step3_ifmt As Windows.Forms.Label
	Friend WithEvents lbl_Step3 As Windows.Forms.Label
	Friend WithEvents lbl_Step3_ifmt2 As Windows.Forms.Label
	Friend WithEvents lbl_Step3_ifmt3 As Windows.Forms.Label
	Friend WithEvents lbl_Step3_AccountsCount As Windows.Forms.Label
	Friend WithEvents btn_Step3_ManualAdd As Windows.Forms.Button
	Friend WithEvents btn_Step3_ImportAccountList As Windows.Forms.Button
	Friend WithEvents ofd_Step2_ImportAccountsList As Windows.Forms.OpenFileDialog
	Friend WithEvents Pnl_Finish As Windows.Forms.Panel
	Friend WithEvents lbl_Finish As Windows.Forms.Label
	Friend WithEvents lbl_Finish_ifmt As Windows.Forms.Label
	Friend WithEvents bgwk_Step1_CheckUpdate As ComponentModel.BackgroundWorker
End Class
