using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Domain.Factories
{
    public interface IItemFactory
    {
        Item.Item Create(string itemName, string location, string note);
    }
}
