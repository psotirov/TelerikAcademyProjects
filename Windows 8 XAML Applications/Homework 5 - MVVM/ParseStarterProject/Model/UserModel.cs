using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseStarterProject.Model
{
    public class UserModel : ObservableObject
    {
        internal ParseObject storage;

        public UserModel()
            : this(new ParseObject("User"))
        {
        }

        public UserModel(ParseObject storage)
        {
            this.storage = storage;
        }

        public string FirstName
        {
            get
            {
                return (string)storage["FirstName"];
            }
        }

        public string LastName
        {
            get
            {
                return (string)storage["LastName"];
            }
        }

        public Uri Uri
        {
            get
            {
                return new Uri((string)storage["Photo"], UriKind.Absolute);
            }
        }
    }
}
