using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReaderWriter {
    public interface IBinary2TextProcessor {
        void Process(Stream input, TextWriter output);
    }
}
