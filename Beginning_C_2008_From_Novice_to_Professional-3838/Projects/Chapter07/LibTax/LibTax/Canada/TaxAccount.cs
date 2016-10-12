using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax.Canada {
    static class OntarioTax2007 {
        public static double TaxRate(double income) {
            double runningTotal = 0.0;

            if (income > 120887.0) {
                runningTotal += (income - 120887.0) * 0.4641;
                income = 120887.0;
            }
            if (income > 74357.0) {
                runningTotal += (income - 74357.0) * 0.4341;
                income = 74357.0;
            }
            if (income > 73625.0) {
                runningTotal += (income - 73625.0) * 0.3941;
                income = 73625.0;
            }
            if (income > 70976.0) {
                runningTotal += (income - 70976.0) * 0.3539;
                income = 70976.0;
            }
            if (income > 62485.0) {
                runningTotal += (income - 62485.0) * 0.3298;
                income = 62485.0;
            }
            if (income > 37178.0) {
                runningTotal += (income - 37178.0) * 0.3115;
                income = 37178.0;
            }
            if (income > 35448.0) {
                runningTotal += (income - 35448.0) * 0.2465;
                income = 35448.0;
            }
            runningTotal += income * 0.155;
            return runningTotal / income;
        }
    }

    internal class TaxAccount : BaseTaxAccount {
        Province _province;
        int _year;

        public TaxAccount(Province province, int year) {
            _province = province;
            _year = year;
        }
        public override double GetTaxRate(double income) {
            if (_year == 2007) {
                if (_province == Province.Ontario) {
                    return OntarioTax2007.TaxRate(income);
                }
            }
            throw new NotSupportedException("Year " + _year + " Province " + _province + " not supported");
        }
    }
}
