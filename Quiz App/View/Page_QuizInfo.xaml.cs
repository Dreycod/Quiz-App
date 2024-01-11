using Quiz_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Page_QuizInfo.xaml
    /// </summary>
    public partial class Page_QuizInfo : UserControl
    {
        public Category current_category { get; set; }
        MainWindow mainwindow;
        Page_QuizQuestions page_quizquestions;
        public Page_QuizInfo(MainWindow main)
        {
            InitializeComponent();
            mainwindow = main;
            page_quizquestions = new Page_QuizQuestions(main);
        }

        public void UpdateInfo()
        {
            LB_QuizName.Content = "Quiz "+current_category.Name;
            Category_IMG.Source = new BitmapImage(new Uri(current_category.ImageUrl, UriKind.Relative));
            LB_Date.Content = DateTime.Now.ToString("dd/MM/yyyy");
            LB_Time.Content = current_category.Time.ToString();
            LB_Points.Content = current_category.Points.ToString() + " Points";
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            mainwindow.Grid_Content.Children.Clear();
            page_quizquestions.current_category = current_category;
            page_quizquestions.Image_Test.Source = new BitmapImage(new Uri(current_category.ImageUrl, UriKind.Relative));
            page_quizquestions.UpdateInfo(true);
            mainwindow.Grid_Content.Children.Add(page_quizquestions);
        }
    }
}
