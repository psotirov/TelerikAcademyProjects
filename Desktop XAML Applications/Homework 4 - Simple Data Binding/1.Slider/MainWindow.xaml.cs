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

namespace _1.Slider
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

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            sldFontSize.Value = sldFontSize.Minimum;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            sldFontSize.Value = sldFontSize.Maximum;
        }
    }
}
