using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egged.Infrastructure.Helpers
{
    public static class StopwatchHelper
    {
        public static double TimedAction<TResult>(Func<TResult> action, out TResult result)
        {
            result = default(TResult);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = action();
            sw.Stop();
            return Math.Round(sw.Elapsed.TotalMilliseconds/1000,2);
        }

        public static double TimedAction(Action action)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action();
            return Math.Round(sw.Elapsed.TotalMilliseconds / 1000, 2);
        }
    }
}
