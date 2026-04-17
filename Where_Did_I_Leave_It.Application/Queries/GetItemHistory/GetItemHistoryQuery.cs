using Where_Did_I_Leave_It.Application.Abstractions.Queries;

namespace Where_Did_I_Leave_It.Application.Queries.GetItemHistory
{
    public record GetItemHistoryQuery(string itemName) : IQuery;
    
}
