Imports System.Text.RegularExpressions
Public Class GameForm_Aiden
    Dim buttonList
    ReadOnly wordList As New List(Of String) From
        {"Toyata", "Mitsubishi", "Hyundai", "Mercedes", "Subaru", "Nissan", "Volkswagen", "Audi", "Bently", "Chevrolet", "Ferrari", "Lamborghini", "Fiat", "Ford", "Honda", "Kia", "Jeep", "Lexus", "Mazda", "Porsche", "Renault", "Suzuki", "Tesla", "Volvo"}
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

    Private Sub Randomise_Click(sender As Object, e As EventArgs) Handles Randomise.Click
        Reset()
    End Sub

    Private Sub Reset()
        Dim index = (wordList.Count - 1) * Rnd()
        hiddenWord = wordList(index)
        Debug.Print(hiddenWord)
        Debug.Print(index)

        completedAmountLabel.Text() = "Completed: " + completed.ToString()
        failedWordsLabel.Text() = "Failed: " + failed.ToString()
        wordsLeftLabel.Text() = "Words Left: " + wordList.Count.ToString()

        hiddenWordLabel.Text() = ""
        selectedLetters = ""
        hiddenWordLabel.Text() = ""
        For Each c As Char In hiddenWord
            hiddenWordLabel.Text() += "_ "
        Next

        For Each currentButton As Button In buttonList
            currentButton.Enabled = True
        Next
    End Sub

    Private Sub gameOver()

    End Sub

    Private Sub Game_button_click(sender As Object, e As EventArgs) Handles buttonA.Click, buttonB.Click, buttonC.Click, buttonD.Click, buttonE.Click, buttonF.Click, buttonG.Click, buttonH.Click, buttonI.Click, buttonJ.Click, buttonK.Click, buttonL.Click, buttonM.Click, buttonN.Click, buttonO.Click, buttonP.Click, buttonQ.Click, buttonR.Click, buttonS.Click, buttonT.Click, buttonU.Click, buttonV.Click, buttonW.Click, buttonX.Click, buttonY.Click, buttonZ.Click
        Dim clicked As Button = DirectCast(sender, Button)
        clicked.Enabled = False
        selectedLetters += clicked.Text

        hiddenWordLabel.Text() = ""
        Dim foundLetter = False
        Dim wordFound = True
        livesLost = 0

        For Each c As Char In selectedLetters.ToUpper()
            For Each c2 As Char In hiddenWord.ToString().ToUpper().ToCharArray().Distinct().ToArray()
                If c = c2 Then
                    livesLost -= 1
                End If
            Next
            livesLost += 1
        Next

        For Each c As Char In hiddenWord.ToUpper()
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
            wordList.Remove(hiddenWord)
            failed += 1
            Reset()
            Exit Sub
        End If

        If wordFound Then
            wordList.Remove(hiddenWord)
            completed += 1
            Reset()
            Debug.Print("done done donew oo")
            Exit Sub
        End If

        hangmanPicture.Image = hangmanPictures(livesLost)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles wordsLeftLabel.Click

    End Sub
End Class