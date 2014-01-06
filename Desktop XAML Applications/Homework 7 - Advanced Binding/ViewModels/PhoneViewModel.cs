using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PhoneViewModel
    {
        public string Vendor { get; set; }

        public string Model { get; set; }

        public string Image { get; set; }

        public string Year { get; set; }

        public OSViewModel OS{ get; set; }

        public IEnumerable<FeatureViewModel> Features { get; set; }
    }
}
