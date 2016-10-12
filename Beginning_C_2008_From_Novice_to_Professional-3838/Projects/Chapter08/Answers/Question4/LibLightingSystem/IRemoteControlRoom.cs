using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace LibLightingSystem {
public interface IRemoteControlRoom : IRoom {
    double LightLevel { get; }
    void LightSwitch(bool lightState);
    void DimLight(double level);
}
}
