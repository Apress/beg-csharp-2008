using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JugglingTasks {
    class ExampleImplementation : StatefulThread {
        int _totalCount;

        public ExampleImplementation(int totalCount) {
            _totalCount = totalCount;
        }
        protected override bool Process() {
            Console.WriteLine("Counter (" + _totalCount + ")");
            Thread.Sleep( 1000);
            _totalCount--;
            if (_totalCount == 0) {
                return false;
            }
            else {
                return true;
            }
        }
    }
    static class TestStateFullThread {
        public static void RunAll() {
            new ExampleImplementation(10).RunThreaded();
        }
    }
}
