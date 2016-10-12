using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    class MyType {
        public string Value;
    }

    // Notice how this sort is case insenstive
    class MyTypeSorter : IComparer<MyType> {
        #region IComparer<MyType> Members

        public int Compare(MyType x, MyType y) {
            return x.Value.CompareTo(y.Value);
        }
        #endregion
    }


    class Program {
        static void Main(string[] args) {
            List<MyType> lst = new List<MyType> {
                new MyType { Value = "hello"},
                new MyType { Value = "another"},
                new MyType { Value = "dude" },
                new MyType { Value = "gal"},
                new MyType { Value = "pond" },
                new MyType { Value = "happy" },
                new MyType { Value = "mixture" },
                new MyType { Value = "cats" },
                new MyType { Value = "hippo" },
                new MyType { Value = "Country"}
            };
            foreach (MyType item in lst) {
                Console.WriteLine("(" + item.Value + ")");
            }
            Console.WriteLine("********************");
            lst.Sort(new MyTypeSorter());
            foreach (MyType item in lst) {
                Console.WriteLine("(" + item.Value + ")");
            }
            Console.ReadKey();
        }
    }
}
