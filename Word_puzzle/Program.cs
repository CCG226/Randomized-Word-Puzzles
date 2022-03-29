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
            bool canGameContinue = true;
            bool foundWord = false;
            int Score = 0;
            string word = " ";
            Console.WriteLine("Welcome to Random Word Search Puzzle Game!");
            Console.WriteLine();
            Console.WriteLine("Goal: Enter as many valid words as you can find in the Word Search puzzle");
            Console.WriteLine("Each word is worth 10 points per letter in the word");
            Console.WriteLine("Example: car (c + a + r) is worth 30 points");
            
            
            holdPuzzleCount++;
            var RandomWordPuzzleSize = Randomizer.Next(15, 36);
            puzzle New_puzzle = new puzzle();
            char[,] SearchPuzzle = New_puzzle.Create_puzzle(RandomWordPuzzleSize);
              
            New_puzzle.puzzleBuilder(RandomWordPuzzleSize, SearchPuzzle);
            while (canGameContinue == true)
            {
                Console.WriteLine();
                Console.WriteLine("Current score: " + Score);


                New_puzzle.outputPuzzle(SearchPuzzle, RandomWordPuzzleSize);
                Console.WriteLine();

                Console.WriteLine("Enter a valid word");
                word = Console.ReadLine();
                wordIsValid = New_puzzle.DoesWordExist(word);
                if(!wordIsValid)
                {
                    Console.WriteLine("That word does not exist in the Dictionary.");
                    canGameContinue = false;
                }
                else
                {
                    foundWord = New_puzzle.isWordinPuzzle(SearchPuzzle, RandomWordPuzzleSize, word);
                    if(foundWord == true)
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Failure");                    }
                    }
            }
     
        }
    }
}