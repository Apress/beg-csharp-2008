using System;
using System.Collections.Generic;
using System.Text;
using LibCurrencyTrader;

namespace nsTestCurrencyTrader {
    static class TestCurrencyTraders {
        static void TestActiveCurrencyTrader() {
            CurrencyTrader cls = new ActiveCurrencyTrader(new CurrencyPair("USD", "EUR", new Decimal(1.36)));
            Decimal haveUSD = 100.0M;
            Decimal getEUR = cls.ConvertFrom(haveUSD);
            Console.WriteLine("Converted " + haveUSD + " USD to " + getEUR);
            haveUSD = cls.ConvertTo(getEUR);
            Console.WriteLine("Converted " + haveUSD + " USD to " + getEUR);
        }
        static void TestHotelCurrencyTrader() {
            CurrencyTrader cls = new HotelCurrencyTrader(new CurrencyPair("USD", "EUR", new Decimal(1.36)), new Decimal( 0.05));
            Decimal haveUSD = 100.0M;
            Decimal getEUR = cls.ConvertFrom(haveUSD);
            Console.WriteLine("Converted " + haveUSD + " USD to " + getEUR);
            haveUSD = cls.ConvertTo(getEUR);
            Console.WriteLine("Converted " + haveUSD + " USD to " + getEUR);
        }
        public static void RunAll() {
            TestActiveCurrencyTrader();
            TestHotelCurrencyTrader();
        }
    }
}
