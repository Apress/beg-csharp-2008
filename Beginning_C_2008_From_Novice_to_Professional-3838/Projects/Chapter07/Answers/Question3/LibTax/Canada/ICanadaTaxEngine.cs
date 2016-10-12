using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibTax.Canada {
    public enum Province {
        Albert,
        BritishColumbia,
        Manitoba,
        NewBrunswick,
        NewfoundlandLabrador,
        NovaScotia,
        Nunavut,
        Ontario,
        PrinceEdwardIsland,
        Quebec,
        Saskatchewan,
        Yukon
    }

    public interface ICanadaTaxEngine {
        ITaxAccount CreateTaxAccount( Province province, int year);
        ITaxIncome CreateCapitalGain(double amount);
    }
}
