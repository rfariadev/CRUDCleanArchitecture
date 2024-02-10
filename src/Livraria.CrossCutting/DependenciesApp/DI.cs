using Livraria.Domain;
using Livraria.Infra.Data;
using Livraria.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Livraria.CrossCutting.DependenciesApp;

public static class DI {
  public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config) {
    var connString = config.GetConnectionString("Sqlite");

    services.AddDbContext<AppDbContext>(
      opt => opt.UseSqlite(connString));

    services.AddScoped<ILivroRepository, LivroRepository>();

    return services;
  }
}