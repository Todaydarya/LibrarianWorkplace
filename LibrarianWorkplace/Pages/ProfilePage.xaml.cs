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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.mainFrame.Navigate(new CatalogPage());
        }

        private void btnDocumentation_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.mainFrame.Navigate(new DocumentationPage());
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.mainFrame.Navigate(new StatisticsPage());
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.mainFrame.Navigate(new ImportPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.mainFrame.Navigate(new AddEditBookPage());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
