using System;
using System.Runtime.Serialization;

namespace Feedzilla.Client
{
    [DataContract]
    class Article
    {
        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "publish_date")]
        public DateTime PublishDate { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "source_url")]
        public string SourceUrl { get; set; }

        public override string ToString()
        {
            return string.Format(@"
=ARTICLE==========================================
Author:  {0}
Date:    {1:dd-MM-yyyy}
Title:   {2}
URL:     {4}
Summary:
{3}
",
                this.Author, this.PublishDate, this.Title, this.Summary, this.SourceUrl);
        }
    }
}
