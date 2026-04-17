using Where_Did_I_Leave_It.Application.DTOs;
using Where_Did_I_Leave_It.Domain.Entities;

namespace Where_Did_I_Leave_It.Application.Queries
{
    public static class Extension
    {
        public static ItemDTO AsDTO(this Item item)
        {
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Location = item.Location,
                Note = item.Note,
                LastSeenDate = item.LastSeenDate,
            };
        }

        public static ItemHistoryDTO AsDTO(this ItemHistory itemHistory)
        {
            return new ItemHistoryDTO()
            {
                Id = itemHistory.Id,
                Name = itemHistory.Name,
                Location = itemHistory.Location,
                Note = itemHistory.Note,
                CreatedAt = itemHistory.CreatedAt,
                ChangeType = itemHistory.ChangeType.ToString(),
            };
        }
    }
}
