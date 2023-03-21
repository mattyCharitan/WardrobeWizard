using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.DataObjects;
using Repositories.Implantation;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IAuthorRepository,AuthorRepository>();
            //get the connection string from configuration...
            //calculate relative connection string...
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\מטי\\source\\repos\\WardrobeWizard\\wardrobeWizard\\DB\\Database.mdf;Integrated Security=True;";
            services.AddDbContext<WardrobeWizard>(options => options.UseSqlServer(connString));
        }
    }
}
