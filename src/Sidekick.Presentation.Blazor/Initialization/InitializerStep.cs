using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Sidekick.Application.Initialization
{
    internal class InitializerStep<TNotification> : IInitializerStep
      where TNotification : INotification, new()
    {
        private readonly IMediator mediator;

        public InitializerStep(
            IMediator mediator,
            ServiceFactory serviceFactory,
            string name,
            bool runOnce = false)
        {
            this.mediator = mediator;
            Name = name;
            RunOnce = runOnce;

            Count = serviceFactory.GetInstances<INotificationHandler<TNotification>>().Count();
        }

        public int Count { get; set; } = 0;
        public int Completed { get; set; } = 0;
        public int Percentage => Count == 0 ? 0 : Completed * 100 / Count;

        public string Name { get; }
        public bool RunOnce { get; }

        public async Task Run(bool isFirstRun)
        {
            // Make sure that steps that should be run once are not run multiple times
            if (!isFirstRun && RunOnce)
            {
                Completed = Count;
                return;
            }

            // Publish the notification
            await mediator.Publish(new TNotification());

            // Make sure that after all handlers run, the Completed count is updated
            Completed = Count;
        }
    }
}
