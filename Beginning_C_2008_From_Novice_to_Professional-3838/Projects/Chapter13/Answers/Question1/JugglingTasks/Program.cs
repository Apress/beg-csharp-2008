using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JugglingTasks {
    class Program {
        static void Main(string[] args) {
            //Threads.TestThreads.RunAll();
            //MoreTopics.TestMoreTopics.RunAll();
            //AsynchronousFile.TestAsynchronousFile.RunAll();
            //Synchronization.TestSynchronization.RunAll();
            TestStateFullThread.RunAll();
            Console.WriteLine("Waiting for key to exit...");
            Console.ReadKey();
        }
    }
}
