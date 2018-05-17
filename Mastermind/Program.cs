using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new AutosolverConfig(true, 8, 2);
            
            var secret = new Code(Peg.Green, Peg.Blue, Peg.Black, Peg.White);
            Console.WriteLine($"secret: {secret}");

            var stopwatch = Stopwatch.StartNew();
            var guesses = Autosolver.Autosolve(config, guess => Logic.EvaluateGuess(secret, guess)).ToList();
            stopwatch.Stop();

            Console.WriteLine($"Number of guesses: {guesses.Count}");
            guesses.ForEach(tuple => Console.WriteLine($"guess: {tuple.guess} score: {tuple.score}"));
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
