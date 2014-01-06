using System;
using System.Runtime.Serialization;

namespace Feedzilla.Client
{
    [DataContract]
    class Category
    {
        [DataMember(Name = "category_id")]
        public int Id { get; set; }

        [DataMember(Name = "english_category_name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0,5} - {1,-30}", this.Id, this.Name);
        }
    }
}
