﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ReaderWriter;

namespace TextProcessor {
    public static class Program {
        static void Main(string[] args) {
            Bootstrap.Process(args, new LottoTicketProcessor());
        }
    }
}
