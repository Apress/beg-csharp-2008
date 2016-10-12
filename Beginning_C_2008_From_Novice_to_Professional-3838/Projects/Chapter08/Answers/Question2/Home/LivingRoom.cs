using System;
using System.Linq;
using System.Collections;
using System.Text;
using LibLightingSystem;

namespace Home {
    class LivingRoom : ISensorRoom {
        #region ISensorRoom Members

        public bool IsPersonInRoom {
            get { return false; }
        }

        #endregion

        #region IRemoteControlRoom Members

        double _lightLevel;

        public double LightLevel {
            get { return _lightLevel; }
        }

        public void LightSwitch(bool lightState) {
            if (lightState) {
                _lightLevel = 1.0;
            }
            else {
                _lightLevel = 0.0;
            }
        }

        public void DimLight(double level) {
            _lightLevel = level;
        }

        #endregion
    }
}
