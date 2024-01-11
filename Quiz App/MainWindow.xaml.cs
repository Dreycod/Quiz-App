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
        List<Achievement> Ls_Achievements = new List<Achievement>();
        List<Category> Ls_Category = new List<Category>();  

        PlayerController playercontroller;
        CategoryController categoryController;
        AchievementsController achievementsController;

        public Page_Dashboard page_dashboard;
        Page_ExtraTopic page_extratopic;
        Page_Achievements page_achievement;
       
        public MainWindow()
        {
            InitializeComponent();

            playercontroller = new PlayerController();
            categoryController = new CategoryController();
            achievementsController = new AchievementsController(playercontroller);

            page_dashboard = new Page_Dashboard();
            page_extratopic = new Page_ExtraTopic(this);
             
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_dashboard);

            Ls_Category.Add(categoryController.GetCategory("General Knowledge"));
            Ls_Category.Add(categoryController.GetCategory("Computers"));
            Ls_Category.Add(categoryController.GetCategory("Anime & Manga"));
            Ls_Category.Add(categoryController.GetCategory("History"));

            page_dashboard.UpdateInfo(playercontroller.GetDashBoardInfo(), Ls_Category);
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

        private void ExpButton_Click(object sender, RoutedEventArgs e)
        {
            playercontroller.AddExp(10);
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
