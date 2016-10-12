using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax {
    public abstract class BaseTaxAccount : ITaxAccount {
        ITaxDeduction[] _deductions;
        ITaxIncome[] _incomes;

        public BaseTaxAccount() {
            _deductions = new ITaxDeduction[100];
            _incomes = new ITaxIncome[100];
        }

        public void AddDeduction(ITaxDeduction deduction) {
            for (int c1 = 0; c1 < 100; c1++) {
                if (_deductions[c1] == null) {
                    _deductions[c1] = deduction;
                    break;
                }
            }
        }

        public void AddIncome(ITaxIncome income) {
            for (int c1 = 0; c1 < 100; c1++) {
                if (_incomes[c1] == null) {
                    _incomes[c1] = income;
                    break;
                }
            }
        }

        public ITaxDeduction[] Deductions {
            get {
                return _deductions;
            }
        }

        public ITaxIncome[] Income {
            get {
                return _incomes;
            }
        }

        public abstract double GetTaxRate(double income);
    }
}
