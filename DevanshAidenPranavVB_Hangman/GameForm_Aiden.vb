Imports System.Text.RegularExpressions
Public Class GameForm_Aiden
    Dim buttonList
    Dim wordList As New List(Of String) From
        {"Toyota", "Mitsubishi", "Hyundai", "Mercedes", "Subaru", "Nissan", "Volkswagen", "Audi", "Bently", "Chevrolet", "Ferrari", "Lamborghini", "Fiat", "Ford", "Honda", "Kia", "Jeep", "Lexus", "Mazda", "Porsche", "Renault", "Suzuki", "Tesla", "Volvo"}
    ReadOnly hangmanPictures As New List(Of Bitmap) From
        {My.Resources.hangman0, My.Resources.hangman1, My.Resources.hangman2, My.Resources.hangman3, My.Resources.hangman4, My.Resources.hangman5, My.Resources.hangman6, My.Resources.hangman7, My.Resources.hangman8, My.Resources.hangman9, My.Resources.hangman10}
    Dim completed = 0
    Dim failed = 0
    Dim hiddenWord = ""
    Dim selectedLetters As String
    Dim livesLost = 0

    Private Sub GameForm_Aiden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonList = New List(Of Button) From
        {buttonA, buttonB, buttonC, buttonD, buttonE, buttonF, buttonG, buttonH, buttonI, buttonJ, buttonK, buttonL, buttonM, buttonN, buttonO, buttonP, buttonQ, buttonR, buttonS, buttonT, buttonU, buttonV, buttonW, buttonX, buttonY, buttonZ}
        Reset()
    End Sub

    Private Sub Reset()
        Static Generator As New Random()
        If wordList.Count <> 0 Then
            Dim index = Generator.Next(0, wordList.Count - 1)
            hiddenWord = wordList(index)
            Debug.Print(hiddenWord)
            Debug.Print(index)
        End If


        completedAmountLabel.Text() = "Completed: " + completed.ToString()
        failedWordsLabel.Text() = "Failed: " + failed.ToString()
        wordsLeftLabel.Text() = "Words Left: " + wordList.Count.ToString()

        livesLost = 0
        hiddenWordLabel.Text() = ""
        selectedLetters = ""
        hiddenWordLabel.Text() = ""

        For Each c As Char In hiddenWord
            hiddenWordLabel.Text() += "_ "
        Next

        hangmanPicture.Image = hangmanPictures(livesLost)

        For Each currentButton As Button In buttonList
            currentButton.Enabled = True
            currentButton.BackColor = Color.FromArgb(100, 200, 200, 200)
        Next
    End Sub

    Private Sub GameOver()
        wordList.Remove(hiddenWord)
        failed += 1
        MsgBox("The man has been hanged, you couldn't save him! The correct word was: " + hiddenWord, 1, "Game Lost!")
        Reset()
    End Sub

    Private Sub GameWon()
        wordList.Remove(hiddenWord)
        completed += 1
        MsgBox("You saved the man! He is free once more! The word was: " + hiddenWord, 1, "Game Won!")
        Reset()
    End Sub

    Private Sub Game_button_click(sender As Object, e As EventArgs) Handles buttonA.Click, buttonB.Click, buttonC.Click, buttonD.Click, buttonE.Click, buttonF.Click, buttonG.Click, buttonH.Click, buttonI.Click, buttonJ.Click, buttonK.Click, buttonL.Click, buttonM.Click, buttonN.Click, buttonO.Click, buttonP.Click, buttonQ.Click, buttonR.Click, buttonS.Click, buttonT.Click, buttonU.Click, buttonV.Click, buttonW.Click, buttonX.Click, buttonY.Click, buttonZ.Click
        Dim clicked As Button = DirectCast(sender, Button)
        clicked.Enabled = False
        selectedLetters += clicked.Text

        hiddenWordLabel.Text() = ""
        Dim foundLetter = False
        Dim wordFound = True
        Dim wrongLetter = True
        For Each c As Char In hiddenWord.ToUpper()
            If clicked.Text = c Then
                wrongLetter = False
            End If
        Next
        If wrongLetter Then
            livesLost += 1
            clicked.BackColor = Color.FromArgb(100, 255, 20, 20)
        Else
            clicked.BackColor = Color.FromArgb(100, 20, 255, 20)
        End If

        For Each c As Char In hiddenWord.ToUpper()
            foundLetter = False
            For Each c2 As Char In selectedLetters.ToUpper()
                If c = c2 Then
                    hiddenWordLabel.Text() += (c2 + " ")
                    foundLetter = True
                End If
            Next
            If Not foundLetter Then
                hiddenWordLabel.Text() += "_ "
                wordFound = False
            End If
            foundLetter = False
        Next

        If livesLost = 10 Then
            GameOver()
            Exit Sub
        End If

        If wordFound Then
            GameWon()
            Exit Sub
        End If

        hangmanPicture.Image = hangmanPictures(livesLost)

    End Sub

    Private Sub ResetClick(sender As Object, e As EventArgs) Handles resetBtn.Click
        If MsgBox("Are you sure you want to give up? This will count as a failed word!", 4, "Give up?") = 6 Then
            GameOver()
        End If
    End Sub

    Private Sub MenuBtn_Click(sender As Object, e As EventArgs) Handles menuBtn.Click
        If MsgBox("Do you want to reset all your progress as well?", 4, "Reset progress too?") = 6 Then
            MainMenu.Show()
            Me.Close()
        Else
            MainMenu.Show()
            Me.Hide()
        End If
    End Sub
End Class