using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReserve.Client.ViewModels
{
    class ReservationViewModel : ViewModelBase, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Reservation";
            }
        }
    }
}
