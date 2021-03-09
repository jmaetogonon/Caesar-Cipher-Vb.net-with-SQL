Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbConnection()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim registerForm As New frmregister
        registerForm.Show()
        Me.Hide()

    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Fields must not be empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If isFoundAccount(username, Encipher(password, 3)).ToString.Equals(txtUsername.Text) Then
                If Decipher(u_password, 3) = password Then
                    MessageBox.Show("Login Successfully", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Home.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid Username / Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid Username / Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub username_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        ' only numbers and letters, backspace
        If (Not Char.IsLetter(e.KeyChar) AndAlso (Not Char.IsDigit(e.KeyChar)) AndAlso e.KeyChar <> ControlChars.Back) Then e.Handled = True

    End Sub
End Class
