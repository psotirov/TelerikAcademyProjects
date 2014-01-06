using GalaSoft.MvvmLight;
using ParseStarterProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseStarterProject.ViewModel
{
    public class ProfileViewModel : ViewModelBase
    {
        public UserModel User
        {
            get
            {
                return new UserModel(((App)App.Current).AuthenticatedUser);
            }
        }
    }
}
