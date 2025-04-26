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
        hashTable.Set("qwe", 876);
        hashTable.Set("asd", 765);
        hashTable.Set("bacon", 786);


        hashTable.Get("milk");
        hashTable.Get("potato");

        hashTable.PrintTable();
    }
}