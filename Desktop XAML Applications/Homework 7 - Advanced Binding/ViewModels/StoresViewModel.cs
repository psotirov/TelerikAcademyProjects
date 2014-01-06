using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using ViewModels.Behavior;

namespace ViewModels
{
    public class StoresViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand deleteStore;
        public ICommand DeleteStore
        {
            get
            {
                if (this.deleteStore == null)
                {
                    this.deleteStore = new RelayCommand(this.HandleDeleteStoreCommand);
                }
                return this.deleteStore;
            }
        }

        private ICommand changeStore;
        public ICommand ChangeStore
        {
            get
            {
                if (this.changeStore == null)
                {
                    this.changeStore = new RelayCommand(this.HandleChangeStoreCommand);
                }
                return this.changeStore;
            }
        }

        private ICommand addStore;
        public ICommand AddStore
        {
            get
            {
                if (this.addStore == null)
                {
                    this.addStore = new RelayCommand(this.HandleAddStoreCommand);
                }

                return addStore;
            }
        }

        private ObservableCollection<StoreViewModel> stores;
        public ObservableCollection<StoreViewModel> Stores
        {
            get
            {
                if (this.stores == null)
                {
                    var storesEnumerable = DataPersister.GetAll();
                    this.stores = new ObservableCollection<StoreViewModel>();
                    foreach (var store in storesEnumerable)
                    {
                        this.stores.Add(store);
                    }
                }

                return stores;
            }
        }

        private StoreViewModel currentStore;
        public StoreViewModel CurrentStore
        {
            get
            {
                if (this.currentStore == null)
                {
                    var storeCollectionView = CollectionViewSource.GetDefaultView(this.Stores);
                    this.currentStore = storeCollectionView.CurrentItem as StoreViewModel;
                }

                return this.currentStore;
            }
        }

        protected void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(p));
            }
        }

        private void HandleDeleteStoreCommand(object obj)
        {
            this.currentStore = null; // forces update
            var oldName = this.CurrentStore.Name; 
            this.stores.Remove(this.CurrentStore);
            this.currentStore = null; // forces update
            OnPropertyChanged("Stores");
            //DataPersister.DeleteStore(oldName, "..\\..\\..\\ViewModels\\stores.xml");
        }

        private void HandleChangeStoreCommand(object obj)
        {
            this.currentStore = null; // forces update
            var oldName = this.CurrentStore.Name;
            this.CurrentStore.Name = (string)obj;
            this.CurrentStore.OnStoreRenamed();
            OnPropertyChanged("Stores");
            //DataPersister.UpdateStore(oldName, this.CurrentStore.Name, "..\\..\\..\\ViewModels\\stores.xml");
        }

        private void HandleAddStoreCommand(object obj)
        {
            var store = new StoreViewModel();
            store.Name = "New Store";
            store.PhonesEnum = new List<PhoneViewModel>();

            //DataPersister.AddNewStore(store.Name, "..\\..\\..\\ViewModels\\stores.xml");
            this.stores.Add(store);
            OnPropertyChanged("Stores");
        }
    }
}
