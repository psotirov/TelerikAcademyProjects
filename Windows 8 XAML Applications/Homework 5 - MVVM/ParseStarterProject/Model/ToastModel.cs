using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseStarterProject.Model
{
    public class ToastModel : ObservableObject
    {
        private ParseObject storage;

        public ToastModel()
            : this(new ParseObject("Toast"))
        {
        }

        public ToastModel(ParseObject storage)
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

        public UserModel Sender
        {
            get
            {
                ParseUser result;

                if (storage.TryGetValue<ParseUser>("Sender", out result))
                {


                    return new UserModel(result);
                }

                return null;
            }

            set
            {
                storage["Sender"] = value.storage;
            }
        }

        public UserModel Reciever
        {
            get
            {
                ParseUser result;

                if (storage.TryGetValue<ParseUser>("Reciever", out result))
                {


                    return new UserModel(result);
                }

                return null;
            }

            set
            {
                storage["Reciever"] = value.storage;
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
