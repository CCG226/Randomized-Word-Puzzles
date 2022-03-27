using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_puzzle
{
    public class puzzle
    {

      public char[,] Create_puzzle(int size){ char[,] wordPuzzle = new char[size, size]; return wordPuzzle; }

     public void puzzleBuilder(int size, char[,] wordPuzzle)
        {
            letter_frequency getDict = new letter_frequency();
            letter_frequency[] LetterFrequencyChart = getDict.Freq_Map();
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine(LetterFrequencyChart[i].Letter);
            }
        }
   
    }
}
