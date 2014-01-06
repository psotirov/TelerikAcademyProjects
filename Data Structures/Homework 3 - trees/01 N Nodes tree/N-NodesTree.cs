using System;
using System.Collections.Generic;
using System.IO;

namespace _01_N_Nodes_tree
{
    class NNodesTree
    {
        static void Main()
        {
            Console.SetIn(new StreamReader(@"../../input.txt"));
            int numberOfNodes = int.Parse(Console.ReadLine());

            // each node is in range [0, N-1]
            // creates an array of all possible nodes
            // then we can build the tree using this array  
            TreeNode<int>[] allPossibleNodes = new TreeNode<int>[numberOfNodes];
            for (int i = 0; i < numberOfNodes; i++)
            {
                allPossibleNodes[i] = new TreeNode<int>(i);
            }

            // reads and creates parent-child relations - edges
            // as a result we will have all subtrees with depth of 1
            for (int i = 1; i <= numberOfNodes - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                string[] edgeParts = edgeAsString.Split(' ');

                int parentId = int.Parse(edgeParts[0]);
                int childId = int.Parse(edgeParts[1]);

                allPossibleNodes[parentId].Children.Add(allPossibleNodes[childId]);
                allPossibleNodes[childId].HasParent = true;
            }

            // 1. Find the root
            TreeNode<int> root = FindRoot(allPossibleNodes);
            Console.WriteLine("\nThe root of the tree is: {0}", root.Value);

            // 2. Find all leafs
            List<TreeNode<int>> leafs = FindAllLeafs(allPossibleNodes);
            Console.WriteLine("\nLeafs: " + string.Join(", ", leafs));

            // 3. Find all middle nodes
            List<TreeNode<int>> middleNodes = FindAllMiddleNodes(allPossibleNodes);
            Console.WriteLine("\nMiddle nodes: " + string.Join(", ", middleNodes));

            // 4. Find the longest path from the root
            int longestPath = FindLongestPath(root);
            Console.WriteLine("\nNumber of levels: {0}", longestPath);


            // reads sums for tasks 5 and 6
            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            // 5. Find all paths that have sum of S (S = 9 as input)
            List<List<TreeNode<int>>> allSumPaths = new List<List<TreeNode<int>>>();
            FindAllSumPaths(allSumPaths, new List<TreeNode<int>>(), root, pathSum);
            Console.WriteLine("\nAll paths that have sum of {0}:", pathSum);
            foreach (var item in allSumPaths)
            {
                Console.WriteLine(string.Join(", ", item));
            }

            // 6. Find all subtrees that have sum of S (S = 12 as input)
            List<TreeNode<int>> allSumRoots = new List<TreeNode<int>>();
            FindAllSumTrees(allSumRoots, root, subtreeSum);
            Console.WriteLine("\nAll root nodes of subtrees that have sum of {0}: {1}", subtreeSum, string.Join(", ", allSumRoots));
            // TODO: we can show all nodes of the result subtrees
        }

        /// <summary>
        /// Task 1 - Finds tree's root node
        /// </summary>
        private static TreeNode<int> FindRoot(TreeNode<int>[] nodes)
        {
            // the root is the first node that has no parent
            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("nodes", "The tree has no root.");
        }

        /// <summary>
        /// Task 2 - Finds tree's longest path recursively
        /// </summary>
        private static int FindLongestPath(TreeNode<int> root)
        {
            // a single root node has path of 1
            if (root.Children.Count == 0)
            {
                return 1;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                // DFS recursive traversing all child subtrees
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            // each egde increases the path 
            return maxPath + 1;
        }

        /// <summary>
        /// Task 3 - Finds all middle (inner) nodes of the tree
        /// </summary>
        private static List<TreeNode<int>> FindAllMiddleNodes(TreeNode<int>[] nodes)
        {
            List<TreeNode<int>> middleNodes = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                // every node that has parent  and at least one child is middle node
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        /// <summary>
        /// Task 4 - Finds all leafs of the tree
        /// </summary>
        private static List<TreeNode<int>> FindAllLeafs(TreeNode<int>[] nodes)
        {
            List<TreeNode<int>> leafs = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                // every node that has no childs is leaf
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        /// <summary>
        /// Task 5 - Finds all paths in the tree that have certain sum of its nodes
        /// </summary>
        private static void FindAllSumPaths(List<List<TreeNode<int>>> allPaths, List<TreeNode<int>> path, TreeNode<int> root, int sum)
        {
            // adds current element to the path (stored in stack of the recursive invoked method)
            path.Add(root);

            // an end of path has been reached - checks path and adds it to the result
            if (root.Children.Count == 0)
            {
                int currentSum = 0;
                foreach (var item in path)
                {
                    currentSum += item.Value;
                }

                if (currentSum == sum)
                {
                    allPaths.Add(path);  
                }
                return;
            }

            foreach (var node in root.Children)
            {
                // each branch works on a copy of current subpath 
                List<TreeNode<int>> newPath = path.GetRange(0, path.Count);

                // DFS recursive traversing all child subtrees
                FindAllSumPaths(allPaths, newPath, node, sum);
            }
        }
        
        /// <summary>
        /// Task 6 - Finds all subtrees that have certain sum of its nodes
        /// </summary>
        private static int FindAllSumTrees(List<TreeNode<int>> allRoots, TreeNode<int> root, int sum)
        {
            int currentSum = root.Value;
            foreach (var node in root.Children)
            {
                // DFS recursive traversing all child elements
                currentSum += FindAllSumTrees(allRoots, node, sum);
            }

            if (currentSum == sum)
            {
                allRoots.Add(root);
            }

            return currentSum;
        }
    }
}
