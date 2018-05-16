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
            var score = Mastermind.EvaluateGuess(secret, guess);
            Assert.Equal(0, score.Blacks);
            Assert.Equal(0, score.Whites);
        }

        [Fact]
        public void ExactMatch()
        {
            var secret = new Code(Peg.Red, Peg.Green, Peg.Blue, Peg.Yellow);
            var guess = new Code(Peg.Red, Peg.Green, Peg.Blue, Peg.Yellow);
            var score = Mastermind.EvaluateGuess(secret, guess);
            Assert.Equal(4, score.Blacks);
            Assert.Equal(0, score.Whites);
        }

        [Fact]
        public void AllColoursCorrectButWrongPositions()
        {
            var secret = new Code(Peg.Red, Peg.Green, Peg.Blue, Peg.Yellow);
            var guess = new Code(Peg.Yellow, Peg.Blue, Peg.Green, Peg.Red);
            var score = Mastermind.EvaluateGuess(secret, guess);
            Assert.Equal(0, score.Blacks);
            Assert.Equal(4, score.Whites);
        }

        [Fact]
        public void Scenario1()
        {
            var secret = new Code(Peg.Green, Peg.Green, Peg.Blue, Peg.Blue);
            var guess = new Code(Peg.Blue, Peg.Blue, Peg.Green, Peg.Green);
            var score = Mastermind.EvaluateGuess(secret, guess);
            Assert.Equal(0, score.Blacks);
            Assert.Equal(4, score.Whites);
        }

        [Fact]
        public void Scenario2()
        {
            var secret = new Code(Peg.Green, Peg.Green, Peg.Blue, Peg.Blue);
            var guess = new Code(Peg.Blue, Peg.Blue, Peg.Green, Peg.Yellow);
            var score = Mastermind.EvaluateGuess(secret, guess);
            Assert.Equal(0, score.Blacks);
            Assert.Equal(3, score.Whites);
        }

        [Fact]
        public void Scenario3()
        {
            var secret = new Code(Peg.Green, Peg.Green, Peg.Blue, Peg.Yellow);
            var guess = new Code(Peg.Blue, Peg.Blue, Peg.Green, Peg.Green);
            var score = Mastermind.EvaluateGuess(secret, guess);
            Assert.Equal(0, score.Blacks);
            Assert.Equal(3, score.Whites);
        }

        [Fact]
        public void Scenario4()
        {
            var secret = new Code(Peg.Blue, Peg.Yellow, Peg.White, Peg.White);
            var guess = new Code(Peg.Blue, Peg.White, Peg.Yellow, Peg.Yellow);
            var score = Mastermind.EvaluateGuess(secret, guess);
            Assert.Equal(1, score.Blacks);
            Assert.Equal(2, score.Whites);
        }
    }
}
