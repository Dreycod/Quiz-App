using Quiz_App.Controller;
using Quiz_App.Model;
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

namespace Quiz_App.View
{
    /// <summary>
    /// Interaction logic for Page_ExtraTopic.xaml
    /// </summary>
    public partial class Page_ExtraTopic : UserControl
    {
        CategoryController categoryController { get; set; }
        List<Category> Ls_Category = new List<Category>();
        static Page_QuizQuestions page_quizquestions = new Page_QuizQuestions();
        MainWindow mainwindow;
        public Page_ExtraTopic(MainWindow window)
        {
            InitializeComponent();
            categoryController = new CategoryController();
            mainwindow = window;
            Ls_Category = categoryController.GetListCategory();
            LV_Categories.ItemsSource = Ls_Category;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            StackPanel stackPanel = (StackPanel)button.Content;
            Label label = (Label)stackPanel.Children[1];
            string Category = label.Content.ToString();
            Category category = categoryController.GetCategory(Category);
            mainwindow.Grid_Content.Children.Clear();


            mainwindow.Grid_Content.Children.Add(page_quizquestions);
            int Amount = 10;
            string Difficulty = "easy";
            string _Type = "multiple";
            // _GetQuiz();

            
        }
    }
}
