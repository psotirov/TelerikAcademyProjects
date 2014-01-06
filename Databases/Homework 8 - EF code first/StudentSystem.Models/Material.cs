using System;

namespace StudentSystem.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        public MaterialType Type { get; set; }
        public string Description { get; set; }
    }
}
