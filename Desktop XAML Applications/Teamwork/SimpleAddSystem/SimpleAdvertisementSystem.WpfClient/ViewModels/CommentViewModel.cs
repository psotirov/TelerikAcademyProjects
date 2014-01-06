using System;

namespace SimpleAdvertisementSystem.WpfClient.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        public string CommentedBy { get; set; }

        public DateTime PostDate { get; set; }
    }
}