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
            _exchangeRate = value;
        }
    }
    protected double ConvertValue(double input) {
        return _exchangeRate * input;
    }
    protected double ConvertValueInverse(double input) {
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

    public HotelCurrencyTrader(double currExchange, double spread, 
        string fromCurrency, string toCurrency) {
        ExchangeRate = currExchange;
        _fromCurrency = fromCurrency;
        _toCurrency = toCurrency;
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
