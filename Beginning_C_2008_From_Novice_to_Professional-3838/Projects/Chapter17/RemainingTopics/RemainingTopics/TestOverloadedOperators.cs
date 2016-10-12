using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemainingTopics {
    public sealed class ComplexType {
        double _real;
        readonly double _imaginary;

        public ComplexType(double real, double imaginary) {
            _real = real;
            _imaginary = imaginary;
        }
        public double Real {
            get {
                return _real;
            }
            set {
                _real = value;
            }
        }
        public double Imaginary {
            get {
                return _imaginary;
            }
        }
        public static ComplexType operator +(ComplexType a, ComplexType b) {
            return new ComplexType(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }
        public static ComplexType operator ++(ComplexType a) {
            return new ComplexType(a.Real + 1, a.Imaginary);
        }
        public override string ToString() {
            return "(" + _real + ") (" + _imaginary + ")i";
        }
    }

    class TestOverloadedOperators {
        static void ComplexAdd() {
            ComplexType a = new ComplexType(1.0, 10.0);
            ComplexType b = new ComplexType(2.0, 20.0);

            ComplexType c = a + b;
        }
        static void CallMethod(ComplexType val) {
            ++val;
            Console.WriteLine("--- " + val.ToString());
        }
        static void ComplexIncrement() {
            ComplexType a = new ComplexType(1.0, 10.0);

            a++;

            Console.WriteLine(a.ToString());
            CallMethod(a);
            Console.WriteLine(a.ToString());
        }
        public static void RunAll() {
            //ComplexAdd();
            ComplexIncrement();
        }
    }
}
