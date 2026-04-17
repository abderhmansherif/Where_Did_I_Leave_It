using Where_Did_I_Leave_It.Application.Abstractions.Commands;
using Where_Did_I_Leave_It.Application.Exceptions;
using Where_Did_I_Leave_It.Domain.Repositories;

namespace Where_Did_I_Leave_It.Application.Commands.EditItemLocation
{
    public class EditItemLocationHandler : ICommandHandler<EditItemLocationCommnad>
    {
        private readonly IItemRepository _repository;

        public EditItemLocationHandler(IItemRepository itemRepository)
            => _repository = itemRepository;
        
        public async Task HandleAsync(EditItemLocationCommnad command)
        {
            var (itemName, newLocation) = command;

            var item = await _repository.GetAsync(itemName);

            if (item == null)
            {
                throw new NotFoundItemException(itemName);
            }

            item.EditLocation(newLocation);

            await _repository.UpdateAsync(item);
        }
    }
}
