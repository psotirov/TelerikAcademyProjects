using SimpleAdvertisementSystem.WpfClient.Behavior;
using SimpleAdvertisementSystem.WpfClient.Data;
using SimpleAdvertisementSystem.WpfClient.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class AppViewModel : ViewModelBase
    {

        private ICommand changeViewModelCommand;
        private IPageViewModel currentViewModel;
        private bool loggedInUser = false;
        private ICommand logoutCommand;

        public IPageViewModel LoginRegisterViewModel { get; set; }

        public ICommand Logout
        {
            get
            {
                if (this.logoutCommand == null)
                {
                    this.logoutCommand = new RelayCommand(this.HandleLogoutCommand);
                }
                return this.logoutCommand;
            }
        }

        private void HandleLogoutCommand(object parameter)
        {
            bool isUserLoggedOut = DataPersister.LogoutUser();
            if (isUserLoggedOut)
            {
                this.Username = "";
                this.LoggedInUser = false;
                this.HandleChangeViewModelCommand(this.LoginRegisterViewModel);
            }
        }

        public bool LoggedInUser
        {
            get
            {
                return this.loggedInUser;
            }
            set
            {
                this.loggedInUser = value;
                this.OnPropertyChanged("LoggedInUser");
            }
        }

        public IPageViewModel CurrentViewModel 
        { 
            get
            {
                return this.currentViewModel;
            }

            set
            {
                this.currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        }

        public List<IPageViewModel> ViewModels { get; set; }

        public ICommand ChangeViewModel 
        { 
            get 
            {
                if (this.changeViewModelCommand == null)
                {
                    this.changeViewModelCommand = new RelayCommand(this.HandleChangeViewModelCommand);
                }

                return this.changeViewModelCommand;
            } 
        }

        private void HandleChangeViewModelCommand(object parameter)
        {
            var newViewModel = parameter as IPageViewModel;
            this.CurrentViewModel = newViewModel;
        }
        
        public AppViewModel()
        {
            this.ViewModels = new List<IPageViewModel>();
            this.ViewModels.Add(new HomePageViewModel());
            this.ViewModels.Add(new AdvertisementsViewModel());
            this.ViewModels.Add(new AddAdvertisementViewModel());
            this.ViewModels.Add(new AddCommentViewModel());
            this.ViewModels.Add(new TagsViewModel());
            this.ViewModels.Add(new CategoriesViewModel());
            this.ViewModels.Add(new SearchViewModel());
            this.ViewModels.Add(new CommentsViewModel());
            

            var loginVM = new LoginRegisterFormViewModel();
            loginVM.LogginSuccess += this.LoginSuccessful;

            this.LoginRegisterViewModel = loginVM;
            this.CurrentViewModel = this.LoginRegisterViewModel;
        }

        private void LoginSuccessful(object sender, LoginSuccessArgs e)
        {
            this.Username = e.Username;
            this.LoggedInUser = true;
            this.HandleChangeViewModelCommand(this.ViewModels[0]);
        }

        public string Username { get; set; }
    }
}
