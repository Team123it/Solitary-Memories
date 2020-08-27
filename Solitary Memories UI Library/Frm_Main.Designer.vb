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
		Me.msp_Main = New System.Windows.Forms.MenuStrip()
		Me.tsmi_players = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsmi_scores = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsmi_options = New System.Windows.Forms.ToolStripMenuItem()
		Me.msp_Main.SuspendLayout()
		Me.SuspendLayout()
		'
		'msp_Main
		'
		Me.msp_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_players, Me.tsmi_scores, Me.tsmi_options})
		Me.msp_Main.Location = New System.Drawing.Point(0, 0)
		Me.msp_Main.Name = "msp_Main"
		Me.msp_Main.Size = New System.Drawing.Size(647, 25)
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
		'Frm_Main
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(647, 292)
		Me.Controls.Add(Me.msp_Main)
		Me.Name = "Frm_Main"
		Me.Text = "Solitary Memories"
		Me.msp_Main.ResumeLayout(False)
		Me.msp_Main.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents msp_Main As Windows.Forms.MenuStrip
	Friend WithEvents tsmi_players As Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsmi_scores As Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsmi_options As Windows.Forms.ToolStripMenuItem
End Class
