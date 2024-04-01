using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrelloClone.DataAccess.EFCore.Repositories;
using TrelloClone.DataAccess.Interfaces.Repositories;

namespace TrelloClone.DataAccess.EFCore.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IListRepository, ListRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            

            return services;
        }
    }
}
