namespace BinarySearchTree;

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(47);
        bst.Insert(21);
        bst.Insert(76);
        bst.Insert(18);
        bst.Insert(52);
        bst.Insert(82);
        bst.Insert(22);
        bst.Insert(73);
        bst.Insert(91);
        bst.Insert(79);
        bst.Insert(48);
        bst.Insert(30);
        

        bst.PrintTree();
    }
}