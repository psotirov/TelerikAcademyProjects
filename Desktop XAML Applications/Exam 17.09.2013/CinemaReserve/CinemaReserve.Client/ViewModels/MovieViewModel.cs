using System;
using CinemaReserve.Client.Behavior;
using CinemaReserve.Client.Data;
using CinemaReserve.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace CinemaReserve.Client.ViewModels
{
    class MovieViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Title { get; set; }

        private bool showDetails = false;
        public bool ShowDetails
        {
            get { return this.showDetails; }
            set
            {
                this.showDetails = value;
                OnPropertyChanged("ShowDetails");
            }
        }

        private MovieDetailsModel currentMovieDetails;
        public MovieDetailsModel CurrentMovieDetails
        {
            get
            {
                return this.currentMovieDetails;
            }
            set
            {
                this.currentMovieDetails = value;
                OnPropertyChanged("CurrentMovieDetails");
            }
        }

        private ICommand showMovieDetailsCommand;
        public ICommand ShowMovieDetails
        {
            get
            {
                if (this.showMovieDetailsCommand == null)
                {
                    this.showMovieDetailsCommand = new RelayCommand(this.HandleShowMovieDetailsCommand);
                }

                return this.showMovieDetailsCommand;
            }
        }

        private void HandleShowMovieDetailsCommand(object parameter)
        {
            this.ShowDetails = !this.ShowDetails;
            if (this.ShowDetails)
            {
                var model = DataPersister.GetMovieDetails(this.Id);
                this.CurrentMovieDetails = model;
            }
        }
    }
}
