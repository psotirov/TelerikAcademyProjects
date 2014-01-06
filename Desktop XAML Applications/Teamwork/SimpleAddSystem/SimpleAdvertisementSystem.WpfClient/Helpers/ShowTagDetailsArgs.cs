using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.WpfClient.Helpers
{
    public class ShowTagDetailsArgs : EventArgs
    {
        public int TagId { get; set; }
        
        public ShowTagDetailsArgs(int tagId)
            : base()
        {
            this.TagId = tagId;
        }
    }
}
