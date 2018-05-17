using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mastermind;

namespace Tests
{
    public class AutosolveTests
    {
        private static AutosolverConfig config = new AutosolverConfig(true, 8, 2);

        [Fact]
        public void FixedSecret()
        {
            var secret = new Code(Peg.Green, Peg.Blue, Peg.Black, Peg.White);
            var guesses = Autosolver.Autosolve(config, guess => Mastermind.Logic.EvaluateGuess(secret, guess));
            Assert.True(guesses.Count <= 5);
            Assert.Equal(secret, guesses.Last().guess);
            Assert.Equal(4, guesses.Last().score.Blacks);
            Assert.Equal(0, guesses.Last().score.Whites);
        }

        [Fact]
        public void RandomSecret()
        {
            var secret = Mastermind.Logic.GenerateSecret();
            var guesses = Autosolver.Autosolve(config, guess => Mastermind.Logic.EvaluateGuess(secret, guess));
            Assert.True(guesses.Count <= 5);
            Assert.Equal(secret, guesses.Last().guess);
            Assert.Equal(4, guesses.Last().score.Blacks);
            Assert.Equal(0, guesses.Last().score.Whites);
        }
    }
}
