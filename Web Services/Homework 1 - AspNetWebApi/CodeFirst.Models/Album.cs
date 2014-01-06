using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CodeFirst.Models
{
    [DataContract(IsReference = true)]
    public class Album
    {
        public int AlbumId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public DateTime Year { get; set; }

        private ICollection<Artist> artists;

        [DataMember]
        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }

        private ICollection<Song> songs;

        [DataMember]
        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }
    }
}
