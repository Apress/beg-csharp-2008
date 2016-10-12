using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax {
    public interface ITaxIncome {
        double RealAmount { get; }
        double TaxableAmount { get; }
    }
}
