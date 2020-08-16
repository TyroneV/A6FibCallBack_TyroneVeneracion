using System;
using static A6FibCallBack_TyroneVeneracion.Program;

namespace A6FibCallBack_TyroneVeneracion
{
    interface IWorker
    {
        event WorkStarted Started;
        event WorkProgressing Progressing;
        event WorkCompleted Completed;

        void DoWork();
        void Result(IAsyncResult result);
    }
}
