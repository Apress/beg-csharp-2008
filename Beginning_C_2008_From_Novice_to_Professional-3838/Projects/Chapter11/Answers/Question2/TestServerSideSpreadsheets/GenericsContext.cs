using System;

namespace GenericsContext {
    public class MyType {
        public void Method() {
            Console.WriteLine("hello world");
        }
    }
    public class Container {
        object _managed;

        public Container(object toManage) {
            _managed = toManage;
        }

        public object Managed {
            get {
                return _managed;
            }
        }
    }

    public class GenericsContainer<ManagedType> {
        ManagedType _managed;
        public GenericsContainer(ManagedType toManage) {
            _managed = toManage;
        }
        public ManagedType Managed {
            get {
                return _managed;
            }
        }
    }

    public static class TestGenerics {
        static void IllustrateObjectContainer() {
            Container container = new Container(new MyType());

            if (container.Managed is MyType) {
                (container.Managed as MyType).Method();
            }
        }
        static void IllustrateGenericContainer() {
            GenericsContainer<MyType> container = new GenericsContainer<MyType>(new MyType());
            container.Managed.Method();
        }

        public static void RunAll() {
            IllustrateObjectContainer();
            IllustrateGenericContainer();
        }
    }
}