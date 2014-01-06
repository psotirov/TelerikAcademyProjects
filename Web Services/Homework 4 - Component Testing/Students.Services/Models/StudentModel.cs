using System;
using System.Collections.Generic;

namespace Students.Services.Models
{
    public class StudentModel
    {
        public string Name { get; set; }
    }

    public class StudentModelDetails
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public IEnumerable<MarkModel> Marks { get; set; }
    }
}