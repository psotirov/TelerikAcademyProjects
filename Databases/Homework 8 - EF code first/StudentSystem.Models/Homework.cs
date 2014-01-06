using System;

namespace StudentSystem.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public DateTime TimeSent { get; set; }
    }
}
