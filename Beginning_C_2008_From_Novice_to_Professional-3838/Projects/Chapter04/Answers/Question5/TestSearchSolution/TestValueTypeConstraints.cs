using System;
using System.Collections.Generic;
using System.Text;

namespace TestSearchSolution {
    struct MyValueType {
        public int value;
    }
    class MyReferenceType {
        public int value;
    }

    struct MyValueTypeWithReferenceType {
        public int value;
        public MyReferenceType reference;
    }

    struct MyValueTypeWithValueType {
        public int value;
        public MyValueType embeddedValue;
    }

    class MyReferenceTypeWithValueType {
        public int value;
        public MyValueType embeddedValue;
    }

    class TestValueTypeConstraints {
        static void Constraint1() {
            MyValueType var = new MyValueType();
            MyValueType copiedVar = var;

            Console.WriteLine("var value=" + var.value +
                " copiedVar value=" + copiedVar.value);
            var.value = 10;
            Console.WriteLine("var value=" + var.value +
                " copiedVar value=" + copiedVar.value);

            MyReferenceType val = new MyReferenceType();
            MyReferenceType copiedVal = val;

            Console.WriteLine("val value=" + val.value +
                " copiedVal value=" + copiedVal.value);
            val.value = 10;
            Console.WriteLine("val value=" + val.value +
                " copiedVal value=" + copiedVal.value);
        }
        static void Constraint2() {
            MyValueTypeWithReferenceType var = new MyValueTypeWithReferenceType();
            var.reference = new MyReferenceType();
            MyValueTypeWithReferenceType copiedVar = var;

            Console.WriteLine("var value=" + var.reference.value +
                " copiedVar value=" + copiedVar.reference.value);
            var.reference.value = 10;
            Console.WriteLine("var value=" + var.reference.value +
                " copiedVar value=" + copiedVar.reference.value);
        }
        static void Method(MyValueType value, MyReferenceType reference) {
            value.value = 10;
            reference.value = 10;
        }
        static void Constraint3() {
            MyValueType value = new MyValueType();
            MyReferenceType reference = new MyReferenceType();
            Method(value, reference);
            Console.WriteLine("value value=" + value.value +
                " reference value=" + reference.value);
        }
        static void TruthTable() {
            MyValueTypeWithValueType var = new MyValueTypeWithValueType();
            //var.embeddedValue = new MyValueType();
            MyValueTypeWithValueType copiedVar = var;

            Console.WriteLine("var value=" + var.embeddedValue.value +
                " copiedVar value=" + copiedVar.embeddedValue.value);
            var.embeddedValue.value = 10;
            Console.WriteLine("var value=" + var.embeddedValue.value +
                " copiedVar value=" + copiedVar.embeddedValue.value);
        }
        public static void Run() {
            //Constraint1();
            //Constraint2();
            Constraint3();
            //TruthTable();
        }
    }
}
