using System;
using System.Collections.Generic;
using System.Text;

namespace BinTree
{
    class AVLTree<T> : BSTree<T> where T : IComparable
    {
        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);
            //recursive
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItem(item, ref tree.Left);
                tree = Balance(tree);
            }
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItem(item, ref tree.Right);
                tree = Balance(tree);
            }
            else
                Console.WriteLine("Coundn't add " + item + " as it is already in the tree");
        }

        private Node<T> Balance(Node<T> tree)
        {
            if (balanceFactor(tree) > 1) // for left
            {
                if (balanceFactor(tree.Left) > 0)
                    tree = RotateLeftLeft(tree);
                else
                    tree = RotateLeftRight(tree);
            }
            else if (balanceFactor(tree) < -1) // for right
            {
                if (balanceFactor(tree.Right) > 0)
                    tree = RotateRightLeft(tree);
                else
                    tree = RotateRightRight(tree);
            }
            return tree;
        }

        private int balanceFactor(Node<T> tree)
        {
            return subHeight(tree.Left) - subHeight(tree.Right);
        }

        private Node<T> RotateRightRight(Node<T> tree)
        {
            Node<T> newTree = tree.Right;
            tree.Right = newTree.Left;
            newTree.Left = tree;
            return newTree;
        }
        private Node<T> RotateLeftLeft(Node<T> tree)
        {
            Node<T> newTree = tree.Left;
            tree.Left = newTree.Right;
            newTree.Right = tree;
            return newTree;
        }
        private Node<T> RotateLeftRight(Node<T> tree)
        {
            Node<T> newTree = tree.Left;
            tree.Left = RotateRightRight(newTree);
            return RotateLeftLeft(tree);
        }
        private Node<T> RotateRightLeft(Node<T> tree)
        {
            Node<T> newTree = tree.Right;
            tree.Right = RotateLeftLeft(newTree);
            return RotateRightRight(tree);
        }
    }

}
