using LibrarianWorkplace.Class;
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

namespace LibrarianWorkplace.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private bool AuthCheck(string login, string password)
        {
            int errors = 0;
            try
            {
                foreach (var employee in LibraryEntities.GetContext().Employee.ToList())
                {
                    if(login == employee.login && password == employee.password)
                    {
                        errors = 0;
                        break;
                    }
                    else
                        errors++;
                }
                if (errors == 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Не верно введён логин или пароль");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в подключении БД");
                return false;
            }
            return false;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if(AuthCheck(tbLogin.Text, pbPassword.Password))
            {
                NavigationClass.mainFrame.Navigate(new CatalogPage());
            }
        }
    }
}
