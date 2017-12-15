using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for Submit_Answers.xaml
    /// </summary>
    public partial class Submit_Answers : Window
    {
        public Submit_Answers()
        {
            InitializeComponent();
            //foreach (string word in ArrayParameters.RandomWords)
            //{
            //    MessageBox.Show(word);
            //}

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (textBox.Text.ToLower().Trim() == ArrayParameters.RandomWords[0].ToLower().Trim())
            {
                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show("Wrong");
            }           
        }
    }
}
