using System;
using System.Linq;
using System.Collections;
using System.Text;
using LibLightingSystem;

namespace Museum {
public static class FactoryRooms {
    public static IRoom CreatePrivateRoom() {
        return new PrivateRoom();
    }
    public static IRoom CreatePublicRoom() {
        return new PublicRoom();
    }
    public static LightingController CreateBuilding() {
        LightingController controller = new LightingController();
        object publicAreas = controller.AddRoomGrouping("public viewing areas");
        object privateAreas = controller.AddRoomGrouping("private viewing areas");
        controller.AddRoomToGrouping(publicAreas, new PublicRoom());
        controller.AddRoomToGrouping(privateAreas, new PrivateRoom());
        return controller;
    }
}
}
