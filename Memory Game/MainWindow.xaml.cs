using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // wordAmount and interval values are set by the sliders
            int wordAmount = Convert.ToInt32(sldUnit.Value);
            int interval = Convert.ToInt32(sldInterval.Value);

            // Passes Interval and WordCount to the class GameParameters 
            GameParameters.Interval = interval;
            GameParameters.WordCount = wordAmount;

            // Passes the user to the display game screen
            Display display = new Display();
            display.Show();
            this.Close();            
        }

        private void sldUnit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // reads the file words.txt, counts lines, then sets the maximum amount of words that can be selected
            string StartUpPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var lineCount = File.ReadLines(StartUpPath + @"\words.txt").Count();
            sldUnit.Maximum = lineCount;
            int totalWords = lineCount;
            GameParameters.TotalWords = totalWords;
        }
    }
}
