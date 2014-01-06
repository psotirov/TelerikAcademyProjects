using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParseStarterProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParseStarterProject.ViewModel
{
    public class NavigateViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public NavigateViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.NavigateCommand = new RelayCommand<string>((s) =>
            {
                var view = (Views)Enum.Parse(typeof(Views), s);

                this.navigationService.Navigate(view);
            });
        }

        public ICommand NavigateCommand { get; private set; }
    }
}
