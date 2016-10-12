using System.Collections.Generic;
using System;

namespace InitialProblem {
    abstract class IteratorBaseClass {
        IList<int> _collection;

        protected IteratorBaseClass(IList<int> collection) {
            _collection = collection;
        }
        protected abstract void ProcessElement(int value);
        public IteratorBaseClass Iterate() {
            foreach (int element in _collection) {
                ProcessElement(element);
            }
            return this;
        }
    }

    class RunningTotal : IteratorBaseClass {
        public int Total;
        public RunningTotal(IList<int> collection)
            :
            base(collection) {
            Total = 0;
        }
        protected override void ProcessElement(int value) {
            Total += value;
        }
    }

    class MaximumValue : IteratorBaseClass {
        public int MaxValue;
        public MaximumValue(IList<int> collection)
            :
            base(collection) {
            MaxValue = int.MinValue;
        }
        protected override void ProcessElement(int value) {
            if (value > MaxValue) {
                MaxValue = value;
            }
        }
    }

    static class Tests {
        static void ExampleRunningTotal() {
            IList<int> elements = new List<int>();
            elements.Add(1);
            elements.Add(2);
            elements.Add(3);
            int runningTotal = 0;
            foreach (int value in elements) {
                runningTotal += value;
            }
            Console.WriteLine("RunningTotal (" + runningTotal + ")");
        }
        static void ExampleMaximumValue() {
            IList<int> elements = new List<int>();
            elements.Add(1);
            elements.Add(2);
            elements.Add(3);
            int maxValue = int.MinValue;
            foreach (int value in elements) {
                if (value > maxValue) {
                    maxValue = value;
                }
            }
            Console.WriteLine("Maximum value is (" + maxValue + ")");
        }
        static void ExampleRunningTotalAndMaximumValue() {
            IList<int> elements = new List<int>();
            elements.Add(1);
            elements.Add(2);
            elements.Add(3);
            int runningTotal = 0;
            foreach (int value in elements) {
                runningTotal += value;
            }
            Console.WriteLine("RunningTotal (" + runningTotal + ")");
            int maxValue = int.MinValue;
            foreach (int value in elements) {
                if (value > maxValue) {
                    maxValue = value;
                }
            }
            Console.WriteLine("Maximum value is (" + maxValue + ")");
        }
        static void ExampleWithClasses() {
            IList<int> elements = new List<int>();
            elements.Add(1);
            elements.Add(2);
            elements.Add(3);

            Console.WriteLine("RunningTotal (" +
                ((new RunningTotal(elements).Iterate()) as RunningTotal).Total +
                ") Maximum Value (" +
                ((new MaximumValue(elements).Iterate()) as MaximumValue).MaxValue +
                ")");
        }
        public static void RunAll() {
            ExampleRunningTotal();
            ExampleMaximumValue();
            ExampleRunningTotalAndMaximumValue();
            ExampleWithClasses();
        }

    }
    /*class AddRunningTotal {
        public int AddRunningTotal(IList items) {
            foreach (int item in list) {
            }
        }
    }


    static class Tests {
        public static void RunAll() {
        }
    }*/
}