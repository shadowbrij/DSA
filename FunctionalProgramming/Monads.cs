using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    internal class Monads
    {
        static Nullable<T> ApplyFunction<T>(
            Nullable<T> nullable,
            Func<T, T> function)
        {
            if (nullable.HasValue)
            {
                T unwrapped = nullable.Value;
                T result = function(unwrapped);
                return new Nullable<T>(result);
            }
            else
                return new Nullable<T>();
        }
        static Nullable<R> ApplyFunction<A, R>(
          Nullable<A> nullable,
          Func<A, R> function)
        {
            if (nullable.HasValue)
            {
                A unwrapped = nullable.Value;
                R result = function(unwrapped);
                return new Nullable<R>(result);
            }
            else
                return new Nullable<R>();
        }
        public static Func<T, V> Compose<T, U, V>(this Func<U, V> f, Func<T, U> g)
        {
            return x => f(g(x));
        }

        //static M<T> CreateSimpleM<T>(T value);
        //static M<R> ApplyFunction<A, R>(
        //  M<A> wrapped,
        //  Func<A, R> function)
        //static M<R> ApplySpecialFunction<A, R>(
        //  M<A> wrapped,
        //  Func<A, M<R>> function)


        //static M<R> ApplyFunction<A, R>(
        //  M<A> wrapped,
        //  Func<A, R> function)
        //{
        //    return ApplySpecialFunction<A, R>(
        //      wrapped,
        //      (A unwrapped) => CreateSimpleM<R>(function(unwrapped)));
        //}
        static IEnumerable<R> ApplySpecialFunction<A, R>(
          IEnumerable<A> sequence,
          Func<A, IEnumerable<R>> function)
        {
            foreach (A unwrapped in sequence)
            {
                IEnumerable<R> result = function(unwrapped);
                foreach (R r in result)
                    yield return r;
            }
        }

        static Nullable<int> AddOne(Nullable<int> nullable)
        {
            return ApplyFunction(nullable, (int x) => x + 1);
        }

        static Nullable<int> ApplyFunction(
              Nullable<int> nullable,
              Func<int, int> function)
        {
            if (nullable.HasValue)
            {
                int unwrapped = nullable.Value;
                int result = function(unwrapped);
                return new Nullable<int>(result);
            }
            else
                return new Nullable<int>();
        }
    }
}
