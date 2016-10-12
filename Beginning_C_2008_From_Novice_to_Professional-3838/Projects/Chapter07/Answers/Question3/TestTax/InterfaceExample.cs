using System;

interface IExample {
    void Method();
    int Property { get; set; }
}

class ExampleImplementation : IExample {
    public void Method() {
        throw new Exception("The method or operation is not implemented.");
    }

    public int Property {
        get {
            throw new Exception("The method or operation is not implemented.");
        }
        set {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}

public class ExampleUsage {
    public static void Runall() {
        IExample cls = new ExampleImplementation();
        cls.Method();
    }
}