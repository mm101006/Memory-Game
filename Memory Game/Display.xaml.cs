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
using System.IO;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for Display.xam
    /// </summary>
    public partial class Display : Window
    {
        public Display()
        {
            InitializeComponent();

            // MessageBox.Show(Convert.ToString(wordCount));
            string StartUpPath = System.AppDomain.CurrentDomain.BaseDirectory;
            // MessageBox.Show(StartUpPath);
            string lstWords = StartUpPath + @"\words.txt";

            StreamReader r = new StreamReader(lstWords);

            // MessageBox.Show(Convert.ToString(wordCount));
            string[] wordArr = new string[GameParameters.WordCount];
            string line;

            for (int i = 0; i < GameParameters.WordCount; i++)
            {
                line = r.ReadLine();
                wordArr[i] += line;
            }

            r.Close();

            txtDisplay.Text = wordArr[0];
            System.Threading.Thread.Sleep(GameParameters.Interval * 1000);
            txtDisplay.Text = String.Empty;
            txtDisplay.Text = wordArr[1];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            //int n = 0;
            //while (n < GameParameters.WordCount)
            //{
            //    txtDisplay.Text = wordArr[0];
            //    System.Threading.Thread.Sleep(GameParameters.Interval * 1000);
            //    n += 1;
            //}





        }
    }
}
