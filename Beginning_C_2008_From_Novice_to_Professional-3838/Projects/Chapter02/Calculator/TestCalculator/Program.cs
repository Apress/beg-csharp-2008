using System;
using System.Collections.Generic;
using System.Text;

namespace TestCalculator {
    class Program {
        public static void TestSimpleAddition() {
            int total = Calculator.Operations.Add(1, 2);
            if (total != 3) {
                Console.WriteLine("Ooops 1 and 2 does not equal 3");
            }
        }
        public static void TestReallyBigNumbers() {
            int total = Calculator.Operations.Add(2000000000, 2000000000);
            if (total != 4000000000) {
                Console.WriteLine("Error found(" + total + ") should have been (4000000000)");
            }
        }
        public static void AddFractionalNumbersToWhole() {
            int total = (int)1.5 + (int)1.5;
            if (total != 2) {
                Console.WriteLine("oops something went wrong");
            }
        }
        public static void AddFractionalNumbers() {
            float value = (float)10000.0 + (float)0.000001;
            Console.WriteLine(String.Format("Value ({0})", value));
        }
        static void Main(string[] args) {
            TestSimpleAddition();
            //TestReallyBigNumbers();
            //AddFractionalNumbersToWhole();
            AddFractionalNumbers();
            Console.ReadKey();
        }
    }
}
