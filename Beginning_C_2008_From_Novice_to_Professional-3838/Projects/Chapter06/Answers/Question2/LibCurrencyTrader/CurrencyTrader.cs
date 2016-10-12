using System;
using System.Collections.Generic;
using System.Text;

namespace LibCurrencyTrader {
    public sealed class CurrencyPair {
        string _baseCurrency;
        string _destinationCurrency;
        double _exchangeRate;

        public CurrencyPair(string baseCurrency, string destinationCurrency, double exchangeRate) {
            _baseCurrency = baseCurrency;
            _destinationCurrency = destinationCurrency;
            _exchangeRate = exchangeRate;
        }
        public string BaseCurrency {
            get {
                return _baseCurrency;
            }
        }
        public string DestinationCurrency {
            get {
                return _destinationCurrency;
            }
        }
        public double ExchangeRate {
            get {
                return _exchangeRate;
            }
        }
    }

    public abstract class CurrencyTrader {
        CurrencyPair _currencyPair;

        public CurrencyTrader(CurrencyPair currencyPair) {
            _currencyPair = currencyPair;
        }
        public CurrencyPair Currency {
            get {
                return _currencyPair;
            }
        }
        public abstract double ConvertTo(double value);
        public abstract double ConvertFrom(double value);
    }

    public class ActiveCurrencyTrader : CurrencyTrader {
        public ActiveCurrencyTrader( CurrencyPair currencyPair) : base( currencyPair) {
        }
        public override double ConvertTo(double input) {
            if (input < 0.0) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            return Currency.ExchangeRate * input;
        }
        public override double ConvertFrom(double input) {
            if (input < 0.0) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            return input / Currency.ExchangeRate;
        }
    }
    public class HotelCurrencyTrader : CurrencyTrader {
        double _spread;

        public HotelCurrencyTrader( CurrencyPair currencyPair, double spread) : base( currencyPair) {
            if (_spread < 0.0) {
                throw new ArgumentOutOfRangeException("Spread is a negative value");
            }
            _spread = spread;
        }
        public override double ConvertTo(double input) {
            if (input < 0.0) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            double realExchange = Currency.ExchangeRate;
            realExchange -= _spread;
            return realExchange * input;
        }
        public override double ConvertFrom(double input) {
            if (input < 0.0) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            double realExchange = Currency.ExchangeRate;
            return input / realExchange;
        }
    }
}
