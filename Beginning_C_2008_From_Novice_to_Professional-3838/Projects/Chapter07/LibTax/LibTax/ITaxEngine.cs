using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax {
    public interface ITaxEngine {
        double CalculateTaxToPay(ITaxAccount account);
        ITaxDeduction CreateDeduction( double value);
        ITaxIncome CreateIncome( double value);
        ITaxAccount CreateTaxAccount();
    }
}
