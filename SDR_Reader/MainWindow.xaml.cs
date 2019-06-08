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
using OxyPlot;
using OxyPlot.Series;

namespace SDR_Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AsyncObservableCollection<RawTrade> _RawTrades = new AsyncObservableCollection<RawTrade>();

        public AsyncObservableCollection<RawTrade> RawTrades
        {
            get { return _RawTrades; }
        }

        public PlotModel Model { get; private set; }

        public MainWindow()
        {
            // create plot model
            var tmp = new PlotModel();

            // make a line series of demo chart data
            var chartseries = new LineSeries { Title = "Demo Data", MarkerType = MarkerType.Circle };

            // make a random generator and some chart data
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                chartseries.Points.Add(new DataPoint(i, rnd.NextDouble()));
            }
            tmp.Series.Add(chartseries);

            this.Model = tmp;

            InitializeComponent();

            _RawTrades.Add(new RawTrade()
            {
                Id = 1,
                Direction = "BUY",
                Quantity = 50,
                Market = "ICE WTI CRUDE OIL",
                Product = "DECEMBER 2019 FUTURES",
                Price = 58.25
            });
        }

        private void listRawTrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblTradeDetail.Content = "A trade was selected!";
        }
    }

    public class RawTrade
    {
        public int Id { get; set; }
        public string Direction { get; set; }
        public double Quantity { get; set; }
        public string Market { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
    }
}
