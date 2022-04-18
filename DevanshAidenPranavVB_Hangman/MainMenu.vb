Public Class MainMenu
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Devansh_Click(sender As Object, e As EventArgs) Handles Devansh.Click
        GameForm_Devansh.Show()
        Me.Hide()
    End Sub

    Private Sub Aiden_Click(sender As Object, e As EventArgs) Handles Aiden.Click
        GameForm_Aiden.Show()
        Me.Hide()
    End Sub

    Private Sub Pranav_Click(sender As Object, e As EventArgs) Handles Pranav.Click
        GameForm_Pranav.Show()
        Me.Hide()
    End Sub
End Class
