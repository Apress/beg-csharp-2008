using System;

namespace ExceptionsThatCorruptState {
class MyType {
    public int DataMember;
}
class Tests {
    public int LocalDataMember;

    public void GeneratesException() {
        LocalDataMember = 10;
        MyType cls = null;
        cls.DataMember = 10;
    }
    public void RunAll() {
        Console.WriteLine("LocalDataMember=" + LocalDataMember);
        try {
            GeneratesException();
        }
        catch (Exception) {
            ;
        }
        Console.WriteLine("LocalDataMember=" + LocalDataMember);
    }
}
}