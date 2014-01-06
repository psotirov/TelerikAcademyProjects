using SimpleAdvertisementSystem.WpfClient.Behavior;
using SimpleAdvertisementSystem.WpfClient.Data;
using SimpleAdvertisementSystem.WpfClient.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class TagViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Posts { get; set; }

        public event EventHandler<ShowTagDetailsArgs> ShowTagDetailsRaised;

        private ObservableCollection<AdvertisementViewModel> tagPosts;
        public IEnumerable<AdvertisementViewModel> TagPosts
        {
            get
            {
                if (this.tagPosts == null)
                {
                    this.tagPosts = new ObservableCollection<AdvertisementViewModel>();
                }

                return this.tagPosts;
            }
            set
            {
                if (this.tagPosts == null)
                {
                    this.tagPosts = new ObservableCollection<AdvertisementViewModel>();
                }

                this.tagPosts.Clear();

                foreach (var result in value)
                {
                    this.tagPosts.Add(result);
                }
            }
        }

        private ICommand showAllAdvertisementsCommand;

        public ICommand ShowAllAdvertisements
        {
            get
            {
                if (this.showAllAdvertisementsCommand == null)
                {
                    this.showAllAdvertisementsCommand = new RelayCommand(this.HandleShowAllAdvertisementsCommand);
                }

                return this.showAllAdvertisementsCommand;
            }
        }

        private void HandleShowAllAdvertisementsCommand(object parameter)
        {
            var models = DataPersister.GetAllAdvertisementsByTag(this.Id);
            this.TagPosts = models;
        }
    }
}
