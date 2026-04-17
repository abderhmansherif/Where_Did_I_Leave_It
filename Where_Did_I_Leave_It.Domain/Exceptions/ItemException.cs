using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Domain.Exceptions
{
    public class ItemException: Exception
    {
        public ItemException(string msg): base(msg)
        {
            
        }
    }
}
