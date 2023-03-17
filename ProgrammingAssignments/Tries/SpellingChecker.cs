using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Tries
{
    class SpellingChecker
    {
        public List<int> solve(List<string> A, List<string> B)
        {
            //prepare Trie
            var root = new TrieNode();
            foreach (var word in A)
            {
                var L = word.Length;
                var temp = root;
                for (int i = 0; i < L; i++)
                {
                    var index = word[i]-'a';
                    if (temp.children[index] == null)
                    {
                        temp.children[index] = new TrieNode();
                    }
                    temp = temp.children[index];
                }
                temp.isEnd = true;
            }

            var ans = new List<int>();
            foreach (var word in B)
            {
                ans.Add(SearchWord(word, root));
            }
            return ans;

        }
        int SearchWord(string word, TrieNode root)
        {
            var L = word.Length;
            var temp = root;
            for (int i = 0; i < L; i++)
            {
                var index = word[i] - 'a';
                if (temp.children[index] != null)
                {
                    temp = temp.children[index];
                }
            }
            return temp.isEnd ? 1 : 0;
        }
    }
}
