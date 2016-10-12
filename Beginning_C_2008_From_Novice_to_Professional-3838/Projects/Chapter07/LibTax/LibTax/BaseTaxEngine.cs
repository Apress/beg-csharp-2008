using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax {
    public static class EngineCreator {
        public static ITaxEngine CreateCanadianTaxEngine() {
            return new Canada.TaxEngine();
        }
        public static ITaxEngine CreateWiggleWiggleEngine() {
            return new WiggleWiggle.TaxEngine();
        }
    }

    public abstract class BaseTaxEngine : ITaxEngine {
        protected double _calculatedTaxable;

        public BaseTaxEngine() { }
        public virtual double CalculateTaxToPay(ITaxAccount account) {
            _calculatedTaxable = 0.0;
            foreach (ITaxIncome income in account.Income) {
                if (income != null) {
                    _calculatedTaxable += income.TaxableAmount;
                }
            }
            foreach (ITaxDeduction deduction in account.Deductions) {
                if (deduction != null) {
                    _calculatedTaxable -= deduction.Amount;
                }
            }
            return account.GetTaxRate(_calculatedTaxable) * _calculatedTaxable;
        }

        public virtual ITaxDeduction CreateDeduction(double amount) {
            return new TaxDeduction(amount);
        }
        public virtual ITaxIncome CreateIncome(double amount) {
            return new TaxIncome(amount, 1.0);
        }
        public abstract ITaxAccount CreateTaxAccount();
    }
}
