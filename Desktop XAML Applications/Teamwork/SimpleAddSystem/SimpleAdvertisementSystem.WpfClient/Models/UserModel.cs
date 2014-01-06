using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleAdvertisementSystem.WpfClient.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string AuthCode { get; set; }

        public string Email { get; set; }
    }
}