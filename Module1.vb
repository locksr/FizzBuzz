Module Module1

    Dim menuscreen As New Menu
    Sub Main()
        menuscreen.ShowMenu()
    End Sub

    Public Class Player
        Public Lives As Integer
        Public Alive As Boolean
        Public playernumber As Integer

        Public Sub New(number As Integer)
            Lives = 3
            Alive = True
            playernumber = number
        End Sub

        Public Sub New()
            Lives = 3
            Alive = True
        End Sub

        Public Function GetLives()
            Return Lives
        End Function

        Public Sub LoseLife()
            Lives -= 1
            If Lives = 0 Then
                Alive = False
            End If
        End Sub

    End Class

    Public Class Game

        Private players As New List(Of Player)
        Private numbergame As Integer = 1

        Public Sub StartGame()
            Dim playerans As Integer
            Dim correctans As String
            Dim gameinput As String
            Dim currentplayer As Integer = 0

            Do

                Console.WriteLine("How many players are playing?")

                Try
                    playerans = Console.ReadLine
                Catch ex As Exception
                    playerans = 0
                End Try
                If playerans <= 1 Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("Invalid input")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.Clear()
                Else
                    Console.Clear()
                End If
            Loop Until playerans > 1
            For i = 1 To playerans
                players.Add(New Player(i))
            Next

            Dim p As Player = players(currentplayer)

            While players.Count > 1

                Console.WriteLine("Player " & (currentplayer + 1) & " Number: " & numbergame)

                gameinput = Console.ReadLine

                correctans = GetAns(numbergame)

                If gameinput.ToLower <> correctans.ToLower Then
                    p.LoseLife()
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("Incorrect. Lives left: " & p.Lives)
                    Console.ForegroundColor = ConsoleColor.White
                End If

                If p.Lives = 0 Then
                    Console.WriteLine("Player " & p.playernumber & " is out!")
                    players.RemoveAt(currentplayer)
                    If players.Count = 1 Then Exit While
                    currentplayer -= 1
                End If

                numbergame += 1
                currentplayer += 1

                If currentplayer >= players.Count Then
                    currentplayer = 0
                End If

                p = players(currentplayer)

            End While

            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Player " & players(0).playernumber & " wins!")
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("[ENTER] to continue")

            Console.ReadLine()

            Console.Clear()

            menuscreen.ShowMenu()

        End Sub

        Public Function GetAns(numbergame As Integer) As String
            If numbergame Mod 3 = 0 And numbergame Mod 5 = 0 Then
                Return "FizzBuzz"
            ElseIf numbergame Mod 3 = 0 Then
                Return "Fizz"
            ElseIf numbergame Mod 5 = 0 Then
                Return "Buzz"
            Else
                Return numbergame.ToString
            End If
        End Function

    End Class

    Public Class Menu
        Public Sub ShowMenu()
            Dim menuans As String

            Do
                Console.WriteLine("Welcome to Fizzbuzz.
[1] - Start Game
[2] - Rules
[3] - Example Game
[4] - Exit")
                menuans = Console.ReadLine

                Select Case menuans
                    Case "1"
                        Console.Clear()
                        Dim game As New Game
                        game.StartGame()
                        Exit Do
                    Case "2"
                        Console.Clear()
                        Rules()
                        Exit Do
                    Case "3"
                        Console.Clear()
                        Example()
                        Exit Do
                    Case "4"
                        Console.Clear()
                        Exitprogram()
                        Exit Do
                    Case Else
                        Console.ForegroundColor = ConsoleColor.Red
                        Console.WriteLine("Incorrect input detected. [ENTER] to continue")
                        Console.ForegroundColor = ConsoleColor.White
                        Console.ReadLine()
                        Console.Clear()
                End Select
            Loop

        End Sub

        Public Sub Rules()
            Console.WriteLine("Numbers in order will appear on the screen.
If the number is divisible by 3, the user must input 'Fizz'
If the number is divisible by 5, the user must input 'Buzz'
If the number is divisible by both, the user must input 'FizzBuzz'
Any other number, the user must input that same number.
If the user fails to do this, they will lose 1 out of their 3 lives.
The first person to lose all their lives lose.

[ENTER] to continue")
            Console.ReadLine()
            Console.Clear()
            ShowMenu()
        End Sub


        Public Sub Example()
            Console.WriteLine("Here is an example game.
Player 1 Number: 1 -> 1
Player 2 Number: 2 -> 2
Player 1 Number: 3 -> Fizz
Player 2 Number: 4 -> 4
Player 1 Number: 5 -> Buzz
Player 2 Number: 6 -> 6")

            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Incorrect. Lives left: 2")
            Console.ForegroundColor = ConsoleColor.White

            Console.WriteLine("Player 1 Number: 7 -> 7
Player 2 Number: 8 -> Fizz")

            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Incorrect. Lives left: 1")
            Console.ForegroundColor = ConsoleColor.White

            Console.WriteLine("Player 1 Number: 9 -> Fizz
Player 2 Number: 10 -> 10")

            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Incorrect. Lives left: 0")
            Console.ForegroundColor = ConsoleColor.White

            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Player 1 wins!")
            Console.ForegroundColor = ConsoleColor.White

            Console.WriteLine("[ENTER] to continue")
            Console.ReadLine()

            Console.Clear()

            ShowMenu()

        End Sub

        Public Sub Exitprogram()
            Console.WriteLine("Thanks for using this program")
        End Sub

    End Class

End Module

