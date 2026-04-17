using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<Item.Item> GetAsync(string itemName);
        Task InsertAsync(Item.Item item);
        Task UpdateAsync(Item.Item item);
        Task DeleteAsync(Item.Item item);
    }

}
