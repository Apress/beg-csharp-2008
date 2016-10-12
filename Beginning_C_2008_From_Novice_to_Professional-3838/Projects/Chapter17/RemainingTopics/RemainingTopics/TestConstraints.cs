using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemainingTopics {
    interface IExample {
        void Method();
    }

interface IBase {
    int Value { get; set; }
}
class ExampleMgr<DataType> where DataType : IExample {
    DataType _inst;

    public ExampleMgr(DataType inst) {
        _inst = inst;
    }
    public void DoSomething() {
        _inst.Method();
    }

    public DataType Inst {
        get {
            return _inst;
        }
    }
}

class ExampleMgr {
    IExample _inst;

    public ExampleMgr(IExample inst) {
        _inst = inst;
    }
    public void DoSomething() {
        _inst.Method();
    }
}

class Example<DataType> where DataType : IBase, new() {
    DataType _value;

    public Example() {
        _value = new DataType { Value = 10 };

    }
}

class AssumeReferenceType<DataType> where DataType : class {
    DataType _value;

    public AssumeReferenceType(DataType value) {
    }
}
    class TestConstraints {
        public static void RunAll() {
            AssumeReferenceType<IExample> cls = new AssumeReferenceType<IExample>(null);
        }
    }
}
