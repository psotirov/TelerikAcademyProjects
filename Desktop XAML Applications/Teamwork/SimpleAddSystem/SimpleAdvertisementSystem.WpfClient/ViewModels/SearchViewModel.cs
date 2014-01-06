using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SimpleAdvertisementSystem.WpfClient.Behavior;
using SimpleAdvertisementSystem.WpfClient.Data;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class SearchViewModel : ViewModelBase, IPageViewModel
    {
        private string queryString;
        private ObservableCollection<AdvertisementViewModel> searchResult;
        private ICommand searchCommand;

        public IEnumerable<AdvertisementViewModel> SearchResult
        {
            get
            {
                if (this.searchResult == null)
                {
                    this.SearchResult = new ObservableCollection<AdvertisementViewModel>();
                }

                return this.searchResult;
            }
            set
            {
                if (this.searchResult == null)
                {
                    this.searchResult = new ObservableCollection<AdvertisementViewModel>();
                }

                this.searchResult.Clear();

                foreach (var result in value)
                {
                    this.searchResult.Add(result);
                }
            }
        }

        public string QueryString
        {
            get
            {
                return this.queryString;
            }
            set
            {
                if (this.queryString != value)
                {
                    this.queryString = value;
                    this.OnPropertyChanged("QueryString");
                }
            }
        }

        public ICommand Search
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new RelayCommand(this.HandleSearchCommand);
                }

                return this.searchCommand;
            }
        }

        private void HandleSearchCommand(object parameter)
        {
            if (this.queryString == null || this.queryString == string.Empty)
            {
                this.searchResult = null;
                return;
            }

            var models = DataPersister.SearchByQueryString(this.QueryString);
            this.SearchResult = models;
        }

        public string Name
        {
            get
            {
                return "Search";
            }
        }
    }
}
