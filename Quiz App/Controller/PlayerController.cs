using Quiz_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace Quiz_App.Controller
{
    public class PlayerController
    {
        Player player = new Player();

        public PlayerController()
        {
            player.Username = "Default";
            player.Level = 1;
            player.Exp = 10;
            player.MaxExp = 20;
            player.Wins = 0;
            player.Achievements = new List<Achievement>();
            player.FastestTime = 0;
            player.CorrectAnswers = 0;
            player.ImageUrl = "/Ressources/Images/Player/Default.png";
            player.quizDifficulty = "Easy";
            player.quizQuestionAmount = 10;

            Achievement Achievement = new Achievement();
            Achievement.Content = "Win your first game";
            Achievement.ImageUrl = "/Ressources/Images/Achievements/Silver.png";
            player.Achievements.Add(Achievement);
        }

        public Player GetPlayer()
        {
            return player;
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public (string,List<int>,double,List<Achievement>) GetDashBoardInfo()
        {
            List<int> info = new List<int>();
            info.Add(player.Level);
            info.Add(player.Wins);
            info.Add(player.MaxExp);
            info.Add(player.Exp);
            info.Add(player.CorrectAnswers);
            return (player.Username,info,player.FastestTime,player.Achievements);
        }

        public void SetUsername(string username)
        {
            player.Username = username;
        }

        public void SetLevel(int level)
        {
            player.Level = level;
        }

        public void SetExp(int exp)
        {
            player.Exp = exp;
        }

        public void SetWins(int wins)
        {
            player.Wins = wins;
        }

        public void SetAchievements(List<Achievement> achievements)
        {
            player.Achievements = achievements;
        }

        public void SetFastestTime(double fastestTime)
        {
            player.FastestTime = fastestTime;
        }

        public void SetCorrectAnswers(int correctAnswers)
        {
            player.CorrectAnswers = correctAnswers;
        }

        public void AddAchievement(Achievement achievement)
        {
            player.Achievements.Add(achievement);
        }

        public void AddWin()
        {
            player.Wins++;
        }

        public void AddExp(int exp)
        {
            player.Exp += exp;
            if (player.Exp >= player.MaxExp)
            {
                player.MaxExp *= 2;
                player.Level++;
            }
        }

        public void AddCorrectAnswer()
        {
            player.CorrectAnswers++;
        }

    }
}
