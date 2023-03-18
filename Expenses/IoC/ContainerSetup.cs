using Expenses.Data.Access.DAL;
using Expenses.Data.Access.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace Expenses.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(IServiceCollection services,IConfigurationRoot configuration)
        {
            //AddUow()
        }

        private static void AddUow(IServiceCollection services,IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetConnectionString("main");
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<MainDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            services.AddScoped<IUnitofWork>(x => new EFUnitOfWork(x.GetRequiredService<MainDbContext>()));

        }
    }
}
