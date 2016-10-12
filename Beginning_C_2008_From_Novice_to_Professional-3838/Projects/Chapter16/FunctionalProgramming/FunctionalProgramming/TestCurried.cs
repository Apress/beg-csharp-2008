using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming {
    interface ICalculate {
        double SalesTax { get; }
        double Calculate(double total);
    }

    class LocalSalesTax : ICalculate {
        double _salesTax;

        public LocalSalesTax(double amount) {
            _salesTax = amount;
        }
        public double SalesTax {
            get { return _salesTax; }
        }

        public double Calculate(double total) {
            return total + total * SalesTax;
        }
    }

    class TestCurried {
        static void ExampleCurriedBuffer() {
            Func<string, Func<string, string>> curry = surrounding => core => surrounding + " " + core + " " + surrounding;
            Func<string, string> curriedFunction = curry("+++");
            Func<string, string> curriedFunction2 = curry("---");

            Console.WriteLine("Calling currying like calling function (" + curry("+++")("core") + ")");
            Console.WriteLine("Calling basic function that has been curried (" + curriedFunction("core") + ")");
            Console.WriteLine("Calling basic function 2 that has been curried (" + curriedFunction2("core") + ")");
        }
        static void TraditionalSalesTax() {
            ICalculate localplace = new LocalSalesTax(0.165);
            double amount = 100.0;
            Console.WriteLine("I bought (" + amount + ") and with tax that is (" + localplace.Calculate(amount) + ")");
        }
        static void ExampleSalesTaxCalculator() {
            Func<double, Func<double, double>> salesTax = localSalesTax => totalBought => totalBought + totalBought * localSalesTax;

            Func<double, double> localplace = salesTax(0.165);
            double amount = 100.0;

            Console.WriteLine("I bought (" + amount + ") and with tax that is (" + localplace(amount) + ")");
        }
        public static void RunAll() {
            //ExampleCurriedPlus();
            //ExampleCurriedBuffer();
            ExampleSalesTaxCalculator();
        }
    }
}
