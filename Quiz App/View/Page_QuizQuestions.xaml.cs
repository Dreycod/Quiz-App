using Quiz_App.Controller;
using Quiz_App.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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

namespace Quiz_App.View
{ 
    /// <summary>
    /// Interaction logic for Page_QuizQuestions.xaml
    /// </summary>
    public partial class Page_QuizQuestions : UserControl
    {
        public Category current_category { get; set; }
        public int Question_Amount { get; set; }
        public string Quiz_Difficulty { get; set; }

        Root root;
        MainWindow mainwindow;
        PlayerController playercontroller;
        int Number_Question = 0;
        int Questions_justes = 0;

        QuizAPI quizAPI = new QuizAPI();

        public Page_QuizQuestions(MainWindow main)
        {
            InitializeComponent();
            mainwindow = main;
            playercontroller = mainwindow.playercontroller;
        }
     
        public void UpdateInfo(bool NewQuiz)
        {
            GetQuiz(NewQuiz);
            LB_QuizName.Content = current_category.Name + " Quiz";

            Player player = playercontroller.GetPlayer();

            LB_Progress.Content = "Question " + (Number_Question+1) + " of "+player.quizQuestionAmount;

        }

        public async void GetQuiz(bool NewQuiz)
        {
            if (NewQuiz == true)
            { 
                Player player = playercontroller.GetPlayer();
                Number_Question = 0;
                root = await quizAPI.GetQuizRoot(player.quizQuestionAmount, current_category.ID, player.quizDifficulty.ToLower(), "multiple");
            }

            if (root == null)
            {
                Debug.WriteLine("Error in getting data");
                return;
            }

            LB_Question.Text = root.results[Number_Question].question.ToString();

            Random rnd = new Random();
            int random = rnd.Next(0, 4);

            switch (random)
            {
                case 0:
                    RB_Answer1.Content = root.results[Number_Question].correct_answer.ToString();
                    RB_Answer2.Content = root.results[Number_Question].incorrect_answers[0].ToString();
                    RB_Answer3.Content = root.results[Number_Question].incorrect_answers[1].ToString();
                    RB_Answer4.Content = root.results[Number_Question].incorrect_answers[2].ToString();
                    break;
                case 1:
                    RB_Answer1.Content = root.results[Number_Question].incorrect_answers[0].ToString();
                    RB_Answer2.Content = root.results[Number_Question].correct_answer.ToString();
                    RB_Answer3.Content = root.results[Number_Question].incorrect_answers[1].ToString();
                    RB_Answer4.Content = root.results[Number_Question].incorrect_answers[2].ToString();
                    break;
                case 2:
                    RB_Answer1.Content = root.results[Number_Question].incorrect_answers[0].ToString();
                    RB_Answer2.Content = root.results[Number_Question].incorrect_answers[1].ToString();
                    RB_Answer3.Content = root.results[Number_Question].correct_answer.ToString();
                    RB_Answer4.Content = root.results[Number_Question].incorrect_answers[2].ToString();
                    break;
                case 3:
                    RB_Answer1.Content = root.results[Number_Question].incorrect_answers[0].ToString();
                    RB_Answer2.Content = root.results[Number_Question].incorrect_answers[1].ToString();
                    RB_Answer3.Content = root.results[Number_Question].incorrect_answers[2].ToString();
                    RB_Answer4.Content = root.results[Number_Question].correct_answer.ToString();
                    break;
            }
        }

        public void ValidateAnswer(object sender, RoutedEventArgs e)
        {
            foreach(RadioButton radiobutton in SP_RB.Children.OfType<RadioButton>())
            {
                if(radiobutton.IsChecked == true)
                {
                    if(radiobutton.Content.ToString() == root.results[Number_Question].correct_answer.ToString())
                    {
                        Questions_justes++;
                        MessageBox.Show("Correct Answer");
                    }
                    else
                    {
                        MessageBox.Show("Wrong Answer, the correct answer was: "+ root.results[Number_Question].correct_answer.ToString());
                    }
                }
            }

            Player player = playercontroller.GetPlayer();

            if (Number_Question == (player.quizQuestionAmount-1))
            {

                playercontroller.AddExp(Questions_justes * 10);
                player.CorrectAnswers += Questions_justes;
                if (Questions_justes != 0)
                {
                    if (((Questions_justes/player.quizQuestionAmount) * 100) >= 70)
                    {
                        MessageBox.Show(" Answers: " + Questions_justes + "/" + player.quizQuestionAmount + "\nYou won the quiz");
                        player.Wins++;
                    }
                }
                mainwindow.Grid_Content.Children.Clear();
                mainwindow.Grid_Content.Children.Add(mainwindow.page_dashboard);
                mainwindow.page_dashboard.UpdateInfo();
                Number_Question = 0;
                Questions_justes = 0;
                return;
            } 
            else
            {
                Number_Question++;
                UpdateInfo(false);
            }
        }
    }
}
