using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleAdvertisementSystem.WpfClient.Models
{
    public class CommentModel
    {
        public string Text { get; set; }

        public string CommentedBy { get; set; }

        public DateTime PostDate { get; set; }
    }
}