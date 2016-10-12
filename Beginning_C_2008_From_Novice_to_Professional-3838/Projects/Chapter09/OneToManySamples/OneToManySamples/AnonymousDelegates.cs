using System;
using System.Collections.Generic;

namespace AnonymousDelegates {

    public delegate void ProcessValue(int value);

    public static class Extensions {
        public static void Iterate(this ICollection<int> collection, ProcessValue cb) {
            foreach (int element in collection) {
                cb(element);
            }
        }
    }

    static class Tests {
        static void DoRunningTotalAndMaxium() {
            List<int> lst = new List<int> { 1, 2, 3, 4 };
            int runningTotal = 0;
            int maxValue = int.MinValue;

            ProcessValue anonymous = new ProcessValue(
                delegate(int value) {
                    runningTotal += value;
                });
            anonymous += new ProcessValue(
                    delegate(int value) {
                        if (value > maxValue) {
                            maxValue = value;
                        }
                    });

            lst.Iterate(anonymous);
            Console.WriteLine("Running total is (" + runningTotal + ")");
            Console.WriteLine("Maximum value is (" + maxValue + ")");
        }
        public static void RunAll() {
            DoRunningTotalAndMaxium();
        }
    }

}