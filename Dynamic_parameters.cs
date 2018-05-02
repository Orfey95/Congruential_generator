using System;
using System.Windows.Controls;

namespace Congruential_generator
{
    class Dynamic_parameters
    {
        Random rand = new Random();
        // Substitution of dynamic parameters
        public Int64[] dynamicParametrs()
        {
            Int64[] arrA = { 84589, 36261, 17221, 2416, 4096 };
            Int64[] arrC = { 45989, 66037, 107839, 374441, 150889 };
            Int64[] arrM = { 1048423, 1048433, 1048447, 1048507, 1048517, 1048549, 1048559, 1048571, 1048573, 1048575 };
                        
            int randA_1_and_C_1 = rand.Next(0, arrA.Length);
            int randA_2_and_C_2 = rand.Next(0, arrA.Length);
            int randM_1 = rand.Next(0, arrM.Length);
            int randM_2 = rand.Next(0, arrM.Length);

            Int64[] arrParametrs = { arrA[randA_1_and_C_1], arrA[randA_2_and_C_2], arrM[randM_1], arrM[randM_2] };

            return arrParametrs;
        }
    }
}