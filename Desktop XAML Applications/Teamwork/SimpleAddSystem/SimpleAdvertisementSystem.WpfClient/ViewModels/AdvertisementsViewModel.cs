using SimpleAdvertisementSystem.WpfClient.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class AdvertisementsViewModel : ViewModelBase, IPageViewModel
    {
        private ObservableCollection<AdvertisementViewModel> advertisements;

        public AdvertisementsViewModel()
        {
            this.advertisements = new ObservableCollection<AdvertisementViewModel>();
        }

        public IEnumerable<AdvertisementViewModel> Advertisements
        {
            get
            {
                if (this.advertisements != null)
                {
                    this.Advertisements = DataPersister.GetAllAdvertisements();    
                }

                return this.advertisements;
            }
            set
            {
                if (this.advertisements == null)
                {
                    this.advertisements = new ObservableCollection<AdvertisementViewModel>();
                }

                this.advertisements.Clear();

                foreach (var ad in value)
                {
                    this.advertisements.Add(ad);
                }
            }
        }

        public string Name
        {
            get
            {
                return "Advertisements";
            }
        }
    }
}
