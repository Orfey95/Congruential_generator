using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Congruential_generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Algorithm conrguentAlgorithm = new Algorithm();
        Dynamic_parameters dynamicParametrs = new Dynamic_parameters();

        private Int64 x_1; // X0 for Generator 1
        private Int64 x_2; // X0 for Generator 2

        public MainWindow()
        {
            InitializeComponent();
            x_1 = Int64.Parse(parametr_X0_1_Box.Text); // Set X0 for Generator 1 
            x_2 = Int64.Parse(parametr_X0_2_Box.Text); // Set X0 for Generator 2
        }

        private void parametr_X0_1_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { x_1 = Int64.Parse(parametr_X0_1_Box.Text); } // Set X0 for Generator 1
            catch { }
        }

        private void parametr_X0_2_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { x_2 = Int64.Parse(parametr_X0_2_Box.Text); } // Set X0 for Generator 2
            catch { }
        }

        private void generationButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < int.Parse(NumberOfIterationsBox.Text); i++)
            {
                if (DynamicParametersRadioButton.IsChecked == true)
                {
                    Int64[] tempArr = dynamicParametrs.dynamicParametrs();
                    x_1 = conrguentAlgorithm.CongruentialGeneratorAlgorithm(x_1, tempArr[0], tempArr[0], tempArr[2]);
                    x_2 = conrguentAlgorithm.CongruentialGeneratorAlgorithm(x_2, tempArr[1], tempArr[1], tempArr[3]);
                    sequenceTextBox.Text += conrguentAlgorithm.XORAlgorithm(conrguentAlgorithm.DecimalToBinaryAlgorithm(tempArr[2], x_1), conrguentAlgorithm.DecimalToBinaryAlgorithm(tempArr[3], x_2));
                }
                else
                {
                    x_1 = conrguentAlgorithm.CongruentialGeneratorAlgorithm(x_1, Int64.Parse(parametr_A_1_Box.Text), Int64.Parse(parametr_C_1_Box.Text), Int64.Parse(parametr_M_1_Box.Text));
                    x_2 = conrguentAlgorithm.CongruentialGeneratorAlgorithm(x_2, Int64.Parse(parametr_A_2_Box.Text), Int64.Parse(parametr_C_2_Box.Text), Int64.Parse(parametr_M_2_Box.Text));
                    sequenceTextBox.Text += conrguentAlgorithm.XORAlgorithm(conrguentAlgorithm.DecimalToBinaryAlgorithm(Int64.Parse(parametr_M_1_Box.Text), x_1), conrguentAlgorithm.DecimalToBinaryAlgorithm(Int64.Parse(parametr_M_2_Box.Text), x_2));
                }
            }            
        }

        private void DynamicParametersRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            parametr_X0_1_Box.IsReadOnly = parametr_X0_2_Box.IsReadOnly = true;
            parametr_A_1_Box.IsReadOnly = parametr_A_2_Box.IsReadOnly = true;
            parametr_C_1_Box.IsReadOnly = parametr_C_2_Box.IsReadOnly = true;
            parametr_M_1_Box.IsReadOnly = parametr_M_2_Box.IsReadOnly = true;

            parametr_X0_1_Box.Background = parametr_X0_2_Box.Background = (Brush)bc.ConvertFrom("#E8E7E7");
            parametr_A_1_Box.Background = parametr_A_2_Box.Background = (Brush)bc.ConvertFrom("#E8E7E7");
            parametr_C_1_Box.Background = parametr_C_2_Box.Background = (Brush)bc.ConvertFrom("#E8E7E7");
            parametr_M_1_Box.Background = parametr_M_2_Box.Background = (Brush)bc.ConvertFrom("#E8E7E7");
        }

        private void StaticParametrsRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            parametr_X0_1_Box.IsReadOnly = parametr_X0_2_Box.IsReadOnly = false;
            parametr_A_1_Box.IsReadOnly = parametr_A_2_Box.IsReadOnly = false;
            parametr_C_1_Box.IsReadOnly = parametr_C_2_Box.IsReadOnly = false;
            parametr_M_1_Box.IsReadOnly = parametr_M_2_Box.IsReadOnly = false;

            parametr_X0_1_Box.Background = parametr_X0_2_Box.Background = Brushes.White;
            parametr_A_1_Box.Background = parametr_A_2_Box.Background = Brushes.White;
            parametr_C_1_Box.Background = parametr_C_2_Box.Background = Brushes.White;
            parametr_M_1_Box.Background = parametr_M_2_Box.Background = Brushes.White;
        }

        private void sequenceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            counter.Content = "Sequence Length: " + sequenceTextBox.Text.Length.ToString();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            sequenceTextBox.Text = "";
        }

        private void writeFileButton_Click(object sender, RoutedEventArgs e)
        {
            string tempSequence = "";
            for(int i = 0; i < sequenceTextBox.Text.Length; i++)
            {
                tempSequence += sequenceTextBox.Text[i] + " ";
            }
            tempSequence = tempSequence.Substring(0, tempSequence.Length - 1);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Sasha\Documents\Visual Studio 2015\Projects\Congruential_generator\Sequence.txt", false))
            {
                file.WriteLine(tempSequence);
            }
        }
    }
}