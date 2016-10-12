using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax.Canada {
    internal class TaxEngine : BaseTaxEngine, ICanadaTaxEngine {
        public override ITaxAccount CreateTaxAccount() {
            return new TaxAccount(Province.Ontario, 2007);
        }
        public ITaxAccount CreateTaxAccount(Province province, int year) {
            return new TaxAccount(province, year);
        }
        public ITaxIncome CreateCapitalGain(double amount) {
            return new TaxIncome(amount, 0.50);
        }
    }
}
