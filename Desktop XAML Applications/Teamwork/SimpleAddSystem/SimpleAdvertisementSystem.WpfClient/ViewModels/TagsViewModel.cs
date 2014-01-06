using SimpleAdvertisementSystem.WpfClient.Behavior;
using SimpleAdvertisementSystem.WpfClient.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class TagsViewModel : ViewModelBase, IPageViewModel
    {
        private string tagName;

        public string Name
        {
            get
            {
                return "All Tags";
            }
        }

        private ObservableCollection<TagViewModel> tags;

        public TagsViewModel()
        {
            this.tags = new ObservableCollection<TagViewModel>();
        }

        private ICommand addTagCommand;
        public ICommand AddTag
        {
            get 
            {
                if (this.addTagCommand == null)
                {
                    this.addTagCommand = new RelayCommand(this.HandleAddTagCommand);
                }

                return this.addTagCommand;
            }
        }

        public string TagName
        {
            get
            {
                return this.tagName;
            }
            set
            {
                if (this.tagName != value)
                {
                    this.tagName = value;
                    this.OnPropertyChanged("TagName");
                }
            }
        }

        private void HandleAddTagCommand(object parameter)
        {
            if (this.TagName == null || this.TagName == string.Empty)
            {
                return;
            }

            DataPersister.AddTag(this.TagName);
            this.TagName = string.Empty;
            this.Tags = DataPersister.GetAllTags();
        }

        public IEnumerable<TagViewModel> Tags
        {
            get
            {
                if (this.tags != null)
                {
                    this.Tags = DataPersister.GetAllTags();    
                }

                return this.tags;
            }
            set
            {
                if (this.tags == null)
                {
                    this.tags = new ObservableCollection<TagViewModel>();
                }

                this.tags.Clear();

                foreach (var tag in value)
                {
                    this.tags.Add(tag);
                }
            }
        }
    }
}
