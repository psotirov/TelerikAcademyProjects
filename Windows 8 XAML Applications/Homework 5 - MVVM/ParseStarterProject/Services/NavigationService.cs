﻿using ParseStarterProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ParseStarterProject.Services
{
    public class NavigationService : INavigationService
    {
        private Type GetViewType(Views view)
        {
            switch (view)
            {
                case Views.Login:
                    return typeof(MainPage);
                case Views.Updates:
                    return typeof(UpdatesPage);
                case Views.Toasts:
                    return typeof(ToastsPage);
                    break;
                case Views.Profile:
                    return typeof(ProfilePage);
                    break;
                default:
                    break;
            }

            return null;
        }

        public void Navigate(Views sourcePageType)
        {
            var pageType = this.GetViewType(sourcePageType);

            if (pageType != null)
            {

                ((Frame)Window.Current.Content).Navigate(pageType);
            }
        }

        public void Navigate(Views sourcePageType, object parameter)
        {
            var pageType = this.GetViewType(sourcePageType);

            if (pageType != null)
            {
                ((Frame)Window.Current.Content).Navigate(pageType, parameter);
            }
        }

        public void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
