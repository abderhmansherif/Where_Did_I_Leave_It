using Where_Did_I_Leave_It.Application.Abstractions.Commands;
namespace Where_Did_I_Leave_It.Application.Commands.RemoveItem
{
    public record RemoveItemCommand(string itemName): ICommand;
}
