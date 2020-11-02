using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DataStructures
{
    public class Exercises
    {
        public  static char firstUniqueChar(string word)
        {
            word = word.ToLower();
            var hash = new Dictionary<char, int>();
            var hash2 = new OrderedDictionary();


            for (var i = 0; i < word.Length; i++)
            {
                if (!hash.ContainsKey(word[i]))
                {
                    hash[word[i]] = 1;
                }
                else
                {
                    hash[word[i]]++;
                };
            }

            foreach (var letter in word)
            {
                if (hash[letter] == 1)
                {
                    return letter;
                }
            }
            foreach (var pair in hash)
            {
                if (pair.Value == 1)
                {
                    return pair.Key;
                }
                Console.WriteLine(pair.Key);
            }
            return 'N';
        }
        public static char firstDup(string word)
        {
            var set = new HashSet<char>();
            foreach(var letter in word)
            {
                if(set.Contains(letter) && letter != ' ')
                {
                    return letter;
                }
                set.Add(letter);
            }
            return 'N';
        }
    }
}
