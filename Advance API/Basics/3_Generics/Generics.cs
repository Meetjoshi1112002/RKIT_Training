using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Theroy:

    We can have generic classes as well as method

    we can add constrains to the types as well

    eg: Where T : class --> means the T must be a class type only
        Where T : struct --> means T must be a value type
        Where T : interface --> means T must implement that   pareticular interface
        Where T : baseClass --> means T maust be that class or its derived class
        Where T : new() -- > Restricts T to have a public parameterless constructor.

        Where T : new(),Ientity, class --> T must be a reference type, implement IEntity, and have a parameterless constructor
 
 */

namespace Advance_API.Generics
{

    // example of generic method:
    public class Sample
    {
        public T Max<T>(T a, T b) where T : IComparable  // --> means T must implement I comparable 
        {
            return a.CompareTo(b) > 0 ? a:b;
        }
    }

    // example of generic class 
    internal class MeetsDic<TKey, TValue>
    {
        private List<TKey> keys = new ();
        private List<TValue> values = new();

        // Properties to get keys 
        public IEnumerable<TKey> GetKeys => keys;  // this is similart --> public IEnum<> GetKeys { get{ return Keys;}} and this is a read only  property
        public int KeyCount => keys.Count; // another readonly bodied sytax property

        // Add methods to add key , values
        public void Add(TKey key, TValue value)
        {
            if(keys.Contains(key))
            {
                throw new ArgumentException("Key alaready exits");
            }
            keys.Add(key);
            values.Add(value);
        }

        // Get a value by key
        public TValue Get(TKey key)
        {
            int index = keys.IndexOf(key);
            if(index == -1)
            {
                throw new ArgumentException("key not found ");
            }
            return values[index];
        }

        // Check if a key exists
        public bool ContainsKey(TKey key)
        {
            return keys.Contains(key);
        }

        // Remove a key-value pair
        public void Remove(TKey key)
        {
            int index = keys.IndexOf(key);
            if (index == -1)
            {
                throw new KeyNotFoundException("Key not found.");
            }
            keys.RemoveAt(index);
            values.RemoveAt(index);
        }


        // Indexers for my dictionry
        public TValue this[TKey key]
        {
            get
            {
                int index = keys.IndexOf(key);
                if (index == -1)
                {
                    throw new ArgumentException("key not found ");
                }
                return values[index];
            }
        }
    }
}
