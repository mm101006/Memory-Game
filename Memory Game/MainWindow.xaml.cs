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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

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
            Display display = new Display();
            display.Show();
            this.Close();

            int wordCount = Convert.ToInt32(sldUnit.Value);
            // MessageBox.Show(Convert.ToString(wordCount));
            string StartUpPath = System.AppDomain.CurrentDomain.BaseDirectory;
            // MessageBox.Show(StartUpPath);
            string lstWords = StartUpPath + @"\words.txt";

            StreamReader r = new StreamReader(lstWords);

            // MessageBox.Show(Convert.ToString(wordCount));
            string[] wordArr = new string[wordCount];
            string line;

            for (int i = 0; i < wordCount; i++)
            {
                line = r.ReadLine();
                MessageBox.Show(line);
                wordArr[i] += line;
            }

            r.Close();
        }
    }
}
