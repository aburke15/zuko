using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace Zuko.Data
{
    public static class PersistenceRegistrar
    {
        public static void RegisterPersistence(IServiceCollection services, IConfiguration configuration)
        {
            var mongoUri = configuration.GetConnectionString("MongoDb");
            var dbName = configuration.GetSection("Database")?.Value;

            if (string.IsNullOrWhiteSpace(mongoUri))
                throw new ArgumentNullException(nameof(mongoUri));
            if (string.IsNullOrWhiteSpace(dbName))
                throw new ArgumentNullException(nameof(dbName));

            services.AddDbContext<ApplicationContext>(
                options => options.UseMongoDB(mongoUri, dbName));
        }
    }
}
