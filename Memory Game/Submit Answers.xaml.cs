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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
        }
    }
}
