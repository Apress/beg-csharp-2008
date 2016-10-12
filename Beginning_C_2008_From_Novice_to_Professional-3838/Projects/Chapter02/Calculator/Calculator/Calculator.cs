using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator {
    public class Operations {
        public static int Add(int number1, int number2) {
            return number1 + number2;
        }
    }
    public class OperationsNewType {
        public static double Add(double number1, double number2) {
            return number1 + number2;
        }
        public static double Subtract(double number1, double number2) {
            return number1 - number2;
        }
        public static double Divide(double number1, double number2) {
            return number1 / number2;
        }
        public static double Multiply(double number1, double number2) {
            return number1 * number2;
        }
    }
}
