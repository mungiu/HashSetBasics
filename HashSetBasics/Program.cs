using System;
using System.Collections.Generic;

namespace HashSetBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>
                (new UncasedStringEqualityComparer())
            {
                "New York", "Manchester", "Chisinau", "Paris"
            };
            //checking if elements where added as bool
            //.Add returns "bool"
            bool addedChisinau = bigCities.Add("CHISINAU");
            bool addedHorsens = bigCities.Add("HORSENS");
            Console.WriteLine(addedChisinau);
            Console.WriteLine(addedHorsens + "\r\n");

            ////HasSet checks against duplicate creation
            ////checks for duplicate fast -> internally based on HashTable
            //bigCities.Add("Chisinau");
            //bigCities.Add("Horsens");

            ////adding item to a list twice doubles it, so check for duplicate
            ////this is resource intensive (checks every element)
            //if (!bigCities.Contains("Sheffield"))
            //    bigCities.Add("Sheffield");
            //if (!bigCities.Contains("Horsens"))
            //    bigCities.Add("Horsens");

            foreach (string city in bigCities)
                Console.WriteLine(city);
        }
    }

    /// <summary>
    /// Custom comparer to be used at will
    /// </summary>
    class UncasedStringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }

        public int GetHashCode(string obj)
        {
            return obj.ToUpper().GetHashCode();
        }
    }
}
