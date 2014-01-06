using System;

namespace Students.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public string Subject { get; set; }
        public float Score { get; set; }

        public virtual Student Student { get; set; }
    }
}
