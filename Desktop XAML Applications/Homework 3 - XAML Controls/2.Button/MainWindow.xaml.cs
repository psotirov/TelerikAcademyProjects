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

namespace _2.Button
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int clickClount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClicker_Click(object sender, RoutedEventArgs e)
        {
            clickClount++;
            lblClicker.Content = string.Format("Button clicked {0} times.", clickClount);
        }
    }
}
