using Where_Did_I_Leave_It.Application.Abstractions.Queries;
using Where_Did_I_Leave_It.Application.DTOs;
using Where_Did_I_Leave_It.Application.Exceptions;
using Where_Did_I_Leave_It.Domain.Repositories;

namespace Where_Did_I_Leave_It.Application.Queries.GetItemHistory
{
    public class GetItemHistoryHandler : IQueryHandler<GetItemHistoryQuery, List<ItemHistoryDTO>>
    {
        private readonly IItemRepository _repository;

        public GetItemHistoryHandler(IItemRepository repository)
            => _repository = repository;

        public async Task<List<ItemHistoryDTO>> HandleAsync(GetItemHistoryQuery query)
        {
            var item = await _repository.GetAsync(query.itemName);

            if (item is null)
            {
                throw new NotFoundItemException(query.itemName);
            }

            return item.History.Select(h => h.AsDTO()).ToList();
        }
    }
}
