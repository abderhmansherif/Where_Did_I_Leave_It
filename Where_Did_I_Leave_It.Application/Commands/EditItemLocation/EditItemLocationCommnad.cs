using Where_Did_I_Leave_It.Application.Abstractions.Commands;

namespace Where_Did_I_Leave_It.Application.Commands.EditItemLocation
{
    public record EditItemLocationCommnad(string itemName, string newLocation): ICommand;
   
}
