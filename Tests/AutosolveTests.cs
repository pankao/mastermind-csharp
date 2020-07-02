using System;
using System.Linq;
using Xunit;
using Mastermind;

namespace Tests
{
    public class AutosolveTests
    {
        [Fact]
        public void FixedSecret()
        {
            var secret = new Code(Peg.Green, Peg.Blue, Peg.Black, Peg.White);
            Func<Code, Score> attempt = guess => Logic.EvaluateScore(secret, guess);
            var guesses = Autosolver.Autosolve(attempt);
            Assert.True(guesses.Count <= 5);
            Assert.Equal(secret, guesses.Last().guess);
            Assert.Equal(4, guesses.Last().score.Blacks);
            Assert.Equal(0, guesses.Last().score.Whites);
        }

        [Fact]
        public void RandomSecret()
        {
            var secret = Mastermind.Logic.GenerateSecret();
            Func<Code, Score> attempt = guess => Logic.EvaluateScore(secret, guess);
            var guesses = Autosolver.Autosolve(attempt);
            Assert.True(guesses.Count <= 5);
            Assert.Equal(secret, guesses.Last().guess);
            Assert.Equal(4, guesses.Last().score.Blacks);
            Assert.Equal(0, guesses.Last().score.Whites);
        }
    }
}
