using ListaTelefonica.Application.Abstractions.Repositories;
using ListaTelefonica.Infrastructure;
using ListaTelefonica.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ListaTelefonica.Infrastructure.Persistence;
namespace ListaTelefonica.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.Configure<MongoDbSettings>(
                configuration.GetSection("MongoDbSettings"));

          
            services.AddSingleton<MongoDbContext>();

           
            services.AddScoped<IContatoRepository, ContatoRepository>();

            return services;
        }
    }
}