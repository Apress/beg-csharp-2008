using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessor {
    public interface IProcessor {
        string Process(string input);
    }
}
