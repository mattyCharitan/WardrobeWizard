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
        private static string ReplaceWithCurrentLocation(string connStr)
        {
            string str = AppDomain.CurrentDomain.BaseDirectory;
            string directryAboveBin = str.Substring(0, str.IndexOf("\\bin"));
            string twoDirectoriesAboveBin = directryAboveBin.Substring(0, directryAboveBin.LastIndexOf("\\"));
            connStr = string.Format(connStr, twoDirectoriesAboveBin);
            return connStr;
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IOutfitRepository, OutfitRepository>();
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();
            string connStr = ReplaceWithCurrentLocation("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0}\\DB\\Database.mdf;Integrated Security=True;");
            services.AddDbContext<WardrobeWizard>(options => options.UseSqlServer(connStr));
        }
    }
}
