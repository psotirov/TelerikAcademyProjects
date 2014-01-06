using CinemaReserve.Client.Behavior;
using CinemaReserve.Client.Data;
using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaReserve.Client.ViewModels
{
    class CinemaViewModel:ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private ICommand showCinemaMoviesCommand;
        private bool showMovies = false;
        public bool ShowMovies
        {
            get { return this.showMovies; }
            set
            {
                this.showMovies = value;
                OnPropertyChanged("ShowMovies");
            }
        }
 
        private ObservableCollection<MovieModel> currentCinemaMovies;
        public IEnumerable<MovieModel> CurrentCinemaMovies
        {
            get
            {
                if (this.currentCinemaMovies == null)
                {
                    this.CurrentCinemaMovies = new ObservableCollection<MovieModel>();
                }

                return this.currentCinemaMovies;
            }
            set
            {
                if (this.currentCinemaMovies == null)
                {
                    this.currentCinemaMovies = new ObservableCollection<MovieModel>();
                }

                this.currentCinemaMovies.Clear();

                foreach (var movie in value)
                {
                    this.currentCinemaMovies.Add(movie);
                }
            }
        }

        public ICommand ShowCinemaMovies
        {
            get
            {
                if (this.showCinemaMoviesCommand == null)
                {
                    this.showCinemaMoviesCommand = new RelayCommand(this.HandleShowCinemaMoviesCommand);
                }

                return this.showCinemaMoviesCommand;
            }
        }

        private void HandleShowCinemaMoviesCommand(object parameter)
        {
            this.ShowMovies = !this.ShowMovies;
            if (this.ShowMovies)
            {
                var models = DataPersister.GetCinemaMovies(this.Id);
                this.CurrentCinemaMovies = models;
            }
        }
    }
}
