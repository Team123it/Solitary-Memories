<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FirstStart
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
		Me.Spc_FirstStart = New System.Windows.Forms.SplitContainer()
		Me.Pnl_Welcome = New System.Windows.Forms.Panel()
		Me.Pnl_Operations = New System.Windows.Forms.Panel()
		Me.lbl_ = New System.Windows.Forms.Label()
		CType(Me.Spc_FirstStart, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Spc_FirstStart.Panel1.SuspendLayout()
		Me.Spc_FirstStart.Panel2.SuspendLayout()
		Me.Spc_FirstStart.SuspendLayout()
		Me.Pnl_Welcome.SuspendLayout()
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
		Me.Spc_FirstStart.SplitterDistance = 250
		Me.Spc_FirstStart.TabIndex = 0
		'
		'Pnl_Welcome
		'
		Me.Pnl_Welcome.Controls.Add(Me.lbl_)
		Me.Pnl_Welcome.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Pnl_Welcome.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Welcome.Name = "Pnl_Welcome"
		Me.Pnl_Welcome.Size = New System.Drawing.Size(647, 250)
		Me.Pnl_Welcome.TabIndex = 0
		'
		'Pnl_Operations
		'
		Me.Pnl_Operations.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Pnl_Operations.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Operations.Name = "Pnl_Operations"
		Me.Pnl_Operations.Size = New System.Drawing.Size(647, 40)
		Me.Pnl_Operations.TabIndex = 0
		'
		'lbl_
		'
		Me.lbl_.AutoSize = True
		Me.lbl_.Location = New System.Drawing.Point(12, 9)
		Me.lbl_.Name = "lbl_"
		Me.lbl_.Size = New System.Drawing.Size(41, 12)
		Me.lbl_.TabIndex = 0
		Me.lbl_.Text = "Label1"
		'
		'Frm_FirstStart
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(647, 294)
		Me.Controls.Add(Me.Spc_FirstStart)
		Me.Name = "Frm_FirstStart"
		Me.ShowIcon = False
		Me.Text = "Solitary Memories 初始化向导"
		Me.Spc_FirstStart.Panel1.ResumeLayout(False)
		Me.Spc_FirstStart.Panel2.ResumeLayout(False)
		CType(Me.Spc_FirstStart, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Spc_FirstStart.ResumeLayout(False)
		Me.Pnl_Welcome.ResumeLayout(False)
		Me.Pnl_Welcome.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Spc_FirstStart As Windows.Forms.SplitContainer
	Friend WithEvents Pnl_Welcome As Windows.Forms.Panel
	Friend WithEvents Pnl_Operations As Windows.Forms.Panel
	Friend WithEvents lbl_ As Windows.Forms.Label
End Class
