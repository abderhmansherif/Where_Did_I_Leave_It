using Where_Did_I_Leave_It.Domain.Enum;
using Where_Did_I_Leave_It.Domain.Exceptions;

namespace Where_Did_I_Leave_It.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public string Note { get; private set; }
        public DateTime LastSeenDate { get; private set; }
        public List<ItemHistory> History { get; private set; } = new();

        private Item() { }
        internal Item(Guid id, string name, string location, string note)
        {
            Id = id;
            Name = name;
            Location = location;
            Note = note;
            LastSeenDate = DateTime.UtcNow;

            AddHistory(ChangeType.Created);
        }

        private void AddHistory(ChangeType changeType)
            => History.Add(new ItemHistory.ItemHistory(Guid.NewGuid(), this.Name, this.Id, this.Location, this.Note, changeType));

        public void EditLocation(string newLocation)
        {
            if(string.IsNullOrEmpty(newLocation))
            {
                throw new EmptyItemLocationException();
            }

            this.Location = newLocation;
            this.LastSeenDate = DateTime.UtcNow;

            AddHistory(ChangeType.LocationChanged);
        }

        public void EditNote(string newNote)
        {
            if(string.IsNullOrEmpty(newNote))
            {
                throw new EmptyItemNoteException();
            }

            if(History.Any(h => h.Note.Equals(newNote, StringComparison.OrdinalIgnoreCase)))
            {
                throw new DublicatedItemNoteException();
            }

            this.Note = newNote;
            this.LastSeenDate = DateTime.UtcNow;

            AddHistory(ChangeType.NoteChanged);
        }
    }
}
