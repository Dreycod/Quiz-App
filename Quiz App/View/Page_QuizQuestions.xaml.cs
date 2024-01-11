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
        Root root;
        MainWindow mainwindow;
        int Number_Question = 0;
        int Questions_justes = 0;

        QuizAPI quizAPI = new QuizAPI();

        public Page_QuizQuestions(MainWindow main)
        {
            InitializeComponent();
            mainwindow = main;
        }
     
        public void UpdateInfo(bool NewQuiz)
        {
            GetQuiz(NewQuiz);
            LB_QuizName.Content = current_category.Name + " Quiz";
            LB_Progress.Content = "Question " + (Number_Question+1) + " of 10";

        }

        public async void GetQuiz(bool NewQuiz)
        {
            if (NewQuiz == true)
            { 
                root = await quizAPI.GetQuizRoot(10, current_category.ID, "easy", "multiple");
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
                }
            }

            if (Number_Question == 9)
            {
                MessageBox.Show("End of Quiz");
                mainwindow.Grid_Content.Children.Clear();
                mainwindow.Grid_Content.Children.Add(mainwindow.page_dashboard);
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
