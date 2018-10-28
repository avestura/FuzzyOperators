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
using FuzzyOperators.Models;
using FuzzyOperators.Pages;
using OxyPlot;

namespace FuzzyOperators
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public Frame Frame { get { return MainFrame; } }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new PlotModels();
            MainFrame.Navigate(new SelectPlots());
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            MainFrame.MarginFadeInAnimation(
                from:     new Thickness(0),
                to:       new Thickness(20, 0, 0, 0),
                duration: TimeSpan.FromMilliseconds(500)
                );
        }
    }
}
