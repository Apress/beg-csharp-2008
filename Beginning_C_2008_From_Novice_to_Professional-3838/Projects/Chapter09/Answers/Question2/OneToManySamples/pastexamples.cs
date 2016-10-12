using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApplication2 {
    class FirstAddition {
        public int AddAllElements(IList<int> list) {
            int runningTotal = 0;
            foreach (int value in list) {
                runningTotal += value;
            }
            return runningTotal;
        }
        public int SubtractAllElements(IList<int> list) {
            int runningTotal = 0;
            foreach (int value in list) {
                runningTotal -= value;
            }
            return runningTotal;
        }
    }
    
    delegate void FunctorDelegate(int value);
    
    class Action {
        FunctorDelegate _delegate;
        
        public Action AddDelegate(FunctorDelegate deleg) {
            _delegate += deleg;
            return this;
        }
        public void IterateAllElements(IList<int> list) {
            foreach (int value in list) {
                _delegate(value);
            }
        }
    }
    
    class ActionLamda {
        Func< int, bool> _lambda;
        
        
        public ActionLamda AddExpression(Func<int, bool> lambda) {
            _lambda += lambda;
            return this;
        }
        public void IterateAllElements(IList<int> list) {
            foreach (int value in list) {
                _lambda(value);
            }
        }
        public void Method( int x) {
            //runningTotal += x;
        }
    }
        
    
    class TestLambdaexpressions {
        static void DoAddition() {
            Action add = new Action();
            int runningTotal = 0;
            
            add.AddDelegate(
                new FunctorDelegate(
                    delegate( int value) {
                        runningTotal += value;
                    })).IterateAllElements(
                new List< int> { 1, 2, 3, 4});
            Console.WriteLine("Running Total is (" + runningTotal + ")");
        }
        static void DoLambda() {
            ActionLamda cls = new ActionLamda();
            int runningTotal = 0;
            cls.AddExpression(
            (x) => { runningTotal += x; return false;}).IterateAllElements(
                new List<int> { 1, 2, 3, 4 });
        }
        static void DoLambdas() {
            ActionLamda cls = new ActionLamda();
            int runningTotal = 0;
            cls.AddExpression(
            (x) => { return (x % 2) == 0; });
            cls.AddExpression( 
            (x) => (x % 2) == 0).IterateAllElements(
                new List<int> { 1, 2, 3, 4 });
        }
        public static void RunAll() {
            DoAddition();
            DoLambda();
        }
    }
}

