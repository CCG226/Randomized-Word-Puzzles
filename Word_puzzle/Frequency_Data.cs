using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_puzzle
{
   
    public partial class letter_frequency
    {
        public char Letter { get; set; }
        public double Min { get; set; }
        public  double Max { get; set; }
        static char[] letterList = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        static double[] forMinFreqCalc = new double[26] {0, 8.4966, 2.0720, 4.5388, 3.3844, 11.1607, 1.8121, 2.4705, 3.0034, 7.5448, 0.1965, 1.1016, 5.4893, 3.0129, 6.6544, 7.1635, 3.1671, 0.1962, 7.5809, 5.7351, 6.9509, 3.6308, 1.0074, 1.2899, 0.2902, 1.7779 };
        static double[] forMaxFreqCalc = new double[26] { 8.4966, 2.0720, 4.5388, 3.3844, 11.1607, 1.8121, 2.4705, 3.0034, 7.5448, 0.1965, 1.1016, 5.4893, 3.0129, 6.6544, 7.1635, 3.1671, 0.1962, 7.5809, 5.7351, 6.9509, 3.6308, 1.0074, 1.2899, 0.2902, 1.7779, 0.2722 };
                                                                  
        private static void DistributeRange(int pos, double[] Range, double[] Sumup)
        {
            if(pos == 26)
            {
                if(Sumup[25] != 99.7279)
                {
                    Sumup[25] = Math.Round(Sumup[25], 0);
                }
              
                return;

            }
            Sumup[pos] = Range[pos] + Sumup[pos - 1];
            Sumup[pos] = Math.Round(Sumup[pos], 4);
            DistributeRange(pos + 1, Range, Sumup);
        }
       public letter_frequency[] Freq_Data()
        {
            double[] MinRange = new double[26];
            double[] MaxRange = new double[26];
            MinRange[0] = 0;
            MaxRange[0] = 8.4966;
            DistributeRange(1, forMinFreqCalc, MinRange);
            DistributeRange(1, forMaxFreqCalc, MaxRange);
            letter_frequency[] letters = new letter_frequency[26];
            
           
            for (int i = 0; i < 26; i++)
            {
                letters[i] = new letter_frequency();
                letters[i].Max = MaxRange[i] * 10000;
                letters[i].Min = MinRange[i] * 10000;
                letters[i].Max = Math.Round(letters[i].Max, 0);
                letters[i].Min = Math.Round(letters[i].Min, 0);
                letters[i].Letter = letterList[i];

            }
      
            return letters;
        }
       
    }
   
}
