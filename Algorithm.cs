using System;
using System.Windows.Controls;

namespace Congruential_generator
{
    class Algorithm
    {
        //Linear congruential generator
        public int CongruentialGeneratorAlgorithm(int x0, TextBox parametr_A, TextBox parametr_C, TextBox parametr_M)
        {            
            int a = int.Parse(parametr_A.Text);
            int c = int.Parse(parametr_C.Text);
            int m = int.Parse(parametr_M.Text);

            x0 = (a * x0 + c) % m;

            return x0;
        }
        // Converting a sequence from decimal to binary
        public string DecimalToBinaryAlgorithm(int m, int x)
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
            binarySequence = Convert.ToString(Convert.ToInt32(x + exponent), 2);
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
