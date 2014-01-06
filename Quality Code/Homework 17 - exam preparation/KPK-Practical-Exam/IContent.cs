using System;

namespace FreeContentCatalog
{
    public interface IContent : IComparable
    {
        string Title { get; set; }

        string Author { get; set; }

        long Size { get; set; }

        string URL { get; set; }

        ContentType Type { get; set; }

        string TextRepresentation { get; set; }
    }
}
