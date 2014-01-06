using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewModels
{
    public class CountryViewModel
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string NationalFlag { get; set; }
        public List<TownViewModel> Towns { get; set; }
    }
}
