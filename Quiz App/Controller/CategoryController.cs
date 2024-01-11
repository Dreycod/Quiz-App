using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Quiz_App.Model;
namespace Quiz_App.Controller
{
    class CategoryController
    {
        List<Category> listCategory = new List<Category>();

        // List Int ID,Time,Points

        public Dictionary<string, List<int>> categories = new Dictionary<string, List<int>>()
        {
            {"General Knowledge", new List<int>(){9,10,100}},
            {"Books", new List<int>(){10,10,100}},
            {"Film", new List<int>(){11,10,100}},
            {"Music", new List<int>(){12,10,100}},
            {"Musicals & Theatres", new List<int>(){13,10,100}},
            {"Television", new List<int>(){14,10,100}},
            {"Video Games", new List<int>(){15,10,100}},
            {"Board Games", new List<int>(){16,10,100}},
            {"Science & Nature", new List<int>(){17,10,100}},
            {"Computers", new List<int>(){18,10,100}},
            {"Mathematics", new List<int>(){19,10,100}},
            {"Mythology", new List<int>(){20,10,100}},
            {"Sports", new List<int>(){21,10,100}},
            {"Geography", new List<int>(){22,10,100}},
            {"History", new List<int>(){23,10,100}},
            {"Politics", new List<int>(){24,10,100}},
            {"Art", new List<int>(){25,10,100}},
            {"Celebrities", new List<int>(){26,10,100}},
            {"Animals", new List<int>(){27,10,100}},
            {"Vehicles", new List<int>(){28,10,100}},
            {"Comics", new List<int>(){29,10,100}},
            {"Gadgets", new List<int>(){30,10,100}},
            {"Anime & Manga", new List<int>(){31,10,100}},
            {"Cartoon & Animations", new List<int>(){32,10,100}}
        };

        public CategoryController()
        {
            foreach (KeyValuePair<string, List<int>> entry in categories)
            {
                Category category = new Category();
                category.Name = entry.Key;
                category.Content = entry.Key;
                category.ImageUrl = "/Ressources/Images/Categories/" + entry.Key + ".jpg";
                category.ID = entry.Value[0];
                category.Time = entry.Value[1];
                category.Points = entry.Value[2];
                listCategory.Add(category);
            }
        }

        public List<Category> GetListCategory()
        {
            return listCategory;
        }
        
        public Category GetCategory(string name)
        {
            foreach (Category category in listCategory)
            {
                if (category.Name == name)
                {
                    return category;
                }
            }
            return null;
        }
    }
}
