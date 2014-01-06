using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using ParseStarterProject.Model;
using ParseStarterProject.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParseStarterProject.ViewModel
{
    public class ToastViewModel : ViewModelBase
    {
        private IDataService dataService;

        public ToastViewModel()
        {
            this.NewItem = new ToastModel() { Sender = new UserModel(((App)App.Current).AuthenticatedUser) };

            dataService = SimpleIoc.Default.GetInstance<IDataService>();

            this.SendCommand = new RelayCommand(async () =>
            {
                await this.NewItem.SaveAsync();
                this.NewItem = new ToastModel() { Sender = new UserModel(((App)App.Current).AuthenticatedUser) };


                this.GetToasts();
            });

            
            
            this.RefreshCommand = new RelayCommand(() => this.GetToasts());

            this.GetToasts();

        }

        private async void GetToasts()
        {
            this.data = await this.dataService.GetToasts(((App)App.Current).AuthenticatedUser.ObjectId);

            this.BuildSelectedToasts();
        }

        private void BuildSelectedToasts()
        {
            if (data == null || SelectedUser == null)
                return;

            this.NewItem.Reciever = this.SelectedUser;
            var selectedItems = this.data.OfType<ToastModel>().Where(c =>  c.Sender!=null && c.Sender.storage.ObjectId == SelectedUser.storage.ObjectId || c.Reciever!=null && c.Reciever.storage.ObjectId == SelectedUser.storage.ObjectId);

            this.toasts = new ObservableCollection<ToastModel>(selectedItems);
            this.RaisePropertyChanged("Toasts");
        }

        private IEnumerable data;


        public ICommand SendCommand { get; set; }
        public ICommand RefreshCommand { get; set; }


        private ToastModel newItem;

        public ToastModel NewItem
        {
            get { return newItem; }
            set
            {
                newItem = value;
                this.RaisePropertyChanged("NewItem");
            }
        }

        private UserModel selectedUser;

        public UserModel SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                this.RaisePropertyChanged("SelectedUser");
                this.BuildSelectedToasts();
            }
        }

        private ObservableCollection<ToastModel> toasts;

        public IEnumerable Toasts
        {
            get
            {
                return this.toasts;
            }
        }

        private IEnumerable users;

        public IEnumerable Users
        {
            get
            {
                if (this.users == null)
                {
                    this.GetUsers();
                    return null;
                }

                return this.users;
            }

            set
            {
                this.users = value;
                this.RaisePropertyChanged("Users");
            }
        }

        private async void GetUsers()
        {
            this.Users = await this.dataService.GetUsers(((App)App.Current).AuthenticatedUser.ObjectId);
        }


    }
}
