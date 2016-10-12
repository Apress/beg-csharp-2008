using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LibTax;
using LibTax.Canada;

namespace TestTax {
    static class Tests {
        static void RunCreateEngine() {
            ITaxEngine engine = EngineCreator.CreateCanadianTaxEngine();
            ICanadaTaxEngine canadaEngine = engine as ICanadaTaxEngine;
            if (engine == null || canadaEngine == null) {
                throw new Exception("could not instantiate engine");
            }
        }
        static void RunCreateAccount() {
            ITaxEngine engine = EngineCreator.CreateCanadianTaxEngine();
            ICanadaTaxEngine canadaEngine = engine as ICanadaTaxEngine;
            ITaxAccount account = canadaEngine.CreateTaxAccount(Province.Ontario, 2007);
            if (account == null) {
                throw new Exception("could not instantiate canada account");
            }
        }
        static void RunCreateAndAddIncome() {
            ITaxEngine engine = EngineCreator.CreateCanadianTaxEngine();
            ICanadaTaxEngine canadaEngine = engine as ICanadaTaxEngine;
            ITaxAccount account = canadaEngine.CreateTaxAccount(Province.Ontario, 2007);

            ITaxIncome income = engine.CreateIncome(100);
            account.AddIncome(income);
            ITaxIncome[] incomeItems = account.Income;
            if (incomeItems[0] == null) {
                throw new Exception("Did not add income item");
            }
        }
        static void RunCreateAndAddDeduction() {
            ITaxEngine engine = EngineCreator.CreateCanadianTaxEngine();
            ICanadaTaxEngine canadaEngine = engine as ICanadaTaxEngine;
            ITaxAccount account = canadaEngine.CreateTaxAccount(Province.Ontario, 2007);

            ITaxDeduction deduction = engine.CreateDeduction(20);
            account.AddDeduction(deduction);
            ITaxDeduction[] deductionItems = account.Deductions;
            if (deductionItems[0] == null) {
                throw new Exception("Did not add deduction item");
            }
        }
        static void RunCanada() {
            ITaxEngine engine = EngineCreator.CreateCanadianTaxEngine();
            ICanadaTaxEngine canadaEngine = engine as ICanadaTaxEngine;
            ITaxAccount account = canadaEngine.CreateTaxAccount(Province.Ontario, 2007);

            ITaxIncome income = engine.CreateIncome(100);
            ITaxIncome capitalGain = canadaEngine.CreateCapitalGain(100);
            account.AddIncome(income);
            account.AddIncome(capitalGain);

            ITaxDeduction deduction = engine.CreateDeduction(20);
            account.AddDeduction(deduction);
            double taxToPay = engine.CalculateTaxToPay(account);
            Console.WriteLine("Tax to pay (" + taxToPay + ")");
        }
        public static void RunAll() {
            RunCreateEngine();
            RunCreateAccount();
            RunCreateAndAddIncome();
            RunCreateAndAddDeduction();
            RunCanada();
        }
    }

    class Program {
        static void Main(string[] args) {
            //Inheritance.TestShape.RunAll();
            Tests.RunAll();
            Console.ReadKey();
        }
    }
}

