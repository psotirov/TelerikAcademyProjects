﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.WpfClient.Helpers
{
    public class LoginSuccessArgs : EventArgs
    {
        public string Username { get; set; }

        public LoginSuccessArgs(string username)
            : base()
        {
            this.Username = username;
        }
    }
}
