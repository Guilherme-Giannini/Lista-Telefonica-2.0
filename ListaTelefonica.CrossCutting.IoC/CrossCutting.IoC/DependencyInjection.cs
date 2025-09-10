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
            // Bind das configurações do Mongo
            services.Configure<MongoDbSettings>(
                configuration.GetSection("MongoDbSettings"));

            // Registro do contexto
            services.AddSingleton<MongoDbContext>();

            // Registro do repositório
            services.AddScoped<IContatoRepository, ContatoRepository>();

            return services;
        }
    }
}