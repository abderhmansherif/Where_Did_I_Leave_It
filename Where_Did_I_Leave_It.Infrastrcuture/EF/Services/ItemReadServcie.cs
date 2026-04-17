using Microsoft.EntityFrameworkCore;
using Where_Did_I_Leave_It.Application.DTOs;
using Where_Did_I_Leave_It.Application.Queries;
using Where_Did_I_Leave_It.Application.Services;
using Where_Did_I_Leave_It.Domain.Entities;
using Where_Did_I_Leave_It.Infrastrcuture.EF.Contexts;

namespace Where_Did_I_Leave_It.Infrastrcuture.EF.Services
{
    public class ItemReadServcie : IItemReadService
    {
        private readonly DbSet<Item> _items;
        private readonly ItemDbContext _dbContext;
        public ItemReadServcie(ItemDbContext dbContext)
        {
            _dbContext = dbContext;
            _items = dbContext.Items;
        }
        public async Task<List<ItemDTO>> GetItemsAsync()
            => await _items.Select(i => i.AsDTO()).ToListAsync();
    }
}
