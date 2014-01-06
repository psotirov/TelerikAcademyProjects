using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Services.Models
{
    public class CommentDetailsModel
    {
        public string Text { get; set; }
        public string CommentedBy { get; set; }
        public DateTime PostDate { get; set; }
    }
}