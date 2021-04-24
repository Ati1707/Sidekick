using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sidekick.Persistence.ItemCategories
{
    public class ItemCategoryRepository : IItemCategoryRepository
    {
        private readonly DbContextOptions<SidekickContext> options;

        public ItemCategoryRepository(DbContextOptions<SidekickContext> options)
        {
            this.options = options;
        }

        public async Task<ItemCategory> Get(string type)
        {
            using var dbContext = new SidekickContext(options);

            return await dbContext.ItemCategories.FindAsync(type);
        }

        public async Task SaveCategory(string type, string category)
        {
            using var dbContext = new SidekickContext(options);

            var itemCategory = await dbContext.ItemCategories.FindAsync(type);

            if (itemCategory == null)
            {
                itemCategory = new ItemCategory()
                {
                    Type = type,
                };
                dbContext.ItemCategories.Add(itemCategory);
            }

            itemCategory.Category = category;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(string type)
        {
            using var dbContext = new SidekickContext(options);

            var itemCategory = await dbContext.ItemCategories.FindAsync(type);

            if (itemCategory != null)
            {
                dbContext.ItemCategories.Remove(itemCategory);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
