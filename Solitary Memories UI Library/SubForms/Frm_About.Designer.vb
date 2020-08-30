<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_About
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
		Me.ptbx_Logo = New System.Windows.Forms.PictureBox()
		Me.ptbx_Title = New System.Windows.Forms.PictureBox()
		Me.lbl_ifmt = New System.Windows.Forms.Label()
		Me.lbl_license = New System.Windows.Forms.Label()
		Me.lbl_ifmt7 = New System.Windows.Forms.Label()
		Me.lbl_RepoURL = New System.Windows.Forms.LinkLabel()
		Me.lbl_ifmt6 = New System.Windows.Forms.Label()
		Me.lbl_ifmt5 = New System.Windows.Forms.Label()
		Me.lbl_ifmt4 = New System.Windows.Forms.Label()
		Me.lbl_ifmt3 = New System.Windows.Forms.Label()
		Me.lbl_ifmt2 = New System.Windows.Forms.Label()
		Me.lbl_ifmt_version = New System.Windows.Forms.Label()
		Me.lbl_version = New System.Windows.Forms.Label()
		CType(Me.ptbx_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ptbx_Title, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ptbx_Logo
		'
		Me.ptbx_Logo.ErrorImage = Nothing
		Me.ptbx_Logo.Image = Global.Team123it.Arcaea.Solimmr.UI.My.Resources.Resources.Logo
		Me.ptbx_Logo.InitialImage = Nothing
		Me.ptbx_Logo.Location = New System.Drawing.Point(29, 11)
		Me.ptbx_Logo.Name = "ptbx_Logo"
		Me.ptbx_Logo.Size = New System.Drawing.Size(64, 64)
		Me.ptbx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.ptbx_Logo.TabIndex = 0
		Me.ptbx_Logo.TabStop = False
		'
		'ptbx_Title
		'
		Me.ptbx_Title.ErrorImage = Nothing
		Me.ptbx_Title.Image = Global.Team123it.Arcaea.Solimmr.UI.My.Resources.Resources.Title
		Me.ptbx_Title.InitialImage = Nothing
		Me.ptbx_Title.Location = New System.Drawing.Point(153, -14)
		Me.ptbx_Title.Name = "ptbx_Title"
		Me.ptbx_Title.Size = New System.Drawing.Size(364, 104)
		Me.ptbx_Title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.ptbx_Title.TabIndex = 1
		Me.ptbx_Title.TabStop = False
		'
		'lbl_ifmt
		'
		Me.lbl_ifmt.AutoSize = True
		Me.lbl_ifmt.Location = New System.Drawing.Point(365, 78)
		Me.lbl_ifmt.Name = "lbl_ifmt"
		Me.lbl_ifmt.Size = New System.Drawing.Size(287, 12)
		Me.lbl_ifmt.TabIndex = 2
		Me.lbl_ifmt.Text = "An Advanced Arcaea Desktop Score Search Utility"
		'
		'lbl_license
		'
		Me.lbl_license.AutoSize = True
		Me.lbl_license.Location = New System.Drawing.Point(27, 226)
		Me.lbl_license.Name = "lbl_license"
		Me.lbl_license.Size = New System.Drawing.Size(341, 12)
		Me.lbl_license.TabIndex = 18
		Me.lbl_license.Text = "本项目为开源项目, 使用源代码时请遵守AGPL 3.0开源许可协议"
		'
		'lbl_ifmt7
		'
		Me.lbl_ifmt7.AutoSize = True
		Me.lbl_ifmt7.Location = New System.Drawing.Point(27, 199)
		Me.lbl_ifmt7.Name = "lbl_ifmt7"
		Me.lbl_ifmt7.Size = New System.Drawing.Size(71, 12)
		Me.lbl_ifmt7.TabIndex = 17
		Me.lbl_ifmt7.Text = "Github仓库:"
		'
		'lbl_RepoURL
		'
		Me.lbl_RepoURL.AutoSize = True
		Me.lbl_RepoURL.Location = New System.Drawing.Point(97, 199)
		Me.lbl_RepoURL.Name = "lbl_RepoURL"
		Me.lbl_RepoURL.Size = New System.Drawing.Size(395, 12)
		Me.lbl_RepoURL.TabIndex = 16
		Me.lbl_RepoURL.TabStop = True
		Me.lbl_RepoURL.Text = "https://github.com/123-Open-Source-Organization/Solitary-Memories"
		'
		'lbl_ifmt6
		'
		Me.lbl_ifmt6.AutoSize = True
		Me.lbl_ifmt6.Location = New System.Drawing.Point(203, 173)
		Me.lbl_ifmt6.Name = "lbl_ifmt6"
		Me.lbl_ifmt6.Size = New System.Drawing.Size(449, 12)
		Me.lbl_ifmt6.TabIndex = 15
		Me.lbl_ifmt6.Text = "Powered by 123 Open-Source Organization and Solitary Memories Contributors"
		'
		'lbl_ifmt5
		'
		Me.lbl_ifmt5.AutoSize = True
		Me.lbl_ifmt5.Location = New System.Drawing.Point(340, 121)
		Me.lbl_ifmt5.Name = "lbl_ifmt5"
		Me.lbl_ifmt5.Size = New System.Drawing.Size(77, 12)
		Me.lbl_ifmt5.TabIndex = 14
		Me.lbl_ifmt5.Text = "测试: wlt233"
		'
		'lbl_ifmt4
		'
		Me.lbl_ifmt4.AutoSize = True
		Me.lbl_ifmt4.Location = New System.Drawing.Point(27, 173)
		Me.lbl_ifmt4.Name = "lbl_ifmt4"
		Me.lbl_ifmt4.Size = New System.Drawing.Size(101, 12)
		Me.lbl_ifmt4.TabIndex = 13
		Me.lbl_ifmt4.Text = "图标设计: Mizuna"
		'
		'lbl_ifmt3
		'
		Me.lbl_ifmt3.AutoSize = True
		Me.lbl_ifmt3.Location = New System.Drawing.Point(27, 148)
		Me.lbl_ifmt3.Name = "lbl_ifmt3"
		Me.lbl_ifmt3.Size = New System.Drawing.Size(245, 12)
		Me.lbl_ifmt3.TabIndex = 12
		Me.lbl_ifmt3.Text = "核心依赖项(BotArcAPI) 开发: TheSnowfield" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
		'
		'lbl_ifmt2
		'
		Me.lbl_ifmt2.AutoSize = True
		Me.lbl_ifmt2.Location = New System.Drawing.Point(27, 121)
		Me.lbl_ifmt2.Name = "lbl_ifmt2"
		Me.lbl_ifmt2.Size = New System.Drawing.Size(119, 12)
		Me.lbl_ifmt2.TabIndex = 11
		Me.lbl_ifmt2.Text = "主开发: Misaka12456"
		'
		'lbl_ifmt_version
		'
		Me.lbl_ifmt_version.AutoSize = True
		Me.lbl_ifmt_version.Location = New System.Drawing.Point(27, 98)
		Me.lbl_ifmt_version.Name = "lbl_ifmt_version"
		Me.lbl_ifmt_version.Size = New System.Drawing.Size(35, 12)
		Me.lbl_ifmt_version.TabIndex = 19
		Me.lbl_ifmt_version.Text = "版本:"
		'
		'lbl_version
		'
		Me.lbl_version.AutoSize = True
		Me.lbl_version.Location = New System.Drawing.Point(68, 98)
		Me.lbl_version.Name = "lbl_version"
		Me.lbl_version.Size = New System.Drawing.Size(59, 12)
		Me.lbl_version.TabIndex = 20
		Me.lbl_version.Text = "<Loading>"
		'
		'Frm_About
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(666, 248)
		Me.Controls.Add(Me.lbl_version)
		Me.Controls.Add(Me.lbl_ifmt_version)
		Me.Controls.Add(Me.lbl_license)
		Me.Controls.Add(Me.lbl_ifmt7)
		Me.Controls.Add(Me.lbl_RepoURL)
		Me.Controls.Add(Me.lbl_ifmt6)
		Me.Controls.Add(Me.lbl_ifmt5)
		Me.Controls.Add(Me.lbl_ifmt4)
		Me.Controls.Add(Me.lbl_ifmt3)
		Me.Controls.Add(Me.lbl_ifmt2)
		Me.Controls.Add(Me.lbl_ifmt)
		Me.Controls.Add(Me.ptbx_Title)
		Me.Controls.Add(Me.ptbx_Logo)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(682, 287)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(682, 287)
		Me.Name = "Frm_About"
		Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
		Me.ShowIcon = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "关于 Solitary Memories"
		CType(Me.ptbx_Logo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ptbx_Title, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents ptbx_Logo As Windows.Forms.PictureBox
	Friend WithEvents ptbx_Title As Windows.Forms.PictureBox
	Friend WithEvents lbl_ifmt As Windows.Forms.Label
	Friend WithEvents lbl_license As Windows.Forms.Label
	Friend WithEvents lbl_ifmt7 As Windows.Forms.Label
	Friend WithEvents lbl_RepoURL As Windows.Forms.LinkLabel
	Friend WithEvents lbl_ifmt6 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt5 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt4 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt3 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt2 As Windows.Forms.Label
	Friend WithEvents lbl_ifmt_version As Windows.Forms.Label
	Friend WithEvents lbl_version As Windows.Forms.Label
End Class
