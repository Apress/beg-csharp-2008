using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace TestLightingSystem {
    class Program {
        static void Main(string[] args) {
            TestLightingSystem.TestsLinkedList.RunAll();
            TestLightingSystem.TestsLightingController.RunAll();
            TestLightingSystem.TestsRoomImplementations.RunAll();
            Console.ReadKey();
        }
    }
}
