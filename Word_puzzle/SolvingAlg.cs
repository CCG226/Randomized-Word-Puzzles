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
                    if (Wpuzzle[i, j] == head)//found first letter, check all 8 directions to see if we found the word
                    {

                        if (Alg(0,1, word, wordLength, Wpuzzle, i, j, size)) { return true;  }//south
                        if (Alg(0, -1, word, wordLength, Wpuzzle, i, j, size)) { return true; }//north
                        if (Alg(1, 0, word, wordLength, Wpuzzle, i, j, size)) { return true; }//east
                        if (Alg(-1, 0, word, wordLength, Wpuzzle, i, j, size)) { return true; }//west
                        if (Alg(1, 1, word, wordLength, Wpuzzle, i, j, size)) { return true; }//southeast
                        if (Alg(1, -1, word, wordLength, Wpuzzle, i, j, size)) { return true; }//southwest
                        if (Alg(-1, 1, word, wordLength, Wpuzzle, i, j, size)) { return true; }//northeast
                        if (Alg(-1, -1, word, wordLength, Wpuzzle, i, j, size)) { return true; }//northwest
              

                    }
                   
                }
            }
          return false;
        }

         
        private bool Alg(int Row_Inc, int Col_Inc,string word, int WordSize, char[,] Wpuzzle, int startRow, int startCol, int arraySize)
        {
            if (OutofBounds(startRow, Row_Inc, startCol, Col_Inc, arraySize))//check bounds first to ensure direction wont immediately lead us out of bounds
            {
                return false;
            }
            int[,] DeleteCoords = new int[WordSize, 2];//stores coords of all letters of the word on the map so we can delete it later fi word is found
            DeleteCoords[0, 0] = startRow;
            DeleteCoords[0, 1] = startCol;
            int curr = 1;// move to next letter in word
            while (Wpuzzle[startRow + Row_Inc, startCol + Col_Inc] == word[curr])// is the next letter in this direction correct?
            {
                DeleteCoords[curr, 0] = startRow + Row_Inc;
                DeleteCoords[curr, 1] = startCol + Col_Inc;
                
                if(curr == word.Length - 1)//word has been found
                {
                    RemoveWord(Wpuzzle, startRow, startCol, word.Length, DeleteCoords);//remove word
                    return true;
                }
                curr++;//if word has not been found move to next letter

                if (Row_Inc == 0) { Row_Inc = 0; }//increment based on argument value so we can continue to increment in the right direction 
                if(Row_Inc > 0){Row_Inc++; }
                if(Row_Inc < 0){ Row_Inc--; }
                if (Col_Inc == 0) { Col_Inc = 0; }
                if(Col_Inc > 0) { Col_Inc++;  }
                if(Col_Inc < 0) { Col_Inc--; }
                if (OutofBounds(startRow, Row_Inc, startCol, Col_Inc, arraySize))//will the next incrementation lead us out of bounds?
                {
                    return false;
                }
            }
            return false;
        }
        private bool OutofBounds(int startRow,int Row_Inc, int startCol, int Col_Inc, int size)
        {
            if (startRow + Row_Inc >= size || startRow + Row_Inc < 0 || startCol + Col_Inc >= size || startCol + Col_Inc < 0)
            {
                return true;
            }
            return false;
        }
        private void RemoveWord(char[,] Wpuzzle, int startRow, int startCol,  int wordLength, int[,] Delete)
        {
           for(int i = 0; i < wordLength;i++)
            {
                Wpuzzle[Delete[i, 0], Delete[i, 1]] = ' ';
            }
        }
        
    }
}
