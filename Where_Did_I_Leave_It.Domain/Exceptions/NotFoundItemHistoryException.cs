using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Domain.Exceptions
{
    internal class NotFoundItemHistoryException: ItemException
    {
        public NotFoundItemHistoryException(string itemName):base($"Not Found Item History for '{itemName}' item")
        {   
        }
    }
}
