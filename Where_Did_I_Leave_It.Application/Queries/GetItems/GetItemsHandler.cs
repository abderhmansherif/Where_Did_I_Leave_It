using Where_Did_I_Leave_It.Application.Abstractions.Queries;
using Where_Did_I_Leave_It.Application.DTOs;
using Where_Did_I_Leave_It.Application.Services;

namespace Where_Did_I_Leave_It.Application.Queries.GetItems
{
    public class GetItemsHandler : IQueryHandler<GetItemsQuery, List<ItemDTO>>
    {
        private readonly IItemReadService _service;
        public GetItemsHandler(IItemReadService service)
            => _service = service;

        public async Task<List<ItemDTO>> HandleAsync(GetItemsQuery query)
            => await _service.GetItemsAsync();
    }
}
