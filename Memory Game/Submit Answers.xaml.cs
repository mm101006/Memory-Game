﻿using System;
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
        // below is used to compare user's value to that of the array value
        int count = 0;
        public string CompareAnswer(string txtBoxAnswer,  string arrAnswer)
        {
            // Trim is used here to remove all leading and trailing white spaces
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

        private void SubmitAnswer(object sender, RoutedEventArgs e)
        {
            CompareAnswer(textBox.Text.ToLower().Trim(), ArrayParameters.RandomWords[count].ToLower().Trim());
                                    
        }

        private void backToMenu(object sender, RoutedEventArgs e)
        {
            MainWindow previousWindow = new MainWindow();
            previousWindow.Show();
            this.Close();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List with all the answers.
            List<string> data = new List<string>();
            data.Add("Answers:");
            int words = 0;
            while (words < GameParameters.WordCount)
            {
                data.Add(words + 1 + ". " + ArrayParameters.RandomWords[words].ToLower().Trim());
                words += 1;
            }          

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

    }
}
