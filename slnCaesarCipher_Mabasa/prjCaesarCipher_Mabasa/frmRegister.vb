Public Class frmregister
    Dim strQuery = ""

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtID.Text = "" Or txtFname.Text = "" Or txtMName.Text = "" Or txtLname.Text = "" Or txtPhone.Text = "" Or txtUser.Text = "" Or txtPass.Text = "" Then
            MessageBox.Show("Fields must not be empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If checkusername(txtUser.Text).ToString.Equals(txtUser.Text) Then
                MessageBox.Show("Username already exists", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf checkId(txtID.Text).ToString.Equals(txtID.Text) Then
                MessageBox.Show("ID no. already exists", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    response = MsgBox("Are you sure you want to register?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Saving Utility")
                    If response = vbYes Then
                        strQuery = "INSERT INTO tbl_users(id, fname, mname, lname, phone, username,password) " &
                        "VALUES('" + txtID.Text + "', '" + txtFname.Text + "', '" + txtMName.Text + "', '" + txtLname.Text + "', '+63" + txtPhone.Text + "', '" + txtUser.Text + "', '" + Encipher(txtPass.Text, 3) + "')"
                        SaveData(strQuery)
                        Me.Close()
                        frmLogin.Show()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: Save() " & ex.Message, "Coffee POS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub txt_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtID.KeyPress, txtPhone.KeyPress
        ' allows only numbers and the Backspace
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtLetters_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtFname.KeyPress, txtMName.KeyPress, txtLname.KeyPress
        ' only letters and whitespace, backspace
        If (Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c AndAlso e.KeyChar <> ControlChars.Back) Then e.Handled = True
        If (DirectCast(sender, TextBox).Text.Length = 0) Then e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub
    Private Sub username_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtUser.KeyPress
        ' only numbers and letters, backspace
        If (Not Char.IsLetter(e.KeyChar) AndAlso (Not Char.IsDigit(e.KeyChar)) AndAlso e.KeyChar <> ControlChars.Back) Then e.Handled = True
    End Sub
End Class