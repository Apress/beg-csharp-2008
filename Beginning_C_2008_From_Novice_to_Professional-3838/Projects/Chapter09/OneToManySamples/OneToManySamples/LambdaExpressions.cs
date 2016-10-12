using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpressions {
    public static class Another {
        public static void Lambda(Func<int, int, bool> lambda) {
        }
}
public static class Extensions {
    public static void Iterate(this ICollection<int> collection, Func< int, bool> lambda) {
        foreach (int element in collection) {
            lambda(element);
        }
    }
}

static class Tests {
    static void DoRunningTotalAndMaxium() {
        List<int> lst = new List<int> { 1, 2, 3, 4 };
        int runningTotal = 0;
        lst.Iterate(
            (value) => {
                runningTotal += value;
                return true;
            });
        Console.WriteLine("Running total is (" + runningTotal + ")");

        int maxValue = int.MinValue;
        lst.Iterate(
            (value) => {
                if (value > maxValue) {
                    maxValue = value;
                }
                return true;
            });
        Console.WriteLine("Maximum value is (" + maxValue + ")");
    }
    public static void RunAll() {
        DoRunningTotalAndMaxium();
    }
}

}
