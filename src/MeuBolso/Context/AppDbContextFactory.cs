using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeuBolso.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        const string connectionString = "Server=localhost;Database=MeuBolso;User Id=sa;Password=ef66b58b-6ff2-4c78-bcec-6b279312b625;TrustServerCertificate=True";

        var construtor = new DbContextOptionsBuilder<AppDbContext>();
        construtor.UseSqlServer(connectionString);

        return new AppDbContext(construtor.Options);
    }
}