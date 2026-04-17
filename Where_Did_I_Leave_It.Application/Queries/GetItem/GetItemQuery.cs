using Where_Did_I_Leave_It.Application.Abstractions.Queries;

namespace Where_Did_I_Leave_It.Application.Queries.GetItem
{
    public record GetItemQuery(string ItemName) : IQuery;
}
