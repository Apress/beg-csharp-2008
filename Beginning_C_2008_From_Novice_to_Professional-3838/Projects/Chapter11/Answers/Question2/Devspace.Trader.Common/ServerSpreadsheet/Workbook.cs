using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Devspace.Trader.Common.Tracer;
using System.Reflection;
using System.IO;
using Devspace.Trader.Common.Automators;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    class Workbook : TraderBaseClass, IWorkbook, IEnumerable<string> {
        IDictionary<string, IWorksheetBase> _worksheets = new Dictionary<string, IWorksheetBase>();

        string _identifier;
        public string Identifier {
            get {
                return _identifier;
            }
        }
        bool _generateRowCounter;
        public bool GenerateRowCounter {
            get {
                return _generateRowCounter;
            }
            set {
                _generateRowCounter = value;
            }
        }

        public Workbook(string identifier) {
            _identifier = identifier;
        }
        public void Clear() {
            _worksheets.Clear();
        }
        public IWorksheet<StateType> GetSheet<StateType>(string identifier) {
            lock (_worksheets) {
                IWorksheet<StateType> retval = null;
                if (_worksheets.ContainsKey(identifier)) {
                    retval = _worksheets[identifier] as IWorksheet<StateType>;
                }
                else {
                    retval = new Worksheet<StateType>(identifier);
                    _worksheets.Add(identifier, retval);
                }
                return retval;
            }
        }
        public IWorksheetBase this[string identifier] {
            get {
                IWorksheetBase retval = null;
                lock (_worksheets) {
                    if (_worksheets.ContainsKey(identifier)) {
                        retval = _worksheets[identifier];
                    }
                }
                return retval;
            }
            set {
                lock (_worksheets) {
                    if (_worksheets.ContainsKey(identifier)) {
                        _worksheets.Remove(identifier);
                    }
                    _worksheets.Add(identifier, value);
                }
            }
        }
        IEnumerator<string> IEnumerable<string>.GetEnumerator() {
            foreach (string identifier in _worksheets.Keys) {
                yield return identifier;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return (((IEnumerable<string>)this) as IEnumerable).GetEnumerator();
        }
        public override string ToString() {
            string buffer = "";
            foreach (string identifier in this) {
                buffer += "Workbook (" + identifier + ")";
            }
            return buffer;
        }
    }
}
