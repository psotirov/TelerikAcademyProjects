using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleAdvertisementSystem.WpfClient.Models
{
    public class LoginResponseModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string AccessToken { get; set; }
    }
}