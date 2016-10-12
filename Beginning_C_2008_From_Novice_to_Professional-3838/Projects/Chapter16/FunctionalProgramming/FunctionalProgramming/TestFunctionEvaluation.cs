using System;

namespace FunctionalProgramming {

delegate void LazyInitialization();

class ClassWithoutSideEffects {
    string _value;
    public ClassWithoutSideEffects(Func<string> remoteInitialize) {
        Initialize = delegate() {
            this._value = remoteInitialize();
            Initialize = delegate() { };
        };
    }
    protected LazyInitialization Initialize;
    public string GetMeAValue() {
        Initialize();
        return _value;
    }
}

    class LazyInitialization< DataType> {
        protected DataType _dataToInitialize;

        public LazyInitialization( Func< DataType> remoteInitialize) {
            Initialize = delegate() {
                this._dataToInitialize = remoteInitialize();
                Initialize = delegate() { };
            };
        }

        protected LazyInitialization Initialize;
    }

    class ActiveInitialize : LazyInitialization<string> {
        public ActiveInitialize(Func<string> remoteInitialize) : base(remoteInitialize) { }
        public string Value {
            get {
                Initialize();
                return _dataToInitialize;
            }
        }
    }

    public class TestFunctionEvaluation {
        static void TestClassWithoutSideeffects() {
Func<string, Func<string>> lazyString = (stringToRetrieve) => () => {
    Console.WriteLine("Called initialization");
    return stringToRetrieve;
};

ClassWithoutSideEffects cls = new ClassWithoutSideEffects(lazyString("hello"));
ClassWithoutSideEffects cls2 = new ClassWithoutSideEffects(lazyString("goodbye"));
Console.WriteLine("Value (" + cls.GetMeAValue() + ")");
            Console.WriteLine("Value (" + cls2.GetMeAValue() + ")");
            Console.WriteLine("Value (" + cls.GetMeAValue() + ")");
            Console.WriteLine("Value (" + cls2.GetMeAValue() + ")");
        }
        static void TestActiveInitialization() {
            Func<string, Func<string>> lazyString = (stringToRetrieve) => () => {
                Console.WriteLine("Called initialization");
                return stringToRetrieve; 
            };

            ActiveInitialize cls = new ActiveInitialize(lazyString("hello"));
            Console.WriteLine("Value (" + cls.Value + ")");
            Console.WriteLine("Value (" + cls.Value + ")");
            Console.WriteLine("Value (" + cls.Value + ")");
        }
        public static void RunAll() {
            TestClassWithoutSideeffects();
            //TestActiveInitialization();
        }
    }
}