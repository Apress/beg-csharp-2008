using System;
using System.Collections.Generic;
using System.Text;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    class ObjectReference {
        object _reference;
        string _identifier;

        public ObjectReference(object reference, string identifier) {
            _reference = reference;
            _identifier = identifier;
        }

        public object Reference {
            get {
                return _reference;
            }
        }
        public string Identifier {
            get {
                return _identifier;
            }
        }
        public override string ToString() {
            return "ObjectReference <" + _identifier + ">";
        }
    }
}
