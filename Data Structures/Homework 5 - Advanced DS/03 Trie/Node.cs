using System;
using System.Collections;
using System.Text;

namespace Trie
{
    //Represents a tree node. The node could be a root or a child.
    public class Node
    {
        //Children
        NodeCollection _children = null;

        //Parent
        Node _parent = null;

        //value of each node
        string _value = "";

        //value of each node
        string _key = "";

        //is terminal node
        bool _isTerminal = false;

        //Constructor
        public Node(string key, string value)
        {
            //creates an empty collection
            _children = new NodeCollection(this);
            _key = key;
            _value = value;
        }

        //Gets the parent node
        public Node Parent
        {
            get
            {
                return _parent;
            }
            internal set
            {
                _parent = value;
            }
        }

        //Gets the children
        public NodeCollection Children
        {
            get
            {
                return _children;
            }
        }

        //Gets the root node
        public Node Root
        {
            get
            {
                if (null == _parent) return this;
                return _parent.Root;
            }
        }

        //Determins if this node is ancestor of the given node
        public bool IsParentOfNode(Node node)
        {
            if (_children.Contains(node)) return true;
            foreach (Node childNode in _children)
                if (childNode.IsParentOfNode(node)) return true;
            return false;
        }

        //Determins if this node is descendant of the given node
        public bool IsChildOfNode(Node node)
        {
            if (null == _parent) return false;
            if (node == _parent) return true;
            return _parent.IsChildOfNode(node);
        }

        //determines if this node shares hierarchy with given node
        public bool IsParentOrChild(Node node)
        {
            if (node == this) return true;
            if (this.IsParentOfNode(node)) return true;
            if (this.IsChildOfNode(node)) return true;
            return false;
        }

        //Gets the node value
        public string Value
        {
            get
            {
                return _value;
            }
        }

        //Gets the node value
        public bool IsTerminal
        {
            get
            {
                return _isTerminal;
            }

            set
            {
                _isTerminal = value;
            }
        }

        //Gets the node value
        public string Key
        {
            get
            {
                return _key;
            }
        }

        //iterates depth first, returns all the keys
        public IEnumerator GetDepthKeys()
        {
            yield return _key; // _value;

            foreach (Node child in _children)
            {
                IEnumerator childEnumerator = child.GetDepthKeys();
                while (childEnumerator.MoveNext())
                    yield return childEnumerator.Current;
            }
        }

        //iterate breadth first
        public IEnumerator GetBreadthNodes()
        {
            System.Collections.Generic.Queue<Node> que = new System.Collections.Generic.Queue<Node>();
            que.Enqueue(this);
            while (0 < que.Count)
            {
                Node node = que.Dequeue();
                foreach (Node child in node._children)
                    que.Enqueue(child);
                yield return node; // _value;
            }
        }

        //iterates depth first, returns all the nodes
        public System.Collections.IEnumerator GetDepthNodes()
        {
            yield return this;

            foreach (Node child in _children)
            {
                IEnumerator childEnumerator = child.GetDepthNodes();
                while (childEnumerator.MoveNext())
                    yield return childEnumerator.Current;
            }

        }
    }
}
