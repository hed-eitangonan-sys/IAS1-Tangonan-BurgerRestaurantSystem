Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class Register

    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db")

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim username As String = TextBox2.Text.Trim()
        Dim password As String = TextBox3.Text.Trim()
        Dim role As String = "User"
        Dim status As String = "Pending"

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim strongPasswordPattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"
        If Not Regex.IsMatch(password, strongPasswordPattern) Then
            MessageBox.Show("Password must be at least 8 characters and include uppercase, lowercase, number, and special character.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn.Open()
            Dim checkCmd As New MySqlCommand("SELECT * FROM user_tbl WHERE username=@username", conn)
            checkCmd.Parameters.AddWithValue("@username", username)
            Dim dt As New DataTable()
            Dim da As New MySqlDataAdapter(checkCmd)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                MessageBox.Show("Username already exists. Please choose another.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim cmd As New MySqlCommand("INSERT INTO user_tbl (username, password, role, status) VALUES (@username, @password, @role, @status)", conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            cmd.Parameters.AddWithValue("@role", role)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Registration successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            AuditTrailing.LogActivity("New user registered: " & username)

            TextBox2.Clear()
            TextBox3.Clear()

            Login.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Login.Show()
        Me.Hide()
    End Sub

End Class
