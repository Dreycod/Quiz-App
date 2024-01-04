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
using System.Reflection.Emit;

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
        string username = "Default";
        int level = 1;
        int exp = 0;
        int wins = 0;
        List<string> achievements = new List<string>();
        double fastestTime = 0;
        int correctAnswers = 0;

        QuizAPI quizAPI;
        Category category;
        Player player;
        public MainWindow()
        {
            InitializeComponent();

            quizAPI = new QuizAPI();
            category = new Category("Books");
            player = new Player(username, level, exp, wins, achievements, fastestTime, correctAnswers);
        }

        private void CategoryBTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button) sender;
            string content = btn.Content.ToString();
            
            category = new Category(content);
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
            QuestionLabel.Text = root.results[0].question.ToString();

            if (root.results[0].type == "multiple")
            {
                // Randomize the answers
                Random rnd = new Random();
                int random = rnd.Next(0, 4);

                

                if (random == 0)
                {
                    Answer1Button.Content = root.results[0].correct_answer.ToString();
                    Answer2Button.Content = root.results[0].incorrect_answers[0].ToString();
                    Answer3Button.Content = root.results[0].incorrect_answers[1].ToString();
                    Answer4Button.Content = root.results[0].incorrect_answers[2].ToString();
                }
                else if (random == 1)
                {
                    Answer1Button.Content = root.results[0].incorrect_answers[0].ToString();
                    Answer2Button.Content = root.results[0].correct_answer.ToString();
                    Answer3Button.Content = root.results[0].incorrect_answers[1].ToString();
                    Answer4Button.Content = root.results[0].incorrect_answers[2].ToString();
                }
                else if (random == 2)
                {
                    Answer1Button.Content = root.results[0].incorrect_answers[0].ToString();
                    Answer2Button.Content = root.results[0].incorrect_answers[1].ToString();
                    Answer3Button.Content = root.results[0].correct_answer.ToString();
                    Answer4Button.Content = root.results[0].incorrect_answers[2].ToString();
                }
                else if (random == 3)
                {
                    Answer1Button.Content = root.results[0].incorrect_answers[0].ToString();
                    Answer2Button.Content = root.results[0].incorrect_answers[1].ToString();
                    Answer3Button.Content = root.results[0].incorrect_answers[2].ToString();
                    Answer4Button.Content = root.results[0].correct_answer.ToString();
                }   
            }    
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConfirmAnswersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExpButton_Click(object sender, RoutedEventArgs e)
        {
            player.AddExp(10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }   
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
