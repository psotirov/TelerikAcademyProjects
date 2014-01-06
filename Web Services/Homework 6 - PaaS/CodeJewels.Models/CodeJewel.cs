using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace CodeJewels.Models
{
    [DataContract]
    public class CodeJewel
    {
        public int Id { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [DataMember]
        public virtual Category Category { get; set; }

        [DataMember]
        public string AuthorEmail { get; set; }

        [DataMember]
        public int Rating { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string Content { get; set; }
    }
}