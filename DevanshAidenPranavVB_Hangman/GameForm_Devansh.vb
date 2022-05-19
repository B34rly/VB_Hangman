Imports System.Timers
Public Class GameForm_Devansh
    Dim buttonListD
    Dim wordListD As New List(Of String) From
        {"Australia", "England", "India", "Bangladesh", "Afghanistan", "Bhutan", "Canada", "America", "France", "Germany", "Russia", "Israel", "Uruguay", "Botswana", "Uzbekistan", "Portuagal", "Mexico", "Mozambique", "Romania", "Romania", "Peru", "Brazil", "Japan", "Ireland"}
    ReadOnly hangmanPicturesD As New List(Of Bitmap) From
        {My.Resources.hangman0, My.Resources.hangman1, My.Resources.hangman2, My.Resources.hangman3, My.Resources.hangman4, My.Resources.hangman5, My.Resources.hangman6, My.Resources.hangman7, My.Resources.hangman8, My.Resources.hangman9, My.Resources.hangman10}
    Dim completedD = 0
    Dim failedD = 0
    Dim hiddenWordD = ""
    Dim selectedLettersD As String
    Dim livesLostD = 0
    Dim TimeLimitD = TimeSpan.FromMinutes(24)
    Dim TimerD As Timer
    Dim StartD As DateTime
    Dim timePassedD As TimeSpan

    Private Async Sub GameForm_Devansh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonListD = New List(Of Button) From
        {buttonA, buttonB, buttonC, buttonD, buttonE, buttonF, buttonG, buttonH, buttonI, buttonJ, buttonK, buttonL, buttonM, buttonN, buttonO, buttonP, buttonQ, buttonR, buttonS, buttonT, buttonU, buttonV, buttonW, buttonX, buttonY, buttonZ}
        Reset1()

        StartD = DateTime.Now
        TimerD = New Timer()
        TimerD.Interval = 500
        AddHandler TimerD.Elapsed, AddressOf TimerEvent1
        TimerD.Enabled = True
    End Sub

    Private Sub onpause1() Handles MyBase.VisibleChanged
        If Me.Visible = True Then
            TimerD.Enabled = True
            StartD = Date.Now.Subtract(timePassedD)
        Else
            TimerD.Enabled = False
            timePassedD = DateTime.Now - StartD
        End If
    End Sub

    Private Sub onclose2() Handles MyBase.FormClosed
        TimerD.Enabled = False
    End Sub

    Private Sub TimerEvent1(ByVal source As Object, ByVal e As ElapsedEventArgs)
        Dim timeLeft = (TimeLimitD - (DateTime.Now - StartD))
        If timeLeft <= TimeSpan.Zero Then
            Me.Invoke(Sub()
                          timerLabel.Text = timeLeft.ToString("00: 00")
                      End Sub)
            GameFinish1("time")
        Else
            Me.Invoke(Sub()
                          timerLabel.Text = timeLeft.ToString("mm\:ss")
                      End Sub)
        End If
    End Sub

    Private Sub SetTimer2()
        timerLabel.Text = (TimeLimitD - (DateTime.Now - StartD)).ToString("mm\:ss")
    End Sub
    Private Sub Reset1()
        Static Generator As New Random()
        If wordListD.Count <> 0 Then
            Dim index = Generator.Next(0, wordListD.Count - 1)
            hiddenWordD = wordListD(index)
            Debug.Print(hiddenWordD)
            Debug.Print(index)
        Else
            completedAmountLabel.Text() = "Completed: " + completedD.ToString()
            failedWordsLabel.Text() = "Failed: " + failedD.ToString()
            wordsLeftLabel.Text() = "Words Left: 0"

            GameFinish1("emptyList")
            Exit Sub

        End If


        completedAmountLabel.Text() = "Completed: " + completedD.ToString()
        failedWordsLabel.Text() = "Failed: " + failedD.ToString()
        wordsLeftLabel.Text() = "Words Left: " + wordListD.Count.ToString()

        livesLostD = 0
        hiddenWordLabel.Text() = ""
        selectedLettersD = ""
        hiddenWordLabel.Text() = ""

        For Each c As Char In hiddenWordD
            hiddenWordLabel.Text() += "_ "
        Next

        hangmanPicture.Image = hangmanPicturesD(livesLostD)

        For Each currentButton As Button In buttonListD
            currentButton.Enabled = True
            currentButton.BackColor = Color.FromArgb(100, 200, 200, 200)
        Next
    End Sub
    Private Sub GameFinish1(reason)
        If reason = "time" Then
            MsgBox("You ran out of time to save everyone! There were still " + wordListD.Count.ToString + " men left! Try to save more next time!", 1, "Game Over!")
            MainMenu.Show()
            Me.Close()
        ElseIf reason = "emptyList" Then
            MsgBox("You've gone through all the words and saved " + completedD.ToString + " of them! Good job!", 1, "Game Over!")
            MainMenu.Show()
            Me.Close()
        End If

    End Sub
    Private Sub GameOver1()
        wordListD.Remove(hiddenWordD)
        failedD += 1
        MsgBox("The man has been hanged, you couldn't save him! The correct word was: " + hiddenWordD, 1, "Game Lost!")
        Reset()
    End Sub

    Private Sub GameWon1()
        wordListD.Remove(hiddenWordD)
        completedD += 1
        MsgBox("You saved the man! He is free once more! The word was: " + hiddenWordD, 1, "Game Won!")
        Reset1()
    End Sub

    Private Sub Game_button_click1(sender As Object, e As EventArgs) Handles buttonA.Click, buttonB.Click, buttonC.Click, buttonD.Click, buttonE.Click, buttonF.Click, buttonG.Click, buttonH.Click, buttonI.Click, buttonJ.Click, buttonK.Click, buttonL.Click, buttonM.Click, buttonN.Click, buttonO.Click, buttonP.Click, buttonQ.Click, buttonR.Click, buttonS.Click, buttonT.Click, buttonU.Click, buttonV.Click, buttonW.Click, buttonX.Click, buttonY.Click, buttonZ.Click
        Dim clicked As Button = DirectCast(sender, Button)
        clicked.Enabled = False
        selectedLettersD += clicked.Text

        hiddenWordLabel.Text() = ""
        Dim foundLetter
        Dim wordFound = True
        Dim wrongLetter = True
        For Each c As Char In hiddenWordD.ToUpper()
            If clicked.Text = c Then
                wrongLetter = False
            End If
        Next
        If wrongLetter Then
            livesLostD += 1
            clicked.BackColor = Color.FromArgb(100, 255, 20, 20)
        Else
            clicked.BackColor = Color.FromArgb(100, 20, 255, 20)
        End If

        For Each c As Char In hiddenWordD.ToUpper()
            foundLetter = False
            For Each c2 As Char In selectedLettersD.ToUpper()
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

        If livesLostD = 10 Then
            GameOver1()
            Exit Sub
        ElseIf wordFound Then
            GameWon1()
            Exit Sub
        End If

        hangmanPicture.Image = hangmanPicturesD(livesLostD)

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