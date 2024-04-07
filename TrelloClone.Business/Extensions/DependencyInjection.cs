using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Business.Interfaces;
using TrelloClone.Business.Services;

namespace TrelloClone.Business.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<ICardOrdersService, CardOrdersService>();

            return services;
        }
    }
}
