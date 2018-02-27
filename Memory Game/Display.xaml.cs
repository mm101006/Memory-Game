using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using System.Windows.Threading;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Window
    {        
        // declares a string array, and creates an instance of the Random class
        string[] wordArr = new string[GameParameters.WordCount];
        static Random _random = new Random();        

        public Display()
        {
            InitializeComponent();
            // fill in answers button is hidden from user at start of game
            FillAnswers.Visibility = Visibility.Hidden;
            // navigates to debug directory looking for the file words.txt
            string StartUpPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string lstWords = StartUpPath + @"\words.txt";
            // StreamReader is initialized 
            StreamReader r = new StreamReader(lstWords);
            
            string line;
            string[] fileArr = new string[GameParameters.TotalWords];
            bool finished = false;
            // while loop is used to read each line of the text file, 
            // if line has a value attach that value to the arrary fileArr
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
                    fileArr[i] += line;                
                }
                i += 1;
            }
            // RandomWords array of class ArrayParameters is populated by the fileArr,
            // which is ran through the RandomizeString function
            ArrayParameters.RandomWords = RandomizeStrings(fileArr);
            // a for loop then reads through the RandomWords Array
            for (int n = 0; i < GameParameters.WordCount; i++)
            {
                line = r.ReadLine();
                ArrayParameters.RandomWords[n] += line;
            }

            r.Close();
            // a Timer is used to flash words on the screen
            int counter = 0;
            DispatcherTimer timer = new DispatcherTimer();            
            timer.Start();
            timer.Tick += delegate
            {                
                counter++;
                if (counter > wordArr.Length)
                {
                    timer.Stop();
                    wordScreen.FontSize = int.Parse("24");
                    wordScreen.Text = "Click to Fill in Answers";
                    Stop.Visibility = Visibility.Hidden;
                    FillAnswers.Visibility = Visibility.Visible;
                }
                else
                {
                    wordScreen.Text = ArrayParameters.RandomWords[counter - 1];
                }
            };
            timer.Interval = TimeSpan.FromSeconds(GameParameters.Interval);

        }

        private void StopButton(object sender, RoutedEventArgs e)
        {
            MainWindow previousWindow = new MainWindow();
            previousWindow.Show();
            this.Close();            
        }

        private void FillAnswersButton(object sender, RoutedEventArgs e)
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


