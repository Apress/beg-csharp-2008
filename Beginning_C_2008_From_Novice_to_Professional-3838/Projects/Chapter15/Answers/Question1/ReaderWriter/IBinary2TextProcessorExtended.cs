using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderWriter {
    public interface IBinary2TextProcessorExtended : IBinary2TextProcessor {
        string Initialize();
        string Finalize();
    }
}
