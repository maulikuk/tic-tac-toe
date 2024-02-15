using System.Text.RegularExpressions;
using tic_tac_toe;


string playAgain;
TicTacToe ticTacToe = new TicTacToe();
do
{
    // See https://aka.ms/new-console-template for more information
    Console.WriteLine("Welcome to tic-tac-toe");
    Console.WriteLine("Enter the values in Row and Column sequence. Separate both value with a space. Min value 1 and Max value 3.");
    Console.WriteLine("i.e. 1 2, This means first row and second position.");
    Console.WriteLine("i.e. 3 3, This means third row and third position.");
    Console.WriteLine("");

    ticTacToe.ResetInputs();
    ticTacToe.PrintOutput();
    bool isMatchTie = false;
    for (int i = 0; i < 9; i++)
    {
        ticTacToe.GetUserInput(i);
        isMatchTie = ticTacToe.VerifyPattern();
        if (isMatchTie)
        {
            break;
        }
    }

    if (!isMatchTie)
    {
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("*********** The game is tied *********");
        Console.WriteLine("--------------------------------------");
    }

    Console.WriteLine("");
    Console.WriteLine("Do you want to Play Again: Y/N");
    playAgain = Console.ReadLine();
} while (!string.IsNullOrEmpty(playAgain) && playAgain.Equals("y", StringComparison.CurrentCultureIgnoreCase));



