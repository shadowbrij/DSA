using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Tries
{
    class TrieNode
    {
        public bool isEnd;
        public List<int> countW;//max 5
        public TrieNode[] children;
        public TrieNode()
        {
            this.children = new TrieNode[26];
            this.countW = new List<int>();
        }
    }
}
