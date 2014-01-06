using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAdvertisementSystem.WpfClient.Behavior;
using SimpleAdvertisementSystem.WpfClient.Data;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    class AddCommentViewModel : ViewModelBase, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Add Comment";
            }
        }

        private ObservableCollection<AdvertisementViewModel> _advertisements;
        public AddCommentViewModel()
        {
            this._advertisements = new ObservableCollection<AdvertisementViewModel>();
        }

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
    }
}
