using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_puzzle
{
    public partial class puzzle
    {

        public char[,] Create_puzzle(int size) { char[,] wordPuzzle = new char[size, size]; return wordPuzzle; }
        public int Pull_Random_Value()
        {
            int RandomValue = new Random().Next(0, 1000000 + 1);

            return RandomValue;

        }
        public void puzzleBuilder(int size, char[,] wordPuzzle)
        {

            int GenerateValue = 0;
            letter_frequency getDict = new letter_frequency();
            letter_frequency[] LetterFrequencyChart = new letter_frequency[26];
            LetterFrequencyChart = getDict.Freq_Data();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    GenerateValue = Pull_Random_Value();
                    wordPuzzle[i, j] = getDict.FreqMapper(LetterFrequencyChart, 0, GenerateValue);

                }
            }

        }
        public void outputPuzzle(char[,] wordPuzzle, int size)
        {

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(wordPuzzle[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool DoesWordExist(string word)
        {
          
            using (StreamReader sr = new StreamReader(@"words.txt"))
            {
                string Data = sr.ReadToEnd();
                if(Data.Contains(word) && word != " " && word != "")
                {
                    
                    return true;
                }
                
                return false;
            }
        }
    }
    
}
