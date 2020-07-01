using System;
using System.Collections.Immutable;
using System.Linq;

namespace Mastermind
{
    public static class Logic
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

        private static int CountOccurrencesOfPeg(Peg peg, Code code)
        {
            return (
                (peg == code.Pegs[0] ? 1 : 0) +
                (peg == code.Pegs[1] ? 1 : 0) +
                (peg == code.Pegs[2] ? 1 : 0) +
                (peg == code.Pegs[3] ? 1 : 0)
            );
        }

        private static int CountMatchingPegsByPosition(Code code1, Code code2)
        {
            return (
                (code1.Pegs[0] == code2.Pegs[0] ? 1 : 0) +
                (code1.Pegs[1] == code2.Pegs[1] ? 1 : 0) +
                (code1.Pegs[2] == code2.Pegs[2] ? 1 : 0) +
                (code1.Pegs[3] == code2.Pegs[3] ? 1 : 0)
            );
        }

        public static Score EvaluateScore(Code code1, Code code2)
        {
            var sumOfMinOccurrences = 0;
            for (var index = 0; index < AllPegs.Count; index++) {
                var peg = AllPegs[index];
                var numOccurrences1 = CountOccurrencesOfPeg(peg, code1);
                var numOccurrences2 = CountOccurrencesOfPeg(peg, code2);
                var minOccurrences = Math.Min(numOccurrences1, numOccurrences2);
                sumOfMinOccurrences += minOccurrences;
            }
            var blacks = CountMatchingPegsByPosition(code1, code2);
            var whites = sumOfMinOccurrences - blacks;
            return new Score(blacks, whites);
        }
    }
}
