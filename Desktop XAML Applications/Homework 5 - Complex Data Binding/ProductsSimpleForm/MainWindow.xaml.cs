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
using Products.Models;

namespace ProductsSimpleForm
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            var input = textBoxProductId.Text;
            bool isNumber = int.TryParse(input, out id);
            if (isNumber)
            {
                var dataContext = this.GetDataContext();
                dataContext.GetCurrentProduct(id);
            }
            else
            {
                MessageBox.Show("Invalid product id input!");
                textBoxProductId.Text = "1";
            }

        }

        private CurrentProductModelView GetDataContext()
        {
            var dataContext = this.DataContext;
            return dataContext as CurrentProductModelView;
        }
    }
}
