using NUnit.Framework;
using tic_tac_toe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe.Tests
{
    [TestFixture()]
    public class TicTacToeTests
    {
        [Test()]
        public void GetUserInputTest()
        {
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.ResetInputs();

            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1 1");
            Console.SetIn(input);
            ticTacToe.GetUserInput(0);
            Assert.That(string.Format("{0}Player 1 enter your position:{0}X - -{0}- - -{0}- - -{0}", Environment.NewLine), Is.EqualTo(output.ToString()));

            var data = String.Join(Environment.NewLine, new[] { "1 1", "1 2" });
            Console.SetIn(new StringReader(data));
            ticTacToe.GetUserInput(1);
            Assert.That(string.Format("{0}Player 1 enter your position:{0}X - -{0}- - -{0}- - -{0}{0}Player 2 enter your position:{0}Position already filled. Please select another position.{0}Available positions are: 1 2, 1 3, 2 1, 2 2, 2 3, 3 1, 3 2, 3 3{0}{0}Player 2 enter your position:{0}X 0 -{0}- - -{0}- - -{0}", Environment.NewLine), Is.EqualTo(output.ToString()));
        }
    }
}