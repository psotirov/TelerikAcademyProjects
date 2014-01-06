using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class HomePageViewModel : ViewModelBase, IPageViewModel
    {
        public string HomeMessage { get; set; }

        public HomePageViewModel()
        {
            this.HomeMessage = "Welcome Home!";
        }

        public string Name
        {
            get
            {
                return "HomePage";
            }
        }
    }
}
