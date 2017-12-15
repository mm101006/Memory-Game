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
        static Random _random = new Random();
        

        public Display()
        {
            InitializeComponent();

            FillAnswers.Visibility = Visibility.Hidden;

            // MessageBox.Show(Convert.ToString(wordCount));
            string StartUpPath = System.AppDomain.CurrentDomain.BaseDirectory;
            // MessageBox.Show(StartUpPath);
            string lstWords = StartUpPath + @"\words.txt";

            StreamReader r = new StreamReader(lstWords);

            // MessageBox.Show(Convert.ToString(wordCount));
            
            string line;
            string[] fileArr = new string[GameParameters.TotalWords];
            bool finished = false;

            int i = 0;
            while (!finished)
            {
                line = r.ReadLine();
                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    fileArr[i] += line + Environment.NewLine;                
                }
                i += 1;
            }

            string[] shuffle = RandomizeStrings(fileArr);

            ArrayParameters.RandomWords = shuffle;

            

            for (int n = 0; i < GameParameters.WordCount; i++)
            {
                line = r.ReadLine();
                wordArr[n] += line;
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
                    label1.FontSize = int.Parse("24");
                    label1.Text = "Submit Answers";
                    Stop.Visibility = Visibility.Hidden;
                    FillAnswers.Visibility = Visibility.Visible;
                }
                else
                {
                    label1.Text = shuffle[counter - 1];
                }
            };
            timer.Interval = TimeSpan.FromSeconds(GameParameters.Interval);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow previousWindow = new MainWindow();
            previousWindow.Show();
            this.Close();
            
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Submit_Answers answers = new Submit_Answers();
            answers.Show();
            this.Close();
        }

        static string[] RandomizeStrings(string[] arr)
        {
            List<KeyValuePair<int, string>> list =
                new List<KeyValuePair<int, string>>();
            // Add all strings from array.
            // ... Add new random int each time.
            foreach (string s in arr)
            {
                list.Add(new KeyValuePair<int, string>(_random.Next(), s));
            }
            // Sort the list by the random number.
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array.
            string[] result = new string[arr.Length];
            // Copy values to array.
            int index = 0;
            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array.
            return result;
        }

    }
}


