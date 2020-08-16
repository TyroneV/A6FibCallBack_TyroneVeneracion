using System;

namespace A6FibCallBack_TyroneVeneracion
{
    class Worker : IWorker
    {
        public event Program.WorkStarted Started;
        public event Program.WorkProgressing Progressing;
        public event Program.WorkCompleted Completed;

        public void DoWork()
        {
            Console.WriteLine("Worker: work started");
            Started?.Invoke();
            Console.WriteLine("Worker: work progressing");
            Progressing?.Invoke();
            Console.WriteLine("Worker: work completed");
            if (Completed != null)
            {
                foreach (Program.WorkCompleted wc in Completed.GetInvocationList())
                {
                    wc.BeginInvoke(new AsyncCallback(Result), wc);
                }
            }
        }

        public void Result(IAsyncResult result)
        {
            Program.WorkCompleted wc = (Program.WorkCompleted)result.AsyncState;
            string res = wc.EndInvoke(result);
            Console.WriteLine(res);
        }
    }
}
