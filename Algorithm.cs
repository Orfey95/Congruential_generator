using System;
using System.Windows.Controls;

namespace Congruential_generator
{
    class Algorithm
    {
        //Linear congruential generator
        public Int64 CongruentialGeneratorAlgorithm(Int64 x0, Int64 a, Int64 c, Int64 m)
        {
            x0 = (a * x0 + c) % m;
            return x0;
        }
        // Converting a sequence from decimal to binary
        public string DecimalToBinaryAlgorithm(Int64 m, Int64 x)
        {
            string binarySequence = "";
            double i = 0;
            double exponent = 0;
            while (true)
            {
                exponent = Math.Pow(2, i);
                if (exponent >= m)
                {
                    break;
                }
                i++;
            }            
            binarySequence = Convert.ToString(Convert.ToInt64(x + exponent), 2);
            binarySequence = binarySequence.Remove(0, 1);
            return binarySequence;
        }
        // The XOR operation between the sequences of two congruent generators
        public string XORAlgorithm(string SequenceOne, string SequenceTwo)
        {
            string XORSequence = "";

            int minLength = 0;
            if (SequenceOne.Length >= SequenceTwo.Length)
                minLength = SequenceTwo.Length;
            else
                minLength = SequenceOne.Length;

            for (int i = 0; i < minLength; i++)
            {
                XORSequence += SequenceOne[i] ^ SequenceTwo[i];
            }

            return XORSequence;
        }
    }
}
