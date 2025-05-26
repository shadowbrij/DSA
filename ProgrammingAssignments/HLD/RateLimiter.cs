using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.HLD
{
    class RateLimiter
    {
        /*
        Design a rate limiter system. A rate limiter limits the number of client requests allowed to be sent over a specified period.
        You are given N client requests where A[i] gives the client ID and B[i] gives the timestamp t for the i-th request. The rate limiter allows 3 requests from a client in every 10 sec interval.
        In other words, there can be at most 3 successful requests from each client in any time interval [t, t+10).
        All requests will come in chronological order. Several requests may arrive at the same timestamp.
        The answer to the i-th request should be 1 if the request is successful and 0 if the request fails.

        Example Input:
        A = [1, 1, 2, 1, 1, 1]
        B = [1, 2, 2, 9, 10, 11]
        Output:
        [1, 1, 1, 1, 0, 1]
        */
        public List<int> solve(List<int> A, List<int> B)
        {
            List<int> result = new List<int>();

            // Dictionary to store the timestamps of requests for each client
            Dictionary<int, Queue<int>> clientRequests = new Dictionary<int, Queue<int>>();
            
            // Dictionary to store the count of requests for each client
            Dictionary<int, int> clientRequestCount = new Dictionary<int, int>();

            for (int i = 0; i < A.Count; i++)
            {
                int client = A[i];
                int timestamp = B[i];

                // Initialize the client's request queue and count if not already present
                if (!clientRequests.ContainsKey(client))
                {
                    clientRequests[client] = new Queue<int>();
                    clientRequestCount[client] = 0;
                }

                // Remove requests that are outside the 10-second window
                while (clientRequests[client].Count > 0 && clientRequests[client].Peek() + 10 <= timestamp)
                {
                    clientRequests[client].Dequeue();
                    clientRequestCount[client]--;
                }

                // Check if the client can make a new request
                if (clientRequestCount[client] < 3)
                {
                    // Add the new request timestamp to the queue and increment the count
                    clientRequests[client].Enqueue(timestamp);
                    clientRequestCount[client]++;
                    result.Add(1); // Request is successful
                }
                else
                {
                    result.Add(0); // Request is denied
                }
            }
            return result;
        }
    }
}
