using System;

namespace FreeContentCatalog
{
    public enum CommandType
    {
        AddBook,
        AddMovie,
        AddSong,
        AddApplication,
        Update,
        Find,
    }

    public enum ContentType
    {
        Application,
        Book,
        Movie,
        Song
    }

    public enum ContentItem
    {
        Title = 0,
        Author,
        Size,
        Url,
    }

}
