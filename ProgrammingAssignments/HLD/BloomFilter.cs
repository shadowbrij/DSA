using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.HLD
{
    class BloomFilter
    {
        /*
         A Bloom filter is a space-efficient probabilistic data structure that is used to test whether an element is a member of a set.

        Implement a Bloom Filter. Operations that the Bloom Filter should support are :

        insert(X) - Inserts the element X in the Bloom Filter.
        lookup(X) - Checks whether the element X is already present in Bloom Filter with a positive false probability. Returns a boolean value.

        Note:- The Bloom Filter should work with an error rate of less than 5%.
         */
        static HashSet<String> hashset = new HashSet<String>();
        static bool lookup(String s)
        {
            return hashset.Contains(s);
        }

        static void insert(String s)
        {
            hashset.Add(s);
        }
    }
}
