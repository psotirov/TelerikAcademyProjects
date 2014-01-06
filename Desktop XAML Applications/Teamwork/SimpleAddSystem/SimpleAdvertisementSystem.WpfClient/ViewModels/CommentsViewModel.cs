using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAdvertisementSystem.WpfClient.Data;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    class CommentsViewModel : ViewModelBase, IPageViewModel
    {
        private ObservableCollection<CommentViewModel> _comments;

        public CommentsViewModel()
        {
            this._comments = new ObservableCollection<CommentViewModel>();
        }

        public IEnumerable<CommentViewModel> Comments
        {
            get
            {
                if (this._comments != null)
                {
                    this.Comments = DataPersister.GetAllComments();
                }

                return this._comments;
            }
            set
            {
                if (this._comments == null)
                {
                    this._comments = new ObservableCollection<CommentViewModel>();
                }

                this._comments.Clear();

                foreach (var ad in value)
                {
                    this._comments.Add(ad);
                }
            }
        }

        public string Name
        {
            get
            {
                return "Latest Comments";
            }
        }
    }
}
