using Where_Did_I_Leave_It.Application.Abstractions.Commands;

namespace Where_Did_I_Leave_It.Application.Commands.EditItemNote
{
    public record EditItemNoteCommand(string ItemName, string newNote) : ICommand;
    
}
