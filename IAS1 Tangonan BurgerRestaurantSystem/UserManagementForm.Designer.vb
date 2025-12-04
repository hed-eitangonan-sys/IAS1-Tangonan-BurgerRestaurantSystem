<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserManagementForm
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
        dgvStatus = New DataGridView()
        btnRead = New Button()
        btnUpdate = New Button()
        btnLogout = New Button()
        lblUsername = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        lblPassword = New Label()
        txtId = New TextBox()
        lblId = New Label()
        cbStatus = New ComboBox()
        lblStatus = New Label()
        lblRole = New Label()
        cbRole = New ComboBox()
        gbFields = New GroupBox()
        btnBack = New Button()
        btnManage = New Button()
        btnCreate = New Button()
        btnDelete = New Button()
        btnSearch = New Button()
        gbButtons = New GroupBox()
        CType(dgvStatus, ComponentModel.ISupportInitialize).BeginInit()
        gbFields.SuspendLayout()
        gbButtons.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvStatus
        ' 
        dgvStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStatus.EditMode = DataGridViewEditMode.EditProgrammatically
        dgvStatus.Location = New Point(12, 12)
        dgvStatus.Name = "dgvStatus"
        dgvStatus.RowHeadersWidth = 51
        dgvStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStatus.Size = New Size(478, 483)
        dgvStatus.TabIndex = 0
        ' 
        ' btnRead
        ' 
        btnRead.Location = New Point(506, 444)
        btnRead.Name = "btnRead"
        btnRead.Size = New Size(144, 51)
        btnRead.TabIndex = 3
        btnRead.Text = "READ"
        btnRead.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(9, 79)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(144, 51)
        btnUpdate.TabIndex = 4
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Transparent
        btnLogout.Font = New Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogout.Location = New Point(766, 13)
        btnLogout.Margin = New Padding(3, 4, 3, 4)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(79, 33)
        btnLogout.TabIndex = 7
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Location = New Point(28, 66)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(75, 20)
        lblUsername.TabIndex = 8
        lblUsername.Text = "Username"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(107, 63)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(216, 27)
        txtUsername.TabIndex = 9
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(107, 99)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(216, 27)
        txtPassword.TabIndex = 11
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(28, 102)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(70, 20)
        lblPassword.TabIndex = 10
        lblPassword.Text = "Password"
        ' 
        ' txtId
        ' 
        txtId.Location = New Point(107, 26)
        txtId.Name = "txtId"
        txtId.Size = New Size(79, 27)
        txtId.TabIndex = 13
        ' 
        ' lblId
        ' 
        lblId.AutoSize = True
        lblId.Location = New Point(74, 29)
        lblId.Name = "lblId"
        lblId.Size = New Size(24, 20)
        lblId.TabIndex = 12
        lblId.Text = "ID"
        ' 
        ' cbStatus
        ' 
        cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatus.FormattingEnabled = True
        cbStatus.Location = New Point(107, 136)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(151, 28)
        cbStatus.TabIndex = 14
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(49, 139)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(49, 20)
        lblStatus.TabIndex = 15
        lblStatus.Text = "Status"
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Location = New Point(49, 173)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(39, 20)
        lblRole.TabIndex = 17
        lblRole.Text = "Role"
        ' 
        ' cbRole
        ' 
        cbRole.DropDownStyle = ComboBoxStyle.DropDownList
        cbRole.FormattingEnabled = True
        cbRole.Location = New Point(107, 170)
        cbRole.Name = "cbRole"
        cbRole.Size = New Size(151, 28)
        cbRole.TabIndex = 16
        ' 
        ' gbFields
        ' 
        gbFields.Controls.Add(btnBack)
        gbFields.Controls.Add(btnManage)
        gbFields.Controls.Add(txtId)
        gbFields.Controls.Add(lblRole)
        gbFields.Controls.Add(lblUsername)
        gbFields.Controls.Add(cbRole)
        gbFields.Controls.Add(txtUsername)
        gbFields.Controls.Add(lblStatus)
        gbFields.Controls.Add(lblPassword)
        gbFields.Controls.Add(cbStatus)
        gbFields.Controls.Add(txtPassword)
        gbFields.Controls.Add(lblId)
        gbFields.Location = New Point(506, 50)
        gbFields.Name = "gbFields"
        gbFields.Size = New Size(339, 273)
        gbFields.TabIndex = 18
        gbFields.TabStop = False
        gbFields.Text = "GroupBox1"
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(233, 216)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(66, 40)
        btnBack.TabIndex = 20
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' btnManage
        ' 
        btnManage.Location = New Point(107, 216)
        btnManage.Name = "btnManage"
        btnManage.Size = New Size(104, 40)
        btnManage.TabIndex = 19
        btnManage.Text = "READ"
        btnManage.UseVisualStyleBackColor = True
        ' 
        ' btnCreate
        ' 
        btnCreate.Location = New Point(9, 18)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(144, 51)
        btnCreate.TabIndex = 19
        btnCreate.Text = "CREATE"
        btnCreate.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(9, 136)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(144, 51)
        btnDelete.TabIndex = 20
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(671, 444)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(144, 51)
        btnSearch.TabIndex = 21
        btnSearch.Text = "SEARCH"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' gbButtons
        ' 
        gbButtons.Controls.Add(btnUpdate)
        gbButtons.Controls.Add(btnCreate)
        gbButtons.Controls.Add(btnDelete)
        gbButtons.Location = New Point(851, 51)
        gbButtons.Name = "gbButtons"
        gbButtons.Size = New Size(164, 197)
        gbButtons.TabIndex = 25
        gbButtons.TabStop = False
        ' 
        ' ManageUsersForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1168, 507)
        Controls.Add(gbButtons)
        Controls.Add(btnLogout)
        Controls.Add(btnSearch)
        Controls.Add(gbFields)
        Controls.Add(btnRead)
        Controls.Add(dgvStatus)
        Name = "ManageUsersForm"
        Text = "Form3"
        CType(dgvStatus, ComponentModel.ISupportInitialize).EndInit()
        gbFields.ResumeLayout(False)
        gbFields.PerformLayout()
        gbButtons.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvStatus As DataGridView
    Friend WithEvents btnRead As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents lblId As Label
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents cbRole As ComboBox
    Friend WithEvents gbFields As GroupBox
    Friend WithEvents btnManage As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents gbButtons As GroupBox
    Friend WithEvents btnBack As Button
End Class
