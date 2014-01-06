using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Services.Models
{
    public class PostDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PostedBy { get; set; }
        
        public DateTime PostDate { get; set; }

        public string Text { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<CommentDetailsModel> Comments { get; set; }
    }
}