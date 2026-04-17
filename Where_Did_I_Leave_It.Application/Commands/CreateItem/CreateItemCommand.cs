using Where_Did_I_Leave_It.Application.Abstractions.Commands;

namespace Where_Did_I_Leave_It.Application.Commands.CreateItem
{
    public record CreateItemCommand(string itemName, string location, string note): ICommand;
    
}
