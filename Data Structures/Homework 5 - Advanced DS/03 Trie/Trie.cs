using System;
using System.Collections;
using System.Text;

namespace Trie
{
    public class Trie
    {
        /* Gets all the childern starting from a string
           ex: returns all names starting from Jo -> John, Joe, Joseph etc*/
        public static void GetChildrenStartingFromKey(Node node, string key)
        {
            //Get the node which has the value of "Jo"
            Node curNode = GetChildNode(node, key);

            //if "Jo" found:
            if (curNode != null)
            {
                //get the children of "Jo" -> John, Joe, Joseph etc
                IEnumerator iterator = curNode.GetDepthNodes();

                while (iterator.MoveNext())
                {
                    //get child
                    Node childNode = (Node)iterator.Current;

                    //Does child have a valid full name
                    if (childNode.IsTerminal)
                        Console.WriteLine(childNode.Value);
                }
            }

        }

        //Locates a node based on the key; eg. Locates "Jo" node on the tree
        public static Node GetChildNode(Node node, string key)
        {
            //Is key empty
            if (string.IsNullOrEmpty(key))
                return node;//terminal Node?

            //get the first character
            string first = key.Substring(0, 1);

            //get the tail: key - first character
            string tail = key.Substring(1);

            //current node
            Node curNode = node.Children.GetNodeByKey(first);

            //loop until you locate the key i.e. "Jo"
            if (curNode != null)
            {
                return GetChildNode(curNode, tail);
            }
            else
            {
                //not found, return null
                return null;
            }
        }

        //Find a node given the key("Jo")
        public static bool Find(Node node, string key)
        {
            //Is key empty
            if (string.IsNullOrEmpty(key))
                return true;//terminal Node

            //get the first character
            string first = key.Substring(0, 1);

            //get the tail: key - first character
            string tail = key.Substring(1);

            Node curNode = node.Children.GetNodeByKey(first);

            //loop until you locate the key i.e. "Jo"
            if (curNode != null)
            {
                return Find(curNode, tail);
            }
            else
            {
                //not found, return false
                return false;
            }
        }

        //Inserts Names into the Trie data structure
        public static Node InsertNode(string name, Node root)
        {
            //Is name null?
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Null Key");

            //set the index, start inserting characters
            int index = 1;

            //key
            string key;

            //start with the root node
            Node currentNode = root;

            //loop for all charecters in the name
            while (index <= name.Length)
            {
                //get the key character
                key = name[index - 1].ToString();

                //does the node with same key already exist?
                Node resultNode = currentNode.Children.GetNodeByKey(key);

                //No, this is a new key
                if (resultNode == null)
                {
                    //Add a node
                    Node newNode = new Node(key, name.Substring(0, index));

                    //If reached the last charaecter, this is a valid full name
                    if (index == name.Length)
                        newNode.IsTerminal = true;

                    //add the node to currentNode(i.e. Root node for the first time)
                    currentNode.Children.Add(newNode);

                    //set as the current node
                    currentNode = newNode;
                }
                else
                {
                    //node already exist, set as tghe current node
                    //and move to the next character in the name
                    currentNode = resultNode;
                }

                //move to the next character in the name
                index++;
            }

            //all done, return root node
            return root;
        }

    }
}
