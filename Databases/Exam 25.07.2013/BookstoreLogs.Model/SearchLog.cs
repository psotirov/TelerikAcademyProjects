using System;


namespace BookstoreLogs.Model
{
    public class SearchLog
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string QueryXml { get; set; }
    }
}
