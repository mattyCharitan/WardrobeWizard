using AppServices.Implementations;
using AppServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserSer, UserService>();
            services.AddScoped<IItemSer, ItemService>();
            services.AddScoped<IOutfitSer, OutfitService>();

           //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<IAuthorService,AuthorService>();
            services.AddRepositories();
        }
    }
}
