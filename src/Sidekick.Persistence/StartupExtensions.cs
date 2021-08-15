using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sidekick.Common.Extensions;
using Sidekick.Domain.Cache;
using Sidekick.Domain.Game.Leagues;
using Sidekick.Domain.Views;
using Sidekick.Persistence.Cache;
using Sidekick.Persistence.ItemCategories;
using Sidekick.Persistence.Leagues;
using Sidekick.Persistence.Views;

namespace Sidekick.Persistence
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddSidekickPersistence(this IServiceCollection services)
        {
            var connectionString = "Filename=" + SidekickPaths.GetDataFilePath("data.db");

            services.AddDbContextPool<SidekickContext>(options => options.UseSqlite(connectionString));

            var builder = new DbContextOptionsBuilder<SidekickContext>();
            builder.UseSqlite(connectionString);
            var context = new SidekickContext(builder.Options);
            context.Database.Migrate();

            services.AddTransient<ICacheRepository, CacheRepository>();
            services.AddTransient<IItemCategoryRepository, ItemCategoryRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<IViewPreferenceRepository, ViewPreferenceRepository>();

            return services;
        }
    }
}
