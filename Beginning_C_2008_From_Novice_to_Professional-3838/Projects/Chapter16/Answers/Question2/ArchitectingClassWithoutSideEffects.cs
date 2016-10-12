using System;

namespace ArchitectingClassWithoutSideEffects {
    public delegate void LazyInitialization();

    public abstract class LazyInitializationBase {
        public LazyInitializationBase() {
            Initialize = delegate() {
                DoInitialization();
                Initialize = delegate() { };
            };
        }
        protected abstract void DoInitialization();
        protected LazyInitialization Initialize;
    }

    class ClassWithoutSideEffects : LazyInitializationBase {
        string _value;
        Func<string> _remoteInitialize;

        protected override void DoInitialization() {
            _value = _remoteInitialize();
        }
        public ClassWithoutSideEffects(Func<string> remoteInitialize)  {
            _remoteInitialize = remoteInitialize;
        }
        public string GetMeAValue() {
            Initialize();
            return _value;
        }
    }
}