using System;
using System.Collections.Immutable;
using System.Linq;

namespace Mastermind
{
    public static class Autosolver
    {
        public static IImmutableList<(Code guess, Score score)> Autosolve(
            Func<Code, Score> attempt)
        {
            return RecursiveSolveStep(
                attempt,
                Logic.AllCodes,
                ImmutableList<(Code, Score)>.Empty);
        }

        private static Code InitialGuess = new Code(Peg.Red, Peg.Red, Peg.Green, Peg.Green);

        private static IImmutableList<(Code, Score)> RecursiveSolveStep(
            Func<Code, Score> attempt,
            IImmutableList<Code> untried,
            IImmutableList<(Code, Score)> history)
        {
            var guess =
                untried.Count == Logic.AllCodes.Count ? InitialGuess :
                untried.Count == 1 ? untried.First() : CalculateNewGuess(untried);

            var score = attempt(guess);

            var newHistory = history.Add((guess, score));

            if (score.Blacks == 4)
            {
                return newHistory;
            }

            var newUntried = untried
                .Where(code => Logic.EvaluateScore(code, guess).Equals(score))
                .ToImmutableList();

            return RecursiveSolveStep(attempt, newUntried, newHistory);
        }

        private static Code CalculateNewGuess(IImmutableList<Code> untried)
        {
            var best = Logic.AllCodes.Aggregate(
                Tuple.Create(int.MaxValue, InitialGuess),
                (currentBest, allCode) =>
            {
                var maxCount = Logic.AllScores.Aggregate(
                    0,
                    (currentMax, score) =>
                {
                    var count = untried.Count(code => Logic.EvaluateScore(allCode, code).Equals(score));
                    return Math.Max(currentMax, count);
                });
                return (maxCount < currentBest.Item1) ? Tuple.Create(maxCount, allCode) : currentBest;
            });
            return best.Item2;
        }
    }
}
