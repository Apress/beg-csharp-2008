using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            StringBuilder builder = new StringBuilder();
            builder.Append( "hello");
            builder.Append( "world");
            string c = builder.ToString();
            Console.WriteLine(c);
        }
    }
}
