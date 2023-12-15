using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Quiz_App.Controller;
using Quiz_App.Model;

namespace Quiz_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Amount;
        int Category;
        string Difficulty;
        string Type;

        QuizAPI quizAPI;

        public MainWindow()
        {
            InitializeComponent();

            quizAPI = new QuizAPI();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Amount = int.Parse(TB_Amount.Text);
            Category = int.Parse(TB_Category.Text);
            Difficulty = TB_Difficulty.Text;
            Type = TB_Type.Text;

            GetQuiz();
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        public async void GetQuiz()
        {
            Root root = await quizAPI.GetQuizRoot(Amount, Category, Difficulty, Type);
            if (root == null)
            {
                Debug.WriteLine("Error in getting data");
                return;
            }
            MessageBox.Show(root.results[0].question.ToString());
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
