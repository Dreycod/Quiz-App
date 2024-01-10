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

        static public Dictionary<string, int> categories = new Dictionary<string, int>()
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

        public CategoryController()
        {
            foreach (KeyValuePair<string, int> entry in categories)
            {
                Category category = new Category();
                category.Name = entry.Key;
                category.Content = entry.Key;
                category.ImageUrl = "/Ressources/Images/Categories/" + entry.Key + ".jpg";
                category.ID = entry.Value;
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
