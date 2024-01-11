using Quiz_App.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Quiz_App.Model
{
    public class Category
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get;set; }
        public int Time { get; set; }
        public int Points { get; set; }
    }
}
