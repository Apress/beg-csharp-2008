using LibLightingSystem;
namespace TestLightingSystem {
    public static class TestsRoomImplementations {
        static void RunMuseum() {
            LightingController controller = Museum.FactoryRooms.CreateBuilding();
            foreach (string description in controller.RoomGroupingIterator()) {
                controller.TurnOnLights(controller[description]);
            }
        }
        static void RunHome() {
            LightingController controller = Home.FactoryRooms.CreateBuilding();
            foreach (string description in controller.RoomGroupingIterator()) {
                controller.TurnOnLights(controller[description]);
            }
        }
        public static void RunAll() {
            RunMuseum();
            RunHome();
        }
    }
}