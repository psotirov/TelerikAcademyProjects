using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using ViewModels.Behavior;

namespace ViewModels
{
    public class StoreViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public IEnumerable<PhoneViewModel> PhonesEnum { get; set; }

        private ICommand prevPhone;
        public ICommand PrevPhone
        {
            get
            {
                if (this.prevPhone == null)
                {
                    this.prevPhone = new RelayCommand(this.HandlePreviousCommand);
                }
                return this.prevPhone;
            }
        }

        private ICommand nextPhone;
        public ICommand NextPhone
        {
            get
            {
                if (this.nextPhone == null)
                {
                    this.nextPhone = new RelayCommand(this.HandleNextCommand);
                }
                return this.nextPhone;
            }
        }

        private ICommand deletePhone;
        public ICommand DeletePhone
        {
            get
            {
                if (this.deletePhone == null)
                {
                    this.deletePhone = new RelayCommand(this.HandleDeletePhoneCommand);
                }
                return this.deletePhone;
            }
        }

        private ICommand changePhone;
        public ICommand ChangePhone
        {
            get
            {
                if (this.changePhone == null)
                {
                    this.changePhone = new RelayCommand(this.HandleChangePhoneCommand);
                }
                return this.changePhone;
            }
        }

        private ICommand addPhone;
        public ICommand AddPhone
        {
            get
            {
                if (this.addPhone == null)
                {
                    this.addPhone = new RelayCommand(this.HandleAddPhoneCommand);
                }

                return addPhone;
            }
        }

        private PhoneViewModel currentPhone;
        public PhoneViewModel CurrentPhone
        {
            get
            {
                if (this.currentPhone == null)
                {
                    var imagesCollectionView = CollectionViewSource.GetDefaultView(this.Phones);
                    this.currentPhone = imagesCollectionView.CurrentItem as PhoneViewModel;
                }
                return this.currentPhone;
            }

            set
            {
                this.currentPhone = value;
                this.OnPropertyChanged("CurrentPhone");
            }
        }

        private ObservableCollection<PhoneViewModel> phones;
        public ObservableCollection<PhoneViewModel> Phones
        {
            get
            {
                if (this.phones == null)
                {
                    this.phones = new ObservableCollection<PhoneViewModel>();
                    foreach (var image in PhonesEnum)
                    {
                        this.phones.Add(image);
                    }
                }

                return phones;
            }
        }

        public void OnStoreRenamed()
        {
            this.OnPropertyChanged("Name");
        }

        protected void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(p));
            }
        }

        private void HandlePreviousCommand(object obj)
        {
            var phonesCollectionView = CollectionViewSource.GetDefaultView(this.Phones);
            phonesCollectionView.MoveCurrentToPrevious();
            if (phonesCollectionView.IsCurrentBeforeFirst)
            {
                phonesCollectionView.MoveCurrentToLast();
            }

            var current = phonesCollectionView.CurrentItem as PhoneViewModel;
            this.CurrentPhone = current;
        }

        private void HandleNextCommand(object obj)
        {
            var phonesCollectionView = CollectionViewSource.GetDefaultView(this.Phones);
            phonesCollectionView.MoveCurrentToNext();
            if (phonesCollectionView.IsCurrentAfterLast)
            {
                phonesCollectionView.MoveCurrentToFirst();
            }

            var current = phonesCollectionView.CurrentItem as PhoneViewModel;
            this.CurrentPhone = current;
        }

        private void HandleDeletePhoneCommand(object obj)
        {
            var oldPhone = this.CurrentPhone;
            this.Phones.Remove(this.CurrentPhone);
            this.HandlePreviousCommand(obj); // forces update
            OnPropertyChanged("Phones");
            //DataPersister.DeletePhone(oldPhone, "..\\..\\..\\ViewModels\\Phones.xml");
        }

        private void HandleChangePhoneCommand(object obj)
        {
            this.currentPhone = null; // forces update
            OnPropertyChanged("Phones");
            //DataPersister.UpdatePhone(this.CurrentPhone, this.CurrentPhone.Name, "..\\..\\..\\ViewModels\\Phones.xml");
        }

        private void HandleAddPhoneCommand(object obj)
        {
            var newPhone = new PhoneViewModel();
            newPhone.Model = "New Phone";
            newPhone.OS = new OSViewModel();
            if (this.CurrentPhone != null)
            {
                newPhone.Features = new List<FeatureViewModel>(this.CurrentPhone.Features);
                foreach (var item in newPhone.Features)
                {
                    item.Value = "";
                }
            }
            else
            {
                newPhone.Features = new List<FeatureViewModel>();
            }


            //DataPersister.AddNewPhone(newPhone, "..\\..\\..\\ViewModels\\Phones.xml");
            this.Phones.Add(newPhone);
            var phonesCollectionView = CollectionViewSource.GetDefaultView(this.Phones);
            phonesCollectionView.MoveCurrentToLast();
            this.CurrentPhone = newPhone;
            OnPropertyChanged("Phones");
        }
    }
}
