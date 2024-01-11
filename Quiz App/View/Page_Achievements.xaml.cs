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
    /// Interaction logic for Page_Achievements.xaml
    /// </summary>
    public partial class Page_Achievements : UserControl
    {
        List<Achievement> Ls_Achievement;

        public Page_Achievements(AchievementsController achievementsController)
        {
            InitializeComponent();

            Ls_Achievement = new List<Achievement>();
            Ls_Achievement = achievementsController.GetListAchievements();
            LV_Achievements.ItemsSource = Ls_Achievement;

        }
    }
}

