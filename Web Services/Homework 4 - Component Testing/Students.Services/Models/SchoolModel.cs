using System;
using System.Collections.Generic;

namespace Students.Services.Models
{
    public class SchoolModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
    }
}