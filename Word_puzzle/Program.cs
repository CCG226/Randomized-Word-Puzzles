using System;
using System.IO;
namespace Word_puzzle // Note: actual namespace depends on the project name.
{
    internal class Program
    {
     
        static void Main(string[] args)
        {
            var Randomizer = new Random();
            char playAgain = 'y';
            Console.WriteLine("Welcome to Random Word Search Puzzle Game!");
            while (playAgain == 'y')
            {
                var RandomWordPuzzleSize = Randomizer.Next(15, 46);
                

                puzzle New_puzzle = new puzzle();
                char[,] SearchPuzzle = New_puzzle.Create_puzzle(RandomWordPuzzleSize);
                New_puzzle.puzzleBuilder(RandomWordPuzzleSize, SearchPuzzle);

                Console.WriteLine("Would you like to play again? Enter y to continue and n to exit.");
                playAgain = Console.ReadLine()[0];

            }
     
        }
    }
}