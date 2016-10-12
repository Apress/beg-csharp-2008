using System;
using System.Collections.Generic;
using System.Text;

namespace Devspace.Trader.Common.Automators {
    public class TraderBaseClass {
        private bool _debug;
        public bool Debug {
            get {
                return _debug;
            }
            set {
                _debug = value;
            }
        }
    }
}
