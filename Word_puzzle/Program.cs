using System;
using System.IO;
namespace Word_puzzle // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        enum characters { a,};
        static void Main(string[] args)
        {
            var Randomizer = new Random();
            char playAgain = 'y';
            Console.WriteLine("Welcome to Random Word Search Puzzle Game");
            while (playAgain == 'y')
            {
                var RandomWordPuzzleSize = Randomizer.Next(5, 21);

                puzzle puzzle = new puzzle();
                char[,] SearchPuzzle = puzzle.puzzle_Builder(RandomWordPuzzleSize,RandomWordPuzzleSize);
            }
     
        }
    }
}