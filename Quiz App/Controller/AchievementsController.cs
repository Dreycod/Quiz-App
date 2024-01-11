using Quiz_App.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.Controller
{
    public class AchievementsController
    {

        List<Achievement> listAchievements = new List<Achievement>();

        static public Dictionary<string, int> achievements = new Dictionary<string, int>()
        {
            {"Fresh Start", 1},
            {"Adept", 5},
            {"Speedrunner", 1}
        };

        static public Dictionary<string, string> listAchievementsContent = new Dictionary<string, string>()
        {
            {"Fresh Start", "Complete your first quiz"},
            {"Adept", "Complete 5 quizzes"},
            {"Speedrunner", "Complete a quiz in less than 1 minute"}
        };

        public AchievementsController()
        {

        }

        public AchievementsController(PlayerController playerController)
        {
            foreach (KeyValuePair<string, int> entry in achievements)
            {
                Achievement achievement = new Achievement();
                achievement.Name = entry.Key;
                achievement.Requirements = entry.Value;
                achievement.isAchievementUnlocked = true;
                achievement.Content = listAchievementsContent[entry.Key];
                if (achievement.isAchievementUnlocked == true)
                {
                    achievement.ImageUrl = "/Ressources/Images/Achievements/Silver.png";
                    playerController.GetPlayer().Achievements.Add(achievement);
                }
                else
                {
                    achievement.ImageUrl = "/Ressources/Images/Achievements/Black.png";
                }

                listAchievements.Add(achievement);
            }
        }

        public List<Achievement> GetListAchievements()
        {
            return listAchievements;
        }

    }
}
