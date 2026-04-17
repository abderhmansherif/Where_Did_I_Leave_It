using Where_Did_I_Leave_It.Application.Abstractions.Commands;
using Where_Did_I_Leave_It.Application.Exceptions;
using Where_Did_I_Leave_It.Domain.Repositories;

namespace Where_Did_I_Leave_It.Application.Commands.RemoveItem
{
    public class RemoveItemHandler : ICommandHandler<RemoveItemCommand>
    {
        private readonly IItemRepository _repository;
        public RemoveItemHandler(IItemRepository repository)
            => _repository = repository;
        
        public async Task HandleAsync(RemoveItemCommand command)
        {
            var item = await _repository.GetAsync(command.itemName);

            if (item is null)
            {
                throw new NotFoundItemException(command.itemName);
            }

            await _repository.DeleteAsync(item);
        }
    }
}
