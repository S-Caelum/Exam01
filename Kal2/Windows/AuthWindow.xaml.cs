using Kal2.Data;
using Kal2.Windows;
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

namespace Kal2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string PasswordValue = PasswordTextBox.Password;
            try
            {
                var User = DiagnosisEntities.getInstance().Employees.Where(p => p.AuthData1.AuthLogin == LoginTextBox.Text).First();
                if (User == null)
                {
                    MessageBox.Show("Введён неверный логин");
                }
                else
                {
                    if (User.AuthData1.AuthPassword == PasswordValue)
                    {
                        switch (User.EmployeeRole)
                        {
                            case 1: onSuccessfullSignIn(User);
                                    break;
                            case 6: onSuccessfullSignIn(User);
                                    break;
                        }
                    }
                    else
                        MessageBox.Show("Введён неверный пароль");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void onSuccessfullSignIn(Employee User)
        {
            MainWindow mainWindow = new MainWindow(User);
            mainWindow.Show();
            this.Close();
        }
    }
}
