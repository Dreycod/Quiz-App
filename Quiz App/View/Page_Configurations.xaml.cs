using Quiz_App.Controller;
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
using Quiz_App.Model;

namespace Quiz_App.View
{
    /// <summary>
    /// Interaction logic for Page_Configurations.xaml
    /// </summary>
    public partial class Page_Configurations : UserControl
    {
        PlayerController playercontroller;
        Page_Dashboard page_dashboard;

        public Page_Configurations(PlayerController player_controller, Page_Dashboard p_dash)
        {
            InitializeComponent();
            playercontroller = player_controller;   
            page_dashboard = p_dash;
        }

        private void QDecr_AmountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(LB_Question_Amount.Content.ToString()) > 1)
            {
                LB_Question_Amount.Content = (int.Parse(LB_Question_Amount.Content.ToString()) - 1).ToString();
            }

            Player player = playercontroller.GetPlayer();
            player.quizQuestionAmount = int.Parse(LB_Question_Amount.Content.ToString());
        }

        private void QIncr_AmountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(LB_Question_Amount.Content.ToString()) < 30)
            {
                LB_Question_Amount.Content = (int.Parse(LB_Question_Amount.Content.ToString()) + 1).ToString();
            }

            Player player = playercontroller.GetPlayer();
            player.quizQuestionAmount = int.Parse(LB_Question_Amount.Content.ToString());
        }

        private void QDecr_DifficultyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LB_Quiz_Difficulty.Content.ToString() == "Easy")
                LB_Quiz_Difficulty.Content = "Hard";
            else if (LB_Quiz_Difficulty.Content.ToString() == "Medium")
                LB_Quiz_Difficulty.Content = "Easy";
            else if (LB_Quiz_Difficulty.Content.ToString() == "Hard")
                LB_Quiz_Difficulty.Content = "Medium";

            Player player = playercontroller.GetPlayer();
            player.quizDifficulty = LB_Quiz_Difficulty.Content.ToString();

        }

        private void QIncr_DifficultyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LB_Quiz_Difficulty.Content.ToString() == "Easy")
                LB_Quiz_Difficulty.Content = "Medium";
            else if (LB_Quiz_Difficulty.Content.ToString() == "Medium")
                LB_Quiz_Difficulty.Content = "Hard";
            else if (LB_Quiz_Difficulty.Content.ToString() == "Hard")
                LB_Quiz_Difficulty.Content = "Easy";

        }

        private void ResetName_BTN_Click(object sender, RoutedEventArgs e)
        {
            TB_PlayerChosenName.Text = "Default";
            playercontroller.SetUsername(TB_PlayerChosenName.Text);
            
            Player plr = playercontroller.GetPlayer();
            MessageBox.Show("Your name has been reset to " + plr.Username);
            page_dashboard.UpdateInfo();
        }

        private void ConfirmName_BTN_Click(object sender, RoutedEventArgs e)
        {
            playercontroller.SetUsername(TB_PlayerChosenName.Text);
            Player plr = playercontroller.GetPlayer();
            MessageBox.Show("Your name has been set to " + plr.Username);

            page_dashboard.UpdateInfo();

        }
    }
}
