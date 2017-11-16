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
using System.Timers;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Window
    {
        public Display(int wordCount, int interval)
        {
            InitializeComponent();
            // Timer 
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(nextWord);
            int time = interval * 1000;
            aTimer.Interval = time;
            aTimer.Enabled = true;
            
            // MessageBox.Show(Convert.ToString(wordCount));
            string StartUpPath = System.AppDomain.CurrentDomain.BaseDirectory;
            // MessageBox.Show(StartUpPath);
            string lstWords = StartUpPath + @"\words.txt";

            StreamReader r = new StreamReader(lstWords);

            // MessageBox.Show(Convert.ToString(wordCount));
            string[] wordArr = new string[wordCount];
            string line;        

            int n = 0;
            while (n < wordCount)
            {
                line = r.ReadLine();
                txtDisplay.Text += line;
                n += 1;
            }

            //for (int i = 0; i < wordCount; i++)
            //{
            //    line = r.ReadLine();
            //    txtDisplay.Text = line;
            //    wordArr[i] += line;
            //}

            r.Close();
        }

        private static void nextWord(Object source, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show("test");
        }

    }
}
