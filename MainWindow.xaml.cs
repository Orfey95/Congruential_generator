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

        private int x_1; // X0 for Generator 1
        private int x_2; // X0 for Generator 2

        public MainWindow()
        {
            InitializeComponent();
            x_1 = int.Parse(parametr_X0_1_Box.Text); // Set X0 for Generator 1 
            x_2 = int.Parse(parametr_X0_2_Box.Text); // Set X0 for Generator 2
        }

        private void parametr_X0_1_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { x_1 = int.Parse(parametr_X0_1_Box.Text); } // Set X0 for Generator 1
            catch { }
        }

        private void parametr_X0_2_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { x_2 = int.Parse(parametr_X0_2_Box.Text); } // Set X0 for Generator 2
            catch { }
        }

        private void generationButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < int.Parse(NumberOfIterationsBox.Text); i++)
            {
                if (DynamicParametersRadioButton.IsChecked == true)
                {
                    dynamicParametrs.dynamicParametrs(parametr_A_1_Box, parametr_A_2_Box, parametr_C_1_Box, parametr_C_2_Box, parametr_M_1_Box, parametr_M_2_Box);
                }
                x_1 = conrguentAlgorithm.CongruentialGeneratorAlgorithm(x_1, parametr_A_1_Box, parametr_C_1_Box, parametr_M_1_Box);
                x_2 = conrguentAlgorithm.CongruentialGeneratorAlgorithm(x_2, parametr_A_2_Box, parametr_C_2_Box, parametr_M_2_Box);
                sequenceTextBox.Text += conrguentAlgorithm.XORAlgorithm(conrguentAlgorithm.DecimalToBinaryAlgorithm(int.Parse(parametr_M_1_Box.Text), x_1), conrguentAlgorithm.DecimalToBinaryAlgorithm(int.Parse(parametr_M_2_Box.Text), x_2));
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
    }
}