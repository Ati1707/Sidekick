using System.Threading.Tasks;
using Sidekick.Common.Blazor.Views;
using Sidekick.Common.Platform;
using Sidekick.Domain.Keybinds;

namespace Sidekick.Application.Keybinds
{
    public class PriceCheckItemKeybindHandler : IKeybindHandler
    {
        private readonly IViewLocator viewLocator;
        private readonly IClipboardProvider clipboardProvider;
        private readonly IProcessProvider processProvider;

        public PriceCheckItemKeybindHandler(
            IViewLocator viewLocator,
            IClipboardProvider clipboardProvider,
            IProcessProvider processProvider)
        {
            this.viewLocator = viewLocator;
            this.clipboardProvider = clipboardProvider;
            this.processProvider = processProvider;
        }

        public bool IsValid() => processProvider.IsPathOfExileInFocus;

        public async Task Execute()
        {
            var itemText = await clipboardProvider.Copy();
            await viewLocator.Open(View.Trade, itemText);
        }
    }
}
