using System;

namespace StackUnwinding {
    class CallingExample {
        int depth;
        public void CalledCalledMethod() {
            depth = 2;
            throw new Exception();
        }
        public void CalledMethod() {
            depth = 1;
            CalledCalledMethod();
            depth = 1;
        }
        public void Method() {
            depth = 0;
            CalledMethod();
            depth = 0;
        }
        public int GetDepth() {
            return depth;
        }
    }
    class CallingExampleWithFinally {
        int depth;
        public void CalledCalledMethod() {
            depth = 2;
            throw new Exception();
        }
        public void CalledMethod() {
            depth = 1;
            try {
                CalledCalledMethod();
            }
            finally {
                depth = 1;
            }
        }
        public void Method() {
            depth = 0;
            try {
                CalledMethod();
            }
            finally {
                depth = 0;
            }
        }
        public int GetDepth() {
            return depth;
        }
    }

    class SeparateTheSteps {
        public void PossibleExceptionMethod() {
        }
    }
    class Tests {
        void TestCallingExample() {
            CallingExample cls = null;
            try {
                cls = new CallingExample();
                cls.Method();
            }
            catch (Exception) { ;}
            Console.WriteLine("Depth is (" + cls.GetDepth() + ")");
        }
        void TestCallingExample2() {
            CallingExample cls = null;
            try {
                cls = new CallingExample();
                cls.Method();
            }
            catch (Exception) { ;}
            if (cls != null) {
                Console.WriteLine("Depth is (" + cls.GetDepth() + ")");
            }
        }
        int TestGetValue(string buffer) {
            int retval = 0;
            try {
                retval = int.Parse(buffer);
            }
            catch (FormatException ex) {
                Console.WriteLine("Exception (" + ex.Message + ")");
            }
            return retval;
        }
        bool TestGetValue2(string buffer, out int val) {
            bool retval = false;
            if (int.TryParse(buffer, out val)) {
                retval = true;
            }
            return retval;
        }

        void TestCallingExampleWithFinally() {
            CallingExampleWithFinally cls = null;
            try {
                cls = new CallingExampleWithFinally();
                cls.Method();
            }
            catch (NotSupportedException ex) {
            }
            catch (Exception ex) {
                if (ex is NotSupportedException) {
                }
                else {
                    throw ex;
                }
            }
            Console.WriteLine("Depth is (" + cls.GetDepth() + ")");
        }
        SeparateTheSteps Separated() {
            SeparateTheSteps cls = null;

            cls = new SeparateTheSteps();
            cls.PossibleExceptionMethod();

            return cls;
        }

        public void RunAll() {
            TestCallingExample();
            TestCallingExampleWithFinally();
        }
    }
class DefaultStateWrong {
    private string[] ParseBuffers( string buffer) {
        return null;
    }
    public void IterateBuffers(string buffer) {
        string[] found = ParseBuffers(buffer);
        if (found != null) {
            for (int c1 = 0; c1 < found.Length; c1++) {
                Console.WriteLine("Found (" + found[c1] + ")");
            }
        }
    }
}
class DefaultStateRight {
    private string[] ParseBuffers(string buffer) {
        return new string[0];
    }
    public void IterateBuffers(string buffer) {
        string[] found = ParseBuffers(buffer);
        for (int c1 = 0; c1 < found.Length; c1++) {
            Console.WriteLine("Found (" + found[c1] + ")");
        }
    }
}
}