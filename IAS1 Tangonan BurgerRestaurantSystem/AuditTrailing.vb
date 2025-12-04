Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports MySql.Data.MySqlClient

Public Class AuditTrailing
    Public Shared Sub LogActivity(user_id As Integer, username As String, Activity As String)
        Using co As New MySqlConnection("server=localhost; userid=root; password=root; database=burger_db;")
            co.Open()

            Using cmd As New MySqlCommand("INSERT INTO audit_tbl (userid, username, activity, log_date) VALUES (@userid, @username, @activity, NOW())", co)
                cmd.Parameters.AddWithValue("@userid", user_id)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@activity", Activity)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub LogActivity(Activity As String)
        LogActivity(1, "admin", Activity)
    End Sub
End Class
