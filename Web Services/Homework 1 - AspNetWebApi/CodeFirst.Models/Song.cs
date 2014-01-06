using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace CodeFirst.Models
{
    [DataContract(IsReference = true)]
    public class Song
    {
        public int SongId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public DateTime Year { get; set; }

        [IgnoreDataMember]
        public int ArtistId { get; set; }

        [IgnoreDataMember]
        public virtual Artist Artist { get; set; }
    }
}
