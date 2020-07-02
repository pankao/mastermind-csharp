using System;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = Logic.RandomSecret();
            Console.WriteLine($"secret: {secret}");

            Score attempt(Code guess)
            {
                var score = Logic.EvaluateScore(secret, guess);
                Console.WriteLine($"guess: {guess} score: {score}");
                return score;
            };

            var stopwatch = Stopwatch.StartNew();
            var history = Autosolver.Autosolve(attempt).ToImmutableList();
            stopwatch.Stop();

            Console.WriteLine($"Number of guesses: {history.Count}");
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
