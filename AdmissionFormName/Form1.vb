
Imports MySql.Data.MySqlClient






Public Class Form1

    Public applicant As Object

    Dim cred As String = "server=localhost; uid=root; pwd=; database=sunbeam;"
    Dim conn As New MySqlConnection(cred)

    Sub loadapplicants()
        Dim query As String = "select * from application"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet
        adpt.Fill(ds, "application")
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        RichTextBox1.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        ComboBox1.Text = ""









    End Sub





    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadapplicants()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As MySqlCommand
        conn.Open()
        Dim gender As String
        If RadioButton1.Checked Then
            gender = "male"
        ElseIf RadioButton2.Checked Then
            gender = "female"
        ElseIf RadioButton3.Checked Then
            gender = "others"

        End If
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "INSERT INTO application(first_name, last_name, gender, address, pincode, email, alt_email, prefered_language, contact) VALUES (@first_name, @last_name, @gender, @address, @pincode, @email, @alt_email, @prefered_language, @contact);"
            cmd.Parameters.AddWithValue("@first_name", TextBox1.Text)
            cmd.Parameters.AddWithValue("@last_name", TextBox2.Text)
            cmd.Parameters.AddWithValue("@address", RichTextBox1.Text)
            cmd.Parameters.AddWithValue("@gender", gender)
            cmd.Parameters.AddWithValue("@pincode", TextBox3.Text)
            cmd.Parameters.AddWithValue("@contact", TextBox5.Text)
            cmd.Parameters.AddWithValue("@email", TextBox4.Text)
            cmd.Parameters.AddWithValue("@alt_email", TextBox6.Text)
            cmd.Parameters.AddWithValue("@prefered_language", ComboBox1.Text)
            cmd.ExecuteNonQuery()
            loadapplicants()

        Catch ex As Exception
            conn.Close()


        End Try
        conn.Close()


    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
End Class
