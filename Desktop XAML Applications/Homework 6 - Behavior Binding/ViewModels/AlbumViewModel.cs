using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using ViewModels.Behavior;

namespace ViewModels
{
    public class AlbumViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public IEnumerable<ImageViewModel> ImagesCollection { get; set; }

        private ObservableCollection<ImageViewModel> images;
        public ObservableCollection<ImageViewModel> Images
        {
            get
            {
                if (this.images == null)
                {
                    this.images = new ObservableCollection<ImageViewModel>();
                    foreach (var image in ImagesCollection)
                    {
                        this.images.Add(image);
                    }
                }

                return images;
            }
        }

        private ImageViewModel currentImage;
        public ImageViewModel CurrentImage
        {
            get
            {
                if (this.currentImage == null)
                {
                    var imagesCollectionView = CollectionViewSource.GetDefaultView(this.Images);
                    this.currentImage = imagesCollectionView.CurrentItem as ImageViewModel;
                }

                return this.currentImage;
            }

            set
            {
                this.currentImage = value;
                this.OnPropertyChanged("CurrentImage");
            }
        }

        private ICommand prevImage;
        public ICommand PrevImage
        {
            get
            {
                if (this.prevImage == null)
                {
                    this.prevImage = new RelayCommand(this.HandlePreviousCommand);
                }

                return this.prevImage;
            }
        }

        private ICommand nextImage;
        public ICommand NextImage
        {
            get
            {
                if (this.nextImage == null)
                {
                    this.nextImage = new RelayCommand(this.HandleNextCommand);
                }

                return this.nextImage;
            }
        }

        private ICommand addImage;
        public ICommand AddImage
        {
            get
            {
                if (this.addImage == null)
                {
                    this.addImage = new RelayCommand(HandleAddCommand);
                }

                return addImage;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(p));
            }
        }

        private void HandlePreviousCommand(object obj)
        {
            var imagesCollectionView = CollectionViewSource.GetDefaultView(this.Images);
            imagesCollectionView.MoveCurrentToPrevious();
            if (imagesCollectionView.IsCurrentBeforeFirst)
            {
                imagesCollectionView.MoveCurrentToLast();
            }

            var current = imagesCollectionView.CurrentItem as ImageViewModel;
            this.CurrentImage = current;
        }

        private void HandleNextCommand(object obj)
        {
            var imagesCollectionView = CollectionViewSource.GetDefaultView(this.Images);
            imagesCollectionView.MoveCurrentToNext();
            if (imagesCollectionView.IsCurrentAfterLast)
            {
                imagesCollectionView.MoveCurrentToFirst();
            }

            var current = imagesCollectionView.CurrentItem as ImageViewModel;
            this.CurrentImage = current;
        }

        private void HandleAddCommand(object obj)
        {
            var image = obj as ImageViewModel;
            if (image == null)
            {
                return;
            }

            DataPersister.AddNewImage(image.Source, image.Title, this.Name);
            this.images.Add(image);

            //OnPropertyChanged("Images");
        }
    }
}
