using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            int? ss = null;


            try
            {
                if(ss == 2)
                {
                    Console.WriteLine("ss");
                }
                var cts = new CancellationTokenSource();
                var token = cts.Token;
                Task t_error = Task.Factory.StartNew(() =>
                {
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    int i = 0;
                    int j = 100 / i;
                }
                , token//to .Net
                );
            }
            catch (Exception ex)
            {
                //Put in a constructor for unfinished task so that they don't throw ar GC
                TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            }
            //var x = Test.mainfunc();
            //Test.printBeforeCompute();
            Console.ReadLine();
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
        }
    }
}
