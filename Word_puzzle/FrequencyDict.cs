using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_puzzle
{
    public partial class letter_frequency
    {
        public char FreqMapper(letter_frequency[] Potential_Character, int pos, int RandomValue)
        {
            char Generated_Character = ' ';
            bool hasFoundCharacter = false;
            while (!hasFoundCharacter)
            {
                if (Potential_Character[pos].Min <= RandomValue && RandomValue < Potential_Character[pos].Max)
                {
                    Generated_Character = Potential_Character[pos].Letter;
                    hasFoundCharacter = true;
                
                }
                pos++;
            }
            return Generated_Character;
        }
    }
}
