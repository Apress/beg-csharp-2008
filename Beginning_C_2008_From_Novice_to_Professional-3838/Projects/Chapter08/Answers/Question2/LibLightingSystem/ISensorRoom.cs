using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace LibLightingSystem {
public interface ISensorRoom : IRemoteControlRoom {
    bool IsPersonInRoom { get; }
}
}
