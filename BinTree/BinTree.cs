using System;
using System.Collections.Generic;
using System.Text;

namespace BinTree
{
    class BinTree<T> where T : IComparable
    {
        protected private Node<T> root; //change to protected

        public BinTree()  //creates an empty tree
        {
            root = null;
        }

        public BinTree(Node<T> node)  //creates a tree with node as the root
        {
            root = node;
        }

        public string PreOrder() //for the user of this class - hides the node away
        {
            string buffer = "";
            return preOrder(root, ref buffer);//start recursion at the top of the tree
        }

        private string preOrder(Node<T> tree, ref string buffer)//currrent node we are on for this copy of the code
        {
            //stopping codition - empty tree (null)
            if (tree != null)
            {
                buffer += "," + tree.Data.ToString();
                preOrder(tree.Left, ref buffer);
                preOrder(tree.Right, ref buffer);
            }
            return buffer;

        }

        public string InOrder()
        {
            string buffer = "";
            return inOrder(root, ref buffer);
        }

        private string inOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                inOrder(tree.Left, ref buffer);
                buffer += "," + tree.Data.ToString();
                inOrder(tree.Right, ref buffer);
            }
            return buffer;
        }

        public string PostOrder()
        {
            string buffer = "";
            return postOrder(root, ref buffer);
        }

        private string postOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                postOrder(tree.Left, ref buffer);
                postOrder(tree.Right, ref buffer);
                buffer += "," + tree.Data.ToString();
            }
            return buffer;
        }

        public void Copy(BinTree<T> tree2)
        {
            copy(ref root, tree2.root);
        }

        private void copy(ref Node<T> tree, Node<T> tree2)
        {
            tree = new Node<T>(tree2.Data);
            if (tree2.Left != null)
                copy(ref tree.Left, tree2.Left);
            if (tree2.Right != null)
                copy(ref tree.Right, tree2.Right);
        }

        public int Count()
        {
            return count(root);
        }

        private int count(Node<T> tree)
        {
            if (tree == null)
                return 0;
            return 1 + count(tree.Left) + count(tree.Right);
        }

        public int Height()
        //Return the max level of the tree
        {
            return height(root);
        }

        public int subHeight(Node<T> tree)
        //Return the max level of the tree
        {
            return height(tree);
        }

        private int height(Node<T> tree)
        {
            //higher count left or right
            if (tree == null)
                return 0;
            if (count(tree.Left) > count(tree.Right))
                return 1 + height(tree.Left);
            else
                return 1 + height(tree.Right);
        }

        public Boolean Contains(T item)
        //Return true if the item is contained in the BSTree, false 	  //otherwise.
        {
            return contains(item, root);
        }

        private Boolean contains(T item, Node<T> tree)
        {
            if (tree == null)
                return false;
            if (item.CompareTo(tree.Data) == 0)
                return true;
            if (item.CompareTo(tree.Data) < 0)
                return contains(item, tree.Left);
            if (item.CompareTo(tree.Data) > 0)
                return contains(item, tree.Right);
            else
                return false;

        }


    }

}


