using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Lib;

namespace Tests
{
    public class AutosolveTests
    {
        [Fact]
        public void FixedSecret()
        {
            var secret = new Code(Peg.Green, Peg.Blue, Peg.Black, Peg.White);
            var config = new AutosolverConfig(true, 8, 2);
            var guesses = new List<(Code guess, Score score)>();
            Autosolver.Autosolve(config, guess =>
            {
                var score = Lib.Mastermind.EvaluateGuess(secret, guess);
                guesses.Add((guess, score));
                return score;
            });
            Assert.True(guesses.Count <= 5);
            Assert.Equal(secret, guesses.Last().guess);
            Assert.Equal(4, guesses.Last().score.Blacks);
            Assert.Equal(0, guesses.Last().score.Whites);
        }

        [Fact]
        public void RandomSecret()
        {
            var secret = Mastermind.GenerateSecret();
            var config = new AutosolverConfig(true, 8, 2);
            var guesses = new List<(Code guess, Score score)>();
            Autosolver.Autosolve(config, guess =>
            {
                var score = Lib.Mastermind.EvaluateGuess(secret, guess);
                guesses.Add((guess, score));
                return score;
            });
            Assert.True(guesses.Count <= 5);
            Assert.Equal(secret, guesses.Last().guess);
            Assert.Equal(4, guesses.Last().score.Blacks);
            Assert.Equal(0, guesses.Last().score.Whites);
        }
    }
}
