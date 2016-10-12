using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Definitions;

namespace Implementations1 {
    class Implementation : IDefinition {
        #region IDefinition Members

        public string TranslateWord(string word) {
            return word + ",";
        }

        public string this[string word] {
            get {
                throw new Exception("The method or operation is not implemented.");
            }
            set {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
