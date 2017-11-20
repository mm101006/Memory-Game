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
using System.ComponentModel;
using System.Threading;
using System.Timers;
using System.Windows.Threading;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for Display.xam
    /// </summary>
    public partial class Display : Window
    {
        string[] wordArr = new string[GameParameters.WordCount];

        public Display()
        {
            InitializeComponent();

            // MessageBox.Show(Convert.ToString(wordCount));
            string StartUpPath = System.AppDomain.CurrentDomain.BaseDirectory;
            // MessageBox.Show(StartUpPath);
            string lstWords = StartUpPath + @"\words.txt";

            StreamReader r = new StreamReader(lstWords);

            // MessageBox.Show(Convert.ToString(wordCount));
            
            string line;

            for (int i = 0; i < GameParameters.WordCount; i++)
            {
                line = r.ReadLine();
                wordArr[i] += line;
            }

            r.Close();

            int counter = 0;
            DispatcherTimer timer = new DispatcherTimer();            
            timer.Start();
            timer.Tick += delegate
            {                
                counter++;
                if (counter > wordArr.Length)
                {
                    timer.Stop();
                }
                else
                {
                    label1.Text = wordArr[counter - 1];
                }
            };
            timer.Interval = TimeSpan.FromSeconds(GameParameters.Interval);


        }
    }
}
