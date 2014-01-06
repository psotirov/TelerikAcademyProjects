using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace FreeContentCatalog
{
    class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from content in this.title[title] 
                                                  select content;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string old, string newUrl)
        {
            int theElements = 0;
            List<IContent> contentToList = this.url[old].ToList();

            foreach (Content content in contentToList)
            {
                this.title.Remove(content.Title, content);
                theElements++;
            }

            this.url.Remove(old);
            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
            }

            foreach (IContent content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }
    }
}
