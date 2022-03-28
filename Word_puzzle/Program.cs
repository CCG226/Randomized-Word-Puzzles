using System;
using System.IO;
namespace Word_puzzle // Note: actual namespace depends on the project name.
{
    internal class Program
    {
     
        static void Main(string[] args)
        {
            int holdPuzzleCount = 0;
            var Randomizer = new Random();
            char playAgain = 'y';
            Console.WriteLine("Welcome to Random Word Search Puzzle Game!");
            Console.WriteLine("Play by finding words in the word search puzzle");
           
            
            while (playAgain == 'y')
            {
                holdPuzzleCount++;
                var RandomWordPuzzleSize = Randomizer.Next(15, 36);
                puzzle New_puzzle = new puzzle();
                char[,] SearchPuzzle = New_puzzle.Create_puzzle(RandomWordPuzzleSize);
              
                New_puzzle.puzzleBuilder(RandomWordPuzzleSize, SearchPuzzle);

                Console.WriteLine();
                Console.WriteLine("Puzzle: " + holdPuzzleCount);
                New_puzzle.outputPuzzle(SearchPuzzle, RandomWordPuzzleSize);

                Console.WriteLine("Would you like to play again? Enter y to continue and n to exit.");
                playAgain = Console.ReadLine()[0];

            }
     
        }
    }
}