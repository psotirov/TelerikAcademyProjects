using CinemaReserve.Client.Behavior;
using CinemaReserve.Client.Data;
using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaReserve.Client.ViewModels
{
    class CinemasViewModel : ViewModelBase, IPageViewModel
    {
        private ObservableCollection<CinemaViewModel> cinemas;
 
        public IEnumerable<CinemaViewModel> Cinemas
        {
            get
            {
                if (this.cinemas != null)
                {
                    this.Cinemas = DataPersister.GetAllCinemas();    
                }

                return this.cinemas;
            }
            set
            {
                if (this.cinemas == null)
                {
                    this.cinemas = new ObservableCollection<CinemaViewModel>();
                }

                this.cinemas.Clear();

                foreach (var cinema in value)
                {
                    this.cinemas.Add(cinema);
                }
            }
        }



        public string Name
        {
            get
            {
                return "Cinemas";
            }
        }


        public CinemasViewModel()
        {
            this.cinemas = new ObservableCollection<CinemaViewModel>();
        }

    }
}
