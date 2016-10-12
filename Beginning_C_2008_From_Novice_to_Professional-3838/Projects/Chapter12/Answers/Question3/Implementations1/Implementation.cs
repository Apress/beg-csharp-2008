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

class ReferenceSupportedTypes : ISupportedTypes {
    #region ISupportedTypes Members

    public bool IsTypeSupported(string typeidentifier) {
        if (typeidentifier.CompareTo("SuperCool") == 0) {
            return true;
        }
        else if (typeidentifier.CompareTo("Impl1") == 0) {
            return true;
        }
        return false;
    }

    public InstantiatedType Instantiate<InstantiatedType>(string typeidentifier) {
        if (typeidentifier.CompareTo("SuperCool") == 0 || typeidentifier.CompareTo( "Impl1") == 0) {
            try {
                object obj = (new Implementations1.Implementation());
                return (InstantiatedType)obj;
            }
            catch (Exception e) {
                ;
            }
        }
        return default(InstantiatedType);
    }

    #endregion
}
