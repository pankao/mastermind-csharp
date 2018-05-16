using System;
using System.Collections.Generic;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = new Code(Peg.Green, Peg.Blue, Peg.Black, Peg.White);
            var config = new AutosolverConfig(true, 8, 2);
            var guesses = new List<(Code guess, Score score)>();
            Console.WriteLine($"secret: {secret}");
            Autosolver.Autosolve(config, guess =>
            {
                var score = Logic.EvaluateGuess(secret, guess);
                guesses.Add((guess, score));
                return score;
            });
            Console.WriteLine($"Number of guesses: {guesses.Count}");
            guesses.ForEach(tuple => Console.WriteLine($"guess: {tuple.guess} score: {tuple.score}"));
        }
    }
}
