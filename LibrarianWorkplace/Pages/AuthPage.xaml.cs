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

        AuthHistory history = new AuthHistory();
        private bool AuthCheck(string login, string password)
        {
            int errors = 0;
            try
            {
                foreach (var employee in LibraryEntities.GetContext().Employee.ToList())
                {
                    if(login == employee.login && password == employee.password)
                    {
                        foreach (var history in LibraryEntities.GetContext().AuthHistory.ToList())
                        {
                            try
                            {
                                DataContext = employee;
                                history.Time = DateTime.Now;
                                history.Employee.Name = employee.Name;
                                LibraryEntities.GetContext().AuthHistory.Add(history);
                                LibraryEntities.GetContext().SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка записи в историю");
                            }
                        }
                        
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

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            spAuth.Visibility= Visibility.Hidden;
            spInfo.Visibility= Visibility.Visible;

            btnBack.Visibility= Visibility.Visible;
            btnInfo.Visibility= Visibility.Hidden;
        }

        private void btnInfoDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Система предназначена для автоматизации работчего места библиотекаря\nРазработчик: Васильченко Дарья Александровна\nГруппа 29-КД9-3ИНС");
        }

        private void btnInfoHistory_Click(object sender, RoutedEventArgs e)
        {
            stHistory.Visibility= Visibility.Visible;

            btnInfoDeveloper.Visibility= Visibility.Hidden;
            btnInfoHistory.Visibility= Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            spInfo.Visibility= Visibility.Hidden;
            spAuth.Visibility= Visibility.Visible;

            btnBack.Visibility = Visibility.Hidden;
            btnInfo.Visibility = Visibility.Visible;

            stHistory.Visibility = Visibility.Hidden;
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
