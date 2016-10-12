using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace LibLightingSystem {
    public abstract class BaseLinkedList {
        private BaseLinkedList _next;
        private BaseLinkedList _prev;

        public BaseLinkedList Next {
            get {
                return _next;
            }
        }
        public BaseLinkedList Prev {
            get {
                return _prev;
            }
        }

        public void Insert(BaseLinkedList item) {
            item._next = _next;
            item._prev = this;

            if (_next != null) {
                _next._prev = item;
            }
            _next = item;
        }
        public void Remove() {
            if (_next != null) {
                _next._prev = _prev;
            }
            if (_prev != null) {
                _prev._next = _next;
            }
            _next = null;
            _prev = null;
        }
    }

}
