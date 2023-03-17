using System;

namespace OOPS
{
    abstract class A
    {
        static A()
        {
            System.Console.WriteLine("Inside abstract");
        }
        public abstract void display();

    }
    class AA : A
    {
        public override void display()
        {

        }
    }
    interface X
    {
        void display();
        int addin { get; set; }
        event EventHandler del;

    }
    //interface Y
    //{
    //    void display();
    //}
    //class B : X, Y
    //{
    //    public B()
    //    {
    //    }

    //    public void display()
    //    {
    //        throw new NotImplementedException();
    //    }

    //}
    public class Person
    {
        public string name;
        public int id;
        public Person()
        {
            name = "xyz";
            id = 6;
        }
    }

    //class AMCheck
    //{
    //    public virtual void display()
    //    {

    //    }
    //    protected virtual void print()
    //    {

    //    }
    //}
    //class AMChild : AMCheck
    //{
    //    public override void display()
    //    {

    //    }
    //    protected void xcv()
    //    {

    //    }
    //}
    //class SecondChile : AMChild
    //{
    //    public override void display()
    //    {

    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            //AMCheck am = new SecondChile();
            //am.display();

            // Person p = new Person();
            //int[] A = new int[] { 6, 1, 4, 6, 3, 2, 7, 4 };
            //FindMin(A, 3, 2);
            try
            {
                TryCatchTest();

            }
            catch (Exception e)
            {

            }
            //x a = new B();
            //a.display();
            //y b = new B();
            //b.display();
            //string abc = "sing";
            //string vb = abc;
            //vb = "brijesh";

            //Console.WriteLine(abc);
            Console.ReadLine();
        }

        private static int TryCatchTest()
        {
            try
            {
                int a = 5, b = 0;
                var c = a / b;
                return 3;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }

        public static int FindMin(int[] A, int K, int L)
        {
            if (K + L > A.Length)
                return -1;
            int mx = (K > L) ? K : L;
            int lx = (K < L) ? K : L;
            int maxsum = 0;
            int maxstindex = 0;
            for (int j = 0; j < A.Length - mx; j++)
            {
                int tempsum = 0;
                for (int i = j; i < j + mx; i++)
                {
                    tempsum += A[i];
                }
                if (tempsum > maxsum)
                {
                    maxsum = tempsum;
                    maxstindex = j;
                }
            }

            int lxSum = 0;
            for (int j = 0; j < A.Length - lx + 1; j++)
            {
                if (j <= maxstindex - lx || j >= mx + maxstindex)
                {
                    int tempsum = 0;
                    for (int i = j; i < j + lx; i++)
                    {
                        tempsum += A[i];
                    }
                    if (tempsum > lxSum)
                    {
                        lxSum = tempsum;
                    }
                }
                else lxSum = 0;
            }
            return maxsum + lxSum;
        }
    }


    public static class PersonExtension
    {
        public static string ToString(this Person p)
        {
            return p.name + " " + p.id.ToString();
        }
    }

}
