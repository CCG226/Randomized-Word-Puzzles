using System;
using System.IO;
namespace Word_puzzle // Note: actual namespace depends on the project name.
{
    internal class Program
    {
     
        static void Main(string[] args)
        {
            bool wordIsValid;
            int holdPuzzleCount = 0;
            var Randomizer = new Random();
            char playAgain = 'y';
            int Score = 0;
            string word = " ";
            Console.WriteLine("Welcome to Random Word Search Puzzle Game!");
            Console.WriteLine();
            Console.WriteLine("Goal: Enter as many valid words as you can find in each puzzzle");
            Console.WriteLine("Each word is worth a 100 points");
            
            
            while (playAgain == 'y')
            {
                holdPuzzleCount++;
                var RandomWordPuzzleSize = Randomizer.Next(15, 36);
                puzzle New_puzzle = new puzzle();
                char[,] SearchPuzzle = New_puzzle.Create_puzzle(RandomWordPuzzleSize);
              
                New_puzzle.puzzleBuilder(RandomWordPuzzleSize, SearchPuzzle);

                Console.WriteLine();
                Console.WriteLine("Current score:" + Score);
                Console.WriteLine("Puzzle: " + holdPuzzleCount);
                New_puzzle.outputPuzzle(SearchPuzzle, RandomWordPuzzleSize);
                Console.WriteLine();
                Console.WriteLine("Enter a valid word");
                word = Console.ReadLine();
                wordIsValid = New_puzzle.DoesWordExist(word);

                Console.WriteLine("Would you like to play again? Enter y to continue and n to exit.");
                playAgain = Console.ReadLine()[0];

            }
     
        }
    }
}