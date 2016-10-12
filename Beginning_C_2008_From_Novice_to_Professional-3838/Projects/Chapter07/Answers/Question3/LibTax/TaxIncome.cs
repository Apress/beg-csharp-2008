using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax {
    sealed class TaxIncome : ITaxIncome {
        double _amount;
        double _taxableRate;

        public TaxIncome(double amount, double taxableRate) {
            _amount = amount;
            _taxableRate = taxableRate;
        }
        public double RealAmount {
            get {
                return _amount;
            }
        }

        public double TaxableAmount {
            get {
                return _amount * _taxableRate;
            }
        }
    }
}
