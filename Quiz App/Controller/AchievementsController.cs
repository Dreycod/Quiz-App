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

        static public Dictionary<string, List<int>> achievements = new Dictionary<string, List<int>>()
        {
            {"Fresh Start", new List<int>() {1, 2} },
            {"Adept", new List<int>() {5, 1} },
            {"Speedrunner", new List<int>() {1, 3} },
            {"Tryharder", new List<int>() {100, 2} }
        };

        static public Dictionary<string, string> listAchievementsRarity = new Dictionary<string, string>()
        {
            {"Fresh Start", "/Ressources/Images/Achievements/Silver.png"},
            {"Adept", "/Ressources/Images/Achievements/Silver.png"},
            {"Speedrunner", "/Ressources/Images/Achievements/Gold.png"},
            {"Tryharder", "/Ressources/Images/Achievements/Gold.png"},
        };

        static public Dictionary<string, string> listAchievementsContent = new Dictionary<string, string>()
        {
            {"Fresh Start", "Complete your first quiz"},
            {"Adept", "Reach level 5"},
            {"Speedrunner", "Complete a quiz in less than 1 minute"},
            {"Tryharder", "Complete 100 quizzes"},
        };

        static public Dictionary<int, string> listRequirements = new Dictionary<int, string>()
        {
            {1, "Level"},
            {2, "Wins"},
            {3, "FastestTime"},
            {4, "CorrectAnswers"}
        };

        public AchievementsController(PlayerController playerController)
        {
            Player player = playerController.GetPlayer();

            foreach (KeyValuePair<string, List<int>> entry in achievements)
            {
                Achievement achievement = new Achievement();
                achievement.Name = entry.Key;
                achievement.Requirements = entry.Value[0];
                achievement.RequirementType = GetAchievementTypeByID(entry.Value[1]);
                achievement.Content = listAchievementsContent[entry.Key];

                var property = typeof(Player).GetProperty(achievement.RequirementType);

                var playerValue = property.GetValue(player);

                if (playerValue is int intValue)
                {
                    achievement.isAchievementUnlocked = intValue >= achievement.Requirements;
                }
                else if (playerValue is double doubleValue)
                {
                    achievement.isAchievementUnlocked = doubleValue >= achievement.Requirements;
                }

                if (achievement.isAchievementUnlocked == true)
                {
                    achievement.ImageUrl = listAchievementsRarity[entry.Key];
                    playerController.GetPlayer().Achievements.Add(achievement);
                }
                else
                {
                    achievement.ImageUrl = "/Ressources/Images/Achievements/Black.png";
                }

                listAchievements.Add(achievement);
            }
        }

        public void CheckAchievements(PlayerController playerController)
        {
            Player player = playerController.GetPlayer();
            
            foreach (Achievement achievement in listAchievements)
            {
                player.Achievements.Remove(achievement);

                var property = typeof(Player).GetProperty(achievement.RequirementType);

                var playerValue = property.GetValue(player);

                if (playerValue is int intValue)
                {
                    achievement.isAchievementUnlocked = intValue >= achievement.Requirements;
                }
                else if (playerValue is double doubleValue)
                {
                    achievement.isAchievementUnlocked = doubleValue >= achievement.Requirements;
                }

                if (achievement.isAchievementUnlocked == true)
                {
                    achievement.ImageUrl = listAchievementsRarity[achievement.Name];
                    playerController.GetPlayer().Achievements.Add(achievement);
                }
                else
                {
                    achievement.ImageUrl = "/Ressources/Images/Achievements/Black.png";
                }
            }
        }

        public string GetAchievementTypeByID(int ID)
        {
            foreach (KeyValuePair<int, string> entry in listRequirements)
            {
                if (entry.Key == ID)
                {
                    return entry.Value;
                }
            }
            return "";
        }

        public List<Achievement> GetListAchievements()
        {
            return listAchievements;
        }
    }
}
