namespace HashTable;

class Program
{
    static void Main(string[] args)
    {
        HashTable hashTable = new HashTable();

        hashTable.Set("milk", 87);
        hashTable.Set("coffees", 6);
        hashTable.Set("milk", 22);
        hashTable.Set("bolts", 64);
        hashTable.Set("screws", 54);
        hashTable.Set("pizza", 321);
        hashTable.Set("potato", 322);
        hashTable.Set("carrots", 77);
        
        hashTable.Get("milk");
        hashTable.Get("potato");

        hashTable.Keys();

        hashTable.PrintTable();


        int[] arr1 = [1, 3, 5];
        int[] arr2 = [2, 4, 5];
        Console.WriteLine(Test.ItemInCommon(arr1, arr2));
        Console.WriteLine(Test.ItemInHash(arr2, arr1));
    }
}