using System;
namespace UniversalDataConverter {
class UniversalDataConverterClass {
    public outType Convert<outType, inType>(inType input) {
        if (input is string && typeof(string).IsAssignableFrom(typeof(outType))) {
            return (outType)(object)input;
        }
        else if (input is string && typeof(int).IsAssignableFrom(typeof(outType))) {
            return (outType)(object)int.Parse((string)(object)input);
        }
        return default(outType);
    }
}

    static class TestDataConverter {
        public static void RunAll() {
            UniversalDataConverterClass converter = new UniversalDataConverterClass();
            String buffer = converter.Convert<string, string>("buffer");
            int value = converter.Convert<int, string>("123");
            if (buffer != "buffer") {
                Console.WriteLine("Conversion did not work");
            }
            if (value != 123) {
                Console.WriteLine("Conversion to number did not work");
            }
        }
    }
}