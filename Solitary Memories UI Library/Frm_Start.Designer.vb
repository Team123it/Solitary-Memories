Imports System.Drawing
Imports System.Windows.Forms
Imports Team123it.Arcaea.Solimmr.Global

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Start
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Start))
		Me.tmr_Start = New System.Windows.Forms.Timer(Me.components)
		Me.lbl_start = New System.Windows.Forms.Label()
		Me.bgwk_Start = New System.ComponentModel.BackgroundWorker()
		Me.ptbx_Start = New System.Windows.Forms.PictureBox()
		Me.ptbx_Title = New System.Windows.Forms.PictureBox()
		Me.lbl_cprt = New System.Windows.Forms.Label()
		Me.awmp_Start = New AxWMPLib.AxWindowsMediaPlayer()
		CType(Me.ptbx_Start, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ptbx_Title, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.awmp_Start, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'tmr_Start
		'
		Me.tmr_Start.Interval = 1
		'
		'lbl_start
		'
		Me.lbl_start.AutoSize = True
		Me.lbl_start.Location = New System.Drawing.Point(12, 339)
		Me.lbl_start.Name = "lbl_start"
		Me.lbl_start.Size = New System.Drawing.Size(89, 12)
		Me.lbl_start.TabIndex = 1
		Me.lbl_start.Text = "Starting up..."
		'
		'bgwk_Start
		'
		Me.bgwk_Start.WorkerSupportsCancellation = True
		'
		'ptbx_Start
		'
		Me.ptbx_Start.ErrorImage = Nothing
		Me.ptbx_Start.Image = Global.Team123it.Arcaea.Solimmr.UI.My.Resources.Resources.StartBg
		Me.ptbx_Start.InitialImage = Nothing
		Me.ptbx_Start.Location = New System.Drawing.Point(0, 0)
		Me.ptbx_Start.MaximumSize = New System.Drawing.Size(640, 1024)
		Me.ptbx_Start.MinimumSize = New System.Drawing.Size(640, 360)
		Me.ptbx_Start.Name = "ptbx_Start"
		Me.ptbx_Start.Size = New System.Drawing.Size(640, 1024)
		Me.ptbx_Start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.ptbx_Start.TabIndex = 0
		Me.ptbx_Start.TabStop = False
		'
		'ptbx_Title
		'
		Me.ptbx_Title.BackColor = System.Drawing.Color.Transparent
		Me.ptbx_Title.ErrorImage = Nothing
		Me.ptbx_Title.Image = Global.Team123it.Arcaea.Solimmr.UI.My.Resources.Resources.Title
		Me.ptbx_Title.InitialImage = Nothing
		Me.ptbx_Title.Location = New System.Drawing.Point(155, 12)
		Me.ptbx_Title.Name = "ptbx_Title"
		Me.ptbx_Title.Size = New System.Drawing.Size(317, 78)
		Me.ptbx_Title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.ptbx_Title.TabIndex = 2
		Me.ptbx_Title.TabStop = False
		Me.ptbx_Title.Visible = False
		'
		'lbl_cprt
		'
		Me.lbl_cprt.AutoSize = True
		Me.lbl_cprt.Location = New System.Drawing.Point(449, 339)
		Me.lbl_cprt.Name = "lbl_cprt"
		Me.lbl_cprt.Size = New System.Drawing.Size(179, 12)
		Me.lbl_cprt.TabIndex = 4
		Me.lbl_cprt.Text = "©123 Open-Source Organization"
		Me.lbl_cprt.Visible = False
		'
		'awmp_Start
		'
		Me.awmp_Start.Enabled = True
		Me.awmp_Start.Location = New System.Drawing.Point(592, 300)
		Me.awmp_Start.Name = "awmp_Start"
		Me.awmp_Start.OcxState = CType(resources.GetObject("awmp_Start.OcxState"), System.Windows.Forms.AxHost.State)
		Me.awmp_Start.Size = New System.Drawing.Size(36, 36)
		Me.awmp_Start.TabIndex = 5
		Me.awmp_Start.Visible = False
		'
		'Frm_Start
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.ClientSize = New System.Drawing.Size(640, 360)
		Me.Controls.Add(Me.awmp_Start)
		Me.Controls.Add(Me.lbl_cprt)
		Me.Controls.Add(Me.ptbx_Title)
		Me.Controls.Add(Me.lbl_start)
		Me.Controls.Add(Me.ptbx_Start)
		Me.DoubleBuffered = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Icon = Global.Team123it.Arcaea.Solimmr.UI.My.Resources.Resources.icon
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(640, 360)
		Me.MinimumSize = New System.Drawing.Size(640, 360)
		Me.Name = "Frm_Start"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Solitary Memories"
		Me.TopMost = True
		CType(Me.ptbx_Start, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ptbx_Title, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.awmp_Start, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents ptbx_Start As PictureBox
	Friend WithEvents tmr_Start As Timer
	Friend WithEvents bgwk_Start As System.ComponentModel.BackgroundWorker
	Public WithEvents lbl_start As Label
	Friend WithEvents ptbx_Title As PictureBox
	Friend WithEvents lbl_cprt As Label
	Friend WithEvents awmp_Start As AxWMPLib.AxWindowsMediaPlayer
End Class
