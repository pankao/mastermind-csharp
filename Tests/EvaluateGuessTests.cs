using System;
using Xunit;
using Lib;

namespace Tests
{
    public class EvaluateGuessTests
    {
        [Fact]
        public void NoOverlap()
        {
            var secret = new Code(Peg.Red, Peg.Green, Peg.Blue, Peg.Yellow);
            var guess = new Code(Peg.Black, Peg.Black, Peg.White, Peg.White);
            var score = Logic.EvaluateGuess(secret, guess);
            Assert.Equal(0, score.Blacks);
            Assert.Equal(0, score.Whites);
        }

        [Fact]
        public void ExactMatch()
        {
            var secret = new Code(Peg.Red, Peg.Green, Peg.Blue, Peg.Yellow);
            var guess = new Code(Peg.Red, Peg.Green, Peg.Blue, Peg.Yellow);
            var score = Logic.EvaluateGuess(secret, guess);
            Assert.Equal(4, score.Blacks);
            Assert.Equal(0, score.Whites);
        }

        [Fact]
        public void AllColoursCorrectButWrongPositions()
        {
            var secret = new Code(Peg.Red, Peg.Green, Peg.Blue, Peg.Yellow);
            var guess = new Code(Peg.Yellow, Peg.Blue, Peg.Green, Peg.Red);
            var score = Logic.EvaluateGuess(secret, guess);
            Assert.Equal(0, score.Blacks);
            Assert.Equal(4, score.Whites);
        }
    }
}
