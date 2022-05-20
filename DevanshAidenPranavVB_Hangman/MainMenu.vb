Public Class MainMenu
    Public musicPlaying As Boolean = True
    Private Sub onshow(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Devansh.Visible = False
        Aiden.Visible = False
        Pranav.Visible = False

        If Not musicPlaying Then
            songBtn.BackgroundImage = My.Resources.icons8_mute_100
        Else
            songBtn.BackgroundImage = My.Resources.icons8_audio_100
        End If
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
        topicLbl.Visible = True
        topicLbl.Text = "Select Topic"
        infoLbl.Visible = False

        Devansh.Visible = True
        Aiden.Visible = True
        Pranav.Visible = True
    End Sub

    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        If MsgBox("Are you sure you want to exit?", 4, "Exit?") = 6 Then
            Application.Exit()
        End If
    End Sub

    Private Sub creditsBtn_Click(sender As Object, e As EventArgs) Handles creditsBtn.Click
        bgPanel.Visible = True
        topicLbl.Visible = True
        topicLbl.Text = "Credits"
        infoLbl.Visible = True
        infoLbl.Text = "This Hangman game is brought to you by Beribus Games, consisting of Aiden Naji, Devansh Sayal and Pranav Gupta.
Lead Programmer: Aiden Naji
Resource Manager: Devansh Sayal
Graphic Designer: Pranav Gupta
Music: Evan King - Vapor (context-sensitive.com)
Icons: icons8.com"

        Devansh.Visible = False
        Aiden.Visible = False
        Pranav.Visible = False
    End Sub

    Private Sub instructionsBtn_Click(sender As Object, e As EventArgs) Handles instructionsBtn.Click
        bgPanel.Visible = True
        topicLbl.Visible = True
        topicLbl.Text = "How to Play"
        infoLbl.Visible = True
        infoLbl.Text = "A hidden word chosen based on the topic you've selected. You have to find this word to save the man being hung! 
To find the word you select a letter from the on-screen keyboard, if the letter is part of the word it will get revealed at the top. 
If it isn't another part of the man is drawn, you can only make 10 mistakes before his fate is sealed. 
There are 24 total words of different length in each topic and there is 24 minutes to solve them all,
can you solve them all and save everyone in time?"

        Devansh.Visible = False
        Aiden.Visible = False
        Pranav.Visible = False
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.synth1,
          AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub songBtn_Click(sender As Object, e As EventArgs) Handles songBtn.Click
        If musicPlaying Then
            My.Computer.Audio.Stop()
            songBtn.BackgroundImage = My.Resources.icons8_mute_100
            musicPlaying = False
        Else
            My.Computer.Audio.Play(My.Resources.synth1,
          AudioPlayMode.BackgroundLoop)
            songBtn.BackgroundImage = My.Resources.icons8_audio_100
            musicPlaying = True
        End If
    End Sub
End Class
