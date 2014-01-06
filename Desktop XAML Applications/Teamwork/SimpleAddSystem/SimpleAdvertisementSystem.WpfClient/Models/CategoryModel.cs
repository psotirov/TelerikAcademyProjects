using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleAdvertisementSystem.WpfClient.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }

        public IEnumerable<AdvertisementModel> Advertisements { get; set; }
    }
}