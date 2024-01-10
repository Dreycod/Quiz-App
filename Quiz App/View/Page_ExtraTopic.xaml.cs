using Quiz_App.Controller;
using Quiz_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_App.View
{
    /// <summary>
    /// Interaction logic for Page_ExtraTopic.xaml
    /// </summary>
    public partial class Page_ExtraTopic : UserControl
    {
        CategoryController categoryController { get; set; }
        List<Category> Ls_Category = new List<Category>();

        public Page_ExtraTopic()
        {
            InitializeComponent();
            categoryController = new CategoryController();
            Ls_Category = categoryController.GetListCategory();

            LV_Categories.ItemsSource = Ls_Category;
        }
    }
}
