using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming {
    //delegate void Counter(Counter counter, int value);

    //delegate DataType Recursive<DataType>(DataType input);


    //class TestRecursion {
    //    delegate T SelfApplicable<T>(SelfApplicable<T> self);

    //    static void Mains(string[] args) {
    //        // The Y combinator
    //        SelfApplicable<
    //          Func<Func<Func<int, int>, Func<int, int>>, Func<int, int>>
    //        > Y = y => f => x => f(y(y)(f))(x);

    //        // The fixed point generator
    //        Func<Func<Func<int, int>, Func<int, int>>, Func<int, int>> Fix =
    //          Y(Y);

    //        // The higher order function describing factorial
    //        Func<Func<int, int>, Func<int, int>> F =
    //          fac => x => x == 0 ? 1 : x * fac(x - 1);

    //        // The factorial function itself
    //        Func<int, int> factorial = Fix(F);

    //        for (int i = 0; i < 12; i++) {
    //            Console.WriteLine(factorial(i));
    //        }
    //    }

    //    static void CountAgain2() {
    //        Func<string, Func<string, string>> curry = surrounding => core => surrounding + " " + core + " " + surrounding;

    //        Recursive<int> func = delegate(int value) {
    //            return 0;
    //        };
    //    }
    //    static void CountAgain() {
    //        Counter counter = delegate(Counter paramCounter, int iterations) {
    //            if (iterations > 0) {
    //                paramCounter(paramCounter, iterations - 1);
    //            }
    //            Console.WriteLine("Curr count( " + iterations + ")");
    //        };
    //        counter(counter, 10);
    //    }
    //    static void Count() {
    //        Counter RecursiveCount = (iterations) => {
    //            if (iterations > 0) {
    //                RecursiveCount(iterations - 1);
    //            }
    //            Console.WriteLine("Curr count( " + iterations + ")");
    //        };
    //        RecursiveCount(10);
    //    }
    //    public static void RunAll() {
    //        Count();
    //    }
    //}
}
