using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;

namespace ViewModels
{
    public class ImageGalleryViewModel
    {
        public string CountriesDocumentPath { get; set; }

        private ObservableCollection<AlbumViewModel> albums;
        public ObservableCollection<AlbumViewModel> Albums
        {
            get
            {
                if (this.albums == null)
                {
                    var albumsEnumerable = DataPersister.GetAll();
                    this.albums = new ObservableCollection<AlbumViewModel>();
                    foreach (var album in albumsEnumerable)
                    {
                        this.albums.Add(album);
                    }
                   
                }

                return albums;
            }
        }

        private AlbumViewModel currentAlbum;
        public AlbumViewModel CurrentAlbum
        {
            get
            {
                if (this.currentAlbum == null)
                {
                    var albumsCollectionView = CollectionViewSource.GetDefaultView(this.Albums);
                    this.currentAlbum = albumsCollectionView.CurrentItem as AlbumViewModel;
                }

                return this.currentAlbum;
            }
        }
    }
}
