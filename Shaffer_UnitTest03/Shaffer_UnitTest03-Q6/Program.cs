using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: David Schuh, Nicholas Shaffer
// Date: 11/18/2020
namespace Shaffer_UnitTest03_Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree node = null;
            BTree root = null;

            node = new BTree(1, null, true);
            root = node;

            node = new BTree(5, root, true);
            node = new BTree(15, root, true);
            node = new BTree(20, root, true);
            node = new BTree(21, root, true);
            node = new BTree(22, root, true);
            node = new BTree(23, root, true);
            node = new BTree(24, root, true);
            node = new BTree(25, root, true);
            node = new BTree(30, root, true);
            node = new BTree(35, root, true);
            node = new BTree(37, root, true);
            node = new BTree(40, root, true);
            node = new BTree(55, root, true);
            node = new BTree(60, root, true);

            List<int> nodesAscending = new List<int>();
            nodesAscending = BTree.TraverseAscending(root, nodesAscending);

            node = new BTree(nodesAscending[7], null, true);
            root = node;

            node = new BTree(nodesAscending[3], root, true);
            node = new BTree(nodesAscending[11], root, true);

            node = new BTree(nodesAscending[1], root, true);
            node = new BTree(nodesAscending[5], root, true);
            node = new BTree(nodesAscending[9], root, true);
            node = new BTree(nodesAscending[13], root, true);

            node = new BTree(nodesAscending[0], root, true);
            node = new BTree(nodesAscending[2], root, true);
            node = new BTree(nodesAscending[4], root, true);
            node = new BTree(nodesAscending[6], root, true);
            node = new BTree(nodesAscending[8], root, true);
            node = new BTree(nodesAscending[10], root, true);
            node = new BTree(nodesAscending[12], root, true);
            node = new BTree(nodesAscending[14], root, true);
        }
    }

    /// 
    ///  Our Binary Tree Class
    /// 
    public class BTree
    {
        //////////////////////////////////////////////////////////
        ///  The most important 3 fields of any Binary Search Tree

        // the "less than" branch off of this node
        public BTree ltChild;

        // the "greater than or equal to" branch off of this node
        public BTree gteChild;

        // the data contained in this node
        public int data;
        //////////////////////////////////////////////////////////


        // a boolean to indicate if this is actual data or seed data to prime the tree
        public bool isData;

        //////////////////////////////////////////////////////////
        // overload all operators to compare BTree nodes by int or string data
        public static bool operator ==(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                returnVal = ((int)a.data == (int)b.data);
            }
            catch
            {
                returnVal = (a == (object)b);
            }

            return (returnVal);
        }
        public static bool operator !=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                returnVal = ((int)a.data != (int)b.data);
            }
            catch
            {
                returnVal = (a != (object)b);
            }

            return (returnVal);
        }
        public static bool operator <(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                returnVal = ((int)a.data < (int)b.data);
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        public static bool operator >(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                returnVal = ((int)a.data > (int)b.data);
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        public static bool operator >=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                returnVal = ((int)a.data >= (int)b.data);
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        public static bool operator <=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                returnVal = ((int)a.data <= (int)b.data);
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        //////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////
        // The constructor which will add the new node to an existing tree
        // if a non-null root is passed in
        // isData defaults to true, but can be set to false if seed data is being added to prime the tree
        public BTree(int nData, BTree root, bool isData = true)
        {
            this.ltChild = null;
            this.gteChild = null;
            this.data = nData;
            this.isData = isData;

            // if a tree exists to add this node to
            if (root != null)
            {
                AddChildNode(this, root);
            }
        }
        //////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////
        /// Recursive AddChildNode method adds BTree nodes to an existing tree
        public static void AddChildNode(BTree newNode, BTree treeNode)
        {
            // if the new node >= the tree node (use the operator overrides)
            if (newNode >= treeNode)
            {
                // if there is not a child node greater than this tree node (ie. gteChild == null)
                if (treeNode.gteChild == null)
                {
                    // set this node's "greater than or equal to" child to this new node
                    treeNode.gteChild = newNode;
                }
                else
                {
                    // otherwise recursively add the new node to the "greater than or equal to" branch
                    AddChildNode(newNode, treeNode.gteChild);
                }
            }
            else
            {
                // the new node < this tree node
                // if there is not a child node less than this tree node (ie. ltChild == null)
                if (treeNode.ltChild == null)
                {
                    // set this node's "less than" child to this new node
                    treeNode.ltChild = newNode;
                }
                else
                {
                    // otherwise recursively add the new node to the "less than" branch
                    AddChildNode(newNode, treeNode.ltChild);
                }
            }
        }
        //////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////
        // Print the tree in ascending order
        public static List<int> TraverseAscending(BTree node, List<int> nodesAscending)
        {
            if (node != null)
            {
                // handle "less than" children
                TraverseAscending(node.ltChild, nodesAscending);

                if (node.isData)
                {
                    // handle current node
                    nodesAscending.Add(node.data);
                }

                // handle "greater than or equal to children"
                TraverseAscending(node.gteChild, nodesAscending);
            }

            return nodesAscending;
        }
    }
}
