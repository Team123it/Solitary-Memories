<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SolitaryBoxxx
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
		Me.lbl_SongName = New System.Windows.Forms.Label()
		Me.lbl_countdown = New System.Windows.Forms.Label()
		Me.gbx_selectDiff = New System.Windows.Forms.GroupBox()
		Me.rbtn_ftr = New System.Windows.Forms.RadioButton()
		Me.rbtn_prs = New System.Windows.Forms.RadioButton()
		Me.rbtn_pst = New System.Windows.Forms.RadioButton()
		Me.btn_Play = New System.Windows.Forms.Button()
		Me.lbl_SongComposer = New System.Windows.Forms.Label()
		Me.lbl_ifmt = New System.Windows.Forms.Label()
		Me.lbl_Player = New System.Windows.Forms.Label()
		Me.bgwk_SolitaryBoxxx = New System.ComponentModel.BackgroundWorker()
		Me.tmr_SolitaryBoxxx = New System.Windows.Forms.Timer(Me.components)
		Me.lbl_Status = New System.Windows.Forms.Label()
		Me.gbx_selectDiff.SuspendLayout()
		Me.SuspendLayout()
		'
		'lbl_SongName
		'
		Me.lbl_SongName.Font = New System.Drawing.Font("宋体", 20.0!)
		Me.lbl_SongName.Location = New System.Drawing.Point(176, 26)
		Me.lbl_SongName.Name = "lbl_SongName"
		Me.lbl_SongName.Size = New System.Drawing.Size(254, 27)
		Me.lbl_SongName.TabIndex = 0
		Me.lbl_SongName.Text = "<Loading>"
		Me.lbl_SongName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lbl_countdown
		'
		Me.lbl_countdown.AutoSize = True
		Me.lbl_countdown.Font = New System.Drawing.Font("Comic Sans MS", 20.0!)
		Me.lbl_countdown.ForeColor = System.Drawing.Color.Orange
		Me.lbl_countdown.Location = New System.Drawing.Point(5, 205)
		Me.lbl_countdown.Name = "lbl_countdown"
		Me.lbl_countdown.Size = New System.Drawing.Size(49, 38)
		Me.lbl_countdown.TabIndex = 3
		Me.lbl_countdown.Text = "35"
		'
		'gbx_selectDiff
		'
		Me.gbx_selectDiff.BackColor = System.Drawing.SystemColors.Control
		Me.gbx_selectDiff.Controls.Add(Me.rbtn_ftr)
		Me.gbx_selectDiff.Controls.Add(Me.rbtn_prs)
		Me.gbx_selectDiff.Controls.Add(Me.rbtn_pst)
		Me.gbx_selectDiff.ForeColor = System.Drawing.SystemColors.ControlText
		Me.gbx_selectDiff.Location = New System.Drawing.Point(181, 94)
		Me.gbx_selectDiff.Name = "gbx_selectDiff"
		Me.gbx_selectDiff.Size = New System.Drawing.Size(249, 103)
		Me.gbx_selectDiff.TabIndex = 4
		Me.gbx_selectDiff.TabStop = False
		Me.gbx_selectDiff.Text = "选择难度"
		'
		'rbtn_ftr
		'
		Me.rbtn_ftr.AutoSize = True
		Me.rbtn_ftr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.rbtn_ftr.Location = New System.Drawing.Point(61, 64)
		Me.rbtn_ftr.Name = "rbtn_ftr"
		Me.rbtn_ftr.Size = New System.Drawing.Size(59, 16)
		Me.rbtn_ftr.TabIndex = 2
		Me.rbtn_ftr.TabStop = True
		Me.rbtn_ftr.Text = "Future"
		Me.rbtn_ftr.UseVisualStyleBackColor = True
		'
		'rbtn_prs
		'
		Me.rbtn_prs.AutoSize = True
		Me.rbtn_prs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.rbtn_prs.Location = New System.Drawing.Point(61, 42)
		Me.rbtn_prs.Name = "rbtn_prs"
		Me.rbtn_prs.Size = New System.Drawing.Size(65, 16)
		Me.rbtn_prs.TabIndex = 1
		Me.rbtn_prs.TabStop = True
		Me.rbtn_prs.Text = "Present"
		Me.rbtn_prs.UseVisualStyleBackColor = True
		'
		'rbtn_pst
		'
		Me.rbtn_pst.AutoSize = True
		Me.rbtn_pst.ForeColor = System.Drawing.SystemColors.ControlText
		Me.rbtn_pst.Location = New System.Drawing.Point(61, 20)
		Me.rbtn_pst.Name = "rbtn_pst"
		Me.rbtn_pst.Size = New System.Drawing.Size(47, 16)
		Me.rbtn_pst.TabIndex = 0
		Me.rbtn_pst.TabStop = True
		Me.rbtn_pst.Text = "Past"
		Me.rbtn_pst.UseVisualStyleBackColor = True
		'
		'btn_Play
		'
		Me.btn_Play.BackColor = System.Drawing.SystemColors.Control
		Me.btn_Play.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btn_Play.Location = New System.Drawing.Point(514, 217)
		Me.btn_Play.Name = "btn_Play"
		Me.btn_Play.Size = New System.Drawing.Size(93, 23)
		Me.btn_Play.TabIndex = 5
		Me.btn_Play.Text = "开始游戏(&S)"
		Me.btn_Play.UseVisualStyleBackColor = False
		'
		'lbl_SongComposer
		'
		Me.lbl_SongComposer.Location = New System.Drawing.Point(181, 66)
		Me.lbl_SongComposer.Name = "lbl_SongComposer"
		Me.lbl_SongComposer.Size = New System.Drawing.Size(249, 12)
		Me.lbl_SongComposer.TabIndex = 6
		Me.lbl_SongComposer.Text = "<Loading>"
		Me.lbl_SongComposer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lbl_ifmt
		'
		Me.lbl_ifmt.AutoSize = True
		Me.lbl_ifmt.Location = New System.Drawing.Point(417, 9)
		Me.lbl_ifmt.Name = "lbl_ifmt"
		Me.lbl_ifmt.Size = New System.Drawing.Size(35, 12)
		Me.lbl_ifmt.TabIndex = 7
		Me.lbl_ifmt.Text = "玩家:"
		'
		'lbl_Player
		'
		Me.lbl_Player.Location = New System.Drawing.Point(458, 9)
		Me.lbl_Player.Name = "lbl_Player"
		Me.lbl_Player.Size = New System.Drawing.Size(149, 55)
		Me.lbl_Player.TabIndex = 8
		Me.lbl_Player.Text = "<Loading>"
		'
		'bgwk_SolitaryBoxxx
		'
		'
		'tmr_SolitaryBoxxx
		'
		Me.tmr_SolitaryBoxxx.Interval = 1000
		'
		'lbl_Status
		'
		Me.lbl_Status.Location = New System.Drawing.Point(101, 217)
		Me.lbl_Status.Name = "lbl_Status"
		Me.lbl_Status.Size = New System.Drawing.Size(407, 23)
		Me.lbl_Status.TabIndex = 9
		Me.lbl_Status.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Frm_SolitaryBoxxx
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.DimGray
		Me.ClientSize = New System.Drawing.Size(619, 252)
		Me.Controls.Add(Me.lbl_Status)
		Me.Controls.Add(Me.lbl_Player)
		Me.Controls.Add(Me.lbl_ifmt)
		Me.Controls.Add(Me.lbl_SongComposer)
		Me.Controls.Add(Me.btn_Play)
		Me.Controls.Add(Me.gbx_selectDiff)
		Me.Controls.Add(Me.lbl_countdown)
		Me.Controls.Add(Me.lbl_SongName)
		Me.ForeColor = System.Drawing.Color.Lime
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(635, 291)
		Me.MinimumSize = New System.Drawing.Size(635, 291)
		Me.Name = "Frm_SolitaryBoxxx"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "SOLITARY BOXXX"
		Me.TopMost = True
		Me.gbx_selectDiff.ResumeLayout(False)
		Me.gbx_selectDiff.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents lbl_SongName As Windows.Forms.Label
	Friend WithEvents lbl_countdown As Windows.Forms.Label
	Friend WithEvents gbx_selectDiff As Windows.Forms.GroupBox
	Friend WithEvents rbtn_pst As Windows.Forms.RadioButton
	Friend WithEvents btn_Play As Windows.Forms.Button
	Friend WithEvents rbtn_ftr As Windows.Forms.RadioButton
	Friend WithEvents rbtn_prs As Windows.Forms.RadioButton
	Friend WithEvents lbl_SongComposer As Windows.Forms.Label
	Friend WithEvents lbl_ifmt As Windows.Forms.Label
	Friend WithEvents lbl_Player As Windows.Forms.Label
	Friend WithEvents bgwk_SolitaryBoxxx As ComponentModel.BackgroundWorker
	Friend WithEvents tmr_SolitaryBoxxx As Windows.Forms.Timer
	Friend WithEvents lbl_Status As Windows.Forms.Label
End Class
