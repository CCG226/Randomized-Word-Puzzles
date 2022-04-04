using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_puzzle
{
    public partial class letter_frequency
    {
        public static char FreqMapper(letter_frequency[] Potential_Character, int pos, int RandomValue)
        {
            char Generated_Character = ' ';
            bool hasFoundCharacter = false;
            while (!hasFoundCharacter)//move through list of letters A - Z until Random value is greater than or equal to the letters min value and less than the letters max value
            {
                if (Potential_Character[pos].Min <= RandomValue && RandomValue < Potential_Character[pos].Max)
                {
                    Generated_Character = Potential_Character[pos].Letter;//Random value fits inside this letters range, generate_character is set
                    hasFoundCharacter = true;
                
                }
                pos++;//letter wasnt found move to next letter in list
            }
            return Generated_Character;
        }
    }
}
