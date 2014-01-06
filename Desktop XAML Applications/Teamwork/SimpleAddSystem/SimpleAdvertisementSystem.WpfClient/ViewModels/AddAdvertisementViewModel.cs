using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using SimpleAdvertisementSystem.WpfClient.Behavior;
using SimpleAdvertisementSystem.WpfClient.Data;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class AddAdvertisementViewModel : ViewModelBase, IPageViewModel
    {
        private ICommand _addNewCommand;
        private AdvertisementViewModel _newAdvertisement = new AdvertisementViewModel();

  //      public string TagsList = "dssdfs"; 


        public ICommand AddNew
        {
            get
            {
                if (this._addNewCommand == null)
                {
                    this._addNewCommand = new RelayCommand(this.HandleAddNewCommand);
                }
                return this._addNewCommand;
            }
        }

        private void HandleAddNewCommand(object parameter)
        {
            var selectedCategory = parameter as CategoryViewModel;

            string[] advTags = this.NewAdvertisement.TagsList.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            this.NewAdvertisement.Tags = advTags;
            if (selectedCategory != null)
            {
                this.NewAdvertisement.CategoryId = selectedCategory.CategoryId;
            }
            DataPersister.AddNewAdvertisement(this.NewAdvertisement);
            this.Advertisements = DataPersister.GetAllAdvertisements();
        }



       public AdvertisementViewModel NewAdvertisement
        {
            get
            {
                return this._newAdvertisement;
            }
            set
            {
                _newAdvertisement = value;
                this.OnPropertyChanged("NewAdvertisement");
            }
        }

        //________________//
        private ObservableCollection<AdvertisementViewModel> _advertisements;

        public IEnumerable<AdvertisementViewModel> Advertisements
        {
            get
            {
                if (this._advertisements != null)
                {
                    this.Advertisements = DataPersister.GetAllAdvertisements();    
                }

                return this._advertisements;
            }
            set
            {
                if (this._advertisements == null)
                {
                    this._advertisements = new ObservableCollection<AdvertisementViewModel>();
                }

                this._advertisements.Clear();

                foreach (var ad in value)
                {
                    this._advertisements.Add(ad);
                }
            }
        }

        private string _categoryName;

        public string CategoryName
        {
            get
            {
                return this._categoryName;
            }
            set
            {
                if (this._categoryName != value)
                {
                    this._categoryName = value;
                    this.OnPropertyChanged("CategoryName");
                }
            }
        }

        private ObservableCollection<CategoryViewModel> _categories;

        public AddAdvertisementViewModel()
        {
            this._categories = new ObservableCollection<CategoryViewModel>();
            this._advertisements = new ObservableCollection<AdvertisementViewModel>();
        }

        public IEnumerable<CategoryViewModel> Categories
        {
            get
            {
                if (this._categories != null)
                {
                    this.Categories = DataPersister.GetAllCategories();
                }

                return this._categories;
            }
            set
            {
                if (this._categories == null)
                {
                    this._categories = new ObservableCollection<CategoryViewModel>();
                }

                this._categories.Clear();

                foreach (var ad in value)
                {
                    this._categories.Add(ad);
                }
            }
        }

        public string Name
        {
            get
            {
                return "Add Advertisement";
            }
        }
    }
}
