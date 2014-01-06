﻿using CinemaReserve.Client.Behavior;
using CinemaReserve.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CinemaReserve.Client.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private ICommand changeViewModelCommand;

        private IPageViewModel currentViewModel;
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
            this.ViewModels.Add(new CinemasViewModel());
            this.ViewModels.Add(new MoviesViewModel());
            this.ViewModels.Add(new ReservationViewModel());

            this.CurrentViewModel = this.ViewModels[0];
        }
    }
}
