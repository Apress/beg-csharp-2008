#define ACTIVATE_1
#undef ACTIVATE_2

namespace TestDefine {
    class Example {
#if ACTIVATE_1
        int _dataMember;
#elif !NO_ACTIVATE_10
        int _dataMember3;
#else
        int _defaultValue;
#endif
    }
}