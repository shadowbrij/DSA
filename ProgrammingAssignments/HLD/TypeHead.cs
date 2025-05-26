using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.HLD
{
    class TrieNode
    {
        public TrieNode[] Child = new TrieNode[26];
        public List<Tuple<int, string>> BestFive = new List<Tuple<int, string>>();
        public bool IsEnd;
    }

    class TypeHead
    {
        public TrieNode Root;
        private Dictionary<string, int> Freq = new Dictionary<string, int>();

        public TypeHead()
        {
            Root = GetNode();
            Freq.Clear();
        }

        private TrieNode GetNode()
        {
            TrieNode pNode = new TrieNode();
            pNode.IsEnd = false;
            for (int i = 0; i < 26; i++)
                pNode.Child[i] = null;
            return pNode;
        }
        public void IncrementSearchTermFrequency(string search_term, int increment)
        {
            TrieNode temp = Root;
            Freq[search_term] = Freq.GetValueOrDefault(search_term, 0) + increment;
            for (int i = 0; i < search_term.Length; i++)
            {
                int chr_val = search_term[i] - 'a';
                if (temp.Child[chr_val] == null)
                {
                    temp.Child[chr_val] = GetNode();
                }
                temp = temp.Child[chr_val];
                temp.BestFive = temp.BestFive.OrderBy(x => x.Item1).ToList();
                bool found = false;
                for (int j = 0; j < temp.BestFive.Count; j++)
                {
                    if (temp.BestFive[j].Item2 == search_term)
                    {
                        found = true;
                        temp.BestFive[j] = new Tuple<int, string>(Freq[search_term], search_term);
                    }
                }
                if (!found && (temp.BestFive.Count < 5 || temp.BestFive[0].Item1 <= Freq[search_term]))
                {
                    if (temp.BestFive.Count < 5)
                    {
                        temp.BestFive.Add(new Tuple<int, string>(Freq[search_term], search_term));
                    }
                    else if (Freq[search_term] > temp.BestFive[0].Item1 || string.Compare(search_term, temp.BestFive[0].Item2) > 0)
                    {
                        temp.BestFive[0] = new Tuple<int, string>(Freq[search_term], search_term);
                    }
                }
                temp.BestFive = temp.BestFive.OrderBy(x => x.Item1).ToList();
            }
            temp.IsEnd = true;
        }

        public List<string> FindTopXSuggestion(string queryPrefix, int X)
        {
            TrieNode temp = Root;
            List<string> ans = new List<string>();
            for (int i = 0; i < queryPrefix.Length; i++)
            {
                int chr_val = queryPrefix[i] - 'a';
                if (temp.Child[chr_val] == null)
                {
                    temp = temp.Child[chr_val];
                    break;
                }
                temp = temp.Child[chr_val];
            }
            if (temp != null)
            {
                List<Tuple<int, string>> v = temp.BestFive;
                v = v.OrderBy(x => x.Item1).ToList();
                for (int j = v.Count - 1; j >= 0 && ans.Count < X; j--)
                {
                    ans.Add(v[j].Item2);
                }
            }
            while (ans.Count < X)
            {
                ans.Add("");
            }
            ans.Sort();
            return ans;
        }
    }
}
