using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{


    internal class Debouncer
    {
        private readonly Action _action;
        private readonly int _milliseconds;
        private CancellationTokenSource _cts;

        public Debouncer(Action action, int milliseconds)
        {
            _action = action;
            _milliseconds = milliseconds;
        }

        public void Call()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
            }

            _cts = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread.Sleep(_milliseconds);
                if (!_cts.Token.IsCancellationRequested)
                {
                    _action();
                }
            }, null);
        }
    }
}
