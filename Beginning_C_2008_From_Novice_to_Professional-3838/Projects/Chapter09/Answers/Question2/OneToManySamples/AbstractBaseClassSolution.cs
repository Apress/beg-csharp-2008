using System;
using System.Collections.Generic;

namespace AbstractBaseClassSolution {
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
        public static void RunAll() {
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
    }

}