using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Async_Prime_Numbers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void CalculatePrimesClick(object sender, RoutedEventArgs e)
        {
            var btnCalculate = sender as Button;
            if (btnCalculate == null)
            {
                return;
            }
            btnCalculate.IsEnabled = false;

            var panel = btnCalculate.Parent as StackPanel;
            var startContainer = panel.Children[1] as TextBox;
            int start = 0;
            if (startContainer != null)
            {
                int.TryParse(startContainer.Text, out start);
            }

            var endContainer = panel.Children[3] as TextBox;
            int end = start + 1000;
            if (endContainer != null)
            {
                int.TryParse(endContainer.Text, out end);
            }

            var toggle = panel.Children[4] as ToggleSwitch;
            bool showPrimesOnly = (endContainer != null) ? showPrimesOnly = toggle.IsOn : true;

            var result = ((panel.Parent as StackPanel).Children[1] as ScrollViewer).Content as TextBlock;
            if (result == null)
            {
                return;
            }

            result.Text = "working...";
            var primes = await PrimesCalculator.GetPrimesConcatenationsAsync(start, end, showPrimesOnly);

            result.Text = await primes.JoinAsStringAsync<int>(", ");
            btnCalculate.IsEnabled = true;
        }
    }
}
