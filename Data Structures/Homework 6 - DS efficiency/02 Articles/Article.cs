using System;

namespace _02_Articles
{
    public class Article : IComparable
    {
        public string Title { get; set; }
        public string Vendor { get; set; }
        public string Barcode { get; set; }

        public Article(string title, string vendor = "generic", string barcode = "0000")
        {
            this.Title = title;
            this.Vendor = vendor;
            this.Barcode = barcode;
        }

        public int CompareTo(object obj)
        {
            return this.Title.CompareTo((obj as Article).Title);
        }

        public override string ToString()
        {
            return this.Title + ", " + this.Vendor + ", " + this.Barcode;
        }
    }
}
