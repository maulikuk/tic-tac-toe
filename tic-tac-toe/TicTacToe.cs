using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class TicTacToe
    {
        public string[,] Inputs { get; set; }

        public TicTacToe()
        {
            Inputs = new string[3, 3];
        }

        public void GetUserInput(int i)
        {
            string userInput;
            string[]? values = null;
            bool validateValue = false;
            do
            {
                Console.WriteLine("");
                if (i == 0 || i % 2 == 0)
                    Console.WriteLine("Player 1 enter your position:");
                else
                    Console.WriteLine("Player 2 enter your position:");
                userInput = Console.ReadLine();
                if (VerifyInputs(userInput))
                {
                    values = userInput.Split(' ');
                    if (Inputs[Convert.ToInt32(values[0]) - 1, Convert.ToInt32(values[1]) - 1] != "-")
                    {
                        Console.WriteLine("Position already filled. Please select another position.");
                        AvailablePositions();
                    }
                    else
                        validateValue = true;
                }
            } while (!validateValue);

            if (values != null)
                if (i == 0 || i % 2 == 0)
                    Inputs[Convert.ToInt32(values[0]) - 1, Convert.ToInt32(values[1]) - 1] = "X";
                else
                    Inputs[Convert.ToInt32(values[0]) - 1, Convert.ToInt32(values[1]) - 1] = "0";

            PrintOutput();
        }

        public void AvailablePositions()
        {
            string positions = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Inputs[i, j] == "-")
                        positions += (i + 1) + " " + (j + 1) + ", ";
                }
            }
            Console.WriteLine("Available positions are: " + positions.Trim().Trim(','));
        }

        public bool VerifyInputs(string userInput)
        {
            if (!Regex.Match(userInput, "[1-3] [1-3]", RegexOptions.IgnoreCase).Success)
            {
                Console.WriteLine("Please enter valid input. i.e. 1 2. Sequence of row and column with space and max value is 3.");
                return false;
            }
            return true;
        }

        public void ResetInputs()
        {
            for (int i = 0; i < 3; i++)
            {
                Inputs[i, 0] = "-";
                Inputs[i, 1] = "-";
                Inputs[i, 2] = "-";
            }
        }

        public void PrintOutput()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Inputs[i, 0] + " " + Inputs[i, 1] + " " + Inputs[i, 2]);
            }
        }

        public bool VerifyPattern()
        {
            string value = GetTheMetchValue();
            if (string.IsNullOrEmpty(value))
                return false;

            int index;
            if (value == "X")
                index = 1;
            else
                index = 2;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("********  Player " + index + " win the game ******");
            Console.WriteLine("--------------------------------------");
            return true;
        }

        public string GetTheMetchValue()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Inputs[i, 0] != "-" && Inputs[i, 1] != "-" && Inputs[i, 2] != "-")
                    if (Inputs[i, 0] == Inputs[i, 1] && Inputs[i, 1] == Inputs[i, 2])
                        return Inputs[i, 0];
                if (Inputs[0, i] != "-" && Inputs[1, i] != "-" && Inputs[2, i] != "-")
                    if (Inputs[0, i] == Inputs[1, i] && Inputs[1, i] == Inputs[2, i])
                        return Inputs[0, i];
            }
            if (Inputs[0, 0] != "-" && Inputs[1, 1] != "-" && Inputs[2, 2] != "-")
                if (Inputs[0, 0] == Inputs[1, 1] && Inputs[1, 1] == Inputs[2, 2])
                    return Inputs[0, 0];
            if (Inputs[2, 0] != "-" && Inputs[1, 1] != "-" && Inputs[0, 2] != "-")
                if (Inputs[2, 0] == Inputs[1, 1] && Inputs[1, 1] == Inputs[0, 2])
                    return Inputs[2, 0];

            return string.Empty;
        }
    }
}
