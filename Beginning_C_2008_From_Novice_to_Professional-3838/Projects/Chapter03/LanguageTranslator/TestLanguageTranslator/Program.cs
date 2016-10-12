using System;
using System.Collections.Generic;
using System.Text;

namespace TestLanguageTranslator {
    class BasePropertiesObject {
        public static void TestObject() {
            object obj = new Object();
        }

        public static void TestEquals() {
            int a = 2;
            if (a.Equals(2)) {

            }
        }
        public static void TestGetHashCode() {
            int a = 2;
            int b = 2;
            int c = 3;
            if (a.GetHashCode() == b.GetHashCode()) {
                Console.WriteLine("As should be 2 equals 2");
            }
            if (c.GetHashCode() != b.GetHashCode()) {
                Console.WriteLine("As should be 3 does not equals 2");
            }
        }
        public static void TestGetType() {
            int a = 1;
            if (a.GetType().IsValueType == true) {
                Console.WriteLine("a is a value type");
            }
        }
        public static void TestToString() {
            int a = 3;

            string aAsAString = a.ToString();
            if (aAsAString.CompareTo("3") == 0) {
                Console.WriteLine("3 has been converted into a string");
            }
        }
    }
    class Program {
        public static string TrimingWhitespace(string buffer) {
            string trimmed = buffer.Trim();
            return LanguageTranslator.Translator.TranslateHello(trimmed);
        }
        public static string FindSubstring(string buffer) {
            int offset = buffer.IndexOf("allo");
            if (offset != -1) {
                return LanguageTranslator.Translator.TranslateHello("allo");
            }
            else {
                return "";
            }
        }
        public static string FindString(string buffer) {
            char[] characters = buffer.ToCharArray();
            for (int c1 = 0; c1 < characters.Length; c1++) {
                if (characters[c1] == 'a' && characters[c1 + 1] == 'l' &&
                    characters[c1 + 2] == 'l' && characters[c1 + 3] == 'o') {
                    return LanguageTranslator.Translator.TranslateHello("allo");
                }
            }
            return "";
        }
        static void TestTranslateHello2() {
            string verifyValue;

            verifyValue = LanguageTranslator.Translator.TranslateHello("hello");
            if (verifyValue.CompareTo("hallo") != 0) {
                Console.WriteLine("Test failed of hello to hallo");
            }
            verifyValue = LanguageTranslator.Translator.TranslateHello("allo");
            if (verifyValue.CompareTo("hallo") != 0) {
                Console.WriteLine("Test failed of allo to hallo");
            }
            verifyValue = LanguageTranslator.Translator.TranslateHello("allosss");
            if (verifyValue.CompareTo("") != 0) {
                Console.WriteLine("Test to verify non-translated word failed");
            }
            verifyValue = LanguageTranslator.Translator.TranslateHello("  allo");
            if (verifyValue.CompareTo("hallo") != 0) {
                Console.WriteLine("Test failed of extra white spaces allo to hallo");
            }
            verifyValue = LanguageTranslator.Translator.TranslateHello("  Allo");
            if (verifyValue.CompareTo("hallo") != 0) {
                Console.WriteLine("Test failed of extra white spaces allo to hallo");
            }

        }

        static void TestTranslateHello() {
            string verifyValue;

            verifyValue = LanguageTranslator.Translator.TranslateHello("hello");
            if (verifyValue.CompareTo("hallo") != 0) {
                Console.WriteLine("Test failed of hello to hallo");
            }
            verifyValue = LanguageTranslator.Translator.TranslateHello("allo");
            if (verifyValue.CompareTo("hallo") != 0) {
                Console.WriteLine("Test failed of allo to hallo");
            }
            verifyValue = LanguageTranslator.Translator.TranslateHello("allosss");
            if (verifyValue.CompareTo("") != 0) {
                Console.WriteLine("Test to verify non-translated word failed");
            }
            verifyValue = LanguageTranslator.Translator.TranslateHello("  allo");
            if (verifyValue.CompareTo("hallo") != 0) {
                Console.WriteLine("Test failed of extra white spaces allo to hallo");
            }
        }
        static void Main(string[] args) {
            //TestTranslateHello();
            TestTranslateHello2();
            //BasePropertiesObject.TestGetType();
            //BasePropertiesObject.TestToString();
            Console.ReadKey();
        }
    }
}
