using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Definitions {
    public interface IDefinition {
        string TranslateWord(string word);
        string this[string word] { get; set; }
    }
}
