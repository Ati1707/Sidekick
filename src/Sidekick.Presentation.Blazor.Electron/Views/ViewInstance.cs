using System;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API.Entities;
using Sidekick.Common.Blazor.Views;
using Sidekick.Common.Cache;

namespace Sidekick.Presentation.Blazor.Electron.Views
{
    public class ViewInstance : IViewInstance, IDisposable
    {
        private readonly InternalViewInstance view;
        private readonly ViewLocator locator;
        private readonly ICacheProvider cacheProvider;

        public ViewInstance(
            ViewLocator locator,
            ICacheProvider cacheProvider)
        {
            view = locator.Views.Last();
            this.locator = locator;
            this.cacheProvider = cacheProvider;
        }

        public async Task Initialize(string title, int width = 768, int height = 600, bool isOverlay = false, bool isModal = false, bool closeOnBlur = false)
        {
            Title = title;
            MinWidth = width;
            MinHeight = height;
            view.IsOverlay = isOverlay;

            view.Browser.SetMinimumSize(width, height);
            view.Browser.SetSize(width, height);

            var preferences = await cacheProvider.Get<ViewPreferences>($"view_preference_{view.Key}");
            if (!isModal && preferences != null)
            {
                view.Browser.SetSize(preferences.Width, preferences.Height);
            }

            if (isOverlay)
            {
                view.Browser.SetMaximizable(false);
                view.Browser.SetMinimizable(false);
                view.Browser.SetSkipTaskbar(true);
                view.Browser.SetResizable(true);
                view.Browser.SetAlwaysOnTop(true, OnTopLevel.screenSaver);
                view.Browser.ShowInactive();
            }
            else if (isModal)
            {
                view.Browser.SetMaximizable(false);
                view.Browser.SetMinimizable(false);
                view.Browser.SetSkipTaskbar(false);
                view.Browser.SetResizable(false);
                view.Browser.SetAlwaysOnTop(false);
                view.Browser.ShowInactive();
            }
            else
            {
                view.Browser.SetMaximizable(true);
                view.Browser.SetMinimizable(true);
                view.Browser.SetSkipTaskbar(false);
                view.Browser.SetResizable(true);
                view.Browser.SetAlwaysOnTop(false);
                view.Browser.Show();
            }

            view.Browser.Center();

            if (!isModal)
            {
                view.Browser.OnResize += Browser_OnResize;
            }

            if (closeOnBlur)
            {
                view.Browser.OnBlur += Browser_OnBlur;
            }

            resizeBounce++;
            view.Browser.OnResize -= Browser_OnResize;
            view.Browser.OnBlur -= Browser_OnBlur;
        }

        public string Title { get; private set; } = "Sidekick";

        public int MinWidth { get; set; }

        public int MinHeight { get; set; }

        public bool SavePreferences { get; set; }

        public Task Minimize()
        {
            view.Browser.Minimize();
            return Task.CompletedTask;
        }

        public async Task Maximize()
        {
            if (!await view.Browser.IsMaximizedAsync())
            {
                view.Browser.Maximize();
            }
            else
            {
                var preferences = await cacheProvider.Get<ViewPreferences>($"view_preference_{view.Key}");
                if (preferences != null)
                {
                    MinWidth = preferences.Width;
                    MinHeight = preferences.Height;
                }

                view.Browser.SetSize(MinWidth, MinHeight);
                view.Browser.Center();
            }
        }

        public async Task Close()
        {
            Dispose();

            if (!await view.Browser.IsDestroyedAsync())
            {
                view.Browser.Close();
            }
        }

        private void Browser_OnBlur()
        {
            Dispose();
            view.Browser.Close();
        }

        private ulong resizeBounce = 0;
        private void Browser_OnResize()
        {
            Task.Run(async () =>
            {
                try
                {
                    var currentBounce = ++resizeBounce;
                    await Task.Delay(500);
                    if (currentBounce == resizeBounce)
                    {
                        if (!await view.Browser.IsMaximizedAsync())
                        {
                            var bounds = await view.Browser.GetBoundsAsync();
                            await cacheProvider.Set($"view_preference_{view.Key}", new ViewPreferences()
                            {
                                Width = bounds.Width,
                                Height = bounds.Height
                            });
                        }
                    }
                }
                catch (Exception) { }
            });
        }

        public void Dispose()
        {
            if (locator.Views.Contains(view))
            {
                locator.Views.Remove(view);
            }

            resizeBounce++;
            view.Browser.OnResize -= Browser_OnResize;
            view.Browser.OnBlur -= Browser_OnBlur;
        }
    }
}
