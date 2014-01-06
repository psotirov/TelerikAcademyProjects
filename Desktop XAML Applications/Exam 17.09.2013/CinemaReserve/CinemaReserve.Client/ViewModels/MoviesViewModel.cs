using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaReserve.ResponseModels;
using System.Collections.ObjectModel;
using CinemaReserve.Client.Data;
using System.Windows.Input;
using CinemaReserve.Client.Behavior;


namespace CinemaReserve.Client.ViewModels
{
    class MoviesViewModel : ViewModelBase, IPageViewModel
    {

        private string searchFilter;
        public string SearchFilter
        {
            get { return this.searchFilter; }
            set
            {
                this.searchFilter = value.Trim();
                OnPropertyChanged("Movies");
            }
        }

        public MoviesViewModel()
        {
            this.movies = new ObservableCollection<MovieViewModel>();
            this.searchFilter = string.Empty;
        }

        private ObservableCollection<MovieViewModel> movies;
        public IEnumerable<MovieViewModel> Movies
        {
            get
            {
                if (this.movies != null)
                {
                    if (this.searchFilter.Length > 0)
                    {
                        this.Movies = DataPersister.SearchMovies(this.searchFilter);
                    }
                    else
                    {
                        this.Movies = DataPersister.GetAllMovies();
                    }
                }

                return this.movies;
            }
            set
            {
                if (this.movies == null)
                {
                    this.movies = new ObservableCollection<MovieViewModel>();
                }

                this.movies.Clear();

                foreach (var movie in value)
                {
                    this.movies.Add(movie);
                }
            }
        }

        private ICommand reloadCommand;
        public ICommand Reload
        {
            get
            {
                if (this.reloadCommand == null)
                {
                    this.reloadCommand = new RelayCommand(this.HandleReloadCommand);
                }

                return this.reloadCommand;
            }
        }

        private void HandleReloadCommand(object parameter)
        {
            this.movies.Clear(); 
            OnPropertyChanged("Movies");
        }

        public string Name
        {
            get
            {
                return "Movies";
            }
        }
    }
}
