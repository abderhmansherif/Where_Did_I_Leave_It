using System;
using System.Collections.Generic;
using System.Text;
using Where_Did_I_Leave_It.Domain.Exceptions;

namespace Where_Did_I_Leave_It.Application.Exceptions
{
    public class NotFoundItemException: ItemException
    {
        public NotFoundItemException(string itemName): base($"Item with that name '{itemName}' not found.")
        {
            
        }
    }
}
