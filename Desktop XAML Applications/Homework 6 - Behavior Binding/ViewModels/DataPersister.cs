using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ViewModels
{
    public class DataPersister
    {
        public static string AlbumsDocumentPath = "..\\..\\..\\ViewModels\\gallery.xml";

        public static IEnumerable<AlbumViewModel> GetAll()
        {
            var galleryDocumentRoot = XDocument.Load(AlbumsDocumentPath).Root;
            var albums =
                from album in galleryDocumentRoot.Elements("album")
                select new AlbumViewModel()
                {
                    Name = album.Attribute("name").Value,
                    ImagesCollection =
                        from image in album.Element("images").Elements("image")
                        select new ImageViewModel()
                        {
                            Title = image.Element("title").Value,
                            Source = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), image.Element("source").Value)
                        }
                };

            return albums;
        }

        public static void AddNewImage(string filename, string title, string albumName)
        {
            var galleryDocumentRoot = XDocument.Load(AlbumsDocumentPath).Root;

            var albumFound =
                (from album in galleryDocumentRoot.Elements("album")
                where album.Attribute("name").Value == albumName
                select album.Element("images")).FirstOrDefault();

            if (albumFound != null)
            {
                var newImage = new XElement("image",
                    new XElement("title", title),
                    new XElement("source", filename));

                albumFound.Add(newImage);
            }
 
            galleryDocumentRoot.Save(AlbumsDocumentPath);
        }
    }
}
