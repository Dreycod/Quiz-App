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

        public PlayerController playercontroller;
        CategoryController categoryController;
        AchievementsController achievementsController;

        public Page_Dashboard page_dashboard;
        Page_ExtraTopic page_extratopic;
        Page_Achievements page_achievement;
        Page_Configurations page_configurations;

        String AudioPathClickSFX = "Ressources/Sounds/ClickSFX.mp3";
        String AudioPathWinSFX = "Ressources/Sounds/WinSFX.mp3";

        String AudioPathBGM = "Ressources/Sounds/se-no-bi.mp3";
        MediaPlayer ClickSFX;
        MediaPlayer BGM;

        public MainWindow()
        {
            InitializeComponent();

            ClickSFX = new MediaPlayer();
            BGM = new MediaPlayer();

            BGM.Volume = 0.1; 
            BGM.Open(new Uri(AudioPathBGM, UriKind.Relative));
            BGM.Play();

            playercontroller = new PlayerController();
            categoryController = new CategoryController();
            achievementsController = new AchievementsController(playercontroller);

            page_dashboard = new Page_Dashboard(playercontroller,categoryController);
            page_extratopic = new Page_ExtraTopic(this);
            page_achievement = new Page_Achievements(achievementsController);
            page_configurations = new Page_Configurations(playercontroller,page_dashboard);

            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_dashboard);
        }

        private void DashboardBTN_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSFX();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_dashboard);
        }

        private void AchievementsBTN_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSFX();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_achievement);
        }

        private void CategoryBTN_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSFX();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_extratopic);
        }

        private void ConfigurationBTN_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSFX();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_configurations);
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            (string,List<int>,double,List<Achievement>) listData = playercontroller.GetDashBoardInfo();
            string Json = JsonConvert.SerializeObject(listData);
            //File.WriteAllText("Ressources/Data.json", Json);
            Close();
        }
        private void PlayClickSFX() // Function to play the music
        {
            ClickSFX.Volume = 1.0;
            ClickSFX.Open(new Uri(AudioPathClickSFX, UriKind.Relative));
            ClickSFX.Play();

        }
    }
}
