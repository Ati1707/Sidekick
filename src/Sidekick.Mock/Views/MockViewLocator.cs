using System.Threading.Tasks;
using Sidekick.Domain.Views;

namespace Sidekick.Mock.Views
{
    public class MockViewLocator : IViewLocator
    {
        public Task Open(View view, params object[] args)
        {
            return Task.CompletedTask;
        }

        public bool IsOpened(View view) => true;

        public bool IsAnyOpened() => true;

        public void CloseAll()
        {
            // Do nothing
        }

        public void Minimize(View view)
        {

        }

        public void Maximize(View view)
        {

        }

        public void Close(View view)
        {
            // Do nothing
        }
    }
}
