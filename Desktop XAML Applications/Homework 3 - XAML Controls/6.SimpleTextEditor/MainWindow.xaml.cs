using System;
using System.IO;
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

namespace _6.SimpleTextEditor
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

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            tbEditArea.TextWrapping = (chkWordWrap.IsChecked == true) ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        private void cbFontSize_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)cbFontSize.SelectedItem;

            if (tbEditArea != null)
            {
                tbEditArea.FontSize = double.Parse(selectedItem.Content.ToString());                
            }
        }

        private void cbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)cbFontFamily.SelectedItem;

            if (tbEditArea != null)
            {
                tbEditArea.FontFamily = new FontFamily(selectedItem.Content.ToString());
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string filename = "test.txt";
            try
            {
                using (var sr = new StreamReader(filename))
                {
                    tbEditArea.Text = sr.ReadToEnd(); 
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Failed to load " + filename);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string filename = "test.txt";
            try
            {
                using (var sw = new StreamWriter(filename))
                {
                    sw.Write(tbEditArea.Text);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Failed to save " + filename);
            }
        }
    }
}
