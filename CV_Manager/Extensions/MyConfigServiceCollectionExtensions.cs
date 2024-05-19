using CV_Manager.BLL.Services;
using CV_Manager.BLL.Services.CV_Modules;
using CV_Manager.Core.Contracts;
using CV_Manager.Core.Contracts.CV_Modules;
using CV_Manager.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace CV_Manager.Extensions
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
        public static IServiceScope MigrateDatabase(this IServiceScope app)
        {
            #region applay migration
            var dataContext = app.ServiceProvider.GetRequiredService<AppDbContext>();
            dataContext.Database.Migrate();
            #endregion
            return app;
        }
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {

            #region Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            #endregion

            #region CV Service
            services.AddScoped<ICV_Service, CV_Service>();
            #endregion

            return services;
        }

    }
}
