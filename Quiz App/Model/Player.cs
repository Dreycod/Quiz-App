using Quiz_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_App.Model;

namespace Quiz_App.Model
{
    public class Player
    {
        public string Username { get; set;}
        public int Level { get; set; }
        public int Exp { get; set; }

        public int MaxExp { get; set;}
        public int Wins { get; set; }
        public List<Achievement> Achievements { get; set;}
        public double FastestTime { get; set; }
        public int CorrectAnswers { get; set; }
        public string ImageUrl { get; set; }
        public string quizDifficulty { get; set; }
        public int quizQuestionAmount { get; set; }
    }
}
