using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.Model
{
    public class Category
    {
        private string Name;
        private int ID;

        public string Content { get; set; }
        public string ImageUrl { get; set; }

        private Dictionary<string, int> categories = new Dictionary<string, int>()
        {
            {"General Knowledge", 9},
            {"Books", 10},
            {"Film", 11},
            {"Music", 12},
            {"Musicals & Theatres", 13},
            {"Television", 14},
            {"Video Games", 15},
            {"Board Games", 16},
            {"Science & Nature", 17},
            {"Computers", 18},
            {"Mathematics", 19},
            {"Mythology", 20},
            {"Sports", 21},
            {"Geography", 22},
            {"History", 23},
            {"Politics", 24},
            {"Art", 25},
            {"Celebrities", 26},
            {"Animals", 27},
            {"Vehicles", 28},
            {"Comics", 29},
            {"Gadgets", 30},
            {"Anime & Manga", 31},
            {"Cartoon & Animations", 32}
        };

        public Category(string name)
        {
            Name = name;
            ID = categories[Name];
        }
    }
}
