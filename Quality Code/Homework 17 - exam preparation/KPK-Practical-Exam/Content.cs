using System;

namespace FreeContentCatalog
{
    public class Content : IComparable, IContent
    {
        private string url;

        public ContentType Type { get; set; }
        public string TextRepresentation { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long Size { get; set; }
        public string URL
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentItem.Title];
            this.Author = commandParams[(int)ContentItem.Author];
            this.Size = long.Parse(commandParams[(int)ContentItem.Size]);
            this.URL = commandParams[(int)ContentItem.Url];
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
                return comparisonResult;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}",
                this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }

}
