using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseConsoleEx {
    class Program {

        static void Main(string[] args) {
            //Console.Write(DatabaseConsoleEx.Properties.Settings.Default.lotteryConnectionString);
            GeneratedCode.Tests.RunAll();
            ADONet.Tests.RunAll();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
