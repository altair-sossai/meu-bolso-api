using MeuBolso.Modulos.Carteira.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MeuBolso.Context;

public class AppDbContext : DbContext
{
    private static readonly object Locker = new();
    private static bool _migrated;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        MigrateLocked();
    }

    public DbSet<CarteiraEntity> Carteiras { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        var loggerFactory = LoggerFactory.Create(builder => builder
            .AddConsole(_ => { })
            .AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information));

        optionsBuilder.UseLoggerFactory(loggerFactory);
#endif

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = typeof(AppDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }

    private void MigrateLocked()
    {
        if (!Database.IsRelational() || _migrated)
            return;

        lock (Locker)
        {
            Database.Migrate();
            _migrated = true;
        }
    }
}