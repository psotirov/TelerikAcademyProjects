using System;
using System.Collections.Generic;

namespace _01_N_Nodes_tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public bool HasParent { get; set; }

        public TreeNode(T value)
        {
            this.Children = new List<TreeNode<T>>();
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
