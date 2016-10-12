using System.Collections;
using System;

namespace BeforeCShap2dot0 {
    class Example {
        int _value;

        public int Value {
            get {
                return _value;
            }
            set {
                _value = value;
            }
        }
    }

    class Another { }

    static class Tests {
        static void PlainVanillaObjects() {
            IList objects = new ArrayList();

            objects.Add(new Example { Value = 10 });
            objects.Add(new Example { Value = 20 });
            foreach (Example obj in objects) {
                Console.WriteLine("Object value (" + obj.Value + ")");
            }
        }
        static void MixedObjects() {
            try {
                IList objects = new ArrayList();

                objects.Add(new Example { Value = 10 });
                objects.Add(new Example { Value = 20 });
                objects.Add(new Another());
                foreach (Example obj in objects) {
                    Console.WriteLine("Object value (" + obj.Value + ")");
                }
            }
            catch (InvalidCastException ex) {
                Console.WriteLine("Expected exception");
            }
        }
        static void ValueTypeObjects() {
            IList objects = new ArrayList();
            objects.Add(1);
            objects.Add(2);
            foreach (int val in objects) {
                Console.WriteLine("Value (" + val + ")");
            }
        }
        public static void RunAll() {
            PlainVanillaObjects();
            MixedObjects();
            ValueTypeObjects();
        }
    }
}