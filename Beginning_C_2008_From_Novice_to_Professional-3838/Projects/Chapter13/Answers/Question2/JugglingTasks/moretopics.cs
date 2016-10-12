using System;
using System.Threading;
using System.Collections.Generic;

namespace MoreTopics {
    static class TestMoreTopics {
        static void ReaderWriter() {
            ReaderWriterLock rwlock = new ReaderWriterLock();

            List<int> elements = new List<int>();
            elements.Add(10);
            elements.Add(20);

            Thread thread1 = new Thread(
                                 () => {
                                     Thread.Sleep(1000);
                                     Console.WriteLine("Thread 1 waiting read lock");
                                     rwlock.AcquireReaderLock(-1);
                                     Console.WriteLine("Thread 1 have read lock");
                                     foreach (int item in elements) {
                                         Console.WriteLine("Thread 1 Item (" + item + ")");
                                         Thread.Sleep(1000);
                                     }
                                     Console.WriteLine("Thread 1 releasing read lock");
                                     rwlock.ReleaseLock();
                                 });
            Thread thread2 = new Thread(
                                 () => {
                                     Thread.Sleep(1250);
                                     Console.WriteLine("Thread 2 waiting read lock");
                                     rwlock.AcquireReaderLock(-1);
                                     Console.WriteLine("Thread 2 have read lock");
                                     foreach (int item in elements) {
                                         Console.WriteLine("Thread 2 Item (" + item + ")");
                                         Thread.Sleep(1000);
                                     }
                                     Console.WriteLine("Thread 2 releasing read lock");
                                     rwlock.ReleaseLock();
                                 });
            Thread thread3 = new Thread(
                                 () => {
                                     Thread.Sleep(1750);
                                     Console.WriteLine("Thread 3 waiting read lock");
                                     rwlock.AcquireReaderLock(-1);
                                     Console.WriteLine("Thread 3 have read lock");
                                     foreach (int item in elements) {
                                         Console.WriteLine("Thread 3 Item (" + item + ")");
                                         Thread.Sleep(1000);
                                     }
                                     Console.WriteLine("Thread 3 releasing read lock");
                                     rwlock.ReleaseLock();
                                 });
            Thread thread4 = new Thread(
                                 () => {
                                     Thread.Sleep(1500);
                                     Console.WriteLine("Thread 4 waiting write lock");
                                     rwlock.AcquireWriterLock(-1);
                                     Console.WriteLine("Thread 4 have write Lock");
                                     elements.Add(30);
                                     Console.WriteLine("Thread 4 releasing write lock");
                                     rwlock.ReleaseLock();
                                 });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }
        public static void RunAll() {
            ReaderWriter();
        }
    }
}