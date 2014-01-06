using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string[] Tags { get; set; }

        public string Text { get; set; }

        public string TagsList { get; set; }

        public int CategoryId { get; set; }
    }
}
