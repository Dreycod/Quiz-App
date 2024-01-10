using Quiz_App.View;
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
using Quiz_App.View;

namespace Quiz_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Create me a dictionnary of string and int 
        string username = "Default";
        int level = 1;
        int exp = 10;
        int wins = 0;
        List<string> achievements = new List<string>();
        double fastestTime = 0;
        int correctAnswers = 0;

        QuizAPI quizAPI;
        Category category;
        Player player;

        Page_Dashboard dashboard;

        List<Achievements> Ls_Achievements = new List<Achievements>();
        List<Category> Ls_Category = new List<Category>();

        public MainWindow()
        {
            InitializeComponent();

            quizAPI = new QuizAPI();
            category = new Category("Books");
            player = new Player(username, level, exp, wins, achievements, fastestTime, correctAnswers);

            // Appear dashboard_xaml Page
            dashboard = new Page_Dashboard();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(dashboard);

            player.SetUsername(username);
            player.SetLevel(level);
            player.SetExp(exp);
            player.SetWins(wins);
            player.SetAchievements(achievements);
            player.SetFastestTime(fastestTime);
            player.SetCorrectAnswers(correctAnswers);


            // Set the player's informations
            dashboard.LB_Username.Content = player.GetUsername();
            dashboard.LB_Level.Content = "Lvl." + player.GetLevel();


            dashboard.PB_Player.Maximum = player.GetMaxExp();
            dashboard.PB_Player.Value = player.GetExp();

            Ls_Achievements.Add(new Achievements() { ImageUrl = "/Ressources/Images/Achievements/Silver.png", Content = "Win your first game"});
            dashboard.LV_Achievements.ItemsSource = Ls_Achievements;

            Ls_Category.Add(new Category("General Knowledge") {ImageUrl = "/Ressources/Images/Categories/General_Knowledge.jpg", Content = "General Knowledge"});
            dashboard.LV_Categories.ItemsSource = Ls_Category;
        }

        //listview clickable event handler itemselected for category
        //private void LV_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Category category = (Category)dashboard.LV_Categories.SelectedItem;
        //    StringCategory = category.Content;
        //    MessageBox.Show(StringCategory);
        //}

        private void CategoryBTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button) sender;
            string content = btn.Content.ToString();
            
            category = new Category(content);
        }

        public async void GetQuiz()
        {
            Root root = await quizAPI.GetQuizRoot(Amount, Category, Difficulty, Type);
            if (root == null)
            {
                Debug.WriteLine("Error in getting data");
                return;
            }
         //   QuestionLabel.Text = root.results[0].question.ToString();

            if (root.results[0].type == "multiple")
            {
                // Randomize the answers
                Random rnd = new Random();
                int random = rnd.Next(0, 4);

                

                //if (random == 0)
                //{
                //    Answer1Button.Content = root.results[0].correct_answer.ToString();
                //    Answer2Button.Content = root.results[0].incorrect_answers[0].ToString();
                //    Answer3Button.Content = root.results[0].incorrect_answers[1].ToString();
                //    Answer4Button.Content = root.results[0].incorrect_answers[2].ToString();
                //}
                //else if (random == 1)
                //{
                //    Answer1Button.Content = root.results[0].incorrect_answers[0].ToString();
                //    Answer2Button.Content = root.results[0].correct_answer.ToString();
                //    Answer3Button.Content = root.results[0].incorrect_answers[1].ToString();
                //    Answer4Button.Content = root.results[0].incorrect_answers[2].ToString();
                //}
                //else if (random == 2)
                //{
                //    Answer1Button.Content = root.results[0].incorrect_answers[0].ToString();
                //    Answer2Button.Content = root.results[0].incorrect_answers[1].ToString();
                //    Answer3Button.Content = root.results[0].correct_answer.ToString();
                //    Answer4Button.Content = root.results[0].incorrect_answers[2].ToString();
                //}
                //else if (random == 3)
                //{
                //    Answer1Button.Content = root.results[0].incorrect_answers[0].ToString();
                //    Answer2Button.Content = root.results[0].incorrect_answers[1].ToString();
                //    Answer3Button.Content = root.results[0].incorrect_answers[2].ToString();
                //    Answer4Button.Content = root.results[0].correct_answer.ToString();
                //}   
            }    
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
=======
        public MainWindow()
        {
            InitializeComponent();
            Page_Dashboard dashboard = new Page_Dashboard();
            Grid_Content.Children.Add(dashboard);
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
