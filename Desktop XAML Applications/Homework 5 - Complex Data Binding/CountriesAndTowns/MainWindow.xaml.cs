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
using ViewModels;

namespace CountriesAndTowns
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

        private void OnPrevButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.Prev();
        }

        private void OnNextButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.Next();
        }

        private void OnPrevTownButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.PrevTown();
        }

        private void OnNextTownButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.NextTown();
        }

        private CountriesAndTownsViewModel GetDataContext()
        {
            var dataContext = this.DataContext;
            return dataContext as CountriesAndTownsViewModel;
        }
    }
}
