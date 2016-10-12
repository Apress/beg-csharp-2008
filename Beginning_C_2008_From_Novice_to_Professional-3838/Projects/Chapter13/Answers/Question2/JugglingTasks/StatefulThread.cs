using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JugglingTasks {
    public abstract class StatefulThread {
        protected abstract bool Process();

        void Run() {
            while (true) {
                if (!Process()) {
                    break;
                }
            }
        }
        public void RunThreaded() {
            ThreadStart job = new ThreadStart(Run);
            Thread thread = new Thread(job);
            thread.Start();
        }
    }
}

