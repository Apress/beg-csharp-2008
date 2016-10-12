using System;
using System.Linq;
using System.Collections;
using System.Text;
using LibLightingSystem;

namespace Home {
    public static class FactoryRooms {
        public static IRoom CreateBedroom() {
            return new Bedroom();
        }
        public static IRoom CreateGarage() {
            return new Garage();
        }
        public static IRoom CreateLivingRoom() {
            return new LivingRoom();
        }
        public static LightingController CreateBuilding() {
            LightingController controller = new LightingController();
            object home = controller.AddRoomGrouping("home");
            controller.AddRoomToGrouping(home, new Bedroom());
            controller.AddRoomToGrouping(home, new Bedroom());
            controller.AddRoomToGrouping(home, new LivingRoom());
            controller.AddRoomToGrouping(home, new Garage());
            return controller;
        }
    }
}
