using System;
using System.Collections.Generic;

namespace AfterCSharp2dot0 {
    class Example {
        int _value;

        public int Value {
            get {
                return _value;
            }
            set {
                _value = value;
            }
        }
    }

    static class Tests {
        static void IListExample() {
            IList<Example> lst = new List<Example>();
            lst.Add(new Example { Value = 10 });
            lst.Add(new Example { Value = 20 });
            foreach (Example item in lst) {
                Console.WriteLine("item (" + item.Value + ")");
            }
        }

        public static void RunAll() {
            IListExample();
        }
    }
}