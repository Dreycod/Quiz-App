using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.Model
{
    public class Achievement
    {
        public string Name { get; set; }
        public bool isAchievementUnlocked { get; set; }
        public int Requirements { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
    }
}
