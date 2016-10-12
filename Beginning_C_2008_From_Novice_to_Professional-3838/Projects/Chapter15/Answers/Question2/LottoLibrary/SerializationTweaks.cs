using System;
using System.Runtime.Serialization;


namespace SerializationTweaks {

    [Serializable]
    class MyObject : ISerializable {
        int value;

        public MyObject() { }
        public MyObject(SerializationInfo info, StreamingContext context) {
            value = int.Parse((string)info.GetValue("value", typeof(string)));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("value", value.ToString());
        }
    }

    [Serializable]
    class MyObject2 {
        [NonSerialized]
        private int _networkIdentifier;
    }

    class Doer {
        MyObject2 _object;
    }
}