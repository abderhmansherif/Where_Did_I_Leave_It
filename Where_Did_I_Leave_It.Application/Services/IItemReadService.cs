using Where_Did_I_Leave_It.Application.DTOs;

namespace Where_Did_I_Leave_It.Application.Services
{
    public interface IItemReadService
    {
        Task<List<ItemDTO>> GetItemsAsync();
    }
}
