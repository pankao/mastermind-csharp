using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class Mastermind
    {
        public static Code GenerateSecret()
        {
            return new Code(Peg.Red, Peg.Red, Peg.Green, Peg.Green);
        }

        public static IReadOnlyList<Peg> AllPegs =
            Enum.GetValues(typeof(Peg))
                .Cast<Peg>()
                .ToList();

        public static IReadOnlyList<Score> AllScores =
        (
            from blacks in Enumerable.Range(0, 5)
            from whites in Enumerable.Range(0, 5)
            where blacks + whites <= 4
            where !(blacks == 3 && whites == 1)
            select new Score(blacks, whites)
         ).ToList();

        public static IReadOnlyList<Code> AllCodes =
        (
            from p0 in AllPegs
            from p1 in AllPegs
            from p2 in AllPegs
            from p3 in AllPegs
            select new Code(p0, p1, p2, p3)
         ).ToList();

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
