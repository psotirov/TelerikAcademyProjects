using System.Runtime.Serialization;
using SimpleAdvertisementSystem.WpfClient.Behavior;
using SimpleAdvertisementSystem.WpfClient.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{   
    [DataContract]
    public class CategoryViewModel : ViewModelBase
    {
        [DataMember(Name = "id")]
        public int CategoryId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }


    }
}