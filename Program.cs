using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace A6FibCallBack_TyroneVeneracion
{
    class Program
    {
        public delegate void WorkStarted();
        public delegate void WorkProgressing();
        public delegate string WorkCompleted();
        static readonly Stopwatch sw = new Stopwatch();
        static void WorkerStartedWork()
        {
            sw.Start();
    
        }
        static string WorkerCompletedWork()
        {
            sw.Stop();
            return "work duration : " + sw.Elapsed.ToString();
        }
        static void Main()
        {
            FibonacciCalculator fc = new FibonacciCalculator();
            IWorker worker1 = new Worker();

            worker1.Started += new WorkStarted(fc.AcceptInput);
            worker1.Started += new WorkStarted(WorkerStartedWork);
            worker1.Progressing += new WorkProgressing(fc.Calculate);

            worker1.Completed += new WorkCompleted(fc.GiveResults);
            worker1.Completed += new WorkCompleted(WorkerCompletedWork);
            worker1.DoWork();

            Console.WriteLine("Main: worker completed work");
            Console.ReadLine();
        }
    }
}
