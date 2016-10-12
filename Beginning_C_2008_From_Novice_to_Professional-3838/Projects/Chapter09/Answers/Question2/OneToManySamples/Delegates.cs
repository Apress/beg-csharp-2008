using System;
using System.Collections.Generic;

namespace Delegates {

    public delegate void ProcessValue(int value);

    public static class Extensions {
        public static void Iterate(this ICollection<int> collection, ProcessValue cb) {
            foreach (int element in collection) {
                cb(element);
            }
        }
    }

    class DelegateImplementations {
        void InstanceProcess(int value) { }
        static void StaticProcess(int value) { }

        public static ProcessValue StaticInstantiate() {
            return new ProcessValue(StaticProcess);
        }
        public ProcessValue InstanceInstantiate() {
            return new ProcessValue(InstanceProcess);
        }
    }
    // The problem with this class is that you are using static data members
    // meaning that only ever a single thread can manipulate the data members
    // This class is a problem in a multi-threaded application
    static class Tests {
        private class DelegateRunningTotal {
            public int RunningTotal;
            public void ProcessRunningTotal(int value) {
                RunningTotal += value;
            }
        }
        private class DelegateProcessMaximumValue {
            public int MaxValue;
            public DelegateProcessMaximumValue() {
                MaxValue = int.MinValue;
            }
            public void ProcessMaximumValue(int value) {
                if (value > _maxValue) {
                    _maxValue = value;
                }
            }
        }
        static int _runningTotal;

        static void ProcessRunningTotal(int value) {
            _runningTotal += value;
        }

        static int _maxValue;
        static void ProcessMaximumValue(int value) {
            if (value > _maxValue) {
                _maxValue = value;
            }
        }
        static void SafeDoRunningTotalAndMaxium() {
            List<int> lst = new List<int> { 1, 2, 3, 4 };
            DelegateRunningTotal runningTotal = new DelegateRunningTotal();
            lst.Iterate(new ProcessValue(runningTotal.ProcessRunningTotal));
            Console.WriteLine("Running total is (" + runningTotal.RunningTotal + ")");

            DelegateProcessMaximumValue maxValue = new DelegateProcessMaximumValue();
            lst.Iterate(new ProcessValue(maxValue.ProcessMaximumValue));
            Console.WriteLine("Maximum value is (" + maxValue.MaxValue + ")");
        }
        static void DoRunningTotalAndMaxium() {
            List<int> lst = new List<int> { 1, 2, 3, 4 };
            _runningTotal = 0;
            lst.Iterate(new ProcessValue(ProcessRunningTotal));
            Console.WriteLine("Running total is (" + _runningTotal + ")");

            _maxValue = int.MinValue;
            lst.Iterate(new ProcessValue(ProcessMaximumValue));
            Console.WriteLine("Maximum value is (" + _maxValue + ")");
        }
        public static void RunAll() {
            DoRunningTotalAndMaxium();
        }
    }
}