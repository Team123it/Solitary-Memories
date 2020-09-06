<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AnomalyFuncUnlock
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
		Me.lbl_solibox = New System.Windows.Forms.Label()
		Me.lbl_querytimes = New System.Windows.Forms.Label()
		Me.btn_unlock = New System.Windows.Forms.Button()
		Me.lbl_playersCount = New System.Windows.Forms.Label()
		Me.lbl_querySpecialOrder = New System.Windows.Forms.Label()
		Me.lbl_connectStrCorrect = New System.Windows.Forms.Label()
		Me.tmr_UnlockEffect = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'lbl_solibox
		'
		Me.lbl_solibox.AutoSize = True
		Me.lbl_solibox.Location = New System.Drawing.Point(12, 9)
		Me.lbl_solibox.Name = "lbl_solibox"
		Me.lbl_solibox.Size = New System.Drawing.Size(53, 12)
		Me.lbl_solibox.TabIndex = 0
		Me.lbl_solibox.Text = "[Locked]"
		'
		'lbl_querytimes
		'
		Me.lbl_querytimes.AutoSize = True
		Me.lbl_querytimes.Location = New System.Drawing.Point(12, 31)
		Me.lbl_querytimes.Name = "lbl_querytimes"
		Me.lbl_querytimes.Size = New System.Drawing.Size(53, 12)
		Me.lbl_querytimes.TabIndex = 1
		Me.lbl_querytimes.Text = "[Locked]"
		'
		'btn_unlock
		'
		Me.btn_unlock.Enabled = False
		Me.btn_unlock.Location = New System.Drawing.Point(475, 161)
		Me.btn_unlock.Name = "btn_unlock"
		Me.btn_unlock.Size = New System.Drawing.Size(28, 23)
		Me.btn_unlock.TabIndex = 2
		Me.btn_unlock.Text = "?"
		Me.btn_unlock.UseVisualStyleBackColor = True
		'
		'lbl_playersCount
		'
		Me.lbl_playersCount.AutoSize = True
		Me.lbl_playersCount.Location = New System.Drawing.Point(12, 55)
		Me.lbl_playersCount.Name = "lbl_playersCount"
		Me.lbl_playersCount.Size = New System.Drawing.Size(53, 12)
		Me.lbl_playersCount.TabIndex = 3
		Me.lbl_playersCount.Text = "[Locked]"
		'
		'lbl_querySpecialOrder
		'
		Me.lbl_querySpecialOrder.AutoSize = True
		Me.lbl_querySpecialOrder.Location = New System.Drawing.Point(12, 76)
		Me.lbl_querySpecialOrder.Name = "lbl_querySpecialOrder"
		Me.lbl_querySpecialOrder.Size = New System.Drawing.Size(53, 12)
		Me.lbl_querySpecialOrder.TabIndex = 4
		Me.lbl_querySpecialOrder.Text = "[Locked]"
		'
		'lbl_connectStrCorrect
		'
		Me.lbl_connectStrCorrect.AutoSize = True
		Me.lbl_connectStrCorrect.Location = New System.Drawing.Point(12, 98)
		Me.lbl_connectStrCorrect.Name = "lbl_connectStrCorrect"
		Me.lbl_connectStrCorrect.Size = New System.Drawing.Size(53, 12)
		Me.lbl_connectStrCorrect.TabIndex = 5
		Me.lbl_connectStrCorrect.Text = "[Locked]"
		'
		'tmr_UnlockEffect
		'
		Me.tmr_UnlockEffect.Interval = 1000
		'
		'Frm_AnomalyFuncUnlock
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(515, 196)
		Me.Controls.Add(Me.lbl_connectStrCorrect)
		Me.Controls.Add(Me.lbl_querySpecialOrder)
		Me.Controls.Add(Me.lbl_playersCount)
		Me.Controls.Add(Me.btn_unlock)
		Me.Controls.Add(Me.lbl_querytimes)
		Me.Controls.Add(Me.lbl_solibox)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(510, 235)
		Me.Name = "Frm_AnomalyFuncUnlock"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.Text = "?"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents lbl_solibox As Windows.Forms.Label
	Friend WithEvents lbl_querytimes As Windows.Forms.Label
	Friend WithEvents btn_unlock As Windows.Forms.Button
	Friend WithEvents lbl_playersCount As Windows.Forms.Label
	Friend WithEvents lbl_querySpecialOrder As Windows.Forms.Label
	Friend WithEvents lbl_connectStrCorrect As Windows.Forms.Label
	Friend WithEvents tmr_UnlockEffect As Windows.Forms.Timer
End Class
