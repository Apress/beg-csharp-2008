using System;
using System.Collections.Generic;
using System.Text;

namespace LibCurrencyTrader {
    public abstract class CurrencyTrader {
        private double _exchangeRate;

        protected double ExchangeRate {
            get {
                return _exchangeRate;
            }
            set {
                if (_exchangeRate < 0.0) {
                    throw new ArgumentOutOfRangeException("Exchange rate must be positive");
                }
                _exchangeRate = value;
            }
        }
        protected double ConvertValue(double input) {
            if (input < 0.0) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            return _exchangeRate * input;
        }
        protected double ConvertValueInverse(double input) {
            if (input < 0.0) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            return input / _exchangeRate;
        }
        public abstract double ConvertTo(double value);
        public abstract double ConvertFrom(double value);
    }

    public class ActiveCurrencyTrader : CurrencyTrader {
        string _fromCurrency;
        string _toCurrency;

        public ActiveCurrencyTrader(double currExchange, string fromCurrency, string toCurrency) {
            ExchangeRate = currExchange;
            _fromCurrency = fromCurrency;
            _toCurrency = toCurrency;
        }
        public string FromCurrency {
            get {
                return _fromCurrency;
            }
        }
        public string ToCurrency {
            get {
                return _toCurrency;
            }
        }
        public override double ConvertTo(double value) {
            return ConvertValue(value);
        }
        public override double ConvertFrom(double value) {
            return ConvertValueInverse(value);
        }
    }
    public class HotelCurrencyTrader : CurrencyTrader {
        string _fromCurrency;
        string _toCurrency;
        double _spread;

        // The spread is assumed to be a positive value
        // What if the spread were a negative number ?
        // This then raises the argument if spread could be negative, what about 
        // the exchange value? Answer yes that is a problem as well
        // This situation is an illustration of a bug that you probably
        // did not think about, but is very real.
        public HotelCurrencyTrader(double currExchange, double spread,
            string fromCurrency, string toCurrency) {
            ExchangeRate = currExchange;
            _fromCurrency = fromCurrency;
            _toCurrency = toCurrency;
            if (_spread < 0.0) {
                throw new ArgumentOutOfRangeException("Spread is a negative value");
            }
            _spread = spread;
        }
        public string FromCurrency {
            get {
                return _fromCurrency;
            }
        }
        public string ToCurrency {
            get {
                return _toCurrency;
            }
        }
        public override double ConvertTo(double value) {
            double realExchange = ExchangeRate;
            ExchangeRate = realExchange - _spread;
            double retval = ConvertValue(value);
            ExchangeRate = realExchange;
            return retval;
        }
        public override double ConvertFrom(double value) {
            double realExchange = ExchangeRate;
            ExchangeRate = realExchange + _spread;
            double retval = ConvertValueInverse(value);
            ExchangeRate = realExchange;
            return retval;
        }
    }
}
