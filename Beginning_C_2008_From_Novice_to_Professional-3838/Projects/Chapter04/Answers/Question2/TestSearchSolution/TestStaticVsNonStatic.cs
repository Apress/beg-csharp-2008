using System;
using System.Collections.Generic;
using System.Text;

namespace TestSearchSolution {
class MyStaticAndNonStaticClass {
    public static int Value;
    public static void MyMethod() {
        Value = 10;
        //InstanceValue = 20;
    }
    public int InstanceValue;
    public void MyInstanceMethod() {
        Value = 10;
        InstanceValue = 20;
    }
}
class TestStaticVsNonStatic {
    public void TestSimple() {
        MyStaticAndNonStaticClass.MyMethod();
        //MyStaticAndNonStaticClass.MyInstanceMethod();
        MyStaticAndNonStaticClass cls = new MyStaticAndNonStaticClass();
        cls.MyInstanceMethod();
    }
}
}
