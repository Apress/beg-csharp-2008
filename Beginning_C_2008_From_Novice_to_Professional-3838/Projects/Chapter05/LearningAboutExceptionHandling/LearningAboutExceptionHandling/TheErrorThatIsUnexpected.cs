using System;

namespace TheErrorThatIsUnexpected {
class MyType {
    public int DataMember;
}
class Tests {
    public void GeneratesException() {
        MyType cls = null;
        cls.DataMember = 10;
    }
    public void RunAll() {
try {
    GeneratesException();
}
catch (Exception) {
    ;
}
    }
}
}