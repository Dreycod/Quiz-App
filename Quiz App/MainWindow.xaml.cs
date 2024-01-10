using Quiz_App.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Quiz_App.Controller;
using Quiz_App.Model;
using System.Reflection.Emit;

namespace Quiz_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Page_Dashboard dashboard = new Page_Dashboard();
            Grid_Content.Children.Add(dashboard);
        }

        //listview clickable event handler itemselected for category
        //private void LV_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Category category = (Category)dashboard.LV_Categories.SelectedItem;
        //    StringCategory = category.Content;
        //    MessageBox.Show(StringCategory);
        //}


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
