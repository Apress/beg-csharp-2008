using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax.WiggleWiggle {
    internal class TaxEngine : BaseTaxEngine {
        public override double CalculateTaxToPay(ITaxAccount account) {
            double taxToPay = base.CalculateTaxToPay(account);
            if (_calculatedTaxable > 400) {
                taxToPay += 10;
            }
            return taxToPay;
        }
        public override ITaxAccount CreateTaxAccount() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
