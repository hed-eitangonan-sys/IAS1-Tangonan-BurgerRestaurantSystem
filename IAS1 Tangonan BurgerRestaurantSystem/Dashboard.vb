Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1.Cmp
Imports System.Text.RegularExpressions

Public Class Dashboard

    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db")

    ' Inactivity Timer Variables
    Private inactivityTimer As New Timer()
    Private countdownSeconds As Integer = 10
    Private originalCountdown As Integer = 10 ' Store original value for reset

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()

        ' Initialize Inactivity Timer
        InitializeInactivityTimer()

        ' Attach event handlers to detect user activity
        AttachActivityHandlers(Me)
    End Sub

    '==================== INACTIVITY TIMER SETUP =============
    Private Sub InitializeInactivityTimer()
        ' Set timer to tick every 1 second (1000 milliseconds)
        inactivityTimer.Interval = 1000
        AddHandler inactivityTimer.Tick, AddressOf InactivityTimer_Tick
        inactivityTimer.Start()

        ' Update label with initial countdown
        UpdateCountdownLabel()
    End Sub

    Private Sub InactivityTimer_Tick(sender As Object, e As EventArgs)
        ' Decrease countdown
        countdownSeconds -= 1

        ' Update label
        UpdateCountdownLabel()

        ' Check if countdown reached zero
        If countdownSeconds <= 0 Then
            inactivityTimer.Stop()
            LogoutDueToInactivity()
        End If
    End Sub

    Private Sub UpdateCountdownLabel()
        ' Update a label to show countdown (make sure you have lblInactivity label on your form)
        If Me.Controls.Contains(lblInactivity) Then
            lblInactivity.Text = "Inactivity Logout: " & countdownSeconds & "s"

            ' Change color based on time remaining
            If countdownSeconds <= 3 Then
                lblInactivity.ForeColor = Color.Red
            ElseIf countdownSeconds <= 5 Then
                lblInactivity.ForeColor = Color.Orange
            Else
                lblInactivity.ForeColor = Color.Green
            End If
        End If
    End Sub

    Private Sub LogoutDueToInactivity()
        MessageBox.Show("You have been logged out due to inactivity.", "Session Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Log the activity
        AuditTrailing.LogActivity("User logged out due to inactivity from Dashboard")

        ' Clear any sensitive data
        txtID.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        cmbStatus.Text = ""
        cmbRole.Text = ""
        txtSearch.Clear()

        ' Show login form and close this form
        Login.Show()
        Me.Close()
    End Sub

    Private Sub ResetInactivityTimer()
        ' Reset countdown to original value
        countdownSeconds = originalCountdown
        UpdateCountdownLabel()
    End Sub

    '==================== ATTACH ACTIVITY HANDLERS ===========
    Private Sub AttachActivityHandlers(parentControl As Control)
        ' Attach event handlers to the parent control
        AddHandler parentControl.MouseMove, AddressOf UserActivity_Detected
        AddHandler parentControl.MouseClick, AddressOf UserActivity_Detected
        AddHandler parentControl.KeyPress, AddressOf UserActivity_Detected
        AddHandler parentControl.KeyDown, AddressOf UserActivity_Detected

        ' Recursively attach handlers to all child controls
        For Each ctrl As Control In parentControl.Controls
            AddHandler ctrl.MouseMove, AddressOf UserActivity_Detected
            AddHandler ctrl.MouseClick, AddressOf UserActivity_Detected
            AddHandler ctrl.KeyPress, AddressOf UserActivity_Detected
            AddHandler ctrl.KeyDown, AddressOf UserActivity_Detected
            AddHandler ctrl.Click, AddressOf UserActivity_Detected

            ' For TextBox controls, also monitor text changes
            If TypeOf ctrl Is TextBox Then
                AddHandler DirectCast(ctrl, TextBox).TextChanged, AddressOf UserActivity_Detected
            End If

            ' For ComboBox controls, monitor selection changes
            If TypeOf ctrl Is ComboBox Then
                AddHandler DirectCast(ctrl, ComboBox).SelectedIndexChanged, AddressOf UserActivity_Detected
            End If

            ' Recursively attach to nested controls
            If ctrl.HasChildren Then
                AttachActivityHandlers(ctrl)
            End If
        Next
    End Sub

    Private Sub UserActivity_Detected(sender As Object, e As EventArgs)
        ' Reset the timer whenever user activity is detected
        ResetInactivityTimer()
    End Sub

    '==================== PASSWORD VALIDATION ===============
    Private Function IsStrongPassword(password As String) As Boolean
        ' Check if password has at least 8 characters
        If password.Length < 8 Then
            Return False
        End If

        ' Check for uppercase letter
        Dim hasUpperCase As Boolean = Regex.IsMatch(password, "[A-Z]")

        ' Check for number
        Dim hasNumber As Boolean = Regex.IsMatch(password, "[0-9]")

        ' Check for special character
        Dim hasSpecialChar As Boolean = Regex.IsMatch(password, "[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]")

        Return hasUpperCase And hasNumber And hasSpecialChar
    End Function

    Private Function GetPasswordStrengthMessage(password As String) As String
        Dim issues As New List(Of String)

        If password.Length < 8 Then
            issues.Add("at least 8 characters")
        End If

        If Not Regex.IsMatch(password, "[A-Z]") Then
            issues.Add("at least one uppercase letter")
        End If

        If Not Regex.IsMatch(password, "[0-9]") Then
            issues.Add("at least one number")
        End If

        If Not Regex.IsMatch(password, "[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]") Then
            issues.Add("at least one special character (!@#$%^&* etc.)")
        End If

        If issues.Count > 0 Then
            Return "Weak password! Password must contain:" & vbCrLf & "• " & String.Join(vbCrLf & "• ", issues)
        End If

        Return ""
    End Function

    '==================== LOAD TABLE ========================
    Private Sub LoadUsers()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM user_tbl", conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvUsers.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    '==================== VIEW BUTTON =======================
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        LoadUsers()
    End Sub

    '==================== ADD USER ==========================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Validate password strength
        If Not IsStrongPassword(txtPassword.Text) Then
            Dim message As String = GetPasswordStrengthMessage(txtPassword.Text)
            MessageBox.Show(message, "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        Try
            conn.Open()
            Dim query As String =
                "INSERT INTO user_tbl (username, password, status, role) 
                 VALUES (@uname, @pass, @status, @role)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@uname", txtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text)
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text)
            cmd.Parameters.AddWithValue("@role", cmbRole.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("User Added!")

            LoadUsers()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    '==================== UPDATE USER =======================
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Validate password strength
        If Not IsStrongPassword(txtPassword.Text) Then
            Dim message As String = GetPasswordStrengthMessage(txtPassword.Text)
            MessageBox.Show(message, "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(
                "UPDATE user_tbl SET 
                    username=@uname,
                    password=@pass,
                    status=@status,
                    role=@role
                 WHERE id=@id",
                conn
            )

            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.Parameters.AddWithValue("@uname", txtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text)
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text)
            cmd.Parameters.AddWithValue("@role", cmbRole.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("User Updated!")
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    '==================== DELETE USER =======================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("DELETE FROM user_tbl WHERE id=@id", conn)
            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.ExecuteNonQuery()

            MessageBox.Show("User Deleted!")
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    '==================== SEARCH USER =======================
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM user_tbl WHERE username LIKE @search"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            dgvUsers.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    '==================== CLEAR FIELDS =======================
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtID.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        cmbStatus.Text = ""
        cmbRole.Text = ""
        txtSearch.Text = ""
    End Sub

    '==================== CLICK DATAGRID TO FILL TEXTBOXES ===
    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)

            txtID.Text = row.Cells("id").Value.ToString()
            txtUsername.Text = row.Cells("username").Value.ToString()
            txtPassword.Text = row.Cells("password").Value.ToString()
            cmbStatus.Text = row.Cells("status").Value.ToString()
            cmbRole.Text = row.Cells("role").Value.ToString()
        End If
    End Sub

    Private Sub DataEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataEntryToolStripMenuItem.Click
        inactivityTimer.Stop() ' Stop timer when navigating
        DataEntryForm.Show()
        Me.Hide()
    End Sub

    Private Sub AuditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditToolStripMenuItem.Click
        inactivityTimer.Stop() ' Stop timer when navigating
        AuditForm.Show()
        Me.Hide()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        Database.Backup()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        Database.Restore()
    End Sub

    ' Clean up timer when form closes
    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If inactivityTimer IsNot Nothing Then
            inactivityTimer.Stop()
            inactivityTimer.Dispose()
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class