using System;
using System.Collections.Immutable;
using System.Linq;

namespace Lib
{
    public static class Mastermind
    {
        public static Code GenerateSecret()
        {
            return new Code(Peg.Red, Peg.Red, Peg.Green, Peg.Green);
        }

        public static IImmutableList<Peg> AllPegs =
            Enum.GetValues(typeof(Peg))
                .Cast<Peg>()
                .ToImmutableList();

        public static IImmutableList<Score> AllScores =
        (
            from blacks in Enumerable.Range(0, 5)
            from whites in Enumerable.Range(0, 5)
            where blacks + whites <= 4
            where !(blacks == 3 && whites == 1)
            select new Score(blacks, whites)
         ).ToImmutableList();

        public static IImmutableList<Code> AllCodes =
        (
            from p0 in AllPegs
            from p1 in AllPegs
            from p2 in AllPegs
            from p3 in AllPegs
            select new Code(p0, p1, p2, p3)
         ).ToImmutableList();

        public static Score EvaluateGuess(Code secret, Code guess)
        {
            var sumOfMins = AllPegs
                .Select(peg =>
                    Math.Min(
                        secret.Pegs.Count(p => p == peg),
                        guess.Pegs.Count(p => p == peg)))
                .Sum();
            var blacks = secret.Pegs.Where((p, i) => p == guess.Pegs[i]).Count();
            var whites = sumOfMins - blacks;
            return new Score(blacks, whites);
        }
    }
}
