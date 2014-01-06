using System;
using System.Collections.Generic;

namespace _03_Directories_Tree
{
    public class Folder
    {
        public string Name { get; private set; }
        public List<File> Files { get; private set; }
        public List<Folder> ChildFolders { get; private set; }

        public Folder(string name)
        {

            if (name.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Empty folder filename");

            }

            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public void AddFile(string name, int size)
        {
            this.Files.Add(new File(name, size));
        }

        public Folder AddFolder(string name)
        {
            Folder newFolder = new Folder(name);
            this.ChildFolders.Add(newFolder);
            return newFolder; // chaining
        }

        public long FolderSize()
        {
            long size = 0;
            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            foreach (var folder in this.ChildFolders)
            {
                size += folder.FolderSize();
            }

            return size;
        }
    }
}
