using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Domain.Exceptions
{
    public class EmptyItemNoteException: ItemException
    {
        public EmptyItemNoteException(): base("Note can not be null or empty.")
        {
            
        }
    }
}
