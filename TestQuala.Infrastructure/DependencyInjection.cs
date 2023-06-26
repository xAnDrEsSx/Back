using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestQuala.Application.Contracts.Persistence;
using TestQuala.Infrastructure.Persistence;
using TestQuala.Infrastructure.Repositories;

namespace TestQuala.Infrastructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfraestructuraServices(this IServiceCollection services,
                IConfiguration configuration)
        {
            services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer(Base64Decode(GetConnection().GetConnectionString("Database"))));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IBranchStoreRepository, BranchStoreRepository>();

            return services;
        }

        #region methods
        private static IConfigurationRoot GetConnection()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        #endregion

    }

}
