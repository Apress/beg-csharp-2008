using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibLightingSystem;

namespace TestLightingSystem {
    static class TestGeneralLinkedList {
        static void GeneralInitialize() {
            GeneralLinkedList lst = new GeneralLinkedList();
            if (lst == null) {
                throw new NullReferenceException();
            }
        }
        static void AddASingleItem() {
            GeneralLinkedList lst = new GeneralLinkedList();

            lst.Add("hello");
        }
        static void AddAndIterate() {
            GeneralLinkedList lst = new GeneralLinkedList();

            lst.Add("hello");
            lst.Add("bye");
            foreach (string item in lst) {
                Console.WriteLine("item (" + item + ")");
            }
        }
        public static void RunAll() {
            GeneralInitialize();
            AddASingleItem();
            AddAndIterate();
        }
    }
}
