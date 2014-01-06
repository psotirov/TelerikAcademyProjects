using System;

namespace _03_Directories_Tree
{
    public class File
    {
        public string Name { get; private set; }
        public int Size { get; private set; }

        public File(string name, int size)
        {

            if (name.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Empty filename");
                
            }

            this.Name = name;
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("Negative filesize");
            }

            this.Size = size;
        }
    }
}
