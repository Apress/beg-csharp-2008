using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JugglingTasks {
    class GenerateSquares : StatefulThread {
        int _start;
        int _end;
        int _counter;

        public GenerateSquares(int start, int end) {
            _start = start;
            _end = end;
            _counter = start;
        }
        protected override bool Process() {
            Console.WriteLine("Number (" + _counter + ") Square (" + Math.Pow( _counter, 2) + ")");
            _counter++;
            if (_counter > _end) {
                return false;
            }
            else {
                return true;
            }
        }
    }

    class GenerateFibonacci : StatefulThread {
        int _end;
        int _lastTotal;
        int _prevLastTotal;

        public GenerateFibonacci(int end) {
            _end = end;
            _prevLastTotal = 1;
            _lastTotal = 1;
            Console.WriteLine("(0)");
            Console.WriteLine("(1)");
            Console.WriteLine("(1)");
        }
        protected override bool Process() {
            int temp = _lastTotal + _prevLastTotal;
            _prevLastTotal = _lastTotal;
            _lastTotal = temp;
            Console.WriteLine("(" + _lastTotal + ")");
            if (_lastTotal > _end) {
                return false;
            }
            else {
                return true;
            }
        }
    }

    static class TestGenerateSeries {
        static void TestGenerateSquares() {
            // You can run multiple square threads beside each other because none
            // are dependent on each other. The only requirement is that you
            // don't generate the squares for identical numbers
            new GenerateSquares(1, 50).RunThreaded();
            new GenerateSquares(51, 100).RunThreaded();
        }
        static void TestGenerateFibonacci() {
            // You can't multi-thread a fibonacci series because each
            // number recursively depends on a previous number
            new GenerateFibonacci( 30).RunThreaded();
        }
        public static void RunAll() {
            TestGenerateSquares();
            TestGenerateFibonacci();
        }
    }
}
