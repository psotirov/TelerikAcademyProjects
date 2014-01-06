using System;
using System.Collections.Generic;

namespace FreeContentCatalog
{
    public interface ICatalog
    {
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        int UpdateContent(string oldUrl, string newUrl);
    }
}
