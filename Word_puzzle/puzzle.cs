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
            int RandomValue = new Random().Next(0, 1000000 + 1); //pulls random value from 0 - 1,000,000

            return RandomValue;

        }
        public void puzzleBuilder(int size, char[,] wordPuzzle)
        {

            int GenerateValue = 0;
            letter_frequency getDict = new letter_frequency();//used to call methods
            letter_frequency[] LetterFrequencyChart = new letter_frequency[26];//will holds letters and their frequncy ranges 
            LetterFrequencyChart = getDict.Freq_Data();//build data range 
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    GenerateValue = Pull_Random_Value();//get a random value 
                    wordPuzzle[i, j] = getDict.FreqMapper(LetterFrequencyChart, 0, GenerateValue);//pull a letter based on the random value and the letters frequency range

                }
            }

        }
        public void outputPuzzle(char[,] wordPuzzle, int size)
        {

            for (int i = 0; i < size; i++)//prints puzzle
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
          
            using (StreamReader sr = new StreamReader(@"words.txt"))//open and read from words.txt (contains all dictionary words)
            {
                string Data = sr.ReadToEnd();//holds text file content
                if(Data.Contains(word) && word.Length > 2 )//makes sure word is greater than and exists in the file 
                {
                    
                    return true;//if so return true
                }
                
                return false;
            }
        }
    }
    
}
