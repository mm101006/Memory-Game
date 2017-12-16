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
        }

        int count = 0;
        public string CompareAnswer(string txtBoxAnswer,  string arrAnswer)
        {
            if (textBox.Text.ToLower().Trim() == ArrayParameters.RandomWords[count].ToLower().Trim())
            {
                MessageBoxResult output = MessageBox.Show("Correct");
                count += 1;
                if (GameParameters.WordCount == count)
                {
                    MessageBoxResult end = MessageBox.Show("Game Ended");
                    MainWindow previousWindow = new MainWindow();
                    previousWindow.Show();
                    this.Close();
                    return end.ToString();
                } 
                else
                {
                    textBox.Clear();
                    return output.ToString();
                }                
            }
            else
            {
                MessageBoxResult output = MessageBox.Show("Wrong");
                return output.ToString();
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            CompareAnswer(textBox.Text.ToLower().Trim(), ArrayParameters.RandomWords[count].ToLower().Trim());
                                    
        }
    }
}
