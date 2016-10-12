using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibLightingSystem;

namespace TestLightingSystem {
    static class TestAddRoomGrouping {
        // The bug is that you can add two room groupings with the same identifier
        static void IllustrateError() {
            Console.WriteLine("**************");
            Console.WriteLine("IllustrateError: Start");

            LightingController controller = new LightingController();

            object handle1 = controller.AddRoomGrouping("test");
            if (handle1 == null) {
                throw new Exception("Could not add room grouping");
            }
            object handle2 = controller.AddRoomGrouping("test");
            if (handle2 == null) {
                throw new Exception("Could not add room grouping");
            }
            if (handle1 != handle2) {
                Console.WriteLine("This is a bug");
            }
            Console.WriteLine("IllustrateError: End");
        }
        public static void RunAll() {
            IllustrateError();
        }
    }
}
