using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ParseStarterProject.Common
{
    public class ResizeImageManager
    {
        public static bool GetActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(ActiveProperty);
        }

        public static void SetActive(DependencyObject obj, bool value)
        {
            obj.SetValue(ActiveProperty, value);
        }

        // Using a DependencyProperty as the backing store for Active.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActiveProperty =
            DependencyProperty.RegisterAttached("Active", typeof(bool), typeof(ResizeImageManager), new PropertyMetadata(false, OnActiveChanged));

        private static void OnActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var image = d as Image;

            if (image != null)
            {
                if ((bool)e.NewValue)
                {
                    image.Tapped += image_Tapped;
                }
                else
                {
                    image.Tapped -= image_Tapped;
                }
            }


        }

        static void image_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var image = sender as Image;

            image.Height += 10;
            image.Width += 10;


        }


    }
}
