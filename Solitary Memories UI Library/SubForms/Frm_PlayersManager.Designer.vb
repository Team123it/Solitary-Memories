<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PlayersManager
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
		Me.spc_PlayersManager = New System.Windows.Forms.SplitContainer()
		Me.dbdgv_Players = New System.Windows.Forms.DataGridView()
		Me.dgvcln_PlayerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvcln_PlayerId = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.btn_Remove = New System.Windows.Forms.Button()
		Me.btn_Add = New System.Windows.Forms.Button()
		Me.tbx_PlayerId = New System.Windows.Forms.TextBox()
		Me.lbl_ifmt2 = New System.Windows.Forms.Label()
		Me.tbx_PlayerNick = New System.Windows.Forms.TextBox()
		Me.lbl_ifmt = New System.Windows.Forms.Label()
		Me.dtst_Players = New System.Data.DataSet()
		Me.dttb_Players = New System.Data.DataTable()
		Me.cln_PlayerName = New System.Data.DataColumn()
		Me.cln_PlayerId = New System.Data.DataColumn()
		CType(Me.spc_PlayersManager, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.spc_PlayersManager.Panel1.SuspendLayout()
		Me.spc_PlayersManager.Panel2.SuspendLayout()
		Me.spc_PlayersManager.SuspendLayout()
		CType(Me.dbdgv_Players, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtst_Players, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dttb_Players, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'spc_PlayersManager
		'
		Me.spc_PlayersManager.Dock = System.Windows.Forms.DockStyle.Fill
		Me.spc_PlayersManager.Location = New System.Drawing.Point(0, 0)
		Me.spc_PlayersManager.Name = "spc_PlayersManager"
		Me.spc_PlayersManager.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'spc_PlayersManager.Panel1
		'
		Me.spc_PlayersManager.Panel1.Controls.Add(Me.dbdgv_Players)
		'
		'spc_PlayersManager.Panel2
		'
		Me.spc_PlayersManager.Panel2.Controls.Add(Me.btn_Remove)
		Me.spc_PlayersManager.Panel2.Controls.Add(Me.btn_Add)
		Me.spc_PlayersManager.Panel2.Controls.Add(Me.tbx_PlayerId)
		Me.spc_PlayersManager.Panel2.Controls.Add(Me.lbl_ifmt2)
		Me.spc_PlayersManager.Panel2.Controls.Add(Me.tbx_PlayerNick)
		Me.spc_PlayersManager.Panel2.Controls.Add(Me.lbl_ifmt)
		Me.spc_PlayersManager.Size = New System.Drawing.Size(438, 291)
		Me.spc_PlayersManager.SplitterDistance = 192
		Me.spc_PlayersManager.TabIndex = 0
		'
		'dbdgv_Players
		'
		Me.dbdgv_Players.AllowUserToAddRows = False
		Me.dbdgv_Players.AllowUserToDeleteRows = False
		Me.dbdgv_Players.AllowUserToResizeColumns = False
		Me.dbdgv_Players.AllowUserToResizeRows = False
		Me.dbdgv_Players.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
		Me.dbdgv_Players.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvcln_PlayerName, Me.dgvcln_PlayerId})
		Me.dbdgv_Players.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dbdgv_Players.Location = New System.Drawing.Point(0, 0)
		Me.dbdgv_Players.Name = "dbdgv_Players"
		Me.dbdgv_Players.ReadOnly = True
		Me.dbdgv_Players.RowTemplate.Height = 23
		Me.dbdgv_Players.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dbdgv_Players.Size = New System.Drawing.Size(438, 192)
		Me.dbdgv_Players.TabIndex = 0
		'
		'dgvcln_PlayerName
		'
		Me.dgvcln_PlayerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.dgvcln_PlayerName.DataPropertyName = "playerName"
		Me.dgvcln_PlayerName.FillWeight = 50.0!
		Me.dgvcln_PlayerName.HeaderText = "昵称"
		Me.dgvcln_PlayerName.Name = "dgvcln_PlayerName"
		Me.dgvcln_PlayerName.ReadOnly = True
		Me.dgvcln_PlayerName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
		'
		'dgvcln_PlayerId
		'
		Me.dgvcln_PlayerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.dgvcln_PlayerId.DataPropertyName = "playerId"
		Me.dgvcln_PlayerId.FillWeight = 50.0!
		Me.dgvcln_PlayerId.HeaderText = "id"
		Me.dgvcln_PlayerId.Name = "dgvcln_PlayerId"
		Me.dgvcln_PlayerId.ReadOnly = True
		Me.dgvcln_PlayerId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
		'
		'btn_Remove
		'
		Me.btn_Remove.Location = New System.Drawing.Point(233, 47)
		Me.btn_Remove.Name = "btn_Remove"
		Me.btn_Remove.Size = New System.Drawing.Size(75, 23)
		Me.btn_Remove.TabIndex = 1
		Me.btn_Remove.Text = "移除(&R)"
		Me.btn_Remove.UseVisualStyleBackColor = True
		'
		'btn_Add
		'
		Me.btn_Add.Location = New System.Drawing.Point(118, 47)
		Me.btn_Add.Name = "btn_Add"
		Me.btn_Add.Size = New System.Drawing.Size(75, 23)
		Me.btn_Add.TabIndex = 3
		Me.btn_Add.Text = "添加(&A)"
		Me.btn_Add.UseVisualStyleBackColor = True
		'
		'tbx_PlayerId
		'
		Me.tbx_PlayerId.Location = New System.Drawing.Point(284, 10)
		Me.tbx_PlayerId.MaxLength = 9
		Me.tbx_PlayerId.Name = "tbx_PlayerId"
		Me.tbx_PlayerId.Size = New System.Drawing.Size(109, 21)
		Me.tbx_PlayerId.TabIndex = 1
		'
		'lbl_ifmt2
		'
		Me.lbl_ifmt2.AutoSize = True
		Me.lbl_ifmt2.Location = New System.Drawing.Point(231, 13)
		Me.lbl_ifmt2.Name = "lbl_ifmt2"
		Me.lbl_ifmt2.Size = New System.Drawing.Size(47, 12)
		Me.lbl_ifmt2.TabIndex = 1
		Me.lbl_ifmt2.Text = "玩家id:"
		'
		'tbx_PlayerNick
		'
		Me.tbx_PlayerNick.Location = New System.Drawing.Point(86, 10)
		Me.tbx_PlayerNick.MaxLength = 64
		Me.tbx_PlayerNick.Name = "tbx_PlayerNick"
		Me.tbx_PlayerNick.Size = New System.Drawing.Size(107, 21)
		Me.tbx_PlayerNick.TabIndex = 2
		'
		'lbl_ifmt
		'
		Me.lbl_ifmt.AutoSize = True
		Me.lbl_ifmt.Location = New System.Drawing.Point(21, 13)
		Me.lbl_ifmt.Name = "lbl_ifmt"
		Me.lbl_ifmt.Size = New System.Drawing.Size(59, 12)
		Me.lbl_ifmt.TabIndex = 1
		Me.lbl_ifmt.Text = "玩家昵称:"
		'
		'dtst_Players
		'
		Me.dtst_Players.DataSetName = "NewDataSet"
		Me.dtst_Players.Tables.AddRange(New System.Data.DataTable() {Me.dttb_Players})
		'
		'dttb_Players
		'
		Me.dttb_Players.Columns.AddRange(New System.Data.DataColumn() {Me.cln_PlayerName, Me.cln_PlayerId})
		Me.dttb_Players.TableName = "Table1"
		'
		'cln_PlayerName
		'
		Me.cln_PlayerName.Caption = "昵称"
		Me.cln_PlayerName.ColumnName = "playerName"
		'
		'cln_PlayerId
		'
		Me.cln_PlayerId.Caption = "id"
		Me.cln_PlayerId.ColumnName = "playerId"
		'
		'Frm_PlayersManager
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(438, 291)
		Me.Controls.Add(Me.spc_PlayersManager)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(454, 330)
		Me.MinimumSize = New System.Drawing.Size(454, 330)
		Me.Name = "Frm_PlayersManager"
		Me.ShowIcon = False
		Me.Text = "玩家管理"
		Me.spc_PlayersManager.Panel1.ResumeLayout(False)
		Me.spc_PlayersManager.Panel2.ResumeLayout(False)
		Me.spc_PlayersManager.Panel2.PerformLayout()
		CType(Me.spc_PlayersManager, System.ComponentModel.ISupportInitialize).EndInit()
		Me.spc_PlayersManager.ResumeLayout(False)
		CType(Me.dbdgv_Players, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtst_Players, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dttb_Players, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents spc_PlayersManager As Windows.Forms.SplitContainer
	Friend WithEvents dbdgv_Players As Windows.Forms.DataGridView
	Friend WithEvents lbl_ifmt As Windows.Forms.Label
	Friend WithEvents tbx_PlayerNick As Windows.Forms.TextBox
	Friend WithEvents lbl_ifmt2 As Windows.Forms.Label
	Friend WithEvents tbx_PlayerId As Windows.Forms.TextBox
	Friend WithEvents btn_Add As Windows.Forms.Button
	Friend WithEvents btn_Remove As Windows.Forms.Button
	Friend WithEvents dgvcln_PlayerName As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents dgvcln_PlayerId As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents dtst_Players As DataSet
	Friend WithEvents dttb_Players As DataTable
	Friend WithEvents cln_PlayerName As DataColumn
	Friend WithEvents cln_PlayerId As DataColumn
End Class
