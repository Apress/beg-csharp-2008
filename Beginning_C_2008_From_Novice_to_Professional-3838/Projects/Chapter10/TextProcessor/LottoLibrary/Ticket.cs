using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// type lotto.txt | TextProcessor.exe | Text2Binary.exe | Binary2Text.exe

namespace LottoLibrary {
    [Serializable]
    public class Ticket {
        int[] _numbers;
        int _bonus;
        DateTime _drawDate;

        public Ticket() { }
        public Ticket( DateTime drawDate, int[] numbers, int bonus) {
            _drawDate = drawDate;
            _numbers = numbers;
            _bonus = bonus;
        }
        public DateTime DrawDate {
            get {
                return _drawDate;
            }
            set {
                _drawDate = value;
            }
        }
        public int[] Numbers {
            get {
                return _numbers;
            }
            set {
                _numbers = value;
            }
        }
        public int Bonus {
            get {
                return _bonus;
            }
            set {
                _bonus = value;
            }
        }
    }
}
