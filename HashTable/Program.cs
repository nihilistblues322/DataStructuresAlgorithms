namespace HashTable;

class Program
{
    static void Main(string[] args)
    {
        HashTable hashTable = new HashTable();
        
        hashTable.Set("nails", 100);
        hashTable.Set("coffees", 100);
        hashTable.Set("milk", 100);
        hashTable.Set("bolts", 100);
        hashTable.Set("screws", 100);
        
        hashTable.PrintTable();
        
        
        
    }
}