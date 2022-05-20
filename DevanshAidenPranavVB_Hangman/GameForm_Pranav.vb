Imports System.Timers
Public Class GameForm_Pranav
    Dim buttonListP
    Dim wordListP As New List(Of String) From
        {"Fortnite", "GTAV", "COD", "Battlefield", "FNAF", "Terraria", "Minecraft", "Valorant", "Forza", "Halo", "Brawlstars", "Genshin", "Honkai", "Clashroyale", "Ballgobroom", "Pokemongo", "Titanfall", "Destiny", "Brawlhalla", "Planetside", "Splitgate", "Warframe", "Portal", "Gangbeasts"}
    ReadOnly hangmanPicturesP As New List(Of Bitmap) From
        {My.Resources.hangman0, My.Resources.hangman1, My.Resources.hangman2, My.Resources.hangman3, My.Resources.hangman4, My.Resources.hangman5, My.Resources.hangman6, My.Resources.hangman7, My.Resources.hangman8, My.Resources.hangman9, My.Resources.hangman10}
    Dim completedP = 0
    Dim failedP = 0
    Dim hiddenWordP = ""
    Dim selectedLettersP As String
    Dim livesLostP = 0
    Dim TimeLimitP = TimeSpan.FromMinutes(24)
    Dim TimerP As Timer
    Dim StartP As DateTime
    Dim timePassedP As TimeSpan

    Private Async Sub GameForm_Pranav_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonListP = New List(Of Button) From
        {buttonA, buttonB, buttonC, buttonD, buttonE, buttonF, buttonG, buttonH, buttonI, buttonJ, buttonK, buttonL, buttonM, buttonN, buttonO, buttonP, buttonQ, buttonR, buttonS, buttonT, buttonU, buttonV, buttonW, buttonX, buttonY, buttonZ}
        Reset1()

        StartP = DateTime.Now
        TimerP = New Timer()
        TimerP.Interval = 500
        AddHandler TimerP.Elapsed, AddressOf TimerEvent1
        TimerP.Enabled = True
    End Sub

    Private Sub onpause1() Handles MyBase.VisibleChanged
        If Me.Visible = True Then
            TimerP.Enabled = True
            StartP = Date.Now.Subtract(timePassedP)
        Else
            TimerP.Enabled = False
            timePassedP = DateTime.Now - StartP
        End If
    End Sub

    Private Sub onclose1() Handles MyBase.FormClosed
        TimerP.Enabled = False
    End Sub

    Private Sub TimerEvent1(ByVal source As Object, ByVal e As ElapsedEventArgs)
        Dim timeLeft = (TimeLimitP - (DateTime.Now - StartP))
        If timeLeft <= TimeSpan.Zero Then
            Me.Invoke(Sub()
                          timerLabel.Text = timeLeft.ToString("00: 00")
                      End Sub)
            TimerP.Enabled = False
            GameFinish1("time")
        Else
            Me.Invoke(Sub()
                          timerLabel.Text = timeLeft.ToString("mm\:ss")
                      End Sub)
        End If
    End Sub

    Private Sub SetTimer1()
        timerLabel.Text = (TimeLimitP - (DateTime.Now - StartP)).ToString("mm\:ss")
    End Sub
    Private Sub Reset1()
        Static Generator As New Random()
        If wordListP.Count <> 0 Then
            Dim index = Generator.Next(0, wordListP.Count - 1)
            hiddenWordP = wordListP(index)
            Debug.Print(hiddenWordP)
            Debug.Print(index)
        Else
            completedAmountLabel.Text() = "Completed: " + completedP.ToString()
            failedWordsLabel.Text() = "Failed: " + failedP.ToString()
            wordsLeftLabel.Text() = "Words Left: 0"

            GameFinish1("emptyList")
            Exit Sub

        End If


        completedAmountLabel.Text() = "Completed: " + completedP.ToString()
        failedWordsLabel.Text() = "Failed: " + failedP.ToString()
        wordsLeftLabel.Text() = "Words Left: " + wordListP.Count.ToString()

        livesLostP = 0
        hiddenWordLabel.Text() = ""
        selectedLettersP = ""
        hiddenWordLabel.Text() = ""

        For Each c As Char In hiddenWordP
            hiddenWordLabel.Text() += "_ "
        Next

        hangmanPicture.Image = hangmanPicturesP(livesLostP)

        For Each currentButton As Button In buttonListP
            currentButton.Enabled = True
            currentButton.BackColor = Color.FromArgb(100, 200, 200, 200)
        Next
    End Sub
    Private Sub GameFinish1(reason)
        If reason = "time" Then
            MsgBox("You ran out of time to save everyone! There were still " + wordListP.Count.ToString + " men left! Try to save more next time!", 1, "Game Over!")
            MainMenu.Show()
            Me.Close()
        ElseIf reason = "emptyList" Then
            MsgBox("You've gone through all the words and saved " + completedP.ToString + " of them! Good job!", 1, "Game Over!")
            MainMenu.Show()
            Me.Close()
        End If

    End Sub
    Private Sub GameOver1()
        wordListP.Remove(hiddenWordP)
        failedP += 1
        MsgBox("The man has been hanged, you couldn't save him! The correct word was: " + hiddenWordP, 1, "Game Lost!")
        Reset1()
    End Sub

    Private Sub GameWon1()
        wordListP.Remove(hiddenWordP)
        completedP += 1
        MsgBox("You saved the man! He is free once more! The word was: " + hiddenWordP, 1, "Game Won!")
        Reset1()
    End Sub

    Private Sub Game_button_click1(sender As Object, e As EventArgs) Handles buttonA.Click, buttonB.Click, buttonC.Click, buttonD.Click, buttonE.Click, buttonF.Click, buttonG.Click, buttonH.Click, buttonI.Click, buttonJ.Click, buttonK.Click, buttonL.Click, buttonM.Click, buttonN.Click, buttonO.Click, buttonP.Click, buttonQ.Click, buttonR.Click, buttonS.Click, buttonT.Click, buttonU.Click, buttonV.Click, buttonW.Click, buttonX.Click, buttonY.Click, buttonZ.Click
        Dim clicked As Button = DirectCast(sender, Button)
        clicked.Enabled = False
        selectedLettersP += clicked.Text

        hiddenWordLabel.Text() = ""
        Dim foundLetter
        Dim wordFound = True
        Dim wrongLetter = True
        For Each c As Char In hiddenWordP.ToUpper()
            If clicked.Text = c Then
                wrongLetter = False
            End If
        Next
        If wrongLetter Then
            livesLostP += 1
            clicked.BackColor = Color.FromArgb(100, 255, 20, 20)
        Else
            clicked.BackColor = Color.FromArgb(100, 20, 255, 20)
        End If

        For Each c As Char In hiddenWordP.ToUpper()
            foundLetter = False
            For Each c2 As Char In selectedLettersP.ToUpper()
                If c = c2 Then
                    hiddenWordLabel.Text() += (c2 + " ")
                    foundLetter = True
                End If
            Next
            If Not foundLetter Then
                hiddenWordLabel.Text() += "_ "
                wordFound = False
            End If
        Next

        If livesLostP = 10 Then
            GameOver1()
            Exit Sub
        ElseIf wordFound Then
            GameWon1()
            Exit Sub
        End If

        hangmanPicture.Image = hangmanPicturesP(livesLostP)

    End Sub

    Private Sub resetBtn_Click1(sender As Object, e As EventArgs) Handles resetBtn.Click
        If MsgBox("Are you sure you want to give up? This will count as a failed word!", 4, "Give up?") = 6 Then
            GameOver1()
        End If
    End Sub

    Private Sub menuBtn_Click1(sender As Object, e As EventArgs) Handles menuBtn.Click
        If MsgBox("Do you want to reset all your progress as well?", 4, "Reset progress too?") = 6 Then
            MainMenu.Show()
            Me.Close()
        Else
            MainMenu.Show()
            Me.Hide()
        End If
    End Sub
End Class