using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReaderWriter {
    public interface IBinaryProcessor {
        void Process(Stream input, Stream output);
    }
}
