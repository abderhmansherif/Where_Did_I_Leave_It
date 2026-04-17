using Where_Did_I_Leave_It.Domain.Enum;

namespace Where_Did_I_Leave_It.Domain.Entities
{
    public class ItemHistory
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid ItemId { get; private set; }
        public string Location { get; private set; }
        public string Note { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ChangeType ChangeType { get; private set; }

        public Item? Item { get; private set; }
        public ItemHistory(Guid id, string name, Guid itemId, string location, string note, ChangeType changeType)
        {
            Id = id;
            Name = name;
            ItemId = itemId;
            Location = location;
            Note = note;
            CreatedAt = DateTime.UtcNow;
            ChangeType = changeType;
        }


    }
}
