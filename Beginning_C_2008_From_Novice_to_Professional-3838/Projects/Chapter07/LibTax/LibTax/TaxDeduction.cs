using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax {
    sealed class TaxDeduction : ITaxDeduction {
        double _amount;

        public TaxDeduction(double amount) {
            _amount = amount;
        }
        public double Amount {
            get {
                return _amount;
            }
        }
    }
}
