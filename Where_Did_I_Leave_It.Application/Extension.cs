using Microsoft.Extensions.DependencyInjection;
using Where_Did_I_Leave_It.Application.Abstractions.Commands;
using Where_Did_I_Leave_It.Application.Abstractions.Queries;
using Where_Did_I_Leave_It.Application.Commands;
using Where_Did_I_Leave_It.Application.Commands.CreateItem;
using Where_Did_I_Leave_It.Application.Commands.EditItemLocation;
using Where_Did_I_Leave_It.Application.Commands.EditItemNote;
using Where_Did_I_Leave_It.Application.Commands.RemoveItem;
using Where_Did_I_Leave_It.Application.DTOs;
using Where_Did_I_Leave_It.Application.Queries;
using Where_Did_I_Leave_It.Application.Queries.GetItem;
using Where_Did_I_Leave_It.Application.Queries.GetItemHistory;
using Where_Did_I_Leave_It.Application.Queries.GetItems;
using Where_Did_I_Leave_It.Domain.Factories;

namespace Where_Did_I_Leave_It.Application
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.AddScoped<IQueryDispatcher, InMemoryQueryDispatcher>();

            services.AddSingleton<IItemFactory, ItemFactory>();

            services.AddScoped<ICommandHandler<CreateItemCommand>, CreateItemHandler>();
            services.AddScoped<ICommandHandler<EditItemLocationCommnad>, EditItemLocationHandler>();
            services.AddScoped<ICommandHandler<EditItemNoteCommand>, EditItemNoteHandler>();
            services.AddScoped<ICommandHandler<RemoveItemCommand>, RemoveItemHandler>();

            services.AddScoped<IQueryHandler<GetItemQuery, ItemDTO>, GetItemHandler>();
            services.AddScoped<IQueryHandler<GetItemHistoryQuery, List<ItemHistoryDTO>>, GetItemHistoryHandler>();
            services.AddScoped<IQueryHandler<GetItemsQuery, List<ItemDTO>>, GetItemsHandler>();



            return services;
        }
    }
}
