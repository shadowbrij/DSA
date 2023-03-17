using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Anagram
    {
        static void MMain(String[] args)
        {
            //Task : Print a single integer denoting the number of characters you must delete to make the two strings anagrams of each other.
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            int num = NumberNeededToDelete(str1, str2);
            Console.WriteLine(num);
            Console.ReadLine();
        }

        private static int NumberNeededToDelete(string str1, string str2)
        {
            int count =0;
            int[] charCount1 = CreateCharCountArray(str1);
            int[] charCount2 = CreateCharCountArray(str2);

            count = DifferenceCalc(charCount1, charCount2);

            return count;
        }

        private static int DifferenceCalc(int[] charCount1, int[] charCount2)
        {
            int count = 0;
            if (charCount2.Length == charCount1.Length)
            {
                for (int i = 0; i < charCount1.Length; i++)
                {
                    count += Math.Abs(charCount1[i] - charCount2[i]);
                }
            }
            return count;
        }

        private static int[] CreateCharCountArray(string str1)
        {
            int[] CharArr = new int[26];

            for(int i = 0;i<str1.Length;i++)
            {
                int offset = (int)'a';
                int dist = str1.ElementAt(i) - offset;
                CharArr[dist]++;
            }
            return CharArr;
        }
    }
}
