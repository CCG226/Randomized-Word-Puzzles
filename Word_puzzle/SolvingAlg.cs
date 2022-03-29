using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_puzzle
{
    public partial class puzzle
    {
        public bool isWordinPuzzle(char[,] Wpuzzle, int size, string word)
        {
            char head = word[0];  
            int wordLength = word.Length;

            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (Wpuzzle[i, j] == head)
                    {
                        if(word.Length == 1)
                        {
                            Wpuzzle[i, j] = ' ';
                            return true;
                        }

                        if (Alg(0,1, word, wordLength, Wpuzzle, i, j)) { return true;  }//south
                        if (Alg(0, -1, word, wordLength, Wpuzzle, i, j)) { return true; }//north
                        if (Alg(1, 0, word, wordLength, Wpuzzle, i, j)) { return true; }//east
                        if (Alg(-1, 0, word, wordLength, Wpuzzle, i, j)) { return true; }//west
                        if (Alg(1, 1, word, wordLength, Wpuzzle, i, j)) { return true; }//southeast
                        if (Alg(1, -1, word, wordLength, Wpuzzle, i, j)) { return true; }//southwest
                        if (Alg(-1, 1, word, wordLength, Wpuzzle, i, j)) { return true; }//northeast
                        if (Alg(-1, -1, word, wordLength, Wpuzzle, i, j)) { return true; }//northwest
              

                    }
                   
                }
            }
          return false;
        }

         
        private bool Alg(int Row_Inc, int Col_Inc,string word, int size, char[,] Wpuzzle, int startRow, int startCol)
        {
            
            int[,] DeleteCoords = new int[size, 2];
            DeleteCoords[0, 0] = startRow;
            DeleteCoords[0, 1] = startCol;
            int curr = 1;
            while (Wpuzzle[startRow + Row_Inc, startCol + Col_Inc] == word[curr])
            {
                DeleteCoords[curr, 0] = startRow + Row_Inc;
                DeleteCoords[curr, 1] = startCol + Col_Inc;
                if (!OutofBounds(startRow, Row_Inc, startCol, Col_Inc, size))
                {
                    return false;
                }
                if(curr == word.Length - 1)
                {
                    RemoveWord(Wpuzzle, startRow, startCol, word.Length, DeleteCoords);
                    return true;
                }
                curr++;

                if (Row_Inc == 0) { Row_Inc = 0; }
                if(Row_Inc > 0){Row_Inc++; }
                if(Row_Inc < 0){ Row_Inc--; }
                if (Col_Inc == 0) { Col_Inc = 0; }
                if(Col_Inc > 0) { Col_Inc++;  }
                if(Col_Inc < 0) { Col_Inc--; }
               
            }
            return false;
        }
        private bool OutofBounds(int startRow,int Row_Inc, int startCol, int Col_Inc, int size)
        {
            if (startRow + Row_Inc < size || startRow + Row_Inc >= 0 || startCol + Col_Inc < size || startCol + Col_Inc >= 0)
            {
                return true;
            }
            return false;
        }
        private void RemoveWord(char[,] Wpuzzle, int startRow, int startCol,  int wordLength, int[,] Delete)
        {
            for(int i = 0; i < wordLength; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    Console.WriteLine(Delete[i, j]);
                }
            }
        }
        
    }
}
