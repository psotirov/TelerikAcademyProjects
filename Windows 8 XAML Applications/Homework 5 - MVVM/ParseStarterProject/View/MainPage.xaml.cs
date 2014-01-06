using Parse;
using ParseStarterProject.Services;
using ParseStarterProject.View;
using ParseStarterProject.ViewModel;
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

namespace ParseStarterProject
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

        public MainViewModel Model
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Authenticate();
        }

        private async void Authenticate()
        {

            ParseUser user = await ParseFacebookUtils.LogInAsync(webView, new[] { "user_about_me" });

            webView.Visibility = Visibility.Collapsed;

            if (user.IsNew)
            {
                var client = new Facebook.FacebookClient();
                client.AccessToken = ParseFacebookUtils.AccessToken;

                dynamic result = await client.GetTaskAsync("me");

                string firstName = result.first_name;

                string lastName = result.last_name;

                var photo = string.Format("http://graph.facebook.com/{0}.{1}/picture", firstName, lastName);

                user.Add("FirstName", firstName);
                user.Add("LastName", lastName);
                user.Add("Photo", photo);

                await user.SaveAsync();
            }

            ((App)App.Current).AuthenticatedUser = user;

            if (this.Model.NavigateCommand.CanExecute(null))
            {
                this.Model.NavigateCommand.Execute(null);
            }
        }
    }
}
