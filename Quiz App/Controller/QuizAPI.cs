using Quiz_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Quiz_App.Controller
{
    public class QuizAPI
    {
        // fait un dictionare de 2 string
        public Dictionary<string, string> characteres = new Dictionary<string, string>()
        {
            {"&quot;", "'" },
            {"&ouml;", "ö" },
            {"&#039;", "'" }
        };  
        public QuizAPI() 
        {

        }

        public async Task<Root> GetQuizRoot(int amount, int category, string difficulty, string type)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("https://opentdb.com/api.php?amount=" + amount + "&category=" + category + "&difficulty=" + difficulty + "&type=" + type);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(content);
                    // prend root.question et traduit avec characteres
                    foreach (var question in root.results)
                    {
                        question.question = Translate(question.question);
                        question.correct_answer = Translate(question.correct_answer);
                        for (int i = 0; i < question.incorrect_answers.Count; i++)
                        {
                            question.incorrect_answers[i] = Translate(question.incorrect_answers[i]);
                        }
                    }
                    return root;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Translate(string text)
        {
            foreach (KeyValuePair<string, string> entry in characteres)
            {
                text = text.Replace(entry.Key, entry.Value);
            }
            return text;
        }

    }
}
