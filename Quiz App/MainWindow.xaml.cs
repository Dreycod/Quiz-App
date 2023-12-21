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
        string StringCategory;
        string Difficulty;
        string Type;

        // Create me a dictionnary of string and int 
        Dictionary<string, int> categories = new Dictionary<string, int>()
        {
            {"General Knowledge", 9},
            {"Books", 10},
            {"Film", 11},
            {"Music", 12},
            {"Musicals & Theatres", 13},
            {"Television", 14},
            {"Video Games", 15},
            {"Board Games", 16},
            {"Science & Nature", 17},
            {"Computers", 18},
            {"Mathematics", 19},
            {"Mythology", 20},
            {"Sports", 21},
            {"Geography", 22},
            {"History", 23},
            {"Politics", 24},
            {"Art", 25},
            {"Celebrities", 26},
            {"Animals", 27},
            {"Vehicles", 28},
            {"Comics", 29},
            {"Gadgets", 30},
            {"Anime & Manga", 31},
            {"Cartoon & Animations", 32}
        };

        QuizAPI quizAPI;

        public MainWindow()
        {
            InitializeComponent();

            quizAPI = new QuizAPI();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Amount = int.Parse(TB_Amount.Text);
            StringCategory = TB_Category.Text;
            Difficulty = TB_Difficulty.Text;
            Type = TB_Type.Text;

            Category = categories[StringCategory];
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
            QuestionLabel.Content = root.results[0].question.ToString();

            if (root.results[0].type == "multiple")
            {
                Answer1Button.Content = root.results[0].correct_answer.ToString();
                Answer2Button.Content = root.results[0].incorrect_answers[0].ToString();
                Answer3Button.Content = root.results[0].incorrect_answers[1].ToString();
                Answer4Button.Content = root.results[0].incorrect_answers[2].ToString();
            }
            

            
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConfirmAnswersButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
