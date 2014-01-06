using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CodeJewels.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string CategoryName { get; set; }
    }
}