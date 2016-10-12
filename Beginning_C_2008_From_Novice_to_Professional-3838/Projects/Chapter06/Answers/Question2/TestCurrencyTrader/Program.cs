#define INTEGRATE_TESTS

using System;
using System.Collections.Generic;
using System.Text;
using LibCurrencyTrader;


partial class TestCurrencyTrader : CurrencyTrader {

    public TestCurrencyTrader(CurrencyPair currencyPair) : base(currencyPair) { }

    public override double ConvertTo(double value) {
        throw new NotImplementedException();
    }

    public override double ConvertFrom(double value) {
        throw new NotImplementedException();
    }
}

#if INTEGRATE_TESTS
partial class TestCurrencyTrader : CurrencyTrader {
    public void VerifyExchangeRate(double value) {
        if( Currency.ExchangeRate != value) {
            throw new Exception("ExchangeRate verification failed");
        }
    }
}
#endif

namespace nsTestCurrencyTrader {
    class Program {
        static void TestInitial() {
            CurrencyTrader cls = new ActiveCurrencyTrader(new CurrencyPair("USD", "EUR", 1.31));
            double haveUSD = 100.0;
            double getEUR = cls.ConvertFrom(haveUSD);
            Console.WriteLine("Converted " + haveUSD + " USD to " + getEUR);
        }
        static void TestSubclassedCurrencyTrader() {
            TestCurrencyTrader cls = new TestCurrencyTrader( new CurrencyPair( "", "", 100.0));
            cls.VerifyExchangeRate( 100.0);
        }
        static void Main(string[] args) {
        }
    }
}
