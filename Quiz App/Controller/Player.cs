using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace Quiz_App.Controller
{
    internal class Player
    {
        private string Username;
        private int Level;
        private int Exp;
        private int MaxExp = 100;
        private int Wins;
        private List<string> Achievements = new List<string>();
        private double FastestTime;
        private int CorrectAnswers;

        public Player(string username, int level, int exp, int wins, List<string> achievements, double fastestTime, int correctAnswers)
        {
            Username = username;
            Level = level;
            Exp = exp;
            Wins = wins;
            Achievements = achievements;
            FastestTime = fastestTime;
            CorrectAnswers = correctAnswers;


        }

        public string GetUsername()
        {
            return Username;
        }

        public int GetLevel()
        {
            return Level;
        }

        public int GetExp()
        {
            return Exp;
        }

        public int GetMaxExp()
        {
            return MaxExp;
        }

        public int GetWins()
        {
            return Wins;
        }

        public List<string> GetAchievements()
        {
            return Achievements;
        }

        public double GetFastestTime()
        {
            return FastestTime;
        }

        public int GetCorrectAnswers()
        {
            return CorrectAnswers;
        }

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetLevel(int level)
        {
            Level = level;
        }

        public void SetExp(int exp)
        {
            Exp = exp;
        }

        public void SetWins(int wins)
        {
            Wins = wins;
        }

        public void SetAchievements(List<string> achievements)
        {
            Achievements = achievements;
        }

        public void SetFastestTime(double fastestTime)
        {
            FastestTime = fastestTime;
        }

        public void SetCorrectAnswers(int correctAnswers)
        {
            CorrectAnswers = correctAnswers;
        }

        public void AddAchievement(string achievement)
        {
            Achievements.Add(achievement);
        }

        public void AddWin()
        {
            Wins++;
        }

        public void AddExp(int exp)
        {
            Exp += exp;
            if (Exp >= MaxExp)
            {
                MaxExp *= 2;
                Level++;
            }
        }

        public void AddCorrectAnswer()
        {
            CorrectAnswers++;
        }

    }
}
