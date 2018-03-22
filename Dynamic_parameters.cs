using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Congruential_generator
{
    class Dynamic_parameters
    {
        Random rand = new Random();
        // Substitution of dynamic parameters
        public void dynamicParametrs(TextBox parametr_A_1_Box, TextBox parametr_A_2_Box, TextBox parametr_C_1_Box, TextBox parametr_C_2_Box, TextBox parametr_M_1_Box, TextBox parametr_M_2_Box)
        {
            int[] arrA = { 84589, 36261, 17221, 2416, 4096 };
            int[] arrC = { 45989, 66037, 107839, 374441, 150889 };
            int[] arrM = { 1048423, 1048433, 1048447, 1048507, 1048517, 1048549, 1048559, 1048571, 1048573, 1048575 };
            
            
            int randA_1_and_C_1 = rand.Next(0, arrA.Length);
            int randA_2_and_C_2 = rand.Next(0, arrA.Length);
            int randM_1 = rand.Next(0, arrM.Length);
            int randM_2 = rand.Next(0, arrM.Length);

            parametr_A_1_Box.Text = arrA[randA_1_and_C_1].ToString();
            parametr_A_2_Box.Text = arrA[randA_2_and_C_2].ToString();
            parametr_C_1_Box.Text = arrC[randA_1_and_C_1].ToString();
            parametr_C_2_Box.Text = arrC[randA_2_and_C_2].ToString();
            parametr_M_1_Box.Text = arrM[randM_1].ToString();
            parametr_M_2_Box.Text = arrM[randM_2].ToString();
        }
    }
}
