using Where_Did_I_Leave_It.Application.Abstractions.Queries;
using Where_Did_I_Leave_It.Application.DTOs;
using Where_Did_I_Leave_It.Application.Exceptions;
using Where_Did_I_Leave_It.Domain.Repositories;

namespace Where_Did_I_Leave_It.Application.Queries.GetItem
{
    public class GetItemHandler : IQueryHandler<GetItemQuery, ItemDTO>
    {
        private readonly IItemRepository _repository;
        public GetItemHandler(IItemRepository repository)
            => _repository = repository;
        public async Task<ItemDTO> HandleAsync(GetItemQuery query)
        {
            var item = await _repository.GetAsync(query.ItemName);

            if (item is null)
            {
                throw new NotFoundItemException(query.ItemName);
            }

            return item.AsDTO();
        }
    }
}
