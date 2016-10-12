using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax {
    public interface ITaxAccount {
        void AddDeduction(ITaxDeduction deduction);
        void AddIncome(ITaxIncome income);
        double GetTaxRate(double income);
        ITaxDeduction[] Deductions { get; }
        ITaxIncome[] Income { get; }
    }
    public interface ITaxAccount2 : ITaxAccount {
        double BaseTaxFreeLevel { get; }
    }
}
