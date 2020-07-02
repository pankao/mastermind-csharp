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
            Score attempt(Code guess) => Logic.EvaluateScore(secret, guess);
            var history = Autosolver.Autosolve(attempt);
            Assert.True(history.Count <= 5);
            Assert.Equal(secret, history.Last().guess);
            Assert.Equal(new Score(4, 0), history.Last().score);
        }

        [Fact]
        public void RandomSecret()
        {
            var secret = Logic.RandomSecret();
            Score attempt(Code guess) => Logic.EvaluateScore(secret, guess);
            var history = Autosolver.Autosolve(attempt);
            Assert.True(history.Count <= 5);
            Assert.Equal(secret, history.Last().guess);
            Assert.Equal(new Score(4, 0), history.Last().score);
        }
    }
}
