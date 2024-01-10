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
using System.Reflection.Metadata;

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

        List<Achievement> Ls_Achievements = new List<Achievement>();
        List<Category> Ls_Category = new List<Category>();  

        PlayerController playercontroller;
        CategoryController categoryController;

        Page_Dashboard page_dashboard;
        Page_ExtraTopic page_extratopic;
        Page_Achievements page_achievement;
        public MainWindow()
        {
            InitializeComponent();

            playercontroller = new PlayerController();
            categoryController = new CategoryController();
            page_dashboard = new Page_Dashboard();
            page_extratopic = new Page_ExtraTopic(this);
            page_achievement = new Page_Achievements();
             
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_dashboard);

            Ls_Category.Add(categoryController.GetCategory("General Knowledge"));
            Ls_Category.Add(categoryController.GetCategory("Computers"));
            Ls_Category.Add(categoryController.GetCategory("Anime & Manga"));
            Ls_Category.Add(categoryController.GetCategory("History"));

            page_dashboard.UpdateInfo(playercontroller.GetDashBoardInfo(), Ls_Category);
        }

        //listview clickable event handler itemselected for category
        private void LV_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         //   Category category = (Category)dashboard.LV_Categories.SelectedItem;
           // StringCategory = category.Content;
            //MessageBox.Show(StringCategory);
        }

        private void DashboardBTN_Click(object sender, RoutedEventArgs e)
        {
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_dashboard);
        }

        private void AchievementsBTN_Click(object sender, RoutedEventArgs e)
        {
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_achievement);
        }

        private void CategoryBTN_Click(object sender, RoutedEventArgs e)
        {
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_extratopic);
        }

        private void ConfirmAnswersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExpButton_Click(object sender, RoutedEventArgs e)
        {
            playercontroller.AddExp(10);
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

        private void Dashboard_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
