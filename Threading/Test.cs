using System;
using System.Threading.Tasks;

namespace Threading
{
    static class Test
    {
        public static async Task mainfunc()
        {
            var t1 = Task.Factory.StartNew(() => call1());
            var t2 = Task.Factory.StartNew(() => call2());

            await Task.WhenAll(t1, t2).ContinueWith((result) =>
            {
                Console.WriteLine(result.Result[0] + result.Result[1]);
            });

        }
        public static int call1()
        {
            return 5;
        }
        public static int call2()
        {
            System.Threading.Thread.Sleep(5000);
            return 3;
        }

        public static void printBeforeCompute()
        {
            Console.WriteLine("I am here");
        }
    }
}
