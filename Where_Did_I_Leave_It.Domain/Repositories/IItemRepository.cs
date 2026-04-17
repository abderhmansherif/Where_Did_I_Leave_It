using System;
using System.Collections.Generic;
using System.Text;
using Where_Did_I_Leave_It.Domain.Entities;

namespace Where_Did_I_Leave_It.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetAsync(string itemName);
        Task InsertAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Item item);
    }

}
