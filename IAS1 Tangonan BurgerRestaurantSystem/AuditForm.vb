Imports MySql.Data.MySqlClient

Public Class AuditForm

    '==================== DATABASE CONNECTION ====================
    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db")

    '==================== INACTIVITY TIMER VARIABLES ==============
    Private inactivityTimer As New Timer()
    Private countdownSeconds As Integer = 10
    Private originalCountdown As Integer = 10

    '==================== FORM LOAD ===============================
    Private Sub AuditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAuditData()

        ' Initialize inactivity timer
        InitializeInactivityTimer()

        ' Attach event handlers to detect user activity
        AttachActivityHandlers(Me)
    End Sub

    '==================== LOAD AUDIT LOGS =========================
    Private Sub LoadAuditData()
        Try
            conn.Open()
            Dim da As New MySqlDataAdapter("SELECT * FROM audit_tbl", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvAudit.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error loading audit logs", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    '==================== SEARCH BUTTON ===========================
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Using connect As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db;")
                connect.Open()

                Using cmd As New MySqlCommand("SELECT * FROM audit_tbl WHERE activity LIKE @search AND log_date >= @from AND log_date <= @to", connect)
                    cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
                    cmd.Parameters.AddWithValue("@from", dtFrom.Value)
                    cmd.Parameters.AddWithValue("@to", dtTo.Value)

                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvAudit.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '==================== INACTIVITY TIMER SETUP ==================
    Private Sub InitializeInactivityTimer()
        inactivityTimer.Interval = 1000
        AddHandler inactivityTimer.Tick, AddressOf InactivityTimer_Tick
        inactivityTimer.Start()
        UpdateCountdownLabel()
    End Sub

    Private Sub InactivityTimer_Tick(sender As Object, e As EventArgs)
        countdownSeconds -= 1
        UpdateCountdownLabel()

        If countdownSeconds <= 0 Then
            inactivityTimer.Stop()
            LogoutDueToInactivity()
        End If
    End Sub

    Private Sub UpdateCountdownLabel()
        If Me.Controls.Contains(lblInactivity) Then
            lblInactivity.Text = "Inactivity Logout: " & countdownSeconds & "s"

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
        MessageBox.Show("You have been logged out due to inactivity.", "Session Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        AuditTrailing.LogActivity("User logged out due to inactivity from AuditForm")

        Login.Show()
        Me.Close()
    End Sub

    Private Sub ResetInactivityTimer()
        countdownSeconds = originalCountdown
        UpdateCountdownLabel()
    End Sub

    '==================== USER ACTIVITY TRACKING ==================
    Private Sub AttachActivityHandlers(parentControl As Control)
        AddHandler parentControl.MouseMove, AddressOf UserActivity_Detected
        AddHandler parentControl.MouseClick, AddressOf UserActivity_Detected
        AddHandler parentControl.KeyPress, AddressOf UserActivity_Detected
        AddHandler parentControl.KeyDown, AddressOf UserActivity_Detected

        For Each ctrl As Control In parentControl.Controls
            AddHandler ctrl.MouseMove, AddressOf UserActivity_Detected
            AddHandler ctrl.MouseClick, AddressOf UserActivity_Detected
            AddHandler ctrl.KeyPress, AddressOf UserActivity_Detected
            AddHandler ctrl.KeyDown, AddressOf UserActivity_Detected
            AddHandler ctrl.Click, AddressOf UserActivity_Detected

            If TypeOf ctrl Is TextBox Then
                AddHandler CType(ctrl, TextBox).TextChanged, AddressOf UserActivity_Detected
            End If

            If TypeOf ctrl Is ComboBox Then
                AddHandler CType(ctrl, ComboBox).SelectedIndexChanged, AddressOf UserActivity_Detected
            End If

            If ctrl.HasChildren Then
                AttachActivityHandlers(ctrl)
            End If
        Next
    End Sub

    Private Sub UserActivity_Detected(sender As Object, e As EventArgs)
        ResetInactivityTimer()
    End Sub

    '==================== MENU NAVIGATION =========================
    Private Sub DataEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataEntryToolStripMenuItem.Click
        inactivityTimer.Stop()
        DataEntryForm.Show()
        Me.Hide()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        inactivityTimer.Stop()
        Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        Database.Backup()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        Database.Restore()
    End Sub

    '==================== CLEANUP =============================
    Private Sub AuditForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        inactivityTimer.Stop()
        inactivityTimer.Dispose()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class
