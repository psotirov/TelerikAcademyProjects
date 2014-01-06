using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleAdvertisementSystem.WpfClient.Behavior;
using System.Windows.Controls;
using System.Security.Cryptography;
using SimpleAdvertisementSystem.WpfClient.Data;
using SimpleAdvertisementSystem.WpfClient.Helpers;
using System.Net;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class LoginRegisterFormViewModel : ViewModelBase, IPageViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        private string message;

        public string Name
        {
            get
            {
                return "Login Form";
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public ICommand Login
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new RelayCommand(this.HandleLoginCommand);
                }
                return this.loginCommand;
            }
        }

        public ICommand Register
        {
            get
            {
                if (this.registerCommand == null)
                {
                    this.registerCommand = new RelayCommand(this.HandleRegisterCommand);
                }
                return this.registerCommand;
            }
        }

        public event EventHandler<LoginSuccessArgs> LogginSuccess;

        private void HandleRegisterCommand(object parameter)
        {
            try
            {
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;
                var sha1Password = this.CalculateSha1(password);
                DataPersister.RegisterUser(this.Username, this.Email, sha1Password);
            }
            catch (WebException)
            {
                Message = "Registration failed. Please try again.";
            }
            catch (Exception e)
            {
                Message = e.Message;
            }

            this.HandleLoginCommand(parameter);
        }

        private void HandleLoginCommand(object parameter)
        {
            try
            {
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;
                var sha1Password = this.CalculateSha1(password);

                var username = DataPersister.LoginUser(this.Username, sha1Password);
                if (!string.IsNullOrWhiteSpace(username))
                {
                    this.RaiseLoginSuccess(username);
                }
            }
            catch (Exception)
            {
                Message = "Invalid login details. Try again";
            }
        }

        protected void RaiseLoginSuccess(string username)
        {
            if (this.LogginSuccess != null)
            {
                this.LogginSuccess(this, new LoginSuccessArgs(username));
            }
        }

        private ICommand loginCommand;

        private ICommand registerCommand;

        public string CalculateSha1(string text)
        {
            Encoding enc = Encoding.Default;

            // Convert the input string to a byte array
            byte[] buffer = enc.GetBytes(text);

            // In doing your test, you won't want to re-initialize like this every time you test a
            // string.
            SHA1CryptoServiceProvider cryptoTransformSHA1 =
                new SHA1CryptoServiceProvider();

            // The replace won't be necessary for your tests so long as you are consistent in what
            // you compare.    
            string hash = BitConverter.ToString(
                cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }
    }
}
