Imports MySql.Data.MySqlClient

Public Class Login

    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db")

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set password character to hide password
        txtPassword.PasswordChar = "*"

        ' Set default focus to username textbox
        txtUsername.Focus()
    End Sub

    '==================== LOGIN BUTTON =======================
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate input fields
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter username!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter password!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        Try
            conn.Open()

            ' Query to check username and password
            Dim query As String = "SELECT * FROM user_tbl WHERE username=@username AND password=@password"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            ' Check if user exists
            If dt.Rows.Count > 0 Then
                ' Check if user status is Active
                Dim status As String = dt.Rows(0)("status").ToString()

                If status = "Active" Then
                    Dim role As String = dt.Rows(0)("role").ToString()
                    Dim username As String = dt.Rows(0)("username").ToString()

                    MessageBox.Show("Login Successful!" & vbCrLf & "Welcome, " & username & "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Open Dashboard and close login form
                    Dashboard.Show()
                    Me.Hide()

                    ' Clear fields after successful login
                    txtUsername.Clear()
                    txtPassword.Clear()
                Else
                    MessageBox.Show("Your account is Inactive!" & vbCrLf & "Please contact the administrator.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ' Login failed
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Clear()
                txtUsername.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    '==================== CANCEL BUTTON ======================
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Ask for confirmation before closing
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    '==================== SHOW PASSWORD CHECKBOX =============
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            ' Show password
            txtPassword.PasswordChar = ""
        Else
            ' Hide password
            txtPassword.PasswordChar = "*"
        End If
    End Sub

    '==================== ENTER KEY TO LOGIN =================
    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        ' Press Enter to move to password field
        If e.KeyChar = Chr(13) Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        ' Press Enter to trigger login
        If e.KeyChar = Chr(13) Then
            btnLogin_Click(sender, e)
        End If
    End Sub


    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        CheckCapsLock()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        CheckCapsLock()
    End Sub

    Private Sub CheckCapsLock()
        If Control.IsKeyLocked(Keys.CapsLock) Then
            lblCapsLock.Visible = True
            lblCapsLock.Text = "Capslock Is On!"
            lblCapsLock.ForeColor = Color.Red
        Else
            lblCapsLock.Visible = False
        End If
    End Sub

    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click
        Register.Show()
        Me.Hide()
    End Sub
End Class