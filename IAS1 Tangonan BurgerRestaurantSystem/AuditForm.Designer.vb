<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuditForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbFilters = New System.Windows.Forms.GroupBox()
        Me.dgvAudit = New System.Windows.Forms.DataGridView()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MENUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DashboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblInactivity = New System.Windows.Forms.Label()
        Me.gbFilters.SuspendLayout()
        CType(Me.dgvAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbFilters
        '
        Me.gbFilters.Controls.Add(Me.dgvAudit)
        Me.gbFilters.Controls.Add(Me.btnSearch)
        Me.gbFilters.Controls.Add(Me.dtTo)
        Me.gbFilters.Controls.Add(Me.dtFrom)
        Me.gbFilters.Controls.Add(Me.lblDateTo)
        Me.gbFilters.Controls.Add(Me.lblDateFrom)
        Me.gbFilters.Controls.Add(Me.txtSearch)
        Me.gbFilters.Location = New System.Drawing.Point(12, 47)
        Me.gbFilters.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbFilters.Name = "gbFilters"
        Me.gbFilters.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbFilters.Size = New System.Drawing.Size(716, 455)
        Me.gbFilters.TabIndex = 1
        Me.gbFilters.TabStop = False
        Me.gbFilters.Text = "Filters"
        '
        'dgvAudit
        '
        Me.dgvAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAudit.Location = New System.Drawing.Point(15, 130)
        Me.dgvAudit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvAudit.Name = "dgvAudit"
        Me.dgvAudit.RowHeadersWidth = 51
        Me.dgvAudit.Size = New System.Drawing.Size(695, 313)
        Me.dgvAudit.TabIndex = 8
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(6, 58)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(104, 42)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(422, 67)
        Me.dtTo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(269, 22)
        Me.dtTo.TabIndex = 5
        Me.dtTo.Value = New Date(2025, 12, 15, 22, 12, 0, 0)
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(422, 22)
        Me.dtFrom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(269, 22)
        Me.dtFrom.TabIndex = 4
        Me.dtFrom.Value = New Date(2020, 1, 1, 22, 12, 0, 0)
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(388, 72)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(27, 16)
        Me.lblDateTo.TabIndex = 3
        Me.lblDateTo.Text = "To:"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(370, 28)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(41, 16)
        Me.lblDateFrom.TabIndex = 2
        Me.lblDateFrom.Text = "From:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(6, 22)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(214, 22)
        Me.txtSearch.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MENUToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(740, 28)
        Me.MenuStrip1.TabIndex = 20
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MENUToolStripMenuItem
        '
        Me.MENUToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataEntryToolStripMenuItem, Me.DashboardToolStripMenuItem, Me.ToolStripSeparator1, Me.BackupToolStripMenuItem, Me.RestoreToolStripMenuItem})
        Me.MENUToolStripMenuItem.Name = "MENUToolStripMenuItem"
        Me.MENUToolStripMenuItem.Size = New System.Drawing.Size(65, 24)
        Me.MENUToolStripMenuItem.Text = "MENU"
        '
        'DataEntryToolStripMenuItem
        '
        Me.DataEntryToolStripMenuItem.Name = "DataEntryToolStripMenuItem"
        Me.DataEntryToolStripMenuItem.Size = New System.Drawing.Size(165, 26)
        Me.DataEntryToolStripMenuItem.Text = "DataEntry"
        '
        'DashboardToolStripMenuItem
        '
        Me.DashboardToolStripMenuItem.Name = "DashboardToolStripMenuItem"
        Me.DashboardToolStripMenuItem.Size = New System.Drawing.Size(165, 26)
        Me.DashboardToolStripMenuItem.Text = "Dashboard"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(162, 6)
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(165, 26)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(165, 26)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(635, 11)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(93, 37)
        Me.btnLogout.TabIndex = 19
        Me.btnLogout.Text = "LOGOUT"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'lblInactivity
        '
        Me.lblInactivity.AutoSize = True
        Me.lblInactivity.Location = New System.Drawing.Point(522, 32)
        Me.lblInactivity.Name = "lblInactivity"
        Me.lblInactivity.Size = New System.Drawing.Size(48, 16)
        Me.lblInactivity.TabIndex = 21
        Me.lblInactivity.Text = "Label1"
        '
        'AuditForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 513)
        Me.Controls.Add(Me.lblInactivity)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gbFilters)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AuditForm"
        Me.Text = "AUDITLOGS"
        Me.gbFilters.ResumeLayout(False)
        Me.gbFilters.PerformLayout()
        CType(Me.dgvAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbFilters As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents lblDateTo As Label
    Friend WithEvents lblDateFrom As Label
    Friend WithEvents dgvAudit As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MENUToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataEntryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnLogout As Button
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DashboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblInactivity As Label
End Class
