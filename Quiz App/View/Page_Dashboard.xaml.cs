using Microsoft.Win32;
using Quiz_App.Controller;
using Quiz_App.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
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
    /// Logique d'interaction pour Page_Dashboard.xaml
    /// </summary>
    public partial class Page_Dashboard : UserControl
    {
        PlayerController playercontroller;
        CategoryController categoryController;
        public Page_Dashboard(PlayerController plr_c,CategoryController cat_c)
        {
            InitializeComponent();
            playercontroller = plr_c;
            categoryController = cat_c;
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            List<Category> Ls_Category = new List<Category>();
            Ls_Category.Add(categoryController.GetCategory("General Knowledge"));
            Ls_Category.Add(categoryController.GetCategory("Computers"));
            Ls_Category.Add(categoryController.GetCategory("Anime & Manga"));
            Ls_Category.Add(categoryController.GetCategory("History"));
            (string, List<int>, double, List<Achievement>) GeneralInfo = playercontroller.GetDashBoardInfo();

            LB_Username.Content = GeneralInfo.Item1;
            LB_Level.Content = "Lvl." + GeneralInfo.Item2[0].ToString();
            LB_Victories.Content = "Victories: "+GeneralInfo.Item2[1];
            PB_Player.Maximum = GeneralInfo.Item2[2];
            PB_Player.Value = GeneralInfo.Item2[3];
            LB_Answers.Content = "Correct Answers: "+GeneralInfo.Item2[4];
            LB_Time.Content = "Fastest Time: "+GeneralInfo.Item3;
            LV_Achievements.ItemsSource = GeneralInfo.Item4;
            LV_Categories.ItemsSource = Ls_Category;
        }

        private void UploadPfpButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select Profile Picture";
            op.Filter = "Image files (*.png)|*.png;";
            if (op.ShowDialog() == true)
            {
                ProfilePicture.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

    }
}
