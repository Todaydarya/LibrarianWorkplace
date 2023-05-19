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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibrarianWorkplace.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private LibraryEntities _context = new LibraryEntities();
        public StatisticsPage()
        {
            InitializeComponent();
            ChartStatistics.ChartAreas.Add(new ChartArea());

            var currentSeries = new Series()
            {
                IsValueShownAsLabel= true,
            };
            ChartStatistics.Series.Add(currentSeries);

            cbChart.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
        }

        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            if(cbChart.SelectedItem is SeriesChartType currentType)
            {
                Series currentSeries = ChartStatistics.Series.FirstOrDefault();
                currentSeries.ChartType = currentType;
                currentSeries.Points.Clear();

                var CountBookList = _context.Books.ToList();
                foreach (var CountBook in CountBookList)
                {
                    currentSeries.Points.AddXY(CountBook.Name, CountBook.Count);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.mainFrame.GoBack();
        }
    }
}
