using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace CodeFirst.Models
{
    [DataContract(IsReference = true)]
    public class Artist
    {
        public int ArtistId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public DateTime BirthDate { get; set; }
        
        private ICollection<Album> albums;

        [IgnoreDataMember]
        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }

        public Artist()
        {
            this.albums = new HashSet<Album>();
        }
    }
}
