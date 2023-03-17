using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Tries
{
    class AutoComplete
    {
        public void DoAutoComplete(string[] words, string[] prefixes, int[] weigths, int N)
        {
            //create map of weights->words
            var map = new Dictionary<int, string>();
            for (int i = 0; i < N; i++)
            {
                map.Add(weigths[i], words[i]);
            }

            //var WWMap = map.OrderByDescending(r => r.Key);
            /*****Returns IOrderderedEnumerable.... Items can be accessed using.
            var item = WWMap.ElementAt(0);
            *********************************/


            //Prepare Trie
            var root = new TrieNode();
            foreach(var pair in map.OrderByDescending(r => r.Key))
            {
                InsertToTrie(pair.Value, root, pair.Key);
            }
            //for (int i = 0; i < N; i++)
            //{
            //    InsertToTrie(WWMap.ElementAt(i).Value, root, i);
            //}

            //for each prefixes, we need to output atmost 5 words
            foreach (var prefix in prefixes)
            {
                var toPrint = MatchAndReturnWords(prefix, root, map);
                foreach (var str in toPrint)
                {
                    Console.Write(str);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        List<string> MatchAndReturnWords(string prefix, TrieNode root, Dictionary<int, string> map)
        {
            var ans = new List<string>();
            var temp = root;
            int L = prefix.Length;

            for (int i = 0; i < L; i++)
            {
                var index = prefix[i] - 'a';
                if (temp.children[index] != null)
                {
                    temp = temp.children[index];
                }
                else
                {
                    ans.Add("-1");
                    return ans;
                }
            }
            //reached at a trie node which will give result
            foreach (var weight in temp.countW)
            {
                ans.Add(map[weight]);
            }
            return ans;
        }
        void InsertToTrie(string word, TrieNode root, int mapIndex)
        {
            var temp = root;
            for (int i = 0; i < word.Length; i++)
            {
                var index = word[i] - 'a';
                if (temp.children[index] == null)
                {
                    temp.children[index] = new TrieNode();
                    temp.children[index].countW.Add(mapIndex);
                }
                else
                {
                    if (temp.children[index].countW.Count < 5)
                        temp.children[index].countW.Add(mapIndex);
                }

                temp = temp.children[index];
            }
            temp.isEnd = true;
        }
    }

}
