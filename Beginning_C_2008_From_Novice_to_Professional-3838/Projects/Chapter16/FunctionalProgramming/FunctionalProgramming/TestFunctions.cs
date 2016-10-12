using System;


namespace FunctionalProgramming {

    class ClassWithSideEffects {
        public ClassWithSideEffects() {
            _isInitialized = false;
        }
        bool _isInitialized;
        string _value;
        public void Initialize(string value) {
            _isInitialized = true;
            _value = value;
        }
        public string GetMeAValue() {
            if (_isInitialized) {
                return _value;
            }
            throw new NullReferenceException("Not initialized");
        }
    }

    class ClassWithNoSideEffects {
        private readonly string _value;

        public ClassWithNoSideEffects(string value) {
            _value = value;
        }
        public string GetMeAValue() {
            return _value;
        }
    }

    class SalesTax {
        private readonly double _percentage;

        public SalesTax(double percentage) {
            _percentage = percentage;
        }
        public double Percentage {
            get {
                return _percentage;
            }
        }
        public double CalculateGrandTotal(double itemTotal) {
            return itemTotal + itemTotal * _percentage;
        }
    }

    class SalesTaxWithMethod {
        private readonly double _percentage;

        public SalesTaxWithMethod(double percentage) {
            _percentage = percentage;
        }
        public double Percentage {
            get {
                return _percentage;
            }
        }
        public double CalculateGrandTotal(double itemTotal) {
            return itemTotal + itemTotal * _percentage;
        }
        public SalesTaxWithMethod AddPercentage(double percentage) {
            return new SalesTaxWithMethod(percentage + _percentage);
        }
    }


    static class ClassExtension {
        public static SalesTax AddPercentage(this SalesTax cls, double percentage) {
            return new SalesTax(cls.Percentage + percentage);
        }
    }
    public class TestFunctions {
        public static void CodeWithBuggySideEffect() {

        }
        public static void CodeWithoutSideEffectsExtension() {
            ClassWithNoSideEffects cls = new ClassWithNoSideEffects("hello");

        }
        public static void CodeWithoutSideEffectsLambda() {
            ClassWithNoSideEffects cls = new ClassWithNoSideEffects("hello");

            Func<ClassWithNoSideEffects, string, ClassWithNoSideEffects> lambda =
                (clsToModify, boundaries) => new ClassWithNoSideEffects(boundaries + "_" + clsToModify.GetMeAValue() + "_" + boundaries);

            ClassWithNoSideEffects cls2 = lambda(cls, "*****");
        }
        public static void RunAll() {
        }
    }
}