using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using ParseStarterProject.Model;
using ParseStarterProject.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.Storage.Streams;

namespace ParseStarterProject.ViewModel
{
    public class UpdatesViewModel : ViewModelBase
    {
        private IDataService dataService;

        public UpdatesViewModel()
        {
            this.NewItem = new UpdateModel() { UserId = ((App)App.Current).AuthenticatedUser.ObjectId, User = new UserModel(((App)App.Current).AuthenticatedUser) };

            dataService = SimpleIoc.Default.GetInstance<IDataService>();

            this.SaveCommand = new RelayCommand(async () =>
            {
                await this.NewItem.SaveAsync();
                this.NewItem = new UpdateModel() { UserId = ((App)App.Current).AuthenticatedUser.ObjectId };

                this.GetUpdates();
            });

            this.TakePictureCommand = new RelayCommand(() => this.TakePicture());

        }

        private IEnumerable updates;

        public IEnumerable Updates
        {
            get
            {
                if (this.updates == null)
                {
                    this.GetUpdates();
                    return null;
                }

                return this.updates;
            }

            set
            {
                this.updates = value;
                this.RaisePropertyChanged("Updates");
            }
        }

        private UpdateModel newItem;

        public UpdateModel NewItem
        {
            get { return newItem; }
            set
            {
                newItem = value;
                this.RaisePropertyChanged("NewItem");
            }
        }

        public RelayCommand SaveCommand { get; private set; }

        public RelayCommand TakePictureCommand { get; private set; }

        private async void TakePicture()
        {
            var ui = new CameraCaptureUI();
            ui.PhotoSettings.CroppedAspectRatio = new Size(4, 3);

            var file = await ui.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (file != null)
            {
                IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                NewItem.UpdateImage(fileStream);
            }
        }

        private async void GetUpdates()
        {
            IEnumerable data = await this.dataService.GetUpdates(((App)App.Current).AuthenticatedUser.ObjectId);

            this.Updates = data;
        }
    }
}
