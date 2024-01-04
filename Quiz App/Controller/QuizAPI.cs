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
                    return root;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
