Imports System.Data.Common
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class DataEntryForm
    Private productID As Integer

    ' Inactivity Timer Variables
    Private inactivityTimer As New Timer()
    Private countdownSeconds As Integer = 10
    Private originalCountdown As Integer = 10 ' Store original value for reset

    Private Sub DataEntryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetProductList()

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
        AuditTrailing.LogActivity("User logged out due to inactivity")

        ' Clear any sensitive data
        txtName.Clear()
        txtPrice.Clear()

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

    '==================== ORIGINAL FUNCTIONS =================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If (txtName.Text.Trim() = "" Or txtPrice.Text.Trim() = "") Then
            MessageBox.Show("Fields must not be empty", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        End If

        If (Not Regex.IsMatch(txtName.Text, "^[A-Za-z]")) Then
            MessageBox.Show("Name must begin with a letter", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        End If

        If (Not Regex.IsMatch(txtPrice.Text, "^\d+(\.\d+)?$")) Then
            MessageBox.Show("Price must be a valid number", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        End If

        Try
            Using connect As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db;")
                connect.Open()
                Using comm As New MySqlCommand("INSERT INTO menu_tbl (item_name, price) VALUES (@item_name, @price);", connect)
                    comm.Parameters.AddWithValue("@item_name", txtName.Text)
                    comm.Parameters.AddWithValue("@price", txtPrice.Text)
                    comm.ExecuteNonQuery()

                    AuditTrailing.LogActivity("Added item: item_name='" & txtName.Text & "', price='" & txtPrice.Text & "'")
                    GetProductList()
                End Using
            End Using
        Catch ex As Exception
            AuditTrailing.LogActivity("Error adding item: item_name='" & txtName.Text & "', price='" & txtPrice.Text & "'")
            MessageBox.Show(ex.Message, "Data Entry Addition Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvIAS_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIAS.CellClick
        Dim rowIndex = dgvIAS.CurrentCell.RowIndex
        If dgvIAS.CurrentCell.RowIndex > -1 Then
            txtName.Text = dgvIAS.Rows(rowIndex).Cells("item_name").Value.ToString()
            txtPrice.Text = dgvIAS.Rows(rowIndex).Cells("price").Value.ToString()
            If Not IsDBNull(dgvIAS.Rows(rowIndex).Cells("id").Value) Then
                productID = Integer.Parse(dgvIAS.Rows(rowIndex).Cells("id").Value)
            End If
        End If
    End Sub

    Private Sub GetProductList()
        Try
            Using connect As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db;")
                connect.Open()
                Dim dataAdapter As New MySqlDataAdapter("SELECT * FROM menu_tbl", connect)
                Dim dataTable As New DataTable()
                dataAdapter.Fill(dataTable)
                dgvIAS.DataSource = dataTable
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Data Entry Listing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Using connect As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db;")
                connect.Open()
                Using comm As New MySqlCommand("DELETE FROM menu_tbl WHERE id=@id", connect)
                    comm.Parameters.AddWithValue("@id", productID)
                    comm.ExecuteNonQuery()

                    AuditTrailing.LogActivity("Item deleted: item_name='" & txtName.Text & "', price='" & txtPrice.Text & "'")
                    GetProductList()
                    MessageBox.Show("Product successfully deleted.", "Product Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Data Entry Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AuditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditToolStripMenuItem.Click
        inactivityTimer.Stop() ' Stop timer when navigating
        AuditForm.Show()
        Me.Hide()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        inactivityTimer.Stop() ' Stop timer when navigating
        Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        ' Add your update code here
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        Database.Backup()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        Database.Restore()
    End Sub

    ' Clean up timer when form closes
    Private Sub DataEntryForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If inactivityTimer IsNot Nothing Then
            inactivityTimer.Stop()
            inactivityTimer.Dispose()
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        GetProductList()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class