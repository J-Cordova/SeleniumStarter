using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Framework
{
    public class WaitHelper
    {
        public static void WaitFor(Func<bool> action, int trys = 10, TimeSpan waitInterval = default)
        {
            if (waitInterval == default) waitInterval = TimeSpan.FromMilliseconds(500);

            for (int i = 1; i < trys; i++)
            {
                var result = action();
                if (result)
                {
                    break;
                }
                else if (i == trys)
                {
                    throw new TimeoutException($"Timeout occured after {trys} attempts");
                }
                else
                {
                    Task.Delay(waitInterval).Wait();
                }
            }
        }
    }
}
