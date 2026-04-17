namespace Where_Did_I_Leave_It.Domain.Exceptions
{
    public class DublicatedItemNoteException: ItemException
    {
        public DublicatedItemNoteException(): base("Note cannot be the same as any previous notes.")
        {
            
        }
    }
}
