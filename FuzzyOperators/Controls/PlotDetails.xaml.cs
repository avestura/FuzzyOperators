using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FuzzyOperators.Controls
{
    /// <summary>
    /// Interaction logic for PlotDetails.xaml
    /// </summary>
    public partial class PlotDetails : UserControl
    {
        PlotDetailsViewModel details = new PlotDetailsViewModel();

        private Color HeaderBackgroundUnchecked = (Color)ColorConverter.ConvertFromString("#dee1e2");
        private Color HeaderBorderUnchecked = (Color)ColorConverter.ConvertFromString("#cacdce");
        private Color HeaderBackgroundChecked = (Color)ColorConverter.ConvertFromString("#92e59e");
        private Color HeaderBorderChecked = (Color)ColorConverter.ConvertFromString("#bdefc4");

        private Brush HeaderBackgroundUncheckedBrush = new SolidColorBrush();
        private Brush HeaderBorderUncheckedBrush = new SolidColorBrush();
        private Brush HeaderBackgroundCheckedBrush = new SolidColorBrush();
        private Brush HeaderBorderCheckedBrush = new SolidColorBrush();

        public CheckBox CheckBox { get { return check; } }

        public string FuncName { get; set; }

        public PlotDetails()
        {
            InitializeComponent();
            DataContext = details;
        }

        public string Title { get { return details.Title; } set { details.Title = value; } }



        public PlotModel PlotModel
        {
            get { return details.PlotViewModel; }
            set { details.PlotViewModel = value; }
        }
 


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
             HeaderBackgroundUncheckedBrush = new SolidColorBrush(HeaderBackgroundUnchecked);
             HeaderBorderUncheckedBrush = new SolidColorBrush(HeaderBorderUnchecked);
             HeaderBackgroundCheckedBrush = new SolidColorBrush(HeaderBackgroundChecked);
             HeaderBorderCheckedBrush = new SolidColorBrush(HeaderBorderChecked);

             details.HeaderBackground = HeaderBackgroundUncheckedBrush;
             details.HeaderBorder = HeaderBorderUncheckedBrush;


            var plotController = new PlotController();
            plotController.UnbindMouseWheel();

            MainPlotView.Controller = plotController;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            details.HeaderBackground = HeaderBackgroundCheckedBrush;
            details.HeaderBorder = HeaderBorderCheckedBrush;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            details.HeaderBackground = HeaderBackgroundUncheckedBrush;
            details.HeaderBorder = HeaderBorderUncheckedBrush;
        }
    }

    class PlotDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Brush headerBackground = new SolidColorBrush();
        private Brush headerBorder     = new SolidColorBrush();
        private string title = "";
        private PlotModel plotModel;

        public Brush HeaderBackground {
            get { return headerBackground; }
            set { headerBackground = value; OnPropertyChanged("HeaderBackground"); }
        }
        public Brush HeaderBorder {
            get { return headerBorder; }
            set { headerBorder = value; OnPropertyChanged("HeaderBorder"); }
        }

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }

        public PlotModel PlotViewModel {
            get { return plotModel; }
            set { plotModel = value; OnPropertyChanged("PlotViewModel"); }

        }

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
