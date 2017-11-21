using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            int wordAmount = Convert.ToInt32(sldUnit.Value);
            int interval = Convert.ToInt32(sldInterval.Value);

            // creating the instance of the class GameParameters passing in 2 parameters 
            GameParameters.Interval = interval;
            GameParameters.WordCount = wordAmount;            

            Display display = new Display();
            display.Show();
            this.Close();            
        }

        private void sldUnit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            string StartUpPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var lineCount = File.ReadLines(StartUpPath + @"\words.txt").Count();
            sldUnit.Maximum = lineCount;
            int totalWords = lineCount;
            GameParameters.TotalWords = totalWords;
        }
    }
}
