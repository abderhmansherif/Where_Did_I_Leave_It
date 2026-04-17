using Microsoft.EntityFrameworkCore;
using Where_Did_I_Leave_It.Domain.Item;
using Where_Did_I_Leave_It.Domain.Repositories;
using Where_Did_I_Leave_It.Infrastrcuture.EF.Contexts;

namespace Where_Did_I_Leave_It.Infrastrcuture.EF.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DbSet<Item> _items;
        private readonly ItemDbContext _dbContext;

        public ItemRepository(ItemDbContext dbContext)   
        {
            _dbContext = dbContext;
            _items = dbContext.Items;
        }
        public async Task DeleteAsync(Item item)
        {
            _items.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Item> GetAsync(string itemName)
            => await _items.Include(i => i.History).FirstOrDefaultAsync(i => i.Name == itemName);

        public async Task InsertAsync(Item item)
        {
            await _items.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item) 
            => await _dbContext.SaveChangesAsync();
        
    }
}
