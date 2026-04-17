using Where_Did_I_Leave_It.Application.Abstractions.Commands;
using Where_Did_I_Leave_It.Application.Exceptions;
using Where_Did_I_Leave_It.Domain.Repositories;

namespace Where_Did_I_Leave_It.Application.Commands.EditItemNote
{
    public class EditItemNoteHandler : ICommandHandler<EditItemNoteCommand>
    {
        private readonly IItemRepository _repository;
        public EditItemNoteHandler(IItemRepository itemRepository)
            => _repository = itemRepository;
        
        public async Task HandleAsync(EditItemNoteCommand command)
        {
            var (itemName, newNote) = command;

            var item = await _repository.GetAsync(itemName);

            if(item is null)
            {
                throw new NotFoundItemException(itemName);
            }

            item.EditNote(newNote);

            await _repository.UpdateAsync(item);
        }
    }
}
