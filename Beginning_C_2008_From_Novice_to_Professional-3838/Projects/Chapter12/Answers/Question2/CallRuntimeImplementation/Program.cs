using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Definitions;

namespace CallRuntimeImplementation {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Starting");
            TestConfigurationLoader.RunAll();
            Console.ReadKey();
        }
    }
}
