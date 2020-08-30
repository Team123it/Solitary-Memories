<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SubScribesList
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
		Me.dbdgv_subscribes = New System.Windows.Forms.DataGridView()
		Me.dgvcln_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvcln_playerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvcln_songName = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvcln_difficulty = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvcln_score = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dtst_subscribeList = New System.Data.DataSet()
		Me.dtb_list = New System.Data.DataTable()
		Me.cln_id = New System.Data.DataColumn()
		Me.cln_playerId = New System.Data.DataColumn()
		Me.cln_songName = New System.Data.DataColumn()
		Me.cln_difficulty = New System.Data.DataColumn()
		Me.cln_trigScore = New System.Data.DataColumn()
		CType(Me.dbdgv_subscribes, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtst_subscribeList, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtb_list, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'dbdgv_subscribes
		'
		Me.dbdgv_subscribes.AllowUserToAddRows = False
		Me.dbdgv_subscribes.AllowUserToDeleteRows = False
		Me.dbdgv_subscribes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dbdgv_subscribes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvcln_id, Me.dgvcln_playerName, Me.dgvcln_songName, Me.dgvcln_difficulty, Me.dgvcln_score})
		Me.dbdgv_subscribes.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dbdgv_subscribes.Location = New System.Drawing.Point(0, 0)
		Me.dbdgv_subscribes.Name = "dbdgv_subscribes"
		Me.dbdgv_subscribes.RowTemplate.Height = 23
		Me.dbdgv_subscribes.Size = New System.Drawing.Size(672, 258)
		Me.dbdgv_subscribes.TabIndex = 0
		'
		'dgvcln_id
		'
		Me.dgvcln_id.DataPropertyName = "id"
		Me.dgvcln_id.HeaderText = "id"
		Me.dgvcln_id.Name = "dgvcln_id"
		Me.dgvcln_id.ReadOnly = True
		'
		'dgvcln_playerName
		'
		Me.dgvcln_playerName.DataPropertyName = "playerId"
		Me.dgvcln_playerName.HeaderText = "玩家"
		Me.dgvcln_playerName.Name = "dgvcln_playerName"
		Me.dgvcln_playerName.ReadOnly = True
		'
		'dgvcln_songName
		'
		Me.dgvcln_songName.DataPropertyName = "songName"
		Me.dgvcln_songName.HeaderText = "曲目"
		Me.dgvcln_songName.Name = "dgvcln_songName"
		Me.dgvcln_songName.ReadOnly = True
		'
		'dgvcln_difficulty
		'
		Me.dgvcln_difficulty.DataPropertyName = "difficulty"
		Me.dgvcln_difficulty.HeaderText = "难度"
		Me.dgvcln_difficulty.Name = "dgvcln_difficulty"
		Me.dgvcln_difficulty.ReadOnly = True
		'
		'dgvcln_score
		'
		Me.dgvcln_score.DataPropertyName = "trigScore"
		Me.dgvcln_score.HeaderText = "触发分数"
		Me.dgvcln_score.Name = "dgvcln_score"
		Me.dgvcln_score.ReadOnly = True
		'
		'dtst_subscribeList
		'
		Me.dtst_subscribeList.DataSetName = "Subscribe List"
		Me.dtst_subscribeList.Tables.AddRange(New System.Data.DataTable() {Me.dtb_list})
		'
		'dtb_list
		'
		Me.dtb_list.Columns.AddRange(New System.Data.DataColumn() {Me.cln_id, Me.cln_playerId, Me.cln_songName, Me.cln_difficulty, Me.cln_trigScore})
		Me.dtb_list.TableName = "SubScribe List Table"
		'
		'cln_id
		'
		Me.cln_id.Caption = ""
		Me.cln_id.ColumnName = "id"
		'
		'cln_playerId
		'
		Me.cln_playerId.Caption = ""
		Me.cln_playerId.ColumnName = "playerId"
		'
		'cln_songName
		'
		Me.cln_songName.Caption = ""
		Me.cln_songName.ColumnName = "songName"
		'
		'cln_difficulty
		'
		Me.cln_difficulty.Caption = ""
		Me.cln_difficulty.ColumnName = "difficulty"
		'
		'cln_trigScore
		'
		Me.cln_trigScore.Caption = ""
		Me.cln_trigScore.ColumnName = "trigScore"
		'
		'Frm_SubScribesList
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(672, 258)
		Me.Controls.Add(Me.dbdgv_subscribes)
		Me.MinimumSize = New System.Drawing.Size(688, 297)
		Me.Name = "Frm_SubScribesList"
		Me.ShowIcon = False
		Me.Text = "成绩订阅列表"
		CType(Me.dbdgv_subscribes, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtst_subscribeList, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtb_list, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents dbdgv_subscribes As Windows.Forms.DataGridView
	Friend WithEvents dtst_subscribeList As DataSet
	Friend WithEvents dtb_list As DataTable
	Friend WithEvents cln_id As DataColumn
	Friend WithEvents cln_playerId As DataColumn
	Friend WithEvents cln_songName As DataColumn
	Friend WithEvents cln_difficulty As DataColumn
	Friend WithEvents cln_trigScore As DataColumn
	Friend WithEvents dgvcln_id As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents dgvcln_playerName As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents dgvcln_songName As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents dgvcln_difficulty As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents dgvcln_score As Windows.Forms.DataGridViewTextBoxColumn
End Class
