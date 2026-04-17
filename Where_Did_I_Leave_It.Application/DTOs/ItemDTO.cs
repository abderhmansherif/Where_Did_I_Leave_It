using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Application.DTOs
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string  Note { get; set; } = string.Empty;
        public DateTime LastSeenDate { get; set; }
    }
}
