using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sidekick.Presentation.Blazor.Debounce
{
    public class Debouncer : IDebouncer
    {
        private readonly Dictionary<string, uint> Debounces = new Dictionary<string, uint>();
        public async Task Debounce(string id, Func<Task> func,
            CancellationToken cancellationToken = new CancellationToken(),
            int refreshRate = 1000,
            int delay = 2000,
            Action<int> delayUpdate = null)
        {
            if (!Debounces.ContainsKey(id))
            {
                Debounces.Add(id, 0);
            }

            if (delayUpdate != null)
            {
                delayUpdate.Invoke(delay);
            }

            var count = ++Debounces[id];
            while (delay > 0)
            {
                await Task.Delay(refreshRate, cancellationToken);
                if (count != Debounces[id])
                {
                    continue;
                }
                delay -= refreshRate;
                if (delayUpdate != null)
                {
                    delayUpdate.Invoke(delay);
                }
            }
            if (count == Debounces[id])
            {
                await func();
            }
        }
    }
}
