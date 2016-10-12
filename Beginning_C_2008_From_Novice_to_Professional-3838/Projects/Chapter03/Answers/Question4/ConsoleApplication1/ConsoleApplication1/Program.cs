using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    class Program {
        static void AddStringAndNumber() {
            string buffer = "hello";
            int number = 10;

            string stringResult = buffer + number;
            if (stringResult.CompareTo("hello10") != 0) {
                Console.WriteLine("error...");
            }
            // These two tests are added to illustrate that you cannot add
            // a number to a string and get a number, but you can add a string
            // to a number and get a string.
            //int numberResult = buffer + number;
            //int numberResult2 = number + buffer;
        }
        static void Main(string[] args) {
            AddStringAndNumber();
        }
    }
}
