using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

namespace Synchronization {
    static class TestSynchronization {
        static void ThreadProblem() {
            List<int> elements = new List<int>();
            elements.Add(10);
            elements.Add(20);

            Thread thread1 = new Thread(
                                 () => {
                                     Thread.Sleep(1000);
                                     foreach (int item in elements) {
                                         Console.WriteLine("Item (" + item + ")");
                                         Thread.Sleep(1000);
                                     }
                                 });
            Thread thread2 = new Thread(
                                 () => {
                                     Thread.Sleep(1500);
                                     elements.Add(30);
                                 });
            thread1.Start();
            thread2.Start();
        }
        static void ThreadProblem2() {
            List<int> elements = new List<int>();
            elements.Add(10);
            elements.Add(20);

            Thread thread1 = new Thread(
                                 () => {
                                     Thread.Sleep(1000);
                                     foreach (int item in new ReadOnlyCollection<int>(elements)) {
                                         Console.WriteLine("Item (" + item + ")");
                                         Thread.Sleep(1000);
                                     }
                                 });
            Thread thread2 = new Thread(
                                 () => {
                                     Thread.Sleep(1500);
                                     elements.Add(30);
                                 });
            thread1.Start();
            thread2.Start();
        }
        static void SynchronizedThread() {
            List<int> elements = new List<int>();
            elements.Add(10);
            elements.Add(20);

            Thread thread1 = new Thread(
                                 () => {
                                     Thread.Sleep(1000);
                                     lock (elements) {
                                         foreach (int item in new ReadOnlyCollection<int>(elements)) {
                                             Console.WriteLine("Item (" + item + ")");
                                             Thread.Sleep(1000);
                                         }
                                     }
                                 });
            Thread thread2 = new Thread(
                                 () => {
                                     Thread.Sleep(1500);
                                     lock (elements) {
                                         elements.Add(30);
                                     }
                                 });
            thread1.Start();
            thread2.Start();
        }
        static void SynchronizedAndEfficientThread() {
            List<int> elements = new List<int>();
            elements.Add(10);
            elements.Add(20);

            Thread thread1 = new Thread(
                                 () => {
                                     Thread.Sleep(1000);
                                     int[] items;
                                     lock (elements) {
                                         items = elements.ToArray();
                                     }
                                     foreach (int item in items) {
                                         Console.WriteLine("Item (" + item + ")");
                                         Thread.Sleep(1000);
                                     }
                                 });
            Thread thread2 = new Thread(
                                 () => {
                                     Thread.Sleep(1500);
                                     lock (elements) {
                                         elements.Add(30);
                                     }
                                 });
            thread1.Start();
            thread2.Start();
        }
        static void DeadlockedThread() {
            List<int> elements = new List<int>();
            elements.Add(10);
            elements.Add(20);

            Thread thread1 = new Thread(
                                 () => {
                                     Thread.Sleep(1000);
                                     int[] items;
                                     lock (elements) {
                                         while (elements.Count < 3) {
                                             Thread.Sleep(1000);
                                         }
                                         items = elements.ToArray();
                                     }
                                     foreach (int item in items) {
                                         Console.WriteLine("Item (" + item + ")");
                                         Thread.Sleep(1000);
                                     }
                                 });
            Thread thread2 = new Thread(
                                 () => {
                                     Thread.Sleep(1500);
                                     lock (elements) {
                                         elements.Add(30);
                                     }
                                 });
            thread1.Start();
            thread2.Start();
        }
        static void SafeThread() {
            List<int> elements = new List<int>();
            elements.Add(10);
            elements.Add(20);

            Thread thread1 = new Thread(
                                 () => {
                                     Thread.Sleep(1000);
                                     int[] items;
                                     Monitor.Enter(elements);
                                     while (elements.Count < 3) {
                                         Monitor.Wait(elements, 1000);
                                     }
                                     items = elements.ToArray();
                                     Monitor.Exit(elements);
                                     foreach (int item in items) {
                                         Console.WriteLine("Item (" + item + ")");
                                         Thread.Sleep(1000);
                                     }
                                 });
            Thread thread2 = new Thread(
                                 () => {
                                     Thread.Sleep(1500);
                                     Monitor.Enter(elements);
                                     elements.Add(30);
                                     Monitor.Pulse(elements);
                                     Monitor.Exit(elements);
                                 });
            thread1.Start();
            thread2.Start();
        }
        public static void RunAll() {
            ThreadProblem();
            //ThreadProblem2();
            //SynchronizedThread();
            //SynchronizedAndEfficientThread();
            //DeadlockedThread();
            //SafeThread();
        }
    }
}