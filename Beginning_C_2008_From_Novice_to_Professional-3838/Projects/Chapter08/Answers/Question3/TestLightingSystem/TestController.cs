using LibLightingSystem;
using System;

namespace TestLightingSystem {
    class TestRoom : IRoom {
        public string Description;
    }
    public static class TestsLightingController {
        static void RunAddGrouping() {
            Console.WriteLine("**************");
            Console.WriteLine("RunAddGrouping: Start");

            LightingController controller = new LightingController();

            object handle = controller.AddRoomGrouping("test");
            if (handle == null) {
                throw new Exception("Could not add room grouping");
            }
            object sameHandle = controller.FindRoomGrouping("test");
            if (handle != sameHandle) {
                throw new Exception("Should have found the room grouping");
            }
            object indexerHandle = controller["test"];
            if (handle != indexerHandle) {
                throw new Exception("Indexer should have found the room grouping");
            }
            Console.WriteLine("RunAddGrouping: End");
        }
        static void IterateGroupings() {
            Console.WriteLine("**************");
            Console.WriteLine("IterateGroupings: Start");

            LightingController controller = new LightingController();

            controller.AddRoomGrouping("test1");
            controller.AddRoomGrouping("test2");
            controller.AddRoomGrouping("test3");
            controller.AddRoomGrouping("test4");
            controller.AddRoomGrouping("test5");
            int runningTotal = 0;
            foreach (string description in controller.RoomGroupingIterator()) {
                Console.WriteLine("Room grouping (" + description + ")");
                if (description.CompareTo("test1") == 0) {
                    runningTotal += 1;
                }
                else if (description.CompareTo("test2") == 0) {
                    runningTotal += 2;
                }
                else if (description.CompareTo("test3") == 0) {
                    runningTotal += 4;
                }
                else if (description.CompareTo("test4") == 0) {
                    runningTotal += 8;
                }
                else if (description.CompareTo("test5") == 0) {
                    runningTotal += 16;
                }
            }
            if (runningTotal != 31) {
                throw new Exception("Iterate groupings did not work");
            }
            Console.WriteLine("IterateGroupings: End");
        }
        public static void RoomManipulations() {
            Console.WriteLine("**************");
            Console.WriteLine("AddRoom: Start");
            LightingController controller = new LightingController();

            object handle = controller.AddRoomGrouping("test1");
            IRoom room1 = new TestRoom { Description = "room 1" };
            IRoom room2 = new TestRoom { Description = "room 2" };
            controller.AddRoomToGrouping( handle, room1);
            controller.AddRoomToGrouping( handle, room2);
            int runningTotal = 0;
            foreach (IRoom room in controller.RoomIterator("test1")) {
                TestRoom testRoom = room as TestRoom;
                if (testRoom != null) {
                    Console.WriteLine("Room (" + testRoom.Description + ")");
                    if (testRoom.Description.CompareTo("room 1") == 0) {
                        runningTotal += 1;
                    }
                    else if (testRoom.Description.CompareTo("room 2") == 0) {
                        runningTotal += 2;
                    }
                }
            }
            if (runningTotal != 3) {
                throw new Exception("Iterate rooms did not work");
            }
            Console.WriteLine("AddRoom: End");
        }
        public static void RunAll() {
            RunAddGrouping();
            IterateGroupings();
            RoomManipulations();
        }
    }
}