using System;
using System.Collections.Generic;
using System.Text;
using Where_Did_I_Leave_It.Domain.Exceptions;

namespace Where_Did_I_Leave_It.Application.Exceptions
{
    public class CreateAlreadyExistItemException: ItemException
    {
        public CreateAlreadyExistItemException() : base("Cannot create item because it already exists")
        { 
        }
    }
}
