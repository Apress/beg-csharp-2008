using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderWriter;

namespace Text2Binary {
    class Program {
        static void Main(string[] args) {
            Text2BinaryBootstrap.Process(args, new LottoTicketProcessor());
        }
    }
}
