using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleAdvertisementSystem.WpfClient.Behavior;
using SimpleAdvertisementSystem.WpfClient.Data;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    class CategoriesViewModel : ViewModelBase, IPageViewModel
    {
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

        private ICommand _addCategory;

        public ICommand AddCategory
        {
            get
            {
                if (this._addCategory == null)
                {
                    this._addCategory = new RelayCommand(this.HandleAddCategoryCommand);
                }
                return this._addCategory;
            }
        }

        private void HandleAddCategoryCommand(object parameter)
        {
            DataPersister.AddNewCategory(this.CategoryName);
            this.Categories = DataPersister.GetAllCategories();
            this.CategoryName = string.Empty;
        }


        private ObservableCollection<CategoryViewModel> _categories;

        public CategoriesViewModel()
        {
            this._categories = new ObservableCollection<CategoryViewModel>();
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
                return "All Categories";
            }
        }

        private ObservableCollection<AdvertisementViewModel> categoryPosts;
        public IEnumerable<AdvertisementViewModel> CategoryPosts
        {
            get
            {
                if (this.categoryPosts == null)
                {
                    this.categoryPosts = new ObservableCollection<AdvertisementViewModel>();
                }

                return this.categoryPosts;
            }
            set
            {
                if (this.categoryPosts == null)
                {
                    this.categoryPosts = new ObservableCollection<AdvertisementViewModel>();
                }

                this.categoryPosts.Clear();

                foreach (var result in value)
                {
                    this.categoryPosts.Add(result);
                }
            }
        }

        private ICommand showAllAdvertisementsCommand;

        public ICommand ShowAllAdvertisementsByCategory
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
            if (parameter == null)
            {
                return;
            }
            var catId = (int)parameter;
            var models = DataPersister.GetAllAdvertisementsByCategory(catId);
            this.CategoryPosts = models;
        }
    }
}
