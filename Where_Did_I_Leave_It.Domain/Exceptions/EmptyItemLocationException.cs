using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Domain.Exceptions
{
    public class EmptyItemLocationException: ItemException
    {
        public EmptyItemLocationException():base("Location cannot be null or empty.")
        {
            
        }
    }
}
