using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace LibLightingSystem {

    class RoomGrouping : BaseLinkedList {
        public Room Rooms;
        public string Description;
    }

    class Room : BaseLinkedList {
        public IRoom ObjRoom;
    }

    public class LightingController {
        #region Room groupings
        private BaseLinkedList _roomGroupings = new RoomGrouping();

        public object AddRoomGrouping(string description) {
            object grouping = FindRoomGrouping(description);
            if (grouping != null) {
                return grouping;
            }
            grouping = new RoomGrouping {
                Description = description,
                Rooms = null
            };
            _roomGroupings.Insert(grouping as RoomGrouping);
            return grouping;
        }
        public object FindRoomGrouping(string description) {
            RoomGrouping curr = _roomGroupings.Next as RoomGrouping;
            while (curr != null) {
                if (curr.Description.CompareTo(description) == 0) {
                    return curr;
                }
                curr = curr.Next as RoomGrouping;
            }
            return null;
        }
        public object this[string description] {
            get {
                return FindRoomGrouping(description);
            }
        }

        public IEnumerable RoomGroupingIterator() {
            RoomGrouping curr = _roomGroupings.Next as RoomGrouping;
            while (curr != null) {
                yield return curr.Description;
                curr = curr.Next as RoomGrouping;
            }
        }
        public void AddRoomToGrouping(object grouping, IRoom room) {
            RoomGrouping roomGrouping = grouping as RoomGrouping;
            if (roomGrouping == null) {
                throw new Exception("Handle grouping is not a valid room grouping instance");
            }
            Room oldRooms = roomGrouping.Rooms as Room;
            if (oldRooms == null) {
                roomGrouping.Rooms = new Room { ObjRoom = room };
            }
            else {
                roomGrouping.Rooms.Insert(new Room { ObjRoom = room });
            }
        }
        public void RemoveRoomFromgrouping(object grouping, IRoom room) {
            RoomGrouping roomGrouping = grouping as RoomGrouping;
            if (roomGrouping == null) {
                throw new Exception("Handle grouping is not a valid room grouping instance");
            }
            Room curr = roomGrouping.Rooms as Room;
            while (curr != null) {
                if (curr.ObjRoom == room) {
                    curr.Remove();
                }
                curr = curr.Next as Room;
            }
        }
        #endregion

        public IEnumerable RoomIterator(string description) {
            RoomGrouping grouping = this[description] as RoomGrouping;
            if (grouping.Description.CompareTo(description) == 0) {
                Room curr = grouping.Rooms as Room;
                while (curr != null) {
                    yield return curr.ObjRoom;
                    curr = curr.Next as Room;
                }
            }
        }
        public IEnumerable RoomIterator(object handle) {
            RoomGrouping grouping = handle as RoomGrouping;
            Room curr = grouping.Rooms as Room;
            while (curr != null) {
                yield return curr.ObjRoom;
                curr = curr.Next as Room;
            }
        }
        // You add an exception block and in the example
        // I am only catching, creating a new exception
        // and nesting the old. Though in another system you
        // would do more. The idea is that the kernel has an exception
        // block to make sure that the kernel is never left in a hanging
        // state that could potentially corrupt the kernel
        public void DimLights(object grouping, double level) {
            foreach (IRoom room in RoomIterator(grouping)) {
                IRemoteControlRoom remote = room as IRemoteControlRoom;
                ISensorRoom sensorRoom = room as ISensorRoom;
                if (sensorRoom != null) {
                    if (!sensorRoom.IsPersonInRoom) {
                        try {
                            sensorRoom.DimLight(level);
                        }
                        catch (Exception e) {
                            throw new ApplicationException("Could not dim lights", e);
                        }
                    }
                }
                else if (remote != null) {
                    try {
                        remote.DimLight(level);
                    }
                    catch (Exception e) {
                        throw new ApplicationException("Could not dim lights", e);
                    }
                }
            }
        }
        public void TurnOffLights(object grouping) {
            foreach (IRoom room in RoomIterator(grouping)) {
                IRemoteControlRoom remote = room as IRemoteControlRoom;
                ISensorRoom sensorRoom = room as ISensorRoom;
                try {
                    if (sensorRoom != null) {
                        if (!sensorRoom.IsPersonInRoom) {
                            continue;
                        }
                    }
                    else if (remote != null) {
                        remote.LightSwitch(false);
                    }
                }
                catch (Exception e) {
                    throw new ApplicationException("Could not turn off lights", e);
                }
            }
        }
        public void TurnOnLights(object grouping) {
            foreach (IRoom room in RoomIterator(grouping)) {
                IRemoteControlRoom remote = room as IRemoteControlRoom;
                if (remote != null) {
                    try {
                        remote.LightSwitch(true);
                    }
                    catch (Exception e) {
                        throw new ApplicationException("Could not turn on light", e);
                    }
                }
            }
        }
    }
}
