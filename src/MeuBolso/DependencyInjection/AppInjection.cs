using System.Reflection;
using FluentValidation;
using MeuBolso.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuBolso.DependencyInjection;

public static class AppInjection
{
    public static void AddApp(this IServiceCollection serviceCollection, IConfiguration configuration, params Assembly[] assemblies)
    {
        serviceCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration["MSSQL:ConnectionString"]));
        serviceCollection.AddScoped<DbContext>(s => s.GetRequiredService<AppDbContext>());

        serviceCollection.AddMediatR(c => c.RegisterServicesFromAssemblies(assemblies));
        serviceCollection.AddAutoMapper(assemblies);
        serviceCollection.AddValidatorsFromAssemblies(assemblies);

        serviceCollection.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses()
            .AsImplementedInterfaces(type => assemblies.Contains(type.Assembly)));

        serviceCollection.AddScoped(_ => typeof(AppInjection).Assembly);
    }
}