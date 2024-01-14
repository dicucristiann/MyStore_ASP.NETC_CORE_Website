using Microsoft.EntityFrameworkCore;
using MyStore_ASP_NET_CORE_WebApp.Data;
using PostgreSQL.Data;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Clients> Clients { get; set; }
    public DbSet<HomeProduct> HomeProducts { get; set; }
    public DbSet<Communication> Communications { get; set; }
    public DbSet<Cart> Carts { get; set; }
}