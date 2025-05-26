using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.HLD
{
    class ConsistentHashing
    {
        /*
        We have a hash ring where we have locations available from 0 degrees to 359 degrees. Implement a consistent hashing in the following way : You can add a server to the hash ring. We just need to pass the serverID and the hash functions automatically assign them one location on the hash ring. The serverID can be strings.

        To add any server you give input as ADD servername . This will add that server to your hash ring. You also have the option to remove an added server which can be done by giving the input as REMOVE servername . This will remove the server from the hash ring. Lastly, to the servers added on the ring, you can assign incoming requests based on keys.

        So, when you do ASSIGN keyname, you basically want to assign this request to one of the servers nearest to the name hash location in clockwise direction ( If no server found in clockwise direction, pick the nearest server from 0 degrees in clockwise direction or if there is more than one nearest server available then assign this request to the latest server added to that location). It has been guaranteed that all the key names and server names would be unique and at least one server exists for ASSIGN type requests.

        You are given two string vectors A and B and an integer array C. For all valid i, A[i] tells you the type of operation of i-th query and B[i] tells you the key/server name depending on the type of query and C[i] tells you the hashKey for the i-th operation. A[i] can only take 3 values - "ADD", "REMOVE", "ASSIGN". Ignore the hashKey value C[i] for "REMOVE" operations.

        For "ADD" queries, B[i] is an uppercase string with 5 or more letters. They are all unique among add queries.
        For "REMOVE" queries, B[i] is an uppercase string with 5 or more letters. They are all unique among remove queries.
        For "ASSIGN" queries, B[i] is an uppercase string with exactly 4 letters. They are all unique among all queries.

        You need to return an integer array. Let's call it ans. The value ans[i] should correspond to the output for the i-th query. The rules for the output are:
        For "ADD" queries, ans[i] should be equal to the number of keys that got reassigned to the server added in the i-th query.
        For "REMOVE" queries, ans[i] should be equal to the number of keys that assigned to the server getting removed (before removal).
        For "ASSIGN" queries, ans[i] should be equal to the hash location of the server where this request gets assigned.

        It is guaranteed that there will not be any removals of servers that are not already there. It is also guaranteed that number of queries of types "ADD" / "REMOVE" do not exceed 11 each.

        Note:
        While removing a server, all the keys assigned to that particular server will get reassigned according to the "ASSIGN" functionality.
        If there are more than one server at a specific location, then consider the latest added server to that location to serve the upcoming requests that needs to be assigned to a server at that location.    

        You are required to use the following hash function to assign degrees to servers/keys:

        int userHash(string username, int hashKey){
            const int p = hashKey;
            const int n = 360;
            int hashCode = 0;
            long long p_pow = 1;
            for (int i = 0; i < username.length(); i++) {
                char character = username[i];
                hashCode = (hashCode + (character - 'A' + 1) * p_pow) % n;
                p_pow = (p_pow * p) % n;
            }
            return hashCode;
        }  

        Input:
        A = [ADD, ASSIGN, ADD, ASSIGN, REMOVE, ASSIGN]
        B = [INDIA, NWFJ, RUSSIA, OYVL, INDIA, IGAX]
        C = [7, 3, 5, 13, -1, 17 ]       

        Output:
        0 31 1 203 0 203
        */
        public List<int> solve(List<string> A, List<string> B, List<int> C)
        {
            List<int> result = new List<int>();
            SortedDictionary<int, string> serverMap = new SortedDictionary<int, string>();
            Dictionary<string, int> serverKeyMap = new Dictionary<string, int>();
            Dictionary<int, string> keyMap = new Dictionary<int, string>();

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] == "ADD")
                {
                    int hash = userHash(B[i], C[i]);
                    serverMap[hash] = B[i];
                    serverKeyMap[B[i]] = hash;
                    result.Add(0);
                }
                else if (A[i] == "REMOVE")
                {
                    int serverHash = serverKeyMap[B[i]];
                    serverMap.Remove(serverHash);
                    serverKeyMap.Remove(B[i]);

                    int reassignedKeys = 0;
                    List<int> keysToReassign = new List<int>();

                    foreach (var key in keyMap)
                    {
                        if (key.Value == B[i])
                        {
                            keysToReassign.Add(key.Key);
                            reassignedKeys++;
                        }
                    }

                    foreach (var key in keysToReassign)
                    {
                        keyMap.Remove(key);
                    }

                    result.Add(reassignedKeys);
                }
                else if (A[i] == "ASSIGN")
                {
                    int hash = userHash(B[i], C[i]);
                    int assignedServerHash = -1;

                    foreach (var server in serverMap)
                    {
                        if (server.Key >= hash)
                        {
                            assignedServerHash = server.Key;
                            break;
                        }
                    }

                    if (assignedServerHash == -1)
                    {
                        assignedServerHash = serverMap.First().Key;
                    }

                    keyMap[hash] = serverMap[assignedServerHash];
                    result.Add(assignedServerHash);
                }
            }

            return result;
        }

        public int userHash(string username, int hashKey)
        {
            int p = hashKey;
            const int n = 360;
            int hashCode = 0;
            long p_pow = 1;
            for (int i = 0; i < username.Length; i++)
            {
                char character = username[i];
                hashCode = (hashCode + (character - 'A' + 1) * (int)p_pow) % n;
                p_pow = (p_pow * p) % n;
            }
            return hashCode;
        }
    }
}
