using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.Model
{
    public class Question
    {
        private string Type;
        private string Difficulty;
        private string Category;
        private string QuestionText;
        private string CorrectAnswer;
        private List<string> IncorrectAnswers;

        public Question(string type, string difficulty, string category, string questionText, string correctAnswer, List<string> incorrectAnswers)
        {
            Type = type;
            Difficulty = difficulty;
            Category = category;
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            IncorrectAnswers = incorrectAnswers;
        }
    }
}
