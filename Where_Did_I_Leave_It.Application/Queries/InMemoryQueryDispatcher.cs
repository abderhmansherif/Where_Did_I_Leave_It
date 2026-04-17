using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Where_Did_I_Leave_It.Application.Abstractions.Queries;

namespace Where_Did_I_Leave_It.Application.Queries
{
    public class InMemoryQueryDispatcher: IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryQueryDispatcher(IServiceProvider serviceProvider)    
            => _serviceProvider = serviceProvider;  

        public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery where TResult : class
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>(); 
            return await handler.HandleAsync(query);
        }
    }
}
