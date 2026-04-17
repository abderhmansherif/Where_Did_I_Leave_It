using System;
using System.Collections.Generic;
using System.Text;

namespace Where_Did_I_Leave_It.Application.Abstractions.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery where TResult : class;
    }
}
