using System;
using System.Collections.Generic;
using System.Text;

namespace LibCurrencyTrader {
    public sealed class CurrencyPair {
        string _baseCurrency;
        string _destinationCurrency;
        Decimal _exchangeRate;

        public CurrencyPair(string baseCurrency, string destinationCurrency, Decimal exchangeRate) {
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
        public Decimal ExchangeRate {
            get {
                return _exchangeRate;
            }
        }
    }

    public abstract class CurrencyTrader {
        CurrencyPair _currencyPair;
        protected readonly Decimal _zeroValue;

        public CurrencyTrader(CurrencyPair currencyPair) {
            _currencyPair = currencyPair;
            _zeroValue = new Decimal(0.0);
        }
        public CurrencyPair Currency {
            get {
                return _currencyPair;
            }
        }
        public abstract Decimal ConvertTo(Decimal value);
        public abstract Decimal ConvertFrom(Decimal value);
    }

    public class ActiveCurrencyTrader : CurrencyTrader {
        public ActiveCurrencyTrader( CurrencyPair currencyPair) : base( currencyPair) {
        }
        public override Decimal ConvertTo(Decimal input) {
            if (input < _zeroValue) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            return Currency.ExchangeRate * input;
        }
        public override Decimal ConvertFrom(Decimal input) {
            if (input < _zeroValue) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            return input / Currency.ExchangeRate;
        }
    }
    public class HotelCurrencyTrader : CurrencyTrader {
        Decimal _spread;

        public HotelCurrencyTrader(CurrencyPair currencyPair, Decimal spread)
            : base(currencyPair) {
            if (_spread < _zeroValue) {
                throw new ArgumentOutOfRangeException("Spread is a negative value");
            }
            _spread = spread;
        }
        public override Decimal ConvertTo(Decimal input) {
            if (input < _zeroValue) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            Decimal realExchange = Currency.ExchangeRate;
            realExchange -= _spread;
            return realExchange * input;
        }
        public override Decimal ConvertFrom(Decimal input) {
            if (input < _zeroValue) {
                throw new ArgumentOutOfRangeException("Amount to be converted must be positive");
            }
            Decimal realExchange = Currency.ExchangeRate;
            return input / realExchange;
        }
    }
}
