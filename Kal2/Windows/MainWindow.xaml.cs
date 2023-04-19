using Kal2.Data;
using Kal2.Pages;
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
using System.Windows.Shapes;

namespace Kal2.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Employee User)
        {
            InitializeComponent();
            string UserFullName = User.LastName.ToString() + " " + User.FirstName.ToString();
            this.UserName.Content = $"Добро пожаловать, {UserFullName}";
            switch (User.EmployeeRole)
            {
                case 1: MainFrame.Navigate(new Uri("Pages/AdminPage.xaml", UriKind.Relative));
                        break;
                case 6: MainFrame.Navigate(new Uri("Pages/UserPage.xaml", UriKind.Relative));
                        break;
            }
        }
    }
}
