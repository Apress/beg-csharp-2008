using System;

namespace Scenario1 {
    class Base {
        public void Method() {
            Console.WriteLine("Base.Method");
        }
    }
    class Derived : Base {
        public new void Method() {
            Console.WriteLine("Derived.Method");
        }
    }

    class Test {
        public static void Run() {
            Derived derivedCls = new Derived();
            Base baseCls = derivedCls;

            // Calls Derived.Method
            derivedCls.Method();
            // Calls Base.Method
            baseCls.Method();
        }
    }
}

namespace Scenario2 {
    class Base {
        public virtual void Method() {
            Console.WriteLine("Base.Method");
        }
    }
    class Derived : Base {
        public override void Method() {
            Console.WriteLine("Derived.Method");
        }
    }

    class Test {
        public static void Run() {
            Derived derivedCls = new Derived();
            Base baseCls = derivedCls;

            // Calls Derived.Method
            derivedCls.Method();
            // Calls Derived.Method
            baseCls.Method();
        }
    }
}

namespace Scenario3 {
    interface IInterface {
        void Method();
    }
    class Implementation : IInterface {
        public void Method() {
            Console.WriteLine("Implementation.Method");
        }
    }

    class Test {
        public static void Run() {
            Implementation implementation = new Implementation();
            IInterface inst = implementation;

            // Calls Implementation.Method
            implementation.Method();
            // Calls Implementation.Method
            inst.Method();
        }
    }
}

namespace Scenario4 {
    interface IInterface1 {
        void Method();
    }
    interface IInterface2 {
        void Method();
    }
    class Implementation : IInterface1, IInterface2 {
        void IInterface1.Method() {
            Console.WriteLine("Implementation.IInterface1.Method");
        }
        void IInterface2.Method() {
            Console.WriteLine("Implementation.IInterface1.Method");
        }
    }

    class Test {
        public static void Run() {
            Implementation implementation = new Implementation();
            IInterface1 inst1 = implementation;
            IInterface1 inst2 = implementation;

            // Cannot be called
            //implementation.IInterface1.Method();
            // Calls Implementation.IInterface1.Method
            inst1.Method();
            // Calls Implementation.IInterface2.Method
            inst2.Method();
        }
    }
}

namespace Scenario5 {
    interface IInterface {
        void Method();
    }
    class BaseImplementation {
        public void Method() {
            Console.WriteLine("Implementation.Method");
        }
    }
    class ImplementationDerived : BaseImplementation, IInterface {
    }

    class Test {
        public static void Run() {
            ImplementationDerived implementation = new ImplementationDerived();
            IInterface inst = implementation;

            // Calls Implementation.Method
            implementation.Method();
            // Calls Implementation.Method
            inst.Method();
        }
    }
}

namespace Scenario6 {
    interface IInterface {
        void Method();
    }
    class Implementation : IInterface {
        public virtual void Method() {
            Console.WriteLine("Implementation.Method");
        }
    }
    class ImplementationDerived : Implementation {
        public override void Method() {
            Console.WriteLine("ImplementationDerived.Method");
        }
    }

    class Test {
        public static void Run() {
            ImplementationDerived implementation = new ImplementationDerived();
            IInterface inst = implementation;

            // Calls Implementation.Method
            implementation.Method();
            // Calls Implementation.Method
            inst.Method();
        }
    }
}


namespace Scenario7 {
    class Base {
        public virtual void Method() {
            Console.WriteLine("Base.Method");
        }
    }
    class Derived1 : Base {
        public override void Method() {
            Console.WriteLine("Derived1.Method");
        }
    }
    class Derived2 : Derived1 {
        public new virtual void Method() {
            Console.WriteLine("Derived2.Method");
        }
    }
    class Derived3 : Derived2 {
        public new virtual void Method() {
            Console.WriteLine("Derived3.Method");
        }
    }

    class Test {
        public static void Run() {
            Derived3 derivedCls = new Derived3();
            Base baseCls = derivedCls;
            Derived2 derived2cls = derivedCls;

            // Calls Derived3.Method
            derivedCls.Method();
            // Calls Derived.Method
            baseCls.Method();
            // Calls Derived3.Method
            derived2cls.Method();
        }
    }
}
