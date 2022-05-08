Public Class GameForm_Devansh
    Dim buttonList
    Dim wordList As New List(Of String) From
        {}
    ReadOnly hangmanPictures As New List(Of Bitmap) From
        {My.Resources.hangman0, My.Resources.hangman1, My.Resources.hangman2, My.Resources.hangman3, My.Resources.hangman4, My.Resources.hangman5, My.Resources.hangman6, My.Resources.hangman7, My.Resources.hangman8, My.Resources.hangman9, My.Resources.hangman10}
    Dim completed = 0
    Dim failed = 0
    Dim hiddenWord = ""
    Dim selectedLetters As String
    Dim livesLost = 0

    Private Sub GameForm_Devansh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonList = New List(Of Button) From
        {buttonA, buttonB, buttonC, buttonD, buttonE, buttonF, buttonG, buttonH, buttonI, buttonJ, buttonK, buttonL, buttonM, buttonN, buttonO, buttonP, buttonQ, buttonR, buttonS, buttonT, buttonU, buttonV, buttonW, buttonX, buttonY, buttonZ}
        Reset()
    End Sub
    Private Sub Reset()

    End Sub
End Class