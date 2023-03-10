using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace BinTree
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree) // ref as we are changing the tree
        {
            //stopping condition
            if (tree == null)
                tree = new Node<T>(item);
            //recursive
            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);
            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
            else
                Console.WriteLine("Coundn't add " + item + " as it is already in the tree");
        }

        public bool Equals(BSTree<T> tree)
        {
            return InOrder() == tree.InOrder();
        }


        public bool SubTree(BSTree<T> tree)
        {
            return InOrder().Contains(tree.InOrder());
        }




    }

}
