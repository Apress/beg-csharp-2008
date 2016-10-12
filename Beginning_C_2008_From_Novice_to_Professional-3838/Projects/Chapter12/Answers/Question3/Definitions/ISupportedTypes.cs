using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Definitions {
    public interface ISupportedTypes {
        bool IsTypeSupported(string typeidentifier);
        InstantiatedType Instantiate<InstantiatedType>(string typeidentifier);
    }
}
