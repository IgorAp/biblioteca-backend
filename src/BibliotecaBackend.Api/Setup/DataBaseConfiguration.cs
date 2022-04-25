using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaBackend.Infra.Data.WriteModel;
using BibliotecaBackend.Infra.Data.ReadModel;

namespace BibliotecaBackend.Api.Setup
{
    public static class DataBaseConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<BibliotecaContext>(options =>
                options.UseSqlServer(connection)
            );
            services.Configure<MongoDbOptions>(configuration.GetSection("MongoDbOptions"));
            services.AddDataProtection();
        }
    }
}
