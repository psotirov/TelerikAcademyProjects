using System;
using System.Collections.Generic;

namespace Blog.Services.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public HashSet<string> Tags { get; set; }

        public PostModel()
        {
            this.Tags = new HashSet<string>();
        }
    }
}