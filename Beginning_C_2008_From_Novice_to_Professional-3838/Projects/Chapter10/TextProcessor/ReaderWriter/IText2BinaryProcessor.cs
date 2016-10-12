using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReaderWriter {
public interface IText2BinaryProcessor {
    void Process(TextReader input, Stream output);
}
}
