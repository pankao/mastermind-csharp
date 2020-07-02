using System;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = new Code(Peg.Green, Peg.Blue, Peg.Black, Peg.White);
            Console.WriteLine($"secret: {secret}");

            var stopwatch = Stopwatch.StartNew();
            Func<Code, Score> attempt = guess => Logic.EvaluateScore(secret, guess);
            var history = Autosolver.Autosolve(attempt).ToImmutableList();
            stopwatch.Stop();

            Console.WriteLine($"Number of guesses: {history.Count}");
            history.ForEach(tuple => Console.WriteLine($"guess: {tuple.guess} score: {tuple.score}"));
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
