#define INTEGRATE_TESTS

using System;
using System.Collections.Generic;
using System.Text;
using LibCurrencyTrader;


partial class TestCurrencyTrader : CurrencyTrader {

    public TestCurrencyTrader(CurrencyPair currencyPair) : base(currencyPair) { }

    public override Decimal ConvertTo(Decimal value) {
        throw new NotImplementedException();
    }

    public override Decimal ConvertFrom(Decimal value) {
        throw new NotImplementedException();
    }
}

#if INTEGRATE_TESTS
partial class TestCurrencyTrader : CurrencyTrader {
    public void VerifyExchangeRate(Decimal value) {
        if( Currency.ExchangeRate != value) {
            throw new Exception("ExchangeRate verification failed");
        }
    }
}
#endif

namespace nsTestCurrencyTrader {
    class Program {
        static void TestInitial() {
            CurrencyTrader cls = new ActiveCurrencyTrader(new CurrencyPair("USD", "EUR", new Decimal( 1.31)));
            Decimal haveUSD = 100.0M;
            Decimal getEUR = cls.ConvertFrom(haveUSD);
            Console.WriteLine("Converted " + haveUSD + " USD to " + getEUR);
        }
        static void TestSubclassedCurrencyTrader() {
            TestCurrencyTrader cls = new TestCurrencyTrader( new CurrencyPair( "", "", new Decimal( 100.0)));
            cls.VerifyExchangeRate( new Decimal( 100.0));
        }
        static void Main(string[] args) {
        }
    }
}
