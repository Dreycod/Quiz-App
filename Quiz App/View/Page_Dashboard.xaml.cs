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
        public Page_Dashboard()
        {
            InitializeComponent();
        }

        public void UpdateInfo((string, List<int>, double, List<Achievement>) GeneralInfo, List<Category> categories)
        {
            LB_Username.Content = GeneralInfo.Item1;
            LB_Level.Content = "Lvl." + GeneralInfo.Item2[0].ToString();
            // LB_Wins.Content = GeneralInfo.Item2[1];
            PB_Player.Maximum = GeneralInfo.Item2[2];
            PB_Player.Value = GeneralInfo.Item2[3];
            // LB_CorrectAnswers.Content = GeneralInfo.Item2[4];
            // LB_FastestTime.Content = GeneralInfo.Item3;
            LV_Achievements.ItemsSource = GeneralInfo.Item4;
            LV_Categories.ItemsSource = categories;

        }

    }
}
