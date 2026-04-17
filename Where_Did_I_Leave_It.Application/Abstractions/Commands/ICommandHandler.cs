namespace Where_Did_I_Leave_It.Application.Abstractions.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
