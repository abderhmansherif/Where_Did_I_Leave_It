using Where_Did_I_Leave_It.Application.Abstractions.Commands;
using Where_Did_I_Leave_It.Application.Exceptions;
using Where_Did_I_Leave_It.Domain.Factories;
using Where_Did_I_Leave_It.Domain.Repositories;

namespace Where_Did_I_Leave_It.Application.Commands.CreateItem
{
    public class CreateItemHandler : ICommandHandler<CreateItemCommand>
    {
        private readonly IItemRepository _repository;
        private readonly IItemFactory _factory;

        public CreateItemHandler(IItemRepository itemRepository, IItemFactory itemFactory)
        {
            _repository = itemRepository;
            _factory = itemFactory;
        }

        public async Task HandleAsync(CreateItemCommand command)
        {
            var (itemName, location, note) = command;

            var item = await _repository.GetAsync(itemName);

            if(item is not null)
            {
                throw new CreateAlreadyExistItemException();
            }

            var newItem = _factory.Create(itemName, location, note);

            await _repository.InsertAsync(newItem);
        }
    }
}
