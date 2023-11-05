using System;
using System.Collections.Generic;

public class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> Find(Func<T, bool> criteria)
    {
        List<T> results = new List<T>();
        foreach (T item in items)
        {
            if (criteria(item))
            {
                results.Add(item);
            }
        }
        return results;
    }
}

class Program
{
    static void Main()
    {
        Repository<int> intRepository = new Repository<int>();
        intRepository.Add(1);
        intRepository.Add(2);
        intRepository.Add(3);
        intRepository.Add(4);

        List<int> evenNumbers = intRepository.Find(x => x % 2 == 0);
        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

        Repository<string> stringRepository = new Repository<string>();
        stringRepository.Add("apple");
        stringRepository.Add("banana");
        stringRepository.Add("cherry");
        stringRepository.Add("date");

        List<string> fruitsStartingWithA = stringRepository.Find(s => s.StartsWith("a"));
        Console.WriteLine("Fruits starting with 'a': " + string.Join(", ", fruitsStartingWithA));
    }
}
