using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderWriter;

namespace Binary2Text {
    class Program {
        static void Main(string[] args) {
            Binary2TextBootstrap.Process(args, new LottoTicketProcessor());
        }
    }
}
