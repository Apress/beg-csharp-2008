using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemainingTopics {
    class TestOperators {
        const int isTall = 1;
        const int wearsHats = 2;
        const int runsSlow = 4;

        static void RunAll() {
            int person = isTall | runsSlow;

            if ((person & isTall) != 0) {
                Console.WriteLine("Person is tall");
            }
            else {
                Console.WriteLine("Person is not tall");
            }


            person = ~person;

            if ((person & isTall) != 0) {
                Console.WriteLine("Person is tall");
            }
            else {
                Console.WriteLine("Person is not tall");
            }

            int shifted = 8;
            int shiftedLeft = shifted << 2;
            int shiftedRight = shifted >> 2;

            Console.WriteLine("Shifted Left (" + shiftedLeft + ") Right (" + shiftedRight + ")");
            int value = ~8;
            Console.WriteLine("Output (" + value + ")");
            Console.ReadKey();
        }
    }
}
