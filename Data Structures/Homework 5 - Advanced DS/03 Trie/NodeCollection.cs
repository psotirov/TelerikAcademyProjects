using System;
using System.Collections;
using System.Collections;
using System.Text;

namespace Trie
{
    //Represents the collection of nodes
    public class NodeCollection : IEnumerable
    {
        //Internal list contains the children nodes.
        System.Collections.Generic.List<Node> _children = new System.Collections.Generic.List<Node>();

        //repewsents the owner
        Node _owner = null;

        internal NodeCollection(Node owner)
        {
            if (null == owner) throw new ArgumentNullException("Owner");
            _owner = owner;
        }

        //Adds a node into the children list
        public void Add(Node node)
        {
            //cannot readd a same node
            if (_owner.IsParentOrChild(node))
                throw new InvalidOperationException("Cannot add an ancestor or descendant.");
            _children.Add(node);
            node.Parent = _owner;
        }

        //Determins if the children nodes contains the given value
        public bool ContainsValue(string value)
        {
            foreach (Node item in _children)
            {
                if (item.Value.ToString() == value)
                    return true;
            }
            return false;
        }

        //Determins if the children nodes contain the given key
        public bool ContainsKey(string value)
        {
            foreach (Node item in _children)
            {
                if (item.Key.ToString() == value)
                    return true;
            }
            return false;
        }

        //Returns a node based on the key
        public Node GetNodeByKey(string value)
        {
            foreach (Node item in _children)
            {
                if (item.Key.ToString() == value)
                    return item;
            }
            return null;
        }

        //Returns a node based on the value
        public Node GetNodeByValue(string value)
        {
            foreach (Node item in _children)
            {
                if (item.Value.ToString() == value)
                    return item;
            }
            return null;
        }

        //Removes a node
        public void Remove(Node node)
        {
            _children.Remove(node);
            node.Parent = null;
        }

        //Determins if the children contains a node, test for equality
        public bool Contains(Node node)
        {
            return _children.Contains(node);
        }

        //Clears all the nodes
        public void Clear()
        {
            foreach (Node node in this)
                node.Parent = null;
            _children.Clear();
        }

        //Returns the count of children
        public int Count
        {
            get
            {
                return _children.Count;
            }
        }

        //Returns the owner
        public Node Owner
        {
            get
            {
                return _owner;
            }
        }

        //Returns the node based on index
        public Node this[int index]
        {
            get
            {
                return _children[index];
            }
        }

        //returns the enumerator
        public IEnumerator GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        //returns the enumerator
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
