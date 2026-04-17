using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Domain.Exceptions
{
    internal class DublicatedItemLocationException : ItemException
    {
        public DublicatedItemLocationException(string itemName,string location): base($"the '{location}' location for '{itemName}' item is already exists.")
        {
            
        }
    }
}
