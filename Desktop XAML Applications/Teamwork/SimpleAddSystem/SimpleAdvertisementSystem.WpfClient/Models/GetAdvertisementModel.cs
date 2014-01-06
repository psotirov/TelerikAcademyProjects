using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleAdvertisementSystem.WpfClient.Models
{
    public class GetAdvertisementModel : AdvertisementModel
    {
        public DateTime PostDate { get; set; }

        public string PostedBy { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }
}