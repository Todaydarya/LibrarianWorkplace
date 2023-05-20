using LibrarianWorkplace.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();
        }
         /*private void importImage()
         {
            var image = Directory.GetFiles(@"E:\LibraryImage");

            foreach (var file in image)
            {
                var data = file.Split('\t');
                var tempTour = new Books
                {
                    Name = data[0].Replace("\"", "")
                };

                try
                {
                    tempTour.image = File.ReadAllBytes(image.FirstOrDefault(p => p.Contains(tempTour.Name)));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                LibraryEntities.GetContext().Books.Add(tempTour);
                LibraryEntities.GetContext().SaveChanges();
            }
         }*/

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            CatalogStackPanel.Visibility = Visibility.Hidden;
            ProfileStackPanel.Visibility = Visibility.Visible;
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

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            CatalogStackPanel.Visibility = Visibility.Visible;
            ProfileStackPanel.Visibility = Visibility.Hidden;
        }
    }
}
