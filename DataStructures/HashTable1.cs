using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class HashTable1
    {
        private readonly LinkedList<DictionaryEntry>[] _container;

        public HashTable1(int num) // num is the capacity of the table.
        {
            
            _container = new LinkedList<DictionaryEntry>[num]; // set it to ten
            for(var i = 0; i < num; i++)
            {
                _container[i] = new LinkedList<DictionaryEntry>();
            }
        }
        

        public void Put(int k, string v)            // O(1)
        {
            var hashCode = HashCode(k);

            var entry = new DictionaryEntry(k, v);

            var index = Hash(hashCode);

            var ll = _container[index];

            // BEFORE putting in, check for duplicate
            if (ll.Contains(entry))
            {//////////////////// work on this: how should I update key
                DictionaryEntry pairFound;
                foreach (var pairs in ll)
                {
                    if((int)pairs.Key == k)
                    {
                        pairFound = pairs;
                        break;
                    }
                }
                pairFound.Value = v;
            }
            // push in the (k,v) into the container
            _container[index].AddLast(entry);       // O(1)
        }
        public string Get(int k)                    // O(n+1)
        {
            // get key's hashcode
            var hashCode = HashCode(k);
            // find index to put in
            var index = Hash(hashCode);
            // locate index, iterate over linkedlist
            var ll = _container[index];             // O(1)
            
            var p = ll.First; // pointer
            return FindValue(ll, p, k);
        }
        public void Remove(int k)
        {
            int hashCode = HashCode(k);
            int index = Hash(hashCode);
            // locate index, iterate over linkedlist
            var ll = _container[index];             // O(1)
            var p = ll.First;
            if (FindValue(ll, p, k) != null)
            {
                ll.Remove(p);
            }
            else
            {
                throw new ArgumentException();
            }

        }

        private string FindValue(LinkedList<DictionaryEntry> ll, LinkedListNode<DictionaryEntry> p , int k)
        {
            // if key is in the table
            if (FindKeyInList(ll, p, k))
                return (string)p.Value.Value;
            // if key is not in the table
            throw new Exception("Cannot find a stored value for the input key");
        }
        private bool FindKeyInList(LinkedList<DictionaryEntry> ll, LinkedListNode<DictionaryEntry> p, int k)
        {
            // iterate over linked list                     // O(n)
            foreach (var pair in ll)
            {
                if((int)pair.Key == k)
                {
                    return true;
                }
            }
            return false;
            
        }
        
        private static int HashCode(int k)
        {
            // get key's hashcode
            return Math.Abs(k.GetHashCode());
        }

        private int Hash(int hashCode)
        {
            // find index to put in
            return hashCode % _container.Length;
        }
    }

}
