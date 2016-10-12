using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

namespace Threads {
    class ThreadedTask {
        string _whatToSay;
        public ThreadedTask(string whatotsay) {
            _whatToSay = whatotsay;
        }
        public void MethodToRun() {
            Console.WriteLine("I am babbling (" + _whatToSay + ")");
        }
    }
    static class TestThreads {
        static void SimpleThread() {
            Thread thread1 = new Thread(
                                 delegate() {
                                     Console.WriteLine("hello there");
                                 }
            );
            Thread thread2 = new Thread(
                             () => { Console.WriteLine("Well then goodbye"); });

            thread1.Start();
            thread2.Start();
        }
        static void SimpleThreadWithState() {
            Thread thread = new Thread(
            (buffer) => { Console.WriteLine("You said (" + buffer.ToString() + ")"); });
            thread.Start("my text");
        }
        static void ThreadWithState() {
            ThreadedTask task = new ThreadedTask("hello");

            Thread thread = new Thread(new ThreadStart(task.MethodToRun));
            thread.Start();
        }
        static void ThreadWaiting() {
            Thread thread = new Thread(
                                 delegate() {
                                     Console.WriteLine("hello there");
                                     Thread.Sleep(2000);
                                 }
            );
            thread.Start();
            thread.Join();
        }
        public static void RunAll() {
            ThreadWaiting();
        }
    }
}