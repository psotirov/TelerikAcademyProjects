using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;

namespace ParseStarterProject.Model
{
    public class UpdateModel : ObservableObject
    {
        private ParseObject storage;

        public UpdateModel()
            : this(new ParseObject("Update"))
        {
        }

        public UpdateModel(ParseObject storage)
        {
            this.storage = storage;

        }

        public string Message
        {
            get
            {
                string result;

                storage.TryGetValue<string>("Message", out result);

                return result;
            }
            set
            {
                storage["Message"] = value;
                this.RaisePropertyChanged("Message");
            }
        }

        public BitmapImage Picture
        {
            get
            {
                ParseFile result;

                storage.TryGetValue<ParseFile>("Picture", out result);


                return result != null ? new BitmapImage(result.Url) : null;
            }

        }

        public void UpdateImage(IRandomAccessStream rass)
        {

            storage["Picture"] = new ParseFile("Picture.jpg", rass.AsStreamForRead());

            this.RaisePropertyChanged("Picture");
        }

        public string UserId
        {
            get
            {
                return storage.Get<string>("UserId");
            }
            set
            {
                storage["UserId"] = value;
            }
        }

        public UserModel User
        {
            get
            {
                ParseUser result;

                if (storage.TryGetValue<ParseUser>("User", out result))
                {


                    return new UserModel(result);
                }

                return null;
            }

            set
            {
                storage["User"] = value.storage;
            }
        }

        public DateTime Date
        {
            get
            {

                return storage.UpdatedAt ?? new DateTime();
            }
        }

        public async Task SaveAsync()
        {
            await this.storage.SaveAsync();
        }

    }
}
