﻿namespace BinarySearchTree;

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();

        // bst.Insert(47);
        // bst.Insert(21);
        // bst.Insert(76);
        // bst.Insert(18);
        // bst.Insert(52);
        // bst.Insert(82);
        // bst.Insert(22);
        // bst.Insert(73);
        // bst.Insert(91);
        // bst.Insert(79);
        // bst.Insert(48);
        // bst.Insert(30);
        //
        // Console.WriteLine(bst.RecursiveContains(30));
        // Console.WriteLine(bst.RecursiveContains(92));

        bst.RecursiveInsert(76);
        bst.RecursiveInsert(54);
        bst.RecursiveInsert(87);
        bst.RecursiveInsert(43);
        bst.RecursiveInsert(23);
        bst.RecursiveInsert(47);
        bst.RecursiveInsert(96);
        bst.RecursiveInsert(87);
        bst.RecursiveInsert(79);

    

        // bst.RecursiveDelete(43);

        bst.PrintTree();
        Console.WriteLine();
        
        bst.DepthFirstSearchInOrderRecursive().ForEach(i => Console.Write($"{i}, "));

        // Console.WriteLine("----------------------------------");
        //
        // AvlTree avl = new AvlTree();
        //
        // avl.Insert(47);
        // avl.Insert(21);
        // avl.Insert(76);
        // avl.Insert(18);
        // avl.Insert(52);
        // avl.Insert(82);
        //
        // avl.PrintWithHeights();
        //
        // Console.WriteLine("----------------------------------");
        //
        // RedBlackTree rbTree = new RedBlackTree();
        //
        // rbTree.Insert(7);
        // rbTree.Insert(3);
        // rbTree.Insert(18);
        // rbTree.Insert(10);
        // rbTree.Insert(22);
        // rbTree.Insert(8);
        // rbTree.Insert(11);
        // rbTree.Insert(19);
        // rbTree.Insert(20);
        //
        // rbTree.PrintWithColors();
    }
}