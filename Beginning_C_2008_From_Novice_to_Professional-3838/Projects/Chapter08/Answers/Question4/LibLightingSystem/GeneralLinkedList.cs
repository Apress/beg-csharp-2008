using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LibLightingSystem {
    // The general linked list class is by no means complete
    // What is complete is the definition of a private class
    // the iterators using manual techniques, and the ability
    // to build a list of items
    public sealed class GeneralLinkedList : IEnumerable, IEnumerator {
        private class GeneralLinkedListItem : BaseLinkedList {
            public object Data;
        }

        private GeneralLinkedListItem _items;
        private GeneralLinkedListItem _currItem;

        public GeneralLinkedList() {
            _items = null;
        }

        public void Add(object data) {
            GeneralLinkedListItem item = new GeneralLinkedListItem();
            item.Data = data;
            if (_items == null) {
                _items = item;
            }
            else {
                _items.Insert(item);
            }
        }

        #region IEnumerator Members

        public object Current {
            get {
                if (_currItem == null) {
                    throw new NullReferenceException("current item is null");
                }
                return _currItem.Data;
            }
        }
        // The MoveNext is a bit odd
        // When calling foreach there is no calling to reset
        // It is expected that the movenext will be a reset
        public bool MoveNext() {
            if (_currItem == null) {
                Reset();
                return true;
            }

            _currItem = _currItem.Next as GeneralLinkedListItem;
            if (_currItem != null) {
                return true;
            }
            else {
                return false;
            }
        }

        public void Reset() {
            _currItem = _items;
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator() {
            return this;
        }

        #endregion
    }
}
