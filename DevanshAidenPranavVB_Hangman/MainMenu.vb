Public Class MainMenu
    Public musicPlaying As Boolean = True
    Private Sub onshow(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        playBtn.Visible = True
        exitBtn.Visible = True
        instructionsBtn.Visible = True
        creditsBtn.Visible = True
        Devansh.Visible = False
        Aiden.Visible = False
        Pranav.Visible = False
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

    Private Sub playBtn_Click(sender As Object, e As EventArgs) Handles playBtn.Click
        bgPanel.Visible = True
        TopicLbl.Visible = True
        TopicLbl.Text = "Select Topic"
        infoLbl.Visible = False

        Devansh.Visible = True
        Aiden.Visible = True
        Pranav.Visible = True
    End Sub

    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Application.Exit()
    End Sub

    Private Sub creditsBtn_Click(sender As Object, e As EventArgs) Handles creditsBtn.Click
        bgPanel.Visible = True
        TopicLbl.Visible = True
        TopicLbl.Text = "Credits"
        infoLbl.Visible = True
        infoLbl.Text = "Music: Evan King - Vapor"

        Devansh.Visible = False
        Aiden.Visible = False
        Pranav.Visible = False
    End Sub

    Private Sub instructionsBtn_Click(sender As Object, e As EventArgs) Handles instructionsBtn.Click
        bgPanel.Visible = True
        TopicLbl.Visible = True
        TopicLbl.Text = "How to Play"
        infoLbl.Visible = True
        infoLbl.Text = "A hidden word chosen based on the topic you've selected. You have to find this word to save the man being hung! 
To find the word you select a letter from the on-screen keyboard, if the letter is part of the word it will get revealed at the top. 
If it isn't another part of the man is drawn, you can only make 10 mistakes before his fate is sealed. 
There are 24 total words of different length in each topic, can you solve them all and save everyone?"

        Devansh.Visible = False
        Aiden.Visible = False
        Pranav.Visible = False
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.synth1,
          AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub songButton_Click(sender As Object, e As EventArgs) Handles songButton.Click
        If musicPlaying Then
            My.Computer.Audio.Stop()
            songButton.BackgroundImage = My.Resources.icons8_mute_100
            musicPlaying = False
        Else
            My.Computer.Audio.Play(My.Resources.synth1,
          AudioPlayMode.BackgroundLoop)
            songButton.BackgroundImage = My.Resources.icons8_audio_100
            musicPlaying = True
        End If
    End Sub
End Class
