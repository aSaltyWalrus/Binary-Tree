using System;

namespace BinTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> AVLTree1 = new AVLTree<int>();
            AVLTree<int> AVLTree2 = new AVLTree<int>();
            int[] values1 = { 12, 6, 8, 16, 19, 21, 9, 30, 18, 2, 4, 54 };
            int[] values2 = { 8, 6, 9, 2, 4 };
            for (int i = 0; i < 12; i++)
            {
                AVLTree1.InsertItem(values1[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                AVLTree2.InsertItem(values2[i]);
            }

            Console.WriteLine("Tree 1: " + AVLTree1.InOrder());
            Console.WriteLine("Height: " + AVLTree1.Height());

            Console.WriteLine("Tree 2: " + AVLTree2.InOrder());
            Console.WriteLine("Height: " + AVLTree2.Height());

            Console.WriteLine("Is tree 1 equal to tree 2? " + AVLTree1.Equals(AVLTree2));
            Console.WriteLine("Is tree 2 a subtree of tree 1? " + AVLTree1.SubTree(AVLTree2));

        }
    }
}
