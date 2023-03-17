using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerateItems
{
        public class Server
        {
            string _name;
            string _function;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public string Function
            {
                get { return _function; }
                set { _function = value; }
            }
            public Server(string Name, string Function)
            {
                _name = Name;
                _function = Function;
            }
        }
        public class Yielder
        {
            public static IEnumerable<Server> ServerDB()
            {
                Server[] servers = new Server[]
                    {
                new Server("Parabellum","Domain Controller"),
                new Server("Pluck","DNS Server"),
                new Server("Pilgrim","Web Server"),
                new Server("Spark","Firewall Server"),
                    };
                foreach (Server s in servers)
                {
                    yield return s;
                    Console.WriteLine($"Sending {s.Name}");
                }
            }
            public static void Main()
            {

                foreach (int i in OddNumbers(100).Take(10))
                {
                    Console.WriteLine($"Number {i}");
                }
                //foreach (int i in EvenNumbers(1000000000))
                //{
                //    Console.WriteLine($"Number {i}");
                //}

                //foreach (Server s in ServerDB())
                //{
                //    Console.WriteLine($"Name: {s.Name}, Function: {s.Function}");
                //}

                Console.ReadKey();
            }
            public static IEnumerable<int> OddNumbers(int max)
            {
                int i = 1;
                while (i < (max * 2))
                {
                    yield return i;
                    i += 2;
                }
            }

            public static List<int> EvenNumbers(int max)
            {
                var retList = new List<int>();
                int i = 0;
                while (retList.Count < max)
                {
                    retList.Add(i += 2);
                }
                return retList;
            }
    }
}
