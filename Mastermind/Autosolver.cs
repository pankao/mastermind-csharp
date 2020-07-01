using System;
using System.Collections.Immutable;
using System.Linq;

namespace Mastermind
{
    public class AutosolverConfig
    {
        public AutosolverConfig(
            bool enableParallelism,
            int numThreads,
            int setSizeThreshold)
        {
            EnableParallelism = enableParallelism;
            NumThreads = numThreads;
            SetSizeThreshold = setSizeThreshold;
        }

        public bool EnableParallelism { get; }
        public int NumThreads { get; }
        public int SetSizeThreshold { get; }
    }

    public static class Autosolver
    {
        public static IImmutableList<(Code guess, Score score)> Autosolve(
            AutosolverConfig config,
            Func<Code, Score> attempt)
        {
            return Autosolve(
                config,
                attempt,
                Logic.AllCodes,
                ImmutableList<(Code, Score)>.Empty);
        }

        private static Code InitialGuess = new Code(Peg.Red, Peg.Red, Peg.Green, Peg.Green);

        private static IImmutableList<(Code, Score)> Autosolve(
            AutosolverConfig config,
            Func<Code, Score> attempt,
            IImmutableList<Code> set,
            IImmutableList<(Code, Score)> guesses)
        {
            var guess =
                set.Count == Logic.AllCodes.Count ? InitialGuess :
                set.Count == 1 ? set.First() : CalculateNewGuess(config, set);

            var score = attempt(guess);

            var updatedGuesses = guesses.Add((guess, score));

            if (score.Blacks == 4)
            {
                return updatedGuesses;
            }

            var updatedSet = set
                .Where(code => Logic.EvaluateScore(code, guess).Equals(score))
                .ToImmutableList();

            return Autosolve(config, attempt, updatedSet, updatedGuesses);
        }

        private static Code CalculateNewGuess(
            AutosolverConfig config,
            IImmutableList<Code> set)
        {
            var best = Logic.AllCodes.Aggregate(
                Tuple.Create(int.MaxValue, InitialGuess),
                (currentBest, unusedCode) =>
            {
                var max = Logic.AllScores.Aggregate(
                    0,
                    (currentMax, score) =>
                {
                    var thisMax = set.Count(code => Logic.EvaluateScore(unusedCode, code).Equals(score));
                    return Math.Max(currentMax, thisMax);
                });
                return (max < currentBest.Item1) ? Tuple.Create(max, unusedCode) : currentBest;
            });
            return best.Item2;
        }
    }
}
