using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            List<int> lst = new List<int>();
            for (int c1 = 1; c1 < 21; c1++) {
                lst.Add(c1);
            }

            lst.Remove(15);
            lst.Remove(10);
            // You would be tempted to use Range or another method 
            // like that. Though range removes values based on an index
            // and while that would work it would be buggy and subject
            // to the initial condition of the list
            for (int c1 = 3; c1 < 8; c1++) {
                lst.Remove(c1);
            }
            foreach (int count in lst) {
                Console.WriteLine("(" + count + ")");
            }
            Console.ReadKey();
        }
    }
}
