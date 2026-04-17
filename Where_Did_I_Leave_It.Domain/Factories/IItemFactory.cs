using System;
using System.Collections.Generic;
using System.Text;
using Where_Did_I_Leave_It.Domain.Entities;

namespace Where_Did_I_Leave_It.Domain.Factories
{
    public interface IItemFactory
    {
        Item Create(string itemName, string location, string note);
    }
}
