﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingAssignments.ArraysProblems
{
    class DynamicArrays
    {
        static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            List<int> rtvalue = new List<int>();
            List<List<int>> Es = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                Es.Add(new List<int>());
            }
            int lastAnswer = 0;
            foreach (List<int> list in queries)
            {
                if (list[0] == 1)
                {
                    Es[(list[1] ^ lastAnswer) % n].Add(list[2]);
                }
                else if (list[0] == 2)
                {
                    lastAnswer = Es[(list[1] ^ lastAnswer) % n][list[2] % n];
                    rtvalue.Add(lastAnswer);
                }
            }
            return rtvalue;
        }

        //        2 5
        //1 0 5
        //1 1 7
        //1 0 3
        //2 1 0
        //2 1 1
        static void mmm(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string? input = Console.ReadLine()?.TrimEnd();
            if (input == null)
                throw new InvalidOperationException("Input cannot be null.");
                
            string[] nq = input.Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                string? queryInput = Console.ReadLine()?.TrimEnd();
                if (queryInput == null) break;
                
                queries.Add(queryInput.Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = dynamicArray(n, queries);

            //textWriter.WriteLine(String.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
