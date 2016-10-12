using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAboutExceptionHandling {
    class Program {
        static void Main(string[] args) {
            //new TheErrorThatIsUnexpected.Tests().RunAll();
            //new ExceptionsThatCorruptState.Tests().RunAll();
            new StackUnwinding.Tests().RunAll();
            Console.ReadKey();
        }
    }
}
