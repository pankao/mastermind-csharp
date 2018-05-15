using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class Logic
    {
        public static Code GenerateSecret()
        {
            return new Code(Peg.Red, Peg.Red, Peg.Green, Peg.Green);
        }

        private static IReadOnlyList<Peg> AllPegs = 
            Enum.GetValues(typeof(Peg))
                .Cast<Peg>()
                .ToList();

        public static Score EvaluateGuess(Code secret, Code guess)
        {
            var secretPegs = secret.Pegs.ToList();
            var guessPegs = guess.Pegs.ToList();
            var sumOfMins = AllPegs
                .Select(peg =>
                    Math.Min(
                        secretPegs.Count(p => p == peg),
                        guessPegs.Count(p => p == peg)))
                .Sum();
            var blacks = secretPegs.Where((p, i) => p == guessPegs[i]).Count();
            var whites = sumOfMins - blacks;
            return new Score(blacks, whites);
        }
    }
}
