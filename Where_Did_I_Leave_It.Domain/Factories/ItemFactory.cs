using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Domain.Factories
{
    public class ItemFactory : IItemFactory
    {
        public Item.Item Create(string itemName, string location, string note)
        {
            return new Item.Item(Guid.NewGuid(), itemName, location, note);
        }
    }
}
