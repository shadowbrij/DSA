using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.HLD
{
    public class TypeaheadSearch
    {
        TypeHeadTrieNode root;
        public TypeaheadSearch()
        {
            root = new TypeHeadTrieNode();
        }
        // Increment the frequency of the search term by the given increment
        public void IncrementSearchTermFrequency(string search_term, int increment)
        {
            int L = search_term.Length;
            var temp = root;
            for (int i = 0; i < L; i++)
            {
                var index = search_term[i] - 'a';
                if (temp.children[index] == null)
                {
                    temp.children[index] = new TypeHeadTrieNode();
                    temp.children[index].searchTermFrequency.Add(search_term, increment);
                }
                if(temp.children[index].searchTermFrequency.Count < 5)
                {
                    temp.children[index].searchTermFrequency.Add(search_term, increment);
                }
                else
                {
                    var max = temp.children[index].searchTermFrequency.Max(x => x.Value);
                    if (increment > max)
                    {
                        temp.children[index].searchTermFrequency.Remove(temp.children[index].searchTermFrequency.First(x => x.Value == max).Key);
                        temp.children[index].searchTermFrequency.Add(search_term, increment);
                    }
                }
            }
        }

        // Find the top X search terms that have the given prefix and highest frequency
        public List<string> FindTopXSuggestion(string queryPrefix, int X)
        {
            var temp = root;
            for (int i = 0; i < queryPrefix.Length; i++)
            {
                var index = queryPrefix[i] - 'a';
                if (temp.children[index] != null)
                {                    
                    root = temp.children[index];
                }
            }
            var ans = new List<string>();
            ans.AddRange(root.searchTermFrequency.OrderByDescending(x => x.Value).Select(x => x.Key).Take(X).ToList());
            if(ans.Count < X)
            {
                ans.AddRange(Enumerable.Repeat("",X-ans.Count));
            }
            return ans;
        }
    }

    class TypeHeadTrieNode
    {
        public TypeHeadTrieNode[] children; 
        public bool isEndOfWord;
        public Dictionary<string, int> searchTermFrequency; 
        public TypeHeadTrieNode() 
        {
            children = new TypeHeadTrieNode[26];
            searchTermFrequency = new Dictionary<string, int>(5);
        }
    }
}
