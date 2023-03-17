using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumerateItems
{
    class AllDaysOFWeek : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            Console.WriteLine("Calling ");
            yield return "Monday";
            yield return "Sunday";

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public static void DisplayItems<T>(IEnumerable<T> collection)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                bool moreItems = enumerator.MoveNext();
                while (moreItems)
                {
                    T item = enumerator.Current;
                    Console.WriteLine(item);
                    moreItems = enumerator.MoveNext();
                }

            }
        }
    }


}
