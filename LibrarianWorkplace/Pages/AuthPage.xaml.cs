using LibrarianWorkplace.Class;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LibrarianWorkplace.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    
   
    public partial class AuthPage : Page
    {
        LibraryEntitiess db;
        public AuthPage()
        {
            InitializeComponent();
            db = new LibraryEntitiess();
            dGridHistory.ItemsSource = db.AuthHistory.ToList();

        }

        private bool AuthCheck(string login, string password)
        {
            int errors = 0;
            try
            {
                foreach (var employee in LibraryEntitiess.GetContext().Employee.ToList())
                {
                    if (login == employee.login && password == employee.password)
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

            /*История входов*/
            AuthHistory history = new AuthHistory();
            Employee admins = new Employee();
            try
            {
                DataContext = admins;
                DateTime currentTime = DateTime.Now;
                string formattedTime =  currentTime.ToString("H:m:s");
                history.Time = Convert.ToDateTime(formattedTime);
                history.idEmployee = admins.idEmployee;
                LibraryEntitiess.GetContext().AuthHistory.Add(history);
                LibraryEntitiess.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка записи в историю");
            }
            return false;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (AuthCheck(tbLogin.Text, pbPassword.Password))
            {
                NavigationClass.mainFrame.Navigate(new CatalogPage());
            }
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            spAuth.Visibility = Visibility.Hidden;
            spInfo.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Visible;
            btnInfo.Visibility = Visibility.Hidden;
        }

        private void btnInfoDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Система предназначена для автоматизации работчего места библиотекаря\nРазработчик: Васильченко Дарья Александровна\nГруппа 29-КД9-3ИНС");
        }

        private void btnInfoHistory_Click(object sender, RoutedEventArgs e)
        {
            stHistory.Visibility = Visibility.Visible;

            btnInfoDeveloper.Visibility = Visibility.Hidden;
            btnInfoHistory.Visibility = Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            spInfo.Visibility = Visibility.Hidden;
            spAuth.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Hidden;
            btnInfo.Visibility = Visibility.Visible;

            stHistory.Visibility = Visibility.Hidden;
        }
    }
}