using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleAdvertisementSystem.WpfClient.Models
{
    public class PostAdvertisementResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}