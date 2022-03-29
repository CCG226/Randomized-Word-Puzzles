using System;
using System.IO;
namespace Word_puzzle // Note: actual namespace depends on the project name.
{
    internal class Program
    {
     
        static void Main(string[] args)
        {
            bool wordIsValid;
            var Randomizer = new Random();
            bool canGameContinue = true;
            bool foundWord = false;
            int Score = 0;
            int roundScore = 0;
            string word = " ";
            Console.WriteLine("Welcome to Random Word Search Puzzle Game!");
            Console.WriteLine();
            Console.WriteLine("Goal: Enter as many valid words as you can find in the Word Search puzzle");
            Console.WriteLine("Each word is worth 10 points per letter in the word");
            Console.WriteLine("Example: car (c + a + r) is worth 30 points");
            Console.WriteLine("one and two letter words like \"a\"  and \"is\" do NOT count!");
  
            var RandomWordPuzzleSize = Randomizer.Next(15, 36);// genereates size of word search puzzle. (between 15 - 35 characters wide/tall)
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
                wordIsValid = New_puzzle.DoesWordExist(word);//is word in dictionary and big enough?
                if(!wordIsValid)
                {
                    Console.WriteLine("Word is either too small or does NOT exist in the dctionary");
                    canGameContinue = false;//end game
                }
                else
                {
                    foundWord = New_puzzle.isWordinPuzzle(SearchPuzzle, RandomWordPuzzleSize, word);//find and remove word in puzzle
                    if(foundWord == true)
                    {
                        roundScore = 10 * word.Length;// score calculation = 10 * length of word 
                        Score += roundScore;//compound it to total score
                        Console.WriteLine("Success, you gained " + roundScore + " points");
                    }
                    else
                    {//end game, word is not in puzzle
                        Console.WriteLine("Game over, word was not found");
                        canGameContinue = false;
                    }
                }
            }
            Console.WriteLine("\n\n Total Score: " + Score);//summary
     
        }
    }
}